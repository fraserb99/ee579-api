using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Core.Slices.Rules.Processing.Models;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EE579.Core.Slices.Rules.Processing
{
    public class ButtonPushedProcessor : RuleProcessor<ButtonPushedInput, ButtonPushedBody>
    {
        public ButtonPushedProcessor(ProcessEventArgs args, IConfiguration configuration) 
            : base(args, configuration, null) { }

        protected override async Task<IEnumerable<Rule>> GetTriggeredCore(IQueryable<ButtonPushedInput> rules)
        {
            var triggered = await rules
                .Where(x => x.Peripheral == _args.GetPeripheral<ButtonPeripheral>() && 
                            x.Duration <= MessageBody.Duration)
                .Select(x => x.Rule)
                .ToListAsync();

            return triggered;
        }
    }
}
