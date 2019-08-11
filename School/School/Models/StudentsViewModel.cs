using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Display(Name = "Student")]
        [Range(1, int.MaxValue, ErrorMessage = "select a student.")]
        public int IdStudent { get; set; }
        public IEnumerable<SelectListItem> Students { get; set; }
    }
}
