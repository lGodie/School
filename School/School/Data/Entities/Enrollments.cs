using System;
using System.Collections.Generic;

namespace School.Data.Entities
{
    public partial class Enrollments
    {
        public Enrollments()
        {
            QualificationIdCourseNoteNavigation = new HashSet<Qualification>();
            QualificationIdStudentNoteNavigation = new HashSet<Qualification>();
        }

        public int IdEnrollment { get; set; }
        public int? IdStudent { get; set; }
        public int? IdCourse { get; set; }

        public virtual Courses IdCourseNavigation { get; set; }
        public virtual Students IdStudentNavigation { get; set; }
        public virtual ICollection<Qualification> QualificationIdCourseNoteNavigation { get; set; }
        public virtual ICollection<Qualification> QualificationIdStudentNoteNavigation { get; set; }
    }
}
