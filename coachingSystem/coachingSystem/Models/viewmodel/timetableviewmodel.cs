using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class timetableviewmodel
    {
        public int timetable_id { get; set; }
        public Nullable<int> class_id_fk { get; set; }
        public Nullable<int> faculty_id_fk { get; set; }
        public Nullable<int> suubject_fk_id { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_time { get; set; }
        public string dayss { get; set; }
    }
}