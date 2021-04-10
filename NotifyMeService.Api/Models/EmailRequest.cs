using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Models
{
    public class EmailRequest : BaseRequest
    {
        public string Subject { get; set; }
        public string EmailAddress { get; set; }
    }
}