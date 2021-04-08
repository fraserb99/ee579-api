using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class TenantUser
    {
        public Guid TenantId { get; set; }
        public Guid UserId { get; set; }
        public Role Role { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual User User { get; set; }
    }
}
