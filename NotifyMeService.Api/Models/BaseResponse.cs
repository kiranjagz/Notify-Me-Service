using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ServerDateTime { get; set; }

        public Errors? ErrorType { get; set; }

        public enum Errors
        {
            SystemError = 0,
            InvalidEmail = 1,
            SMTPError = 2,
        }
    }
}