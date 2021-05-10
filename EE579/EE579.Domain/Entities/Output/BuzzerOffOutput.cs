using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class BuzzerOffOutput : RuleOutput
    {
        public BuzzerOffOutput()
            : base(OutputType.BuzzerOff) { }
        protected override object BuildMessageBody()
        {
            return new { };
        }
    }
}
