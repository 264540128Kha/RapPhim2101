using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RapPhim2101.Models;

namespace RapPhim2101.Areas.Admin.Controllers
{
    public class LoaiVeController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/LoaiVe
        public ActionResult Index()
        {
            return View(db.LoaiVes.ToList());
        }

        // GET: Admin/LoaiVes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            if (loaiVe == null)
            {
                return HttpNotFound();
            }
            return View(loaiVe);
        }

        // GET: Admin/LoaiVes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiVes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLV, TenLV, DonGia")] LoaiVe loaiVe)
        {
            if (ModelState.IsValid)
            {
                db.LoaiVes.Add(loaiVe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiVe);
        }

        // GET: Admin/KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            if (loaiVe == null)
            {
                return HttpNotFound();
            }
            return View(loaiVe);
        }

        // POST: Admin/LoaiVes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLV, TenLV, DonGia")] LoaiVe loaiVe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiVe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiVe);
        }

        // GET: Admin/LoaiVes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            if (loaiVe == null)
            {
                return HttpNotFound();
            }
            return View(loaiVe);
        }

        // POST: Admin/LoaiVes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiVe loaiVe = db.LoaiVes.Find(id);
            db.LoaiVes.Remove(loaiVe);
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

 