using RapPhim2101.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RapPhim2101.Areas.Admin.Controllers
{
    public class OderController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/Oder
        public ActionResult Index()
        {
            return View(db.ChiTietHDs.ToList());
        }
        // GET: Admin/CTHDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // GET: Admin/CTHDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CTHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVe,MaHD,MaDV,MaUD,Ghe,NgayBanVe,SoLuong")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHDs.Add(chiTietHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiTietHD);
        }

        // GET: Admin/ChitietHDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // POST: Admin/CTHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVe,MaHD,MaDV,MaUD,Ghe,NgayBanVe,SoLuong")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiTietHD);
        }

        // GET: Admin/CTHDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // POST: Admin/CTHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            db.ChiTietHDs.Remove(chiTietHD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}