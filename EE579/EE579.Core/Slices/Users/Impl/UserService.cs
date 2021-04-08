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
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Exceptions;
using EE579.Core.Infrastructure.Exceptions.Models;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Infrastructure.Services;
using EE579.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EE579.Core.Slices.Users.Impl
{
    public class UserService : CrudAppService<User, UserInput>, IUserService
    {
        private readonly IAuthService _authService;
        private readonly ICurrentUser _currentUser;
        public UserService(IMapper mapper, DatabaseContext context, IAuthService authService, ICurrentUser currentUser)
            : base(context, mapper)
        {
            _authService = authService;
            _currentUser = currentUser;
        }

        public async Task<SessionDto> Create(CreateUserInput input)
        {
            if (input.Password != input.PasswordConfirm)
                throw new FormErrorException(new List<FieldError>
                {
                    new FieldError("password", "Passwords must match"),
                    new FieldError("passwordConfirm", "Passwords must match")
                });
            if (await Repository.Users.AnyAsync(x => x.Email == input.Email))
                throw new FormErrorException(new FieldError("email", "This email has already been used"));

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(input.Email);
            if (!match.Success) 
                throw new FormErrorException(new FieldError("email", "The email is invalid"));

            var user = Mapper.Map<User>(input);

            user.RefreshToken = Guid.NewGuid();

            await Repository.Users.AddAsync(user);
            await Repository.SaveChangesAsync();

            var tenant = new Tenant
            {
                Name = $"{user.Name}'s Tenant",
                TenantUsers = new List<TenantUser>
                {
                    new TenantUser
                    {
                        Role = Role.Owner,
                        User = user
                    }
                }
            };
            await Repository.AddAsync(tenant);
            await Repository.SaveChangesAsync();

            var token = _authService.CreateToken(user);
            var userDto = Mapper.Map<UserDto>(user);
            var session = new SessionDto
            {
                User = userDto,
                Token = token,
                RefreshToken = user.RefreshToken
            };

            return session;
        }

        public async Task<IEnumerable<TenantDto>> GetTenants()
        {
            var currentUser = await _currentUser.Get();

            var tenants = currentUser.Tenants;
            var tenantDtos = Mapper.Map<List<TenantDto>>(tenants);

            return tenantDtos;
        }

        public override async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public override async Task<User> Create(UserInput input)
        {
            throw new NotImplementedException();
        }
    }
}
