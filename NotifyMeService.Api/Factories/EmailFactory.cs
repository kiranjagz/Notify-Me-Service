using NotifiyMeService.Library.Models;
using NotifyMeService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Factories
{
    public class EmailFactory
    {
        public static PigeonRequest CreatePigeonRequest(EmailRequest emailRequest)
        {
            PigeonRequest pigeonRequest = new PigeonRequest();

            pigeonRequest.ClientId = emailRequest.ClientId;
            pigeonRequest.DateCreated = emailRequest.DateCreated;
            pigeonRequest.EmailAddress = emailRequest.EmailAddress;
            pigeonRequest.Message = emailRequest.Message;
            pigeonRequest.Subject = emailRequest.Subject;

            return pigeonRequest;
        }

        public static EmailResponse CreateEmailResponse(PigeonResponse pigeonResponse)
        {
            EmailResponse emailResponse = new EmailResponse();

            emailResponse.Body = pigeonResponse.Body;
            emailResponse.From = pigeonResponse.From;
            emailResponse.Message = pigeonResponse.Message;
            emailResponse.SubmittedDateTime = (DateTime)pigeonResponse.SubmittedDateTime;
            emailResponse.Success = pigeonResponse.Success;
            emailResponse.To = pigeonResponse.To;

            return emailResponse;
        }
    }
}