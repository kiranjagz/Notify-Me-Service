using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyMeService.Api.Helpers.DatabaseRepository
{
    public interface IRepo
    {
        bool SaveaSomethingAwesome(string request, string response, int type, int clientId);
    }
}
