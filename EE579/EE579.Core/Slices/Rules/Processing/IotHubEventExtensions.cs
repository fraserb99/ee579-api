using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Core.Slices.Rules.Processing.Models;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Processing
{
    public static class IotHubEventExtensions
    {
        static private  JsonSerializerOptions jsonOpts = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

        public static InputType? GetInputType(this ProcessEventArgs args)
        {
            try
            {
                var type = args.Data.EventBody.ToObjectFromJson<InputTypeBody<InputType>>(jsonOpts).InputType;
                return type;
            }
            catch (Exception _)
            {
                var peripheral = args.Data.EventBody.ToObjectFromJson<InputTypeBody<ButtonPeripheral>>(jsonOpts).InputType;
                return InputType.ButtonPushed;
            }
        }

        public static TEnum? GetPeripheral<TEnum>(this ProcessEventArgs args) where TEnum : struct
        {
            var peripheral = args.Data.EventBody.ToObjectFromJson<PeripheralBody<TEnum>>().Peripheral;

            return peripheral;
        }

        public static string GetDeviceId(this ProcessEventArgs args)
        {
            args.Data.SystemProperties.TryGetValue("iothub-connection-device-id", out var idValue);

            return idValue?.ToString();
        }
    }
}
