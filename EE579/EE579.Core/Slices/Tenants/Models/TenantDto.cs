using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE579.Core.Slices.Users.Models;

namespace EE579.Core.Slices.Tenants.Models
{
    public class TenantDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// A list of ids of users in that tenant
        /// </summary>
        [Required]
        public List<Guid> Users { get; set; }
    }
}
