using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class RuleInput : EntityWithTenant<Guid>
    {
        public RuleInput(InputType type)
        {
            Type = type;
        }
        public Guid RuleId { get; set; }

        public virtual Rule Rule { get; set; }
        [Required]
        public virtual Device Device { get; set; }
        [Required]
        public InputType Type { get; set; }
    }
}
