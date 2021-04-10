using Newtonsoft.Json;
using NotifiyMeService.Library.Models;
using NotifiyMeService.Library.ServiceImplementations.Email;
using NotifiyMeService.Library.ServiceInterfaces;
using NotifyMeService.Api.Factories;
using NotifyMeService.Api.Filters;
using NotifyMeService.Api.Helpers.Common;
using NotifyMeService.Api.Helpers.DatabaseRepository;
using NotifyMeService.Api.Helpers.Services;
using NotifyMeService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotifyMeService.Api.Controllers
{
    //[RequireHttps]
    public class EmailController : ApiController
    {
        private INotifybyPigeon _emailProvider;
        private ICommon _commonProvider;
        private IRepo _databaseRepoProvider;
        private EmailSavingService _emailSavingService;

        public EmailController()
        {
            // emailProvider = new AOutlookPigeonExpress();
        }

        public EmailController(INotifybyPigeon emailProvider, ICommon commonProvider, IRepo databaseRepoProvider)
        {
            _emailProvider = emailProvider;
            _commonProvider = commonProvider;
            _databaseRepoProvider = databaseRepoProvider;
        }

        // GET: api/Email
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Email/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Email
        public IHttpActionResult Post(EmailRequest emailRequest)
        {
            try
            {
                //Build the request model for the service to send the email
                PigeonRequest pigeonRequest = EmailFactory.CreatePigeonRequest(emailRequest);
                PigeonResponse pigeonResponse = _emailProvider.SendAFitPigeon(pigeonRequest);

                if (pigeonResponse.Success)
                {
                    //Create the Api response for the successful post request
                    EmailResponse emailResponse = EmailFactory.CreateEmailResponse(pigeonResponse);

                    //Save to database if the email is sent successfully
                    _emailSavingService = new EmailSavingService(_commonProvider, _databaseRepoProvider,
                        emailRequest, emailResponse);

                    //request = CommonUtility.SerializeObject(emailRequest);
                    //response = CommonUtility.SerializeObject(emailResponse);
                    //var isSaved = databaseStuff.SaveaSomethingAwesome(request, response, 1, 2);

                    return Ok(emailResponse);
                }
                else
                {
                    return BadRequest("Response was not a success: " + pigeonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }
    }
}
