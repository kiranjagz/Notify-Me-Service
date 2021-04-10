using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotifiyMeService.Library.ServiceInterfaces;
using NotifiyMeService.Library.ServiceImplementations.ManualDependencyInjection;
using NotifiyMeService.Library.ServiceImplementations.Email;
using NotifiyMeService.Library.Models;

namespace NotifyMeService.Tests.NotifyMeService.LibraryTests
{
    [TestClass]
    public class ManualDIUnitTests
    {
        private INotifybyPigeon emailProvider;
        private INotifybyRadioWaveSms smsProvider;
        private NotificationSenderDI notificationSenderDI;

        [TestMethod]
        public void TestEmailWithDI()
        {
            notificationSenderDI = new NotificationSenderDI(new AOutlookPigeonExpress());

            PigeonRequest request = new PigeonRequest();
            request.ClientId = "TestClient001";
            request.DateCreated = DateTime.Now;
            request.EmailAddress = "bobbi@gmail.com";
            request.Message = "Dude!!! Niject you say???";
            request.Subject = "INinja";

            var response = notificationSenderDI.SendEmail(request);

            Assert.IsTrue(response.Success, "Send an email using outlook email provider, manual dependency injection");
        }
    }
}
