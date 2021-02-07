using EE579.Core.Slices.Auth.Models;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Slices.Auth
{
    public interface IAuthService
    {
        public SessionDto Login(LoginInput input);
        public SessionDto RefreshToken(RefreshTokenInput input);
        public string CreateToken(User user);
    }
}
