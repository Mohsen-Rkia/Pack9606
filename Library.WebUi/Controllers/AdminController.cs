using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AddBooks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBooks(Books books)
        {
            LibraryDBs ctx = new LibraryDBs();
            ctx.Books.Add(books);
            ctx.SaveChanges();
            TempData["Message"] = "کتاب جدید با موفقیت افزوده شد.";
            return RedirectToAction("Books_List");
        }
        public ActionResult Books_List()
        {
            LibraryDBs ctx = new LibraryDBs();
            var Books = ctx.Books.ToList();
            return View(Books);
        }

        
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            LibraryDBs ctx = new LibraryDBs();
            ctx.Categories.Add(category);
            ctx.SaveChanges();
            TempData["Message"] = "دسته جدید با موفقیت افزوده شد.";
            return RedirectToAction("Category_List");
        }
        public ActionResult Category_List()
        {
            LibraryDBs ctx = new LibraryDBs();
            var Categories = ctx.Categories.ToList();
            return View(Categories);
        }
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            LibraryDBs ctx = new LibraryDBs();
            ctx.Members.Add(member);
            ctx.SaveChanges();
            TempData["Message"] = "کاربر جدید با موفقیت افزوده شد.";
            return RedirectToAction("Members_List");
        }
        public ActionResult Members_List()
        {
            LibraryDBs ctx = new LibraryDBs();
            var Members = ctx.Members.ToList();
            return View(Members);
        }

        public ActionResult Sirculation()
        {
            return View();
        }
        
        
    }
}