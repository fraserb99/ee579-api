using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE579.Domain.Entities
{
    public class Tenant : EntityWithGuid
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual List<TenantUser> TenantUsers { get; set; }
    }
}
