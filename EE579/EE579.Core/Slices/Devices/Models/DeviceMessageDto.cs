using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceMessageDto
    {
        public string DeviceId { get; set; }
        public string MessageBody { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
