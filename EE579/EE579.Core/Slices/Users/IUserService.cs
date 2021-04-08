using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Infrastructure.Services;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Users
{
    public interface IUserService : ICrudAppService<User, UserInput>
    {
        public Task<SessionDto> Create(CreateUserInput input);
        public Task<IEnumerable<TenantDto>> GetTenants();
    }
}
