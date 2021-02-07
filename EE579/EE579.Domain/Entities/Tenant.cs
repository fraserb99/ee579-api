using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE579.Domain.Entities
{
    public class Tenant : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual User Owner { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
