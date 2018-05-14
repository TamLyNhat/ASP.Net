using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class ChiTietSachController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: ChiTietSach
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