using AutoMapper;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Devices.Mapping
{
    public class WebHookUrlAfterMap : IMappingAction<Device, DeviceDto>
    {
        private readonly AppSettings _appSettings;
        public WebHookUrlAfterMap(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }
        public void Process(Device source, DeviceDto destination, ResolutionContext context)
        {
            destination.WebUrl = _appSettings.ApiUrl + "/mock-input/" + source.WebId.ToString();
        }
    }
}
