using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE579.Domain.Entities
{
    public class DeviceGroup : EntityWithGuid
    {
        [Required]
        public string Name { get; set; }
        public virtual Tenant Tenant {get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
