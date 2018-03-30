using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MERAS.Data;
using MERAS.Models;

namespace MERAS.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MerasContext _context;

        public StudentsController(MerasContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var merasContext = _context.Students
				.Include(s => s.Supervisor)
				.Include(d => d.Department)
				.AsNoTracking();
			return View(await merasContext.ToListAsync());

        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Supervisor)
				.Include(d => d.Department)
				.AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["SupervisorID"] = new SelectList(_context.Supervisors, "ID", "FirstName");
			ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name");
			return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,CreditHrs,SupervisorID,DepartmentID,AssignedInternshipID,Phone,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupervisorID"] = new SelectList(_context.Supervisors, "ID", "FirstName", student.SupervisorID);
			ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name", student.DepartmentID);
			return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["SupervisorID"] = new SelectList(_context.Supervisors, "ID", "FirstName", student.SupervisorID);
			ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name", student.DepartmentID);
			return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,CreditHrs,SupervisorID,DepartmentID,AssignedInternshipID,Phone,Email")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            ViewData["SupervisorID"] = new SelectList(_context.Supervisors, "ID", "FirstName", student.SupervisorID);
			ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name", student.DepartmentID);
			return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Supervisor)
				.ThenInclude(d => d.Department)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
