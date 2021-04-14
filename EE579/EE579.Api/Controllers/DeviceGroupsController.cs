using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Api.Examples;
using EE579.Api.Infrastructure.Attributes;
using EE579.Core.Models;
using EE579.Core.Slices.DeviceGroups;
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
        private readonly IDeviceGroupService _deviceGroupService;
        private readonly IMapper _mapper;
        public DeviceGroupsController(IDeviceGroupService deviceGroupService, IMapper mapper)
        {
            _deviceGroupService = deviceGroupService;
            _mapper = mapper;
        }

        /// <remarks>
        /// Gets a list of device groups belonging to the current tenant
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<DeviceGroupDto>), StatusCodes.Status200OK)]
        [RequiresTenant]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _deviceGroupService.GetAll();

            return Ok(new ApiList<DeviceGroupDto>(_mapper.Map<List<DeviceGroupDto>>(groups)));
        }

        /// <remarks>
        /// Creates a new device group
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<DeviceGroupDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeviceGroupInput input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var group = await _deviceGroupService.Create(input);

            return Ok(new ApiList<DeviceGroupDto>(_mapper.Map<DeviceGroupDto>(group)));
        }

        /// <remarks>
        /// Updates a device group
        /// </remarks>
        [ProducesResponseType(typeof(ApiList<DeviceGroupDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormErrorResponse), StatusCodes.Status400BadRequest)]
        [RequiresTenant]
        [Route("{groupId}")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid groupId, [FromBody] DeviceGroupInput input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var group = await _deviceGroupService.Update(groupId, input);

            return Ok(new ApiList<DeviceGroupDto>(_mapper.Map<DeviceGroupDto>(group)));
        }

       

        /// <remarks>
        /// Deletes a device group
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [RequiresTenant]
        [Route("{groupId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid groupId)
        {
            await _deviceGroupService.Delete(groupId);

            return NoContent();
        }
    }
}
