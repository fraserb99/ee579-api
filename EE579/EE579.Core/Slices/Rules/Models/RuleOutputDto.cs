using System;
using System.Collections.Generic;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleOutputDto
    {
        public DeviceDto Device { get; set; }
        public OutputType Type { get; set; }
        public object Params { get; set; }
    }
}
