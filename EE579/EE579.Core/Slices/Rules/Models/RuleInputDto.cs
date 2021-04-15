using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EE579.Core.Slices.DeviceGroups.Models;
using EE579.Core.Slices.Devices.Models;
using EE579.Core.Slices.Rules.Mapping;
using EE579.Domain.Entities;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleInputDto : Entity<Guid>
    {
        public DeviceGroupDto DeviceGroup { get; set; }
        public DeviceDto Device { get; set; }
        /// <summary>
        /// The type of input to detect
        /// </summary>
        public InputType Type { get; set; }
    }
}
