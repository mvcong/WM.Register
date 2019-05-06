using System;
using System.Security.Principal;
using System.Web.Security;
using WM.Register.Models;

namespace WM.Register
{
    public class WebIPrincipal : IPrincipal
    {

        public WebIPrincipal(IIdentity Identity)
        {
            this.Identity = Identity;
        }
        public srv_VNOGateWay_Merchant User { get; set; }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

    }
}