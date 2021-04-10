using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotifiyMeService.Library.ServiceInterfaces;
using NotifiyMeService.Library.ServiceImplementations.Sms;
using NotifiyMeService.Library.Models;

namespace NotifyMeService.Tests.NotifyMeService.LibraryTests
{
    [TestClass]
    public class SmsUnitTests
    {
        private INotifybyRadioWaveSms smsProvider;

        [TestMethod]
        public void TestSendSMSusingClickatellApi()
        {
            smsProvider = new ClickatellRadioWave();

            RadioWaveSmsRequest request = new RadioWaveSmsRequest();

            request.ClientId = "SmsClient002";
            request.DateCreated = DateTime.Now;
            request.Message = "Please deposit 1.25 million into my account. ThanksKBye";
            request.MobileNumber = "27837644406";

            var response = smsProvider.SendSms(request);
            Assert.IsTrue(response.Success, "Test to send a sms message using the Clickatell Api");
        }
    }
}
