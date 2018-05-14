using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Dao;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class TacGiaController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: ChuDe
        public PartialViewResult TacGiaPartial()
        {
            var tg = db.TacGia.ToList();
            return PartialView(tg);
        }

        public ActionResult LocTheoTacGia(string id)
        {
            List<ThongTinSach> thongtin = new SachDao().listSach();

            //var e = from a in thongtin where a.TenTL == id select a;
            var t = thongtin.Where(x => x.MaTG == id);

            ViewBag.tg = thongtin.Where(s => s.MaTG == id).Select(x => x.TenTG).First();

            return View(t.ToList());
        }
    }
}