using NotifiyMeService.Library.ServiceInterfaces;
using NotifyMeService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Helpers.Services
{
    public class EmailService
    {
        private INotifybyPigeon emailProvider;

        public EmailService(INotifybyPigeon _emailProvider)
        {
            emailProvider = _emailProvider;
        }

        public EmailResponse SendEmail(EmailRequest emailRequest)
        {
            EmailResponse emailResponse = new EmailResponse();

            return emailResponse;
        }
    }
}