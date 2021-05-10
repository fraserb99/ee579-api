using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EE579.Core.Slices.Rules.Processing
{
    public class WebhookProcessor : RuleProcessor<WebhookInput, object>
    {
        private readonly string _code;

        public WebhookProcessor(IConfiguration configuration, string code)
            : base(new ProcessEventArgs(), configuration)
        {
            _code = code;
        }

        protected override object GetMessageBody()
        {
            return null;
        }

        protected override async Task<IEnumerable<Rule>> GetTriggeredCore(IQueryable<WebhookInput> rules)
        {
            var triggered = await rules
                .Where(x => x.Code == _code)
                .Select(x => x.Rule)
                .ToListAsync();

            return triggered;
        }
    }
}
