using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NotifyMeService.Wcf.DataContracts
{
    [DataContract]
    public class EmailResponse : BaseResponse
    {
        [DataMember]
        public string To { get; set; }
        [DataMember]
        public string From { get; set; }
        [DataMember]
        public string Body { get; set; }
    }
}