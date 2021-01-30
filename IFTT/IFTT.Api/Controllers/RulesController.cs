using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFTT.Core.Slices.Rules.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IFTT.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        /// <remarks>
        /// Gets a list of rules set up in the current client
        /// </remarks>
        [ProducesResponseType(typeof(List<RuleDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public List<RuleDto> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Creates a rule
        /// </remarks>
        [ProducesResponseType(typeof(RuleDto), StatusCodes.Status200OK)]
        [HttpPost]
        public List<RuleDto> Create()
        {
            throw new NotImplementedException();
        }
    }
}
