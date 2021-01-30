using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Slices.Tenants.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        /// <remarks>
        /// Gets a list of tenants the user can access
        /// </remarks>
        [ProducesResponseType(typeof(List<TenantDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public List<TenantDto> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Creates a tenant
        /// </remarks>
        [ProducesResponseType(typeof(TenantDto), StatusCodes.Status201Created)]
        [HttpPost]
        [Route("create")]
        public TenantDto Create([FromBody] TenantInput input)
        {
            throw new NotImplementedException();
        }


        /// <remarks>
        /// Updates a Tenant
        /// </remarks>
        [ProducesResponseType(typeof(TenantDto), StatusCodes.Status200OK)]
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
