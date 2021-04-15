using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EE579.Core.Slices.Rules.Mapping;

namespace EE579.Core.Slices.Rules.Models
{
    public class RuleDtoInput
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// A list of RuleInputDtos
        /// </summary>
        [Required]
        public List<RuleInputDto> Inputs { get; set; }

        /// <summary>
        /// A list of RuleOutputDtos
        /// </summary>
        [Required]
        public List<RuleOutputDto> Outputs { get; set; }
    }
}
