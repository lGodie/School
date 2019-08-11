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
        [Display(Name = "Id Student")]
        public int? IdStudent { get; set; }
        [Required]
        [Display(Name = "Id Course")]

        public int? IdCourse { get; set; }
    }
}
