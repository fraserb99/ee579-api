using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Processing
{
    public static class IotHubEventExtensions
    {
        public static InputType GetInputType(this ProcessEventArgs args)
        {
            args.Data.Properties.TryGetValue(nameof(InputType), out var inputTypeString);

            Enum.TryParse<InputType>(inputTypeString?.ToString(), true, out var inputType);

            return inputType;
        }

        public static string GetDeviceId(this ProcessEventArgs args)
        {
            args.Data.SystemProperties.TryGetValue("iot=hub-device-id", out var idValue);

            return idValue?.ToString();
        }
    }
}
