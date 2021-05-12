using System;
using System.Collections.Generic;
using EE579.Core.Models;
using EE579.Core.Slices.Devices.Models;
using EE579.Core.Slices.Rules.Models;
using EE579.Core.Slices.Rules.Models.Inputs;
using EE579.Core.Slices.Rules.Models.Outputs;
using EE579.Domain.Models;
using Swashbuckle.AspNetCore.Filters;
using InputType = EE579.Domain.Models.InputType;

namespace EE579.Api.Examples
{
    public class RuleExample : IExamplesProvider<RuleDto>
    {
        public RuleDto GetExamples()
        {
            return new RuleDto
            {
                Id = Guid.NewGuid(),
                Name = "Rule 1",
                Inputs = new List<RuleInputDto>()
                {
                    new ButtonPushedInputDto()
                    {
                        Device = new DeviceDto
                        {
                            Id = "00:0a:95:9d:68:16",
                            DeviceState = DeviceState.Claimed,
                            Name = "Fraser's Msp430",
                        },
                        Type = InputType.ButtonPushed,
                        Duration = 1000
                    }
                },
                Outputs = new List<RuleOutputDto>
                {
                    new BuzzerOnOutputDto()
                    {
                        Device = new DeviceDto
                        {
                            Id = "00:14:22:01:23:45",
                            DeviceState = DeviceState.Claimed,
                            Name = "Ross' Msp430"
                        },
                        OutputType = OutputType.BuzzerOn,
                        Duration = 5000
                    },
                    new LedPeriodOutputDto()
                    {
                        Device = new DeviceDto
                        {
                            Id = "00:A0:C9:14:C8:29",
                            DeviceState = DeviceState.Claimed,
                            Name = "Maddie's Msp430"
                        },
                        Peripheral = LedPeripheral.Led3,
                        Colour = LedColour.Green,
                        OutputType = OutputType.LedBlink,
                        Period = 500
                    }
                }
            };
        }
    }

    public class RuleDtoListExamples : IExamplesProvider<ApiList<RuleDto>>
    {
        public ApiList<RuleDto> GetExamples()
        {
            return new ApiList<RuleDto>
            {
                Items = new List<RuleDto>
                {
                    new RuleDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rule 1",
                        Inputs = new List<RuleInputDto>()
                        {
                            new ButtonPushedInputDto()
                            {
                                Device = new DeviceDto
                                {
                                    Id = "00:0a:95:9d:68:16",
                                    DeviceState = DeviceState.Claimed,
                                    Name = "Fraser's Msp430",
                                },
                                Type = InputType.ButtonPushed,
                                Duration = 1000
                            }
                        },
                        Outputs = new List<RuleOutputDto>
                        {
                            new BuzzerOnOutputDto()
                            {
                                Device = new DeviceDto
                                {
                                    Id = "00:14:22:01:23:45",
                                    DeviceState = DeviceState.Claimed,
                                    Name = "Ross' Msp430"
                                },
                                OutputType = OutputType.BuzzerOn,
                                Duration = 5000
                            },
                            new LedPeriodOutputDto()
                            {
                                Device = new DeviceDto
                                {
                                    Id = "00:A0:C9:14:C8:29",
                                    DeviceState = DeviceState.Claimed,
                                    Name = "Maddie's Msp430"
                                },
                                Peripheral = LedPeripheral.Led3,
                                Colour = LedColour.Green,
                                OutputType = OutputType.LedBlink,
                                Period = 500
                            }
                        }
                    }
                }
            };
        }
    }
}
