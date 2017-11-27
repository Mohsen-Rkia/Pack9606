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
        // GET: Admin
        public ActionResult Index()
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
            return RedirectToAction("AddBooks");
        }

        public ActionResult Category_List()
        {
            LibraryDBs ctx = new LibraryDBs();
            var Categories = ctx.Categories.ToList();
            return View(Categories);
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
            return RedirectToAction("AddCategory");
        }

        public ActionResult Members_List()
        {
            LibraryDBs ctx = new LibraryDBs();
            var Members = ctx.Members.ToList();
            return View(Members);
        }
    }
}