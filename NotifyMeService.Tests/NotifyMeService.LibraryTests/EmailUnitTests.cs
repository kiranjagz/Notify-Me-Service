using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotifiyMeService.Library.ServiceInterfaces;
using NotifiyMeService.Library.ServiceImplementations.Email;
using NotifiyMeService.Library.Models;

namespace NotifyMeService.Tests.NotifyMeService.LibraryTests
{
    [TestClass]
    public class EmailUnitTests
    {
        private INotifybyPigeon emailProvider;

        //public EmailUnitTests(INotifybyPigeon emailProvider)
        //{
        //    emailProvider = this.emailProvider;
        //}

        [TestMethod]
        public void TestSendEmailUsingOutlookSMTP()
        {
            emailProvider = new AOutlookPigeonExpress();

            PigeonRequest request = new PigeonRequest();
            request.ClientId = "TestClient001";
            request.DateCreated = DateTime.Now;
            request.EmailAddress = "kiranjagz@gmail.com";
            request.Message = "Dude!!! Niject you say???";
            request.Subject = "INinja";

            var response = emailProvider.SendAFitPigeon(request);
            Assert.IsTrue(response.Success, "Sends an email to a client using Microsoft Outlook SMTP Provider");
        }

        [TestMethod]
        public void TestSendEmailUsingGMailSMTP()
        {
            emailProvider = new AGmailPigeonExpress();

            PigeonRequest request = new PigeonRequest();
            request.ClientId = "TestClient001";
            request.DateCreated = DateTime.Now;
            request.EmailAddress = "kiranjagz@gmail.com";
            request.Message = "Dude!!! Niject you say???";
            request.Subject = "INinja";

            var response = emailProvider.SendAFitPigeon(request);
            Assert.IsTrue(response.Success, "Sends an email to a client using Google Gmail SMTP Provider");
        }
    }
}
