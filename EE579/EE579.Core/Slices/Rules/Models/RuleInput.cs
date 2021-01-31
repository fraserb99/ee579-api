using System;
using System.Collections.Generic;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleInput
    {
        public string Name { get; set; }
        /// <summary>
        /// A list of device id's to be used as input devices
        /// </summary>
        public List<Guid> InputDeviceIds { get; set; }
        /// <summary>
        /// A list of device id's to be used as output devices
        /// </summary>
        public List<Guid> OutputDevicesIds { get; set; }
        /// <summary>
        /// A list of device groups to be used as input devices
        /// </summary>
        public List<Guid> InputGroupIds { get; set; }
        /// <summary>
        /// A list of device groups to be used as output devices
        /// </summary>
        public List<Guid> OutputGroupIds { get; set; }
        /// <summary>
        /// A list of inputs to trigger the rule
        /// </summary>
        public List<Input> Inputs { get; set; }
        /// <summary>
        /// A list of outputs to trigger the rule
        /// </summary>
        public List<Output> Output { get; set; }
    }
}
