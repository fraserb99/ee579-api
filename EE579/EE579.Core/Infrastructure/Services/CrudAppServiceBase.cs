using AutoMapper;
using EE579.Domain;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EE579.Core.Infrastructure.Services
{

    public abstract class CrudAppService<TEntity, TInput, TCreateInput, TContext, TId> where TEntity : Entity<TId> where TContext : DbContext
    {
        protected readonly TContext Repository;
        protected readonly IMapper Mapper;

        protected CrudAppService(TContext repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await Repository.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(TId id)
        {
            return await Repository.FindAsync<TEntity>(id);
        }

        public virtual async Task<TEntity> Create(TCreateInput input)
        {
            await ValidateCreateInputAsync(input);
            var entity = Mapper.Map<TEntity>(input);

            await Repository.AddAsync(entity);
            await Repository.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> Update(TId id, TInput input)
        {
            var entity = await Repository.FindAsync<TEntity>(id);
            await ValidateInputAsync(input, entity);

            entity = Mapper.Map(input, entity);
            await Repository.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Delete(TId id)
        {
            var entity = await GetById(id);

            Repository.Remove(entity);
            await Repository.SaveChangesAsync();
        }

        protected virtual async Task ValidateInputAsync(TInput input, TEntity entity = null) { }

        protected virtual async Task ValidateCreateInputAsync(TCreateInput input) { }
    }

    public abstract class CrudAppService<TEntity, TInput, TCreateInput> : CrudAppService<TEntity, TInput, TCreateInput, DatabaseContext, Guid>
        where TEntity : Entity<Guid>
    {
        protected CrudAppService(DatabaseContext repository, IMapper mapper)
            : base(repository, mapper) { }
    }

    public abstract class CrudAppService<TEntity, TInput> : CrudAppService<TEntity, TInput, TInput, DatabaseContext, Guid>
        where TEntity : Entity<Guid>
    {
        protected CrudAppService(DatabaseContext repository, IMapper mapper)
            : base(repository, mapper) { }
    }

    public abstract class CrudAppServiceWithIdType<TEntity, TInput, TId> : CrudAppService<TEntity, TInput, TInput, DatabaseContext, TId>
        where TEntity : Entity<TId>
    {
        protected CrudAppServiceWithIdType(DatabaseContext repository, IMapper mapper)
            : base(repository, mapper) { }
    }

    public abstract class CrudAppServiceWithIdType<TEntity, TInput, TCreateInput, TId> : CrudAppService<TEntity, TInput, TCreateInput, DatabaseContext, TId>
        where TEntity : Entity<TId>
    {
        protected CrudAppServiceWithIdType(DatabaseContext repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
