using AutoMapper;
using EE579.Core.Slices.Devices.Mapping;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.DeviceGroups.Mapping
{
    public class DeviceGroupProfile : Profile
    {
        public DeviceGroupProfile()
        {
            CreateMap<string, Device>().ConvertUsing<MACStringToDeviceConverter>();
        }
    }
}
