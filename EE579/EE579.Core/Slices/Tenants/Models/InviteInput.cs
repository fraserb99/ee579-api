using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Tenants.Models
{
    public class InviteInput
    {
        [Required]
        public string Email { get; set; }
    }
}
