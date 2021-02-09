using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleOutputDto
    {
        [Required]
        public DeviceDto Device { get; set; }
        public OutputType Type { get; set; }
    }
}
