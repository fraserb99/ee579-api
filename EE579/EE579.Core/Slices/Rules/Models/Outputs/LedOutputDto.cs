using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models.Outputs
{
    public class LedOutputDto : RuleOutputDto
    {
        public LedPeripheral Peripheral { get; set; }
        public LedColour? Colour { get; set; }
        public bool Value { get; set; }
    }
}
