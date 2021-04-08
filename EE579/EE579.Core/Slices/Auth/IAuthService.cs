using EE579.Core.Slices.Auth.Models;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Auth
{
    public interface IAuthService
    {
        public Task<SessionDto> Login(LoginInput input);
        public Task<SessionDto> RefreshToken(RefreshTokenInput input);
        public string CreateToken(User user);
    }
}
