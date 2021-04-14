using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.IotHub.Models;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;

namespace EE579.Core.Slices.IotHub.Impl
{
    public class IotMessagingService
    {
        private const string ConnectionString = "HostName=IFTTT-Iot-Hub.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=jPmQczB+G9YtEyVGMprjBVCCu7Z843QHFgR65QkfxMk=";
        private static ServiceClient _serviceClient = ServiceClient.CreateFromConnectionString(ConnectionString);

        public static async Task SendMessage(string deviceId, Dictionary<string, string> propertyBag, object body)
        {
            string body_ = JsonConvert.SerializeObject(body);
            var msg = new Message(Encoding.ASCII.GetBytes(body_));

            foreach (var property in propertyBag)
                msg.Properties.Add(property.Key, property.Value);

            await _serviceClient.SendAsync(deviceId, msg);
        }

        //public Task SendOutputMessage(string mac, IOutputPropertyBag propertyBag, object body)
        //{
        //    string body_ = JsonConvert.SerializeObject(body);
        //    var msg = new Message(Encoding.ASCII.GetBytes(body_));


        //    msg.Properties.Add("OutputType", propertyBag.GetOutputType());
        //    var periph = propertyBag.GetPeripheral();
        //    if(periph != null)
        //        msg.Properties.Add("Peripheral", prop)

        //    await serviceClient.SendAsync(deviceId, msg);
        //}
    }
}
