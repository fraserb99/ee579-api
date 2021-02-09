using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models.Inputs
{
    public class SwitchInputDto : RuleInputDto
    {
        public bool Value { get; set; }
        public SwitchPeripheral Peripheral { get; set; }
    }
}
