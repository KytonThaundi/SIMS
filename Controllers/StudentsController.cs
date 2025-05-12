using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIMS.Web.Data;
using SIMS.Web.Models;
using SIMS.Web.Services;
using System.Threading.Tasks;

namespace SIMS.Web.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuditService _auditService;

        public StudentsController(ApplicationDbContext context, AuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = _context.Students.Include(s => s.Programme);
            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Programme)
                .FirstOrDefaultAsync(m => m.Student_Id == id);
                
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create()
        {
            ViewData["ProgramOfStudy"] = new SelectList(_context.Programmes, "Prog_id", "ProgName");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Create([Bind("Student_Id,Fname,Surname,Gender,ProgramOfStudy,TOA,Accommodation,RegStatus,YOA,Mobile,Email,AccNum")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                
                await _auditService.LogActionAsync(
                    "Add Student", 
                    $"Student ID: {student.Student_Id}, Name: {student.Fname} {student.Surname}, Program: {student.ProgramOfStudy}");
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramOfStudy"] = new SelectList(_context.Programmes, "Prog_id", "ProgName", student.ProgramOfStudy);
            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ProgramOfStudy"] = new SelectList(_context.Programmes, "Prog_id", "ProgName", student.ProgramOfStudy);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Edit(string id, [Bind("Student_Id,Fname,Surname,Gender,ProgramOfStudy,TOA,Accommodation,RegStatus,YOA,Mobile,Email,AccNum")] Student student)
        {
            if (id != student.Student_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    
                    await _auditService.LogActionAsync(
                        "Edit Student", 
                        $"Student ID: {student.Student_Id}, Name: {student.Fname} {student.Surname}, Program: {student.ProgramOfStudy}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Student_Id))
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
            ViewData["ProgramOfStudy"] = new SelectList(_context.Programmes, "Prog_id", "ProgName", student.ProgramOfStudy);
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Programme)
                .FirstOrDefaultAsync(m => m.Student_Id == id);
                
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            
            await _auditService.LogActionAsync(
                "Delete Student", 
                $"Student ID: {student.Student_Id}, Name: {student.Fname} {student.Surname}, Program: {student.ProgramOfStudy}");
                
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.Student_Id == id);
        }
    }
}