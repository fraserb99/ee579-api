using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Infrastructure.Settings
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool EmailEnabled { get; set; }
    }
}
