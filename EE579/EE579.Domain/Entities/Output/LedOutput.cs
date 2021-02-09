using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class LedOutput : RuleOutput
    {
        public LedOutput()
            : base(OutputType.LedOutput) { }

        public bool Value { get; set; }
        public LedColour Colour { get; set; }
        public LedPeripheral Peripheral { get; set; }
    }
}
