using AutoMapper;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Infrastructure.Mapping
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<EntityWithGuid, Guid>()
                .IncludeAllDerived()
                .ConvertUsing(x => x.Id);
        }
    }
}
