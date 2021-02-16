using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class RuleInput : EntityWithGuid
    {
        public RuleInput(InputType type)
        {
            Type = type;
        }

        [Required]
        public virtual Device Device { get; set; }
        [Required]
        public InputType Type { get; set; }
    }
}
