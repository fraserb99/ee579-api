using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Users.Models
{
    public class UserInput
    {
        public Role Role { get; set; }
    }
}
