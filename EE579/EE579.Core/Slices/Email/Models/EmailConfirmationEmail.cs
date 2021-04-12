using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EE579.Core.Infrastructure.Settings;
using EE579.Domain.Entities;

namespace EE579.Core.Slices.Email.Models
{
    public class EmailConfirmationEmail : IEmail
    {
        public EmailConfirmationEmail(User user, string token, string apiUrl)
        {
            User = user;
            Token = token;
            ApiUrl = apiUrl;
        }
        public string Subject { get; set; } = "EE579 Confirm Email";
        public string ApiUrl { get; set; }
        public string Token { get; set; }
        public User User { get; set; }


        private const string Template = "<p>Hi {0},<br /><br /> click <a href=\"{1}/users/confirm-email?userId={2}&token={3}\" target=\"__blank\">here</a> to confirm your email address</p>";
        public string GetBody()
        {
            return string.Format(Template, User.Name, ApiUrl, User.Id, HttpUtility.UrlEncode(Token));
        }
    }
}
