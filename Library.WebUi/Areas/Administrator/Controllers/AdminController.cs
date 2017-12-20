using Library.Model;
using Library.WebUi.ToolBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Areas.Administrator.Controllers
{
    //[AuthorizeMember]
    public class AdminController : Controller
    {
        protected LibraryDBs ctx = new LibraryDBs();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            ctx.Categories.Add(category);
            ctx.SaveChanges();
            TempData["Message"] = "دسته جدید با موفقیت افزوده شد.";
            return RedirectToAction("Category_List");
        }
        public ActionResult EditCategory(int? id)
        {
            var c = ctx.Categories.Find(id);

            return View(c);
        }
        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            ctx.Entry<Category>(c).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();

            TempData["Message"] = "دسته موردنظر با موفقیت ویرایش شد";
            return RedirectToAction("Category_List");
        }
        public ActionResult DeleteCategory(int? id)
        {
            var c = ctx.Categories.Find(id);

            return View(c);
        }
        [HttpPost]
        [ActionName("DeleteCategory")]
        public ActionResult DeletedCategory(int? id)
        {
            ctx.Categories.Remove(ctx.Categories.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Category_List");
        }

        public ActionResult Category_List()
        {
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
            var Members = ctx.Members.ToList();
            return View(Members);
        }
        
        
        
        
    }
}