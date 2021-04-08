using System.Threading.Tasks;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Users
{
    public interface ICurrentUser
    {
        public Task<User> Get();
    }
}
