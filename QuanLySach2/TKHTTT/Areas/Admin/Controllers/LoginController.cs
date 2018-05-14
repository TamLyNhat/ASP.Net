using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TKHTTT.Areas.Admin.Models;
using Model;
using TKHTTT.Areas.Admin.Code;
using System.Web.Security;

namespace TKHTTT.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            //var result = new AccountModel().Login(model.MaNV, model.MatKhauNV);
            //if (result && ModelState.IsValid)
            //{
            //    //Nếu thành công chúng ta cần tạo session
            //    SessionHelper.SetSession(new UserSession(model.MaNV));
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Tên đăng nhập hoặc Password không đúng!");
            //}
            //return View(model);

            if (Membership.ValidateUser(model.MaNV, model.MatKhauNV) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.MaNV, model.Rememberme);
                return RedirectToAction("getListBook", "Book");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc Password không đúng!");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }


    }
}