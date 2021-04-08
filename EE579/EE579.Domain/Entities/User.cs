using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EE579.Domain.Entities
{
    public class User : EntityWithGuid
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid RefreshToken { get; set; }

        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual List<TenantUser> TenantUsers { get; set; }
    }
}
