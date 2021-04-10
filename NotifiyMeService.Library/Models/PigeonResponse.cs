using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.Models
{
    public class PigeonResponse : BaseResponse
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
    }
}
