using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Mission2015.Twilio.Apps
{
    public class TwilioResult : ActionResult
    {

        public XDocument Response { get; set; }

        public TwilioResult(XDocument response)
        {
            Response = response;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.HttpContext;

            httpContext.Response.ContentType = "text/xml";
            Response.Save(httpContext.Response.Output);
        }
    }
}