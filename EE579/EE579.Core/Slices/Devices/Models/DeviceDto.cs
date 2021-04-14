using System;
using System.ComponentModel.DataAnnotations;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceDto
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Whether or not the device has been claimed by a tenant
        /// </summary>
        /// <example>Claimed</example>
        public DeviceState DeviceState { get; set; }
        public ConnectionState ConnectionState { get; set; }
    }
}
