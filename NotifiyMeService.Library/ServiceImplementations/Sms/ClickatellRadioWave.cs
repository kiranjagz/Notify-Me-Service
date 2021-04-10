using NotifiyMeService.Library.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifiyMeService.Library.Models;
using System.Net;
using NotifiyMeService.Library.Helpers;
using System.IO;

namespace NotifiyMeService.Library.ServiceImplementations.Sms
{
    public class ClickatellRadioWave : INotifybyRadioWaveSms
    {
        public RadioWaveSmsResponse SendSms(RadioWaveSmsRequest radioWaveRequest)
        {
            RadioWaveSmsResponse radioWaveResponse = new RadioWaveSmsResponse();
            string streamResponse;

            try
            {
                var smsSettings = Settings.DeliverSmsSettings();

                using (WebClient client = new WebClient())
                {
                    client.QueryString.Add("api_id", smsSettings.ApiId);
                    client.QueryString.Add("user", smsSettings.Username);
                    client.QueryString.Add("password", smsSettings.Password);
                    client.QueryString.Add("to", radioWaveRequest.MobileNumber);
                    client.QueryString.Add("text", radioWaveRequest.Message);

                    using (var data = client.OpenRead("http://api.clickatell.com/http/sendmsg"))
                    {
                        using (var reader = new StreamReader(data))
                        {
                            streamResponse = reader.ReadToEnd();

                            if (streamResponse.Contains("ID"))
                            {
                                radioWaveResponse.Success = true;
                                radioWaveResponse.Message = "Sms submitted to Clickatell successfully. " + streamResponse;
                                radioWaveResponse.ApiMessageId = streamResponse.Split(':')[1].Trim();
                                radioWaveResponse.SubmittedDateTime = DateTime.Now;
                                radioWaveResponse.MobileNumber = radioWaveRequest.MobileNumber;
                                radioWaveResponse.TextMessage = radioWaveRequest.Message;
                            }
                            else if (streamResponse.Contains("ERR"))
                            {
                                radioWaveResponse.Success = false;
                                radioWaveResponse.Message = "An error has occurred: " + streamResponse;
                                radioWaveResponse.ApiMessageId = null;
                                radioWaveResponse.SubmittedDateTime = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                radioWaveResponse.Success = false;
                radioWaveResponse.Message = "An error has occurred: " + ex.Message;
                radioWaveResponse.ApiMessageId = null;
                radioWaveResponse.SubmittedDateTime = null;
            }

            return radioWaveResponse;
        }
    }
}
