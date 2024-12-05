using NhaHang_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NhaHang_Web.Controllers
{
    public class AccountController : Controller
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        // GET: Account
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG khachHang)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản đã tồn tại chưa
                bool isTaiKhoanExisted = db.KHACHHANG.Any(kh => kh.TAIKHOAN == khachHang.TAIKHOAN);

                if (isTaiKhoanExisted)
                {
                    //ModelState.AddModelError("CustomError", "Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.");
                    ViewBag.Error = "Tài khoản đã tồn tại. Vui lòng điền tài khoản khác";
                    return View(khachHang);
                }
                else
                {
                    KHACHHANG newKhachHang = new KHACHHANG
                    {
                        TENKH = khachHang.TENKH,
                        NGAYSINH = khachHang.NGAYSINH,
                        SDT = khachHang.SDT,
                        TAIKHOAN = khachHang.TAIKHOAN,
                        MATKHAU = khachHang.MATKHAU,
                        DIACHI = khachHang.DIACHI,
                    };
                    db.KHACHHANG.Add(newKhachHang);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap", "Account");
                }
            }
            else
            {
                ModelState.AddModelError("CustomError", "Có lỗi xảy ra. Vui lòng kiểm tra lại thông tin của bạn.");
                return View(khachHang);
            }
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                KHACHHANG taiKhoan = db.KHACHHANG.SingleOrDefault(u => u.TAIKHOAN == tk.TAIKHOAN && u.MATKHAU == tk.MATKHAU);

                if (taiKhoan != null)
                {
                    //KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
                    Session["TaiKhoan"] = taiKhoan;
                    //Session["MaKhachHang"] = taiKhoan.MAKH;
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("CustomError", "Có lỗi xảy ra. Vui lòng kiểm tra lại thông tin của bạn.");

                return View();
            }

        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Home", "Home");
        }
    
}
}