using System;
using System.Collections.Generic;
using EE579.Core.Slices.Users.Models;

namespace EE579.Core.Slices.Tenants.Models
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
