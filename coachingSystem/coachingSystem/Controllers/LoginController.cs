using coachingSystem.Models;
using coachingSystem.Models.viewmodel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace coachingSystem.Controllers
{
    public class LoginController : Controller
    {
        private cmsEntities db = new cmsEntities();
      public  int classid;
        //GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        //post login form
        public ActionResult Login(adminviewmodel obj)
        {

            tbl_admin t = db.tbl_admin.Where(x => x.ad_Email == obj.ad_Email && x.ad_password == obj.ad_password && x.ad_designation == obj.ad_designation).SingleOrDefault();

            if (t!= null)
            {

                Session["User_id"] = t.ad_name;
                return RedirectToAction("Adminplate");

            }
            else
            {

                return RedirectToAction("Login");    

            }

            return View();
        }

     
        public ActionResult Signup()
        {
           
          
            return View();
        }

      
        //post signuup form
        public ActionResult Signup(adminviewmodel obj)
        {
            if (ModelState.IsValid)
            {

                tbl_admin t = new tbl_admin();
                t.ad_name = obj.ad_name;
                t.ad_Email = obj.ad_Email;
                t.ad_password = obj.ad_password;
                t.ad_designation = obj.ad_designation;
                db.tbl_admin.Add(t);
                db.SaveChanges();
                return Redirect("Login");

            }




            return View();


        }


        public ActionResult Adminplate()
        {
            return View();
        }


        public ActionResult Logout()
        {


            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");

            return View();
        }


        //markshaeet

            [HttpGet]
        public ActionResult marksheetmarksheet()
        {

            List<tbl_class> li = db.tbl_class.ToList();
            ViewBag.list = new SelectList(li, "class_id", "class_name");

            List<tbl_subject> lis = db.tbl_subject.ToList();
            ViewBag.lists = new SelectList(lis, "sub_id", "sub_name");

            List<tbl_student> liss = db.tbl_student.ToList();
            ViewBag.listss = new SelectList(liss, "stu_id", "applicant_name");
            return View();

        }

         public ActionResult GetRecords(string tablerecords)
        {
            maarkSheet m = new maarkSheet();
            DataTable dt = new DataTable();
            DataTable records = new DataTable();  
            dt = JsonConvert.DeserializeObject<DataTable>(tablerecords);

            string count = dt.Rows.Count.ToString();
            
                       
                foreach (DataRow item in dt.Rows)
                {
                    m.Markob_subone = item["Subject"].ToString();
                    m.totalMarks_subone = item["TotalMarks"].ToString();
                    m.Stu_id = Convert.ToInt16(item["StudentId"].ToString());
                    m.Class_id = Convert.ToInt16(item["Classid"].ToString());
                    db.maarkSheets.Add(m);
                    db.SaveChanges();
                    


                }

            return Json(new
            {
                success = true,
            },
       JsonRequestBehavior.AllowGet);

            
        }





        //mark attendance Page

        [HttpGet]
        public ActionResult getStudentRecors()
        {

            List<tbl_class> li = db.tbl_class.ToList();
            ViewBag.list = new SelectList(li, "class_id", "class_name");
                
            return View();
        }

        [HttpPost]
        public ActionResult getStudentRecors(attendenceviewmodel uvm)
        {

          
            List<tbl_class> li = db.tbl_class.ToList();
            ViewBag.list = new SelectList(li, "class_id", "class_name");

            tbl_student s = new tbl_student();
            List<tbl_student> t = db.tbl_student.Where(x => x.class_fk_id == uvm.Class_id).ToList();
            Session["id"] = uvm.Class_id;
            Session["Date"] = uvm.currentDate;
            List<string> listdata = new List<string>();
            foreach (var item in t)
            {
               

                listdata.Add(item.stu_id.ToString());
                listdata.Add(item.applicant_name);
                
            }

            ViewBag.listone = t;
            return View();
        }

        public  ActionResult SaveAttendance(string tableone , string tabletwo)
        {
            

            Attendance t = new Attendance();

            DataTable Present = new DataTable();
            Present = JsonConvert.DeserializeObject<DataTable>(tableone);


            DataTable Absent = new DataTable();
            Absent = JsonConvert.DeserializeObject<DataTable>(tabletwo);
            

            foreach (DataRow row in Present.Rows)
            {
             
                t.stu_id = Convert.ToUInt16(row["Id"].ToString());
                t.currentDate = DateTime.Now;
                t.AttendanceStatus = "Present";
                t.Class_id = Convert.ToUInt16(Session["id"].ToString());
                db.Attendances.Add(t);
                db.SaveChanges();
               

            }
            foreach (DataRow row in Absent.Rows)
            {

                t.stu_id = Convert.ToUInt16(row["Id"].ToString());
                t.currentDate = DateTime.Now;
                t.AttendanceStatus = "Absent";
                t.Class_id = Convert.ToUInt16(Session["id"].ToString());
                db.Attendances.Add(t);
                db.SaveChanges();
            }           
            return Json(new
            {
                success = true,               
            },
            JsonRequestBehavior.AllowGet);

        }





        //Get Records Of Student Absent
        public ActionResult GetAbsentRecords(attendenceviewmodel uvm)
        {
            Attendance t = new Attendance();
            string status = "Absent";

            string currdate = uvm.currentDate.ToString();
            List<Attendance> at = db.Attendances.ToList();
            foreach (var item in at)
            {
                if(Convert.ToDateTime(item.currentDate.ToString()) == Convert.ToDateTime(currdate.ToString()) &&  item.AttendanceStatus == status)
                {
                    string s = "";
                }
                
            }
                  
            return View();


        }
    }
}