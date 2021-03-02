using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace coachingSystem.Models.viewmodel
{
    public class invventoryviewmodel
    {
        public int inventory_id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string items_name { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> items_quanitity { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> items_price { get; set; }

    }
}