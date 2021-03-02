using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coachingSystem.Models;

namespace coachingSystem.Controllers
{
    public class subjectController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: subject
        public ActionResult Index()
        {
            return View(db.tbl_subject.ToList());
        }

        // GET: subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_subject tbl_subject = db.tbl_subject.Find(id);
            if (tbl_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_subject);
        }

        // GET: subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sub_id,sub_name")] tbl_subject tbl_subject)
        {
            if (ModelState.IsValid)
            {
                db.tbl_subject.Add(tbl_subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_subject);
        }

        // GET: subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_subject tbl_subject = db.tbl_subject.Find(id);
            if (tbl_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_subject);
        }

        // POST: subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sub_id,sub_name")] tbl_subject tbl_subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_subject);
        }

        // GET: subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_subject tbl_subject = db.tbl_subject.Find(id);
            if (tbl_subject == null)
            {
                return HttpNotFound();
            }
            return View(tbl_subject);
        }

        // POST: subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_subject tbl_subject = db.tbl_subject.Find(id);
            db.tbl_subject.Remove(tbl_subject);
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
