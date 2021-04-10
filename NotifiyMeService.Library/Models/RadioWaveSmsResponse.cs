using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.Models
{
    public class RadioWaveSmsResponse : BaseResponse
    {
        public string ApiMessageId { get; set; }
        public string MobileNumber { get; set; }
        public string TextMessage { get; set; }
    }
}
