using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Slices.Users.Models;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Tenants
{
    public interface ITenantService : ICrudAppService<Tenant, TenantInput>
    {
        public IEnumerable<TenantDto> Get();
        public Task<UserDto> Invite(InviteInput input, Guid tenantId);
        public Task RevokeAccess(Guid userId);
        public Task<TenantDto> Create(TenantInput input);
        public Task<TenantDto> Update(Guid tenantId, TenantInput input);
    }
}
