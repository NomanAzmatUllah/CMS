using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coachingSystem.Models.viewmodel
{
    public class feestructureviewmodel
    {

        public int fee_structure_id { get; set; }
        public Nullable<int> fee_structure_Amount { get; set; }
        public Nullable<int> class_fk_id { get; set; }
    }
}