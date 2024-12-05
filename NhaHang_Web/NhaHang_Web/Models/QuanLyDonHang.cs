using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaHang_Web.Models
{
    public class QuanLyDonHang
    {
        public int MaDonHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public string TinhTrangThanhToan { get; set; }
        public int TinhTrangGiaoHang { get; set; }
        public float TongTien { get; set; }
    }
}