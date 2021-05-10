using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Slices.Rules.Models;
using EE579.Core.Slices.Rules.Models.Inputs;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Mapping
{
    public class RuleInputConverter : ITypeConverter<RuleInputDto, RuleInput>
    {
        private readonly DatabaseContext _context;

        public RuleInputConverter(DatabaseContext context)
        {
            _context = context;
        }

        public RuleInput Convert(RuleInputDto source, RuleInput destination, ResolutionContext context)
        {
            var existing = _context.RuleInputs.Find(source.Id);
            if (existing != null)
                return existing;

            var mapper = context.Mapper;
            RuleInput mapped = source.Type switch
            {
                InputType.ButtonPushed => mapper.Map<ButtonPushedInput>(source),
                InputType.Switch => mapper.Map<SwitchInput>(source),
                InputType.Potentiometer => mapper.Map<PotentiometerInput>(source),
                InputType.Temperature => mapper.Map<TemperatureInput>(source),
                InputType.Power => mapper.Map<PowerOnInput>(source),
                InputType.Webhook => mapper.Map<WebhookInput>(source),
                _ => null,
            };

            return mapped;
        }
    }

    public class RuleInputDtoConverter : ITypeConverter<RuleInput, RuleInputDto>
    {
        private readonly DatabaseContext _context;

        public RuleInputDtoConverter(DatabaseContext context)
        {
            _context = context;
        }

        public RuleInputDto Convert(RuleInput source, RuleInputDto destination, ResolutionContext context)
        {
            var mapper = context.Mapper;
            RuleInputDto mapped = source.Type switch
            {
                InputType.ButtonPushed => mapper.Map<ButtonPushedInputDto>(source),
                InputType.Switch => mapper.Map<SwitchInputDto>(source),
                InputType.Potentiometer => mapper.Map<AnalogueValueInputDto>(source),
                InputType.Temperature => mapper.Map<AnalogueValueInputDto>(source),
                InputType.Webhook => mapper.Map<WebhookInputDto>(source),
                _ => null,
            };

            return mapped;
        }
    }
}
