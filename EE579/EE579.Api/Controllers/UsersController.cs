﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Models;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Users;
using EE579.Core.Slices.Users.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;

        public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _settings = appSettings.Value;
        }

        /// <remarks>
        /// Gets all users that have access to the current tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();

            return Ok(new ApiList<UserDto>(users));
        }

        /// <remarks>
        /// Allows a user to create an account. This will also create an initial tenant for them as well
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserInput input)
        {
            await _userService.Create(input);

            return Ok();
        }

        /// <remarks>
        /// Allows a user to update their details - e.g. email, name
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> Update(Guid userId, [FromBody] UserInput input)
        {
            var user = await _userService.Update(userId, input);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(new ApiList<UserDto>(userDto));
        }

        /// <remarks>
        /// The verification email will include a link to this endpoint, with a token verifying that the user is the owner of the email address
        /// </remarks>
        [AllowAnonymous]
        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                await _userService.ConfirmEmail(userId, token);
                return Redirect(_settings.AdminUrl + "/signin");
            }
            catch (Exception e)
            {
                return BadRequest("There was a problem confirming your email, please try again");
            }
        }
    }
}
