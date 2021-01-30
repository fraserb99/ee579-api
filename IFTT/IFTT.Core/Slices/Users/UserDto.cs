using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFTT.Core.Slices.Tenants.Models;

namespace IFTT.Core.Slices.Users.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public List<TenantDto> Tenants { get; set; }
    }
}
