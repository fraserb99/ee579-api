using System;
using EE579.Core.Infrastructure.Extensions;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Extensions;
using Microsoft.AspNetCore.Http;

namespace EE579.Core.Slices.Tenants
{
    public class CurrentTenant : ICurrentTenant
    {
        private readonly HttpContext _httpContext;
        private readonly DatabaseContext _db;
        public CurrentTenant(IHttpContextAccessor httpContextAccessor, DatabaseContext db)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _db = db;
        }

        public Guid? GetId()
        {
            return _httpContext.GetTenantId();
        }

        public Tenant Get()
        {
            return _db.Tenants.Find(_httpContext.GetTenantId());
        }
    }
}
