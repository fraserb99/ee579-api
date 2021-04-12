using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Slices.Email.Models;

namespace EE579.Core.Slices.Email
{
    public interface IEmailService
    {
        public Task SendEmail(string address, IEmail email);
    }
}
