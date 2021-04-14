using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace EE579.Core.Slices.Rules.Processing
{
    public class RuleProcessorFactory
    {
        public static RuleProcessor CreateRuleProcessor(ProcessEventArgs args, IConfiguration config)
        {
            var type = args.GetInputType();

            return new ButtonPushedProcessor(args, config);
        }
    }
}
