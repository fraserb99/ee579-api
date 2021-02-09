using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class LedCycleOutput : RuleOutput
    {
        public LedCycleOutput()
            : base(OutputType.LedCycle) { }

        public bool Direction { get; set; }
        public int Period { get; set; }
    }
}
