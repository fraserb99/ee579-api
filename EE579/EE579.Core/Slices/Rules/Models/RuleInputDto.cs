using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleInputDto
    {
        [Required]
        public DeviceDto Device { get; set; }
        /// <summary>
        /// The type of input to detect
        /// </summary>
        public InputType Type { get; set; }
    }
}
