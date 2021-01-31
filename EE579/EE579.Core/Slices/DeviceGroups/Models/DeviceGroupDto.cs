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
        /// <summary>
        /// A list of the device id's that belong to the group
        /// </summary>
        /// <example>[00:0a:95:9d:68:16]</example>
        public List<string> Devices { get; set; }
    }
}
