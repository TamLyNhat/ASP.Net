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

            List<ThongTinSach> thongtin = new SachDao().listSach();

             var e = (from a in thongtin 
                     join b in db.TheLoai on a.MaTL equals b.MaTL
                     select a.TenTL).Distinct();
                        
            return View(e.ToList());
                    
        }

    }
}