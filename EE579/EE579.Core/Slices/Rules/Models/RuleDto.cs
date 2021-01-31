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
        public List<DeviceDto> InputDevices { get; set; }
        /// <summary>
        /// A list of devices which will perform the output actions when the rule is triggered
        /// </summary>
        public List<DeviceDto> OutputDevices { get; set; }
        /// <summary>
        /// A list of inputs which will trigger the rule
        /// </summary>
        public List<Input> Inputs { get; set; }
        /// <summary>
        /// A list of output actions to be performed when the rule is triggered
        /// </summary>
        public List<Output> Output { get; set; }
    }
}
