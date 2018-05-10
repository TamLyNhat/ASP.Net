using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TKHTTT.Areas.Admin.Code
{
    [Serializable] //Tự động hoá nhị phân
    public class UserSession
    {
        private string MaNV { set; get; }
        public UserSession(string MaNV)
        {
            this.MaNV = MaNV;
        }

    }

}