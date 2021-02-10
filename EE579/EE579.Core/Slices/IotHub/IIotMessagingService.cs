using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub
{
    public interface IIotMessagingService
    {
        public Task SendMessage(string mac, Dictionary<string, string> propertyBag, object body);
    }
}
