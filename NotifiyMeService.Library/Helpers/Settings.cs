using NotifyMeService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.Helpers
{
    public static class Settings
    {
        public static EmailSettings SurrenderEmailSettings()
        {
            EmailSettings emailSettings = new EmailSettings();

            using (NotifyMeServiceEntities entity = new NotifyMeServiceEntities())
            {
                emailSettings = entity.EmailSettings.FirstOrDefault();
            }

            return emailSettings;
        }

        public static SmsSettings DeliverSmsSettings()
        {
            SmsSettings smsSetting = new SmsSettings();

            using (NotifyMeServiceEntities entity = new NotifyMeServiceEntities())
            {
                smsSetting = entity.SmsSettings.FirstOrDefault();
            }

            return smsSetting;
        }
    }
}
