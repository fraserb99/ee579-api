using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Slices.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly IUserService _userService;

        public TenantsController(IUserService userService)
        {
            _userService = userService;
        }
        /// <remarks>
        /// Gets a list of tenants the user can access
        /// </remarks>
        [ProducesResponseType(typeof(List<TenantDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public ApiList<TenantDto> Get()
        {
            var tenantDtos = _userService.GetTenants();

            return new ApiList<TenantDto>(tenantDtos);
        }

        /// <remarks>
        /// Creates a tenant
        /// </remarks>
        [ProducesResponseType(typeof(TenantDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("create")]
        public TenantDto Create([FromBody] TenantInput input)
        {
            throw new NotImplementedException();
        }


        /// <remarks>
        /// Updates a Tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{tenantId}")]
        public TenantDto Update([FromBody] TenantInput input, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Delete a tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{tenantId}")]
        public void Delete()
        {

        }

        /// <remarks>
        /// Invite a user to join a tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("{tenantId}")]
        public void Invite([FromBody] InviteInput input)
        {

        }

        /// <remarks>
        /// Revoke a user's access to the tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{tenantId}/users/{userId}")]
        public void RemoveUser(Guid tenantId, Guid userId)
        {

        }
    }
}
