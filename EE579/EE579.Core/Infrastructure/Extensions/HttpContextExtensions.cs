using System;
using System.Linq;
using System.Security;
using System.Security.Claims;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;

namespace EE579.Core.Infrastructure.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var id = context.User.Identity.Name;
            if (id.IsNullOrEmpty()) throw new SecurityException();

            return new Guid(id);
        }

        public static Guid GetTenantId(this HttpContext context)
        {
            var exists = context.Request.Headers.TryGetValue("tenant-id", out var header);
            if (!exists) throw new Exception();
            
            return new Guid(header.FirstOrDefault());
        }
    }
}
