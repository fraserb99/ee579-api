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
    public interface IUserService
    {
        public Task Create(CreateUserInput input);
        public Task<IEnumerable<TenantDto>> GetTenants();
        public Task ConfirmEmail(string userId, string token);
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> GetById(Guid id);
        public Task<UserDto> Update(Guid id, UserInput input);
        public Task Delete(Guid id);
    }
}
