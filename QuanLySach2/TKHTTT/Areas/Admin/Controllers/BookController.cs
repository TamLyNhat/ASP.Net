using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
            return View("Index");

        }

        //Hiển thị chi tiết
        public ActionResult Details(string id)
        {
            //if (a.Equals(""))
            //{
            //    return HttpNotFound();
            //}

            ////Bao gồm tất cả danh sách  chapter của book theo id chỉ định
            //var viewModel = db.Sach.Include(w => w.TheLoai).SingleOrDefault(s => s.MaTL == a);
            //if (viewModel == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(viewModel);

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