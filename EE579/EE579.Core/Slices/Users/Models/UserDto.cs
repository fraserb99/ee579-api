﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Slices.Tenants.Models;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Users.Models
{
    public class UserDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public UserStatus Status { get; set; }

        public List<TenantDto> Tenants { get; set; }
    }
}
