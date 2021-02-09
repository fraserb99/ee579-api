using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EE579.Core.Slices.Devices.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// A list of RuleInputDtos
        /// </summary>
        [Required]
        public List<dynamic> InputDevices { get; set; }

        /// <summary>
        /// A list of RuleOutputDtos
        /// </summary>
        [Required]
        public List<dynamic> OutputDevices { get; set; }
    }
}
