﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Helpers;
using School.Models;

namespace School.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly PruebaContext _context;
        private readonly StudentHelper _studentHelper;
        private readonly CourseHelper _courseHelper;
        private readonly QualificationHelper _QualificationHelper;



        public EnrollmentsController(PruebaContext context,
          StudentHelper Helper,
          CourseHelper CourseHelper,
          QualificationHelper QualificationHelper)
        {
            _context = context;
            _studentHelper = Helper;
            _courseHelper = CourseHelper;
            _QualificationHelper = QualificationHelper;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var model = new StudentsViewModel
            {

                Students = this._studentHelper.GetComboStudents(),
                Enrollments = this._studentHelper.ListEnrollment(),
                Courses = this._courseHelper.ListCourses(),
                Qualification = this._QualificationHelper.ListQualification()


            };
            return View(model);
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.IdEnrollment == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enrollments);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments.FindAsync(id);
            if (enrollments == null)
            {
                return NotFound();
            }
            return View(enrollments);
        }

        // POST: Enrollments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Enrollments enrollments)
        {
            if (id != enrollments.IdEnrollment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentsExists(enrollments.IdEnrollment))
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
            return View(enrollments);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.IdEnrollment == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollments = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentsExists(int id)
        {
            return _context.Enrollments.Any(e => e.IdEnrollment == id);
        }
    }
}
