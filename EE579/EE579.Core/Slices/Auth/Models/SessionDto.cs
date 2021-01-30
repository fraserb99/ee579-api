using EE579.Core.Slices.Users.Models;

namespace EE579.Core.Slices.Auth.Models
{
    public class SessionDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
