using System;
using System.Collections.Generic;
using System.Linq;
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

        public PartialViewResult SachMoiPartial()
        {
            var listSachMoi = db.Sach.Where(x => x.Moi == 1).Take(3).ToList();
            return PartialView(listSachMoi);
        }

    }
}