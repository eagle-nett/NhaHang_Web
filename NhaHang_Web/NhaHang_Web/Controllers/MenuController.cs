using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;
namespace NhaHang_Web.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        public ActionResult MenuSearch(string txt_search = " ")
        {
            List<MONAN> search = db.MONAN.Where(row => row.TENMONAN.Contains(txt_search)).ToList();
            ViewBag.Search = search;
            return View(search);
        }
        public ActionResult MenuLoaiMonAn()
        {
            List<LOAIMONAN> lma = db.LOAIMONAN.OrderBy(l => l.TENLOAI).ToList();
            return View(lma);
        }
        public ActionResult MenuNoiBat()
        {
            List<MONAN> ma = db.MONAN.Take(12).ToList();
            return View(ma);    
        }

        public ActionResult MenuTatCaCacLoai(int page = 1)
        {
            var menu = db.MONAN.ToList();
            //Page
            int NoOfRecordPerPage = 12;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(menu.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPage = NoOfPage;
            menu = menu.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(menu);

        }
        public ActionResult MenuTheoLoai(int malma)
        {
            var ma = (db.MONAN.Where(cd => cd.MALOAI == malma).ToList());
            return View(ma);
        }
        public ActionResult XemChiTiet(int ms)
        {
            return View(db.MONAN.Where(ma => ma.MAMONAN == ms).ToList());
        }

        public ActionResult XemSanPhamTheoLoc(int? giaMin, int? giaMax, string sapXep)
        {
            // Default values if giaMin or giaMax is null
            giaMin = giaMin ?? int.MinValue;
            giaMax = giaMax ?? int.MaxValue;

            var sp = db.SapXepMenu(giaMin, giaMax, sapXep).ToList();
            return View(sp);
        }

    }
}