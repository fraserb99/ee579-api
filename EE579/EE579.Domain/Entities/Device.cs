using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EE579.Core.Slices.IotHub.Models;
using EE579.Domain.Models;
using System.Linq;
using EE579.Core.Slices.IotHub.Messages;
using EE579.Core.Slices.IotHub.Impl;

namespace EE579.Domain.Entities
{
    public class Device : EntityWithTenant<string>
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public Guid WebId { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public DateTime LastDisconnectionTime { get; set; }

        public virtual List<RuleInput> Inputs { get; set; }
        public virtual List<RuleOutput> Outputs { get; set; }
        public virtual ICollection<DeviceGroup> DeviceGroups { get; set; }

        public void NotifyOfInputs()
        {
            var inputs = new BoardInputsDto
            {
                Potentiometer = Inputs.Any(x => x.Type == InputType.Potentiometer),
                Temperature = Inputs.Any(x => x.Type == InputType.Temperature),
                Button1 = Inputs.Any(x => x.Type == InputType.ButtonPushed),
                Button2 = Inputs.Where(x => x.Type == InputType.ButtonPushed).Count() > 1
            };

            var msg = new CloudToDeviceMessage();
            msg.Body = inputs;
            var properties = new Dictionary<string, string> {
                {"MessageType","DeviceConfig" }
            };
            msg.Properties = properties;

            IotMessagingService.SendMessage(Id, msg);
        }

        public void NotifyRuleDeletion()
        {
            var inputs = new BoardInputsDto();
            var msg = new CloudToDeviceMessage();
            msg.Body = inputs;
            var properties = new Dictionary<string, string> {
                {"MessageType","DeviceConfig" }
            };
            msg.Properties = properties;

            IotMessagingService.SendMessage(Id, msg);
        }



    }
}
