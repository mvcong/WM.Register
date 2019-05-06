using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WM.Register.DAO;
using WM.Register.MD5;
using WM.Register.Models;
using PagedList;

namespace WM.Register.Controllers
{
    public class RegisterController : Controller
    {
        [Authorize]
        // GET: Register
        public ActionResult Index(int? page)
        {
           
            if (page == null) page = 1;            
            var srv_VNOGateWay_Merchants = (from l in StoreProceduce.ListAllMerchant()
                                            select l).OrderBy(x => x.id);

            //var links = new DB().Database.SqlQuery<int>("select * from dbo.srv_VNOGateWay_Merchant").ToList();

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            var list = StoreProceduce.ListAllMerchant();       
            return View(list.ToPagedList(pageNumber, pageSize));
        }        
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(HttpPostedFileBase file, srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant)
        {
            if (ModelState.IsValid)
            {
                string filename = null;
                if (file == null)
                {
                    srv_VNOGateWay_Merchant.logo = "";
                    StoreProceduce.InsertMerchant(srv_VNOGateWay_Merchant);
                    return Json(new { srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet });
                }
                else
                {                    
                    filename = file.FileName;
                    string filePathMerchant = Server.MapPath("~/Content/Uploads/Merchant");                    
                    string savedFileName = Path.Combine(filePathMerchant, filename);
                    file.SaveAs(savedFileName);
                    srv_VNOGateWay_Merchant.logo = filename;
                }
                StoreProceduce.InsertMerchant(srv_VNOGateWay_Merchant);
                return Json(new { srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet }); 
            }           
            return Json(new { srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet });
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var getById=StoreProceduce.GetMerchantById(id);           
            if (getById == null)
            {
                return HttpNotFound();
            }
            return View(getById);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(HttpPostedFileBase file, srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {                   
                    string filename = null;
                    if (file == null)
                    {                                               
                        srv_VNOGateWay_Merchant.updated_by = (User as WebIPrincipal).User.id;
                        StoreProceduce.UpdateMerchantWhenLogoNull(srv_VNOGateWay_Merchant);
                        return Json(new { srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet });
                    }
                    else
                    {                        
                        filename = file.FileName;
                        string filePathMerchant = Server.MapPath("~/Content/Uploads/Merchant");                        
                        string savedFileName = Path.Combine(filePathMerchant, filename);
                        file.SaveAs(savedFileName);
                        //file.SaveAs(Server.MapPath("~/Content/Uploads/Merchant" + filename));
                        srv_VNOGateWay_Merchant.logo = filename;
                    }                   
                    srv_VNOGateWay_Merchant.updated_by = (User as WebIPrincipal).User.id;
                    StoreProceduce.UpdateMerchant(srv_VNOGateWay_Merchant);
                    return Json(new { srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet });
                }
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return Json(new { srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet });
        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var getById = StoreProceduce.GetMerchantById(id);           
            if (getById == null)
            {
                return HttpNotFound();
            }
            return View(getById);
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var getById = StoreProceduce.GetMerchantById(id); 
            if(getById == null)           
            {
                return HttpNotFound();
            }
            return View(getById);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int? id, srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant)
        {
            if (id != null)
            {
                var delete = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[Deletesrv_VNOGateWay_Merchant_ById] @Id = " + id).FirstOrDefault();
            }
            else
            {
                return HttpNotFound();
            }
            return Json(srv_VNOGateWay_Merchant, JsonRequestBehavior.AllowGet);
        }

    }
}