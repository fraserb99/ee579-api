using AutoMapper;
using EE579.Core.Slices.Auth;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Users.Models;
using EE579.Domain;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EE579.Core.Slices.Users.Impl
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly IAuthService _auth;
        public UserService(IMapper mapper, DatabaseContext context, IAuthService auth)
        {
            _mapper = mapper;
            _context = context;
            _auth = auth;
        }

        public SessionDto Create(CreateUserInput input)
        {
            if (input.Password == null || input.Email == null || input.PasswordConfirm == null) throw new Exception();
            if (input.Password != input.PasswordConfirm ) throw new Exception();
            if (_context.Users.FirstOrDefault(x => x.Email == input.Email) != null) throw new Exception();
                
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(input.Email);
            if (!match.Success) throw new Exception();

            var user = _mapper.Map<User>(input);
            user.OwnedTenants.Add(new Tenant {
                Name = user.Name
            });


            user.RefreshToken = Guid.NewGuid();

            _context.Users.Add(user);
            _context.SaveChanges();

            var token = _auth.CreateToken(user);
            var userDto = _mapper.Map<UserDto>(user);
            var session = new SessionDto { 
                User = userDto,
                Token = token,
                RefreshToken = user.RefreshToken
            };

            return session;
        }
    }
}
