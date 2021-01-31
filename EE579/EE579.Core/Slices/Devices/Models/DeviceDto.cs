using System;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Whether the device has been claimed by a tenant
        /// </summary>
        /// <example>Claimed</example>
        public DeviceState DeviceState { get; set; }
    }
}
