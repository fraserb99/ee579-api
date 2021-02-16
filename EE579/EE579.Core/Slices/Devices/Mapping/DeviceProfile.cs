using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Devices.Mapping
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>();

            CreateMap<DeviceInput, Device>();
        }
    }
}
