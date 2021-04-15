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
        public static InputType? GetInputType(this ProcessEventArgs args)
        {
            args.Data.Properties.TryGetValue(nameof(InputType), out var inputTypeString);

            if (Enum.TryParse<InputType>(inputTypeString?.ToString(), true, out var inputType))
                return inputType;

            return null;
        }

        public static TEnum? GetPeripheral<TEnum>(this ProcessEventArgs args) where TEnum : struct
        {
            args.Data.Properties.TryGetValue("Peripheral", out var inputTypeString);

            if (Enum.TryParse<TEnum>(inputTypeString?.ToString(), true, out var inputType))
                return inputType;

            return null;
        }

        public static string GetDeviceId(this ProcessEventArgs args)
        {
            args.Data.SystemProperties.TryGetValue("iothub-connection-device-id", out var idValue);

            return idValue?.ToString();
        }
    }
}
