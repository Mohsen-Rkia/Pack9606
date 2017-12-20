using Library.Model;
using Library.WebUi.Areas.Administrator.ViewModels;
using Library.WebUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Areas.Administrator.Controllers
{
    public class AddCirculationsController : Controller
    {
        protected LibraryDBs ctx = new LibraryDBs();
        // GET: AddCirculations
        public ActionResult Index()
        {
            ViewBag.MemberId = new SelectList(ctx.Members, "Id", "UserName");
            ViewBag.BookId = new SelectList(ctx.Books, "Id", "Title");


            return View();
        }

        [HttpPost]
        public ActionResult Index(AddCirculationViewModels circulate)
        {
            if (ModelState.IsValid)
            {
                var c = new Circulation()
                {
                    MemberId = circulate.MemberId,
                    Issue_Date = circulate.Issue_Date,
                    Day_Number = circulate.Day_Number,
                    BookId = circulate.BookId,
                    Expire_Date = circulate.Issue_Date.AddDays(circulate.Day_Number)
                };

                ctx.Circulations.Add(c);
                ctx.SaveChanges();
                TempData["Message"] = "گردش مورد نظر با موفقیت اضافه شد";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "اطلاعات وارد شده صحیح نمی باشد";
            return View();

        }
        public ActionResult CirculationsHome()
        {
            var Circulate = ctx.Circulations.ToList();
            
            return View(Circulate);
        }
        public ActionResult Edit(int? id)
        {
            var c = ctx.Circulations.Find(id);

            return View(c);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit(Circulation cr)
        {
            ctx.Entry<Circulation>(cr).State = System.Data.Entity.EntityState.Modified;
            
            ctx.SaveChanges();

            TempData["Message"] = "گردش با موفقیت ویرایش شد";
            return RedirectToAction("CirculationsHome", "AddCirculations");
        }
        public ActionResult Delete(int? id)
        {
            var c = ctx.Circulations.Find(id);

            return View(c);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleted(int? id)
        {
            ctx.Circulations.Remove(ctx.Circulations.Find(id));
            ctx.SaveChanges();
            return View();
        }
    }
}