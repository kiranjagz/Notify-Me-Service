using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotifiyMeService.Library.ServiceInterfaces;
using NotifiyMeService.Library.ServiceImplementations.Email;
using NotifiyMeService.Library.Models;

namespace NotifyMeService.Tests.NotifyMeService.LibraryTests
{
    [TestClass]
    public class XMLtoEmailResponseUnitTests
    {
        private IXMLtoObject xmltoObject;

        [TestMethod]
        public void XMLtoEmailResponses()
        {
            XMLtoEmailResponse xmltoEmailResponse = new XMLtoEmailResponse();

            xmltoObject = new NotifiyMeService.Library.ServiceImplementations.XMLtoObject.XMLtoEmailResponseService();

            var response = xmltoObject.GetXMLEmailResponses();

            Assert.IsNotNull(response);
        }
    }
}
