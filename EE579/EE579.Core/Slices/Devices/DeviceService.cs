using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Infrastructure.Extensions;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Devices.Models;
using EE579.Core.Slices.Tenants;
using EE579.Domain;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Devices;
using Microsoft.EntityFrameworkCore;
using Device = EE579.Domain.Entities.Device;

namespace EE579.Core.Slices.Devices
{
    public class DeviceService : CrudAppServiceBase<Device, DeviceInput, string>, IDeviceService
    {
        private readonly RegistryManager _registry;

        private const string IotHubConnectionString =
            "HostName=IFTTT-Iot-Hub.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=SpLPXBmM134nhCPQ1tFDsY30jPlPtc3Y6TRRFUOp8KM=";

        private const string DeviceConnectionStringFormat =
            "HostName=IFTTT-Iot-Hub.azure-devices.net;DeviceId={0};SharedAccessKey={1}";

        private readonly HttpContext _httpContext;
        private readonly ICurrentTenant _currentTenant;

        public DeviceService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, ICurrentTenant currentTenant)
            : base(context, mapper)
        {
            _registry = RegistryManager.CreateFromConnectionString(IotHubConnectionString);
            _httpContext = httpContext.HttpContext;
            _currentTenant = currentTenant;
        }
        public async Task<DeviceRegistrationDto> Register(string deviceId)
        {
            var device = GetById(deviceId);

            Microsoft.Azure.Devices.Device hubDevice;

            if (device == null)
            {
                device = new Device
                {
                    Id = deviceId,
                    IpAddress = _httpContext.GetIpAddress().ToString()
                };
                Repository.Devices.Add(device);
                await Repository.SaveChangesAsync();

                hubDevice = await _registry.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));
            }
            else
            {
                device.IpAddress = _httpContext.GetIpAddress().ToString();
                await Repository.SaveChangesAsync();

                hubDevice = await _registry.GetDeviceAsync(deviceId);

                if (hubDevice == null)
                {
                    hubDevice = await _registry.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));
                }
            }

            return new DeviceRegistrationDto
            {
                MqttPassword = string.Format(DeviceConnectionStringFormat, deviceId, hubDevice.Authentication.SymmetricKey.PrimaryKey)
            };
        }

        public async Task<IEnumerable<Device>> GetUnclaimed()
        {
            var currentIp = _httpContext.GetIpAddress().ToString();

            var devices = Repository.Devices.Where(x =>
                x.DeviceState == DeviceState.Unclaimed &&
                x.IpAddress == currentIp);

            return await devices.ToListAsync();
        }

        protected override void ValidateInput(DeviceInput input, Device entity = null)
        {
            if (entity != null && entity.DeviceState == DeviceState.Unclaimed)
            {
                entity.Tenant = _currentTenant.Get();
                entity.DeviceState = DeviceState.Claimed;
            }
        }
    }
}
