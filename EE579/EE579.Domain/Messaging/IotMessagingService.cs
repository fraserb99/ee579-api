﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.IotHub.Models;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EE579.Core.Slices.IotHub.Impl
{
    public class IotMessagingService
    {
        private const string ConnectionString = "HostName=IFTTT-Iot-Hub.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=jPmQczB+G9YtEyVGMprjBVCCu7Z843QHFgR65QkfxMk=";
        private static ServiceClient _serviceClient = ServiceClient.CreateFromConnectionString(ConnectionString);

        public static async Task SendMessage(string deviceId, Dictionary<string, string> propertyBag, object bodyObj)
        {
            string body = JsonConvert.SerializeObject(bodyObj);
            var jObj = JObject.Parse(body);
            foreach (var property in propertyBag)
                jObj.Add(property.Key, property.Value);
            body = jObj.ToString(Formatting.None);

            var message = new Message(Encoding.ASCII.GetBytes(body));

            await _serviceClient.SendAsync(deviceId, message);
        }

        public static Task SendMessage(string deviceId, ICloudToDeviceMessage message)
        {
            return SendMessage(deviceId, message.GetProperties(), message.GetBody());
        }

        //public Task BuildMessageBody(string mac, IOutputPropertyBag propertyBag, object body)
        //{
        //    string body_ = JsonConvert.SerializeObject(body);
        //    var msg = new Message(Encoding.ASCII.GetBytes(body_));


        //    msg.Properties.Add("Type", propertyBag.GetOutputType());
        //    var periph = propertyBag.GetPeripheral();
        //    if(periph != null)
        //        msg.Properties.Add("Peripheral", prop)

        //    await serviceClient.SendAsync(deviceId, msg);
        //}
    }
}
