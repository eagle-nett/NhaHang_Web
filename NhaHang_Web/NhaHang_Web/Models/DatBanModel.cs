using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace NhaHang_Web.Models
{
    public class DatBanModel
    {
        [Required(ErrorMessage = "Họ tên không được trống")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được trống")]
        public string SoDienThoai { get; set; }


        [Required(ErrorMessage = "Ngày đặt không được trống")]
        [DataType(DataType.Date)]
        public DateTime NgayDat { get; set; }

        [Required(ErrorMessage = "Giờ đặt không được trống")]
        [DataType(DataType.Time)]
        public DateTime GioDat { get; set; }


        [Required(ErrorMessage = "Bàn không được trống")]
        public string TenBan { get; set; }


        [Required(ErrorMessage = "Số lượng khách không được trống")]
        //[Range(1, 5, ErrorMessage = "Số lượng khách phải từ 1 đến 5")]
        public int SoLuongKhach { get; set; }

        public List<MonAnModel> DanhSachMonAn { get; set; }
    }

}