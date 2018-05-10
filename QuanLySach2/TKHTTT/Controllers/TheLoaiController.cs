using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Models;

namespace TKHTTT.Controllers
{
    public class TheLoaiController : Controller
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: TheLoai
        public PartialViewResult TheloaiPartial()
        {
            return PartialView(db.TheLoai.Take(5).ToList());
        }
    }
}