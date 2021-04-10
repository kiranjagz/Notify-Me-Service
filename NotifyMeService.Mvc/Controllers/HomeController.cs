using NotifiyMeService.Library.ServiceInterfaces;
using NotifyMeService.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotifyMeService.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IXMLtoObject xmltoObject;

        public HomeController()
        {

        }

        public HomeController(IXMLtoObject _xmltoObject)
        {
            xmltoObject = _xmltoObject;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //GET: BuildEmailTrail
        public JsonResult BuildEmailTrail()
        {
            RetrieveEmailResponsesHelper helper = new RetrieveEmailResponsesHelper(xmltoObject);

            var emailsFromService = helper.RetrieveSomeEmails();

            return Json(emailsFromService.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}