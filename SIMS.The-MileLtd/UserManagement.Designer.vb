<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserManagement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxUM = New System.Windows.Forms.GroupBox()
        Me.gpbAccessRights = New System.Windows.Forms.GroupBox()
        Me.gpbrights = New System.Windows.Forms.GroupBox()
        Me.AddLecturer = New System.Windows.Forms.CheckBox()
        Me.DataView = New System.Windows.Forms.CheckBox()
        Me.SystemBackup = New System.Windows.Forms.CheckBox()
        Me.UserAccess = New System.Windows.Forms.CheckBox()
        Me.AddStudent = New System.Windows.Forms.CheckBox()
        Me.ExamNum = New System.Windows.Forms.CheckBox()
        Me.Attendance = New System.Windows.Forms.CheckBox()
        Me.AccStatement = New System.Windows.Forms.CheckBox()
        Me.ReceivePayment = New System.Windows.Forms.CheckBox()
        Me.GeneralLedger = New System.Windows.Forms.CheckBox()
        Me.PostAnnouncements = New System.Windows.Forms.CheckBox()
        Me.Uploadgrades = New System.Windows.Forms.CheckBox()
        Me.Library = New System.Windows.Forms.CheckBox()
        Me.Courses = New System.Windows.Forms.CheckBox()
        Me.AddAssignmnet = New System.Windows.Forms.CheckBox()
        Me.GradeBook = New System.Windows.Forms.CheckBox()
        Me.StudentProfile = New System.Windows.Forms.CheckBox()
        Me.MajorCourses = New System.Windows.Forms.CheckBox()
        Me.CheckAssignment = New System.Windows.Forms.CheckBox()
        Me.TuitionSettings = New System.Windows.Forms.CheckBox()
        Me.Classes = New System.Windows.Forms.CheckBox()
        Me.SelectAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUMPword = New System.Windows.Forms.TextBox()
        Me.txtUMusername = New System.Windows.Forms.TextBox()
        Me.lbUT = New System.Windows.Forms.Label()
        Me.txtUMConfPword = New System.Windows.Forms.TextBox()
        Me.cmbxtyp = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCustome = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.gpbviewRights = New System.Windows.Forms.GroupBox()
        Me.dgvusers = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchUser = New System.Windows.Forms.TextBox()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.btnUMSave = New System.Windows.Forms.Button()
        Me.btnEditUser = New System.Windows.Forms.Button()
        Me.btnDelUser = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnUMView = New System.Windows.Forms.Button()
        Me.btnNewUser = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.setTimetable = New System.Windows.Forms.CheckBox()
        Me.GroupBoxUM.SuspendLayout()
        Me.gpbAccessRights.SuspendLayout()
        Me.gpbrights.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpbviewRights.SuspendLayout()
        CType(Me.dgvusers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxUM
        '
        Me.GroupBoxUM.Controls.Add(Me.gpbviewRights)
        Me.GroupBoxUM.Controls.Add(Me.gpbAccessRights)
        Me.GroupBoxUM.Location = New System.Drawing.Point(1, -5)
        Me.GroupBoxUM.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBoxUM.Name = "GroupBoxUM"
        Me.GroupBoxUM.Size = New System.Drawing.Size(657, 450)
        Me.GroupBoxUM.TabIndex = 32
        Me.GroupBoxUM.TabStop = False
        '
        'gpbAccessRights
        '
        Me.gpbAccessRights.Controls.Add(Me.gpbrights)
        Me.gpbAccessRights.Controls.Add(Me.GroupBox1)
        Me.gpbAccessRights.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.gpbAccessRights.Location = New System.Drawing.Point(0, 7)
        Me.gpbAccessRights.Name = "gpbAccessRights"
        Me.gpbAccessRights.Size = New System.Drawing.Size(655, 442)
        Me.gpbAccessRights.TabIndex = 36
        Me.gpbAccessRights.TabStop = False
        '
        'gpbrights
        '
        Me.gpbrights.Controls.Add(Me.setTimetable)
        Me.gpbrights.Controls.Add(Me.AddLecturer)
        Me.gpbrights.Controls.Add(Me.DataView)
        Me.gpbrights.Controls.Add(Me.SystemBackup)
        Me.gpbrights.Controls.Add(Me.UserAccess)
        Me.gpbrights.Controls.Add(Me.AddStudent)
        Me.gpbrights.Controls.Add(Me.ExamNum)
        Me.gpbrights.Controls.Add(Me.Attendance)
        Me.gpbrights.Controls.Add(Me.AccStatement)
        Me.gpbrights.Controls.Add(Me.ReceivePayment)
        Me.gpbrights.Controls.Add(Me.GeneralLedger)
        Me.gpbrights.Controls.Add(Me.PostAnnouncements)
        Me.gpbrights.Controls.Add(Me.Uploadgrades)
        Me.gpbrights.Controls.Add(Me.Library)
        Me.gpbrights.Controls.Add(Me.Courses)
        Me.gpbrights.Controls.Add(Me.AddAssignmnet)
        Me.gpbrights.Controls.Add(Me.GradeBook)
        Me.gpbrights.Controls.Add(Me.StudentProfile)
        Me.gpbrights.Controls.Add(Me.MajorCourses)
        Me.gpbrights.Controls.Add(Me.CheckAssignment)
        Me.gpbrights.Controls.Add(Me.TuitionSettings)
        Me.gpbrights.Controls.Add(Me.Classes)
        Me.gpbrights.Controls.Add(Me.SelectAll)
        Me.gpbrights.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbrights.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.gpbrights.Location = New System.Drawing.Point(6, 148)
        Me.gpbrights.Name = "gpbrights"
        Me.gpbrights.Size = New System.Drawing.Size(640, 247)
        Me.gpbrights.TabIndex = 50
        Me.gpbrights.TabStop = False
        Me.gpbrights.Text = "Access Rights"
        '
        'AddLecturer
        '
        Me.AddLecturer.AutoSize = True
        Me.AddLecturer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddLecturer.Location = New System.Drawing.Point(143, 218)
        Me.AddLecturer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AddLecturer.Name = "AddLecturer"
        Me.AddLecturer.Size = New System.Drawing.Size(102, 21)
        Me.AddLecturer.TabIndex = 50
        Me.AddLecturer.Text = "Add Lecturer"
        Me.AddLecturer.UseVisualStyleBackColor = True
        '
        'DataView
        '
        Me.DataView.AutoSize = True
        Me.DataView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataView.Location = New System.Drawing.Point(309, 189)
        Me.DataView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataView.Name = "DataView"
        Me.DataView.Size = New System.Drawing.Size(91, 21)
        Me.DataView.TabIndex = 49
        Me.DataView.Text = "Data Views"
        Me.DataView.UseVisualStyleBackColor = True
        '
        'SystemBackup
        '
        Me.SystemBackup.AutoSize = True
        Me.SystemBackup.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemBackup.Location = New System.Drawing.Point(309, 151)
        Me.SystemBackup.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SystemBackup.Name = "SystemBackup"
        Me.SystemBackup.Size = New System.Drawing.Size(113, 21)
        Me.SystemBackup.TabIndex = 45
        Me.SystemBackup.Text = "System Backup"
        Me.SystemBackup.UseVisualStyleBackColor = True
        '
        'UserAccess
        '
        Me.UserAccess.AutoSize = True
        Me.UserAccess.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserAccess.Location = New System.Drawing.Point(489, 189)
        Me.UserAccess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UserAccess.Name = "UserAccess"
        Me.UserAccess.Size = New System.Drawing.Size(106, 21)
        Me.UserAccess.TabIndex = 46
        Me.UserAccess.Text = "Access Rights"
        Me.UserAccess.UseVisualStyleBackColor = True
        '
        'AddStudent
        '
        Me.AddStudent.AutoSize = True
        Me.AddStudent.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddStudent.Location = New System.Drawing.Point(24, 151)
        Me.AddStudent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AddStudent.Name = "AddStudent"
        Me.AddStudent.Size = New System.Drawing.Size(99, 21)
        Me.AddStudent.TabIndex = 48
        Me.AddStudent.Text = "Add Student"
        Me.AddStudent.UseVisualStyleBackColor = True
        '
        'ExamNum
        '
        Me.ExamNum.AutoSize = True
        Me.ExamNum.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExamNum.Location = New System.Drawing.Point(143, 151)
        Me.ExamNum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ExamNum.Name = "ExamNum"
        Me.ExamNum.Size = New System.Drawing.Size(158, 21)
        Me.ExamNum.TabIndex = 47
        Me.ExamNum.Text = "Assign Exam Numbers"
        Me.ExamNum.UseVisualStyleBackColor = True
        '
        'Attendance
        '
        Me.Attendance.AutoSize = True
        Me.Attendance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Attendance.Location = New System.Drawing.Point(489, 110)
        Me.Attendance.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Attendance.Name = "Attendance"
        Me.Attendance.Size = New System.Drawing.Size(92, 21)
        Me.Attendance.TabIndex = 44
        Me.Attendance.Text = "Attendance"
        Me.Attendance.UseVisualStyleBackColor = True
        '
        'AccStatement
        '
        Me.AccStatement.AutoSize = True
        Me.AccStatement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccStatement.Location = New System.Drawing.Point(489, 151)
        Me.AccStatement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AccStatement.Name = "AccStatement"
        Me.AccStatement.Size = New System.Drawing.Size(135, 21)
        Me.AccStatement.TabIndex = 41
        Me.AccStatement.Text = "Account Statement"
        Me.AccStatement.UseVisualStyleBackColor = True
        '
        'ReceivePayment
        '
        Me.ReceivePayment.AutoSize = True
        Me.ReceivePayment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReceivePayment.Location = New System.Drawing.Point(143, 189)
        Me.ReceivePayment.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ReceivePayment.Name = "ReceivePayment"
        Me.ReceivePayment.Size = New System.Drawing.Size(124, 21)
        Me.ReceivePayment.TabIndex = 42
        Me.ReceivePayment.Text = "Receive Payment"
        Me.ReceivePayment.UseVisualStyleBackColor = True
        '
        'GeneralLedger
        '
        Me.GeneralLedger.AutoSize = True
        Me.GeneralLedger.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLedger.Location = New System.Drawing.Point(24, 189)
        Me.GeneralLedger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GeneralLedger.Name = "GeneralLedger"
        Me.GeneralLedger.Size = New System.Drawing.Size(117, 21)
        Me.GeneralLedger.TabIndex = 43
        Me.GeneralLedger.Text = "General Ledger"
        Me.GeneralLedger.UseVisualStyleBackColor = True
        '
        'PostAnnouncements
        '
        Me.PostAnnouncements.AutoSize = True
        Me.PostAnnouncements.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PostAnnouncements.Location = New System.Drawing.Point(309, 110)
        Me.PostAnnouncements.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PostAnnouncements.Name = "PostAnnouncements"
        Me.PostAnnouncements.Size = New System.Drawing.Size(148, 21)
        Me.PostAnnouncements.TabIndex = 40
        Me.PostAnnouncements.Text = "Post Announcements"
        Me.PostAnnouncements.UseVisualStyleBackColor = True
        '
        'Uploadgrades
        '
        Me.Uploadgrades.AutoSize = True
        Me.Uploadgrades.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uploadgrades.Location = New System.Drawing.Point(143, 110)
        Me.Uploadgrades.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Uploadgrades.Name = "Uploadgrades"
        Me.Uploadgrades.Size = New System.Drawing.Size(116, 21)
        Me.Uploadgrades.TabIndex = 39
        Me.Uploadgrades.Text = "Upload Grades"
        Me.Uploadgrades.UseVisualStyleBackColor = True
        '
        'Library
        '
        Me.Library.AutoSize = True
        Me.Library.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Library.Location = New System.Drawing.Point(24, 71)
        Me.Library.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Library.Name = "Library"
        Me.Library.Size = New System.Drawing.Size(67, 21)
        Me.Library.TabIndex = 33
        Me.Library.Text = "Library"
        Me.Library.UseVisualStyleBackColor = True
        '
        'Courses
        '
        Me.Courses.AutoSize = True
        Me.Courses.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Courses.Location = New System.Drawing.Point(143, 30)
        Me.Courses.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Courses.Name = "Courses"
        Me.Courses.Size = New System.Drawing.Size(102, 21)
        Me.Courses.TabIndex = 34
        Me.Courses.Text = "Add Courses"
        Me.Courses.UseVisualStyleBackColor = True
        '
        'AddAssignmnet
        '
        Me.AddAssignmnet.AutoSize = True
        Me.AddAssignmnet.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAssignmnet.Location = New System.Drawing.Point(309, 30)
        Me.AddAssignmnet.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AddAssignmnet.Name = "AddAssignmnet"
        Me.AddAssignmnet.Size = New System.Drawing.Size(122, 21)
        Me.AddAssignmnet.TabIndex = 38
        Me.AddAssignmnet.Text = "Add Assignment"
        Me.AddAssignmnet.UseVisualStyleBackColor = True
        '
        'GradeBook
        '
        Me.GradeBook.AutoSize = True
        Me.GradeBook.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradeBook.Location = New System.Drawing.Point(489, 30)
        Me.GradeBook.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GradeBook.Name = "GradeBook"
        Me.GradeBook.Size = New System.Drawing.Size(96, 21)
        Me.GradeBook.TabIndex = 36
        Me.GradeBook.Text = "Grade Book"
        Me.GradeBook.UseVisualStyleBackColor = True
        '
        'StudentProfile
        '
        Me.StudentProfile.AutoSize = True
        Me.StudentProfile.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StudentProfile.Location = New System.Drawing.Point(24, 30)
        Me.StudentProfile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StudentProfile.Name = "StudentProfile"
        Me.StudentProfile.Size = New System.Drawing.Size(112, 21)
        Me.StudentProfile.TabIndex = 32
        Me.StudentProfile.Text = "Student Profile"
        Me.StudentProfile.UseVisualStyleBackColor = True
        '
        'MajorCourses
        '
        Me.MajorCourses.AutoSize = True
        Me.MajorCourses.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MajorCourses.Location = New System.Drawing.Point(143, 71)
        Me.MajorCourses.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MajorCourses.Name = "MajorCourses"
        Me.MajorCourses.Size = New System.Drawing.Size(113, 21)
        Me.MajorCourses.TabIndex = 29
        Me.MajorCourses.Text = "Major Courses"
        Me.MajorCourses.UseVisualStyleBackColor = True
        '
        'CheckAssignment
        '
        Me.CheckAssignment.AutoSize = True
        Me.CheckAssignment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAssignment.Location = New System.Drawing.Point(309, 71)
        Me.CheckAssignment.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckAssignment.Name = "CheckAssignment"
        Me.CheckAssignment.Size = New System.Drawing.Size(132, 21)
        Me.CheckAssignment.TabIndex = 30
        Me.CheckAssignment.Text = "Check Assignment"
        Me.CheckAssignment.UseVisualStyleBackColor = True
        '
        'TuitionSettings
        '
        Me.TuitionSettings.AutoSize = True
        Me.TuitionSettings.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TuitionSettings.Location = New System.Drawing.Point(24, 110)
        Me.TuitionSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TuitionSettings.Name = "TuitionSettings"
        Me.TuitionSettings.Size = New System.Drawing.Size(116, 21)
        Me.TuitionSettings.TabIndex = 35
        Me.TuitionSettings.Text = "Tuition Settings"
        Me.TuitionSettings.UseVisualStyleBackColor = True
        '
        'Classes
        '
        Me.Classes.AutoSize = True
        Me.Classes.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Classes.Location = New System.Drawing.Point(489, 71)
        Me.Classes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Classes.Name = "Classes"
        Me.Classes.Size = New System.Drawing.Size(70, 21)
        Me.Classes.TabIndex = 31
        Me.Classes.Text = "Classes"
        Me.Classes.UseVisualStyleBackColor = True
        '
        'SelectAll
        '
        Me.SelectAll.AutoSize = True
        Me.SelectAll.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectAll.Location = New System.Drawing.Point(544, 0)
        Me.SelectAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(79, 21)
        Me.SelectAll.TabIndex = 25
        Me.SelectAll.Text = "Select All"
        Me.SelectAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUMPword)
        Me.GroupBox1.Controls.Add(Me.txtUMusername)
        Me.GroupBox1.Controls.Add(Me.lbUT)
        Me.GroupBox1.Controls.Add(Me.txtUMConfPword)
        Me.GroupBox1.Controls.Add(Me.cmbxtyp)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCustome)
        Me.GroupBox1.Controls.Add(Me.btnBack)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(642, 148)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Login Details"
        '
        'txtUMPword
        '
        Me.txtUMPword.Location = New System.Drawing.Point(132, 50)
        Me.txtUMPword.Name = "txtUMPword"
        Me.txtUMPword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUMPword.Size = New System.Drawing.Size(208, 25)
        Me.txtUMPword.TabIndex = 39
        '
        'txtUMusername
        '
        Me.txtUMusername.Location = New System.Drawing.Point(132, 19)
        Me.txtUMusername.Name = "txtUMusername"
        Me.txtUMusername.Size = New System.Drawing.Size(208, 25)
        Me.txtUMusername.TabIndex = 40
        '
        'lbUT
        '
        Me.lbUT.AutoSize = True
        Me.lbUT.Location = New System.Drawing.Point(51, 115)
        Me.lbUT.Name = "lbUT"
        Me.lbUT.Size = New System.Drawing.Size(66, 17)
        Me.lbUT.TabIndex = 47
        Me.lbUT.Text = "User Type"
        '
        'txtUMConfPword
        '
        Me.txtUMConfPword.Location = New System.Drawing.Point(132, 81)
        Me.txtUMConfPword.Name = "txtUMConfPword"
        Me.txtUMConfPword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUMConfPword.Size = New System.Drawing.Size(208, 25)
        Me.txtUMConfPword.TabIndex = 41
        '
        'cmbxtyp
        '
        Me.cmbxtyp.FormattingEnabled = True
        Me.cmbxtyp.Location = New System.Drawing.Point(132, 112)
        Me.cmbxtyp.Name = "cmbxtyp"
        Me.cmbxtyp.Size = New System.Drawing.Size(122, 25)
        Me.cmbxtyp.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Username"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 17)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Confirm Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Password"
        '
        'btnCustome
        '
        Me.btnCustome.BackgroundImage = CType(resources.GetObject("btnCustome.BackgroundImage"), System.Drawing.Image)
        Me.btnCustome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCustome.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCustome.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustome.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCustome.Location = New System.Drawing.Point(260, 112)
        Me.btnCustome.Name = "btnCustome"
        Me.btnCustome.Size = New System.Drawing.Size(80, 25)
        Me.btnCustome.TabIndex = 48
        Me.btnCustome.Text = "Custom"
        Me.btnCustome.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBack.Location = New System.Drawing.Point(260, 112)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(80, 25)
        Me.btnBack.TabIndex = 49
        Me.btnBack.Text = "&Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'gpbviewRights
        '
        Me.gpbviewRights.Controls.Add(Me.dgvusers)
        Me.gpbviewRights.Controls.Add(Me.Label1)
        Me.gpbviewRights.Controls.Add(Me.txtSearchUser)
        Me.gpbviewRights.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbviewRights.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.gpbviewRights.Location = New System.Drawing.Point(0, 7)
        Me.gpbviewRights.Name = "gpbviewRights"
        Me.gpbviewRights.Size = New System.Drawing.Size(654, 402)
        Me.gpbviewRights.TabIndex = 51
        Me.gpbviewRights.TabStop = False
        Me.gpbviewRights.Text = "Access Rights"
        '
        'dgvusers
        '
        Me.dgvusers.AllowUserToAddRows = False
        Me.dgvusers.AllowUserToDeleteRows = False
        Me.dgvusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvusers.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvusers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvusers.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvusers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvusers.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvusers.Location = New System.Drawing.Point(4, 53)
        Me.dgvusers.Name = "dgvusers"
        Me.dgvusers.RowHeadersWidth = 10
        Me.dgvusers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvusers.ShowEditingIcon = False
        Me.dgvusers.Size = New System.Drawing.Size(647, 342)
        Me.dgvusers.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Search (Username)"
        '
        'txtSearchUser
        '
        Me.txtSearchUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchUser.Location = New System.Drawing.Point(136, 23)
        Me.txtSearchUser.Name = "txtSearchUser"
        Me.txtSearchUser.Size = New System.Drawing.Size(219, 25)
        Me.txtSearchUser.TabIndex = 12
        '
        'btnAddUser
        '
        Me.btnAddUser.BackgroundImage = CType(resources.GetObject("btnAddUser.BackgroundImage"), System.Drawing.Image)
        Me.btnAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddUser.Location = New System.Drawing.Point(91, 14)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(80, 25)
        Me.btnAddUser.TabIndex = 38
        Me.btnAddUser.Text = "Add User"
        Me.btnAddUser.UseVisualStyleBackColor = True
        '
        'btnUMSave
        '
        Me.btnUMSave.BackgroundImage = CType(resources.GetObject("btnUMSave.BackgroundImage"), System.Drawing.Image)
        Me.btnUMSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUMSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUMSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUMSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUMSave.Location = New System.Drawing.Point(91, 14)
        Me.btnUMSave.Name = "btnUMSave"
        Me.btnUMSave.Size = New System.Drawing.Size(80, 25)
        Me.btnUMSave.TabIndex = 45
        Me.btnUMSave.Text = "Save  "
        Me.btnUMSave.UseVisualStyleBackColor = True
        '
        'btnEditUser
        '
        Me.btnEditUser.BackgroundImage = CType(resources.GetObject("btnEditUser.BackgroundImage"), System.Drawing.Image)
        Me.btnEditUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEditUser.Location = New System.Drawing.Point(181, 15)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(80, 25)
        Me.btnEditUser.TabIndex = 10
        Me.btnEditUser.Text = "Edit User"
        Me.btnEditUser.UseVisualStyleBackColor = True
        '
        'btnDelUser
        '
        Me.btnDelUser.BackgroundImage = CType(resources.GetObject("btnDelUser.BackgroundImage"), System.Drawing.Image)
        Me.btnDelUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelUser.Location = New System.Drawing.Point(267, 15)
        Me.btnDelUser.Name = "btnDelUser"
        Me.btnDelUser.Size = New System.Drawing.Size(80, 25)
        Me.btnDelUser.TabIndex = 9
        Me.btnDelUser.Text = "Delete User"
        Me.btnDelUser.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnUMView)
        Me.GroupBox3.Controls.Add(Me.btnNewUser)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnClear)
        Me.GroupBox3.Controls.Add(Me.btnDelUser)
        Me.GroupBox3.Controls.Add(Me.btnEditUser)
        Me.GroupBox3.Controls.Add(Me.btnUMSave)
        Me.GroupBox3.Controls.Add(Me.btnAddUser)
        Me.GroupBox3.Location = New System.Drawing.Point(117, 395)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(528, 47)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        '
        'btnUMView
        '
        Me.btnUMView.BackgroundImage = CType(resources.GetObject("btnUMView.BackgroundImage"), System.Drawing.Image)
        Me.btnUMView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUMView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUMView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUMView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUMView.Location = New System.Drawing.Point(4, 15)
        Me.btnUMView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUMView.Name = "btnUMView"
        Me.btnUMView.Size = New System.Drawing.Size(80, 25)
        Me.btnUMView.TabIndex = 47
        Me.btnUMView.Text = "&View"
        Me.btnUMView.UseVisualStyleBackColor = True
        '
        'btnNewUser
        '
        Me.btnNewUser.BackgroundImage = CType(resources.GetObject("btnNewUser.BackgroundImage"), System.Drawing.Image)
        Me.btnNewUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNewUser.Location = New System.Drawing.Point(5, 15)
        Me.btnNewUser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(80, 25)
        Me.btnNewUser.TabIndex = 46
        Me.btnNewUser.Text = "&New"
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Location = New System.Drawing.Point(445, 15)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 25)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackgroundImage = CType(resources.GetObject("btnClear.BackgroundImage"), System.Drawing.Image)
        Me.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(354, 14)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 25)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'setTimetable
        '
        Me.setTimetable.AutoSize = True
        Me.setTimetable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setTimetable.Location = New System.Drawing.Point(24, 218)
        Me.setTimetable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.setTimetable.Name = "setTimetable"
        Me.setTimetable.Size = New System.Drawing.Size(106, 21)
        Me.setTimetable.TabIndex = 51
        Me.setTimetable.Text = "Set Timetable"
        Me.setTimetable.UseVisualStyleBackColor = True
        '
        'UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(659, 447)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBoxUM)
        Me.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserManagement"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Management"
        Me.GroupBoxUM.ResumeLayout(False)
        Me.gpbAccessRights.ResumeLayout(False)
        Me.gpbrights.ResumeLayout(False)
        Me.gpbrights.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpbviewRights.ResumeLayout(False)
        Me.gpbviewRights.PerformLayout()
        CType(Me.dgvusers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxUM As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchUser As System.Windows.Forms.TextBox
    Friend WithEvents dgvusers As System.Windows.Forms.DataGridView
    Friend WithEvents btnEditUser As System.Windows.Forms.Button
    Friend WithEvents btnDelUser As System.Windows.Forms.Button
    Friend WithEvents gpbAccessRights As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtUMPword As TextBox
    Friend WithEvents btnCustome As Button
    Friend WithEvents txtUMusername As TextBox
    Friend WithEvents lbUT As Label
    Friend WithEvents txtUMConfPword As TextBox
    Friend WithEvents cmbxtyp As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnUMSave As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents gpbviewRights As GroupBox
    Friend WithEvents btnNewUser As Button
    Friend WithEvents btnUMView As Button
    Friend WithEvents gpbrights As GroupBox
    Friend WithEvents DataView As CheckBox
    Friend WithEvents SystemBackup As CheckBox
    Friend WithEvents UserAccess As CheckBox
    Friend WithEvents AddStudent As CheckBox
    Friend WithEvents ExamNum As CheckBox
    Friend WithEvents Attendance As CheckBox
    Friend WithEvents AccStatement As CheckBox
    Friend WithEvents ReceivePayment As CheckBox
    Friend WithEvents GeneralLedger As CheckBox
    Friend WithEvents PostAnnouncements As CheckBox
    Friend WithEvents Uploadgrades As CheckBox
    Friend WithEvents Library As CheckBox
    Friend WithEvents Courses As CheckBox
    Friend WithEvents AddAssignmnet As CheckBox
    Friend WithEvents GradeBook As CheckBox
    Friend WithEvents StudentProfile As CheckBox
    Friend WithEvents MajorCourses As CheckBox
    Friend WithEvents CheckAssignment As CheckBox
    Friend WithEvents TuitionSettings As CheckBox
    Friend WithEvents Classes As CheckBox
    Friend WithEvents SelectAll As CheckBox
    Friend WithEvents AddLecturer As CheckBox
    Friend WithEvents setTimetable As CheckBox
End Class
