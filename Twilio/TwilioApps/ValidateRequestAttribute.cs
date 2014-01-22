using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Mission2015.Twilio.Apps
{
    public class ValidateRequestAttribute : ActionFilterAttribute
    {
        public string AuthToken { get; set; }

        public ValidateRequestAttribute(string authToken)
        {
            switch (authToken)
            {
                case "GETFROMCONFIG":
                    this.AuthToken = ConfigurationManager.AppSettings["AuthToken"];
                    break;
                default:
                    this.AuthToken = authToken;
                    break;
            }            
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = filterContext.HttpContext;

            if(context.Request.IsLocal )
            {
                return;
            }

            // Validate Request
            // Take the full URL of the request
            var value = new StringBuilder();

            var fullUrl = string.Format("http://{0}{1}", context.Request.Url.Host, context.Request.Url.PathAndQuery);

            value.Append(fullUrl);

            // If the request is POST, take all of the POST parameters and sort them alphabetically
            if(context.Request.HttpMethod == "POST")
            {
                // Iterate through the sorted list of POST parameters and append valiable name and value
                var sortedKeys = context.Request.Form.AllKeys.OrderBy(k => k, StringComparer.Ordinal).ToList();
                foreach (var key in sortedKeys)
                {
                    value.Append(key);
                    value.Append(context.Request.Form[key]);
                }
            }

            // Sign the resulting value with HMAC-SHA1 using your AuthToken as a key (remember, )
            var sha1 = new HMACSHA1(Encoding.UTF8.GetBytes(AuthToken));
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(value.ToString()));

            // Base64 encode the hash
            var encoded = Convert.ToBase64String(hash);

            //  Compare your hash to ours, submitted in the X-Twilio-Signature header. If they match then we are good to go

            var sig = context.Request.Headers["X-Twilio-Signature"];

            var invalid = sig != encoded;

            if (invalid )
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                filterContext.HttpContext.Response.SuppressContent = true;
                filterContext.HttpContext.ApplicationInstance.CompleteRequest();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}