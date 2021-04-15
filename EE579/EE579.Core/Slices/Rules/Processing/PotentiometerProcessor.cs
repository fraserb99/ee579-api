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
    public class PotentiometerProcessor : RuleProcessor<PotentiometerInput, AnalogueValueBody>
    {
        public PotentiometerProcessor(ProcessEventArgs args, IConfiguration configuration)
            : base(args, configuration) { }

        protected override async Task<IEnumerable<Rule>> GetTriggeredCore(IQueryable<PotentiometerInput> rules)
        {
            var triggered = await rules
                .Where(x => x.GreaterThan < MessageBody.Value && x.LessThan > MessageBody.Value &&
                            x.GreaterThan >= x.LastValue && x.LessThan <= x.LastValue)
                .Select(x => x.Rule)
                .ToListAsync();

            foreach (var input in rules)
            {
                input.LastValue = MessageBody.Value;
            }
            await _context.SaveChangesAsync();

            return triggered;
        }
    }
}
