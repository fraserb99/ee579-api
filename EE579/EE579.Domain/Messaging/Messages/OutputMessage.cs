using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.IotHub.Models;
using EE579.Domain.Models;

namespace EE579.Core.Slices.IotHub.Messages
{
    public class OutputMessage : CloudToDeviceMessage
    {
        public OutputMessage(OutputType outputType)
        {
            Properties.Add("OutputType", outputType.ToString());
        }

        public OutputMessage(OutputType outputType, string peripheral)
        {
            Properties.Add("OutputType", outputType.ToString());
            Properties.Add("Peripheral", peripheral);
        }

        public OutputMessage(OutputType outputType, Enum peripheral)
        {
            Properties.Add("OutputType", outputType.ToString());
            Properties.Add("Peripheral", peripheral.ToString());
        }
    }
}
