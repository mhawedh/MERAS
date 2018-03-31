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
    public class SupervisorsController : Controller
    {
        private readonly MerasContext _context;

        public SupervisorsController(MerasContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            var merasContext = _context.Supervisors.Include(s => s.Department);
            return View(await merasContext.ToListAsync());
        }

        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisors
                .Include(s => s.Department)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "ID");
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,DepartmentID,Phone,Email")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "ID", supervisor.DepartmentID);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisors.SingleOrDefaultAsync(m => m.ID == id);
            if (supervisor == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "ID", supervisor.DepartmentID);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,DepartmentID,Phone,Email")] Supervisor supervisor)
        {
            if (id != supervisor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.ID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "ID", supervisor.DepartmentID);
            return View(supervisor);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisors
                .Include(s => s.Department)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisor = await _context.Supervisors.SingleOrDefaultAsync(m => m.ID == id);
            _context.Supervisors.Remove(supervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisors.Any(e => e.ID == id);
        }
    }
}
