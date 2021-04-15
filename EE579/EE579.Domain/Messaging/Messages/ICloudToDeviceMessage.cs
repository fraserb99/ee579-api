using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub.Models
{
    public interface ICloudToDeviceMessage
    {
        public Dictionary<string, string> GetProperties();
        public object GetBody();
    }
}
