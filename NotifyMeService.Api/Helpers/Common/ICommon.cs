using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyMeService.Api.Helpers.Common
{
    public interface ICommon
    {
         string SerializeObject<T>(T toSerialize);
    }
}
