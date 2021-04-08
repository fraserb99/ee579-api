using System;
using System.Linq;
using System.Net;
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

        public static IPAddress GetIpAddress(this HttpContext context)
        {
            return context.Connection.RemoteIpAddress; //var ip = context.Request.Headers
        }
    }
}
