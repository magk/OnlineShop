using OnlineShop.Areas.Admin.Code;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = new AccountModel().Login(model.UserName, model.Password);
                if (result)
                {
                    SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            else
            {
                ModelState.AddModelError("", "Nhập thiếu thông tin");
            }
            return View(model);
        }
    }
}