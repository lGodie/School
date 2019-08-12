using Microsoft.AspNetCore.Mvc.Rendering;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class StudentsViewModel
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        [Display(Name = "Estudiantes")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un estudiante.")]
        public int IdStudent { get; set; }
        public IEnumerable<SelectListItem> Students { get; set; }

        public List<Enrollments> Enrollments { get; set; }
        public List<Courses> Courses { get; set; }

        public List<Qualification> Qualification { get; set; }



    }
}
