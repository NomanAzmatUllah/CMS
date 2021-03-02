using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class adminviewmodel
    {

        public int ad_id { get; set; }

        [Required(ErrorMessage ="Please Complete It")]
        public string ad_name { get; set; }

        [Required(ErrorMessage = "Please Complete It")]


        public string ad_Email { get; set; }

        [Required(ErrorMessage = "Please Complete It")]
        [DataType(DataType.Password)]

        public string ad_password { get; set; }

        [Required(ErrorMessage = "Please Complete It")]
        public string ad_designation { get; set; }
    }
}