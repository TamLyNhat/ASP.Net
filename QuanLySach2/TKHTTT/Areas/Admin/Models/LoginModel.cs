using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TKHTTT.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string MaNV { set; get; }
        public string MatKhauNV { set; get; }
        public bool Rememberme { set; get; }

    }
}