using System;
using System.Collections.Generic;

namespace School.Data.Entities
{
    public partial class Courses
    {
        public Courses()
        {
            Enrollments = new HashSet<Enrollments>();
        }

        public int IdCourse { get; set; }
        public string Name { get; set; }
        public string Credits { get; set; }

        public virtual ICollection<Enrollments> Enrollments { get; set; }
    }
}
