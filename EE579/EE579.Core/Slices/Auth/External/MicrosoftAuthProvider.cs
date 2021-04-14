using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain;
using EE579.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EE579.Core.Slices.Auth.External
{
    public class MicrosoftAuthProvider : ExternalProvider, IExternalProvider
    {
        public MicrosoftAuthProvider(UserManager<User> userManager, DatabaseContext context)
            : base(userManager, context) { }

        protected override string GetAuthority()
        {
            return "https://login.microsoftonline.com/631e0763-1533-47eb-a5cd-0457bee5944e/v2.0";
        }

        protected override string GetAudience()
        {
            return "2159bbf6-2fd9-4cad-aa56-dfab875f1cd5";
        }

        protected override string GetNameClaim(ClaimsPrincipal claims)
        {
            return claims.FindFirstValue("name");
        }
    }
}
