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

    /// <summary>
    /// Faculty Details  Page
    /// </summary>
    public class AdminController : Controller
    {
        private cmsEntities db = new cmsEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.tbl_faculty_details.ToList());
        }

        [HttpGet]
        public ActionResult Addfaculty()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Addfaculty(facultyviewmodel obj, HttpPostedFileBase imgfile)
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
                    tbl_faculty_details t = new tbl_faculty_details();

                    t.facullty_name = obj.facullty_name;
                    t.father_name = obj.father_name;
                    t.cnic = obj.cnic;
                    t.date_of_birth = obj.date_of_birth;
                    t.marital_status = obj.marital_status;
                    t.contact_no = obj.contact_no;
                    t.email = obj.email;
                    t.addresss = obj.addresss;
                    t.qualification = obj.qualification;
                    t.instituion = obj.instituion;
                    t.experience = obj.experience;
                    t.descriptionn = obj.descriptionn;
                    t.skill_activities = obj.skill_activities;
                    t.faculty_image = obj.faculty_image = s;
                    db.tbl_faculty_details.Add(t);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");


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

            tbl_faculty_details st = db.tbl_faculty_details.Find(id);

            return View(st);

        }



        [HttpGet]

        public ActionResult Edit(int? id)

        {
           

            if (id == null)
            {

                return RedirectToAction("Index");
            }

            tbl_faculty_details t = db.tbl_faculty_details.Where(x => x.faculty_Id == id).SingleOrDefault();
          


            if (t == null)
            {
                return HttpNotFound();

            }

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(tbl_faculty_details t,  facultyviewmodel obj, HttpPostedFileBase imgfile)
        {
            string s = uploadimgfile(imgfile);

            t.facullty_name = obj.facullty_name;
            t.father_name = obj.father_name;
            t.cnic = obj.cnic;
            t.date_of_birth = obj.date_of_birth;
            t.marital_status = obj.marital_status;
            t.contact_no = obj.contact_no;
            t.email = obj.email;
            t.addresss = obj.addresss;
            t.qualification = obj.qualification;
            t.instituion = obj.instituion;
            t.experience = obj.experience;
            t.descriptionn = obj.descriptionn;
            t.skill_activities = obj.skill_activities;
            t.faculty_image = obj.faculty_image = s;
            db.tbl_faculty_details.Add(t);
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            return View();
        }









    }
}