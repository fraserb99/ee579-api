using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;

namespace EE579.Core.Slices.Rules.Processing
{
    public interface IRuleProcessor : IDisposable, IAsyncDisposable
    {
        public Task ProcessInput();
    }
}
