using System;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DeviceState DeviceState { get; set; }
    }
}
