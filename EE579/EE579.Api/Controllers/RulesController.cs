using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Rules.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EE579.Api.Controllers
{
    [RequiresTenant]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        /// <remarks>
        /// Gets a list of rules set up in the current client
        /// </remarks>
        [ProducesResponseType(typeof(List<RuleDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public ApiList<RuleDto> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Creates a rule
        /// </remarks>
        [ProducesResponseType(typeof(RuleDto), StatusCodes.Status200OK)]
        [HttpPost]
        public RuleDto Create([FromBody] RuleInputDto input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Updates a rule
        /// </remarks>
        [ProducesResponseType(typeof(RuleDto), StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{deviceId}")]
        public RuleDto Update(string deviceId, [FromBody] RuleInputDto input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Deletes a rule
        /// </remarks>
        [HttpDelete]
        [Route("{deviceId}")]
        public RuleDto Delete(string deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
