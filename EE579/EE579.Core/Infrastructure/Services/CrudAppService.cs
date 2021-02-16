using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EE579.Domain;
using EE579.Domain.Entities;

namespace EE579.Core.Infrastructure.Services
{
    public abstract class CrudAppService<TEntity, TDto> : CrudAppServiceBase<TEntity, TDto, Guid> where TEntity : Entity<Guid>
    {
        protected CrudAppService(DatabaseContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
