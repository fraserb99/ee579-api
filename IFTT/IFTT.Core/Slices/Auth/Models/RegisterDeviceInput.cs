using System.ComponentModel.DataAnnotations;

namespace IFTT.Core.Slices.Auth.Models
{
    public class RegisterDeviceInput
    {
        /// <summary>
        /// The MAC address of the device, to be used as a unique identifier
        /// </summary>
        /// <example>Test</example>
        [Required]
        public string DeviceId { get; set; }
    }
}
