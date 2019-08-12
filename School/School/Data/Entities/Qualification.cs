using System;
using System.Collections.Generic;

namespace School.Data.Entities
{
    public partial class Qualification
    {
        public int IdQualification { get; set; }
        public int IdStudentNote { get; set; }
        public int IdCourseNote { get; set; }
        public double? Qualification1 { get; set; }

        public virtual Enrollments IdCourseNoteNavigation { get; set; }
        public virtual Enrollments IdStudentNoteNavigation { get; set; }
    }
}
