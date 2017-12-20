using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Areas.Administrator.Controllers
{
    public class AdministratorHomeController : Controller
    {
        // GET: Administrator/AdministratorHome
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            TempData["Message"] = "جهت ورود به پنل ادمین ابتدا باید وارد سایت شوید";
            return RedirectToAction("Login", "Login", new { area = "" });
        }
    }
}