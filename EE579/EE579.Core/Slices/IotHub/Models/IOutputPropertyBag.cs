using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub.Models
{
    public interface IOutputPropertyBag
    {

        public Dictionary<string, string> GetPropertyBag();
        //public Dictionary<string, string> GetOutputType();
        ///public string GetOutputType();
        //public Dictionary<string, string> GetPeripheral();
        //public string GetPeripheral();
    }
}
