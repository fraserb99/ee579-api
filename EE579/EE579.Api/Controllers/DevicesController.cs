using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Devices.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace EE579.Api.Controllers
{
    [RequiresTenant]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class DevicesController
    {
        /// <remarks>
        /// Gets a list of devices belonging to the current tenant
        /// </remarks>
        [HttpGet]
        public ApiList<DeviceDto> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// The first request a device should send when powered on for the first time and connected to a network.
        /// The device will be added to the system and given an access key to allow it to connect to the mqtt broker. 
        /// If a device has already been added this endpoint will still work, returning a 200 OK instead of 201 Created.
        /// This is to account for devices that have been reset or otherwise lost their mqtt access token
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public DeviceRegistrationDto Create([FromBody] RegisterDeviceInput input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Gets a list of devices that have yet to be claimed by a tenant and are on the same subnet as the request has come from. This prevents users from claiming devices that don't belong to them
        /// </remarks>
        [HttpGet]
        [Route("unclaimed")]
        public ApiList<DeviceDto> GetUnclaimed()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Used to update a device's details. This is also used to claim a device. When a device is first updated, it's tenantId is set to the tenant in the header
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("{deviceId}")]
        public DeviceDto Update([FromBody] DeviceInput input, Guid deviceId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Used to move a device to a new tenant. This will also remove the device from any rules on the previous tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{deviceId}/move-tenant/{newTenantId}")]
        public DeviceDto Update(Guid deviceId, Guid newTenantId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Removes the device and all of it's rule integrations from the current tenant. This will allow it to be claimed by another tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{deviceId}/unclaim")]
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
