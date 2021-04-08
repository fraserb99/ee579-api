using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
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

        private readonly EventProcessorClient _eventProcessor;

        public IotHubWorkerService()
        {
            var storageClient = new BlobContainerClient(storageConnectionString, containerName);

            _eventProcessor = new EventProcessorClient(
                storageClient,
                EventHubConsumerClient.DefaultConsumerGroupName,
                eventHubConnString,
                eventHubName);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _eventProcessor.ProcessEventAsync += ProcessEventHandler;
                _eventProcessor.ProcessErrorAsync += ProcessErrorHandler;

                try
                {
                    await _eventProcessor.StartProcessingAsync(stoppingToken);
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
                Console.WriteLine(args.Data.EnqueuedTime.DateTime.ToString() + ": " + args.Data.EventBody.ToString());
            }
            catch { }
        }

        private async Task ProcessErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.Message);
        }
    }
}
