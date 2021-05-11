using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Rules.Models;
using EE579.Domain;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Rules
{
    public class RuleService : CrudAppService<Rule, RuleDtoInput>, IRuleService
    {
        public RuleService(DatabaseContext repository, IMapper mapper) 
            : base(repository, mapper) { }

        public async Task<List<EventDto>> GetEvents()
        {
            var ruleEvents = Repository.Events.Where(x => x.Timestamp >= DateTime.Now.AddDays(-7)).ToList();
            return Mapper.Map<List<EventDto>>(ruleEvents);
        }

        public override async Task<Rule> Update(Guid id, RuleDtoInput input)
        {
            var oldDevices = Repository.Rules.Find(input.Id).Inputs.Select(x => x.Device);
            var rule = await base.Update(id, input);
            var devices = rule.Inputs.Select(x => x.Device);
            foreach (var device in devices)
            {
                device.NotifyOfInputs();
            }
            var devicesRemoved = oldDevices.Except(devices);
            foreach (var device in devicesRemoved)
            {
                device.NotifyOfInputs();
            }
            return rule;
        }
        public override async Task<Rule> Create(RuleDtoInput input)
        {
            var rule = await base.Create(input);
            var devices = rule.Inputs.Select(x => x.Device);
            foreach (var device in devices)
            {
                device.NotifyOfInputs();
            }
            
            return rule;
        }

        public override async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            
            entity.Events.Clear();
            entity.Inputs.Clear();
            entity.Outputs.Clear();
            entity.Tenant = null;
            var devices = entity.Inputs.Select(x => x.Device);
            foreach (var device in devices)
            {
                device.NotifyOfInputs();
            }
            Repository.Remove(entity);
            await Repository.SaveChangesAsync();
        }
    }
}
