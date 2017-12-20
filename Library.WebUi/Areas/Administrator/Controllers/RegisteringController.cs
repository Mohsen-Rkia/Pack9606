using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Areas.Administrator.Controllers
{
    public class RegisteringController : Controller
    {
        protected LibraryDBs ctx = new LibraryDBs();

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
        public ActionResult Edit(int? id)
        {
            var m = ctx.Members.Find(id);

            return View(m);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit(Member m)
        {
            ctx.Entry<Member>(m).State = System.Data.Entity.EntityState.Modified;
            if (!string.IsNullOrEmpty(m.PasswordHash))
                ctx.Entry<Member>(m).Property("PasswordHash").IsModified = false;
                ctx.SaveChanges();

            TempData["Message"] = "کاربر با موفقیت ویرایش شد";
            return RedirectToAction("Members_List", "Admin");
        }


        public ActionResult Delete(int? id)
        {
            var m = ctx.Members.Find(id);

            return View(m);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleted(int? id)
        {
            ctx.Members.Remove(ctx.Members.Find(id));
            ctx.SaveChanges();
            return View();
        }



    }
}