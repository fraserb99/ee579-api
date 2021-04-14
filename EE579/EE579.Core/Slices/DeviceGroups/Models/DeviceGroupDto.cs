using System;
using System.Collections.Generic;
using System.Text;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.DeviceGroups.Models
{
    public class DeviceGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalDevices { get; set; }
        /// <summary>
        /// A list of the devices that belong to the group
        /// </summary>
        public List<DeviceDto> Devices { get; set; }
    }
}
