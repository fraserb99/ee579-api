using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Rules.Models.Inputs;
using EE579.Domain.Entities.Inputs;
using Microsoft.Extensions.Options;

namespace EE579.Core.Slices.Rules.Mapping
{
    public class MapWebhookUrl : IMappingAction<WebhookInput, WebhookInputDto>
    {
        private readonly AppSettings _settings;
        private const string UrlFormat = "{0}/webhooks/trigger/{1}";

        public MapWebhookUrl(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public void Process(WebhookInput source, WebhookInputDto destination, ResolutionContext context)
        {
            destination.Url = string.Format(UrlFormat, _settings.ApiUrl, source.Code);
        }
    }
}
