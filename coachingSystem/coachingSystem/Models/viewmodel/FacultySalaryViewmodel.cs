using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class FacultySalaryViewmodel
    {


        public int Us_id { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CurrentDate { get; set; }
        public string currMonth { get; set; }
        public string monthly_salary { get; set; }
        public string Bonus { get; set; }
        public string extra_Amount { get; set; }
        public Nullable<int> Faculty_id { get; set; }


    }
}