using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using NhaHang_Web.Models;

namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        //GET: Admin/SanPham
        public ActionResult XemSanPhamTheoLocAdmin(int? giaMin, int? giaMax, string sapXep, string txt_search = "")
        {
            giaMin = giaMin ?? int.MinValue;
            giaMax = giaMax ?? int.MaxValue;

            var sp = db.SapXepMenu(giaMin, giaMax, sapXep).Where(x => x.TENMONAN.ToLower().Contains(txt_search) || txt_search == null).ToList();
            return View(sp);
        }

        public ActionResult Create()
        {
            ViewBag.Maloai = new SelectList(db.LOAIMONAN, "MALOAI", "TENLOAI");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MONAN newFoodItem, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lưu file hình ảnh vào máy chủ
                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        // Tạo tên file duy nhất cho hình ảnh
                        string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                        string fileExtension = Path.GetExtension(imageFile.FileName);
                        string uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{fileExtension}";

                        // Đặt đường dẫn để lưu file trên máy chủ
                        string path = Server.MapPath("~/ImageMenu");
                        string fullPath = Path.Combine(path, uniqueFileName);

                        // Lưu file hình ảnh vào máy chủ
                        imageFile.SaveAs(fullPath);

                        // Cập nhật thuộc tính HINHANH của newFoodItem với tên file
                        newFoodItem.HINHANH = uniqueFileName;
                    }

                    // Thêm newFoodItem vào DbSet MONANs
                    db.MONAN.Add(newFoodItem);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    return RedirectToAction("XemSanPhamTheoLocAdmin", "SanPham"); // Chuyển hướng đến action mong muốn sau khi thêm thành công
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi thêm món ăn mới: " + ex.Message);
                }
            }

            return View(newFoodItem);
        }

        public ActionResult Edit(int id)
        {
            MONAN ma = db.MONAN.Find(id);
            ViewBag.Maloai = new SelectList(db.LOAIMONAN, "MALOAI", "TENLOAI");
            if (ma == null)
            {
                return HttpNotFound();
            }
            return View(ma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MONAN newFoodItem, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lưu file hình ảnh vào máy chủ
                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        // Tạo tên file duy nhất cho hình ảnh
                        string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                        string fileExtension = Path.GetExtension(imageFile.FileName);
                        string uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{fileExtension}";

                        // Đặt đường dẫn để lưu file trên máy chủ
                        string path = Server.MapPath("~/ImageMenu");
                        string fullPath = Path.Combine(path, uniqueFileName);

                        // Lưu file hình ảnh vào máy chủ
                        imageFile.SaveAs(fullPath);

                        // Cập nhật thuộc tính HINHANH của newFoodItem với tên file
                        newFoodItem.HINHANH = uniqueFileName;
                    }

                    // Thêm newFoodItem vào DbSet MONANs

                    db.MONAN.Attach(newFoodItem);
                    db.Entry(newFoodItem).State = System.Data.Entity.EntityState.Modified;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    return RedirectToAction("XemSanPhamTheoLocAdmin", "SanPham"); // Chuyển hướng đến action mong muốn sau khi thêm thành công
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi thêm món ăn mới: " + ex.Message);
                }
            }

            return View(newFoodItem);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var monAnToDelete = db.MONAN.Find(id);

                if (monAnToDelete != null)
                {
                    // Lấy đường dẫn tuyệt đối của tệp hình ảnh
                    string imagePath = Path.Combine(Server.MapPath("~/ImageMenu/"), monAnToDelete.HINHANH);

                    // Kiểm tra xem tệp tồn tại trước khi xóa
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Xóa tệp hình ảnh từ máy chủ
                        System.IO.File.Delete(imagePath);
                    }

                    // Xóa sản phẩm từ cơ sở dữ liệu
                    db.MONAN.Remove(monAnToDelete);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Sản phẩm và hình ảnh đã được xóa thành công." });
                }

                return Json(new { success = false, message = "Không tìm thấy sản phẩm." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }


        public ActionResult MonAn_Loai()
        {
            var listLoai = db.LOAIMONAN.Include("MONANS").ToList();
            return View(listLoai);
        }


        

    }
}