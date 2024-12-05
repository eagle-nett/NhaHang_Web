using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;

namespace NhaHang_Web.Controllers
{
    public class GioHangController : Controller
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        // GET: GioHang

        public ActionResult Index()
        {
            return View();
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGH = Session["GioHang"] as List<GioHang>;
            if (listGH == null)
            {
                listGH = new List<GioHang>();
                Session["GioHang"] = listGH;
            }
            return listGH;
        }

        public ActionResult ThemGioHang(int mamonan, string strURL)
        {
            List<GioHang> listGH = LayGioHang();
            GioHang sanpham = listGH.Find(sp => sp.Mamonan == mamonan);
            if (sanpham == null)
            {
                sanpham = new GioHang(mamonan);
                listGH.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.SoLuong++;
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.SoLuong);
            }
            return tsl;

        }

        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> listGH = Session["GioHang"] as List<GioHang>;
            if (listGH != null)
            {
                ttt += listGH.Sum(sp => sp.Thanhtien);
            }
            return ttt;
        }

        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                ViewBag.TB = "Giỏ hàng trống!";
            }
            List<GioHang> listGH = LayGioHang();

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return View(listGH);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return PartialView();
        }

        public ActionResult XoaGioHang(int Mamonan)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.Mamonan == Mamonan);
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.Mamonan == Mamonan);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Home", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult XoaTatCa(int Mamonan)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.Mamonan == Mamonan);
            if (sp != null)
            {
                lstGioHang.Clear();
                return RedirectToAction("Home", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }


        public ActionResult CapNhatGioHang(int maMonAn, FormCollection f)
        {
            List<GioHang> listGH = LayGioHang();
            GioHang sp = listGH.Single(s => s.Mamonan == maMonAn);
            if (sp != null)
            {
                sp.SoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }


        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "Account");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("MenuLoaiMonAn", "Menu");
            }
            List<GioHang> listGH = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return View(listGH);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            DONHANG dh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            dh.MAKH = kh.MAKH;
            dh.NGAYDATHANG = DateTime.Now;
            
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", f["NgayGiao"]);
            dh.NGAYGIAOHANG = DateTime.Parse(ngaygiao);
            dh.TINHTRANGGIAOHANG = 0; 
            dh.TINHTRANGTHANHTOAN = "Đã thanh toán";
            db.DONHANG.Add(dh);
            db.SaveChanges();

            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();

                ctdh.MADH = dh.MADH;
                ctdh.MAMONAN = item.Mamonan;
                ctdh.SOLUONG = item.SoLuong;
                ctdh.DONGIA = item.Dongia;
                db.CHITIETDONHANG.Add(ctdh);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Index", "GioHang");
        }
    }
}