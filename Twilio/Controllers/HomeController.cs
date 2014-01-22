using Mission2015.Twilio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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
            var doc = new XDocument();

            var response = new XElement("Response");
            var gather = new XElement("Gathter",
                    new XAttribute("action", Url.Action("Input")),
                    new XElement("Say", "Thank you for calling. Please enter your policy number followed by pound key.")
                );
            response.Add(gather);
            doc.Add(response);

            return TwiML(doc);
        }

        public ActionResult Input()
        {
            var doc = new XDocument();

            var response = new XElement("Response");
            var gather = new XElement("Say", string.Format("We are sorry. The policy number {0} is not found ", Digits));
            response.Add(gather);
            doc.Add(response);

            return TwiML(doc);
        }
    }
}