using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;

namespace EE579.Domain.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid? GetTenantId(this HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("x-tenant-id", out var tenantId))
                return null;

            return tenantId.IsNullOrEmpty() ? null : new Guid?(new Guid(tenantId.ToString()));
        }
    }
}
