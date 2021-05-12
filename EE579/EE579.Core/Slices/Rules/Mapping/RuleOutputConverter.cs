using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Slices.Rules.Models;
using EE579.Core.Slices.Rules.Models.Outputs;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using EE579.Domain.Entities.Output;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Mapping
{
    public class RuleOutputConverter : ITypeConverter<RuleOutputDto, RuleOutput>
    {
        private readonly DatabaseContext _context;

        public RuleOutputConverter(DatabaseContext context)
        {
            _context = context;
        }

        public RuleOutput Convert(RuleOutputDto source, RuleOutput destination, ResolutionContext context)
        {
            var existing = _context.RuleOutputs.Find(source.Id);
            if (existing != null)
                return context.Mapper.Map(source, existing);

            var mapper = context.Mapper;
            return source.Type switch
                {
                    OutputType.BuzzerBeep => mapper.Map<BuzzerBeepOutput>(source),
                    OutputType.BuzzerOff => mapper.Map<BuzzerOffOutput>(source),
                    OutputType.LedBlink => mapper.Map<LedBlinkOutput>(source),
                    OutputType.BuzzerOn => mapper.Map<BuzzerOnOutput>(source),
                    OutputType.LedBreathe => mapper.Map<LedBreatheOutput>(source),
                    OutputType.LedCycle => mapper.Map<LedCycleOutput>(source),
                    OutputType.LedFade => mapper.Map<LedFadeOutput>(source),
                    OutputType.LedOutput => mapper.Map<LedOutput>(source),
                    OutputType.Webhook => mapper.Map<WebhookOutput>(source),
                    _ => null,
                };
        }
    }

    public class RuleOutputDtoConverter : ITypeConverter<RuleOutput, RuleOutputDto>
    {
        private readonly DatabaseContext _context;

        public RuleOutputDtoConverter(DatabaseContext context)
        {
            _context = context;
        }

        public RuleOutputDto Convert(RuleOutput source, RuleOutputDto destination, ResolutionContext context)
        {
            var mapper = context.Mapper;
            return source.Type switch
            {
                OutputType.BuzzerBeep => mapper.Map<BuzzerBeepOutputDto>(source),
                OutputType.BuzzerOff => mapper.Map<BuzzerOffOutputDto>(source),
                OutputType.LedBlink => mapper.Map<LedPeriodOutputDto>(source),
                OutputType.BuzzerOn => mapper.Map<BuzzerOnOutputDto>(source),
                OutputType.LedBreathe => mapper.Map<LedPeriodOutputDto>(source),
                OutputType.LedCycle => mapper.Map<LedCycleOutputDto>(source),
                OutputType.LedFade => mapper.Map<LedPeriodOutputDto>(source),
                OutputType.LedOutput => mapper.Map<LedOutputDto>(source),
                OutputType.Webhook => mapper.Map<WebhookOutputDto>(source),
                _ => null,
            };
        }
    }
}
