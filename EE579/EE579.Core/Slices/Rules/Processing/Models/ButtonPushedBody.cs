using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Processing.Models
{
    public class ButtonPushedBody
    {
        public ButtonPeripheral InputType { get; set; }
        public int Value { get; set; }
    }
}
