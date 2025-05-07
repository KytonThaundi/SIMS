-- PostgreSQL table creation script for SIMS Web application
-- This script creates all the necessary tables based on the models

-- Connect to the sims database
\c sims postgres

-- Create Faculty table
CREATE TABLE "Faculty" (
    "Faculty_id" VARCHAR(50) PRIMARY KEY,
    "FacultyName" VARCHAR(100) NOT NULL
);

-- Create Department table
CREATE TABLE "Department" (
    "Dept_id" VARCHAR(50) PRIMARY KEY,
    "DeptName" VARCHAR(100) NOT NULL,
    "Faculty_id" VARCHAR(50) NOT NULL,
    FOREIGN KEY ("Faculty_id") REFERENCES "Faculty" ("Faculty_id")
);

-- Create Programme table
CREATE TABLE "Programme" (
    "Prog_id" VARCHAR(50) PRIMARY KEY,
    "ProgName" VARCHAR(100) NOT NULL,
    "Faculty_id" VARCHAR(50) NOT NULL,
    "Dept_id" VARCHAR(50) NOT NULL,
    "Duration" VARCHAR(50) NOT NULL,
    FOREIGN KEY ("Faculty_id") REFERENCES "Faculty" ("Faculty_id"),
    FOREIGN KEY ("Dept_id") REFERENCES "Department" ("Dept_id")
);

-- Create Student table
CREATE TABLE "Student" (
    "Student_Id" VARCHAR(50) PRIMARY KEY,
    "Fname" VARCHAR(100) NOT NULL,
    "Surname" VARCHAR(100) NOT NULL,
    "OtherName" VARCHAR(100),
    "DOB" DATE,
    "Gender" VARCHAR(10) NOT NULL,
    "HomeVillage" VARCHAR(100),
    "TradAuth" VARCHAR(100),
    "District" VARCHAR(100),
    "Nationality" VARCHAR(100),
    "PostalAddress" VARCHAR(200),
    "EmailAddress" VARCHAR(100),
    "MobileNo" VARCHAR(20),
    "CurResi" VARCHAR(100),
    "ProgramOfStudy" VARCHAR(50) NOT NULL,
    "YOA" VARCHAR(10),
    "TOA" VARCHAR(50),
    "Accommodation" VARCHAR(50),
    "RegStatus" VARCHAR(50),
    FOREIGN KEY ("ProgramOfStudy") REFERENCES "Programme" ("Prog_id")
);

-- Create Course table
CREATE TABLE "Course" (
    "Course_id" VARCHAR(50) PRIMARY KEY,
    "CourseName" VARCHAR(100) NOT NULL,
    "CreditHrs" INTEGER NOT NULL,
    "Prog_id" VARCHAR(50),
    "Dept_id" VARCHAR(50),
    FOREIGN KEY ("Prog_id") REFERENCES "Programme" ("Prog_id"),
    FOREIGN KEY ("Dept_id") REFERENCES "Department" ("Dept_id")
);

-- Create Accounts table
CREATE TABLE "Accounts" (
    "AccNo" VARCHAR(50) PRIMARY KEY,
    "Student_Id" VARCHAR(50) NOT NULL,
    "AccBal" DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY ("Student_Id") REFERENCES "Student" ("Student_Id")
);

-- Create AcademicYear table
CREATE TABLE "AcademicYear" (
    "Id" SERIAL PRIMARY KEY,
    "YrBegin" DATE NOT NULL,
    "YrEnd" DATE NOT NULL,
    "AcademicYear" VARCHAR(20) NOT NULL,
    "CurrentYear" BOOLEAN NOT NULL
);

-- Create AuditTrail table
CREATE TABLE "AuditTrail" (
    "Id" SERIAL PRIMARY KEY,
    "DtTim" TIMESTAMP NOT NULL,
    "Username" VARCHAR(100) NOT NULL,
    "Usertyp" VARCHAR(50) NOT NULL,
    "IpAdd" VARCHAR(50) NOT NULL,
    "TransactionTyp" VARCHAR(100) NOT NULL,
    "TransactionVal" TEXT NOT NULL
);

-- Create ASP.NET Identity tables
CREATE TABLE "AspNetRoles" (
    "Id" TEXT PRIMARY KEY,
    "Name" VARCHAR(256),
    "NormalizedName" VARCHAR(256),
    "ConcurrencyStamp" TEXT
);

CREATE TABLE "AspNetUsers" (
    "Id" TEXT PRIMARY KEY,
    "UserName" VARCHAR(256),
    "NormalizedUserName" VARCHAR(256),
    "Email" VARCHAR(256),
    "NormalizedEmail" VARCHAR(256),
    "EmailConfirmed" BOOLEAN NOT NULL,
    "PasswordHash" TEXT,
    "SecurityStamp" TEXT,
    "ConcurrencyStamp" TEXT,
    "PhoneNumber" TEXT,
    "PhoneNumberConfirmed" BOOLEAN NOT NULL,
    "TwoFactorEnabled" BOOLEAN NOT NULL,
    "LockoutEnd" TIMESTAMP,
    "LockoutEnabled" BOOLEAN NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" SERIAL PRIMARY KEY,
    "RoleId" TEXT NOT NULL,
    "ClaimType" TEXT,
    "ClaimValue" TEXT,
    FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" SERIAL PRIMARY KEY,
    "UserId" TEXT NOT NULL,
    "ClaimType" TEXT,
    "ClaimValue" TEXT,
    FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" VARCHAR(128) NOT NULL,
    "ProviderKey" VARCHAR(128) NOT NULL,
    "ProviderDisplayName" TEXT,
    "UserId" TEXT NOT NULL,
    PRIMARY KEY ("LoginProvider", "ProviderKey"),
    FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    PRIMARY KEY ("UserId", "RoleId"),
    FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" TEXT NOT NULL,
    "LoginProvider" VARCHAR(128) NOT NULL,
    "Name" VARCHAR(128) NOT NULL,
    "Value" TEXT,
    PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

-- Insert default roles
INSERT INTO "AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp")
VALUES 
    (uuid_generate_v4()::text, 'Admin', 'ADMIN', uuid_generate_v4()::text),
    (uuid_generate_v4()::text, 'Staff', 'STAFF', uuid_generate_v4()::text),
    (uuid_generate_v4()::text, 'Student', 'STUDENT', uuid_generate_v4()::text);

-- Create admin user (password needs to be hashed properly in a real scenario)
INSERT INTO "AspNetUsers" (
    "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", 
    "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp",
    "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", 
    "LockoutEnabled", "AccessFailedCount"
)
VALUES (
    uuid_generate_v4()::text, 
    'admin@sims.edu', 
    'ADMIN@SIMS.EDU', 
    'admin@sims.edu', 
    'ADMIN@SIMS.EDU',
    TRUE, 
    'AQAAAAEAACcQAAAAEHxSfsg9S5iqBQEKAj36jRwSHmwcw4N5rvVt3+bFGXSxvYmgx3rT8N/4OEtJ+H+Kug==', -- This is a placeholder hash for 'Admin123!'
    uuid_generate_v4()::text, 
    uuid_generate_v4()::text,
    NULL, 
    FALSE, 
    FALSE, 
    FALSE, 
    0
);

-- Add admin user to Admin role
INSERT INTO "AspNetUserRoles" ("UserId", "RoleId")
SELECT u."Id", r."Id"
FROM "AspNetUsers" u, "AspNetRoles" r
WHERE u."Email" = 'admin@sims.edu' AND r."Name" = 'Admin';
