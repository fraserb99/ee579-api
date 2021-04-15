using System;
using System.Collections.Generic;
using System.Linq;
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

            CreateMap<RuleOutputDto, RuleOutput>()
                .ConvertUsing<RuleOutputConverter>();
            CreateMap<BuzzerOnOutputDto, BuzzerOnOutput>();

            CreateMap<RuleInput, RuleInputDto>()
                .ConvertUsing<RuleInputDtoConverter>();
            CreateMap<ButtonPushedInput, ButtonPushedInputDto>();
            CreateMap<SwitchInput, AnalogueValueInputDto>();
            CreateMap<PotentiometerInput, AnalogueValueInputDto>();
            CreateMap<TemperatureInput, AnalogueValueInputDto>();

            CreateMap<RuleOutput, RuleOutputDto>()
                .ConvertUsing<RuleOutputDtoConverter>();
            CreateMap<BuzzerOnOutput, BuzzerOnOutputDto>();
        }
    }
}
