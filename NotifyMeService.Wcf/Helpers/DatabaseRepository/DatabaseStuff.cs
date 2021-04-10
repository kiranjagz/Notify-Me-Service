using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotifyMeService.Data;

namespace NotifyMeService.Wcf.Helpers.DatabaseRepository
{
    public class DatabaseStuff
    {
        public bool SaveaSomethingAwesome(string request, string response, int type)
        {
            bool isSaved = false;

            using (NotifyMeServiceEntities entity = new NotifyMeServiceEntities())
            {
                NotifyMePlease notifyMePlease = new NotifyMePlease();
                notifyMePlease.DateCreated = DateTime.Now;
                notifyMePlease.NotifiyMeRequest = request;
                notifyMePlease.NotifyMeResponse = response;
                notifyMePlease.TypeId = type;

                entity.NotifyMePlease.Add(notifyMePlease);
                var saveChanges = entity.SaveChanges();

                if (saveChanges > 0)
                    isSaved = true;
                else
                    isSaved = false;
            }

            return isSaved;
        }
    }
}