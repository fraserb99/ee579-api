using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EE579.Domain.Entities
{
    public class User : Entity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid RefreshToken { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Tenant> OwnedTenants { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
