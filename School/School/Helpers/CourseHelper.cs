using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Data.Entities;

namespace School.Helpers
{
    public class CourseHelper
    {
        private readonly PruebaContext _context;

        public CourseHelper(PruebaContext context)
        {
            _context = context;
        }

        public List<Courses> ListCourses()
        {
            var list = this._context.Courses.ToList();

            return list;

        }

        public string getName (int idCourse)
        {
            string result = null;

            result = _context.Courses.Where(x => x.IdCourse == idCourse).Select(x => x.Name).FirstOrDefault();

            return result;
        }
    }
}
