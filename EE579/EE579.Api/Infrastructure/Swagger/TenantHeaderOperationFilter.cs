using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EE579.Api.Infrastructure.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EE579.Api.Infrastructure.Swagger
{
    public class TenantHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<RequiresTenantAttribute>();

            var allowNoHeader = 
                context.MethodInfo.GetCustomAttributes(true)
                    .OfType<RequiresTenantAttribute>()
                    .Any(x => x.Required == false)
                ||
                context.MethodInfo.GetCustomAttributes(true)
                    .OfType<AllowAnonymousAttribute>()
                    .Any();

            if (attributes != null && attributes.Count() > 0 && !allowNoHeader)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "tenant-id",
                    In = ParameterLocation.Header,
                    Description = "The id of the current tenant, required to scope the requests to that tenant",
                    Schema = new OpenApiSchema()
                    {
                        Type = "String",
                        Example = new OpenApiString("704040c2-63d8-11eb-ae93-0242ac130002")
                    }
                });
            } else if (allowNoHeader)
            {
                operation.Parameters.Remove(operation.Parameters.FirstOrDefault(x => x.Name == "tenant-id"));
            }
        }
    }
}
