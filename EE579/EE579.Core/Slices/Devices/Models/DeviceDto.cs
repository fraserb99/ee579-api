using System;
using System.ComponentModel.DataAnnotations;
using EE579.Domain.Entities;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceDto : Entity<string>

    {
        public string Name { get; set; }

        /// <summary>
        /// Whether or not the device has been claimed by a tenant
        /// </summary>
        /// <example>Claimed</example>
        public DeviceState DeviceState { get; set; }

        public ConnectionState ConnectionState { get; set; }
        public string WebUrl { get; set; }
    }
}
