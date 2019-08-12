using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Data.Entities;

namespace School.Helpers
{
    public class QualificationHelper
    {
        private readonly PruebaContext _context;

        public QualificationHelper(PruebaContext context)
        {
            _context = context;
        }

        public List<Qualification> ListQualification()
        {
            var list = this._context.Qualification.ToList();

            return list;

        }

    }
}
