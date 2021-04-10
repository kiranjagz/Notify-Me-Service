using System;
using System.Net;
using System.IO;
using NotifyMeService.Wcf.DataContracts;
using NotifyMeService.Wcf.Helpers.DatabaseRepository;
using NotifyMeService.Wcf.Helpers.Common;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using NotifiyMeService.Library.ServiceInterfaces;
using NotifiyMeService.Library.Models;
using NotifiyMeService.Library.ServiceImplementations.Email;
using NotifyMeService.Wcf.Factories;
using System.Security.Permissions;
using NotifiyMeService.Library.ServiceImplementations.Sms;

namespace NotifyMeService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NotifyMeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NotifyMeService.svc or NotifyMeService.svc.cs at the Solution Explorer and start debugging.
    public class NotifyMeService : INotifyMeService
    {
        INotifybyPigeon notifyByPigeon;
        INotifybyRadioWaveSms notifyByRadioWaveSms;

        public NotifyMeService()
        {
            notifyByPigeon = new AOutlookPigeonExpress();
            notifyByRadioWaveSms = new ClickatellRadioWave();
        }

        public NotifyMeService(INotifybyPigeon concreteImplementation)
        {
            notifyByPigeon = concreteImplementation;
        }

        public NotifyMeService(INotifybyRadioWaveSms concreteImplementation)
        {
            notifyByRadioWaveSms = concreteImplementation;
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "admin")]
        public EmailResponse NotifymeThankyoubyEmail(EmailRequest emailRequest)
        {
            EmailResponse emailResponse = new EmailResponse();
            DatabaseStuff databaseStuff = new DatabaseStuff();
            string request, response;

            try
            {
                #region for wcf basic auth services
                var hostIdentity = WindowsIdentity.GetCurrent().Name;
                var primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                var windowsIdentity = ServiceSecurityContext.Current.WindowsIdentity.Name;
                var threadIdentity = Thread.CurrentPrincipal.Identity.Name;
                //var isAdmin = Thread.CurrentPrincipal.IsInRole("admin");
                #endregion

                var pigeonRequest = EmailFactory.CreatePigeonRequest(emailRequest);

                var pigeonResponse = notifyByPigeon.SendAFitPigeon(pigeonRequest);

                if (pigeonResponse.Success)
                {
                    emailResponse = EmailFactory.CreateEmailResponse(pigeonResponse);

                    request = CommonUtility.SerializeObject(emailRequest);
                    response = CommonUtility.SerializeObject(emailResponse);

                    var isSaved = databaseStuff.SaveaSomethingAwesome(request, response, 1);
                }
            }
            catch (Exception ex)
            {
                emailResponse.Success = false;
                emailResponse.Message = "An error has occurred: " + ex.Message;
                emailResponse.SubmittedDateTime = null;
            }

            return emailResponse;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public SmsResponse PingmePleasebySms(SmsRequest smsRequest)
        {
            SmsResponse smsResponse = new SmsResponse();
            DatabaseStuff databaseStuff = new DatabaseStuff();
            string request, response, streamResponse;

            try
            {
                #region for wcf basic auth services
                var hostIdentity = WindowsIdentity.GetCurrent().Name;
                var primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                var windowsIdentity = ServiceSecurityContext.Current.WindowsIdentity.Name;
                var threadIdentity = Thread.CurrentPrincipal.Identity.Name;
                //var isAdmin = Thread.CurrentPrincipal.IsInRole("admin");
                #endregion

                //todo: Implement the sms stuff in the wcf service
            }
            catch (Exception ex)
            {
                smsResponse.Success = false;
                smsResponse.Message = "An error has occurred: " + ex.Message;
                smsResponse.ApiMessageId = null;
                smsResponse.SubmittedDateTime = null;
            }

            return smsResponse;
        }
    }
}
