using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Api.Examples;
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
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class DevicesController
    {
        /// <remarks>
        /// Gets a list of devices belonging to the current client
        /// </remarks>
        [HttpGet]
        public ApiList<DeviceDto> Get()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// The first request a device should send when powered on for the first time and connected to a network. The device will be added to the system and given an access key to allow it to connect to the mqtt broker
        /// </remarks>
        [ProducesResponseType(typeof(DeviceRegistrationDto), StatusCodes.Status200OK)]
        [HttpPost]
        [Route("register")]
        public DeviceRegistrationDto Create([FromBody] RegisterDeviceInput input)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Gets a list of devices that have yet to be claimed by a tenant
        /// </remarks>
        [ProducesResponseType(typeof(List<DeviceDto>), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("unclaimed")]
        public List<DeviceDto> GetUnclaimed()
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Used to update a device's details
        /// </remarks>
        [ProducesResponseType(typeof(DeviceDto), StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{deviceId}")]
        public DeviceDto Update([FromBody] DeviceInput input, Guid deviceId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Used to move a device to a new tenant. This will also remove the device from any rules on the previous tenant
        /// </remarks>
        [ProducesResponseType(typeof(DeviceDto), StatusCodes.Status200OK)]
        [HttpPut]
        [Route("{deviceId}/move-tenant/{newTenantId}")]
        public DeviceDto Update(Guid deviceId, Guid newTenantId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Removes the device and all of its integrations from the current tenant. This will allow it to be claimed by another tenant
        /// </remarks>
        [ProducesResponseType(typeof(DeviceRegistrationDto), StatusCodes.Status204NoContent)]
        [HttpDelete]
        [Route("{deviceId}/unclaim")]
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
