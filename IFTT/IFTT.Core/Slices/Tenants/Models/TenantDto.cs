using System;
using System.Collections.Generic;
using IFTT.Core.Slices.Users.Models;

namespace IFTT.Core.Slices.Tenants.Models
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
