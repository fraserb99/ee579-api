using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Inputs
{
    public class PowerOnInput : RuleInput
    {
        public PowerOnInput()
            : base(InputType.Power) { }
    }
}
