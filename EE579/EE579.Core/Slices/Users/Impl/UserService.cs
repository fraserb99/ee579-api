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
using EE579.Core.Infrastructure.Exceptions;
using EE579.Core.Infrastructure.Exceptions.Models;
using EE579.Core.Slices.Tenants.Models;

namespace EE579.Core.Slices.Users.Impl
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly IAuthService _authService;
        private readonly ICurrentUser _currentUser;
        public UserService(IMapper mapper, DatabaseContext context, IAuthService authService, ICurrentUser currentUser)
        {
            _mapper = mapper;
            _context = context;
            _authService = authService;
            _currentUser = currentUser;
        }

        public SessionDto Create(CreateUserInput input)
        {
            if (input.Password != input.PasswordConfirm ) 
                throw new FormErrorException(new List<FieldError>
                {
                    new FieldError("password", "Passwords must match"),
                    new FieldError("passwordConfirm", "Passwords must match")
                });
            if (_context.Users.FirstOrDefault(x => x.Email == input.Email) != null) 
                throw new FormErrorException(new FieldError("email", "This email has already been used"));
                
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(input.Email);
            if (!match.Success) throw new Exception();

            var user = _mapper.Map<User>(input);
            user.OwnedTenants = new List<Tenant> {
                new Tenant {
                    Name = $"{user.Name}'s Tenant" 
                }
            };


            user.RefreshToken = Guid.NewGuid();

            _context.Users.Add(user);
            _context.SaveChanges();

            var token = _authService.CreateToken(user);
            var userDto = _mapper.Map<UserDto>(user);
            var session = new SessionDto { 
                User = userDto,
                Token = token,
                RefreshToken = user.RefreshToken
            };

            return session;
        }

        public IEnumerable<TenantDto> GetTenants()
        {
            var currentUser = _currentUser.Get();

            var tenants = currentUser.GetTenants();
            var tenantDtos = _mapper.Map<List<TenantDto>>(tenants);

            return tenantDtos;
        }
    }
}
