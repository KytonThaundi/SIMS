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
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuditService _auditService;

        public DepartmentsController(ApplicationDbContext context, AuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departments = _context.Departments.Include(d => d.Faculty);
            return View(await departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Faculty)
                .FirstOrDefaultAsync(m => m.Dept_id == id);
                
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName");
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dept_id,DeptName,Faculty_id")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                
                var faculty = await _context.Faculties.FindAsync(department.Faculty_id);
                await _auditService.LogActionAsync(
                    "Create Department", 
                    $"Department ID: {department.Dept_id}, Name: {department.DeptName}, Faculty: {faculty?.FacultyName}");
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName", department.Faculty_id);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName", department.Faculty_id);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Dept_id,DeptName,Faculty_id")] Department department)
        {
            if (id != department.Dept_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                    
                    var faculty = await _context.Faculties.FindAsync(department.Faculty_id);
                    await _auditService.LogActionAsync(
                        "Edit Department", 
                        $"Department ID: {department.Dept_id}, Name: {department.DeptName}, Faculty: {faculty?.FacultyName}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Dept_id))
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
            ViewData["Faculty_id"] = new SelectList(_context.Faculties, "Faculty_id", "FacultyName", department.Faculty_id);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Faculty)
                .FirstOrDefaultAsync(m => m.Dept_id == id);
                
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            
            await _auditService.LogActionAsync(
                "Delete Department", 
                $"Department ID: {department.Dept_id}, Name: {department.DeptName}");
                
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(string id)
        {
            return _context.Departments.Any(e => e.Dept_id == id);
        }
    }
}