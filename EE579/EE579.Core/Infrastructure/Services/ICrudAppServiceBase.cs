using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Infrastructure.Services
{
    public interface ICrudAppServiceBase<TEntity, TInput, TId>
    {
        public List<TEntity> GetAll();
        public TEntity GetById(TId id);
        public TEntity Create(TInput input);
        public TEntity Update(TId id, TInput input);
        public void Delete(TId id);
    }

}
