using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class BuzzerOnOutput : RuleOutput
    {
        public BuzzerOnOutput()
            : base(OutputType.BuzzerOn) { }
        public int Duration { get; set; }
    }
}
