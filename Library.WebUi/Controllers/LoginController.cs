using Library.Model;
using Library.Model.Toolsbox;
using Library.WebUi.ToolBox;
using Library.WebUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Controllers
{
    public class LoginController : Controller
    {
        protected LibraryDBs ctx = new LibraryDBs();
        public ActionResult Login()
        {
            if (AuthenticateFunction.GetcurrentMember() != null)
            {
                return RedirectToAction("Index" , "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ForLoginViewModels LoginVM)
        {
            if (ModelState.IsValid)
            {
                var PasswordHash = UserHelper.CalculateMD5Hash(LoginVM.Password);
                var currentUser = ctx.Members.Where(m => m.UserName == LoginVM.UserName && m.PasswordHash == PasswordHash)
                    .FirstOrDefault();
                if (currentUser != null)
                {
                    if (LoginVM.Rememberme)
                    {
                        HttpCookie cookie = new HttpCookie("UserId", currentUser.Id.ToString());
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);
                    }
                    Session["UserId"] = currentUser.Id;
                    TempData["Message"] = $"{currentUser.Name} {currentUser.LastName} عزیز به سایت کتابخانه ایرانیان خوش آمدید";
                    return RedirectToAction("Index", "Home");
                }
                TempData["Message"] = "نام کاربری یا کلمه عبور وارد شده صحیح نمی باشد.";
                return View();
            }

            TempData["Message"] = "اطلاعات کاربری به درستی وارد نشده است.";
            return View();
        }
        public ActionResult Logout()
        {
            AuthenticateFunction.Logout();
            return RedirectToAction("Login");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}