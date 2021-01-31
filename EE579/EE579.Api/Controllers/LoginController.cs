using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Devices.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        /// <remarks>
        /// Allows a user to login to their account
        /// </remarks>
        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public SessionDto Login([FromBody] LoginInput input)
        {
            throw new NotImplementedException();
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
