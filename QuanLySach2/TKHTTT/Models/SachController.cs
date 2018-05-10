using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class SachController : Controller
    {
        BookEnties db = new BookEnties();
        // GET: Sach
        public ActionResult Index()
        {
            //var Detail = from a in db.TacGia
            //             from b in db.Sach
            //             select new
            //             {
            //                 MaTG = a.MaTG,
            //                 MaSach = b.MaSach
            //             };

            var model = from a in db.TacGia
                        join b in db.ChiTietSach
                        join c in db.Sach
                        join d in db.TacGia
                        on a.MaTG equals 
            return View();
        }
    }
}