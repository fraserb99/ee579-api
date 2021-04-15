using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Inputs
{
    public class PotentiometerInput : RuleInput
    {
        public PotentiometerInput()
            : base(InputType.Potentiometer) { }
        public int GreaterThan { get; set; }
        public int LessThan { get; set; }
        public int LastValue { get; set; }
    }
}
