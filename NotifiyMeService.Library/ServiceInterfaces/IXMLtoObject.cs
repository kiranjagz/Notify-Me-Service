using NotifiyMeService.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.ServiceInterfaces
{
    public interface IXMLtoObject
    {
        List<XMLtoEmailResponse> GetXMLEmailResponses();
    }
}
