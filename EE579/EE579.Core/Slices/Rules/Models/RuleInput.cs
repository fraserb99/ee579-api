using System;
using System.Collections.Generic;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleInput
    {
        public string Name { get; set; }
        public List<Guid> InputDeviceIds { get; set; }
        public List<Guid> OutputDevicesIds { get; set; }
        public List<Guid> InputGroupIds { get; set; }
        public List<Guid> OutputGroupIds { get; set; }
        public List<List<Input>> Inputs { get; set; }
        public List<List<Output>> Output { get; set; }
    }
}
