using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Slices.Auth;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <remarks>
        /// Allows a user to login to their account
        /// </remarks>
        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public SessionDto Login([FromBody] LoginInput input)
        {
            return _authService.Login(input);
        }

        /// <remarks>
        /// Used to refresh a user's session
        /// </remarks>
        [HttpPost]
        [Route("/refresh-token")]
        public SessionDto RefreshSession([FromBody] RefreshTokenInput input)
        {
            throw new NotImplementedException();
        }
    }
}
