using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;

namespace EE579.Core.Slices.IotHub.Impl
{
    public class IotMessagingService : IIotMessagingService
    {
        private static ServiceClient serviceClient;
        private static string connectionString = "HostName=IFTTT-Iot-Hub.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=jPmQczB+G9YtEyVGMprjBVCCu7Z843QHFgR65QkfxMk=";

        public IotMessagingService()
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        public async Task SendMessage(string deviceId, Dictionary<string, string> propertyBag, object body)
        {
            string body_ = JsonConvert.SerializeObject(body);
            var msg = new Message(Encoding.ASCII.GetBytes(body_));

            foreach (var property in propertyBag)
                msg.Properties.Add(property.Key, property.Value);

            await serviceClient.SendAsync(deviceId, msg);
        }
    }
}
