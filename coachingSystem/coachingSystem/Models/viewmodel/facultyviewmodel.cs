using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class facultyviewmodel
    {
        public int faculty_Id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string facullty_name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string father_name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string cnic { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_of_birth { get; set; }

        [Required(ErrorMessage = "Required")]
        public string marital_status { get; set; }

        [Required(ErrorMessage = "Required")]
       
        public string contact_no { get; set; }

        [Required(ErrorMessage = "Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string addresss { get; set; }

        [Required(ErrorMessage = "Required")]
        public string qualification { get; set; }

        [Required(ErrorMessage = "Required")]
        public string instituion { get; set; }

        [Required(ErrorMessage = "Required")]
        public string experience { get; set; }

        [Required(ErrorMessage = "Required")]
        public string descriptionn { get; set; }

        [Required(ErrorMessage = "Required")]
        public string skill_activities { get; set; }

       // [Required(ErrorMessage = "Required")]
        public string faculty_image { get; set; }
    }
}