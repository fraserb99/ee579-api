using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Rules.Processing.Models
{
    public class InputTypeBody<TEnum> where TEnum : struct
    {
        public TEnum? InputType { get; set; }
    }
}
