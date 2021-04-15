using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Rules.Models;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Rules
{
    public interface IRuleService : ICrudAppService<Rule, RuleDtoInput>
    {
    }
}
