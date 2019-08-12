using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Data.Entities;

namespace School.Helpers
{
    public class StudentHelper 
    {
        private readonly PruebaContext _context;

        public StudentHelper(PruebaContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboStudents()
    {
        var list = this._context.Students.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.IdStudent.ToString()
        }).OrderBy(l => l.Text).ToList();

        list.Insert(0, new SelectListItem
        {
            Text = "(Seleccione un estudiante...)",
            Value = "0"
        });

        return list;
    }

        public List<Enrollments> ListEnrollment()
        {
            var list = this._context.Enrollments.ToList();

            return list;

        }

    }
}
