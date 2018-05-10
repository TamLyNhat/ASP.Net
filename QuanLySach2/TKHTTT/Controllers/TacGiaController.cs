using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class TacGiaController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: ChuDe
        public PartialViewResult TacGiaPartial()
        {
            var tg = db.TacGia.Take(5).ToList();
            return PartialView(tg);
        }
    }
}