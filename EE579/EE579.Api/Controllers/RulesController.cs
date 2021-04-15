using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Rules;
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
        private readonly IRuleService _ruleService;
        private readonly IMapper _mapper;

        public RulesController(IRuleService ruleService, IMapper mapper)
        {
            _ruleService = ruleService;
            _mapper = mapper;
        }

        /// <remarks>
        /// Gets a list of rules set up in the current client
        /// </remarks>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RuleExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [RequiresTenant]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rules = await _ruleService.GetAll();

            return Ok(new ApiList<RuleDto>(_mapper.Map<List<RuleDto>>(rules)));
        }

        /// <remarks>
        /// Creates a rule
        /// </remarks>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RuleExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RuleDtoInput input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rule = await _ruleService.Create(input);

            return Ok(new ApiList<RuleDto>(_mapper.Map<RuleDto>(rule)));
        }

        /// <remarks>
        /// Updates a rule
        /// </remarks>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RuleExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [HttpPut]
        [Route("{ruleId}")]
        public async Task<IActionResult> Update(Guid ruleId, [FromBody] RuleDtoInput input)
        {
            var rule = _ruleService.Update(ruleId, input);

            return Ok(new ApiList<RuleDto>(_mapper.Map<RuleDto>(rule)));
        }

        /// <remarks>
        /// Deletes a rule
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [RequiresTenant]
        [Route("{ruleId}")]
        public async Task Delete(string ruleId)
        {
            throw new NotImplementedException();
        }
    }
}
