using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Rules.Models.Inputs
{
    public class WebhookInputDto : RuleInputDto
    {
        public string Url { get; set; }
    }
}
