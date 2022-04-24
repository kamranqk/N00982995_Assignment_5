using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject_1_w2022.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherFName { get; set; }

        public string TeacherLName { get; set; }

        public string EmployeeNumber { get; set; }

        public DateTime TeacherHireDate { get; set; }

        public Decimal Salary { get; set; }
    }
}