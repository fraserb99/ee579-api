using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE579.Core.Slices.DeviceGroups.Models
{
    public class DeviceGroupInput
    {
        [Required]
        public string Name { get; set; }
        public List<string> Devices { get; set; }
    }
}
