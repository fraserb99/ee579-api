using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.WebHooks.Models
{
    public class WebHookMockInput
    {
        public Dictionary<string, string> Properties { get; set; }
        public object Body { get; set; }
    }
}
