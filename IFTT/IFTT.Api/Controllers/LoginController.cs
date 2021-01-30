using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFTT.Core.Slices.Auth.Models;
using IFTT.Core.Slices.Devices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IFTT.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        /// <remarks>
        /// Allows a user to login to their account
        /// </remarks>
        [HttpPost]
        [Route("/login")]
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
