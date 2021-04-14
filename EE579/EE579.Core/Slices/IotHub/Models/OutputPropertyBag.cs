using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.IotHub.Models
{
    public class OutputPropertyBag : IOutputPropertyBag
    {
        public string OutputType { get; set; }
        public string Peripheral { get; set; }

        public OutputPropertyBag(string outputType, string peripheralType)
        {
            OutputType = outputType;
            Peripheral = peripheralType;
        }

        public OutputPropertyBag(string outputType)
        {
            OutputType = outputType;
        }


        public Dictionary<string, string> GetPropertyBag()
        {
            var outputDict = new Dictionary<string, string>();
            outputDict.Add("OutputType", OutputType);
            if(Peripheral != null)
                outputDict.Add("Peripheral", Peripheral);
            return outputDict;
        }
        //public Dictionary<string, string> GetOutputType()
        //{
        //    var outputDict = new Dictionary<string, string>();
        //    outputDict.Add("OutputType", OutputType);
        //    return outputDict;
        //}

        //public string GetOutputType()
        //{
        //    return OutputType;
        //}

        //public string GetPeripheral()
        //{
        //    return Peripheral;
        //}
        //public Dictionary<string, string> GetPeripheral()
        //{
        //    var periphDict = new Dictionary<string, string>();
        //    periphDict.Add("Peripheral", Peripheral);
        //    return periphDict;
        //}
    }
}
