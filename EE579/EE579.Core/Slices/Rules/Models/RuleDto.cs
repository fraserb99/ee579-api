using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// A list of devices which will trigger the rule if the correct inputs are detected from them
        /// </summary>
        public List<RuleInputDto> InputDevices { get; set; }
        /// <summary>
        /// A list of devices which will perform the output actions when the rule is triggered
        /// </summary>
        public List<DeviceDto> OutputDevices { get; set; }
    }
}
