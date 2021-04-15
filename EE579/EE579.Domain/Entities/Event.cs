using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Domain.Entities
{
    public class Event : EntityWithTenant<Guid>
    {
        [Required]
        public DateTime Timestamp { get; set; }
        public Guid RuleId { get; set; }
        public virtual Rule Rule {get;set;}
    }
}
