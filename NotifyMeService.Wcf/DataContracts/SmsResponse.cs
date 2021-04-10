using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NotifyMeService.Wcf.DataContracts
{
    [DataContract]
    public class SmsResponse : BaseResponse
    {
        [DataMember]
        public string ApiMessageId { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string TextMessage { get; set; }
    }
}