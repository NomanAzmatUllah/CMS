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
    public class timetablesController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: timetables
        public ActionResult Index()
        {
            var timetables = db.timetables.Include(t => t.tbl_class).Include(t => t.tbl_faculty_details).Include(t => t.tbl_subject);
            return View(timetables.ToList());
        }

        // GET: timetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timetable timetable = db.timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: timetables/Create
        public ActionResult Create()
        {
            ViewBag.class_id_fk = new SelectList(db.tbl_class, "class_id", "class_name");
            ViewBag.faculty_id_fk = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name");
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name");
            return View();
        }

        // POST: timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "timetable_id,class_id_fk,faculty_id_fk,suubject_fk_id,date_time,dayss")] timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.timetables.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.class_id_fk = new SelectList(db.tbl_class, "class_id", "class_name", timetable.class_id_fk);
            ViewBag.faculty_id_fk = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name", timetable.faculty_id_fk);
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name", timetable.suubject_fk_id);
            return View(timetable);
        }

        // GET: timetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timetable timetable = db.timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.class_id_fk = new SelectList(db.tbl_class, "class_id", "class_name", timetable.class_id_fk);
            ViewBag.faculty_id_fk = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name", timetable.faculty_id_fk);
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name", timetable.suubject_fk_id);
            return View(timetable);
        }

        // POST: timetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "timetable_id,class_id_fk,faculty_id_fk,suubject_fk_id,date_time,dayss")] timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.class_id_fk = new SelectList(db.tbl_class, "class_id", "class_name", timetable.class_id_fk);
            ViewBag.faculty_id_fk = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name", timetable.faculty_id_fk);
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name", timetable.suubject_fk_id);
            return View(timetable);
        }

        // GET: timetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timetable timetable = db.timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            timetable timetable = db.timetables.Find(id);
            db.timetables.Remove(timetable);
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
