using System;
using System.Collections.Generic;

namespace School.Data.Entities
{
    public partial class Enrollments
    {
        public int IdEnrollment { get; set; }
        public int? IdStudent { get; set; }
        public int? IdCourse { get; set; }
        public int? Qualification { get; set; }

        public virtual Courses IdCourseNavigation { get; set; }
        public virtual Students IdStudentNavigation { get; set; }
    }
}
