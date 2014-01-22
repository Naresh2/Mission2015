using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mission2015.Twilio.Apps;
using System.Xml.Linq;

namespace Mission2015.Twilio.Controllers
{
    //[ValidateRequest("GETFROMCONFIG")]
    public class TwilioController : Controller
    {
        #region Public Properties
        public string CallSid { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string AccountSid { get; set; }
        public string CallStatus { get; set; }
        public string FromCity { get; set; }
        public string FromState { get; set; }
        public string FromZip { get; set; }
        public string FromCountry { get; set; }
        public string ToCity { get; set; }
        public string ToState { get; set; }
        public string ToZip { get; set; }
        public string ToCountry { get; set; }
        public string Digits { get; set; }
        public string SmsSid { get; set; }
        public string Body { get; set; }
        #endregion

        public  TwilioResult TwiML (XDocument response)
        {
            return new TwilioResult(response);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CallSid = filterContext.HttpContext.Request.Params["CallSid"];
            To = filterContext.HttpContext.Request.Params["To"];
            From = filterContext.HttpContext.Request.Params["From"];
            AccountSid = filterContext.HttpContext.Request.Params["AccountSid"];
            CallStatus = filterContext.HttpContext.Request.Params["CallStatus"];
            FromCity = filterContext.HttpContext.Request.Params["FromCity"];
            FromState = filterContext.HttpContext.Request.Params["FromState"];
            FromZip = filterContext.HttpContext.Request.Params["FromZip"];
            FromCountry = filterContext.HttpContext.Request.Params["FromCountry"];
            ToCity = filterContext.HttpContext.Request.Params["ToCity"];
            ToState = filterContext.HttpContext.Request.Params["ToState"];
            ToZip = filterContext.HttpContext.Request.Params["ToZip"];
            ToCountry = filterContext.HttpContext.Request.Params["ToCountry"];
            Digits = filterContext.HttpContext.Request.Params["Digits"];
            SmsSid = filterContext.HttpContext.Request.Params["SmsSid"];
            Body = filterContext.HttpContext.Request.Params["Body"];

            base.OnActionExecuting(filterContext);
        }
	}
}