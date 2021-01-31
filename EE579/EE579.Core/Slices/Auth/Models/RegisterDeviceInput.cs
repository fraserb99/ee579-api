using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Auth.Models
{
    public class RegisterDeviceInput
    {
        /// <summary>
        /// The MAC address of the device, to be used as a unique identifier
        /// </summary>
        /// <example>00:0a:95:9d:68:16</example>
        [Required]
        public string DeviceId { get; set; }
    }
}
