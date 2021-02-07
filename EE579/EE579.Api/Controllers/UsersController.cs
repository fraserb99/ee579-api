using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Users;
using EE579.Core.Slices.Users.Models;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <remarks>
        /// Allows a user to create an account
        /// </remarks>
        [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public SessionDto Create([FromBody] CreateUserInput input)
        {
            var sessionDto = _userService.Create(input);

            return sessionDto;
        }

        /// <remarks>
        /// Allows a user to update their details - e.g. email
        /// </remarks>
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{userId}")]
        public UserDto Update(Guid userId, [FromBody] UserInput input)
        {
            throw new NotImplementedException();
        }
    }
}
