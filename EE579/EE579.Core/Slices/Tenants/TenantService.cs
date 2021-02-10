using System;
using System.Collections.Generic;
using System.Text;
using EE579.Core.Slices.Tenants.Models;

namespace EE579.Core.Slices.Tenants
{
    public class TenantService : ITenantService
    {

        public TenantService()
        {
        }

        public IEnumerable<TenantDto> Get()
        {
            throw new NotImplementedException();
        }
    }
}
