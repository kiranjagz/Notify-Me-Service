using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NotifiyMeService.Library.Models
{
    [Serializable]
    public class XMLtoEmailResponse
    {
        public int Id { get; set; }
        [XmlElement]
        public string Success { get; set; }
        [XmlElement]
        public string Message { get; set; }
        [XmlElement]
        public string SubmittedDateTime { get; set; }
        [XmlElement]
        public string To { get; set; }
        [XmlElement]
        public string From { get; set; }
        [XmlElement]
        public string Body { get; set; }
    }
}
