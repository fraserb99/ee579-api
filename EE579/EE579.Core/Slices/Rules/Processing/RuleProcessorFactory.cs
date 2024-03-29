﻿using System;
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
        public static IRuleProcessor CreateRuleProcessor(ProcessEventArgs args, IConfiguration config)
        {
            try
            {
                var type = args.GetInputType();

                switch (type)
                {
                    case InputType.ButtonPushed:
                        return new ButtonPushedProcessor(args, config);
                    case InputType.Switch:
                        return new SwitchFlippedProcessor(args, config);
                    case InputType.Potentiometer:
                        return new PotentiometerProcessor(args, config);
                    case InputType.Temperature:
                        return new TemperatureProcessor(args, config);
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
