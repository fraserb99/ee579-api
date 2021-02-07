using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class Device
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string IpAddress { get; set; }
        [Required]
        public virtual Tenant Tenant { get; set; }
        [Required]
        public DeviceState DeviceState { get; set; }
        public virtual ICollection<RuleInput> Inputs { get; set; }
        public virtual ICollection<RuleOutput> Outputs { get; set; }
        public virtual ICollection<DeviceGroup> DeviceGroups { get; set; }
    }
}
