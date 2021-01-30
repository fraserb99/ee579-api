using System;
using System.Collections.Generic;
using System.Text;

namespace IFTT.Core.Models
{
    public class ApiList<T>
    {
        public List<T> Items { get; set; }
    }
}
