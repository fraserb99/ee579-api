using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Slices.DeviceGroups.Models;
using EE579.Core.Slices.Devices.Mapping;
using EE579.Core.Slices.Devices.Models;
using EE579.Core.Slices.Rules.Models;
using EE579.Core.Slices.Rules.Models.Inputs;
using EE579.Core.Slices.Rules.Models.Outputs;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using EE579.Domain.Entities.Output;

namespace EE579.Core.Slices.Rules.Mapping
{
    public class RuleProfile : Profile
    {
        public RuleProfile()
        {
            CreateMap<Rule, RuleDto>();
            CreateMap<RuleInput, RuleInputDto>();
            CreateMap<RuleOutput, RuleOutputDto>();

            CreateMap<RuleDtoInput, Rule>();
            CreateMap<DeviceDto, Device>()
                .ConvertUsing<AutocompleteToEntityConverter<string, Device>>();
            CreateMap<DeviceGroupDto, DeviceGroup>()
                .ConvertUsing<AutocompleteToEntityConverter<Guid, DeviceGroup>>();
            
            CreateMap<RuleInputDto, RuleInput>()
                .ConvertUsing<RuleInputConverter>();
            CreateMap<ButtonPushedInputDto, ButtonPushedInput>();
            CreateMap<AnalogueValueInputDto, SwitchInput>();
            CreateMap<AnalogueValueInputDto, PotentiometerInput>();
            CreateMap<AnalogueValueInputDto, TemperatureInput>();
            CreateMap<WebhookInputDto, WebhookInput>()
                .AfterMap<MapWebhookCode>();

            CreateMap<RuleOutputDto, RuleOutput>()
                .ConvertUsing<RuleOutputConverter>();
            CreateMap<RuleOutputDto, BuzzerOnOutput>();
            CreateMap<Event, EventDto>()
                .ForMember(x => x.Name, opts => opts.MapFrom(y => y.Rule.Name));
            CreateMap<BuzzerOnOutputDto, BuzzerOnOutput>();
            CreateMap<BuzzerBeepOutputDto, BuzzerBeepOutput>();
            CreateMap<BuzzerOffOutputDto, BuzzerOffOutput>();
            CreateMap<LedCycleOutputDto, LedCycleOutput>();
            CreateMap<LedOutputDto, LedOutput>();
            CreateMap<LedPeriodOutputDto, LedBlinkOutput>();
            CreateMap<LedPeriodOutputDto, LedBreatheOutput>();
            CreateMap<LedPeriodOutputDto, LedFadeOutput>();
            CreateMap<WebhookOutputDto, WebhookOutput>();

            CreateMap<RuleInput, RuleInputDto>()
                .ConvertUsing<RuleInputDtoConverter>();
            CreateMap<ButtonPushedInput, ButtonPushedInputDto>();
            CreateMap<SwitchInput, AnalogueValueInputDto>();
            CreateMap<PotentiometerInput, AnalogueValueInputDto>();
            CreateMap<TemperatureInput, AnalogueValueInputDto>();
            CreateMap<WebhookInput, WebhookInputDto>()
                .AfterMap<MapWebhookUrl>();

            CreateMap<RuleOutput, RuleOutputDto>()
                .ConvertUsing<RuleOutputDtoConverter>();
            CreateMap<BuzzerOnOutput, BuzzerOnOutputDto>();
            CreateMap<BuzzerOffOutput, BuzzerOffOutputDto>();
            CreateMap<BuzzerBeepOutput, BuzzerBeepOutputDto>();
            CreateMap<LedCycleOutput, LedCycleOutputDto>();
            CreateMap<LedOutput, LedOutputDto>();
            CreateMap<LedBlinkOutput, LedPeriodOutputDto>();
            CreateMap<LedBreatheOutput, LedPeriodOutputDto>();
            CreateMap<LedFadeOutput, LedPeriodOutputDto>();
            CreateMap<WebhookOutput, WebhookOutputDto>();
        }
    }
}
