using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public class RuleOutput : EntityWithGuid
    {
        public RuleOutput(OutputType outputType)
        {
            OutputType = outputType;
        }
        [Required]
        public virtual Device Device { get; set; }
        [Required]
        public OutputType OutputType { get; set; }
    }
}
