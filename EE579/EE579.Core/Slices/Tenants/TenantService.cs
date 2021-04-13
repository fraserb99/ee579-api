using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Infrastructure.Exceptions;
using EE579.Core.Infrastructure.Exceptions.Models;
using EE579.Core.Infrastructure.Extensions;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Email;
using EE579.Core.Slices.Email.Models;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Slices.Users;
using EE579.Core.Slices.Users.Models;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Extensions;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EE579.Core.Slices.Tenants
{
    public class TenantService : CrudAppService<Tenant, TenantInput>, ITenantService
    {
        private readonly UserManager<User> _userManager;
        private readonly DatabaseContext _context;
        private readonly IEmailService _emailService;
        private readonly ICurrentUser _currentUser;
        private readonly AppSettings _appSettings;
        private readonly HttpContext _httpContext;
        
        public TenantService(DatabaseContext context, IMapper mapper, UserManager<User> userManager, IEmailService emailService, ICurrentUser currentUser, IOptions<AppSettings> options, IHttpContextAccessor httpContextAccessor) 
            : base(context, mapper)
        {
            _emailService = emailService;
            _context = context;
            _userManager = userManager;
            _currentUser = currentUser;
            _appSettings = options.Value;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public IEnumerable<TenantDto> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Invite(InviteInput input, Guid tenantId)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if(user == null)
            {
                user = new User
                {
                    UserName = input.Email,
                    Email = input.Email
                };
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                    throw new FormErrorException(new FieldError("email", "The was a problem inviting this user"));
                user = await _userManager.FindByEmailAsync(input.Email);
            }
            else if (await _context.TenantUsers.AnyAsync(x => x.TenantId == tenantId && x.UserId == user.Id))
                throw new FormErrorException(new FieldError("email", "A user with this email already has access to this tenant"));
            
            var tenantUser = new TenantUser { 
                TenantId = tenantId,
                UserId = user.Id,
                Role = input.Role
            };
            await _context.TenantUsers.AddAsync(tenantUser);
            await _context.SaveChangesAsync();
            var email = new TenantInviteEmail(await _currentUser.Get(), user, _appSettings.AdminUrl);

            await _emailService.SendEmail(user.Email, email);

            return Mapper.Map<UserDto>(tenantUser);
        }

        public async Task RevokeAccess(Guid userId)
        {
            var tenantId = _httpContext.GetTenantId();

            var tenantUser = await _context.TenantUsers.FindAsync(tenantId, userId);
            if (tenantUser == null)
                throw new HttpStatusCodeException(404);

            _context.TenantUsers.Remove(tenantUser);
            await _context.SaveChangesAsync();
        }

        public async Task<TenantDto> Create(TenantInput input)
        {
            var userId = _httpContext.GetUserId();
            await ValidateCreateInputAsync(input);
            var tenant = Mapper.Map<Tenant>(input);

            await Repository.AddAsync(tenant);
            await Repository.SaveChangesAsync();
            var tenantUser = new TenantUser
            {
                TenantId = tenant.Id,
                UserId = userId,
                Role = Role.Owner
            };
            await Repository.AddAsync(tenantUser);
            await Repository.SaveChangesAsync(true);

            return Mapper.Map<TenantDto>(tenantUser);
        }
    }
}
