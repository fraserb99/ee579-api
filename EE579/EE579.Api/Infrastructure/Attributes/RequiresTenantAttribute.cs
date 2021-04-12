using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using EE579.Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EE579.Api.Infrastructure.Attributes
{
    public class RequiresTenantAttribute : Attribute, IResourceFilter
    {
        private const string TenantHeaderName = "tenant-id";
        public bool Required { get; set; } = true;

        public RequiresTenantAttribute()
        {
            
        }

        public RequiresTenantAttribute(bool required)
        {
            Required = required;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(TenantHeaderName, out var tenantHeader) || tenantHeader.IsNullOrEmpty())
                throw new HttpStatusCodeException(403, "The 'tenant-id' header is required for this request");

            if (!Guid.TryParse(tenantHeader, out var tenantId))
                throw new HttpStatusCodeException(400, "The 'tenant-id' header must be a valid Guid");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
