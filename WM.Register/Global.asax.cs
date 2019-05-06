using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using WM.Register.Models;

namespace WM.Register
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                var serializer = new JavaScriptSerializer();
                srv_VNOGateWay_Merchant webUser =  serializer.Deserialize<srv_VNOGateWay_Merchant>(ticket.UserData);
                if (ticket != null && !ticket.Expired)
                {
                    WebIPrincipal webIPrincipal = new WebIPrincipal(new FormsIdentity(ticket));
                    webIPrincipal.User = webUser;
                    HttpContext.Current.User = webIPrincipal;
                }
            }
        }
        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
        }
        //public srv_VNOGateWay_Merchant CurrentUser
        //{
        //    get
        //    {
        //        if (HttpContext.Current.User != null)
        //        {
        //            return HttpContext.Current.User as srv_VNOGateWay_Merchant;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
