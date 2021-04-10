using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NotifyMeService.Wcf.DataContracts
{
    [DataContract]
    public class EmailRequest : BaseRequest
    {
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
    }
}