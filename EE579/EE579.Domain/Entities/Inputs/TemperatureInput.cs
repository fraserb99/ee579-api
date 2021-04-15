using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Inputs
{
    public class TemperatureInput : RuleInput
    {
        public TemperatureInput()
            : base(InputType.Temperature) { }
        public int LessThan { get; set; }
        public int GreaterThan { get; set; }
        public int LastValue { get; set; }
    }
}
