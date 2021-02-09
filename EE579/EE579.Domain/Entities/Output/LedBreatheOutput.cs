using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class LedBreatheOutput : RuleOutput
    {
        public LedBreatheOutput()
            : base(OutputType.LedBreathe) { }

        public int Period { get; set; }
        public LedColour Colour { get; set; }
        public LedPeripheral Peripheral { get; set; }
    }
}
