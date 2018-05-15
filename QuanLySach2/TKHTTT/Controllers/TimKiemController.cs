using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Models;
using PagedList.Mvc;
using PagedList;
using TKHTTT.Dao;
using TKHTTT.Areas.Admin.Models;

namespace TKHTTT.Controllers
{
    public class TimKiemController : Controller
    {

        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string y = f["txtTimKiem"].ToString();
            //tra ve 1 list co dinh tu khoa
            List<Sach> kqtk = db.Sach.Where(x => x.TenSach.Contains(y)).ToList();

            List<ThongTinSach> thongtin = new SachDao().listSach();

            var e = (from a in thongtin
                     join b in kqtk on a.TenSach equals b.TenSach
                     select a).ToList();

            if(kqtk.Count == 0)
            {
                ViewBag.ThongBao = "Khong tim thay san pham nao";
                return View(thongtin.OrderBy(n => n.TenSach));
            }
       
            return View(e.OrderBy(n =>n.TenSach));
        }
    }
}