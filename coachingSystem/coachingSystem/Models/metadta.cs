using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using coachingSystem.Models.viewmodel;

namespace coachingSystem.Models
{

    [MetadataType(typeof(adminviewmodel))]
    public partial class tbl_admin
    {
    }

    [MetadataType(typeof(facultyviewmodel))]
    public partial class tbl_faculty_details
    {
    }

    [MetadataType(typeof(classviewmodel))]
    public partial class tbl_class
    {
    }


    [MetadataType(typeof(feestructureviewmodel))]
    public partial class Fee_structure
    {
    }


    [MetadataType(typeof(subjectviewmodel))]
    public partial class tbl_subject
    {
    }

    [MetadataType(typeof(staffvviewmodel))]
    public partial class tbl_staff
    {
    }


    [MetadataType(typeof(invventoryviewmodel))]
    public partial class inventory
    {
    }


    [MetadataType(typeof(libraryviewmoodel))]
    public partial class library
    {
    }

    [MetadataType(typeof(StudentViewModel))]
    public partial class tbl_student
    {
    }


    [MetadataType(typeof(feeviewmodel))]
    public partial class fee
    {
    }

    [MetadataType(typeof(timetableviewmodel))]
    public partial class timetable
    {
    }



    [MetadataType(typeof(stafsalaryviewmodel))]
    public partial class Staf_salary
    {
    }


    [MetadataType(typeof(FacultySalaryViewmodel))]
    public partial class faculty_salary
    {
    }




    [MetadataType(typeof(attendenceviewmodel))]
    public partial class Attendance
    {
    }




}