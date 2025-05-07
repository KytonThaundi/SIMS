-- PostgreSQL seed data script for SIMS Web application
-- This script inserts sample data for testing

-- Connect to the sims database
\c sims postgres

-- Insert sample faculties
INSERT INTO "Faculty" ("Faculty_id", "FacultyName")
VALUES 
    ('FAC001', 'Faculty of Science and Technology'),
    ('FAC002', 'Faculty of Business and Economics'),
    ('FAC003', 'Faculty of Arts and Social Sciences');

-- Insert sample departments
INSERT INTO "Department" ("Dept_id", "DeptName", "Faculty_id")
VALUES 
    ('DEP001', 'Computer Science', 'FAC001'),
    ('DEP002', 'Mathematics', 'FAC001'),
    ('DEP003', 'Business Administration', 'FAC002'),
    ('DEP004', 'Economics', 'FAC002'),
    ('DEP005', 'English', 'FAC003'),
    ('DEP006', 'History', 'FAC003');

-- Insert sample programmes
INSERT INTO "Programme" ("Prog_id", "ProgName", "Faculty_id", "Dept_id", "Duration")
VALUES 
    ('PRG001', 'BSc Computer Science', 'FAC001', 'DEP001', '4 years'),
    ('PRG002', 'BSc Mathematics', 'FAC001', 'DEP002', '4 years'),
    ('PRG003', 'BBA Business Administration', 'FAC002', 'DEP003', '4 years'),
    ('PRG004', 'BA Economics', 'FAC002', 'DEP004', '3 years'),
    ('PRG005', 'BA English Literature', 'FAC003', 'DEP005', '3 years'),
    ('PRG006', 'BA History', 'FAC003', 'DEP006', '3 years');

-- Insert sample courses
INSERT INTO "Course" ("Course_id", "CourseName", "CreditHrs", "Prog_id", "Dept_id")
VALUES 
    ('CRS001', 'Introduction to Programming', 3, 'PRG001', 'DEP001'),
    ('CRS002', 'Data Structures and Algorithms', 4, 'PRG001', 'DEP001'),
    ('CRS003', 'Database Systems', 3, 'PRG001', 'DEP001'),
    ('CRS004', 'Calculus I', 3, 'PRG002', 'DEP002'),
    ('CRS005', 'Linear Algebra', 3, 'PRG002', 'DEP002'),
    ('CRS006', 'Principles of Management', 3, 'PRG003', 'DEP003'),
    ('CRS007', 'Marketing Management', 3, 'PRG003', 'DEP003'),
    ('CRS008', 'Microeconomics', 3, 'PRG004', 'DEP004'),
    ('CRS009', 'Macroeconomics', 3, 'PRG004', 'DEP004'),
    ('CRS010', 'English Composition', 3, 'PRG005', 'DEP005'),
    ('CRS011', 'World Literature', 3, 'PRG005', 'DEP005'),
    ('CRS012', 'World History', 3, 'PRG006', 'DEP006'),
    ('CRS013', 'Historical Research Methods', 3, 'PRG006', 'DEP006');

-- Insert sample students
INSERT INTO "Student" (
    "Student_Id", "Fname", "Surname", "Gender", 
    "ProgramOfStudy", "TOA", "Accommodation", "RegStatus", 
    "YOA", "EmailAddress", "MobileNo"
)
VALUES 
    ('STD001', 'John', 'Doe', 'Male', 'PRG001', 'Regular', 'On-Campus', 'Active', '2023', 'john.doe@example.com', '1234567890'),
    ('STD002', 'Jane', 'Smith', 'Female', 'PRG001', 'Regular', 'Off-Campus', 'Active', '2023', 'jane.smith@example.com', '2345678901'),
    ('STD003', 'Michael', 'Johnson', 'Male', 'PRG002', 'Regular', 'On-Campus', 'Active', '2022', 'michael.j@example.com', '3456789012'),
    ('STD004', 'Emily', 'Brown', 'Female', 'PRG003', 'Regular', 'Off-Campus', 'Active', '2022', 'emily.b@example.com', '4567890123'),
    ('STD005', 'David', 'Wilson', 'Male', 'PRG004', 'Regular', 'On-Campus', 'Active', '2021', 'david.w@example.com', '5678901234'),
    ('STD006', 'Sarah', 'Taylor', 'Female', 'PRG005', 'Regular', 'Off-Campus', 'Active', '2021', 'sarah.t@example.com', '6789012345');

-- Insert sample accounts
INSERT INTO "Accounts" ("AccNo", "Student_Id", "AccBal")
VALUES 
    ('ACC001', 'STD001', 5000.00),
    ('ACC002', 'STD002', 4500.00),
    ('ACC003', 'STD003', 3800.00),
    ('ACC004', 'STD004', 4200.00),
    ('ACC005', 'STD005', 3500.00),
    ('ACC006', 'STD006', 4100.00);

-- Insert sample academic years
INSERT INTO "AcademicYear" ("YrBegin", "YrEnd", "AcademicYear", "CurrentYear")
VALUES 
    ('2021-09-01', '2022-06-30', '2021/2022', FALSE),
    ('2022-09-01', '2023-06-30', '2022/2023', FALSE),
    ('2023-09-01', '2024-06-30', '2023/2024', TRUE);

-- Insert sample audit trail entries
INSERT INTO "AuditTrail" ("DtTim", "Username", "Usertyp", "IpAdd", "TransactionTyp", "TransactionVal")
VALUES 
    (NOW(), 'admin@sims.edu', 'Admin', '127.0.0.1', 'System Initialization', 'Database initialized with sample data'),
    (NOW(), 'admin@sims.edu', 'Admin', '127.0.0.1', 'User Creation', 'Created admin user');
