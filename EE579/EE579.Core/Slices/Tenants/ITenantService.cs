using System;
using System.Collections.Generic;
using System.Text;
using EE579.Core.Slices.Tenants.Models;

namespace EE579.Core.Slices.Tenants
{
    public interface ITenantService
    {
        public IEnumerable<TenantDto> Get();
    }
}
