using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace EE579.Core.Slices.Auth.External
{
    public abstract class ExternalProvider : IExternalProvider
    {
        private readonly UserManager<User> _userManager;
        private readonly DatabaseContext _context;

        protected ExternalProvider(UserManager<User> userManager, DatabaseContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        protected string GetConfigEndpoint()
        {
            return "/.well-known/openid-configuration";
        }

        protected abstract string GetAuthority();

        protected abstract string GetAudience();

        private async Task<OpenIdConnectConfiguration> GetConfig()
        {
            var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(GetAuthority() + GetConfigEndpoint(), new OpenIdConnectConfigurationRetriever());
            return await configManager.GetConfigurationAsync();
        }

        protected virtual string GetEmailClaim(ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.Email);
        }

        protected virtual string GetNameClaim(ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.Name);
        }

        public bool IssuedToken(string issuer)
        {
            return issuer == GetAuthority();
        }

        public async Task<User> AutoProvisionUserFromToken(string token)
        {
            var config = await GetConfig();

            var validationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = GetAuthority(),

                ValidAudience = GetAudience(),
                IssuerSigningKeys = config.SigningKeys,

                ValidateLifetime = true,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParams, out var validatedToken);

            var email = GetEmailClaim(claimsPrincipal);

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
                return user;

            var name = GetNameClaim(claimsPrincipal);
            user = new User
            {
                UserName = email,
                Email = email,
                Name = name,
                RefreshToken = Guid.NewGuid(),
            };
            await _userManager.CreateAsync(user);

            await _context.AddAsync(new Tenant
            {
                Name = $"{name}'s Tenant",
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

            return user;
        }
    }
}
