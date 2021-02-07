using System;
using System.Collections.Generic;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleInputDto
    {
        public DeviceDto Device { get; set; }
        public InputType Type { get; set; }
        public object Params { get; set; }
    }
}
