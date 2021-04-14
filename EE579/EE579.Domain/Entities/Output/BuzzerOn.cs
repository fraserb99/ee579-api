using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class BuzzerOnOutput : RuleOutput
    {
        public BuzzerOnOutput()
            : base(OutputType.BuzzerOn) { }
        public int Duration { get; set; }
        protected override object BuildMessageBody()
        {
            return new
            {
                Duration
            };
        }
    }
}
