using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub.Models
{
    public class ConnectionStateEvent
    {
        public string id { get; set; }
        public string topic { get; set; }
        public string subject { get; set; }
        public string eventType { get; set; }
        public Data data { get; set; }
        public string dataVersion { get; set; }
        public string metadataVersion { get; set; }
        public DateTime eventTime { get; set; }
    }

    public class Data
    {
        public DeviceConnectionStateEventInfo deviceConnectionStateEventInfo { get; set; }
        public string hubName { get; set; }
        public string deviceId { get; set; }
    }

    public class DeviceConnectionStateEventInfo
    {
        public string sequenceNumber { get; set; }
    }

}
