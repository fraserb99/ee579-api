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
            if (context == null)
                return null;

            if (!context.Request.Headers.TryGetValue("tenant-id", out var tenantId))
                return null;
            var idString = tenantId.ToString();
            return idString.IsNullOrEmpty() ? null : new Guid?(new Guid(idString));
        }
    }
}
