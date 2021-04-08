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
        [ProducesResponseType(typeof(SessionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserInput input)
        {
            var sessionDto = await _userService.Create(input);

            return Created("", sessionDto);
        }

        /// <remarks>
        /// Allows a user to update their details - e.g. email, name
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{userId}")]
        public async Task<UserDto> Update(Guid userId, [FromBody] UserInput input)
        {
            var user = await _userService.Update(userId, input);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
