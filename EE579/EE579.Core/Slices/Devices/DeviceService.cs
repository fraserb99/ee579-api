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
using EE579.Core.Slices.IotHub.Impl;
using EE579.Core.Slices.IotHub.Messages;
using EE579.Core.Slices.Tenants;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Extensions;
using EE579.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Security;
using Microsoft.EntityFrameworkCore;
using Device = EE579.Domain.Entities.Device;

namespace EE579.Core.Slices.Devices
{
    public class DeviceService : CrudAppServiceWithIdType<Device, DeviceInput, string>, IDeviceService
    {
        private readonly RegistryManager _registry;

        private const string IotHubConnectionString =
            "HostName=IFTTT-Iot-Hub.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=SpLPXBmM134nhCPQ1tFDsY30jPlPtc3Y6TRRFUOp8KM=";

        private const string TargetFormat =
            "IFTTT-Iot-Hub.azure-devices.net/devices/{0}";

        private const string TopicFormat =
            "devices/{0}/messages/devicebound/#";


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
            }
            else
            {
                device.IpAddress = _httpContext.GetIpAddress().ToString();
                await Repository.SaveChangesAsync();
            }

            hubDevice = await _registry.GetDeviceAsync(deviceId) ??
                        await _registry.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));

            var sasBuilder = new SharedAccessSignatureBuilder
            {
                Key = hubDevice.Authentication.SymmetricKey.PrimaryKey,
                Target = string.Format(TargetFormat, hubDevice.Id),
                TimeToLive = TimeSpan.FromDays(999999)
            };

            return new DeviceRegistrationDto
            {
                Password = sasBuilder.ToSignature(),
                Topic = string.Format(TopicFormat, hubDevice.Id)
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
            var device = Repository.Devices
                .IgnoreQueryFilters()
                .FirstOrDefault(x => x.Id == deviceId);
            if (device == null) 
                throw new HttpStatusCodeException(404);

            var message = new OutputMessage(OutputType.LedBlink, LedPeripheral.Led1)
            {
                Body = new
                {
                    Period = 10,
                    Colour = LedColour.White
                }
            };

            await IotMessagingService.SendMessage(deviceId, message);
           
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
            device.WebId = Guid.NewGuid();
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
