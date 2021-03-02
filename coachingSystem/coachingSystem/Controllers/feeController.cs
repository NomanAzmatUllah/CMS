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
    public class feeController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: fee
        public ActionResult Index()
        {
            var fee_structure = db.Fee_structure.Include(f => f.tbl_class);
            return View(fee_structure.ToList());
        }

        // GET: fee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee_structure fee_structure = db.Fee_structure.Find(id);
            if (fee_structure == null)
            {
                return HttpNotFound();
            }
            return View(fee_structure);
        }

        // GET: fee/Create
        public ActionResult Create()
        {
            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name");
            return View();
        }

        // POST: fee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fee_structure_id,fee_structure_Amount,class_fk_id")] Fee_structure fee_structure)
        {
            if (ModelState.IsValid)
            {
                db.Fee_structure.Add(fee_structure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name", fee_structure.class_fk_id);
            return View(fee_structure);
        }

        // GET: fee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee_structure fee_structure = db.Fee_structure.Find(id);
            if (fee_structure == null)
            {
                return HttpNotFound();
            }
            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name", fee_structure.class_fk_id);
            return View(fee_structure);
        }

        // POST: fee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fee_structure_id,fee_structure_Amount,class_fk_id")] Fee_structure fee_structure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee_structure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.class_fk_id = new SelectList(db.tbl_class, "class_id", "class_name", fee_structure.class_fk_id);
            return View(fee_structure);
        }

        // GET: fee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee_structure fee_structure = db.Fee_structure.Find(id);
            if (fee_structure == null)
            {
                return HttpNotFound();
            }
            return View(fee_structure);
        }

        // POST: fee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fee_structure fee_structure = db.Fee_structure.Find(id);
            db.Fee_structure.Remove(fee_structure);
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
