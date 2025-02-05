<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentManager))
        Me.gpbExam = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NUDYrOStudy = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbxSemester = New System.Windows.Forms.ComboBox()
        Me.cmbxPID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGenerateExamNums = New System.Windows.Forms.Button()
        Me.btnSMClose = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTOA = New System.Windows.Forms.ComboBox()
        Me.cmbAccomodation = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.RadioFemale = New System.Windows.Forms.RadioButton()
        Me.RadioMale = New System.Windows.Forms.RadioButton()
        Me.cmbSMProgOfStudy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSMGetSID = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSMSurname = New System.Windows.Forms.TextBox()
        Me.txtSMStudentID = New System.Windows.Forms.TextBox()
        Me.txtSMFname = New System.Windows.Forms.TextBox()
        Me.txtAccNum = New System.Windows.Forms.TextBox()
        Me.btnAddStudent = New System.Windows.Forms.Button()
        Me.btnSMSave = New System.Windows.Forms.Button()
        Me.gpbStudentMan = New System.Windows.Forms.GroupBox()
        Me.GroupBoxSM = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchStudent = New System.Windows.Forms.TextBox()
        Me.dgvStudents = New System.Windows.Forms.DataGridView()
        Me.btnEditStudent = New System.Windows.Forms.Button()
        Me.btnDelStudent = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.gpbExam.SuspendLayout()
        CType(Me.NUDYrOStudy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbStudentMan.SuspendLayout()
        Me.GroupBoxSM.SuspendLayout()
        CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbExam
        '
        Me.gpbExam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpbExam.Controls.Add(Me.Label8)
        Me.gpbExam.Controls.Add(Me.NUDYrOStudy)
        Me.gpbExam.Controls.Add(Me.Label9)
        Me.gpbExam.Controls.Add(Me.cmbxSemester)
        Me.gpbExam.Controls.Add(Me.cmbxPID)
        Me.gpbExam.Controls.Add(Me.Label6)
        Me.gpbExam.Controls.Add(Me.btnGenerateExamNums)
        Me.gpbExam.Cursor = System.Windows.Forms.Cursors.Default
        Me.gpbExam.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.gpbExam.Location = New System.Drawing.Point(7, 494)
        Me.gpbExam.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbExam.Name = "gpbExam"
        Me.gpbExam.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbExam.Size = New System.Drawing.Size(645, 131)
        Me.gpbExam.TabIndex = 47
        Me.gpbExam.TabStop = False
        Me.gpbExam.Text = "Exam numbers"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.Location = New System.Drawing.Point(285, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Year of Study"
        '
        'NUDYrOStudy
        '
        Me.NUDYrOStudy.BackColor = System.Drawing.SystemColors.ControlLight
        Me.NUDYrOStudy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDYrOStudy.ForeColor = System.Drawing.SystemColors.WindowText
        Me.NUDYrOStudy.Location = New System.Drawing.Point(406, 77)
        Me.NUDYrOStudy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NUDYrOStudy.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.NUDYrOStudy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUDYrOStudy.Name = "NUDYrOStudy"
        Me.NUDYrOStudy.Size = New System.Drawing.Size(63, 22)
        Me.NUDYrOStudy.TabIndex = 54
        Me.NUDYrOStudy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.Location = New System.Drawing.Point(69, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Semester"
        '
        'cmbxSemester
        '
        Me.cmbxSemester.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbxSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxSemester.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxSemester.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbxSemester.FormattingEnabled = True
        Me.cmbxSemester.Items.AddRange(New Object() {"1", "2"})
        Me.cmbxSemester.Location = New System.Drawing.Point(153, 76)
        Me.cmbxSemester.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbxSemester.Name = "cmbxSemester"
        Me.cmbxSemester.Size = New System.Drawing.Size(62, 24)
        Me.cmbxSemester.TabIndex = 52
        '
        'cmbxPID
        '
        Me.cmbxPID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbxPID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxPID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxPID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbxPID.FormattingEnabled = True
        Me.cmbxPID.Location = New System.Drawing.Point(153, 25)
        Me.cmbxPID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbxPID.Name = "cmbxPID"
        Me.cmbxPID.Size = New System.Drawing.Size(315, 24)
        Me.cmbxPID.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(7, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Programe of Study"
        '
        'btnGenerateExamNums
        '
        Me.btnGenerateExamNums.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGenerateExamNums.BackgroundImage = CType(resources.GetObject("btnGenerateExamNums.BackgroundImage"), System.Drawing.Image)
        Me.btnGenerateExamNums.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGenerateExamNums.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateExamNums.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnGenerateExamNums.Location = New System.Drawing.Point(496, 70)
        Me.btnGenerateExamNums.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerateExamNums.Name = "btnGenerateExamNums"
        Me.btnGenerateExamNums.Size = New System.Drawing.Size(142, 44)
        Me.btnGenerateExamNums.TabIndex = 48
        Me.btnGenerateExamNums.Text = "Generate Exam numbers"
        Me.btnGenerateExamNums.UseVisualStyleBackColor = True
        '
        'btnSMClose
        '
        Me.btnSMClose.BackgroundImage = CType(resources.GetObject("btnSMClose.BackgroundImage"), System.Drawing.Image)
        Me.btnSMClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMClose.Location = New System.Drawing.Point(1039, 595)
        Me.btnSMClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSMClose.Name = "btnSMClose"
        Me.btnSMClose.Size = New System.Drawing.Size(87, 30)
        Me.btnSMClose.TabIndex = 48
        Me.btnSMClose.Text = "&Close"
        Me.btnSMClose.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(850, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Gender"
        '
        'cmbTOA
        '
        Me.cmbTOA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTOA.FormattingEnabled = True
        Me.cmbTOA.Items.AddRange(New Object() {"Self Sponsored", "Government Sponsored", "Scholarship "})
        Me.cmbTOA.Location = New System.Drawing.Point(918, 204)
        Me.cmbTOA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTOA.Name = "cmbTOA"
        Me.cmbTOA.Size = New System.Drawing.Size(207, 24)
        Me.cmbTOA.TabIndex = 66
        '
        'cmbAccomodation
        '
        Me.cmbAccomodation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAccomodation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccomodation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccomodation.FormattingEnabled = True
        Me.cmbAccomodation.Items.AddRange(New Object() {"Off Campus", "Male Hostels", "Female Hostels"})
        Me.cmbAccomodation.Location = New System.Drawing.Point(918, 243)
        Me.cmbAccomodation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbAccomodation.Name = "cmbAccomodation"
        Me.cmbAccomodation.Size = New System.Drawing.Size(207, 24)
        Me.cmbAccomodation.TabIndex = 65
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label24.Location = New System.Drawing.Point(797, 247)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 16)
        Me.Label24.TabIndex = 64
        Me.Label24.Text = "Accommodtion"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label23.Location = New System.Drawing.Point(771, 208)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 16)
        Me.Label23.TabIndex = 63
        Me.Label23.Text = "Type of Admission"
        '
        'RadioFemale
        '
        Me.RadioFemale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioFemale.AutoSize = True
        Me.RadioFemale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioFemale.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioFemale.Location = New System.Drawing.Point(1016, 128)
        Me.RadioFemale.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioFemale.Name = "RadioFemale"
        Me.RadioFemale.Size = New System.Drawing.Size(72, 20)
        Me.RadioFemale.TabIndex = 62
        Me.RadioFemale.TabStop = True
        Me.RadioFemale.Text = "Female"
        Me.RadioFemale.UseVisualStyleBackColor = True
        '
        'RadioMale
        '
        Me.RadioMale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioMale.AutoSize = True
        Me.RadioMale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioMale.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioMale.Location = New System.Drawing.Point(928, 128)
        Me.RadioMale.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioMale.Name = "RadioMale"
        Me.RadioMale.Size = New System.Drawing.Size(56, 20)
        Me.RadioMale.TabIndex = 61
        Me.RadioMale.TabStop = True
        Me.RadioMale.Text = "Male"
        Me.RadioMale.UseVisualStyleBackColor = True
        '
        'cmbSMProgOfStudy
        '
        Me.cmbSMProgOfStudy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSMProgOfStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSMProgOfStudy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSMProgOfStudy.FormattingEnabled = True
        Me.cmbSMProgOfStudy.Location = New System.Drawing.Point(919, 165)
        Me.cmbSMProgOfStudy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSMProgOfStudy.Name = "cmbSMProgOfStudy"
        Me.cmbSMProgOfStudy.Size = New System.Drawing.Size(207, 24)
        Me.cmbSMProgOfStudy.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(832, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Student ID"
        '
        'btnSMGetSID
        '
        Me.btnSMGetSID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMGetSID.BackgroundImage = CType(resources.GetObject("btnSMGetSID.BackgroundImage"), System.Drawing.Image)
        Me.btnSMGetSID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMGetSID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSMGetSID.Location = New System.Drawing.Point(919, 290)
        Me.btnSMGetSID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSMGetSID.Name = "btnSMGetSID"
        Me.btnSMGetSID.Size = New System.Drawing.Size(208, 34)
        Me.btnSMGetSID.TabIndex = 57
        Me.btnSMGetSID.Text = "Get Student ID"
        Me.btnSMGetSID.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Location = New System.Drawing.Point(773, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 16)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Programe of Study"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Location = New System.Drawing.Point(840, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 16)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Surname"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(827, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "First Name"
        '
        'txtSMSurname
        '
        Me.txtSMSurname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMSurname.Location = New System.Drawing.Point(919, 89)
        Me.txtSMSurname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSMSurname.Name = "txtSMSurname"
        Me.txtSMSurname.Size = New System.Drawing.Size(207, 22)
        Me.txtSMSurname.TabIndex = 52
        '
        'txtSMStudentID
        '
        Me.txtSMStudentID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMStudentID.Enabled = False
        Me.txtSMStudentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMStudentID.Location = New System.Drawing.Point(919, 332)
        Me.txtSMStudentID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSMStudentID.Name = "txtSMStudentID"
        Me.txtSMStudentID.Size = New System.Drawing.Size(207, 22)
        Me.txtSMStudentID.TabIndex = 51
        '
        'txtSMFname
        '
        Me.txtSMFname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMFname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMFname.Location = New System.Drawing.Point(919, 50)
        Me.txtSMFname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSMFname.Name = "txtSMFname"
        Me.txtSMFname.Size = New System.Drawing.Size(207, 22)
        Me.txtSMFname.TabIndex = 50
        '
        'txtAccNum
        '
        Me.txtAccNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccNum.Enabled = False
        Me.txtAccNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccNum.Location = New System.Drawing.Point(919, 332)
        Me.txtAccNum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAccNum.Name = "txtAccNum"
        Me.txtAccNum.Size = New System.Drawing.Size(207, 22)
        Me.txtAccNum.TabIndex = 60
        Me.txtAccNum.Visible = False
        '
        'btnAddStudent
        '
        Me.btnAddStudent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddStudent.BackgroundImage = CType(resources.GetObject("btnAddStudent.BackgroundImage"), System.Drawing.Image)
        Me.btnAddStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddStudent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStudent.Location = New System.Drawing.Point(919, 369)
        Me.btnAddStudent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddStudent.Name = "btnAddStudent"
        Me.btnAddStudent.Size = New System.Drawing.Size(208, 33)
        Me.btnAddStudent.TabIndex = 49
        Me.btnAddStudent.Text = "Add Student"
        Me.btnAddStudent.UseVisualStyleBackColor = True
        '
        'btnSMSave
        '
        Me.btnSMSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMSave.BackgroundImage = CType(resources.GetObject("btnSMSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSMSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSMSave.Location = New System.Drawing.Point(919, 369)
        Me.btnSMSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSMSave.Name = "btnSMSave"
        Me.btnSMSave.Size = New System.Drawing.Size(208, 33)
        Me.btnSMSave.TabIndex = 56
        Me.btnSMSave.Text = "Save"
        Me.btnSMSave.UseVisualStyleBackColor = True
        '
        'gpbStudentMan
        '
        Me.gpbStudentMan.Controls.Add(Me.GroupBoxSM)
        Me.gpbStudentMan.Controls.Add(Me.Label5)
        Me.gpbStudentMan.Controls.Add(Me.txtSMFname)
        Me.gpbStudentMan.Controls.Add(Me.cmbTOA)
        Me.gpbStudentMan.Controls.Add(Me.cmbAccomodation)
        Me.gpbStudentMan.Controls.Add(Me.btnAddStudent)
        Me.gpbStudentMan.Controls.Add(Me.Label24)
        Me.gpbStudentMan.Controls.Add(Me.txtAccNum)
        Me.gpbStudentMan.Controls.Add(Me.Label23)
        Me.gpbStudentMan.Controls.Add(Me.txtSMStudentID)
        Me.gpbStudentMan.Controls.Add(Me.RadioFemale)
        Me.gpbStudentMan.Controls.Add(Me.txtSMSurname)
        Me.gpbStudentMan.Controls.Add(Me.RadioMale)
        Me.gpbStudentMan.Controls.Add(Me.Label3)
        Me.gpbStudentMan.Controls.Add(Me.cmbSMProgOfStudy)
        Me.gpbStudentMan.Controls.Add(Me.Label4)
        Me.gpbStudentMan.Controls.Add(Me.Label2)
        Me.gpbStudentMan.Controls.Add(Me.Label7)
        Me.gpbStudentMan.Controls.Add(Me.btnSMGetSID)
        Me.gpbStudentMan.Controls.Add(Me.btnSMSave)
        Me.gpbStudentMan.Location = New System.Drawing.Point(0, 25)
        Me.gpbStudentMan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbStudentMan.Name = "gpbStudentMan"
        Me.gpbStudentMan.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbStudentMan.Size = New System.Drawing.Size(1143, 470)
        Me.gpbStudentMan.TabIndex = 49
        Me.gpbStudentMan.TabStop = False
        '
        'GroupBoxSM
        '
        Me.GroupBoxSM.Controls.Add(Me.Label1)
        Me.GroupBoxSM.Controls.Add(Me.txtSearchStudent)
        Me.GroupBoxSM.Controls.Add(Me.dgvStudents)
        Me.GroupBoxSM.Controls.Add(Me.btnEditStudent)
        Me.GroupBoxSM.Controls.Add(Me.btnDelStudent)
        Me.GroupBoxSM.Location = New System.Drawing.Point(2, 0)
        Me.GroupBoxSM.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.GroupBoxSM.Name = "GroupBoxSM"
        Me.GroupBoxSM.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxSM.Size = New System.Drawing.Size(756, 470)
        Me.GroupBoxSM.TabIndex = 68
        Me.GroupBoxSM.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(323, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Search (Student ID)"
        '
        'txtSearchStudent
        '
        Me.txtSearchStudent.Location = New System.Drawing.Point(448, 20)
        Me.txtSearchStudent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearchStudent.Name = "txtSearchStudent"
        Me.txtSearchStudent.Size = New System.Drawing.Size(300, 25)
        Me.txtSearchStudent.TabIndex = 12
        '
        'dgvStudents
        '
        Me.dgvStudents.AllowUserToAddRows = False
        Me.dgvStudents.AllowUserToDeleteRows = False
        Me.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStudents.BackgroundColor = System.Drawing.Color.White
        Me.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudents.Location = New System.Drawing.Point(7, 54)
        Me.dgvStudents.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvStudents.Name = "dgvStudents"
        Me.dgvStudents.RowHeadersWidth = 10
        Me.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudents.Size = New System.Drawing.Size(742, 365)
        Me.dgvStudents.TabIndex = 8
        '
        'btnEditStudent
        '
        Me.btnEditStudent.BackgroundImage = CType(resources.GetObject("btnEditStudent.BackgroundImage"), System.Drawing.Image)
        Me.btnEditStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditStudent.Location = New System.Drawing.Point(544, 426)
        Me.btnEditStudent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEditStudent.Name = "btnEditStudent"
        Me.btnEditStudent.Size = New System.Drawing.Size(87, 30)
        Me.btnEditStudent.TabIndex = 10
        Me.btnEditStudent.Text = "Edit Student"
        Me.btnEditStudent.UseVisualStyleBackColor = True
        '
        'btnDelStudent
        '
        Me.btnDelStudent.BackgroundImage = CType(resources.GetObject("btnDelStudent.BackgroundImage"), System.Drawing.Image)
        Me.btnDelStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelStudent.Location = New System.Drawing.Point(643, 426)
        Me.btnDelStudent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelStudent.Name = "btnDelStudent"
        Me.btnDelStudent.Size = New System.Drawing.Size(106, 30)
        Me.btnDelStudent.TabIndex = 9
        Me.btnDelStudent.Text = "Delete Student"
        Me.btnDelStudent.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Palatino Linotype", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(-3, -1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(1152, 25)
        Me.Button2.TabIndex = 56
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseCompatibleTextRendering = True
        Me.Button2.UseVisualStyleBackColor = True
        '
        'StudentManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(1144, 641)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.gpbStudentMan)
        Me.Controls.Add(Me.btnSMClose)
        Me.Controls.Add(Me.gpbExam)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StudentManager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StudentManager"
        Me.gpbExam.ResumeLayout(False)
        Me.gpbExam.PerformLayout()
        CType(Me.NUDYrOStudy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbStudentMan.ResumeLayout(False)
        Me.gpbStudentMan.PerformLayout()
        Me.GroupBoxSM.ResumeLayout(False)
        Me.GroupBoxSM.PerformLayout()
        CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents DbSIMSDataSet1 As SIMS_Core.dbSIMSDataSet1
    'Friend WithEvents StudentTableAdapter As SIMS_Core.dbSIMSDataSet1TableAdapters.StudentTableAdapter
    Friend WithEvents StudentIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProgramOfStudyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SurnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpbExam As GroupBox
    Friend WithEvents cmbxPID As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnGenerateExamNums As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbxSemester As ComboBox
    Friend WithEvents btnSMClose As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents NUDYrOStudy As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbTOA As ComboBox
    Friend WithEvents cmbAccomodation As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents RadioFemale As RadioButton
    Friend WithEvents RadioMale As RadioButton
    Friend WithEvents cmbSMProgOfStudy As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSMGetSID As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSMSurname As TextBox
    Friend WithEvents txtSMStudentID As TextBox
    Friend WithEvents txtSMFname As TextBox
    Friend WithEvents txtAccNum As TextBox
    Friend WithEvents btnAddStudent As Button
    Friend WithEvents btnSMSave As Button
    Friend WithEvents gpbStudentMan As GroupBox
    Friend WithEvents GroupBoxSM As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearchStudent As TextBox
    Friend WithEvents dgvStudents As DataGridView
    Friend WithEvents btnEditStudent As Button
    Friend WithEvents btnDelStudent As Button
    Friend WithEvents Button2 As Button
End Class
