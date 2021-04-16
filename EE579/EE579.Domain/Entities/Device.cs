﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class Device : EntityWithTenant<string>
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public DateTime LastDisconnectionTime { get; set; }

        public virtual List<RuleInput> Inputs { get; set; }
        public virtual List<RuleOutput> Outputs { get; set; }
        public virtual ICollection<DeviceGroup> DeviceGroups { get; set; }
    }
}
