using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Settings;
using EE579.Core.Slices.Email.Models;
using Microsoft.Extensions.Options;

namespace EE579.Core.Slices.Email
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly SmtpSettings _settings;
        public EmailService(IOptions<SmtpSettings> options)
        {
            _settings = options.Value;

            _smtpClient = new SmtpClient(_settings.Host)
            {
                Port = _settings.Port,
                Credentials = new NetworkCredential(_settings.Email, _settings.Password),
                EnableSsl = true,
            };
        }

        public async Task SendEmail(string address, IEmail email)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_settings.Email),
                To = { address },
                Subject = email.Subject,
                Body = email.GetBody(),
                IsBodyHtml = true
            };

            if (_settings.EmailEnabled)
                await _smtpClient.SendMailAsync(message);
        }
    }
}
