using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.IotHub.Impl;
using EE579.Core.Slices.IotHub.Messages;
using EE579.Core.Slices.IotHub.Models;
using EE579.Domain.Models;

namespace EE579.Domain.Entities
{
    public abstract class RuleOutput : EntityWithTenant<Guid>
    {
        protected RuleOutput(OutputType type)
        {
            Type = type;
        }
        public virtual Device Device { get; set; }
        public virtual DeviceGroup DeviceGroup { get; set; }
        [Required]
        public OutputType Type { get; set; }

        public Task SendOutputMessage()
        {
            var message = BuildMessage();

            return IotMessagingService.SendMessage(Device.Id, message);
        }

        private ICloudToDeviceMessage BuildMessage()
        {
            var message = CreateMessageCore();
            message.Body = BuildMessageBody();

            return message;
        }

        protected virtual CloudToDeviceMessage CreateMessageCore()
        {
            return new OutputMessage(Type);
        }

        protected virtual object BuildMessageBody()
        {
            return null;
        }
    }
}
