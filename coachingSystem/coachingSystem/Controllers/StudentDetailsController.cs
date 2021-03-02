using coachingSystem.Models;
using coachingSystem.Models.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coachingSystem.Controllers
{
    public class StudentDetailsController : Controller
    {
        private cmsEntities db = new cmsEntities();
        // GET: StudentDetails
        public ActionResult Index()
        {


            return View(db.tbl_student.ToList());
        }

        [HttpGet]
        public ActionResult AddStudent()
        {


            List<tbl_class> Class = db.tbl_class.ToList();
            ViewBag.listclass = new SelectList(Class, "class_id", "class_name");

            List<tbl_subject> studentclass = db.tbl_subject.ToList();
            ViewBag.listsubject = new SelectList(studentclass, "sub_id", "sub_name");



            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentViewModel obj, HttpPostedFileBase imgfile)
        {
            try
            {

                string s = uploadimgfile(imgfile);
                if (s.Equals("-1"))
                {
                    Response.Write("<script>alert('image upload failed...') <script>");
                }
                else
                {
                    tbl_student t = new tbl_student();
                    t.applicant_name = obj.applicant_name;
                    t.father_name = obj.father_name;
                    t.father_occupation = obj.father_occupation;
                    t.home_address = obj.home_address;
                    t.email = obj.email;
                    t.father_student_Cnic = obj.father_student_Cnic;
                    t.cell = obj.cell;
                    t.name_of_college = obj.name_of_college;
                    t.stu_image = obj.stu_image = s;
                    t.groupp = obj.groupp;
                    t.date_of_admission = obj.date_of_admission;
                    t.date_of_payment = obj.date_of_payment;
                    t.class_fk_id = obj.class_fk_id;
                    t.suubject_fk_id = obj.suubject_fk_id;
                    db.tbl_student.Add(t);
                    db.SaveChanges();
                    return RedirectToAction("Create", "fee");


                }

            }
            catch (Exception ex)
            {

                //throw;
            }
            return View();
        }

        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images/"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/images/" + random + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {

                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('only png or jpeg or jpg format allow');<script>");

                }


            }

            return path;
        }



        public ActionResult Details(int? id)
        {

            tbl_student st = db.tbl_student.Find(id);

            return View(st);

        }



        [HttpGet]

        public ActionResult Edit(int? id)

        {

            List<tbl_class> Class = db.tbl_class.ToList();
            ViewBag.listclass = new SelectList(Class, "class_id", "class_name");

            List<tbl_subject> studentclass = db.tbl_subject.ToList();
            ViewBag.listsubject = new SelectList(studentclass, "sub_id", "sub_name");


            if (id == null)
            {

                return RedirectToAction("Index");
            }

            tbl_student t = db.tbl_student.Where(x => x.stu_id == id).SingleOrDefault();



            if (t == null)
            {
                return HttpNotFound();

            }

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(tbl_student t, StudentViewModel obj, HttpPostedFileBase imgfile)
        {
            string s = uploadimgfile(imgfile);
           
            t.applicant_name = obj.applicant_name;
            t.father_name = obj.father_name;
            t.father_occupation = obj.father_occupation;
            t.home_address = obj.home_address;
            t.email = obj.email;
            t.father_student_Cnic = obj.father_student_Cnic;
            t.cell = obj.cell;
            t.name_of_college = obj.name_of_college;
            t.stu_image = obj.stu_image = s;
            t.groupp = obj.groupp;
            t.date_of_admission = obj.date_of_admission;
            t.date_of_payment = obj.date_of_payment;
            t.class_fk_id = obj.class_fk_id;
            t.suubject_fk_id = obj.suubject_fk_id;
            db.tbl_student.Add(t);
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            return View();
        }




    }
}