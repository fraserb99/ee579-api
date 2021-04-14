using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class BuzzerBeepOutput : RuleOutput
    {
        public BuzzerBeepOutput()
            : base(OutputType.BuzzerBeep) { }

        public int OnDuration { get; set; }
        public int OffDuration { get; set; }
        protected override object BuildMessageBody()
        {
            return new
            {
                OnDuration,
                OffDuration
            };
        }
    }
}
