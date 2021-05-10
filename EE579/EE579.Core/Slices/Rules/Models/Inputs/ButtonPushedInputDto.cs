using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models.Inputs
{
    public class ButtonPushedInputDto : RuleInputDto
    {
        public ButtonPeripheral Peripheral { get; set; }
        public int Duration { get; set; }
    }
}
