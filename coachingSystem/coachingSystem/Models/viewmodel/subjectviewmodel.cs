using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class subjectviewmodel
    {
        public int sub_id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string sub_name { get; set; }
    }
}