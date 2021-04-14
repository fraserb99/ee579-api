using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Infrastructure.Exceptions;
using EE579.Core.Infrastructure.Exceptions.Models;
using EE579.Core.Infrastructure.Extensions;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.Devices.Models;
using EE579.Core.Slices.IotHub;
using EE579.Core.Slices.IotHub.Models;
using EE579.Core.Slices.IotHub.Models.MsgBodies;
using EE579.Core.Slices.Tenants;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Extensions;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Devices;
using Microsoft.EntityFrameworkCore;
using Device = EE579.Domain.Entities.Device;

namespace EE579.Core.Slices.Devices
{
    public class DeviceService : CrudAppServiceWithIdType<Device, DeviceInput, string>, IDeviceService
    {
        private readonly RegistryManager _registry;

        private const string IotHubConnectionString =
            "HostName=IFTTT-Iot-Hub.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=SpLPXBmM134nhCPQ1tFDsY30jPlPtc3Y6TRRFUOp8KM=";

        private const string DeviceConnectionStringFormat =
            "HostName=IFTTT-Iot-Hub.azure-devices.net;DeviceId={0};SharedAccessKey={1}";

        private readonly HttpContext _httpContext;
        private readonly ICurrentTenant _currentTenant;
        private readonly IIotMessagingService _messagingService;

        public DeviceService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, ICurrentTenant currentTenant, IIotMessagingService msgSrv)
            : base(context, mapper)
        {
            _registry = RegistryManager.CreateFromConnectionString(IotHubConnectionString);
            _httpContext = httpContext.HttpContext;
            _currentTenant = currentTenant;
            _messagingService = msgSrv;
        }
        public async Task<DeviceRegistrationDto> Register(string deviceId)
        {
            var device = await GetById(deviceId);

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

                hubDevice = await _registry.GetDeviceAsync(deviceId) ??
                            await _registry.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));
            }

            return new DeviceRegistrationDto
            {
                MqttPassword = string.Format(DeviceConnectionStringFormat, deviceId, hubDevice.Authentication.SymmetricKey.PrimaryKey)
            };
        }

        public async Task<IEnumerable<Device>> GetUnclaimed()
        {
            var currentIp = _httpContext.GetIpAddress().ToString();

            var devices = Repository.Devices
                .IgnoreQueryFilters()
                .Where(x =>
                x.TenantId == null &&
                x.IpAddress == currentIp);

            return await devices.ToListAsync();
        }

        public async Task Identify(string deviceId)
        {
            var device = Repository.Devices.IgnoreQueryFilters().FirstOrDefault(x => x.Id == deviceId && x.Tenant == null);
            if (device == null) throw new HttpStatusCodeException(404);

            var ledBlinkPropertyBag = new OutputPropertyBag("LedBlink", "Led1");
            var msgBody = new PeriodColourBody {
                Period = 10,
                Colour = LedColourEnum.Purple
            };

            await _messagingService.SendMessage(deviceId, ledBlinkPropertyBag.GetPropertyBag(), msgBody);
           
        }

        public async Task<Device> Claim(string deviceId, DeviceInput input)
        {
            var ip = _httpContext.GetIpAddress().ToString();
            var device = await Repository.Devices
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == deviceId);

            if (ip != device.IpAddress)
                throw new FormErrorException(new FieldError("name", "You must be on the same network as the device in order to claim it"));

            device = Mapper.Map(input, device);
            device.TenantId = _httpContext.GetTenantId();
            await Repository.SaveChangesAsync();

            return device;
        }

        public async Task Unclaim(string deviceId)
        {
            var device = await Repository.Devices.FindAsync(deviceId);
            if (device == null)
                throw new HttpStatusCodeException(404);

            device.TenantId = null;
            device.Tenant = null;
            device.Name = null;
            device.DeviceGroups.Clear();
            device.Inputs.Clear();
            device.Outputs.Clear();
            await Repository.SaveChangesAsync(true);
        }
    }
}
