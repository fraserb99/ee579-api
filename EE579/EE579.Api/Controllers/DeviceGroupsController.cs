using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Models;
using EE579.Core.Slices.DeviceGroups.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EE579.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class DeviceGroupsController : ControllerBase
    {
        /// <remarks>
        /// Gets a list of device groups belonging to the current tenant
        /// </remarks>
        [HttpGet]
        public ApiList<DeviceGroupDto> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Creates a new device group
        /// </remarks>
        [HttpPost]
        public DeviceGroupDto Create([FromBody] DeviceGroupInput input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Updates a device group
        /// </remarks>
        [Route("{groupId}")]
        [HttpPut]
        public DeviceGroupDto Update(string deviceId, [FromBody] DeviceGroupInput input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Add a device to a group
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        [Route("{groupId}/add-device/{deviceId}")]
        public DeviceGroupDto AddDevice(string groupId, string deviceId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Remove a device from a group
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{groupId}/devices/{deviceId}")]
        public void RemoveDevice(Guid groupId, Guid deviceId)
        {

        }

        /// <remarks>
        /// Deletes a device group
        /// </remarks>
        [Route("{deviceId}")]
        [HttpDelete]
        public void Delete(string deviceId)
        {

        }
    }
}
