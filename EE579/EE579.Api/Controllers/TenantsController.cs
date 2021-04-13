using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Tenants;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Slices.Users;
using EE579.Core.Slices.Users.Models;
using EE579.Domain.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITenantService _tenantService;

        public TenantsController(IUserService userService, ITenantService tenantService)
        {
            _userService = userService;
            _tenantService = tenantService;
        }
        /// <remarks>
        /// Gets a list of tenants the user can access
        /// </remarks>
        [ProducesResponseType(typeof(List<TenantDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ApiList<TenantDto>> Get()
        {
            var tenantDtos = await _userService.GetTenants();

            return new ApiList<TenantDto>(tenantDtos);
        }

        /// <remarks>
        /// Creates a tenant
        /// </remarks>
        [ProducesResponseType(typeof(TenantDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] TenantInput input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tenant = await _tenantService.Create(input);

            return Ok(new ApiList<TenantDto>(tenant));
        }


        /// <remarks>
        /// Updates a Tenant
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<TenantDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{tenantId}")]
        public async Task<IActionResult> Update([FromBody] TenantInput input, Guid tenantId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tenant = await _tenantService.Update(tenantId, input);

            return Ok(new ApiList<TenantDto>(tenant));
        }

        /// <remarks>
        /// Delete a tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{tenantId}")]
        public async Task Delete()
        {

        }

        /// <remarks>
        /// Invite a user to join a tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [HttpPost]
        [Route("invite")]
        public async Task<IActionResult> Invite([FromBody] InviteInput input)
        {
            var tenantId = HttpContext.GetTenantId();
            var userDto = await _tenantService.Invite(input, tenantId.Value);

            return Ok(new ApiList<UserDto>(userDto));
        }

        /// <remarks>
        /// Revoke a user's access to the current tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [RequiresTenant]
        [HttpDelete]
        [Route("users/{userId}")]
        public async Task<IActionResult> RemoveUser(Guid userId)
        {
            await _tenantService.RevokeAccess(userId);

            return NoContent();
        }
    }
}
