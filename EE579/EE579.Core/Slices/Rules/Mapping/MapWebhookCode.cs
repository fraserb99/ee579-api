using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using EE579.Core.Infrastructure.Extensions;
using EE579.Core.Slices.Rules.Models.Inputs;
using EE579.Domain.Entities.Inputs;

namespace EE579.Core.Slices.Rules.Mapping
{
    public class MapWebhookCode : IMappingAction<WebhookInputDto, WebhookInput>
    {
        public void Process(WebhookInputDto source, WebhookInput destination, ResolutionContext context)
        {
            if (!destination.Code.IsNullOrEmpty())
                return;

            destination.Code = KeyGenerator.GetUniqueKey(32);
        }
    }
}
