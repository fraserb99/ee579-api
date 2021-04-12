using AutoMapper;
using EE579.Core.Infrastructure.Services;
using EE579.Core.Slices.DeviceGroups.Models;
using EE579.Domain;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.DeviceGroups.Impl
{
    public class DeviceGroupService : CrudAppService<DeviceGroup, DeviceGroupInput>, IDeviceGroupService
    {
        public DeviceGroupService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {

        }
        

    }
}
