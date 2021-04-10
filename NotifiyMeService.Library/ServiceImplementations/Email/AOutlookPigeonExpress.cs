using NotifiyMeService.Library.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifiyMeService.Library.Models;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using NotifyMeService.Data;
using NotifiyMeService.Library.Helpers;
using System.IO;

namespace NotifiyMeService.Library.ServiceImplementations.Email
{
    public class AOutlookPigeonExpress : INotifybyPigeon
    {
        public PigeonResponse SendAFitPigeon(PigeonRequest pigeonRequest)
        {
            PigeonResponse pigeonResponse = new PigeonResponse();

            try
            {
                var emailSettings = Settings.SurrenderEmailSettings();

                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = emailSettings.Username;
                networkCredential.Password = emailSettings.Password;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = emailSettings.Host;
                smtpClient.Port = int.Parse(emailSettings.Port);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = networkCredential;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                MailMessage mailMessage = new MailMessage();
                MailAddress mailAddress = new MailAddress(emailSettings.MailAddress);

                mailMessage.From = mailAddress;
                mailMessage.To.Add(pigeonRequest.EmailAddress);
                mailMessage.Subject = pigeonRequest.Subject;
                mailMessage.Body = pigeonRequest.Message;
                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);

                pigeonResponse.Success = true;
                pigeonResponse.Message = "Email submitted to email provider successfully.";
                pigeonResponse.SubmittedDateTime = DateTime.Now;
                pigeonResponse.To = pigeonRequest.EmailAddress;
                pigeonResponse.From = mailAddress.Address;
                pigeonResponse.Body = pigeonRequest.Message;
            }
            catch (Exception ex)
            {
                pigeonResponse.Success = false;
                pigeonResponse.Message = "An error has occurred: " + ex.Message;
                pigeonResponse.SubmittedDateTime = null;
            }

            return pigeonResponse;
        }
    }
}
