using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaHang_Web.Models;
namespace NhaHang_Web.Controllers
{
    public class DatBanController : Controller
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        // GET: DatBan
        public ActionResult DatBan()
        {
            DatBanModel model = new DatBanModel();

            // Populate the list of available tables and set it to ViewBag.DanhSachBan
            ViewBag.DanhSachBan = db.BANAN.Where(b => b.TRANGTHAI == "Trống").ToList();

            // Add a default item to the beginning of the list
            ViewBag.DanhSachBan.Insert(0, new BANAN { TENBA = "-- Chọn bàn --" });

            model.DanhSachMonAn = db.MONAN.Select(m => new MonAnModel
            {
                MaMonAn = m.MAMONAN,
                TenMonAn = m.TENMONAN,
                HinhAnh = m.HINHANH,
                Gia = (int)m.GIA,
                SoLuong = 0
            }).ToList();

            // Set the default selected value for TenBan if available
            var availableTables = ViewBag.DanhSachBan as List<BANAN>;
            if (availableTables != null && availableTables.Any())
            {
                model.TenBan = availableTables.First().TENBA;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult DatBan(DatBanModel model)
        {
            if (ModelState.IsValid)
            {
                var bookingReport = new DatBanModel
                {
                    HoTen = model.HoTen,
                    SoDienThoai = model.SoDienThoai,
                    NgayDat = model.NgayDat,
                    GioDat = model.GioDat,
                    TenBan = model.TenBan,
                    SoLuongKhach = model.SoLuongKhach,
                    DanhSachMonAn = new List<MonAnModel>(),

                };

                // Calculate total for each selected dish
                foreach (var selectedMonAn in model.DanhSachMonAn.Where(m => m.SoLuong != 0))
                {
                    var monAn = db.MONAN.Find(selectedMonAn.MaMonAn);
                    var thanhTien = selectedMonAn.SoLuong * monAn.GIA;

                    bookingReport.DanhSachMonAn.Add(new MonAnModel
                    {
                        MaMonAn = selectedMonAn.MaMonAn,
                        TenMonAn = monAn.TENMONAN,
                        HinhAnh = monAn.HINHANH,
                        Gia = (int)monAn.GIA,
                        SoLuong = selectedMonAn.SoLuong,
                        ThanhTien = (int)thanhTien

                    });
                }

                // Pass the booking report model to the view
                return View("ThongTinDB", bookingReport);
            }

            // If ModelState is not valid, return to the reservation page with the entered information
            model.DanhSachMonAn = db.MONAN.Select(m => new MonAnModel
            {
                MaMonAn = m.MAMONAN,
                TenMonAn = m.TENMONAN,
                HinhAnh = m.HINHANH,
                Gia = (int)m.GIA,
                SoLuong = 0
            }).ToList();

            ViewBag.DanhSachBan = db.BANAN.Where(b => b.TRANGTHAI == "Trống").ToList();

            return View("DatBan", model);
        }


        public ActionResult ThongTinDB()
        {

            return View();
        }

        public ActionResult ThanhToan()
        {
            return View();
        }
    }
}