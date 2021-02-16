using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Infrastructure.Extensions;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Devices;
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

        public DeviceService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
            : base(context, mapper)
        {
            _registry = RegistryManager.CreateFromConnectionString(IotHubConnectionString);
            _httpContext = httpContext.HttpContext;
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
                    IpAddress = _httpContext.GetIpAddress()
                };
                Repository.Devices.Add(device);
                await Repository.SaveChangesAsync();

                hubDevice = await _registry.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));
            }
            else
            {
                device.IpAddress = _httpContext.GetIpAddress();
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
    }
}
