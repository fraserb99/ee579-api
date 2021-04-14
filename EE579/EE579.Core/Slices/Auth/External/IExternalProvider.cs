using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Auth.External
{
    public interface IExternalProvider
    {
        public bool IssuedToken(string issuer);
        public Task<User> AutoProvisionUserFromToken(string token);
    }
}
