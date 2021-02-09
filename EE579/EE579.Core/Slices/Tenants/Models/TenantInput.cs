using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Tenants.Models
{
    public class TenantInput
    {
        [Required]
        public string Name { get; set; }
    }
}
