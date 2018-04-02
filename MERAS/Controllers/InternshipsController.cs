using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MERAS.Data;
using MERAS.Models;

namespace MERAS.Controllers
{
	public class InternshipsController : Controller
    {
        private readonly MerasContext _context;

        public InternshipsController(MerasContext context)
        {
            _context = context;
        }

        // GET: Internships
        public async Task<IActionResult> Index()
        {
            var merasContext = _context.Internships.Include(i => i.Company);
            return View(await merasContext.ToListAsync());
        }

        // GET: Internships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships
                .Include(i => i.Company)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        // GET: Internships/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name");
            return View();
        }

        // POST: Internships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyID,FirstName,ApplyStartDate,ApplyFinishtDate,StartDate,FinishtDate,Country,City")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(internship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name", internship.CompanyID);
            return View(internship);
        }

        // GET: Internships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships.SingleOrDefaultAsync(m => m.ID == id);
            if (internship == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name", internship.CompanyID);
            return View(internship);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyID,FirstName,ApplyStartDate,ApplyFinishtDate,StartDate,FinishtDate,Country,City")] Internship internship)
        {
            if (id != internship.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternshipExists(internship.ID))
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
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name", internship.CompanyID);
            return View(internship);
        }

        // GET: Internships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships
                .Include(i => i.Company)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        // POST: Internships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var internship = await _context.Internships.SingleOrDefaultAsync(m => m.ID == id);
            _context.Internships.Remove(internship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternshipExists(int id)
        {
            return _context.Internships.Any(e => e.ID == id);
        }
    }
}
