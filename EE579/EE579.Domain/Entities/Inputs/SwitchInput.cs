using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Inputs
{
    public class SwitchInput : RuleInput
    {
        public SwitchInput()
            : base(InputType.Switch) { }
        public bool Value { get; set; }
        public SwitchPeripheral Peripheral { get; set; }
    }
}
