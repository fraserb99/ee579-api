using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Rules.Models.Outputs
{
    public class WebhookOutputDto : RuleOutputDto
    {
        public string Url { get; set; }
        public bool ForwardMessage { get; set; }
    }
}
