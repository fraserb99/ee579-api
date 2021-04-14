using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EE579.Core.Slices.Devices.Models;
using EE579.Domain.Entities;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Devices.Mapping
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>()
                .ForMember(x => x.DeviceState, 
                    opts => opts.MapFrom(y => y.TenantId != null ? DeviceState.Claimed : DeviceState.Unclaimed));

            CreateMap<DeviceInput, Device>();
        }
    }
}
