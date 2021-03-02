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
    public class faculty_salaryController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: faculty_salary
        public ActionResult Index()
        {
            var faculty_salary = db.faculty_salary.Include(f => f.tbl_faculty_details);
            return View(faculty_salary.ToList());
        }

        // GET: faculty_salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculty_salary faculty_salary = db.faculty_salary.Find(id);
            if (faculty_salary == null)
            {
                return HttpNotFound();
            }
            return View(faculty_salary);
        }

        // GET: faculty_salary/Create
        public ActionResult Create()
        {
            ViewBag.Faculty_id = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name");
            return View();
        }

        // POST: faculty_salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Us_id,CurrentDate,currMonth,monthly_salary,Bonus,extra_Amount,Faculty_id")] faculty_salary faculty_salary)
        {
            if (ModelState.IsValid)
            {
                db.faculty_salary.Add(faculty_salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Faculty_id = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name", faculty_salary.Faculty_id);
            return View(faculty_salary);
        }

        // GET: faculty_salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculty_salary faculty_salary = db.faculty_salary.Find(id);
            if (faculty_salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty_id = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name", faculty_salary.Faculty_id);
            return View(faculty_salary);
        }

        // POST: faculty_salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Us_id,CurrentDate,currMonth,monthly_salary,Bonus,extra_Amount,Faculty_id")] faculty_salary faculty_salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty_id = new SelectList(db.tbl_faculty_details, "faculty_Id", "facullty_name", faculty_salary.Faculty_id);
            return View(faculty_salary);
        }

        // GET: faculty_salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculty_salary faculty_salary = db.faculty_salary.Find(id);
            if (faculty_salary == null)
            {
                return HttpNotFound();
            }
            return View(faculty_salary);
        }

        // POST: faculty_salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            faculty_salary faculty_salary = db.faculty_salary.Find(id);
            db.faculty_salary.Remove(faculty_salary);
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
