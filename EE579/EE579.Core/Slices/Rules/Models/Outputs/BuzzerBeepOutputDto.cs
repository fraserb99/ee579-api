using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Rules.Models.Outputs
{
    public class BuzzerBeepOutputDto : RuleOutputDto
    {
        public int OnDuration { get; set; }
        public int OffDuration { get; set; }
    }
}
