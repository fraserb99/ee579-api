using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Settings;
using EE579.Domain;
using EE579.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EE579.Core.Slices.Auth.External
{
    public class GoogleAuthProvider : ExternalProvider, IExternalProvider
    {
        public GoogleAuthProvider(UserManager<User> userManager, DatabaseContext context)
            : base(userManager, context) { }

        protected override string GetAuthority()
        {
            return "https://accounts.google.com";
        }

        protected override string GetAudience()
        {
            return "394944070114-das844gmn89hk3t9npp62680n52tjtlu.apps.googleusercontent.com";
        }
    }
}
