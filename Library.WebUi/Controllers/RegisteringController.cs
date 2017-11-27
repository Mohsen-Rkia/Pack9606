using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Controllers
{
    public class RegisteringController : Controller
    {
        // GET: Registering
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
            {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Member member)
        {
            LibraryDBs ctx = new LibraryDBs();
            ctx.Members.Add(member);
            ctx.SaveChanges();

            TempData["Message"] = "کاربر جدید با موفقیت افزوده شد.";
            return RedirectToAction("Register");

        }
        
    }
}