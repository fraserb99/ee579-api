using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EE579.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid RefreshToken { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual List<TenantUser> TenantUsers { get; set; }
    }
}
