using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE579.Api.Infrastructure.Attributes
{
    public class RequiresTenantAttribute : Attribute
    {
        public bool Required { get; set; }

        public RequiresTenantAttribute(bool required = true)
        {
            Required = required;
        }
    }
}
