using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.DeviceGroups.Models;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.DeviceGroups
{
    public interface IDeviceGroupService : ICrudAppService<DeviceGroup, DeviceGroupInput, DeviceGroupInput>
    {
    }
}
