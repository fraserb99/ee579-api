using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Infrastructure.Services
{
    public interface ICrudAppService<TEntity, TInput, TCreateInput, TId>
    {
        public Task<List<TEntity>> GetAll();
        public Task<TEntity> GetById(TId id);
        public Task<TEntity> Create(TCreateInput input);
        public Task<TEntity> Update(TId id, TInput input);
        public Task Delete(TId id);
    }

    public interface ICrudAppService<TEntity, TInput, TCreateInput> : ICrudAppService<TEntity, TInput, TCreateInput, Guid>
    {

    }

    public interface ICrudAppService<TEntity, TInput> : ICrudAppService<TEntity, TInput, TInput, Guid>
    {

    }
}
