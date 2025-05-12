using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SIMS.Web.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace SIMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ILogger<AccountController> logger,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            // If user is already signed in, redirect to home page
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // No special cases - authenticate directly against the database

            // Standard login process
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} logged in", model.Email);
                return RedirectToAction("Index", "Home");
            }

            // Login failed
            _logger.LogWarning("Failed login attempt for {Email}", model.Email);
            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your email and password.");
            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if user already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already registered.");
                return View(model);
            }

            // Create new user
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true // Auto-confirm email for simplicity
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Assign default role
                await _userManager.AddToRoleAsync(user, "Student");

                // Log success
                _logger.LogInformation("New user {Email} registered", model.Email);

                // Sign in the new user
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            // Registration failed
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            // Sign the user out
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out via POST");

            // Clear all cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // If returnUrl is specified and it's a local URL, redirect to it
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            // Otherwise redirect to login page
            return RedirectToAction("Login", "Account");
        }

        // GET: /Account/Logout (for convenience)
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogoutGet(string returnUrl = null)
        {
            // Sign the user out
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out via GET");

            // Clear all cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // If returnUrl is specified and it's a local URL, redirect to it
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            // Otherwise redirect to login page
            return RedirectToAction("Login", "Account");
        }

        // GET: /Account/AccessDenied
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: /Account/ResetAdminPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetAdminPassword()
        {
            _logger.LogInformation("ResetAdminPassword GET action called");
            return View();
        }

        // GET: /Account/TestDbConnection
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TestDbConnection()
        {
            _logger.LogInformation("TestDbConnection action called");

            try
            {
                // Test if we can access the database
                var adminEmail = _configuration["AdminUser:Email"] ?? "admin@example.com";
                var adminUser = await _userManager.FindByEmailAsync(adminEmail);

                var message = adminUser != null
                    ? $"Admin user found: {adminUser.Email}"
                    : "Admin user not found";

                // Get all roles
                var roles = await _userManager.GetRolesAsync(adminUser ?? new IdentityUser());

                return Content($"Database connection test: {message}. Roles: {string.Join(", ", roles)}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error testing database connection");
                return Content($"Database connection error: {ex.Message}");
            }
        }

        // GET: /Account/CreateAdminUser
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateAdminUser()
        {
            _logger.LogInformation("CreateAdminUser GET action called");
            return View();
        }

        // POST: /Account/CreateAdminUser
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdminUser(string password, string confirmPassword)
        {
            _logger.LogInformation("CreateAdminUser POST action called");

            if (string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessage"] = "Password is required.";
                return View();
            }

            if (password != confirmPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match.";
                return View();
            }

            if (password.Length < 6)
            {
                TempData["ErrorMessage"] = "Password must be at least 6 characters long.";
                return View();
            }

            try
            {
                // Only allow creating the admin user
                var adminEmail = _configuration["AdminUser:Email"];
                if (string.IsNullOrEmpty(adminEmail))
                {
                    _logger.LogError("Admin email not configured in settings");
                    TempData["ErrorMessage"] = "Admin email not configured. Please contact your system administrator.";
                    return View();
                }

                // Check if the admin user exists
                var adminUser = await _userManager.FindByEmailAsync(adminEmail);

                if (adminUser != null)
                {
                    // Reset the password for the existing admin user
                    var token = await _userManager.GeneratePasswordResetTokenAsync(adminUser);
                    var resetResult = await _userManager.ResetPasswordAsync(adminUser, token, password);

                    if (resetResult.Succeeded)
                    {
                        _logger.LogInformation("Admin password reset successful for {Email}", adminEmail);

                        TempData["SuccessMessage"] = "Admin password reset successful. You can now log in with the new password.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in resetResult.Errors)
                        {
                            TempData["ErrorMessage"] = error.Description;
                        }
                        return View();
                    }
                }
                else
                {
                    // Create the admin user if it doesn't exist
                    adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var createResult = await _userManager.CreateAsync(adminUser, password);

                    if (createResult.Succeeded)
                    {
                        // Check if Administrator role exists, create it if it doesn't
                        var roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
                        if (!await roleManager.RoleExistsAsync("Administrator"))
                        {
                            _logger.LogInformation("Creating Administrator role");
                            await roleManager.CreateAsync(new IdentityRole("Administrator"));
                        }

                        await _userManager.AddToRoleAsync(adminUser, "Administrator");
                        _logger.LogInformation("Created admin user {Email} with new password", adminEmail);

                        TempData["SuccessMessage"] = "Admin user created successfully with the new password.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in createResult.Errors)
                        {
                            TempData["ErrorMessage"] = error.Description;
                        }
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating admin user");
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

        // POST: /Account/ResetAdminPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetAdminPassword(ResetAdminPasswordViewModel model)
        {
            _logger.LogInformation("ResetAdminPassword POST action called with model: {@Model}", new {
                PasswordLength = model.NewPassword?.Length,
                ConfirmPasswordLength = model.ConfirmNewPassword?.Length,
                SecurityCode = model.SecurityCode
            });

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid: {@ModelStateErrors}", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return View(model);
            }

            // Verify the security code
            var expectedSecurityCode = _configuration["AdminReset:SecurityCode"];
            if (string.IsNullOrEmpty(expectedSecurityCode) || model.SecurityCode != expectedSecurityCode)
            {
                _logger.LogWarning("Invalid security code provided or security code not configured");
                ModelState.AddModelError(string.Empty, "Invalid security code. Please contact your system administrator.");
                return View(model);
            }

            // Only allow resetting the admin password
            var adminEmail = _configuration["AdminUser:Email"];
            if (string.IsNullOrEmpty(adminEmail))
            {
                _logger.LogError("Admin email not configured in settings");
                ModelState.AddModelError(string.Empty, "Admin email not configured. Please contact your system administrator.");
                return View(model);
            }

            // Check if the admin user exists
            _logger.LogInformation("Checking if admin user exists: {Email}", adminEmail);
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            _logger.LogInformation("Admin user exists: {Exists}", adminUser != null);

            if (adminUser == null)
            {
                _logger.LogInformation("Creating new admin user: {Email}", adminEmail);
                // Create the admin user if it doesn't exist
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                _logger.LogInformation("Calling UserManager.CreateAsync for {Email}", adminEmail);

                // Make sure the password is not null
                if (string.IsNullOrEmpty(model.NewPassword))
                {
                    _logger.LogWarning("NewPassword is null or empty");
                    ModelState.AddModelError(string.Empty, "Password cannot be empty.");
                    return View(model);
                }

                var createResult = await _userManager.CreateAsync(adminUser, model.NewPassword);
                _logger.LogInformation("UserManager.CreateAsync result: {Succeeded}", createResult.Succeeded);

                if (createResult.Succeeded)
                {
                    // Check if Administrator role exists, create it if it doesn't
                    var roleManager = HttpContext.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
                    if (!await roleManager.RoleExistsAsync("Administrator"))
                    {
                        _logger.LogInformation("Creating Administrator role");
                        await roleManager.CreateAsync(new IdentityRole("Administrator"));
                    }

                    _logger.LogInformation("Adding Administrator role to user {Email}", adminEmail);
                    await _userManager.AddToRoleAsync(adminUser, "Administrator");
                    _logger.LogInformation("Created admin user {Email} with new password", adminEmail);

                    TempData["SuccessMessage"] = "Admin user created successfully with the new password.";
                    return RedirectToAction("Login");
                }
                else
                {
                    _logger.LogWarning("Failed to create admin user {Email}. Errors: {@Errors}",
                        adminEmail, createResult.Errors.Select(e => e.Description));
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }
            else
            {
                _logger.LogInformation("Resetting password for existing admin user: {Email}", adminEmail);
                // Reset the password for the existing admin user
                _logger.LogInformation("Generating password reset token for {Email}", adminEmail);
                var token = await _userManager.GeneratePasswordResetTokenAsync(adminUser);
                _logger.LogInformation("Token generated for {Email}, token length: {TokenLength}", adminEmail, token?.Length);

                _logger.LogInformation("Calling ResetPasswordAsync for {Email}", adminEmail);

                // Make sure the password and token are not null
                if (string.IsNullOrEmpty(model.NewPassword))
                {
                    _logger.LogWarning("NewPassword is null or empty");
                    ModelState.AddModelError(string.Empty, "Password cannot be empty.");
                    return View(model);
                }

                if (string.IsNullOrEmpty(token))
                {
                    _logger.LogWarning("Token is null or empty");
                    ModelState.AddModelError(string.Empty, "Failed to generate password reset token. Please try again.");
                    return View(model);
                }

                var resetResult = await _userManager.ResetPasswordAsync(adminUser, token, model.NewPassword);
                _logger.LogInformation("ResetPasswordAsync result: {Succeeded}", resetResult.Succeeded);

                if (resetResult.Succeeded)
                {
                    _logger.LogInformation("Admin password reset successful for {Email}", adminEmail);

                    TempData["SuccessMessage"] = "Admin password reset successful. You can now log in with the new password.";
                    return RedirectToAction("Login");
                }
                else
                {
                    _logger.LogWarning("Failed to reset password for admin user {Email}. Errors: {@Errors}",
                        adminEmail, resetResult.Errors.Select(e => e.Description));
                    foreach (var error in resetResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }
        }
    }
}
