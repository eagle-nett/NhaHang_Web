using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;

namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        // GET: Admin/DanhMuc
        public ActionResult DanhMuc()
        {
            return View(db.LOAIMONAN.ToList());
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(LOAIMONAN lma)
        {
            if (ModelState.IsValid)
            {
                db.LOAIMONAN.Add(lma);
                db.SaveChanges();
                return RedirectToAction("DanhMuc", "DanhMuc");
            }
            return View(lma);
        }

        public ActionResult UpdateCategory(int id = 0)
        {
            LOAIMONAN lma = db.LOAIMONAN.Single(d => d.MALOAI == id);
            if (lma == null)
            {
                return HttpNotFound();
            }
            return View(lma);
        }
        [HttpPost]
        public ActionResult UpdateCategory(LOAIMONAN dept)
        {
            if (ModelState.IsValid)
            {
                db.LOAIMONAN.Attach(dept);
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMuc", "DanhMuc");
            }
            return View(dept);
        }
    }
}