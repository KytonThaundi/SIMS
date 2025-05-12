# University Student Information Management System (SIMS)

A modern web-based Student Information Management System built with ASP.NET Core and Tailwind CSS for Mombera University.

![University SIMS](wwwroot/images/sims-logo.png)

## Overview

The Student Information Management System (SIMS) is a comprehensive web application designed to manage student records, academic programs, faculty information, and financial accounts. It provides an intuitive interface for administrators, staff, and students to access and manage university data.

## Features

- **User Authentication & Authorization**
  - Role-based access control (Admin, Staff, Student)
  - Secure login and registration
  - Password recovery options

- **Student Management**
  - Create, view, update, and delete student records
  - Track student personal information
  - Manage enrollment status

- **Academic Program Management**
  - Manage faculties, departments, and programs
  - Course catalog and curriculum management
  - Academic year configuration

- **Financial Management**
  - Student account tracking
  - Balance management
  - Financial record keeping

- **Reporting & Analytics**
  - Dashboard with key metrics
  - Customizable reports
  - Data visualization

- **Administration Panel**
  - User management (create, edit, delete users)
  - Role assignment and permissions
  - System-wide configuration
  - Centralized management interface

- **Audit Trail**
  - Track all system changes
  - User activity logging
  - Security monitoring

## Technology Stack

- **Backend**
  - ASP.NET Core 9.0
  - Entity Framework Core
  - PostgreSQL Database
  - Identity Framework for authentication

- **Frontend**
  - Tailwind CSS
  - HTML5/CSS3
  - JavaScript
  - Font Awesome icons

## Prerequisites

- .NET 9.0 SDK or later
- PostgreSQL 13 or later
- Node.js and npm (for Tailwind CSS)

## Getting Started

### Database Setup

1. Install PostgreSQL if not already installed
2. Create a new database named `sims`
3. Create a dedicated PostgreSQL user for the application:

```sql
CREATE USER simsuser WITH PASSWORD 'simspassword';
GRANT ALL PRIVILEGES ON DATABASE sims TO simsuser;
\c sims
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO simsuser;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO simsuser;
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO simsuser;
GRANT CREATE ON SCHEMA public TO simsuser;
```

4. Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=sims;Username=simsuser;Password=simspassword;Trust Server Certificate=true;"
}
```

For security reasons, it's recommended to use user secrets for storing sensitive information:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=sims;Username=simsuser;Password=simspassword;Trust Server Certificate=true;"
dotnet user-secrets set "AdminUser:Email" "admin@system.com"
dotnet user-secrets set "AdminReset:SecurityCode" "your-secure-reset-code"
```

### Troubleshooting Database Connection

If you encounter the error `28P01: password authentication failed for user "postgres"`, try the following:

1. Verify your PostgreSQL credentials are correct
2. Create a dedicated database user as shown above
3. Check PostgreSQL's `pg_hba.conf` file for authentication method settings
4. Ensure the database exists and the user has appropriate permissions
5. Test the connection using a simple console application before running the full application

### Application Setup

1. Clone the repository:
```bash
git clone https://github.com/yourusername/mombera-sims.git
cd mombera-sims
```

2. Install the .NET dependencies:
```bash
dotnet restore
```

3. Install the frontend dependencies:
```bash
npm install
```

4. Build the Tailwind CSS:
```bash
npm run build:css
```

5. Apply database migrations:
```bash
dotnet ef database update
```

6. Run the application:
```bash
dotnet run
```

7. Access the application at `https://localhost:5001` or `http://localhost:5000`

### Authentication

The system uses database authentication for user login. Users must be registered in the database before they can log in.

#### Default Admin User

The database backup contains an admin user with the following credentials:
- Email: admin@system.com

To log in as this user, you'll need to:
1. Restore the database backup from 'C:\www\dbSIMS_backup_28.09.2017_SIMS.BAK'
2. Use the password associated with this account in the database

#### User Registration

New users can register through the registration form. When a new user registers:
1. Their information is stored in the database
2. They are assigned the "Student" role by default
3. They can immediately log in with their credentials

### Administration Panel

The system includes a comprehensive administration panel accessible to users with the "Administrator" role. To access the administration panel:

1. Log in with an administrator account
2. Click on the "Administration" link in the sidebar navigation

The administration panel provides the following features:

- **Dashboard**: Overview of system statistics (users, students, programs, etc.)
- **User Management**: Create, edit, and delete users; assign roles
- **Student Management**: Centralized student record management
- **Program Management**: Manage academic programs
- **Department Management**: Manage university departments

Administrators can create new users with specific roles (Administrator, Staff, Student) and manage all aspects of the system from this centralized interface.

## Project Structure

- **Controllers/** - Contains all the application controllers
- **Models/** - Data models and view models
- **Views/** - Razor views for the UI
- **Data/** - Database context and configurations
- **Services/** - Business logic and services
- **wwwroot/** - Static files (CSS, JS, images)
- **Scripts/** - Database scripts and utilities
- **ViewModels/** - View-specific models
- **docs/** - Documentation files

## Project Map

### Core Components

```
SIMS/
├── Program.cs                 # Application entry point and configuration
├── appsettings.json           # Application settings
├── appsettings.Development.json # Development-specific settings
└── SIMS.Web.csproj            # Project file
```

### Controllers

```
Controllers/
├── AccountController.cs       # Authentication and user account management
├── AccountsController.cs      # Student financial accounts management
├── AdministrationController.cs # Admin dashboard and user management
├── CoursesController.cs       # Course management
├── DepartmentsController.cs   # Department management
├── FacultiesController.cs     # Faculty management
├── HomeController.cs          # Main dashboard and home page
├── ProgrammesController.cs    # Academic programs management
└── StudentsController.cs      # Student records management
```

### Models

```
Models/
├── Account.cs                 # Student financial account
├── AcademicYear.cs            # Academic year configuration
├── AuditTrail.cs              # System audit logging
├── Course.cs                  # Academic course
├── Department.cs              # University department
├── ErrorViewModel.cs          # Error handling
├── Faculty.cs                 # University faculty
├── LoginViewModel.cs          # Login form model
├── Programme.cs               # Academic program
├── RegisterViewModel.cs       # Registration form model
└── Student.cs                 # Student information
```

### ViewModels

```
ViewModels/
├── AdministrationViewModels.cs # Admin dashboard and user management models
├── CreateUserViewModel.cs      # User creation form model
├── DashboardViewModel.cs       # Home dashboard data model
├── EditUserViewModel.cs        # User editing form model
├── ResetAdminPasswordViewModel.cs # Admin password reset model
└── UserViewModel.cs            # User display model
```

### Views

```
Views/
├── Account/                   # Authentication views
│   ├── Login.cshtml           # Login page
│   ├── Register.cshtml        # Registration page
│   ├── CreateAdminUser.cshtml # Admin user creation
│   └── ResetAdminPassword.cshtml # Admin password reset
├── Accounts/                  # Financial accounts views
├── Administration/            # Admin panel views
│   ├── Index.cshtml           # Admin dashboard
│   ├── Users.cshtml           # User management
│   ├── Students.cshtml        # Student management
│   ├── Programs.cshtml        # Program management
│   └── Departments.cshtml     # Department management
├── Courses/                   # Course management views
├── Departments/               # Department management views
├── Faculties/                 # Faculty management views
├── Home/                      # Main application views
│   └── Index.cshtml           # Dashboard
├── Programmes/                # Program management views
├── Shared/                    # Shared layout components
│   ├── _Layout.cshtml         # Main application layout
│   ├── _LoginLayout.cshtml    # Authentication pages layout
│   └── _ValidationScriptsPartial.cshtml # Form validation scripts
└── Students/                  # Student management views
```

### Data

```
Data/
├── ApplicationDbContext.cs    # Entity Framework database context
├── IdentityUserConfiguration.cs # User identity configuration
└── PostgreSqlDbContextOptionsExtensions.cs # PostgreSQL configuration
```

### Services

```
Services/
├── AuditService.cs            # System audit logging service
└── DataMigrationService.cs    # Database migration utilities
```

### Static Files

```
wwwroot/
├── css/                       # Stylesheets
│   ├── tailwind.css           # Compiled Tailwind CSS
│   └── site.css               # Custom styles
├── js/                        # JavaScript files
│   └── site.js                # Custom scripts
├── lib/                       # Third-party libraries
│   ├── jquery/                # jQuery
│   └── bootstrap/             # Bootstrap components
└── images/                    # Image assets
    └── sims-logo.png          # Application logo
```

### Database Scripts

```
Scripts/
├── create_database.sql        # Database creation script
├── create_tables.sql          # Table creation script
├── seed_data.sql              # Initial data seeding
├── initialize_database.sh     # Database initialization script
└── create_db_instructions.md  # Database setup instructions
```

### Documentation

```
docs/
└── security-setup.md          # Security configuration guide
```

## Development

### Building CSS

During development, you can watch for CSS changes:

```bash
npm run watch:css
```

### Database Migrations

To create a new migration after model changes:

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Customization

### Branding

The application is branded for Mombera University. To customize:

1. Update the logo in `wwwroot/images/`
2. Modify the color scheme in `wwwroot/css/site.css` and `tailwind.config.js`
3. Update university name references in views

### Theme Colors

The main theme colors are:
- Primary: Turquoise (`#20B2AA`)
- Footer: Charcoal (`#36454F`)
- Accent: Amber (`#F59E0B`)

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature-name`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature-name`
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- ASP.NET Core team
- Tailwind CSS team
- Font Awesome for icons
- All contributors to the project
