using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using EE579.Core.Infrastructure.Exceptions;
using EE579.Domain;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EE579.Core.Slices.Rules.Processing
{
    public class WebhookProcessor : IRuleProcessor
    {
        protected readonly DatabaseContext _context;
        private readonly string _code;
        protected readonly HttpContext _httpContext;

        public WebhookProcessor(IConfiguration configuration, string code, HttpContext httpContext)
        {
            _context = GetContext(configuration);
            _code = code;
            _httpContext = httpContext;
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

        public async Task ProcessInput()
        {
            var rules = await GetTriggeredCore(_context.WebhookInputs);

            await ProcessRules(rules);
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
                    allTasks.Add(ruleOutput.SendOutputMessage(_httpContext.Request.ReadFromJsonAsync<object>(), _httpContext));
                }
                await throttler.WaitAsync();
            }
            await Task.WhenAll(allTasks);
        }

        protected async Task<IEnumerable<Rule>> GetTriggeredCore(IQueryable<WebhookInput> rules)
        {
            var triggered = await rules
                .Where(x => x.Code == _code)
                .Select(x => x.Rule)
                .ToListAsync();

            if (!triggered.Any())
                throw new HttpStatusCodeException(404);

            return triggered;
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
