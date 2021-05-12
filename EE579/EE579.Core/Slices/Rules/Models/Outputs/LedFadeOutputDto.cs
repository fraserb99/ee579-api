using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Rules.Models.Outputs
{
    public class LedFadeOutputDto : LedPeriodOutputDto
    {
        public bool Value { get; set; }
    }
}
