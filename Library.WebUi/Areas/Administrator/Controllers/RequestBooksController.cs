using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Model;

namespace Library.WebUi.Controllers
{
    public class RequestBooksController : Controller
    {
        private LibraryDBs db = new LibraryDBs();

        // GET: RequestBooks
        public ActionResult Index()
        {
            var requestBooks = db.RequestBooks.Include(r => r.Member);
            return View(requestBooks.ToList());
        }

        // GET: RequestBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestBook requestBook = db.RequestBooks.Find(id);
            if (requestBook == null)
            {
                return HttpNotFound();
            }
            return View(requestBook);
        }

        // GET: RequestBooks/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.MemberId = new SelectList(db.Members, "Id", "UserName");
                return View();
                
            }
            TempData["Message"] = "جهت درخواست کتاب ابتدا باید وارد شوید";
            return RedirectToAction("Login", "Login");

        }

        // POST: RequestBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestBook requestBook)
        {
            if (ModelState.IsValid)
            {
                db.RequestBooks.Add(requestBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.MemberId = new SelectList(db.Members, "Id", "UserName", requestBook.MemberId);
            return View(requestBook);
        }

        // GET: RequestBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestBook requestBook = db.RequestBooks.Find(id);
            if (requestBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", requestBook.MemberId);
            return View(requestBook);
        }

        // POST: RequestBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,BookTitleRQ,AuthorBookRQ,PublisherBookRQ,RequestDate,Note")] RequestBook requestBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", requestBook.MemberId);
            return View(requestBook);
        }

        // GET: RequestBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestBook requestBook = db.RequestBooks.Find(id);
            if (requestBook == null)
            {
                return HttpNotFound();
            }
            return View(requestBook);
        }

        // POST: RequestBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestBook requestBook = db.RequestBooks.Find(id);
            db.RequestBooks.Remove(requestBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
