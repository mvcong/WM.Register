using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WM.Register.MD5;
using WM.Register.Models;
using WM.Register.ServerMail;

namespace WM.Register.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //[Authorize]
        public ActionResult Login(srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant, string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var logined = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[Login] @email, @Password", new SqlParameter("email", srv_VNOGateWay_Merchant.merchant_email), new SqlParameter("Password", Common.MD5Hash(srv_VNOGateWay_Merchant.password))).FirstOrDefault();
                    if (logined != null)
                    {
                        FormsAuthentication.SetAuthCookie(srv_VNOGateWay_Merchant.merchant_email, false);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, srv_VNOGateWay_Merchant.merchant_email, DateTime.Now, DateTime.Now.AddMinutes(30), false, JsonConvert.SerializeObject(logined));
                        string encryptForm = FormsAuthentication.Encrypt(ticket);
                        HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptForm);
                        Response.Cookies.Add(httpCookie);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }

                        return Json(srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                //return Json(srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet);
            }
            return Json(srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ChangePass()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangePass(string newPass, string oldPass/*, srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant*/)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Common.MD5Hash(oldPass) == ((User as WebIPrincipal).User.password))
                {
                    var change = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[ChangePasswordMerchant] @id, @NewPassword, @OldPass", new SqlParameter("id", (User as WebIPrincipal).User.id), new SqlParameter("NewPassword", Common.MD5Hash(newPass)), new SqlParameter("OldPass", Common.MD5Hash(oldPass))).FirstOrDefault();
                    FormsAuthentication.SignOut();
                    return Json(new { result = 1 });
                }
                else
                {
                    return Json("Wrong Password", JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string merchant_email)
        {
            //gui link kem tocken den mail cua merchant
            //generate tocken theo email
            long time = DateTime.Now.AddMinutes(10).Ticks;
            string To = merchant_email, FromEmail, Password, SMTPPort, Host;
            string token = (merchant_email + " " + time.ToString() + " " + Common.ComputeSha256Hash((merchant_email + " " + time.ToString() + " " + "webmoney.com.vn")));
            var lnkHref = "<a href='" + Url.Action("ResetPassword", "Login", new { email = merchant_email, time = time, code = token }, "http") + "'>Reset Password</a>";
            string subject = "Your changed password";
            string body = "Dear" + " " + merchant_email + "," + "<br><br><br> Please click on the link to change your password. <br> Your link:" + lnkHref + " <br><br><br>Sincerely,<br>Administrator<br><i>Note: This is an auto-generated email, please do not reply.</i>";
            EmailManager.AppSettings(out FromEmail, out Password, out SMTPPort, out Host);
            EmailManager.SendEmail(FromEmail, subject, body, To, FromEmail, Password, SMTPPort, Host);
            return Json(new { message = "Chúng tôi đã gửi link về mail của quý khách, vui lòng kiểm tra mail.", status = true });
        }
        public ActionResult ResetPassword(string code, string email, long time)
        {
            string tokenconfirm = (email + " " + time.ToString() + " " + Common.ComputeSha256Hash((email + " " + time.ToString() + " " + "webmoney.com.vn")));
            //so sanh voi tocken duoc gui o email
            //hien thi form 
            if (code == tokenconfirm && time >= DateTime.Now.Ticks)
            {
                srv_VNOGateWay_Merchant model = new srv_VNOGateWay_Merchant();
                //model.code = code;
                model.merchant_email = email;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
            
        }
        [HttpPost]
        public ActionResult ResetPassword(string email, string confirm)
        {
            if(email != null)
            {
                var rest = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[sp_forgotpassword] @forgotpass, @email", new SqlParameter("forgotpass", Common.MD5Hash(confirm)), new SqlParameter("email", email)).FirstOrDefault();
                //thuc hien change pass va luu xuong data voi pass moi
                return Json(new { message = "Password has been changed, Login with new password.", status = true });
            }
            else
            {
                return Json(new { message = "Password not change.", status = true });
            }
            
        }
    }
}