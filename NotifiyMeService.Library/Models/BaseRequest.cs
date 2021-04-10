using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.Models
{
    public abstract class BaseRequest
    {
        public DateTime DateCreated { get; set; }
        public string ClientId { get; set; }
        public string Message { get; set; }
    }
}
