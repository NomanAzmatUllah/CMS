using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class attendenceviewmodel
    {

        public int id { get; set; }


        [DataType(DataType.Date)]        
        public Nullable<System.DateTime> currentDate { get; set; }
        public Nullable<int> stu_id { get; set; }
        public Nullable<int> Class_id { get; set; }
        public string AttendanceStatus { get; set; }
    }
}