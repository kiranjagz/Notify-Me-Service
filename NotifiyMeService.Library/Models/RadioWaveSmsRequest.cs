using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.Models
{
    public class RadioWaveSmsRequest : BaseRequest
    {
        public string MobileNumber { get; set; }
    }
}
