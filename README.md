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
3. Update the connection string in `appsettings.json` if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=sims;Username=your_username;Password=your_password;Trust Server Certificate=true;"
}
```

For security reasons, it's recommended to use user secrets for storing sensitive information:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=sims;Username=your_username;Password=your_password;Trust Server Certificate=true;"
dotnet user-secrets set "AdminUser:Email" "admin@yourdomain.com"
dotnet user-secrets set "AdminReset:SecurityCode" "your-secure-reset-code"
```

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

## Project Structure

- **Controllers/** - Contains all the application controllers
- **Models/** - Data models and view models
- **Views/** - Razor views for the UI
- **Data/** - Database context and configurations
- **Services/** - Business logic and services
- **wwwroot/** - Static files (CSS, JS, images)
- **Scripts/** - Database scripts and utilities

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
