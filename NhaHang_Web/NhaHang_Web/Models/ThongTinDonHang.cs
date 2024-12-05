using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaHang_Web.Models
{
    public class ThongTinDonHang
    {
        public int MADH { get; set; }
        public string TENKHACHHANG { get; set; }
        public string SDT { get; set; }
        public DateTime NGAYDATHANG { get; set; }
        public DateTime NGAYGIAOHANG { get; set; }
        public string TINHTRANGTHANHTOAN { get; set; }
        public int TINHTRANGGIAOHANG { get; set; }
    }
}