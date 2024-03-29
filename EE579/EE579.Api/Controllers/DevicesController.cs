﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Devices;
using EE579.Core.Slices.Devices.Models;
using EE579.Core.Slices.IotHub;
using EE579.Core.Slices.IotHub.Impl;
using EE579.Domain;
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
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        public DevicesController(IDeviceService deviceService, IMapper mapper, DatabaseContext context)
        {
            _deviceService = deviceService;
            _mapper = mapper;
            _context = context;
        }

        /// <remarks>
        /// Gets a list of devices belonging to the current tenant
        /// </remarks>
        [RequiresTenant]
        [ProducesResponseType(typeof(ApiList<DeviceDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devices = await _deviceService.GetAll();

            return Ok(new ApiList<DeviceDto>(_mapper.Map<List<DeviceDto>>(devices)));
        }

        /// <remarks>
        /// The first request a device should send when powered on for the first time and connected to a network.
        /// The device will be added to the system and given an access key to allow it to connect to the mqtt broker. 
        /// If a device has already been added this endpoint will still work, returning a 200 OK instead of 201 Created.
        /// This is to account for devices that have been reset or otherwise lost their mqtt access token
        /// </remarks>
        [ProducesResponseType(typeof(DeviceRegistrationDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DeviceRegistrationDto), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Create([FromBody] RegisterDeviceInput input)
        {
            return Ok(await _deviceService.Register(input.DeviceId));
        }

        /// <remarks>
        /// Gets a list of devices that have yet to be claimed by a tenant and are on the same subnet as the request has come from. This prevents users from claiming devices that don't belong to them
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<DeviceDto>), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("unclaimed")]
        public async Task<ActionResult> GetUnclaimed()
        {
            var devices = await _deviceService.GetUnclaimed();
            var deviceDtos = _mapper.Map<List<DeviceDto>>(devices);

            return Ok(new ApiList<DeviceDto>(deviceDtos));
        }

        /// <remarks>
        /// Used to update a device's details. This is also used to claim a device. When a device is first updated, it's tenantId is set to the tenant in the header
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<DeviceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [RequiresTenant]
        [Route("{deviceId}")]
        public async Task<IActionResult> Update([FromBody] DeviceInput input, string deviceId)
        {
            var device = await _deviceService.Update(deviceId, input);

            return Ok(new ApiList<DeviceDto>(_mapper.Map<DeviceDto>(device)));
        }

        /// <remarks>
        /// This is also used claim a device, setting it's tenantId is set to the tenant in the header and allowing the user to choose a name
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<DeviceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut]
        [RequiresTenant]
        [Route("{deviceId}/claim")]
        public async Task<IActionResult> Claim([FromBody] DeviceInput input, string deviceId)
        {
            var device = await _deviceService.Claim(deviceId, input);

            return Ok(new ApiList<DeviceDto>(_mapper.Map<DeviceDto>(device)));
        }

        /// <remarks>
        /// Used to move a device to a new tenant. This will also remove the device from any rules on the previous tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [RequiresTenant]
        [HttpPut]
        [Route("{deviceId}/move-tenant/{newTenantId}")]
        public async Task<DeviceDto> Update(Guid deviceId, Guid newTenantId)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Removes the device and all of it's rule integrations from the current tenant. This will allow it to be claimed by another tenant
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [RequiresTenant]
        [HttpDelete]
        [Route("{deviceId}/unclaim")]
        public async Task<IActionResult> Delete(string deviceId)
        {
            await _deviceService.Unclaim(deviceId);

            return NoContent();
        }

        /// <remarks>
        /// Blinks an LED on the microcontroller to identify it
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        [Route("{deviceId}/identify")]
        public async Task Identify(string deviceId)
        {
            await _deviceService.Identify(deviceId);
        }

        [HttpPost]
        [Route("dk")]
        public async Task<IActionResult> IotTest()
        {
            await IotMessagingService.SendMessage("00:0a:95:9d:68:16", new Dictionary<string, string>(), "dk");
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("messages")]
        public async Task<IActionResult> GetDeviceMessages()
        {
            var messages = _context.DeviceMessages.OrderByDescending(x => x.TimeStamp).Take(100);
            return Ok(_mapper.Map<List<DeviceMessageDto>>(messages));
        }
    }
}
