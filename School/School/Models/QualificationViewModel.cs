using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class QualificationViewModel
    {
        [Required]
        [Display(Name = "Estudiantes")]
        public int? IdStudentNote { get; set; }
        [Required]
        [Display(Name = "Cursos")]
        public int? IdCourseNote { get; set; }

        [Range(0, 5, ErrorMessage = "Ingrese una calificación entre o y 5") ]
        public double? Qualification1 { get; set; }
    }
}
