using NotifiyMeService.Library.Models;
using NotifiyMeService.Library.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifiyMeService.Library.ServiceImplementations.ManualDependencyInjection
{
    public class NotificationSenderDI
    {
        private INotifybyPigeon emailProvider;
        private INotifybyRadioWaveSms smsProvider;

        public NotificationSenderDI(INotifybyPigeon _emailProvider)
        {
            emailProvider = _emailProvider;
        }

        public NotificationSenderDI(INotifybyRadioWaveSms _smsProvider)
        {
            smsProvider = _smsProvider;
        }

        public NotificationSenderDI(INotifybyPigeon _emailProvider, INotifybyRadioWaveSms _smsProvider)
        {
            emailProvider = _emailProvider;
            smsProvider = _smsProvider;
        }

        public PigeonResponse SendEmail(PigeonRequest request)
        {
            return emailProvider.SendAFitPigeon(request);
        }

        public RadioWaveSmsResponse SendSms(RadioWaveSmsRequest request)
        {
            return smsProvider.SendSms(request);
        }
    }
}
