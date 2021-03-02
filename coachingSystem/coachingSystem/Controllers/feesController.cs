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
    public class feesController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: fees
        public ActionResult Index()
        {
            var fees = db.fees.Include(f => f.tbl_class).Include(f => f.Fee_structure).Include(f => f.tbl_student).Include(f => f.tbl_subject);
            return View(fees.ToList());
        }

        // GET: fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // GET: fees/Create
        public ActionResult Create()
        {
            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name");
            ViewBag.Fee_structure_id = new SelectList(db.Fee_structure, "fee_structure_id", "fee_structure_id");
            ViewBag.st_fk_id = new SelectList(db.tbl_student, "stu_id", "applicant_name");
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name");
            return View();
        }

        // POST: fees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fee_id,admission_fee_rs,st_fk_id,class_fk_id,suubject_fk_id,Fee_structure_id")] fee fee)
        {
            if (ModelState.IsValid)
            {
                db.fees.Add(fee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name", fee.class_fk_id);
            ViewBag.Fee_structure_id = new SelectList(db.Fee_structure, "fee_structure_id", "fee_structure_id", fee.Fee_structure_id);
            ViewBag.st_fk_id = new SelectList(db.tbl_student, "stu_id", "applicant_name", fee.st_fk_id);
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name", fee.suubject_fk_id);
            return View(fee);
        }

        // GET: fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name", fee.class_fk_id);
            ViewBag.Fee_structure_id = new SelectList(db.Fee_structure, "fee_structure_id", "fee_structure_id", fee.Fee_structure_id);
            ViewBag.st_fk_id = new SelectList(db.tbl_student, "stu_id", "applicant_name", fee.st_fk_id);
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name", fee.suubject_fk_id);
            return View(fee);
        }

        // POST: fees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fee_id,admission_fee_rs,st_fk_id,class_fk_id,suubject_fk_id,Fee_structure_id")] fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name", fee.class_fk_id);
            ViewBag.Fee_structure_id = new SelectList(db.Fee_structure, "fee_structure_id", "fee_structure_id", fee.Fee_structure_id);
            ViewBag.st_fk_id = new SelectList(db.tbl_student, "stu_id", "applicant_name", fee.st_fk_id);
            ViewBag.suubject_fk_id = new SelectList(db.tbl_subject, "sub_id", "sub_name", fee.suubject_fk_id);
            return View(fee);
        }

        // GET: fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // POST: fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fee fee = db.fees.Find(id);
            db.fees.Remove(fee);
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
