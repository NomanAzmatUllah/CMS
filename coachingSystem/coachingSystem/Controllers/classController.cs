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
    public class classController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: class
        public ActionResult Index()
        {
            return View(db.tbl_class.ToList());
        }

        // GET: class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_class tbl_class = db.tbl_class.Find(id);
            if (tbl_class == null)
            {
                return HttpNotFound();
            }
            return View(tbl_class);
        }

        // GET: class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "class_id,class_name")] tbl_class tbl_class)
        {
            if (ModelState.IsValid)
            {
                db.tbl_class.Add(tbl_class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_class);
        }

        // GET: class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_class tbl_class = db.tbl_class.Find(id);
            if (tbl_class == null)
            {
                return HttpNotFound();
            }
            return View(tbl_class);
        }

        // POST: class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "class_id,class_name")] tbl_class tbl_class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_class);
        }

        // GET: class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_class tbl_class = db.tbl_class.Find(id);
            if (tbl_class == null)
            {
                return HttpNotFound();
            }
            return View(tbl_class);
        }

        // POST: class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_class tbl_class = db.tbl_class.Find(id);
            db.tbl_class.Remove(tbl_class);
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
