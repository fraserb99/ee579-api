using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Auth.Models
{
    public class LoginInput
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
