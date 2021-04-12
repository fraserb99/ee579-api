using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Slices.Email.Models
{
    public interface IEmail
    {
        public string Subject { get; set; }

        public string GetBody();
    }
}
