using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Api.Examples;
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
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        /// <remarks>
        /// Allows a user to create an account. This will also create an initial tenant for them as well
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public SessionDto Create([FromBody] CreateUserInput input)
        {
            var sessionDto = _userService.Create(input);

            return sessionDto;
        }

        /// <remarks>
        /// Allows a user to update their details - e.g. email, name
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{userId}")]
        public UserDto Update(Guid userId, [FromBody] UserInput input)
        {
            var user = _userService.Update(userId, input);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
