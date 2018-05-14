using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Dao;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class SachTheoTheLoaiController : Controller
    {
        // GET: SachTheoTheLoai
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();

        [ChildActionOnly]
        public PartialViewResult SachTheoTheLoaiPartial(string id)
        {

            List<ThongTinSach> thongtin = new SachDao().listSach();

            var e = from a in thongtin where a.TenTL == id select a;

            return PartialView(e.Take(3).ToList());
        }
    }
}