using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Auth.Models
{
    public class LoginInput
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
