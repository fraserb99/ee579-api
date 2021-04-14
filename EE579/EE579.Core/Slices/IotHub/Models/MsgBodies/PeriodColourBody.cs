using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub.Models.MsgBodies
{
    public class PeriodColourBody
    {
        public int Period { get; set; }
        public LedColourEnum Colour { get; set; }
    }
}
