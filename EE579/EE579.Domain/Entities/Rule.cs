using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE579.Domain.Entities
{
    public class Rule : EntityWithTenant<Guid>
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<RuleInput> Inputs { get; set; }
        public virtual ICollection<RuleOutput> Outputs { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
