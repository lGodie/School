using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class EnrollmentsViewModel
    {
        [Required]
        [Display(Name = "Estudiante")]
        public int? IdStudent { get; set; }
        [Required]
        [Display(Name = "Curso")]

        public int? IdCourse { get; set; }
    }
}
