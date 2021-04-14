using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.DeviceGroups.Models
{
    public class DeviceGroupInput
    {
        [Required]
        public string Name { get; set; }
        public List<Entity<string>> Devices { get; set; }
    }
}
