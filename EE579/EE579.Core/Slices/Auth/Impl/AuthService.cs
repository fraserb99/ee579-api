using EE579.Core.Slices.Auth.Models;
using EE579.Domain;
using EE579.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EE579.Core.Slices.Auth.Impl
{
    public class AuthService : IAuthService
    {

        private readonly DatabaseContext _context;

        public AuthService(DatabaseContext context)
        {
            _context = context;
        }

        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ee579secret");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),  
                }),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public SessionDto Login(LoginInput input)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == input.Email);
            if (user == null)
                throw new Exception();


            throw new NotImplementedException();
        }

        public SessionDto RefreshToken(RefreshTokenInput input)
        {
            throw new NotImplementedException();
        }
    }
}
