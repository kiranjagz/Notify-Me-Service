using NotifyMeService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Helpers.DatabaseRepository
{
    public class DatabaseStuff : IRepo
    {
        public bool SaveaSomethingAwesome(string request, string response, int type, int clientId)
        {
            bool isSaved = false;

            using (NotifyMeServiceEntities entity = new NotifyMeServiceEntities())
            {
                NotifyMePlease notifyMePlease = new NotifyMePlease();
                notifyMePlease.DateCreated = DateTime.Now;
                notifyMePlease.NotifiyMeRequest = request;
                notifyMePlease.NotifyMeResponse = response;
                notifyMePlease.TypeId = type;
                notifyMePlease.ClientId = clientId;

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