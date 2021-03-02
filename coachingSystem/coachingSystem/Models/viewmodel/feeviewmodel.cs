using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class feeviewmodel
    {


        public int fee_id { get; set; }

        [Required(ErrorMessage ="Required")]
        public Nullable<int> admission_fee_rs { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> st_fk_id { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> class_fk_id { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> suubject_fk_id { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> Fee_structure_id { get; set; }
    }
}