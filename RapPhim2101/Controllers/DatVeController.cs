using RapPhim2101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapPhim2101.Controllers
{
    public class DatVeController : Controller
    {
        // GET: DatVe
        private DBContext db = new DBContext();
        public ActionResult TrangDatVe(int id)
        {
            /*List<GioHangItem> lstgiohang = Laygiohang();
            GioHangItem product = lstgiohang.Find(n => n.MaPhim == id);*/
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Home");
            }
            return View(phim);
        }
        public ActionResult test()
        {
            List<GioHangItem> lstgiohang = Laygiohang();
            if (lstgiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(lstgiohang);
        }
        public List<GioHangItem> Laygiohang()
        {
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            if (lstgiohang == null)
            {
                lstgiohang = new List<GioHangItem>();
                Session["GioHang"] = lstgiohang;
            }
            return lstgiohang;
        }
        public ActionResult Themgiohang(int MaPhim,string ghe, string strURL)
        {
            List<GioHangItem> lstgiohang = Laygiohang();
            GioHangItem product = lstgiohang.Find(n => n.MaPhim == MaPhim);
            var site = ghe;
            if (product == null)
            {
                product = new GioHangItem(MaPhim);
                product.Ghe = site;
                lstgiohang.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.Ghe= product.Ghe + ", "+ site;
                product.SoLuong += 1;
                lstgiohang.Add(product);
                return Redirect(strURL);
            }
        }
        [HttpGet]
        public ActionResult Datve(int? id)
        {
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            GioHangItem gh = lstgiohang.Find(n => n.MaPhim == id);
            

            return View(gh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Datve(int id)
        {
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            var session = (KhachHang)Session["TaiKhoan"];
            GioHangItem gh = lstgiohang.Find(n => n.MaPhim == id);
            Ve ve = new Ve();
            ve.MaPhim = gh.MaPhim;
            ve.MaPhong = gh.MaPhong;
            db.Ves.Add(ve);
            db.SaveChanges();
            Hoadon hd = new Hoadon();
            hd.MaKH = session.MaKH;
            hd.TongTien = gh.dthanhtien;
            hd.MaNV = 1;
            db.Hoadons.Add(hd);
            db.SaveChanges();
            foreach (var item in db.Hoadons.ToList())
            {
                foreach(var v in db.Ves.ToList()) {
                    ChiTietHD cthd = new ChiTietHD();
                    cthd.MaHD = item.MaHD;
                    cthd.MaVe = v.MaVe;
                    cthd.MaUD = 1;
                    cthd.MaDV = 1;
                    cthd.Ghe = gh.Ghe;
                    cthd.SoLuong = gh.SoLuong;
                    cthd.NgayBanVe= DateTime.Now;
                    db.ChiTietHDs.Add(cthd);
                    
                }
            }
            db.SaveChanges();
            return RedirectToAction("index", "home");
        }
        /*private double Tongtien()
        {
            double total = 0;
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            if (lstgiohang != null)
            {
                total = lstgiohang.Sum(n => n.dthanhtien);
            }
            return total;
        }*/
    }
}