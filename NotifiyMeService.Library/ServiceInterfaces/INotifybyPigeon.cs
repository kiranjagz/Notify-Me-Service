using NotifiyMeService.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.ServiceInterfaces
{
    public interface INotifybyPigeon
    {
        PigeonResponse SendAFitPigeon(PigeonRequest pigeonRequest);
    }
}
