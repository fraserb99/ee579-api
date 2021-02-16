using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Infrastructure.Services
{
    public interface ICrudAppService<TEntity, Tinput> : ICrudAppServiceBase<TEntity, Tinput, Guid>
    {
    }
}
