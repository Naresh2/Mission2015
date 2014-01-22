using Mission2015.Twilio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twilio.Controllers
{
    public class HomeController : TwilioController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Incoming()
        {

            return new ContentResult
            {
                Content = "",
                ContentType = "text/xml"
            };
        }
    }
}