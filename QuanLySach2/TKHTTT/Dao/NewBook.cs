using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TKHTTT.Areas.Admin.Models;

namespace TKHTTT.Dao
{
    public class NewBook
    {
        public List<SachMoi> sm()
        {
            List<SachMoi> moi = new List<SachMoi>();
            SachMoi sm;

            sm = new SachMoi();
            sm.So = 1;
            sm.Chu = "Mới";
            moi.Add(sm);

            sm = new SachMoi();
            sm.So = 0;
            sm.Chu = "Cũ";
            moi.Add(sm);

            return moi;
        }
    }
}