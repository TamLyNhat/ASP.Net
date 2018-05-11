﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Areas.Admin.Models;
using TKHTTT.Dao;
using TKHTTT.Models;

namespace TKHTTT.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: Admin/Book
        public ActionResult getListBook()
        {
            //Xử lý thao tác linq đơn giản
            var listBook = from s in db.Sach select s;
            return View(listBook);
        }

        //Thêm sách mới
        public ActionResult CreateBook()
        {

            List<SachMoi> moi = new NewBook().sm();

            ViewBag.m = new SelectList(moi, "So", "Chu");

            if (db.TheLoai.ToList() != null && db.NhaXuatBan.ToList() != null)
            {
                ViewBag.nxb = db.NhaXuatBan.ToList();
                ViewBag.tl = db.TheLoai.ToList();
            }
            else
            {
                ViewBag.orr = "loi";
            }

            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken] //Security help
        public ActionResult CreateBook(Sach book, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Upload file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Lưu đường dẫn file ảnh 
                    var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                    //Kiểm tra file đã tồn tại
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    //Them Sach Moi
                    book.HinhAnh = fileUpload.FileName;
                    db.Sach.Add(book);
                    db.SaveChanges();
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            //Cập nhật lại danh sách hiển thị
            var list = from s in db.Sach select s;
            return View("getListBook", list);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SachMoi> moi = new NewBook().sm();

            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }

            ViewBag.m = new SelectList(moi, "So", "Chu", sach.Moi);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL", sach.MaTL);

            return View(sach);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [ValidateInput(false)]
        public ActionResult Edit(HttpPostedFileBase fileUpload, [Bind(Include = "MaSach,MaTL,MaNXB,TenSach,TrangThai,GiaBia,HinhAnh,Moi")] Sach sach)
        {
            List<SachMoi> moi = new NewBook().sm();

            if (ModelState.IsValid)
            {
                //Upload file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn file ảnh 
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                //Kiểm tra file đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }

                //Them Sach Moi
                sach.HinhAnh = fileUpload.FileName;
                db.Sach.Add(sach);

                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("getListBook");
            }

            ViewBag.m = new SelectList(moi, "So", "Chu", sach.Moi);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL", sach.MaTL);

            return View(sach);
        }

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
    }
}