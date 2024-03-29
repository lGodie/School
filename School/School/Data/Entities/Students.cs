﻿using System;
using System.Collections.Generic;

namespace School.Data.Entities
{
    public partial class Students
    {
        public Students()
        {
            Enrollments = new HashSet<Enrollments>();
        }

        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Enrollments> Enrollments { get; set; }
    }
}
