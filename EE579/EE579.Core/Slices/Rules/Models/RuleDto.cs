using System;
using System.Collections.Generic;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DeviceDto> InputDevices { get; set; }
        public List<DeviceDto> OutputDevices { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Output> Output { get; set; }
    }
}
