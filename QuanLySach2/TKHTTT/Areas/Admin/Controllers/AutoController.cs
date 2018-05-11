using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Areas.Admin.Models;
using TKHTTT.Models;

namespace TKHTTT.Areas.Admin.Controllers
{
    public class AutoController : Controller
    {
        private QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();

        // GET: Admin/Auto
        public ActionResult Index()
        {
            var sach = db.Sach.Include(s => s.NhaXuatBan).Include(s => s.TheLoai);
            return View(sach.ToList());
        }

        // GET: Admin/Auto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/Auto/Create
        public ActionResult Create()
        {
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB");
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL");
            return View();
        }

        // POST: Admin/Auto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaTL,MaNXB,TenSach,TrangThai,GiaBia,HinhAnh,Moi")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Sach.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // GET: Admin/Auto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SachMoi> moi = new List<SachMoi>();
            SachMoi sm;

            sm = new SachMoi();
            sm.So = 1;
            sm.Chu = "Mới";
            moi.Add(sm);

            sm = new SachMoi();
            sm.So = 0;
            sm.Chu = "Cũ";
            moi.Add(sm);

            ViewBag.m = new SelectList(moi, "So", "Chu");

            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // POST: Admin/Auto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaTL,MaNXB,TenSach,TrangThai,GiaBia,HinhAnh,Moi")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }

        // GET: Admin/Auto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Sach.Find(id);
            db.Sach.Remove(sach);
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
