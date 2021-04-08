using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Rules.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

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
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RuleExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ApiList<RuleDto>> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Creates a rule
        /// </remarks>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RuleExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<RuleDto> Create([FromBody] RuleInputDto input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Updates a rule
        /// </remarks>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RuleExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{ruleId}")]
        public async Task<RuleDto> Update(string ruleId, [FromBody] RuleInputDto input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Deletes a rule
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{ruleId}")]
        public async Task Delete(string ruleId)
        {
            throw new NotImplementedException();
        }
    }
}
