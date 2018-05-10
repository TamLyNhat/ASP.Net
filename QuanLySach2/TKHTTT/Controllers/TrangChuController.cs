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
       

        public ActionResult Index()
        {
            var thongtin = new SachDao().listSach();

           return View(thongtin.Take(3));
        }

    }
}