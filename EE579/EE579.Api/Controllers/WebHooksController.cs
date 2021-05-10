using AutoMapper;
using EE579.Api.Examples;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.WebHooks;
using EE579.Core.Slices.WebHooks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Slices.Rules.Processing;
using Microsoft.Extensions.Configuration;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class WebHooksController : ControllerBase
    {


        private readonly IMapper _mapper;
        private readonly AppSettings _settings;
        private readonly IWebHookService _webHookService;
        private readonly IConfiguration _config;

        public WebHooksController(IMapper mapper, IOptions<AppSettings> appSettings, IWebHookService webHookService, IConfiguration config)
        {
            _mapper = mapper;
            _settings = appSettings.Value;
            _webHookService = webHookService;
            _config = config;
        }

        /// <remarks>
        /// Allows a user to update their details - e.g. email, name
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("mock-input/{id}")]
        public async Task<IActionResult> MockInput(Guid id, [FromBody] WebHookMockInput input)
        {
            await _webHookService.MockInput(id, input);

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("trigger/{code}")]
        public async Task<IActionResult> Trigger(string code)
        {
            var processor = new WebhookProcessor(_config, code);

            await processor.ProcessInput();

            return Ok();
        }
    }
}
