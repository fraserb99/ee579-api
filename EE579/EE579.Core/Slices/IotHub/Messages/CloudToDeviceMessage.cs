using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.IotHub.Models;

namespace EE579.Core.Slices.IotHub.Messages
{
    public class CloudToDeviceMessage : ICloudToDeviceMessage
    {
        public Dictionary<string, string> Properties = new Dictionary<string, string>();
        public object Body;

        public Dictionary<string, string> GetProperties()
        {
            return Properties;
        }

        public object GetBody()
        {
            return Body;
        }
    }
}
