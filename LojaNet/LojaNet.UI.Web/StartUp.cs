using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(LojaNet.UI.Web.StartUp))]

namespace LojaNet.UI.Web
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication
                (new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Usuario/Login")
                
            }
                );

        }
    }
}
