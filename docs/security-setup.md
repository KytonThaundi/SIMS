# Security Setup Guide

This document provides instructions for securely setting up the application without hardcoded credentials.

## User Secrets

For development, use .NET User Secrets to store sensitive information:

```bash
# Initialize user secrets
dotnet user-secrets init

# Set database connection string
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=sims;Username=your_username;Password=your_password;Trust Server Certificate=true;"

# Set admin user email
dotnet user-secrets set "AdminUser:Email" "admin@yourdomain.com"

# Set admin reset security code
dotnet user-secrets set "AdminReset:SecurityCode" "your-secure-reset-code"
```

## Environment Variables (Production)

For production environments, use environment variables:

```bash
# Linux/macOS
export ConnectionStrings__DefaultConnection="Host=localhost;Database=sims;Username=your_username;Password=your_password;Trust Server Certificate=true;"
export AdminUser__Email="admin@yourdomain.com"
export AdminReset__SecurityCode="your-secure-reset-code"

# Windows (PowerShell)
$env:ConnectionStrings__DefaultConnection="Host=localhost;Database=sims;Username=your_username;Password=your_password;Trust Server Certificate=true;"
$env:AdminUser__Email="admin@yourdomain.com"
$env:AdminReset__SecurityCode="your-secure-reset-code"
```

## Initial Admin User Setup

1. Configure the admin email in user secrets or environment variables as shown above.
2. Navigate to `/Account/CreateAdminUser` in your browser.
3. Enter a secure password and confirm it.
4. Submit the form to create the admin user.
5. You can now log in with the configured admin email and the password you set.

## Security Best Practices

1. **Use strong passwords**: At least 12 characters with a mix of uppercase, lowercase, numbers, and special characters.
2. **Change default security codes**: Always change the default security code for admin password resets.
3. **Restrict access to admin pages**: After initial setup, consider restricting access to the CreateAdminUser and ResetAdminPassword pages.
4. **Use HTTPS**: Always use HTTPS in production environments.
5. **Regular updates**: Keep the application and all dependencies up to date.
6. **Database user permissions**: Use a database user with minimal required permissions.
7. **Audit logging**: Monitor and review audit logs regularly.

## Removing Setup Pages After Initial Configuration

For security reasons, it's recommended to remove or restrict access to the admin setup pages after initial configuration:

1. Update the middleware in `Program.cs` to restrict access to these pages:

```csharp
// If the request is for admin setup pages, check if already configured
if (context.Request.Path.StartsWithSegments("/Account/CreateAdminUser") ||
    context.Request.Path.StartsWithSegments("/Account/ResetAdminPassword"))
{
    // Check if admin user already exists
    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var adminEmail = configuration["AdminUser:Email"];
    
    if (!string.IsNullOrEmpty(adminEmail))
    {
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser != null)
        {
            // Admin user exists, redirect to login
            context.Response.Redirect("/Account/Login");
            return;
        }
    }
}
```

2. Alternatively, you can comment out or remove these routes from the controller after initial setup.
