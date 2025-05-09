using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIMS_Web.Data;
using SIMS_Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Npgsql with custom options
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.ConfigureNpgsqlOptions(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;

    // Configure lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Configure application cookie
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);

    // Add cookie events to handle redirects
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            // Redirect to login page
            context.Response.Redirect("/Account/Login");
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register custom services
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<DataMigrationService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Add middleware to redirect users to login page for root URL and unauthenticated requests
app.Use(async (context, next) =>
{
    // If the request is for the root URL, redirect to login page
    if (context.Request.Path == "/" || context.Request.Path == "")
    {
        context.Response.Redirect("/Account/Login");
        return;
    }

    // If the request is for the login page or static files, proceed
    if (context.Request.Path.StartsWithSegments("/Account/Login") ||
        context.Request.Path.StartsWithSegments("/Account/Register") ||
        context.Request.Path.StartsWithSegments("/css") ||
        context.Request.Path.StartsWithSegments("/js") ||
        context.Request.Path.StartsWithSegments("/lib") ||
        context.Request.Path.StartsWithSegments("/images"))
    {
        await next();
        return;
    }

    // Check if the user is authenticated
    if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
    {
        // Redirect to login page
        context.Response.Redirect("/Account/Login");
        return;
    }

    await next();
});

// Ensure the default route is Account/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.MapRazorPages();

// Initialize roles and admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure database is created
        context.Database.EnsureCreated();

        // Initialize roles
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            roleManager.CreateAsync(new IdentityRole("Staff")).Wait();
            roleManager.CreateAsync(new IdentityRole("Student")).Wait();

            // Create admin user
            var adminUser = new IdentityUser
            {
                UserName = "admin@sims.edu",
                Email = "admin@sims.edu",
                EmailConfirmed = true
            };

            var result = userManager.CreateAsync(adminUser, "Admin123!").Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.Run();