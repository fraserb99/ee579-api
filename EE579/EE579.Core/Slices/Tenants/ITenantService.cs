﻿using System;
using System.Collections.Generic;
using System.Text;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Tenants.Models;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Tenants
{
    public interface ITenantService : ICrudAppService<Tenant, TenantDto>
    {
        public IEnumerable<TenantDto> Get();
    }
}
