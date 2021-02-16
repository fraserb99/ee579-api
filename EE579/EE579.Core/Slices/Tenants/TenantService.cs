using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Tenants.Models;
using EE579.Domain;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Tenants
{
    public class TenantService : CrudAppService<Tenant, TenantInput>, ITenantService
    {

        public TenantService(DatabaseContext context, IMapper mapper) 
            : base(context, mapper) { }

        public IEnumerable<TenantDto> Get()
        {
            throw new NotImplementedException();
        }
    }
}
