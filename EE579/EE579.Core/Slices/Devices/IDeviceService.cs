using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Devices
{
    public interface IDeviceService : ICrudAppServiceBase<Device, DeviceInput, string>
    {
        public Task<DeviceRegistrationDto> Register(string deviceId);
        public Task<IEnumerable<Device>> GetUnclaimed();
    }
}
