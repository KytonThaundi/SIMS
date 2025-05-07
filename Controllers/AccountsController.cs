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
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuditService _auditService;

        public AccountsController(ApplicationDbContext context, AuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var accounts = _context.Accounts.Include(a => a.Student);
            return View(await accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AccNo == id);
                
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id", "Fname");
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccNo,Student_Id,AccBal")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                
                var student = await _context.Students.FindAsync(account.Student_Id);
                await _auditService.LogActionAsync(
                    "Create Account", 
                    $"Account No: {account.AccNo}, Student: {student?.Fname} {student?.Surname}, Initial Balance: {account.AccBal}");
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id", "Fname", account.Student_Id);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id", "Fname", account.Student_Id);
            return View(account);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccNo,Student_Id,AccBal")] Account account)
        {
            if (id != account.AccNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                    
                    var student = await _context.Students.FindAsync(account.Student_Id);
                    await _auditService.LogActionAsync(
                        "Edit Account", 
                        $"Account No: {account.AccNo}, Student: {student?.Fname} {student?.Surname}, New Balance: {account.AccBal}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccNo))
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
            ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id", "Fname", account.Student_Id);
            return View(account);
        }

        // GET: Accounts/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AccNo == id);
                
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            
            await _auditService.LogActionAsync(
                "Delete Account", 
                $"Account No: {account.AccNo}, Student ID: {account.Student_Id}");
                
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.AccNo == id);
        }
    }
}