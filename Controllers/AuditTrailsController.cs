using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS_Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS_Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuditTrailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuditTrailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuditTrails
        public async Task<IActionResult> Index(string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["UserSortParm"] = sortOrder == "User" ? "user_desc" : "User";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "type_desc" : "Type";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var auditTrails = from a in _context.AuditTrails
                              select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                auditTrails = auditTrails.Where(a => 
                    a.Username.Contains(searchString) || 
                    a.TransactionTyp.Contains(searchString) ||
                    a.TransactionVal.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    auditTrails = auditTrails.OrderBy(a => a.DtTim);
                    break;
                case "date_desc":
                    auditTrails = auditTrails.OrderByDescending(a => a.DtTim);
                    break;
                case "User":
                    auditTrails = auditTrails.OrderBy(a => a.Username);
                    break;
                case "user_desc":
                    auditTrails = auditTrails.OrderByDescending(a => a.Username);
                    break;
                case "Type":
                    auditTrails = auditTrails.OrderBy(a => a.TransactionTyp);
                    break;
                case "type_desc":
                    auditTrails = auditTrails.OrderByDescending(a => a.TransactionTyp);
                    break;
                default:
                    auditTrails = auditTrails.OrderByDescending(a => a.DtTim);
                    break;
            }

            int pageSize = 20;
            return View(await PaginatedList<SIMS_Web.Models.AuditTrail>.CreateAsync(auditTrails.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: AuditTrails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditTrail = await _context.AuditTrails
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (auditTrail == null)
            {
                return NotFound();
            }

            return View(auditTrail);
        }
    }
}