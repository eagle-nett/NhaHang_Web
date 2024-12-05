using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;
using System.Web.Http.Results;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;

namespace NhaHang_Web.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        public static string connectionString = "Data Source=asus;Initial Catalog=NHAHANG_DOANWEB;Integrated Security=True;Encrypt=False";
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        // GET: Admin/DonHang
        public ActionResult DanhSachDH()
        {
            return View(db.DONHANG.ToList());
        }

        public ActionResult XemChiTietDonHang(int maDH)
        {
            List<XemChiTietDonHang> ctdhs = new List<XemChiTietDonHang>();
            string query = "EXEC SP_XemChiTietMonAn @maDH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maDH", maDH);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            XemChiTietDonHang ctdh = new XemChiTietDonHang
                            {

                                TENMONAN = reader["TENMONAN"].ToString(),
                                SOLUONG = Convert.ToInt32(reader["SOLUONG"]),
                                DONGIA = float.Parse(reader["DONGIA"].ToString()),
                            };
                            ctdhs.Add(ctdh);
                        }
                    }
                }
            }
            return View(ctdhs);
        }

        public ActionResult ThongTinDatHang(int maDH)
        {
            ThongTinDonHang thongTinDonHang = null;

            string query = "EXEC SP_XemChiTietDonHang @maDH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@maDH", maDH);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            thongTinDonHang = new ThongTinDonHang
                            {
                                MADH = Convert.ToInt32(reader["MADH"]),
                                TENKHACHHANG = reader["TENKH"].ToString(),
                                SDT = reader["SDT"].ToString(),
                                NGAYDATHANG = Convert.ToDateTime(reader["NGAYDATHANG"].ToString()),
                                NGAYGIAOHANG = Convert.ToDateTime(reader["NGAYGIAOHANG"].ToString()),
                                TINHTRANGTHANHTOAN = reader["TINHTRANGTHANHTOAN"].ToString(),
                                TINHTRANGGIAOHANG = Convert.ToInt32(reader["TINHTRANGGIAOHANG"].ToString())
                            };
                        }

                    }
                }
            }

            return View(thongTinDonHang);
        }


        public ActionResult XoaDonHang(int id = 0)
        {
            // Tìm đơn hàng cần xóa
            DONHANG dh = db.DONHANG.Find(id);

            // Kiểm tra xem đơn hàng có tồn tại không
            if (dh == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Kiểm tra xem có chi tiết đơn hàng liên quan không
                if (dh.CHITIETDONHANG != null && dh.CHITIETDONHANG.Any())
                {
                    // Lặp qua từng chi tiết đơn hàng và xóa chúng
                    foreach (var ctdh in dh.CHITIETDONHANG.ToList())
                    {
                        db.CHITIETDONHANG.Remove(ctdh);
                    }
                }

                // Xóa đơn hàng
                db.DONHANG.Remove(dh);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                return RedirectToAction("DanhSachDH", "DonHang");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "DonHang", "XoaDonHang"));
            }
        }

        public ActionResult SuaDonHang(int id = 0)
        {
            DONHANG dh = db.DONHANG.Find(id);
            ViewBag.MAKH = new SelectList(db.KHACHHANG, "MAKH", "TENKH");
            if (dh == null)
            {
                return HttpNotFound();
            }
            return View(dh);
        }

        [HttpPost]
        public ActionResult SuaDonHang(DONHANG dh)
        {
            if (ModelState.IsValid)
            {
                db.DONHANG.Attach(dh);
                db.Entry(dh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachDH", "DonHang");
            }
            return View(dh);
        }
    }
}