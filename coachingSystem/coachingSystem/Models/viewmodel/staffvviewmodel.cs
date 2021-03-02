using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coachingSystem.Models.viewmodel
{
    public class staffvviewmodel
    {
        public int staff_id { get; set; }


        [Required(ErrorMessage ="Required")]
        public string staff_name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string staff_contact { get; set; }

        [Required(ErrorMessage = "Required")]
        public string staff_cnic { get; set; }

        [Required(ErrorMessage = "Required")]
        public string staff_address { get; set; }

    }
}