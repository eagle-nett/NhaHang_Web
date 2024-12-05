using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaHang_Web.Models
{
    public class GioHangModel
    {
        NHAHANG_DOANWEBEntities nh = new NHAHANG_DOANWEBEntities();
        public int id { get; set; }
        public string nameMA { get; set; }
        public string anhMA { get; set; }
        public double donGia { get; set; }
        public int soLuong { get; set; }
        public double thanhTien
        {
            get { return soLuong * donGia; }
        }
        public GioHangModel(int MAMONAN)
        {
            id = MAMONAN;
            MONAN ma = nh.MONAN.Single(a => a.MAMONAN == id);
            nameMA = ma.TENMONAN;
            anhMA = ma.HINHANH;
            donGia = double.Parse(ma.GIA.ToString());
            soLuong = 1;
        }
    }
}