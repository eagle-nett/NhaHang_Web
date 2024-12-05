using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NhaHang_Web.Models
{
    public class GioHang
    {
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();

        int mamonan;
        public int Mamonan
        {
            get { return mamonan; }
            set { mamonan = value; }
        }

        string tenmonan;

        public string Tenmonan
        {
            get { return tenmonan; }
            set { tenmonan = value; }
        }

        string anhbia;

        public string Anhbia
        {
            get { return anhbia; }
            set { anhbia = value; }
        }

        int soluong;

        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        float dongia;

        public float Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        float thanhtien;

        public float Thanhtien
        {
            get { return SoLuong * dongia; }
            set { thanhtien = value; }
        }

        public GioHang(int maMonan)
        {
            mamonan = maMonan;
            MONAN Monan = db.MONAN.Single(sp => sp.MAMONAN == maMonan);
            Tenmonan = Monan.TENMONAN;
            Anhbia = Monan.HINHANH;
            Dongia = float.Parse(Monan.GIA.ToString());
            SoLuong = 1;
        }

    }
}