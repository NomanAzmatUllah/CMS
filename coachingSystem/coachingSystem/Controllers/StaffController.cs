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
    public class StaffController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: Staff
        public ActionResult Index()
        {
            return View(db.tbl_staff.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_staff tbl_staff = db.tbl_staff.Find(id);
            if (tbl_staff == null)
            {
                return HttpNotFound();
            }
            return View(tbl_staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staff_id,staff_name,staff_contact,staff_cnic,staff_address")] tbl_staff tbl_staff)
        {
            if (ModelState.IsValid)
            {
                db.tbl_staff.Add(tbl_staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_staff tbl_staff = db.tbl_staff.Find(id);
            if (tbl_staff == null)
            {
                return HttpNotFound();
            }
            return View(tbl_staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staff_id,staff_name,staff_contact,staff_cnic,staff_address")] tbl_staff tbl_staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_staff tbl_staff = db.tbl_staff.Find(id);
            if (tbl_staff == null)
            {
                return HttpNotFound();
            }
            return View(tbl_staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_staff tbl_staff = db.tbl_staff.Find(id);
            db.tbl_staff.Remove(tbl_staff);
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
