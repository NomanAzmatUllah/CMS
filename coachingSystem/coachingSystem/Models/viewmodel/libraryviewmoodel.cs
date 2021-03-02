using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace coachingSystem.Models.viewmodel
{
    public class libraryviewmoodel
    {

        public int book_id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string book_name { get; set; }


        [Required(ErrorMessage = "Required")]
        public string book_category { get; set; }


        [Required(ErrorMessage = "Required")]
        public Nullable<int> book_status { get; set; }
    }
}