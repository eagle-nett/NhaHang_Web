using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhaHang_Web.Areas.BienTapVien.Controllers
{
    public class HomeBienTapVienController : Controller
    {
        // GET: BienTapVien/HomeBienTapVien
        public ActionResult Index()
        {
            return View();
        }
    }
}