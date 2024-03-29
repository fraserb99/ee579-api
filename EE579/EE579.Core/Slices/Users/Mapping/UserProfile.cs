﻿using AutoMapper;
using EE579.Core.Slices.Tenants.Models;
using EE579.Core.Slices.Users.Models;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;

namespace EE579.Core.Slices.Users.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserInput, User>();
            CreateMap<User, UserDto>();
            CreateMap<Tenant, TenantDto>();
            CreateMap<TenantUser, UserDto>()
                .IncludeMembers(x => x.User)
                .ForMember(x => x.Status, opts => opts.MapFrom(y => y.User.PasswordHash.IsNullOrEmpty() ? UserStatus.Invited : UserStatus.Active));
            CreateMap<UserInput, TenantUser>();

            CreateMap<User, Guid>()
                .ConvertUsing(x => x.Id);
        }
    }
}
