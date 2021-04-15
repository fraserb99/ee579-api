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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EE579.Core.Slices.Rules.Processing
{
    public class SwitchFlippedProcessor : RuleProcessor<SwitchInput, SwitchFlippedBody>
    {
        public SwitchFlippedProcessor(ProcessEventArgs args, IConfiguration configuration) 
            : base(args, configuration) { }

        protected override async Task<IEnumerable<Rule>> GetTriggeredCore(IQueryable<SwitchInput> rules)
        {
            var triggered = await rules
                .Where(x => x.Peripheral == _args.GetPeripheral<SwitchPeripheral>() &&
                            x.Value == MessageBody.Value)
                .Select(x => x.Rule)
                .ToListAsync();

            return triggered;
        }
    }
}
