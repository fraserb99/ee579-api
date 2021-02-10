using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Infrastructure.Services
{
    public interface ICrudAppService<TEntity, TInput>
    {
        public List<TEntity> GetAll();
        public TEntity GetById(Guid id);
        public TEntity Create(TInput input);
        public TEntity Update(Guid id, TInput input);
        public void Delete(Guid id);
    }

}
