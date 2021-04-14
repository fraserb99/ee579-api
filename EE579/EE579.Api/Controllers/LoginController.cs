using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EE579.Api.Examples;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Auth;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppSettings _settings;
        private readonly IConfiguration _config;

        public LoginController(IAuthService authService, IOptions<AppSettings> settings, IConfiguration config)
        {
            _authService = authService;
            _settings = settings.Value;
            _config = config;
        }
        /// <remarks>
        /// Allows a user to login to their account
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public async Task<SessionDto> Login([FromBody] LoginInput input)
        {
            return await _authService.Login(input);
        }

        /// <remarks>
        /// Allows a user to login to their account via a provider like Google or Microsoft
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("/login/external")]
        [AllowAnonymous]
        public async Task<SessionDto> ExternalLogin([FromBody] ExternalLoginInput input)
        {
            return await _authService.ExternalLogin(input.Token);
        }

        /// <remarks>
        /// Used to refresh a user's session
        /// </remarks>
        [HttpPost]
        [Route("/refresh-token")]
        public async Task<SessionDto> RefreshSession([FromBody] RefreshTokenInput input)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/environment")]
        public IActionResult GetEnvironmentVariables()
        {
            var appsettings = new AppSettings();
            _config.GetSection("AppSettings").Bind(appsettings);

            return Ok(appsettings);
        }
    }
}
