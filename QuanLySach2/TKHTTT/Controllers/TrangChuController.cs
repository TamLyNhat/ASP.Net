using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Dao;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class TrangChuController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();

        public ActionResult Index()
        {
            List<ThongTinSach> thongtin = new List<ThongTinSach>();

            var e = (from a in db.TacGia
                            join b in db.ChiTietSach on a.MaTG equals b.MaTG
                            join c in db.Sach on b.MaSach equals c.MaSach
                            join d in db.TheLoai on c.MaTL equals d.MaTL
                            select new ThongTinSach
                            {
                                MaSach = c.MaSach,
                                MaTL = d.MaTL,
                                TenSach = c.TenSach,
                                GiaBia = c.GiaBia,
                                HinhAnh = c.HinhAnh,
                                MaTG = b.MaTG,
                                TenTG = a.TenTG,
                                TenTL = d.TenTL
                            }).ToList();

            thongtin = e;
            return View(thongtin.Distinct().Take(3));
        }

    }
}