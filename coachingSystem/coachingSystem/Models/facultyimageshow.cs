using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coachingSystem.Models
{
    public class facultyimageshow
    {

        public cmsEntities db = new cmsEntities();
        public IEnumerable<tbl_faculty_details> listoffaculty {get; set;}
    }
}