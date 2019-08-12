using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Controllers
{
    public class QualificationsController : Controller
    {
        private readonly PruebaContext _context;

        public QualificationsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Qualifications
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.Qualification.Include(q => q.IdCourseNoteNavigation).Include(q => q.IdStudentNoteNavigation);
            return View(await pruebaContext.ToListAsync());
        }

        // GET: Qualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualification
                .Include(q => q.IdCourseNoteNavigation)
                .Include(q => q.IdStudentNoteNavigation)
                .FirstOrDefaultAsync(m => m.IdQualification == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // GET: Qualifications/Create
        public IActionResult Create()
        {
            ViewData["IdCourseNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment");
            ViewData["IdStudentNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment");
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQualification,IdStudentNote,IdCourseNote,Qualification1")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCourseNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment", qualification.IdCourseNote);
            ViewData["IdStudentNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment", qualification.IdStudentNote);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualification.FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }
            ViewData["IdCourseNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment", qualification.IdCourseNote);
            ViewData["IdStudentNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment", qualification.IdStudentNote);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQualification,IdStudentNote,IdCourseNote,Qualification1")] Qualification qualification)
        {
            if (id != qualification.IdQualification)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationExists(qualification.IdQualification))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCourseNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment", qualification.IdCourseNote);
            ViewData["IdStudentNote"] = new SelectList(_context.Enrollments, "IdEnrollment", "IdEnrollment", qualification.IdStudentNote);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualification
                .Include(q => q.IdCourseNoteNavigation)
                .Include(q => q.IdStudentNoteNavigation)
                .FirstOrDefaultAsync(m => m.IdQualification == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualification = await _context.Qualification.FindAsync(id);
            _context.Qualification.Remove(qualification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationExists(int id)
        {
            return _context.Qualification.Any(e => e.IdQualification == id);
        }
    }
}
