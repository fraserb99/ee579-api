using EE579.Core.Slices.Auth.Models;
using EE579.Domain;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
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
