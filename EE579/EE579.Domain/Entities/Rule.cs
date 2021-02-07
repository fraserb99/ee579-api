using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE579.Domain.Entities
{
    public class Rule : Entity
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<RuleInput> Inputs { get; set; }
        public virtual ICollection<RuleOutput> Outputs { get; set; }
        [Required]
        public virtual Tenant Tenant { get; set; }
    }
}
