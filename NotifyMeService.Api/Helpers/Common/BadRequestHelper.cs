using NotifyMeService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Helpers.Common
{
    public class BadRequestHelper
    {
        public Dictionary<string, string> BuildBadRequestModelState(BaseResponse baseResponse)
        {
            Dictionary<string, string> badRequestResponseDictionary = new Dictionary<string, string>();
            int errorType = 0;

            errorType = (int)baseResponse.ErrorType;

            badRequestResponseDictionary.Add("Success", baseResponse.Success.ToString());
            badRequestResponseDictionary.Add("ServerDateTime", baseResponse.ServerDateTime.ToString());
            badRequestResponseDictionary.Add("ErrorMessage", baseResponse.Message);
            badRequestResponseDictionary.Add("ErrorType", errorType.ToString());

            return badRequestResponseDictionary;
        }
    }
}