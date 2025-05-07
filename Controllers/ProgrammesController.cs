using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIMS_Web.Data;
using SIMS_Web.Models;
using SIMS_Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS_Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProgrammesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuditService _auditService;

        public ProgrammesController(ApplicationDbContext context, AuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        // GET: Programmes
        public async Task<IActionResult> Index()
        {
            var programmes = _context.Programmes
                .Include(p => p.Faculty)
                .Include(p => p.Department);
            return View(await programmes.ToListAsync());
        }

        // GET: Programmes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programme = await _context.Programmes
                .Include(p => p.Faculty)
                .Include(p => p.Department)
                .FirstOrDefaultAsync(m => m.Prog_id == id);
                
            if (programme == null)
            {
                return NotFound();
            }

            return View(programme);
        }

        // GET: Programmes/Create
        public IActionResult Create()
        {
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName");
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName");
            return View();
        }

        // POST: Programmes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prog_id,ProgName,Faculty_id,Dept_id,Duration")] Programme programme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programme);
                await _context.SaveChangesAsync();
                
                await _auditService.LogActionAsync(
                    "Create Programme", 
                    $"Programme ID: {programme.Prog_id}, Name: {programme.ProgName}, Duration: {programme.Duration}");
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName", programme.Faculty_id);
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName", programme.Dept_id);
            return View(programme);
        }

        // GET: Programmes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programme = await _context.Programmes.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName", programme.Faculty_id);
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName", programme.Dept_id);
            return View(programme);
        }

        // POST: Programmes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Prog_id,ProgName,Faculty_id,Dept_id,Duration")] Programme programme)
        {
            if (id != programme.Prog_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programme);
                    await _context.SaveChangesAsync();
                    
                    await _auditService.LogActionAsync(
                        "Edit Programme", 
                        $"Programme ID: {programme.Prog_id}, Name: {programme.ProgName}, Duration: {programme.Duration}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammeExists(programme.Prog_id))
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
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName", programme.Faculty_id);
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName", programme.Dept_id);
            return View(programme);
        }

        // GET: Programmes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programme = await _context.Programmes
                .Include(p => p.Faculty)
                .Include(p => p.Department)
                .FirstOrDefaultAsync(m => m.Prog_id == id);
                
            if (programme == null)
            {
                return NotFound();
            }

            return View(programme);
        }

        // POST: Programmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var programme = await _context.Programmes.FindAsync(id);
            _context.Programmes.Remove(programme);
            await _context.SaveChangesAsync();
            
            await _auditService.LogActionAsync(
                "Delete Programme", 
                $"Programme ID: {programme.Prog_id}, Name: {programme.ProgName}");
                
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammeExists(string id)
        {
            return _context.Programmes.Any(e => e.Prog_id == id);
        }
    }
}