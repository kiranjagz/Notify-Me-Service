using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Models
{
    public class EmailResponse : BaseResponse
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public DateTime SubmittedDateTime { get; set; }
    }
}