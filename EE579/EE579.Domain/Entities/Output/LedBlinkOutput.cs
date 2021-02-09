using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class LedBlinkOutput : RuleOutput
    {
        public LedBlinkOutput()
            : base(OutputType.LedBlink) { }

        public int Period { get; set; }
        public LedColour Colour { get; set; }
        public LedPeripheral Peripheral { get; set; }
    }
}
