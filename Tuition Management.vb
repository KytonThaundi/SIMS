Imports System.Data.SqlClient
Imports SIMS_Core.globalVariables
Imports System.Configuration
Public Class Tuition_Management

    Dim Dtreader As SqlDataReader
    Dim rbvar As String = Nothing
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtFacultyname.Text = Nothing Then
            MsgBox("Please enter Faculty Name!")
            txtFacultyname.Focus()

        ElseIf txtFID.Text = Nothing Then
            MsgBox("Please enter A Faculty ID !")
            txtFID.Focus()

        Else
            Try
                connection.Open()
                Dim command As New SqlCommand("INSERT INTO dbo.Faculty (faculty_id, FacultyName) VALUES ('" & txtFID.Text & "','" & txtFacultyname.Text & "')", connection)
                command.ExecuteNonQuery()

                MsgBox("Faculty Added Successfully")
                connection.Close()
                txtFacultyname.Clear()
                txtFID.Clear()
                txtFacultyname.Focus()
                Call loadcmbfaculty()
                Call loadcmbxFaculty()

            Catch ex As Exception
                MsgBox("Error in population the Database. Error is :" & ex.Message)
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub Tuition_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmHome.lbusertype.Text = "Student" Then
            tbcTuition.TabPages.Remove(TabTuition)
            tbcTuition.TabPages.Remove(TabExamNum)
            tbcTuition.TabPages.Add(TabExamNum)
            btnbar.BringToFront()
            AddFacultyToolStripMenuItem.Visible = False
            AddDepartmentToolStripMenuItem1.Visible = False
            AddProgrammesToolStripMenuItem2.Visible = False
            AddAcademicYrToolStripMenuItem3.Visible = False


        Else
            tbcTuition.TabPages.Remove(TabTuition)
            tbcTuition.TabPages.Remove(TabExamNum)
            tbcTuition.TabPages.Add(TabTuition)
            GroupBox3.Enabled = False
            GroupBox2.Enabled = False
            GroupBox1.Enabled = False
            GroupBox4.Enabled = False
            btnbar.SendToBack()
            AddFacultyToolStripMenuItem.Visible = True
            AddDepartmentToolStripMenuItem1.Visible = True
            AddProgrammesToolStripMenuItem2.Visible = True
            AddAcademicYrToolStripMenuItem3.Visible = True


            Call loadcmbfaculty()
            Call loadcmbxFaculty()
            Call loadcmbDept()
        End If
    End Sub
    Private Sub loadcmbfaculty()
        connection.Open()
        Dim da As New SqlDataAdapter("SELECT faculty_id, FacultyName FROM dbo.Faculty", connection)
        Dim ds As New DataSet
        da.Fill(ds, "faculty")
        cmbfaculty.DataSource = ds.Tables(0)
        cmbfaculty.DisplayMember = "FacultyName"
        cmbfaculty.ValueMember = "faculty_id"
        connection.Close()
    End Sub
    Private Sub loadcmbxFaculty()
        connection.Open()
        Dim da1 As New SqlDataAdapter("SELECT faculty_id, FacultyName FROM dbo.Faculty", connection)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "faculty")
        cmbxFaculty.DataSource = ds1.Tables(0)
        cmbxFaculty.ValueMember = "faculty_id"
        cmbxFaculty.DisplayMember = "FacultyName"

        connection.Close()
    End Sub
    Private Sub loadcmbDept()
        connection.Open()
        Dim da2 As New SqlDataAdapter("SELECT Dept_id, DeptName FROM dbo.Department", connection)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "dept")
        cmbDept.DataSource = ds2.Tables(0)
        cmbDept.ValueMember = "Dept_id"
        cmbDept.DisplayMember = "DeptName"
        connection.Close()
    End Sub

    Public Sub loadcmbSMProgOfStudy()
        connection.Open()
        Dim da3 As New SqlDataAdapter("SELECT Prog_id, ProgName FROM dbo.Programme", connection)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "prog")
        StudentManager.cmbSMProgOfStudy.DataSource = ds3.Tables(0)
        StudentManager.cmbSMProgOfStudy.ValueMember = "Prog_id"
        StudentManager.cmbSMProgOfStudy.DisplayMember = "ProgName"
        connection.Close()

    End Sub

    Private Sub btnAddDept_Click(sender As Object, e As EventArgs) Handles btnAddDept.Click
        If txtdeptName.Text = Nothing Then
            MsgBox("Please enter Departrment Name!")
            txtdeptName.Focus()

        ElseIf txtDeptId.Text = Nothing Then
            MsgBox("Please enter A Department ID !")
            txtDeptId.Focus()

        ElseIf cmbfaculty.Text = Nothing Then
            MsgBox("Please select a faculty!")
            cmbfaculty.Focus()

        Else
            Try
                connection.Open()

                Dim command As New SqlCommand("INSERT INTO dbo.Department(Dept_id,DeptName,faculty_id) VALUES('" & txtDeptId.Text & "','" & txtdeptName.Text & "','" & cmbfaculty.SelectedValue & "')", connection)
                command.ExecuteNonQuery()

                MsgBox("Faculty Added Successfully")
                connection.Close()
                txtdeptName.Clear()
                txtDeptId.Clear()
                txtdeptName.Focus()
                Call loadcmbDept()

            Catch ex As Exception
                MsgBox("Error in population the Database. Error is :" & ex.Message)
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub btnAddProg_Click(sender As Object, e As EventArgs) Handles btnAddProg.Click

        If txtProgName.Text = Nothing Then
            MsgBox("Please enter Programme Name!")
            txtProgName.Focus()

        ElseIf txtProgCode.Text = Nothing Then
            MsgBox("Please enter A Programme Code !")
            txtProgCode.Focus()
        Else

            If rb3yrs.Checked = True Then
                rbvar = "3"
                Call AddProg()
            ElseIf rb4yrs.Checked = True Then
                rbvar = "4"
                Call AddProg()
            ElseIf rb5yrs.Checked = True Then
                rbvar = "5"
                Call AddProg()
            ElseIf rb6yrs.Checked = True Then
                rbvar = "6"
                Call AddProg()
            ElseIf rbvar = Nothing Then
                MsgBox("Please set the Programe duration")
            End If

        End If
    End Sub

    Private Sub AddProg()
        Try
            connection.Open()

            Dim command As New SqlCommand("INSERT INTO dbo.Programme(Prog_id, ProgName, Faculty_id, Dept_id, Duration)VALUES('" & txtProgCode.Text & "','" & txtProgName.Text & "','" & cmbxFaculty.SelectedValue & "','" & cmbDept.SelectedValue & "','" & rbvar & "')", connection)
            command.ExecuteNonQuery()

            MsgBox("Programme Added Successfully")
            connection.Close()
            txtProgName.Clear()
            txtProgCode.Clear()
            txtProgName.Focus()
            Call loadcmbSMProgOfStudy()

        Catch ex As Exception
            MsgBox("Error in population the Database. Error is :" & ex.Message)
            connection.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        msgResult = MessageBox.Show("Closing window, Comfirm?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgResult = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnAddYear_Click(sender As Object, e As EventArgs) Handles btnAddYear.Click
        Dim Add As Integer = 0
        Dim Add2 As Integer = 0
        Dim Add3 As Integer = 0
        Dim NumOfMonths = 0

        If dtpBreak.Value <= dtpYrStart.Value Then
            MessageBox.Show("Invalid Start and Break year Dates", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            NumOfMonths = MonthDifference(dtpBreak.Value, dtpYrStart.Value)
            If NumOfMonths < 4 Then
                MessageBox.Show("First semester Must Have a minimum of 4 Months", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                Add = 1
            End If
        End If

        If dtpResume.Value <= dtpBreak.Value Then
            MessageBox.Show("A Break Can not be Less than or equal to 0 ", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            Add3 = 1
        End If

        If dtpYrEnd.Value <= dtpResume.Value Then
            MessageBox.Show("Invalid Resume and End year Dates", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            NumOfMonths = MonthDifference(dtpYrEnd.Value, dtpResume.Value)
            If NumOfMonths < 4 Then
                MessageBox.Show("Second semester Must Have a minimum of 4 Months", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                Add2 = 1
            End If
        End If

        If Add = 1 And Add2 = 1 And Add3 = 1 Then
            'ADD to DB
            connection.Close()
            connection.Open()
            Dim strSQL As String = "SELECT [YrEnd] FROM [dbo].[AcademicYear] ORDER BY [YrEnd] ASC"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count <= 0 Then
                connection.Close()
                connection.Open()

                Dim cmd As New SqlCommand("INSERT INTO [dbo].[AcademicYear] ([YrBegin],[YrBreak],[YrResume],[YrEnd]) VALUES ('" & dtpYrStart.Text & "','" & dtpBreak.Text & "','" & dtpResume.Text & "','" & dtpYrEnd.Text & "')", connection)
                cmd.CommandType = CommandType.Text

                If (cmd.ExecuteNonQuery().Equals(1)) Then
                    MessageBox.Show("Accademic year Added Successfully", "Student Infolmation Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                For Each dr1 As DataRow In dt.Rows
                    If (dr1("YrEnd")).Substring((dr1("YrEnd")).Length - 4) = (dtpYrStart.Text.ToString).Substring((dtpYrStart.Text.ToString).Length - 4) Then
                        MessageBox.Show("Academic Year already in the system! ", "Student Infolmation Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        connection.Close()
                        Exit For
                        Exit Sub
                    Else
                        connection.Close()
                        connection.Open()

                        Dim cmd As New SqlCommand("INSERT INTO [dbo].[AcademicYear] ([YrBegin],[YrBreak],[YrResume],[YrEnd]) VALUES ('" & dtpYrStart.Text & "','" & dtpBreak.Text & "','" & dtpResume.Text & "','" & dtpYrEnd.Text & "')", connection)
                        cmd.CommandType = CommandType.Text

                        If (cmd.ExecuteNonQuery().Equals(1)) Then
                            MessageBox.Show("Accademic year Added Successfully", "Student Infolmation Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        Exit For
                        Exit Sub

                    End If

                Next
                connection.Close()
            End If
            connection.Close()
        Else
            MessageBox.Show("Adding Academic Year Failed! ", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub AddFacultyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFacultyToolStripMenuItem.Click
        GroupBox3.Enabled = True
        GroupBox2.Enabled = False
        GroupBox1.Enabled = False
        GroupBox4.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddDepartmentToolStripMenuItem1.Click
        GroupBox3.Enabled = False
        GroupBox2.Enabled = True
        GroupBox1.Enabled = False
        GroupBox4.Enabled = False
    End Sub

    Private Sub AddProgrammesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AddProgrammesToolStripMenuItem2.Click
        GroupBox3.Enabled = False
        GroupBox2.Enabled = False
        GroupBox1.Enabled = True
        GroupBox4.Enabled = False
    End Sub

    Private Sub AddAcademicYrToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AddAcademicYrToolStripMenuItem3.Click
        GroupBox3.Enabled = False
        GroupBox2.Enabled = False
        GroupBox1.Enabled = False
        GroupBox4.Enabled = True
    End Sub

End Class