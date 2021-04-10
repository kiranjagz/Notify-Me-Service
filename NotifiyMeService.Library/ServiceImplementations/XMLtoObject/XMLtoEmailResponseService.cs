using NotifiyMeService.Library.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifiyMeService.Library.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace NotifiyMeService.Library.ServiceImplementations.XMLtoObject
{
    public class XMLtoEmailResponseService : IXMLtoObject
    {
        private NotifyMeService.Data.NotifyMeServiceEntities entity;

        public List<Models.XMLtoEmailResponse> GetXMLEmailResponses()
        {
            List<Models.XMLtoEmailResponse> emailResponses = new List<Models.XMLtoEmailResponse>();

            using (entity = new NotifyMeService.Data.NotifyMeServiceEntities())
            {
                var xmlEmailResponses = entity.NotifyMePlease.Where(x => x.TypeId == 1).ToList();

                foreach(var item in xmlEmailResponses)
                {
                    XmlRootAttribute xmlRootAttribute = new XmlRootAttribute();
                    xmlRootAttribute.ElementName = "EmailResponse";
                    xmlRootAttribute.IsNullable = true;

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.XMLtoEmailResponse),xmlRootAttribute);
                    StringReader reader = new StringReader(item.NotifyMeResponse);
                    var response = xmlSerializer.Deserialize(reader) as Models.XMLtoEmailResponse;
                    response.Id = item.NotifyMeServiceId;
                    emailResponses.Add(response);
                }
            }

            return emailResponses;
        }
    }
}
