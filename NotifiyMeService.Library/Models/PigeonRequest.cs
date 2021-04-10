using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.Models
{
    public class PigeonRequest : BaseRequest
    {
        public string Subject { get; set; }
        public string EmailAddress { get; set; }
    }
}
