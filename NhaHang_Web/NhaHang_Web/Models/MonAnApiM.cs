using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaHang_Web.Models
{
    public class MonAnApiM
    {
        public int mamonan;

        public string tenmonan;

        public int gia;

        public string mota;

        public string hinhanh;

        public int maloai;

        public MonAnApiM()
        {

        }
        public MonAnApiM(MONAN ma)
        {
            mamonan = ma.MAMONAN;
            tenmonan = ma.TENMONAN;
            gia = (int)ma.GIA;
            mota = ma.MOTA;
            hinhanh = ma.HINHANH;
            maloai = ma.MALOAI;
        }
    }
}