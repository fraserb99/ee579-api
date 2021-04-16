using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Rules.Models.Outputs
{
    public class LedCycleOutputDto : RuleOutputDto
    {
        public int Period { get; set; }
        public bool Direction { get; set; }
    }
}
