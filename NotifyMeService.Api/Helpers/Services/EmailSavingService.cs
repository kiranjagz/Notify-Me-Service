using Newtonsoft.Json;
using NotifyMeService.Api.Helpers.Common;
using NotifyMeService.Api.Helpers.DatabaseRepository;
using NotifyMeService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Api.Helpers.Services
{
    public class EmailSavingService
    {
        private readonly ICommon _commonUtility;
        private readonly IRepo _databaseRepo;
        private EmailRequest _emailRequest;
        private EmailResponse _emailResponse;

        public EmailSavingService(ICommon commonUtility, IRepo databaseRepo, EmailRequest emailRequest, EmailResponse emailResponse)
        {
            _commonUtility = commonUtility;
            _databaseRepo = databaseRepo;
            _emailRequest = emailRequest;
            _emailResponse = emailResponse;
        }

        public bool SavingtoSQLDatabase()
        {
            bool hasSaved = true;

            var jsonRequest = JsonConvert.SerializeObject(_emailRequest);
            var jsonResponse = JsonConvert.SerializeObject(_emailResponse);
            var request = _commonUtility.SerializeObject(_emailRequest);
            var response = _commonUtility.SerializeObject(_emailResponse);

            bool savedToDatabase = _databaseRepo.SaveaSomethingAwesome(request, response, 1, 2);

            if (!savedToDatabase)
                hasSaved = false;

            return hasSaved;
        }
    }
}