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
    public class ContactUsController : Controller
    {
        private LibraryDBs db = new LibraryDBs();

        // GET: ContactUs
        public ActionResult Index()
        {
            return View(db.ContactUss.ToList());
        }

        // GET: ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.ContactUss.Add(contactUs);
                db.SaveChanges();
                TempData["Message"] = "پیام شما با موفقیت برای مدیر سایت ارسال شد";
                return RedirectToAction("Create");
            }

            return View(contactUs);
        }

        // GET: ContactUs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ContactUs contactUs = db.ContactUss.Find(id);
        //    if (contactUs == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contactUs);
        //}

        //// POST: ContactUs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,EmailAddress,Name,Subject,MsgText")] ContactUs contactUs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(contactUs).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(contactUs);
        //}

        //// GET: ContactUs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ContactUs contactUs = db.ContactUss.Find(id);
        //    if (contactUs == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contactUs);
        //}

        //// POST: ContactUs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ContactUs contactUs = db.ContactUss.Find(id);
        //    db.ContactUss.Remove(contactUs);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
