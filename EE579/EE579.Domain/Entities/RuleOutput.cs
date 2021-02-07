using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Core.Slices.Rules.Models;

namespace EE579.Domain.Entities
{
    public class RuleOutput : Entity
    {
        [Required]
        public virtual Device Device { get; set; }
        [Required]
        public OutputType OutputType { get; set; }
        public string Params { get; set; }
    }
}
