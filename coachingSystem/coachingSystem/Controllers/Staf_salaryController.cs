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
    public class Staf_salaryController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: Staf_salary
        public ActionResult Index()
        {
            var staf_salary = db.Staf_salary.Include(s => s.tbl_staff);
            return View(staf_salary.ToList());
        }

        // GET: Staf_salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staf_salary staf_salary = db.Staf_salary.Find(id);
            if (staf_salary == null)
            {
                return HttpNotFound();
            }
            return View(staf_salary);
        }

        // GET: Staf_salary/Create
        public ActionResult Create()
        {
            ViewBag.Staff_id = new SelectList(db.tbl_staff, "staff_id", "staff_name");
            return View();
        }

        // POST: Staf_salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Us_id,CurrentDate,currMonth,monthly_salary,Bonus,extra_Amount,Staff_id")] Staf_salary staf_salary)
        {
            if (ModelState.IsValid)
            {
                db.Staf_salary.Add(staf_salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Staff_id = new SelectList(db.tbl_staff, "staff_id", "staff_name", staf_salary.Staff_id);
            return View(staf_salary);
        }

        // GET: Staf_salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staf_salary staf_salary = db.Staf_salary.Find(id);
            if (staf_salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.Staff_id = new SelectList(db.tbl_staff, "staff_id", "staff_name", staf_salary.Staff_id);
            return View(staf_salary);
        }

        // POST: Staf_salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Us_id,CurrentDate,currMonth,monthly_salary,Bonus,extra_Amount,Staff_id")] Staf_salary staf_salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staf_salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Staff_id = new SelectList(db.tbl_staff, "staff_id", "staff_name", staf_salary.Staff_id);
            return View(staf_salary);
        }

        // GET: Staf_salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staf_salary staf_salary = db.Staf_salary.Find(id);
            if (staf_salary == null)
            {
                return HttpNotFound();
            }
            return View(staf_salary);
        }

        // POST: Staf_salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staf_salary staf_salary = db.Staf_salary.Find(id);
            db.Staf_salary.Remove(staf_salary);
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
