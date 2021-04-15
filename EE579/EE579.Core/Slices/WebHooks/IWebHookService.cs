using EE579.Core.Slices.WebHooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.WebHooks
{
    public interface IWebHookService
    {
        public Task MockInput(Guid id, WebHookMockInput input);
    }
}
