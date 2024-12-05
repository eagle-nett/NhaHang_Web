using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class BaoLoiController : Controller
    {
        // GET: Admin/BaoLoi
        public ActionResult KhongCoQuyen()
        {
            return View();
        }
    }
}