using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Dao;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class TheLoaiController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: TheLoai
        [ChildActionOnly]
        public PartialViewResult TheloaiPartial()
        {
            return PartialView(db.TheLoai.Take(5).ToList());
        }

        public ActionResult LocTheoTheLoai(string id)
        {
            List<ThongTinSach> thongtin = new SachDao().listSach();

            //var e = from a in thongtin where a.TenTL == id select a;
            var t = thongtin.Where(x => x.MaTL == id);

            if (t.ToList().Count == 0)
            {
                ViewBag.ThongBao = "Khong tim thay san pham nao";
                return View(thongtin);
            }

            ViewBag.tl = thongtin.Where(s => s.MaTL == id).Select(x => x.TenTL).First();

            return View(t.ToList());
        }

        public ActionResult TheloaiKhac()
        {
            return View(db.TheLoai.ToList());
        }
    }
}