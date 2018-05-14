using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class SachMoiController : Controller
    {
        // GET: Sach

        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        
        [ChildActionOnly]
        public PartialViewResult SachMoiPartial()
        {
            var listSachMoi = db.Sach.Where(x => x.Moi == 1).Take(3).ToList();
            return PartialView(listSachMoi);
        }

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