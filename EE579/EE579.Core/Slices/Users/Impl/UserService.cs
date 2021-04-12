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
using System.Web;
using EE579.Core.Infrastructure.Exceptions;
using EE579.Core.Infrastructure.Exceptions.Models;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Email;
using EE579.Core.Slices.Email.Models;
using EE579.Domain.Extensions;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EE579.Core.Slices.Users.Impl
{
    public class UserService : IUserService
    {
        private readonly IAuthService _authService;
        private readonly ICurrentUser _currentUser;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly AppSettings _appSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly HttpContext _httpContext;

        public UserService(IMapper mapper, 
            DatabaseContext context,
            IAuthService authService,
            ICurrentUser currentUser,
            UserManager<User> userManager,
            IEmailService emailService,
            IOptions<AppSettings> options,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _authService = authService;
            _currentUser = currentUser;
            _userManager = userManager;
            _emailService = emailService;
            _appSettings = options.Value;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task Create(CreateUserInput input)
        {
            if (input.Password != input.PasswordConfirm)
                throw new FormErrorException(new List<FieldError>
                {
                    new FieldError("password", "Passwords must match"),
                    new FieldError("passwordConfirm", "Passwords must match")
                });
            if (await _context.Users.AnyAsync(x => x.Email == input.Email && x.PasswordHash != null))
                throw new FormErrorException(new FieldError("email", "This email has already been used"));

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(input.Email);
            if (!match.Success)
                throw new FormErrorException(new FieldError("email", "The email is invalid"));

            IdentityResult result;
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user != null)
            {
                user.Name = input.Name;
                user.RefreshToken = Guid.NewGuid();
                result = await _userManager.AddPasswordAsync(user, input.Password);
            }
            else
            {
                user = new User
                {
                    UserName = input.Email,
                    Email = input.Email,
                    Name = input.Name,
                    RefreshToken = Guid.NewGuid(),
                };
                result = await _userManager.CreateAsync(user, input.Password);
                user = await _userManager.FindByIdAsync(user.Id.ToString());
            }

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
            var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await _emailService.SendEmail(user.Email, new EmailConfirmationEmail(user, confirmEmailToken, _appSettings.ApiUrl));
        }

        public async Task<IEnumerable<TenantDto>> GetTenants()
        {
            var currentUser = await _currentUser.Get();

            var tenants = currentUser.Tenants;
            var tenantDtos = _mapper.Map<List<TenantDto>>(tenants);

            return tenantDtos;
        }

        public async Task ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var decoded = HttpUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
                throw new Exception();
        }

        public async Task<UserDto> Update(Guid id, UserInput input)
        {
            var tenantUser = await _context.TenantUsers.FindAsync(new[] {_httpContext.GetTenantId(), id});

            tenantUser = _mapper.Map(input, tenantUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(tenantUser);
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAll()
        {
            var tenantUsers = await _context.TenantUsers.Include(x => x.User).ToListAsync();

            var userDtos = _mapper.Map<List<UserDto>>(tenantUsers);

            return userDtos;
        }

        public Task<UserDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
