using EE579.Domain.Entities;

namespace EE579.Core.Slices.Users
{
    public interface ICurrentUser
    {
        public User Get();
    }
}
