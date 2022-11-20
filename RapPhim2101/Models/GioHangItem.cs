using RapPhim2101.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RapPhim2101.Models
{
    public class GioHangItem
    {
        DBContext db = new DBContext();
        public int MaPhim { get; set; }
        public int MaPhong { get; set; }
        public DateTime SuatChieu { get; set; }
        public string Ghe { get; set; }
        public int SoLuong { get; set; }
        public double dthanhtien
        {
            get { return SoLuong * 60000; }
        }
        public GioHangItem(int id)
        {
            MaPhim = id;
            ChiTietPhong phong = db.ChiTietPhongs.Single(n => n.MaPhim == id);
            MaPhong = phong.MaPhong;
            SuatChieu = (DateTime)phong.SuatChieu;
            Ghe = "";
            SoLuong = 1;
            
        }
    }
}