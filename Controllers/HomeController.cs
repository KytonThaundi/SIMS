using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS_Web.Data;
using SIMS_Web.Models;
using System.Diagnostics;

namespace SIMS_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel
            {
                StudentCount = await _context.Students.CountAsync(),
                ProgrammeCount = await _context.Programmes.CountAsync(),
                FacultyCount = await _context.Faculties.CountAsync(),
                DepartmentCount = await _context.Departments.CountAsync(),
                CourseCount = await _context.Courses.CountAsync()
            };
            
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
    public class DashboardViewModel
    {
        public int StudentCount { get; set; }
        public int ProgrammeCount { get; set; }
        public int FacultyCount { get; set; }
        public int DepartmentCount { get; set; }
        public int CourseCount { get; set; }
    }
    
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }