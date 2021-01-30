using System;
using System.Collections.Generic;
using EE579.Core.Models;
using EE579.Core.Slices.Devices.Models;
using Swashbuckle.AspNetCore.Filters;

namespace EE579.Api.Examples
{
    public class DeviceDtoExample : IExamplesProvider<DeviceDto>
    {
        public DeviceDto GetExamples()
        {
            return new DeviceDto
            {
                Id = "00:0a:95:9d:68:16",
                DeviceState = DeviceState.Claimed,
                Name = "Fraser's Msp430",
            };
        }
    }
    public class DeviceListExamples : IExamplesProvider<ApiList<DeviceDto>>
    {
        public ApiList<DeviceDto> GetExamples()
        {
            return new ApiList<DeviceDto>
            {
                Items = new List<DeviceDto>
                {
                    new DeviceDto
                    {
                        Id = "00:0a:95:9d:68:16",
                        DeviceState = DeviceState.Claimed,
                        Name = "Fraser's Msp430",
                    },
                    new DeviceDto
                    {
                        Id = "00:14:22:01:23:45",
                        DeviceState = DeviceState.Claimed,
                        Name = "Ross' Msp430"
                    }
                }
            };
        }
    }

    public class DeviceRegistrationExample : IExamplesProvider<DeviceRegistrationDto>
    {
        public DeviceRegistrationDto GetExamples()
        {
            return new DeviceRegistrationDto
            {
                MqttPassword = "SharedAccessSignature sr=EE579T-Iot-Hub.azure-devices.net%2Fdevices%2F00%3A0a%3A95%3A9d%3A68%3A16&sig=P5ZwP6DSCBjclOl2IFEb6AkAcczdT7w1Nn8MoGBtZn0%3D&se=36324632293"
            };
        }
    }

    public class DeviceInputExample : IExamplesProvider<DeviceInput>
    {
        public DeviceInput GetExamples()
        {
            return new DeviceInput
            {
                Name = "Fraser's Msp430"
            };
        }
    }
}
