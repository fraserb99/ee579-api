using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFTT.Core.Slices.Auth.Models;
using IFTT.Core.Slices.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IFTT.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        /// <remarks>
        /// Allows a user to create an account
        /// </remarks>
        [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
        [HttpPost]
        [Route("create")]
        public SessionDto Create([FromBody] CreateUserInput input)
        {
            throw new NotImplementedException();
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
