using AutoMapper;
using EE579.Core.Slices.Devices.Mapping;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.DeviceGroups.Models;

namespace EE579.Core.Slices.DeviceGroups.Mapping
{
    public class DeviceGroupProfile : Profile
    {
        public DeviceGroupProfile()
        {
            CreateMap<DeviceGroupInput, DeviceGroup>();
            CreateMap<Entity<string>, Device>()
                .ConvertUsing<AutocompleteToEntityConverter<string, Device>>();

            CreateMap<DeviceGroup, DeviceGroupDto>()
                .ForMember(x => x.TotalDevices, opts => opts.MapFrom(y => y.Devices.Count));
        }
    }
}
