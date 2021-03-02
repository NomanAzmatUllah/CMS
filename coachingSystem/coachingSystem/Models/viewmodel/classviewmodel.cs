using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace coachingSystem.Models.viewmodel
{
    public class classviewmodel
    {

        public int class_id { get; set; }

        [Required(ErrorMessage ="Class-Name")]
        public string class_name { get; set; }
    }
}