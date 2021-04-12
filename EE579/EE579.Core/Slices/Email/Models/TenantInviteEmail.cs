using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Email.Models
{
    class TenantInviteEmail : IEmail
    {
        
        public TenantInviteEmail(User inviter, User recipient, string appUrl)
        {
            User = inviter;
            Recipient = recipient;
            AppUrl = appUrl;

        }
        public string Subject { get; set; } = "EE579 Tenant Invite";
        private readonly User Recipient;
        private readonly string AppUrl;
        public User User { get; set; }


        private const string Template = "<p>Hi,<br /><br /> {0} has invited you to join their tenant, <a href=\"{1}\" target=\"__blank\">Sign up or Sign in</a> to access the admin page.</p>";
        public string GetBody()
        {
            return string.Format(Template, User.Name, AppUrl);
        }
    }
}
