<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tuition_Management
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tuition_Management))
        Me.btnAddProg = New System.Windows.Forms.Button()
        Me.txtProgName = New System.Windows.Forms.TextBox()
        Me.txtProgCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rb3yrs = New System.Windows.Forms.RadioButton()
        Me.rb4yrs = New System.Windows.Forms.RadioButton()
        Me.rb5yrs = New System.Windows.Forms.RadioButton()
        Me.rb6yrs = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.cmbxFaculty = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFacultyname = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFID = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDeptId = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdeptName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbfaculty = New System.Windows.Forms.ComboBox()
        Me.btnAddDept = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpResume = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpBreak = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAddYear = New System.Windows.Forms.Button()
        Me.dtpYrEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpYrStart = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tbcTuition = New System.Windows.Forms.TabControl()
        Me.TabTuition = New System.Windows.Forms.TabPage()
        Me.TabExamNum = New System.Windows.Forms.TabPage()
        Me.txtViewExamNum = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AddFacultyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.AddDepartmentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.AddProgrammesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip4 = New System.Windows.Forms.MenuStrip()
        Me.AddAcademicYrToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnbar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tbcTuition.SuspendLayout()
        Me.TabTuition.SuspendLayout()
        Me.TabExamNum.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.MenuStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddProg
        '
        Me.btnAddProg.BackgroundImage = CType(resources.GetObject("btnAddProg.BackgroundImage"), System.Drawing.Image)
        Me.btnAddProg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddProg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddProg.Location = New System.Drawing.Point(700, 44)
        Me.btnAddProg.Name = "btnAddProg"
        Me.btnAddProg.Size = New System.Drawing.Size(83, 26)
        Me.btnAddProg.TabIndex = 0
        Me.btnAddProg.Text = "Add Programe"
        Me.btnAddProg.UseVisualStyleBackColor = True
        '
        'txtProgName
        '
        Me.txtProgName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProgName.Location = New System.Drawing.Point(125, 25)
        Me.txtProgName.Name = "txtProgName"
        Me.txtProgName.Size = New System.Drawing.Size(150, 25)
        Me.txtProgName.TabIndex = 2
        '
        'txtProgCode
        '
        Me.txtProgCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProgCode.Location = New System.Drawing.Point(125, 68)
        Me.txtProgCode.Name = "txtProgCode"
        Me.txtProgCode.Size = New System.Drawing.Size(150, 25)
        Me.txtProgCode.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Programe Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Programe Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(295, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Faculty"
        '
        'rb3yrs
        '
        Me.rb3yrs.AutoSize = True
        Me.rb3yrs.Location = New System.Drawing.Point(572, 35)
        Me.rb3yrs.Name = "rb3yrs"
        Me.rb3yrs.Size = New System.Drawing.Size(50, 21)
        Me.rb3yrs.TabIndex = 8
        Me.rb3yrs.TabStop = True
        Me.rb3yrs.Text = "3yrs"
        Me.rb3yrs.UseVisualStyleBackColor = True
        '
        'rb4yrs
        '
        Me.rb4yrs.AutoSize = True
        Me.rb4yrs.Location = New System.Drawing.Point(622, 35)
        Me.rb4yrs.Name = "rb4yrs"
        Me.rb4yrs.Size = New System.Drawing.Size(50, 21)
        Me.rb4yrs.TabIndex = 9
        Me.rb4yrs.TabStop = True
        Me.rb4yrs.Text = "4yrs"
        Me.rb4yrs.UseVisualStyleBackColor = True
        '
        'rb5yrs
        '
        Me.rb5yrs.AutoSize = True
        Me.rb5yrs.Location = New System.Drawing.Point(572, 58)
        Me.rb5yrs.Name = "rb5yrs"
        Me.rb5yrs.Size = New System.Drawing.Size(50, 21)
        Me.rb5yrs.TabIndex = 10
        Me.rb5yrs.TabStop = True
        Me.rb5yrs.Text = "5yrs"
        Me.rb5yrs.UseVisualStyleBackColor = True
        '
        'rb6yrs
        '
        Me.rb6yrs.AutoSize = True
        Me.rb6yrs.Location = New System.Drawing.Point(622, 58)
        Me.rb6yrs.Name = "rb6yrs"
        Me.rb6yrs.Size = New System.Drawing.Size(50, 21)
        Me.rb6yrs.TabIndex = 11
        Me.rb6yrs.TabStop = True
        Me.rb6yrs.Text = "6yrs"
        Me.rb6yrs.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Duration"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(292, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Department"
        '
        'cmbDept
        '
        Me.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(375, 59)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(121, 25)
        Me.cmbDept.Sorted = True
        Me.cmbDept.TabIndex = 15
        '
        'cmbxFaculty
        '
        Me.cmbxFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxFaculty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbxFaculty.FormattingEnabled = True
        Me.cmbxFaculty.Location = New System.Drawing.Point(359, 25)
        Me.cmbxFaculty.Name = "cmbxFaculty"
        Me.cmbxFaculty.Size = New System.Drawing.Size(137, 25)
        Me.cmbxFaculty.Sorted = True
        Me.cmbxFaculty.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "faculty Name"
        '
        'txtFacultyname
        '
        Me.txtFacultyname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacultyname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFacultyname.Location = New System.Drawing.Point(124, 25)
        Me.txtFacultyname.Name = "txtFacultyname"
        Me.txtFacultyname.Size = New System.Drawing.Size(228, 25)
        Me.txtFacultyname.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(382, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Faculty ID "
        '
        'txtFID
        '
        Me.txtFID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFID.Location = New System.Drawing.Point(471, 25)
        Me.txtFID.Name = "txtFID"
        Me.txtFID.Size = New System.Drawing.Size(150, 25)
        Me.txtFID.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(700, 25)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 26)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Add Faculty"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(292, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Department ID "
        '
        'txtDeptId
        '
        Me.txtDeptId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDeptId.Location = New System.Drawing.Point(381, 34)
        Me.txtDeptId.Name = "txtDeptId"
        Me.txtDeptId.Size = New System.Drawing.Size(78, 25)
        Me.txtDeptId.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 17)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Department Name"
        '
        'txtdeptName
        '
        Me.txtdeptName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtdeptName.Location = New System.Drawing.Point(130, 31)
        Me.txtdeptName.Name = "txtdeptName"
        Me.txtdeptName.Size = New System.Drawing.Size(150, 25)
        Me.txtdeptName.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(475, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "faculty "
        '
        'cmbfaculty
        '
        Me.cmbfaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbfaculty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbfaculty.FormattingEnabled = True
        Me.cmbfaculty.Location = New System.Drawing.Point(522, 31)
        Me.cmbfaculty.Name = "cmbfaculty"
        Me.cmbfaculty.Size = New System.Drawing.Size(150, 25)
        Me.cmbfaculty.Sorted = True
        Me.cmbfaculty.TabIndex = 28
        '
        'btnAddDept
        '
        Me.btnAddDept.BackgroundImage = CType(resources.GetObject("btnAddDept.BackgroundImage"), System.Drawing.Image)
        Me.btnAddDept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddDept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddDept.Location = New System.Drawing.Point(699, 34)
        Me.btnAddDept.Name = "btnAddDept"
        Me.btnAddDept.Size = New System.Drawing.Size(83, 26)
        Me.btnAddDept.TabIndex = 29
        Me.btnAddDept.Text = "Add Department"
        Me.btnAddDept.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbDept)
        Me.GroupBox1.Controls.Add(Me.btnAddProg)
        Me.GroupBox1.Controls.Add(Me.txtProgName)
        Me.GroupBox1.Controls.Add(Me.txtProgCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rb3yrs)
        Me.GroupBox1.Controls.Add(Me.rb4yrs)
        Me.GroupBox1.Controls.Add(Me.rb5yrs)
        Me.GroupBox1.Controls.Add(Me.rb6yrs)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbxFaculty)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Location = New System.Drawing.Point(4, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(803, 99)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Programmes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbfaculty)
        Me.GroupBox2.Controls.Add(Me.txtdeptName)
        Me.GroupBox2.Controls.Add(Me.btnAddDept)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtDeptId)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Location = New System.Drawing.Point(4, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(803, 70)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Departments"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFID)
        Me.GroupBox3.Controls.Add(Me.txtFacultyname)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox3.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(802, 62)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Faculty"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtpResume)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.dtpBreak)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.btnAddYear)
        Me.GroupBox4.Controls.Add(Me.dtpYrEnd)
        Me.GroupBox4.Controls.Add(Me.dtpYrStart)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox4.Location = New System.Drawing.Point(4, 290)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(802, 57)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Academic Year"
        '
        'dtpResume
        '
        Me.dtpResume.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpResume.CustomFormat = ""
        Me.dtpResume.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpResume.Location = New System.Drawing.Point(425, 20)
        Me.dtpResume.Name = "dtpResume"
        Me.dtpResume.Size = New System.Drawing.Size(88, 25)
        Me.dtpResume.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(365, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Resume"
        '
        'dtpBreak
        '
        Me.dtpBreak.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpBreak.CustomFormat = ""
        Me.dtpBreak.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBreak.Location = New System.Drawing.Point(236, 20)
        Me.dtpBreak.Name = "dtpBreak"
        Me.dtpBreak.Size = New System.Drawing.Size(88, 25)
        Me.dtpBreak.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(190, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 17)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Break"
        '
        'btnAddYear
        '
        Me.btnAddYear.BackgroundImage = CType(resources.GetObject("btnAddYear.BackgroundImage"), System.Drawing.Image)
        Me.btnAddYear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddYear.Location = New System.Drawing.Point(699, 22)
        Me.btnAddYear.Name = "btnAddYear"
        Me.btnAddYear.Size = New System.Drawing.Size(83, 26)
        Me.btnAddYear.TabIndex = 30
        Me.btnAddYear.Text = "Add Programe"
        Me.btnAddYear.UseVisualStyleBackColor = True
        '
        'dtpYrEnd
        '
        Me.dtpYrEnd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpYrEnd.CustomFormat = ""
        Me.dtpYrEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpYrEnd.Location = New System.Drawing.Point(594, 20)
        Me.dtpYrEnd.Name = "dtpYrEnd"
        Me.dtpYrEnd.Size = New System.Drawing.Size(88, 25)
        Me.dtpYrEnd.TabIndex = 29
        '
        'dtpYrStart
        '
        Me.dtpYrStart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpYrStart.CustomFormat = ""
        Me.dtpYrStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpYrStart.Location = New System.Drawing.Point(76, 20)
        Me.dtpYrStart.Name = "dtpYrStart"
        Me.dtpYrStart.Size = New System.Drawing.Size(88, 25)
        Me.dtpYrStart.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(529, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 17)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Year End"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 17)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Year Start"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Location = New System.Drawing.Point(714, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(83, 26)
        Me.btnClose.TabIndex = 34
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tbcTuition
        '
        Me.tbcTuition.Controls.Add(Me.TabTuition)
        Me.tbcTuition.Controls.Add(Me.TabExamNum)
        Me.tbcTuition.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcTuition.Location = New System.Drawing.Point(2, 29)
        Me.tbcTuition.Name = "tbcTuition"
        Me.tbcTuition.SelectedIndex = 0
        Me.tbcTuition.Size = New System.Drawing.Size(815, 381)
        Me.tbcTuition.TabIndex = 22
        '
        'TabTuition
        '
        Me.TabTuition.BackColor = System.Drawing.Color.MidnightBlue
        Me.TabTuition.Controls.Add(Me.GroupBox3)
        Me.TabTuition.Controls.Add(Me.GroupBox1)
        Me.TabTuition.Controls.Add(Me.GroupBox4)
        Me.TabTuition.Controls.Add(Me.GroupBox2)
        Me.TabTuition.Location = New System.Drawing.Point(4, 26)
        Me.TabTuition.Name = "TabTuition"
        Me.TabTuition.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTuition.Size = New System.Drawing.Size(807, 351)
        Me.TabTuition.TabIndex = 0
        Me.TabTuition.Text = "Tuition Settings"
        '
        'TabExamNum
        '
        Me.TabExamNum.BackColor = System.Drawing.Color.MidnightBlue
        Me.TabExamNum.Controls.Add(Me.txtViewExamNum)
        Me.TabExamNum.Location = New System.Drawing.Point(4, 26)
        Me.TabExamNum.Name = "TabExamNum"
        Me.TabExamNum.Padding = New System.Windows.Forms.Padding(3)
        Me.TabExamNum.Size = New System.Drawing.Size(807, 351)
        Me.TabExamNum.TabIndex = 1
        Me.TabExamNum.Text = "Exam Number"
        '
        'txtViewExamNum
        '
        Me.txtViewExamNum.BackColor = System.Drawing.Color.MidnightBlue
        Me.txtViewExamNum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtViewExamNum.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtViewExamNum.ForeColor = System.Drawing.Color.Red
        Me.txtViewExamNum.Location = New System.Drawing.Point(268, 139)
        Me.txtViewExamNum.Name = "txtViewExamNum"
        Me.txtViewExamNum.Size = New System.Drawing.Size(282, 36)
        Me.txtViewExamNum.TabIndex = 0
        Me.txtViewExamNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddFacultyToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(5, 1)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(95, 25)
        Me.MenuStrip1.TabIndex = 35
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AddFacultyToolStripMenuItem
        '
        Me.AddFacultyToolStripMenuItem.BackgroundImage = CType(resources.GetObject("AddFacultyToolStripMenuItem.BackgroundImage"), System.Drawing.Image)
        Me.AddFacultyToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddFacultyToolStripMenuItem.Name = "AddFacultyToolStripMenuItem"
        Me.AddFacultyToolStripMenuItem.Size = New System.Drawing.Size(87, 21)
        Me.AddFacultyToolStripMenuItem.Text = "Add Faculty"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddDepartmentToolStripMenuItem1})
        Me.MenuStrip2.Location = New System.Drawing.Point(95, 1)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(125, 25)
        Me.MenuStrip2.TabIndex = 36
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'AddDepartmentToolStripMenuItem1
        '
        Me.AddDepartmentToolStripMenuItem1.BackgroundImage = CType(resources.GetObject("AddDepartmentToolStripMenuItem1.BackgroundImage"), System.Drawing.Image)
        Me.AddDepartmentToolStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddDepartmentToolStripMenuItem1.Name = "AddDepartmentToolStripMenuItem1"
        Me.AddDepartmentToolStripMenuItem1.Size = New System.Drawing.Size(117, 21)
        Me.AddDepartmentToolStripMenuItem1.Text = "Add Department"
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddProgrammesToolStripMenuItem2})
        Me.MenuStrip3.Location = New System.Drawing.Point(210, 1)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(131, 25)
        Me.MenuStrip3.TabIndex = 37
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'AddProgrammesToolStripMenuItem2
        '
        Me.AddProgrammesToolStripMenuItem2.BackgroundImage = CType(resources.GetObject("AddProgrammesToolStripMenuItem2.BackgroundImage"), System.Drawing.Image)
        Me.AddProgrammesToolStripMenuItem2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddProgrammesToolStripMenuItem2.Name = "AddProgrammesToolStripMenuItem2"
        Me.AddProgrammesToolStripMenuItem2.Size = New System.Drawing.Size(123, 21)
        Me.AddProgrammesToolStripMenuItem2.Text = "Add Programmes"
        '
        'MenuStrip4
        '
        Me.MenuStrip4.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAcademicYrToolStripMenuItem3})
        Me.MenuStrip4.Location = New System.Drawing.Point(330, 1)
        Me.MenuStrip4.Name = "MenuStrip4"
        Me.MenuStrip4.Size = New System.Drawing.Size(141, 25)
        Me.MenuStrip4.TabIndex = 38
        Me.MenuStrip4.Text = "MenuStrip4"
        '
        'AddAcademicYrToolStripMenuItem3
        '
        Me.AddAcademicYrToolStripMenuItem3.BackgroundImage = CType(resources.GetObject("AddAcademicYrToolStripMenuItem3.BackgroundImage"), System.Drawing.Image)
        Me.AddAcademicYrToolStripMenuItem3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddAcademicYrToolStripMenuItem3.Name = "AddAcademicYrToolStripMenuItem3"
        Me.AddAcademicYrToolStripMenuItem3.Size = New System.Drawing.Size(133, 21)
        Me.AddAcademicYrToolStripMenuItem3.Text = "Add Academic Year"
        '
        'btnbar
        '
        Me.btnbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnbar.BackgroundImage = CType(resources.GetObject("btnbar.BackgroundImage"), System.Drawing.Image)
        Me.btnbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbar.Enabled = False
        Me.btnbar.Font = New System.Drawing.Font("Palatino Linotype", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbar.Location = New System.Drawing.Point(2, 1)
        Me.btnbar.Name = "btnbar"
        Me.btnbar.Size = New System.Drawing.Size(815, 28)
        Me.btnbar.TabIndex = 56
        Me.btnbar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbar.UseCompatibleTextRendering = True
        Me.btnbar.UseVisualStyleBackColor = True
        '
        'Tuition_Management
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(817, 461)
        Me.Controls.Add(Me.MenuStrip4)
        Me.Controls.Add(Me.MenuStrip3)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnbar)
        Me.Controls.Add(Me.tbcTuition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Tuition_Management"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tuition_Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tbcTuition.ResumeLayout(False)
        Me.TabTuition.ResumeLayout(False)
        Me.TabExamNum.ResumeLayout(False)
        Me.TabExamNum.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.MenuStrip4.ResumeLayout(False)
        Me.MenuStrip4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddProg As System.Windows.Forms.Button
    Friend WithEvents txtProgName As System.Windows.Forms.TextBox
    Friend WithEvents txtProgCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rb3yrs As System.Windows.Forms.RadioButton
    Friend WithEvents rb4yrs As System.Windows.Forms.RadioButton
    Friend WithEvents rb5yrs As System.Windows.Forms.RadioButton
    Friend WithEvents rb6yrs As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents cmbxFaculty As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFacultyname As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFID As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDeptId As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtdeptName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbfaculty As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddDept As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpYrEnd As DateTimePicker
    Friend WithEvents dtpYrStart As DateTimePicker
    Friend WithEvents btnClose As Button
    Friend WithEvents dtpResume As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents dtpBreak As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents btnAddYear As Button
    Friend WithEvents tbcTuition As TabControl
    Friend WithEvents TabTuition As TabPage
    Friend WithEvents TabExamNum As TabPage
    Friend WithEvents txtViewExamNum As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddFacultyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents AddDepartmentToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MenuStrip3 As MenuStrip
    Friend WithEvents AddProgrammesToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents MenuStrip4 As MenuStrip
    Friend WithEvents AddAcademicYrToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents btnbar As Button
End Class
