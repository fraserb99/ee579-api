using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Models
{
    public class ApiList<T>
    {
        public ApiList() { }
        public ApiList(IEnumerable<T> items)
        {
            Items = new List<T>();
            Items.AddRange(items);
        }
        public List<T> Items { get; set; }
    }
}
