using NotifyMeService.Wcf.DataContracts;
using System.ServiceModel;

namespace NotifyMeService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INotifyMeService" in both code and config file together.
    [ServiceContract]
    public interface INotifyMeService
    {
        [OperationContract]
        EmailResponse NotifymeThankyoubyEmail(EmailRequest emailRequest);

        [OperationContract]
        SmsResponse PingmePleasebySms(SmsRequest smsRequest);
    }
}
