using System;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Tenants
{
    public interface ICurrentTenant
    {
        public Guid? GetId();
        public Tenant Get();
    }
}
