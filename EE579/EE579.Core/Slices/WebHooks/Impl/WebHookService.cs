using EE579.Core.Slices.IotHub.Impl;
using EE579.Core.Slices.IotHub.Messages;
using EE579.Core.Slices.WebHooks.Models;
using EE579.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.WebHooks.Impl
{
    public class WebHookService : IWebHookService
    {
        private readonly DatabaseContext _context;
        public WebHookService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task MockInput(Guid id, WebHookMockInput input)
        {
            var deviceId = _context.Devices.FirstOrDefault(x => x.WebId == id).Id;

            var msg = new CloudToDeviceMessage() {
                Properties = input.Properties,
                Body = input.Body
            };

            await IotMessagingService.SendMessage(deviceId, msg);
        }
    }
}
