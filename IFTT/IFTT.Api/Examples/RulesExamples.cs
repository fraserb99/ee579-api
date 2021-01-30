using System;
using System.Collections.Generic;
using IFTT.Core.Models;
using IFTT.Core.Slices.Devices.Models;
using IFTT.Core.Slices.Rules.Models;
using Swashbuckle.AspNetCore.Filters;

namespace IFTT.Api.Examples
{
    public class RuleExample : IExamplesProvider<RuleDto>
    {
        public RuleDto GetExamples()
        {
            return new RuleDto
            {
                Id = Guid.NewGuid(),
                Name = "Rule 1",
                InputDevices = new List<DeviceDto>
                {
                    new DeviceDto
                    {
                        Id = "00:0a:95:9d:68:16",
                        DeviceState = DeviceState.Claimed,
                        Name = "Fraser's Msp430",
                    },
                },
                OutputDevices = new List<DeviceDto>
                {
                    new DeviceDto
                    {
                        Id = "00:14:22:01:23:45",
                        DeviceState = DeviceState.Claimed,
                        Name = "Ross' Msp430"
                    },
                    new DeviceDto
                    {
                        Id = "00:A0:C9:14:C8:29",
                        DeviceState = DeviceState.Claimed,
                        Name = "Maddie's Msp430"
                    }
                },
                Inputs = new List<Input>
                {
                    new Input
                    {
                        Type = InputType.ButtonPushed
                    }
                },
                Output = new List<Output>
                {
                    new Output
                    {
                        Type = OutputType.LED1,
                        Params = new
                        {
                            Value = true,
                            Duration = 5000
                        }
                    },
                    new Output
                    {
                        Type = OutputType.Buzzer,
                        Params = new
                        {
                            Duration = 5000
                        }
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
                        InputDevices = new List<DeviceDto>
                        {
                            new DeviceDto
                            {
                                Id = "00:0a:95:9d:68:16",
                                DeviceState = DeviceState.Claimed,
                                Name = "Fraser's Msp430",
                            },
                        },
                        OutputDevices = new List<DeviceDto>
                        {
                            new DeviceDto
                            {
                                Id = "00:14:22:01:23:45",
                                DeviceState = DeviceState.Claimed,
                                Name = "Ross' Msp430"
                            },
                            new DeviceDto
                            {
                                Id = "00:A0:C9:14:C8:29",
                                DeviceState = DeviceState.Claimed,
                                Name = "Maddie's Msp430"
                            }
                        },
                        Inputs = new List<Input>
                        {
                            new Input
                            {
                                Type = InputType.ButtonPushed
                            }
                        },
                        Output = new List<Output>
                        {
                            new Output
                            {
                                Type = OutputType.LED1,
                                Params = new
                                {
                                    Value = true,
                                    Duration = 5000
                                }
                            },
                            new Output
                            {
                                Type = OutputType.Buzzer,
                                Params = new
                                {
                                    Duration = 5000
                                }
                            }
                        }
                    },
                    new RuleDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rule 2",
                        InputDevices = new List<DeviceDto>
                        {
                            new DeviceDto
                            {
                                Id = "00:00:0A:BB:28:FC",
                                DeviceState = DeviceState.Claimed,
                                Name = "Aoife's Msp430",
                            },
                            new DeviceDto
                            {
                                Id = "00:14:22:01:23:45",
                                DeviceState = DeviceState.Claimed,
                                Name = "Ross' Msp430"
                            },
                        },
                        OutputDevices = new List<DeviceDto>
                        {
                            
                            new DeviceDto
                            {
                                Id = "00:A0:C9:14:C8:29",
                                DeviceState = DeviceState.Claimed,
                                Name = "Maddie's Msp430"
                            },
                            new DeviceDto
                            {
                                Id = "00:0a:95:9d:68:16",
                                DeviceState = DeviceState.Claimed,
                                Name = "Fraser's Msp430",
                            },
                            new DeviceDto
                            {
                                Id = "00:1B:44:11:3A:B7",
                                DeviceState = DeviceState.Claimed,
                                Name = "Amanda's Msp430",
                            },
                        },
                        Inputs = new List<Input>
                        {
                            new Input
                            {
                                Type = InputType.TemperatureChange,
                                Params = new
                                {
                                    GreaterThan = 25,
                                }
                            }
                        },
                        Output = new List<Output>
                        {
                            new Output
                            {
                                Type = OutputType.LED2,
                                Params = new
                                {
                                    Colour = "Purple"
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
