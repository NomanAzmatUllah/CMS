//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coachingSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public int id { get; set; }
        public Nullable<System.DateTime> currentDate { get; set; }
        public Nullable<int> stu_id { get; set; }
        public Nullable<int> Class_id { get; set; }
        public string AttendanceStatus { get; set; }
    
        public virtual tbl_class tbl_class { get; set; }
        public virtual tbl_student tbl_student { get; set; }
    }
}
