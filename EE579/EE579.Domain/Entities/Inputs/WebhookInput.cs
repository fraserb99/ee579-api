using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Domain.Entities.Inputs
{
    public class WebhookInput : RuleInput
    {
        public WebhookInput() 
            : base(InputType.Webhook) { }

        public string Code { get; set; }
    }
}
