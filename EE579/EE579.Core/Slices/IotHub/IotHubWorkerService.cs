using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using EE579.Core.Slices.IotHub.Models;
using EE579.Core.Slices.Rules.Processing;
using EE579.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EE579.Core.Slices.IotHub
{
    public class IotHubWorkerService : BackgroundService
    {
        private const string storageConnectionString =
            "DefaultEndpointsProtocol=https;AccountName=ee579;AccountKey=WqI+aE+oDEDPFQ40kASEZQsJjTHaS6hLrbI4KxKG8Pu2hf2Xlaanh5nsuLNT09Q54pn7xBpYQIhBeJ6e5xpEvw==;EndpointSuffix=core.windows.net";

        private const string containerName = "iothub";

        private const string eventHubConnString =
            "Endpoint=sb://ihsuprodlnres008dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=J1Sut+o+80t3UsKGH9alr2aghIyy+tJykfoXPSrg9kc=;EntityPath=iothub-ehub-ifttt-iot-7659698-d1cdec4b32";
        private const string eventHubName = "iothub-ehub-ifttt-iot-7659698-d1cdec4b32";

        private const string deviceStateConnString =
            "Endpoint=sb://ee579-event-hub.servicebus.windows.net/;SharedAccessKeyName=service;SharedAccessKey=OFeR4dTrtqz4aJVYeb3SpzZhrwJ6EhtKuU/Pgyj6H1w=;EntityPath=connection-hub";
        private const string deviceStateHubName = "ee579-event-hub";

        private readonly IConfiguration _configuration;
        private readonly EventProcessorClient _eventProcessor;
        private readonly EventProcessorClient _deviceStateProcessor;

        public IotHubWorkerService(IConfiguration configuration)
        {
            _configuration = configuration;
            var storageClient = new BlobContainerClient(storageConnectionString, containerName);

            _eventProcessor = new EventProcessorClient(
                storageClient,
                EventHubConsumerClient.DefaultConsumerGroupName,
                eventHubConnString,
                eventHubName);

            _deviceStateProcessor = new EventProcessorClient(
                storageClient,
                EventHubConsumerClient.DefaultConsumerGroupName,
                deviceStateConnString);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _eventProcessor.ProcessEventAsync += ProcessEventHandler;
                _eventProcessor.ProcessErrorAsync += ProcessErrorHandler;

                _deviceStateProcessor.ProcessEventAsync += ProcessConnectionStateChange;
                _deviceStateProcessor.ProcessErrorAsync += ProcessErrorHandler;

                try
                {
                    await _eventProcessor.StartProcessingAsync(stoppingToken);
                    await _deviceStateProcessor.StartProcessingAsync(stoppingToken);
                    await Task.Delay(Timeout.Infinite, stoppingToken);
                }
                catch (TaskCanceledException _) { }
                finally
                {
                    await _eventProcessor.StopProcessingAsync();
                }
            }
            catch { }
            finally
            {
                _eventProcessor.ProcessEventAsync -= ProcessEventHandler;
                _eventProcessor.ProcessErrorAsync -= ProcessErrorHandler;
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _eventProcessor.StopProcessingAsync();
            await base.StopAsync(cancellationToken);
        }

        private async Task ProcessEventHandler(ProcessEventArgs args)
        {
            try
            {
                args.UpdateCheckpointAsync();
                Console.WriteLine(args.Data.EnqueuedTime.DateTime + ": " + args.Data.EventBody);
                await using var ruleProcessor = RuleProcessorFactory.CreateRuleProcessor(args, _configuration);
                if (ruleProcessor == null) return;
                
                await ruleProcessor?.ProcessInput();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task ProcessErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.Message);
        }

        private async Task ProcessConnectionStateChange(ProcessEventArgs args)
        {
            Console.WriteLine(args.Data.EnqueuedTime.DateTime + ": " + args.Data.EventBody);
            var message = args.Data.EventBody.ToObjectFromJson<List<ConnectionStateEvent>>().First();

            var contextBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            contextBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_configuration.GetConnectionString("Default"));
            await using var context = new DatabaseContext(contextBuilder.Options, new HttpContextAccessor());
            var device = await context.Devices.FindAsync(message.data.deviceId);

            if (device == null)
            {
                await args.UpdateCheckpointAsync();
                return;
            }

            if (message.eventType == "Microsoft.Devices.DeviceConnected")
            {
                device.NotifyOfInputs();
                if (device.LastConnectionTime < message.eventTime)
                {
                    device.LastConnectionTime = message.eventTime;
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                if (device.LastDisconnectionTime < message.eventTime)
                {
                    device.LastDisconnectionTime = message.eventTime;
                    await context.SaveChangesAsync();
                }
            }

            await args.UpdateCheckpointAsync();
        }
    }
}
