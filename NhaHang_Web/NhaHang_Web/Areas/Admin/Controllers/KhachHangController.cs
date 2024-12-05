using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;

namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        // GET: Admin/KhachHang
        public ActionResult DanhSachKH()
        {
            return View(db.KHACHHANG.ToList());
        }

        public ActionResult XoaKhachHang(int id = 0)
        {
            // Tìm khách hàng cần xóa
            KHACHHANG khachHang = db.KHACHHANG.Find(id);

            // Kiểm tra xem khách hàng có tồn tại không
            if (khachHang == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Kiểm tra xem có đơn hàng liên quan không
                if (khachHang.DONHANG != null && khachHang.DONHANG.Any())
                {
                    // Lặp qua từng đơn hàng và xóa chúng
                    foreach (var donHang in khachHang.DONHANG.ToList())
                    {
                        // Xóa chi tiết đơn hàng liên quan
                        foreach (var chiTietDonHang in donHang.CHITIETDONHANG.ToList())
                        {
                            db.CHITIETDONHANG.Remove(chiTietDonHang);
                        }

                        // Xóa đơn hàng
                        db.DONHANG.Remove(donHang);
                    }
                }

                if (khachHang.PHANHOI != null && khachHang.PHANHOI.Any())
                {
                    foreach (var phanHoi in khachHang.PHANHOI.ToList())
                    {
                        db.PHANHOI.Remove(phanHoi);
                    }
                }

                if (khachHang.DANHGIA != null && khachHang.DANHGIA.Any())
                {
                    foreach (var danhGia in khachHang.DANHGIA.ToList())
                    {
                        db.DANHGIA.Remove(danhGia);
                    }
                }

                if (khachHang.DATBAN != null && khachHang.DATBAN.Any())
                {
                    foreach (var datBan in khachHang.DATBAN.ToList())
                    {
                        db.DATBAN.Remove(datBan);
                    }
                }

                // Xóa khách hàng
                db.KHACHHANG.Remove(khachHang);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                return RedirectToAction("DanhSachKH", "KhachHang");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "KhachHang", "XoaKhachHang"));
            }
        }

        public ActionResult SuaKhachHang(int id = 0)
        {
            KHACHHANG kh = db.KHACHHANG.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }
            return View(kh);
        }

        [HttpPost]
        public ActionResult SuaKhachHang(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANG.Attach(kh);
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachKH", "KhachHang");
            }
            return View(kh);
        }

        public ActionResult ThemKhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemKhachHang(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANG.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DanhSachKH", "KhachHang");
            }
            return View(kh);
        }
    }
}