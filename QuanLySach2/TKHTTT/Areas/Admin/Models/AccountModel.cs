using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TKHTTT.Models;

namespace TKHTTT.Areas.Admin.Models
{
    public class AccountModel
    {
        QuanLyNhaSachEntities db = new QuanLyNhaSachEntities();
        //Phần xử lý phân trang cho Books
        public IEnumerable<Sach> ListAllPage(int page, int rowLimit)
        {
            return db.Sach.OrderByDescending(x => x.TenSach).ToPagedList(page, rowLimit);
        }
    }
}