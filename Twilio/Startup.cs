using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twilio.Startup))]
namespace Twilio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
