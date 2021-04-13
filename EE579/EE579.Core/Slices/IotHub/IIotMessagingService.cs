using EE579.Core.Slices.IotHub.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub
{
    public interface IIotMessagingService
    {
        public Task SendMessage(string mac, Dictionary<string, string> propertyBag, object body);
       // public Task SendOutputMessage(string mac, IOutputPropertyBag propertyBag, object body);
    }
}
