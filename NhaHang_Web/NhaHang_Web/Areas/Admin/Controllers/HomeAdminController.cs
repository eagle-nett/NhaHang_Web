using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NhaHang_Web.Models;

namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }    
            else
            {
                return View();
            }
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
            var taikhoan = db.NHANVIEN.SingleOrDefault(d=>d.USERNAME.ToLower() == user.ToLower() && d.PASSWORD == password);

            if(taikhoan != null)
            {
                Session["user"] = taikhoan;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
        }
        public ActionResult DangXuat()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }
    }
}