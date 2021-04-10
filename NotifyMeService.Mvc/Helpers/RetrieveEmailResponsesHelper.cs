using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotifiyMeService.Library;
using NotifiyMeService.Library.ServiceInterfaces;

namespace NotifyMeService.Mvc.Helpers
{
    public class RetrieveEmailResponsesHelper
    {
        private IXMLtoObject xmltoObject;

        public RetrieveEmailResponsesHelper()
        {

        }

        public RetrieveEmailResponsesHelper(IXMLtoObject _xmltoObjects)
        {
            xmltoObject = _xmltoObjects;
        }

        public List<NotifiyMeService.Library.Models.XMLtoEmailResponse> RetrieveSomeEmails()
        {
            List<NotifiyMeService.Library.Models.XMLtoEmailResponse> xmltoEmailResponses = new List<NotifiyMeService.Library.Models.XMLtoEmailResponse>();

            xmltoEmailResponses = xmltoObject.GetXMLEmailResponses();

            return xmltoEmailResponses;
        }
    }
}