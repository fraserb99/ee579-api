using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Domain;
using EE579.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EE579.Core.Slices.Rules.Processing
{
    public abstract class RuleProcessor<TRuleInput, TMessageBody> : IRuleProcessor where TRuleInput : RuleInput
    {
        protected readonly DatabaseContext _context;
        private readonly ProcessEventArgs _args;
        protected readonly TMessageBody MessageBody;

        protected RuleProcessor(ProcessEventArgs args, IConfiguration configuration)
        {
            _context = GetContext(configuration);
            _args = args;
            MessageBody = _args.Data.EventBody.ToObjectFromJson<TMessageBody>();
        }

        public async Task ProcessInput()
        {
            var triggered = await GetTriggeredRules();

            await ProcessRules(triggered);
        }

        private async Task<IEnumerable<Rule>> GetTriggeredRules()
        {
            var deviceId = _args.GetDeviceId();
            var inputType = _args.GetInputType();

            var deviceInputRules = _context.Set<TRuleInput>()
                .Where(x => x.Device.Id == deviceId && x.Type == inputType);

            return await GetTriggeredCore(deviceInputRules);
        }

        protected abstract Task<IEnumerable<Rule>> GetTriggeredCore(IQueryable<TRuleInput> rules);
        protected abstract Task ProcessOutput(RuleOutput output);

        protected virtual async Task AddRuleTriggeredEvent(Rule rule)
        {

        }

        private async Task ProcessRules(IEnumerable<Rule> rules)
        {
            var allTasks = new List<Task>();
            var throttler = new SemaphoreSlim(25);

            foreach (var rule in rules)
            {
                foreach (var ruleOutput in rule.Outputs)
                {
                    await throttler.WaitAsync();
                    allTasks.Add(ProcessOutput(ruleOutput));
                }
                await throttler.WaitAsync();
                allTasks.Add(AddRuleTriggeredEvent(rule));
            }
            await Task.WhenAll(allTasks);
        }

        private DatabaseContext GetContext(IConfiguration configuration)
        {
            var contextBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            contextBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("Default"));
            var context = new DatabaseContext(contextBuilder.Options, new HttpContextAccessor());

            return context;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_context is not null)
            {
                await _context.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
