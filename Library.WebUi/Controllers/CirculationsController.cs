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
    public class CirculationsController : Controller
    {
        private LibraryDBs db = new LibraryDBs();

        // GET: Circulations
        public ActionResult Index()
        {
            var circulations = db.Circulations.Include(c => c.Member_I);
            return View(circulations.ToList());
        }

        // GET: Circulations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulations circulations = db.Circulations.Find(id);
            if (circulations == null)
            {
                return HttpNotFound();
            }
            return View(circulations);
        }

        // GET: Circulations/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            return View();
        }

        // POST: Circulations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,BooksId,Issue_Date,Expire_Date,Return_Date")] Circulations circulations)
        {
            if (ModelState.IsValid)
            {
                db.Circulations.Add(circulations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", circulations.MemberId);
            return View(circulations);
        }

        // GET: Circulations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulations circulations = db.Circulations.Find(id);
            if (circulations == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", circulations.MemberId);
            return View(circulations);
        }

        // POST: Circulations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,BooksId,Issue_Date,Expire_Date,Return_Date")] Circulations circulations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circulations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", circulations.MemberId);
            return View(circulations);
        }

        // GET: Circulations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulations circulations = db.Circulations.Find(id);
            if (circulations == null)
            {
                return HttpNotFound();
            }
            return View(circulations);
        }

        // POST: Circulations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circulations circulations = db.Circulations.Find(id);
            db.Circulations.Remove(circulations);
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
