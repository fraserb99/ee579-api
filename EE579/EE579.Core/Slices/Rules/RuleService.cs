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
    }
}
