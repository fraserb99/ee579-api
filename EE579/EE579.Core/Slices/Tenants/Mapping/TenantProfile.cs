using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EE579.Core.Slices.Tenants.Models;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Tenants.Mapping
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<TenantInput, Tenant>();
            CreateMap<Tenant, TenantDto>();
            CreateMap<TenantUser, TenantDto>()
                .IncludeMembers(x => x.Tenant);
        }
    }
}
