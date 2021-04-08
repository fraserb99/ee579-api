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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EE579.Core.Slices.Users.Impl
{
    public class UserService : IUserService
    {
        private readonly IAuthService _authService;
        private readonly ICurrentUser _currentUser;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, DatabaseContext context, IAuthService authService, ICurrentUser currentUser, UserManager<User> userManager)
        {
            _mapper = mapper;
            _context = context;
            _authService = authService;
            _currentUser = currentUser;
            _userManager = userManager;
        }

        public async Task<SessionDto> Create(CreateUserInput input)
        {
            if (input.Password != input.PasswordConfirm)
                throw new FormErrorException(new List<FieldError>
                {
                    new FieldError("password", "Passwords must match"),
                    new FieldError("passwordConfirm", "Passwords must match")
                });
            if (await _context.Users.AnyAsync(x => x.Email == input.Email))
                throw new FormErrorException(new FieldError("email", "This email has already been used"));

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(input.Email);
            if (!match.Success)
                throw new FormErrorException(new FieldError("email", "The email is invalid"));

            var user = new User
            {
                UserName = input.Name,
                Email = input.Email,
                RefreshToken = Guid.NewGuid(),
            };
            var result = await _userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
                throw new FormErrorException(new FieldError("email", "There was an error creating your account, please try again"));

            await _context.AddAsync(new Tenant
            {
                Name = $"{input.Name}'s Tenant",
                TenantUsers = new List<TenantUser>
                {
                    new TenantUser
                    {
                        User = user,
                        Role = Role.Owner
                    }
                }
            });
            await _context.SaveChangesAsync();

            var token = await _authService.CreateToken(user);
            var userDto = _mapper.Map<UserDto>(user);
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
            var tenantDtos = _mapper.Map<List<TenantDto>>(tenants);

            return tenantDtos;
        }

        public Task<User> Update(Guid id, UserInput input)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Create(UserInput input)
        {
            throw new NotImplementedException();
        }
    }
}
