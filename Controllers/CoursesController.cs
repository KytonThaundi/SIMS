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
    [Authorize(Roles = "Admin,Staff")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuditService _auditService;

        public CoursesController(ApplicationDbContext context, AuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses.Include(c => c.Department);
            return View(await courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.Course_id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName");
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Course_id,CourseName,CreditHours,AssessmentType,GradingSystem,Dept_id")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();

                var department = await _context.Departments.FindAsync(course.Dept_id);
                await _auditService.LogActionAsync(
                    "Create Course",
                    $"Course ID: {course.Course_id}, Name: {course.CourseName}, Credits: {course.CreditHours}, Department: {department?.DeptName}");

                return RedirectToAction(nameof(Index));
            }
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName", course.Dept_id);
            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName", course.Dept_id);
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("Course_id,CourseName,CreditHours,AssessmentType,GradingSystem,Dept_id")] Course course)
        {
            if (id != course.Course_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();

                    var department = await _context.Departments.FindAsync(course.Dept_id);
                    await _auditService.LogActionAsync(
                        "Edit Course",
                        $"Course ID: {course.Course_id}, Name: {course.CourseName}, Credits: {course.CreditHours}, Department: {department?.DeptName}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Course_id))
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
            ViewData["Dept_id"] = new SelectList(_context.Departments, "Dept_id", "DeptName", course.Dept_id);
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.Course_id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                var department = await _context.Departments.FindAsync(course.Dept_id);
                await _auditService.LogActionAsync(
                    "Delete Course",
                    $"Course ID: {course.Course_id}, Name: {course.CourseName}, Credits: {course.CreditHours}, Department: {department?.DeptName}");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(string id)
        {
            return _context.Courses.Any(e => e.Course_id == id);
        }
    }
}