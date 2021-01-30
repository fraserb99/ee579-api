using IFTT.Core.Slices.Users.Models;

namespace IFTT.Core.Slices.Auth.Models
{
    public class SessionDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
