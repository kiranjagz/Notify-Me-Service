using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NotifyMeService.Wcf.DataContracts
{
    [DataContract]
    public class SmsRequest : BaseRequest
    {
        [DataMember]
        public string MobileNumber { get; set; }
    }
}