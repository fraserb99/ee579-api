using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub.Models
{
    public class BoardInputsDto
    {
        public bool Potentiometer { get; set; }
        public bool Temperature { get; set; }
        public bool Button1 { get; set; }
        public bool Button2 { get; set; }
    }
}
