using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Slices.Email.Models
{
    public class Email : IEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string GetBody()
        {
            return Body;
        }
    }
}
