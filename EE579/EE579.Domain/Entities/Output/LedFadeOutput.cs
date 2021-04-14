using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.IotHub.Messages;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Output
{
    public class LedFadeOutput : RuleOutput
    {
        public LedFadeOutput()
            : base(OutputType.LedFade) { }

        public int Period { get; set; }
        public LedColour Colour { get; set; }
        public LedPeripheral Peripheral { get; set; }

        protected override CloudToDeviceMessage CreateMessageCore()
        {
            return new OutputMessage(OutputType, Peripheral);
        }
        protected override object BuildMessageBody()
        {
            return new
            {
                Period,
                Colour,
            };
        }
    }
}
