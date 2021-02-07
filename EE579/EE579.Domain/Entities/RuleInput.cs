using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class RuleInput : Entity
    {
        [Required]
        public virtual Device Device { get; set; }
        [Required]
        public InputType Type { get; set; }
        public string Params { get; set; }
    }
}
