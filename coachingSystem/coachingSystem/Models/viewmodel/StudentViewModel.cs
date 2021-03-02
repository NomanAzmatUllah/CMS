using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class StudentViewModel
    {
        public int stu_id { get; set; }
        public string applicant_name { get; set; }
        public string father_name { get; set; }
        public string father_occupation { get; set; }
        public string home_address { get; set; }
        public string email { get; set; }
        public string father_student_Cnic { get; set; }
        public string cell { get; set; }
        public string name_of_college { get; set; }
        public string stu_image { get; set; }
        public string groupp { get; set; }
        public Nullable<System.DateTime> date_of_admission { get; set; }
        public Nullable<System.DateTime> date_of_payment { get; set; }
        public Nullable<int> class_fk_id { get; set; }
        public Nullable<int> suubject_fk_id { get; set; }


    }
}