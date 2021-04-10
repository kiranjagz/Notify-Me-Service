using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Models
{
    public class BaseRequest
    {
        public DateTime DateCreated { get; set; }
        public string ClientId { get; set; }
        public string Message { get; set; }
    }
}