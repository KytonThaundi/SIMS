using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIMS.Web.Data;
using SIMS.Web.Models;
using SIMS.Web.Services;
using SIMS.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AuditService _auditService;

        public AdministrationController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AuditService auditService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _auditService = auditService;
        }

        // GET: Administration
        public async Task<IActionResult> Index()
        {
            var viewModel = new AdministrationDashboardViewModel
            {
                UserCount = await _userManager.Users.CountAsync(),
                StudentCount = await _context.Students.CountAsync(),
                ProgrammeCount = await _context.Programmes.CountAsync(),
                DepartmentCount = await _context.Departments.CountAsync(),
                FacultyCount = await _context.Faculties.CountAsync(),
                CourseCount = await _context.Courses.CountAsync()
            };

            return View(viewModel);
        }

        #region User Management

        // GET: Administration/Users
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = roles.ToList()
                });
            }

            return View(userViewModels);
        }

        // GET: Administration/CreateUser
        public async Task<IActionResult> CreateUser()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }

        // POST: Administration/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.Role))
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                    }

                    await _auditService.LogActionAsync(
                        "Create User",
                        $"Created user: {user.Email}, Role: {model.Role}");

                    return RedirectToAction(nameof(Users));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View(model);
        }

        // GET: Administration/EditUser/5
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.ToListAsync();

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                SelectedRoles = userRoles.ToList()
            };

            ViewBag.AllRoles = new MultiSelectList(allRoles, "Name", "Name", userRoles);
            return View(model);
        }

        // POST: Administration/EditUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Email = model.Email;
                user.UserName = model.Email;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Update roles
                    var userRoles = await _userManager.GetRolesAsync(user);
                    
                    // Remove existing roles
                    await _userManager.RemoveFromRolesAsync(user, userRoles);
                    
                    // Add selected roles
                    if (model.SelectedRoles != null && model.SelectedRoles.Any())
                    {
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                    }

                    await _auditService.LogActionAsync(
                        "Edit User",
                        $"Updated user: {user.Email}, Roles: {string.Join(", ", model.SelectedRoles ?? new List<string>())}");

                    return RedirectToAction(nameof(Users));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var allRoles = await _roleManager.Roles.ToListAsync();
            ViewBag.AllRoles = new MultiSelectList(allRoles, "Name", "Name", model.SelectedRoles);
            return View(model);
        }

        // GET: Administration/DeleteUser/5
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            
            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList()
            };

            return View(model);
        }

        // POST: Administration/DeleteUser/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _auditService.LogActionAsync(
                    "Delete User",
                    $"Deleted user: {user.Email}");

                return RedirectToAction(nameof(Users));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction(nameof(DeleteUser), new { id });
        }

        #endregion

        #region Students Management

        // GET: Administration/Students
        public async Task<IActionResult> Students()
        {
            var students = await _context.Students
                .Include(s => s.Programme)
                .ToListAsync();
            return View(students);
        }

        #endregion

        #region Programs Management

        // GET: Administration/Programs
        public async Task<IActionResult> Programs()
        {
            var programs = await _context.Programmes
                .Include(p => p.Faculty)
                .Include(p => p.Department)
                .ToListAsync();
            return View(programs);
        }

        #endregion

        #region Departments Management

        // GET: Administration/Departments
        public async Task<IActionResult> Departments()
        {
            var departments = await _context.Departments
                .Include(d => d.Faculty)
                .ToListAsync();
            return View(departments);
        }

        #endregion
    }
}
