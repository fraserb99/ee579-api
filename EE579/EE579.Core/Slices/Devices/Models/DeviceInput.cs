using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceInput
    {
        [Required]
        public string Name { get; set; }
    }
}
