using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NotifyMeService.Wcf.DataContracts
{
    [DataContract]
    public abstract class BaseRequest
    {
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}