using System;
using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Auth.Models
{
    public class RefreshTokenInput
    {
        /// <summary>
        /// The refresh token to be used to refresh a user's session when expired
        /// </summary>
        [Required]
        public Guid RefreshToken { get; set; }
    }
}
