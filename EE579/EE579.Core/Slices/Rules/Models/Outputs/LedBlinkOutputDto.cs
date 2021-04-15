using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models.Outputs
{
    public class LedBlinkOutputDto : RuleOutputDto
    {
        public int Period { get; set; }
        public LedColour? Colour { get; set; }
        public LedPeripheral Peripheral { get; set; }
    }
}
