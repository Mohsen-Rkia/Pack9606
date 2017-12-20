using AutoMapper;
using Library.Model;
using Library.WebUi.Areas.Administrator.ViewModels;
using Library.WebUi.ToolBox;
using Library.WebUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Areas.Administrator.Controllers
{
    //[AuthorizeMember]
    public class AddBookController : Controller
    {
        protected LibraryDBs ctx = new LibraryDBs();
        // GET: AddBook
        public ActionResult AddBook()
        {
            ViewBag.CategoryId = new SelectList(ctx.Categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult AddBook(AddBooksViewModels addBooks)
        {
            var guid = Guid.NewGuid().ToString();
            var CoverFileInfo = addBooks.CoverFile;
            var CoverSize = CoverFileInfo.ContentLength;
            var CoverType = CoverFileInfo.ContentType;
            var CoverFileName = guid + Path.GetExtension(CoverFileInfo.FileName);
            if (CoverSize > 200 * 1024)
            {
                ModelState.AddModelError(nameof(addBooks.CoverFile), "سایز فایل باید کمتر از 200 کیلوبایت باشد");
            }
            if (CoverType != "image/gif" && CoverType != "image/jpeg" && CoverType != "image/png")
            {
                ModelState.AddModelError(nameof(addBooks.CoverFile), "فایل ارسالی باید از نوع عکس باشد");
            }
           



            if (ModelState.IsValid)
            {
                CoverFileInfo.SaveAs(Path.Combine(Server.MapPath("~/image/Covers/") , CoverFileName));
                var b = new Book()
                {
                    Title = addBooks.Title,
                    Author = addBooks.Author,
                    Publisher = addBooks.Publisher,
                    CategoryId = addBooks.CategoryId,
                    EditionYear = addBooks.EditionYear,
                    Series = addBooks.Series,
                    PublisherCallNumber = addBooks.PublisherCallNumber,
                    NumberOfPage = addBooks.NumberOfPage,
                    Isbn = addBooks.Isbn,
                    Notes = addBooks.Notes,
                    Status = addBooks.Status.ToString(),
                    AddDate = addBooks.AddDate,
                    Cover = "/image/Covers/" + CoverFileName
                };

                ctx.Books.Add(b);
                ctx.SaveChanges();

                TempData["Message"] = "کتاب مورد نظر با موفقیت اضافه شد";
                return RedirectToAction("Books_List");
            }

            return View();
            
        }

        public ActionResult Books_List()
        {
            var book = ctx.Books.ToList();
            return View(book);
        }
        public ActionResult Edit(int? id)
        {
            var book = ctx.Books.Find(id);

            var model = new AddBooksViewModels()
            {
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                CategoryId = book.CategoryId,
                EditionYear = book.EditionYear
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(AddBooksViewModels b)
        {
            Book db = ctx.Books.Find(b.Id);
            db.Title = b.Title;
            db.Publisher = b.Publisher;
            db.Author = b.Author;
            db.CategoryId = b.CategoryId;
            db.EditionYear = b.EditionYear;
            ctx.SaveChanges();
            return RedirectToAction("Books_List");
        }

        public ActionResult Delete (int? id)
        {
            var book = ctx.Books.Find(id);

            var model = new AddBooksViewModels()
            {
                Title = book.Title,
            };
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleted(int? id)
        {
            ctx.Books.Remove(ctx.Books.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Books_List");
        }
    }
}