using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.DeviceGroups.Models;
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
    public class DeviceGroupsController : ControllerBase
    {
        /// <remarks>
        /// Gets a list of device groups belonging to the current tenant
        /// </remarks>
        [RequiresTenant]
        [HttpGet]
        public async Task<ApiList<DeviceGroupDto>> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Creates a new device group
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [HttpPost]
        public async Task<DeviceGroupDto> Create([FromBody] DeviceGroupInput input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Updates a device group
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [Route("{groupId}")]
        [HttpPut]
        public async Task<DeviceGroupDto> Update(string groupId, [FromBody] DeviceGroupInput input)
        {
            throw new NotImplementedException();
        }

       

        /// <remarks>
        /// Deletes a device group
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [RequiresTenant]
        [Route("{groupId}")]
        [HttpDelete]
        public async Task Delete(string groupId)
        {

        }
    }
}
