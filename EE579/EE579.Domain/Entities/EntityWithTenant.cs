using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Domain.Entities
{
    public class EntityWithTenant<TId> : Entity<TId>
    {
        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
