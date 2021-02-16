using AutoMapper;
using EE579.Domain;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EE579.Core.Infrastructure.Services
{

    public abstract class CrudAppServiceBase<TEntity, TInput, TId> where TEntity : Entity<TId>
    {
        protected readonly DatabaseContext Repository;
        protected readonly IMapper Mapper;

        protected CrudAppServiceBase(DatabaseContext repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual List<TEntity> GetAll()
        {
            return Repository.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TId id)
        {
            return Repository.Find<TEntity>(id);
        }

        public virtual TEntity Create(TInput input)
        {
            ValidateInput(input);
            var entity = Mapper.Map<TEntity>(input);

            Repository.Add(entity);
            Repository.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(TId id, TInput input)
        {
            var entity = Repository.Find<TEntity>(id);
            ValidateInput(input, entity);

            entity = Mapper.Map(input, entity);
            Repository.SaveChanges();

            return entity;
        }

        public virtual void Delete(TId id)
        {
            var entity = GetById(id);

            Repository.Remove(entity);
            Repository.SaveChanges();
        }

        protected virtual void ValidateInput(TInput input, TEntity entity = null) { }
    }
}
