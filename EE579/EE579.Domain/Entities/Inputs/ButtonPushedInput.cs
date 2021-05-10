using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Inputs
{
    public class ButtonPushedInput : RuleInput
    {
        public ButtonPushedInput() 
            : base(InputType.ButtonPushed) { }

        public ButtonPeripheral Peripheral { get; set; }
        public int Duration { get; set; }
    }
}
