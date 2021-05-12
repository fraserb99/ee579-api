using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE579.Core.Slices.DeviceGroups.Models;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;
using EE579.Domain.Models;
using Newtonsoft.Json;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleOutputDto : Entity<Guid>
    {
        public DeviceGroupDto DeviceGroup { get; set; }
        public DeviceDto Device { get; set; }
        [JsonProperty("type")]
        public OutputType OutputType { get; set; }
    }
}
