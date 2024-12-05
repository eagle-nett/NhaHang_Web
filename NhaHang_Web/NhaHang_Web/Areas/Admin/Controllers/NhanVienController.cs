using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;


namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        public bool ktraChucNang(int idchucnang)
        {
            NHANVIEN nv = (NHANVIEN)Session["user"];
            var count = db.PHANQUYEN.Count(m => m.MANV == nv.MANV && m.IDCHUCNANG == idchucnang);
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // GET: Admin/NhanVien
        [AdminAuthorize(idChucNang = 1)]        
        
        public ActionResult DanhSachNhanVien()
        {
  
            return View(db.NHANVIEN.ToList());
        }
        //[AdminAuthorize(idChucNang = 2)]

        //public ActionResult ThemMoi()
        //{
        //    return View();
        //}
        //[AdminAuthorize(idChucNang = 3)]

        //public ActionResult CapNhat()
        //{
        //    return View();
        //}
        //[AdminAuthorize(idChucNang = 4)]

        //public ActionResult Xoa()
        //{
        //    return View();
        //}

        public ActionResult XoaNhanVien(int id = 0)
        {
            // Tìm nhân viên cần xóa
            NHANVIEN nhanVien = db.NHANVIEN.Find(id);

            // Kiểm tra xem khách hàng có tồn tại không
            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Kiểm tra xem có đơn hàng liên quan không
                if (nhanVien.HOADON != null && nhanVien.HOADON.Any())
                {
                    // Lặp qua từng đơn hàng và xóa chúng
                    foreach (var hoaDon in nhanVien.HOADON.ToList())
                    {                        
                        db.HOADON.Remove(hoaDon);
                    }
                }

                if (nhanVien.PHANQUYEN != null && nhanVien.PHANQUYEN.Any())
                {
                    foreach (var phanQuyen in nhanVien.PHANQUYEN.ToList())
                    {
                        db.PHANQUYEN.Remove(phanQuyen);
                    }
                }
                

                                // Xóa khách hàng
                db.NHANVIEN.Remove(nhanVien);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                return RedirectToAction("DanhSachNhanVien", "NhanVien");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "NhanVien", "XoaNhanVien"));
            }
        }

        public ActionResult SuaNhanVien(int id = 0)
        {
            NHANVIEN nv = db.NHANVIEN.Find(id);
            if (nv == null)
            {
                return HttpNotFound();
            }
            return View(nv);
        }

        [HttpPost]
        public ActionResult SuaNhanVien(NHANVIEN nv)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIEN.Attach(nv);
                db.Entry(nv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachNhanVien", "NhanVien");
            }
            return View(nv);
        }

        public ActionResult ThemNhanVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNhanVien(NHANVIEN nv)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIEN.Add(nv);
                db.SaveChanges();
                return RedirectToAction("DanhSachNhanVien", "NhanVien");
            }
            return View(nv);
        }
    }
}