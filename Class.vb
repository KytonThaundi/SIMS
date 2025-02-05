Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports SIMS_Core.globalVariables
Imports System.Configuration

Public Class Lecturers

    Dim connStr As String = ConfigurationManager.ConnectionStrings("MyDBConnection").ConnectionString
    Dim conn As New SqlConnection(connStr)
    Private myBindingSource As New BindingSource
    Dim SerialPort As New System.IO.Ports.SerialPort()
    Dim CR As String
    Dim pcname As String = System.Windows.Forms.SystemInformation.UserDomainName
    Dim table As DataTable

    Private Sub loadSID()

        conn.Open()
        Dim da As New SqlDataAdapter("SELECT * FROM dbo.Student ORDER BY Student_id ASC", conn)
        Dim ds As New DataSet
        da.Fill(ds, "SID")
        cmbxGBSID.DataSource = ds.Tables(0)
        cmbxGBSID.DisplayMember = "Student_id"
        cmbxGBSID.ValueMember = "Student_id"
        conn.Close()

    End Sub
    Private Sub Lecturers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnViewAssigPannel.Visible = False
        btnPostAssignPannel.Visible = False
        lbCDate.Text = Today.ToLongDateString
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.Visible = False
        cmbxSem.Items.Add("SEMESTER1")
        cmbxSem.Items.Add("SEMESTER2")
        cmbxClass.Text = Nothing
        btnBack.Visible = False


    End Sub

    Private Sub AssignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignmentToolStripMenuItem.Click

        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.TabPages.Add(TabAssignment)
        TabLect.Visible = True
        btnBack.Visible = True
        dgvviewAssign.DataSource = Nothing
        txtPreviewAssign.Text = Nothing
        loadcmbxCourseAssign()
        loadcmbxClassAssign()
        cmbxClassAssign.Text = Nothing
        cmbxCourseAssign.Text = Nothing
        'lbMessage.ReadOnly = True
        If frmHome.lbusertype.Text = "Student" Then
            gpbPostAssign.Visible = False
            gpbViewAssign.Visible = True
            btnViewAssign.Visible = True
        ElseIf frmHome.lbusertype.Text = "Admin" Then
            gpbPostAssign.Visible = True
            gpbViewAssign.Visible = False
            btnViewAssign.Visible = True
            btnSaveAssign.Visible = False
            btnEditAssign.Visible = False
        End If
    End Sub

    Private Sub GradesManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GradesManagementToolStripMenuItem.Click
        gpbLoadClass.Enabled = True
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Add(TabGrade)
        TabLect.Visible = True
        btnBack.Visible = True
        Call loadCourse()
        Call loadClasses()
        If dgvClass.ColumnCount > 0 Then
            Me.dgvClass.Columns.RemoveAt(0)
            dgvClass.DataSource = Nothing
        End If
        LbClass_course.Visible = False

    End Sub

    Private Sub loadCourse()

        conn.Open()
        Dim da1 As New SqlDataAdapter("SELECT Course_id, CourseName FROM dbo.Course", conn)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "Course")
        cmbxCourse.DataSource = ds1.Tables(0)
        cmbxCourse.ValueMember = "Course_id"
        cmbxCourse.DisplayMember = "CourseName"
        conn.Close()

    End Sub

    Private Sub loadClasses()

        conn.Open()
        Dim da2 As New SqlDataAdapter("SELECT Class_id, ClassName FROM dbo.Class", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "class")
        cmbxClass.DataSource = ds2.Tables(0)
        cmbxClass.ValueMember = "Class_id"
        cmbxClass.DisplayMember = "Class_id"
        conn.Close()

    End Sub




    Private Sub cmbxLecSID_DropDown(sender As Object, e As EventArgs) Handles cmbxClass.DropDown
        Call loadSID()
    End Sub

    Private Sub cmbxLecSID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxClass.SelectedIndexChanged

    End Sub

    Private Sub AnnouncementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnouncementsToolStripMenuItem.Click
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.TabPages.Add(TabAnnouncement)
        TabLect.Visible = True
        btnBack.Visible = True
        If frmHome.lbusertype.Text = "Admin" Then
            gpbPostAnnounce.Visible = True
            If gpbPostAnnounce.Visible = True Then
                directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements"
                If Directory.Exists(directorystr) Then
                    ' This path is a directory.
                    dgv = dgvcompAnnounce
                    Call loadarchivedgv(directorystr)
                    dgv.Columns(3).Visible = False
                    dgv.Columns(0).HeaderText = "Announcements"
                    dgv.ClearSelection()
                Else
                    MsgBox("NO Announcements have been Posted! ", MessageBoxIcon.Warning)
                End If
            End If
            btnCancelAnnounce.PerformClick()
        ElseIf frmHome.lbusertype.Text = "Student" Then
            gpbPostAnnounce.Visible = False
            directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements"
            If Directory.Exists(directorystr) Then
                ' This path is a directory.
                dgv = dgvAnnouncements
                Call loadarchivedgv(directorystr)
                dgv.Columns(3).Visible = False
                dgv.Columns(0).HeaderText = "Announcements"
                dgv.ClearSelection()
                txtAnnouncement.Clear()
                txtAnnounceTittle.Clear()
            Else
                MsgBox("NO Announcements have been Posted! ", MessageBoxIcon.Warning)

            End If
        ElseIf frmHome.lbusertype.Text = "Custom" Then
            If Postannounce = "Yes" Then
                gpbPostAnnounce.Visible = True
                If gpbPostAnnounce.Visible = True Then
                    directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements"
                    If Directory.Exists(directorystr) Then
                        ' This path is a directory.
                        dgv = dgvcompAnnounce
                        Call loadarchivedgv(directorystr)
                        dgv.Columns(3).Visible = False
                        dgv.Columns(0).HeaderText = "Announcements"
                        dgv.ClearSelection()
                    Else
                        MsgBox("NO Announcements have been Posted! ", MessageBoxIcon.Warning)
                    End If
                End If
                btnCancelAnnounce.PerformClick()
            Else
                gpbPostAnnounce.Visible = False
                directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements"
                If Directory.Exists(directorystr) Then
                    ' This path is a directory.
                    dgv = dgvAnnouncements
                    Call loadarchivedgv(directorystr)
                    dgv.Columns(3).Visible = False
                    dgv.Columns(0).HeaderText = "Announcements"
                    dgv.ClearSelection()
                    txtAnnouncement.Clear()
                    txtAnnounceTittle.Clear()
                Else
                    MsgBox("NO Announcements have been Posted! ", MessageBoxIcon.Warning)

                End If
            End If
        End If
    End Sub
    Dim colu As New DataGridViewCheckBoxColumn
    Private Sub AttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttendanceToolStripMenuItem.Click
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.TabPages.Add(TabAttendance)
        TabLect.Visible = True
        btnBack.Visible = True
        cmbx = cmbxCourseAttend
        loadcmbx()
        conn.Close()
        loadcmbxClassAttend()


    End Sub

    Private BMP As Bitmap

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvGrades.RowCount <= 0 Then
            MsgBox("Please Specify the Student to view grades!", MsgBoxStyle.Critical)
        Else

            Dim pd As New PrintDocument
            Dim pdialog As New PrintDialog
            Dim ppd As New PrintPreviewDialog
            BMP = New Bitmap(gbGradebook.Width, gbGradebook.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            gbGradebook.DrawToBitmap(BMP, New Rectangle(0, 0, gbGradebook.Width, gbGradebook.Height))
            AddHandler pd.PrintPage, (Sub(s, args)
                                          args.Graphics.DrawImage(BMP, 0, 35)
                                          args.HasMorePages = False
                                      End Sub)
            'choose a printer
            pdialog.ShowDialog()
            pd.PrinterSettings.PrinterName = pdialog.PrinterSettings.PrinterName

            If pd.PrinterSettings.CanDuplex.ToString Then
                pd.PrinterSettings.Duplex = Duplex.Vertical
            End If

            'Preview the document
            ppd.Document = pd
            ppd.ShowDialog()

            pd.Print()      'actually print data
        End If
    End Sub

    Private Sub btnViewGrade_Click(sender As Object, e As EventArgs) Handles btnViewGrade.Click
        lbYr.Text = "FINAL RESULTS: " + (dtpYr.Value.Year).ToString + " ACADEMIC YEAR,  " + cmbSem.SelectedItem

        conn.Open()
        Dim command As New SqlCommand("SELECT Student_Id, Fname, Surname FROM dbo.Student WHERE  Student_Id = '" & Convert.ToString(cmbxGBSID.SelectedValue) & "'", conn)
        Try
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read

                cmbxVariable.Text = "" & reader("Fname") & " " & reader("Surname") & " "
            End While
            lbStudent.Text = cmbxVariable.Text + " (" + cmbxGBSID.SelectedValue.ToString + ")"
            conn.Close()
            Lbcomment.Text = "[College Principal's Comment on Students Perfomance]"
            Call gradesview()

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()
        'Lbcomment.Text = "[College Principal's Comment on Students Perfomance]"

    End Sub

    Private Sub gradesview()
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Course_id] As [Course Code], (SELECT [CourseName] FROM [dbo].[Course] WHERE [Course_id] = [dbo].[Grade].[Course_id]) AS [Course Name], [Grade] AS [Grade (%)] FROM [dbo].[Grade] WHERE [ExamNum] = (SELECT [ExamNum] FROM [dbo].[Exam] WHERE [Student_id] = '" & cmbxGBSID.Text & "')"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim R As DataRow = dt.NewRow
                R("Grade (%)") = Nothing
                dt.Rows.Add(R)
                dgvGrades.DataSource = dt
                dgvGrades.ClearSelection()

                'now if there are rows loop through to find the average
                Dim total As Decimal = 0
                Dim iGradeColumnIndex = 2
                For i As Integer = 0 To dgvGrades.RowCount - 2
                    total += dgvGrades.Rows(i).Cells(2).Value
                Next
                'now display the average
                Dim f = New Font("Times New Roman", 12, FontStyle.Bold)
                dgvGrades.Rows(dgvGrades.Rows.Count - 1).Cells(1).Style.Font = f
                Me.dgvGrades.Rows(dgvGrades.Rows.Count - 1).Cells(2).Style.Font = f
                dgvGrades.Rows(dgvGrades.Rows.Count - 1).Cells(1).Value = "Average Grade"
                dgvGrades.Rows(dgvGrades.Rows.Count - 1).Cells(2).Value = Math.Round(total / (dgvGrades.Rows.Count - 1), 2)

            Else
                MsgBox("Grades Are Currently not Available!", MsgBoxStyle.Critical)
                'dgvGrades.Rows.RemoveAt(0)
            End If

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try


    End Sub
    Private Sub btnLoardClass_Click(sender As Object, e As EventArgs) Handles btnLoardClass.Click

        Call loadClass()
        LbClass_course.Text = cmbxClass.Text + "  " + cmbxCourse.Text + "  Final Grades for " + cmbxSem.SelectedItem
        gpbLoadClass.Enabled = False
        dgvClass.Columns(0).ReadOnly = True
        LbClass_course.Visible = True
    End Sub

    Private Sub loadClass()
        Try
            conn.Open()
            Dim strSQL As String = "SELECT ExamNum AS [Exam Number] FROM dbo.Exam WHERE Class like'%" & cmbxClass.Text & "%' ORDER BY ExamNum ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            ds.Tables.Clear()
            da.Fill(ds, "ExamNum")
            dgvClass.DataSource = ds.Tables("ExamNum")
            If dgvClass.ColumnCount() = 1 Then
                Dim col As New DataGridViewTextBoxColumn
                col.DataPropertyName = Nothing
                col.HeaderText = "Grade"
                col.Name = "grade"
                dgvClass.Columns.Add(col)
                dgvClass.CurrentCell = dgvClass(1, 0)
            Else
                dgvClass.CurrentCell = dgvClass(1, 0)
            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnSaveGrade_Click(sender As Object, e As EventArgs) Handles btnSaveGrade.Click
        If dgvClass.RowCount >= 0 Then

            Dim exit2ndFor As Boolean = False
            For i1 As Integer = 0 To Me.dgvClass.Columns.Count - 1
                For i2 As Integer = 0 To Me.dgvClass.Rows.Count - 1
                    Dim comd As SqlCommand = conn.CreateCommand()
                    Try
                        conn.Open()
                        comd.Connection = conn
                        comd.CommandText = "INSERT INTO dbo.Grade(ExamNum, Course_id, Grade) VALUES(@ExamNum, @Course_id, @Grade)"

                        'Adding Parameters
                        comd.Parameters.Add("@ExamNum", SqlDbType.VarChar, 50)
                        comd.Parameters.Add("@Course_id", SqlDbType.VarChar, 50)
                        comd.Parameters.Add("@Grade", SqlDbType.VarChar, 50)

                        comd.Prepare()
                        'Data Inserted
                        For Each row As DataGridViewRow In dgvClass.Rows
                            comd.Parameters("@ExamNum").Value = row.Cells(0).Value.ToString
                            comd.Parameters("@Course_id").Value = cmbxCourse.SelectedValue.ToString
                            comd.Parameters("@Grade").Value = row.Cells(1).Value.ToString
                            comd.ExecuteNonQuery()
                        Next

                        conn.Close()
                        ' Audit Trail
                        Try
                            ipadd()
                            Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                            Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
                            cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                            cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                            cmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                            cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                            cmd.Parameters.AddWithValue("@TransTyp", "Post Grades")
                            cmd.Parameters.AddWithValue("@TransVal", cmbxClass.SelectedValue + ", " + cmbxCourse.SelectedValue.ToString + ", " + dtpGYr.Value.ToString + ", " + cmbxSem.Text)
                            conn.Close()
                            conn.Open()
                            cmd.ExecuteNonQuery().Equals(1)
                            conn.Close()

                        Catch ex As SqlException
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                        End Try
                        conn.Close()
                        cmbxSem.Text = Nothing
                        cmbxClass.Text = Nothing
                        cmbxCourse.Text = Nothing
                        dtpGYr.Text = Nothing
                        gpbLoadClass.Enabled = True
                        If dgvClass.ColumnCount >= 0 Then
                            Me.dgvClass.Columns.RemoveAt(0)
                            dgvClass.DataSource = Nothing
                        End If
                        MessageBox.Show("Grades successfully Entered", "Grades ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error :" & ex.ToString())
                    Finally
                        conn.Close()
                    End Try
                    exit2ndFor = True
                    Exit For
                Next
                If exit2ndFor Then Exit For
            Next
        Else
            MessageBox.Show("Select Class and Course", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If cmbxClassAssign.SelectedValue = Nothing Then
            MsgBox("Please Select Class!", MessageBoxIcon.Warning)
        ElseIf cmbxCourseAssign.SelectedValue = Nothing Then
            MsgBox("Please Select Course!", MessageBoxIcon.Warning)
        Else
            Dim myFolderDlog As New FolderBrowserDialog()
            Dim destnPath As String
            Dim content As String
            Dim path As String
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                destnPath = FolderBrowserDialog1.SelectedPath
                content = dgvviewAssign.CurrentRow.Cells(0).Value.ToString + ".pdf"
                path = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + ""
                Dim File_To_Copy As String = ("" & path & "\" & content & "")
                Dim NewCopy As String = ("" & destnPath & "\" & content & "")

                If System.IO.File.Exists(File_To_Copy) = True Then
                    Try
                        System.IO.File.Copy(File_To_Copy, NewCopy)
                        MsgBox("Downlod Complete!", MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("File " & content & " alredy exists in " & destnPath & "")
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub CLassesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLassesToolStripMenuItem.Click
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Add(TabClasses)
        TabLect.Visible = True
        btnBack.Visible = True
        loadClassStudents()
        loadcmbxStClases()
        loadcmbxClassDept()
    End Sub
    Dim dgv As New DataGridView
    Private Sub loadClassStudents()
        dgv = dgvClassStudents
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Student_Id],([Fname]+' '+[Surname]) As [Student],[Gender],[ProgramOfStudy] AS [Programme Of Study],[YOA] AS [Year of Admission] FROM [dbo].[Student] ORDER BY [Student_Id] ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "students")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub loadcmbxClassDept()

        conn.Open()
        Dim da2 As New SqlDataAdapter("SELECT Dept_id, DeptName FROM dbo.Department", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "dept")
        cmbxClassDept.DataSource = ds2.Tables(0)
        cmbxClassDept.ValueMember = "Dept_id"
        cmbxClassDept.DisplayMember = "DeptName"
        conn.Close()
    End Sub

    Private Sub loadcmbxStClases()

        conn.Open()
        Dim da3 As New SqlDataAdapter("SELECT [Class_id],[ClassName] FROM [dbSIMS].[dbo].[Class]", conn)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "class")
        Me.cmbxStudentsClasses.DataSource = ds3.Tables(0)
        Me.cmbxStudentsClasses.ValueMember = "Class_id"
        Me.cmbxStudentsClasses.DisplayMember = "ClassName"
        conn.Close()
    End Sub

    Private Sub btnAddToClass_Click(sender As Object, e As EventArgs) Handles btnAddToClass.Click
        populateclass()
    End Sub

    Public Sub populateclass()
        Dim classyr As String = Date.Now.Year.ToString
        If dgvClassStudents.RowCount >= 0 Then

            Dim exit_2nd_For As Boolean = False

            For j As Integer = 0 To Me.dgvClassStudents.Columns.Count - 1
                For k As Integer = 0 To Me.dgvClassStudents.Rows.Count - 1
                    Dim comd As SqlCommand = conn.CreateCommand()
                    Try
                        conn.Open()
                        comd.Connection = conn
                        comd.CommandText = "INSERT INTO [dbo].[Student_Class] ([Student_Id], [Class_Id], [ClassYear]) VALUES (@SID, @CID, @ClassYr)"

                        'Adding Parameters
                        comd.Parameters.Add("@SID", SqlDbType.VarChar, 50)
                        comd.Parameters.Add("@CID", SqlDbType.VarChar, 50)
                        comd.Parameters.Add("@ClassYr", SqlDbType.Int)
                        comd.Prepare()
                        'Data Inserted
                        For Each row As DataGridViewRow In dgvClassStudents.Rows

                            comd.Parameters("@SID").Value = row.Cells(0).Value.ToString
                            comd.Parameters("@CID").Value = cmbxStudentsClasses.SelectedValue.ToString
                            comd.Parameters("@ClassYr").Value = classyr.ToString
                            comd.ExecuteNonQuery()
                        Next

                        conn.Close()
                        cmbxStudentsClasses.Text = Nothing
                        loadClassStudents()
                        MessageBox.Show("Class Popolated Successiflully!", "Classes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error :" & ex.ToString())
                    Finally
                        conn.Close()
                    End Try
                    exit_2nd_For = True
                    Exit For
                Next
                If exit_2nd_For Then Exit For
            Next
        Else
            MessageBox.Show("Select Class and Course", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub txtclassStudentSearch_TextChanged(sender As Object, e As EventArgs) Handles txtclassStudentSearch.TextChanged
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Student_Id],([Fname]+' '+[Surname]) As [Student],[Gender],[ProgramOfStudy] AS [Programme Of Study],[YOA] AS [Year of Admission] FROM [dbo].[Student]WHERE  Student_Id like '" & txtclassStudentSearch.Text & "%'  ORDER BY [Student_Id] ASC"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Student")
            dgvClassStudents.DataSource = ds.Tables(0)
            dgvClassStudents.ClearSelection()
            conn.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub loadcmbxClassAttend()
        conn.Close()
        conn.Open()
        Dim da3 As New SqlDataAdapter("SELECT [Class_id],[ClassName] FROM [dbSIMS].[dbo].[Class]", conn)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "class")
        Me.cmbxClassAttend.DataSource = ds3.Tables(0)
        Me.cmbxClassAttend.ValueMember = "Class_id"
        Me.cmbxClassAttend.DisplayMember = "Class_id"
        conn.Close()
    End Sub

    Private Sub loaddgvClassAttend()
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Student_Id] AS [Registration Number],(SELECT ([Fname]+' '+[Surname]) FROM [dbo].[Student] WHERE  Student_Id= [dbo].[Student_Class].[Student_Id]) As [Student],(SELECT [ProgramOfStudy] FROM [dbo].[Student] WHERE  Student_Id= [dbo].[Student_Class].[Student_Id]) AS [Programme],(SELECT [Gender] FROM [dbo].[Student]WHERE  Student_Id= [dbo].[Student_Class].[Student_Id]) AS [Gender] FROM [dbo].[Student_Class] WHERE [Class_id] like '" & cmbxClassAttend.Text & "%'  ORDER BY [Student_Id] ASC"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Student")
            dgvClassAttend.DataSource = ds.Tables(0)
            conn.Close()
            dgvClassAttend.ClearSelection()

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            conn.Close()
        End Try
        colu.DataPropertyName = Nothing
        colu.HeaderText = "" + Date.Now.ToShortDateString + ""
        colu.Name = "Attend"
        colu.DisplayIndex = 4
        dgvClassAttend.Columns().Add(colu)
    End Sub
    Private Sub ResetDataGridView()
        dgvClassAttend.CancelEdit()
        dgvClassAttend.Columns.Clear()
        dgvClassAttend.DataSource = Nothing
        If dgvClassAttend.ColumnCount >= 1 Then
            dgvClassAttend.Columns.RemoveAt(0)
        End If
    End Sub
    Private Sub cmbxClassAttend_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbxClassAttend.SelectedValueChanged
        conn.Close()
        ResetDataGridView()
        loaddgvClassAttend()
        'colu.DataPropertyName = Nothing
        'colu.HeaderText = "" + Date.Now.ToShortDateString + ""
        'colu.Name = "Attend"
        'dgvClassAttend.Columns().Add(colu)
    End Sub

    Private Sub checkboxmark()
        Dim comm As SqlCommand = conn.CreateCommand()
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "INSERT INTO [dbo].[Attendance] ([Student_Id], [Course_id], [Attendance]) VALUES (@SID, @CID, @Attend)"

            'Adding Parameters
            comm.Parameters.Add("@SID", SqlDbType.VarChar, 50)
            comm.Parameters.Add("@CID", SqlDbType.VarChar, 50)
            comm.Parameters.Add("@Attend", SqlDbType.VarChar, 50)

            comm.Prepare()
            'Data Inserted

            comm.Parameters("@SID").Value = dgvClassAttend.CurrentRow.Cells(0).Value.ToString
            comm.Parameters("@CID").Value = cmbxCourseAttend.SelectedValue.ToString
            comm.Parameters("@Attend").Value = attend
            comm.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error :" & ex.ToString())
        Finally
            conn.Close()
        End Try
    End Sub
    Dim attend As String = Nothing
    Private Sub dgvClassAttend_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClassAttend.CellContentClick
        If cmbxCourseAttend.Text = Nothing Then
            MsgBox("Please select Course first!", MessageBoxIcon.Warning)
            cmbxCourseAttend.Focus()
            ResetDataGridView()
            loaddgvClassAttend()
        Else
            Dim IsTicked As Boolean = CBool(dgvClassAttend.CurrentRow.Cells(4).Value)
            If Not IsTicked Then
                attend = Date.Now.ToString
                checkboxmark()
            Else
                attend = "0"
                checkboxmark()
            End If
        End If
    End Sub

    Public Shared Sub loadcmbx()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("MyDBConnection").ConnectionString
        Dim conn As New SqlConnection(connStr)
        conn.Close()
        conn.Open()
        Dim da3 As New SqlDataAdapter("SELECT [Course_id],[CourseName] FROM [dbSIMS].[dbo].[Course]", conn)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "class")
        cmbx.DataSource = ds3.Tables(0)
        cmbx.ValueMember = "Course_id"
        cmbx.DisplayMember = "CourseName"
        conn.Close()
    End Sub

    'use the save button for updating
    'Private Sub btnSaveAttend_Click(sender As Object, e As EventArgs) Handles btnSaveAttend.Click
    '    If dgvClassAttend.RowCount >= 0 Then

    '        Dim exit2nd4 As Boolean = False
    '        For A As Integer = 0 To Me.dgvClassAttend.Columns.Count - 1
    '            For B As Integer = 0 To Me.dgvClassAttend.Rows.Count - 1

    '                Dim comm As SqlCommand = conn.CreateCommand()
    '                Try
    '                    conn.Open()
    '                    comm.Connection = conn
    '                    comm.CommandText = "INSERT INTO [dbo].[Attendance] ([Student_Id], [Course_id], [Attendance]) VALUES (@SID, @CID, @Attend)"

    '                    'Adding Parameters
    '                    comm.Parameters.Add("@SID", SqlDbType.VarChar, 50)
    '                    comm.Parameters.Add("@CID", SqlDbType.VarChar, 50)
    '                    comm.Parameters.Add("@Attend", SqlDbType.VarChar, 50)

    '                    comm.Prepare()
    '                    'Data Inserted
    '                    For Each row As DataGridViewRow In dgvClassAttend.Rows
    '                        comm.Parameters("@SID").Value = dgvClassAttend.Rows(B).Cells(4).Value
    '                        comm.Parameters("@CID").Value = cmbxCourseAttend.SelectedValue.ToString
    '                        comm.Parameters("@Attend").Value = attend
    '                        comm.ExecuteNonQuery()
    '                    Next

    '                    conn.Close()
    '                    MessageBox.Show("Attendace Sheet Completed Successfuly", "Attendance ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Catch ex As Exception
    '                    MessageBox.Show("Error :" & ex.ToString())
    '                Finally
    '                    conn.Close()
    '                End Try
    '                exit2nd4 = True
    '                Exit For
    '            Next
    '            If exit2nd4 Then Exit For
    '        Next
    '    Else
    '        MessageBox.Show("Error!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End If
    'End Sub 

    Private Sub GradeBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GradeBookToolStripMenuItem.Click
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.TabPages.Add(TabGradeBook)
        TabLect.Visible = True
        btnBack.Visible = True
        If cmbSem.Items.Count > 0 Then
            cmbSem.Items.Clear()
        End If
        cmbSem.Items.Add("SEMESTER1")
        cmbSem.Items.Add("SEMESTER2")
        Call loadSID()
        If frmHome.lbusertype.Text = "Student" Then
            cmbxGBSID.Text = Login.txtUname.Text
            cmbxGBSID.Enabled = False
        Else

            cmbxGBSID.Enabled = True
        End If
        lbStudent.Text = Nothing
        lbYr.Text = Nothing
        Lbcomment.Text = Nothing

    End Sub
    Private Sub loadcmbxCourseAssign()
        conn.Close()
        conn.Open()
        Dim da3 As New SqlDataAdapter("SELECT [Course_id],[CourseName] FROM [dbSIMS].[dbo].[Course]", conn)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "class")
        Me.cmbxCourseAssign.DataSource = ds3.Tables(0)
        Me.cmbxCourseAssign.ValueMember = "Course_id"
        Me.cmbxCourseAssign.DisplayMember = "CourseName"
        conn.Close()
    End Sub
    Private Sub loadcmbxClassAssign()
        conn.Open()
        Dim da As New SqlDataAdapter("SELECT Class_id, ClassName FROM dbo.Class", conn)
        Dim ds As New DataSet
        da.Fill(ds, "class")
        cmbxClassAssign.DataSource = ds.Tables(0)
        cmbxClassAssign.ValueMember = "Class_id"
        cmbxClassAssign.DisplayMember = "Class_id"
        conn.Close()
    End Sub
    Dim dir As String = Nothing
    Private Sub btnPostAssign_Click(sender As Object, e As EventArgs) Handles btnPostAssign.Click
        dgv = dgvpostAssign
        If txtAssgnTittle.Text = Nothing Then
            MsgBox("Assignment Tittle Required", MessageBoxIcon.Warning)
            txtAssgnTittle.Focus()

        ElseIf txtMessage.Text = Nothing Then
            MsgBox("Assignment Description Required", MessageBoxIcon.Warning)
            txtMessage.Focus()

        ElseIf cmbxClassAssign.SelectedValue = Nothing Then
            MsgBox("Please Select Class!", MessageBoxIcon.Warning)
            cmbxClassAssign.Focus()

        ElseIf cmbxCourseAssign.SelectedValue = Nothing Then
            MsgBox("Please select a course!", MessageBoxIcon.Warning)
        Else

            Dim di As DirectoryInfo = New DirectoryInfo("\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + "")
            Dim FILE_NAME As String = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + "\" + txtAssgnTittle.Text + ".txt"
            Try
                ' Determine whether the directory exists.
                If di.Exists Then
                    ' dir already exists.
                    If System.IO.File.Exists(FILE_NAME) = True Then
                        'File already exists
                        MsgBox("Assignment already uploaded!")
                        'lbMessage.Text = Nothing

                    Else
                        'File does not exist
                        FileOpen(1, FILE_NAME, OpenMode.Output)
                        For Each line In txtMessage.Lines
                            PrintLine(1, line)
                        Next
                        FileClose()
                        txtAttach.Clear()
                        txtMessage.Clear()
                        txtAssgnTittle.Clear()
                        btnEditAssign.Visible = True
                    End If
                Else

                    ' dir does not exist so does the file
                    di.Create()
                    FileOpen(1, FILE_NAME, OpenMode.Output)
                    For Each line In txtMessage.Lines
                        PrintLine(1, line)
                    Next
                    FileClose()
                    txtAttach.Clear()
                    txtMessage.Clear()
                    txtAssgnTittle.Clear()
                    btnEditAssign.Visible = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxIcon.Warning)
            End Try
            If gpbPostAssign.Visible = True Then
                If cmbxClassAssign.SelectedValue = Nothing Then
                    MsgBox("Please select class First!", MessageBoxIcon.Warning)
                Else
                    directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + ""
                    If Directory.Exists(directorystr) Then
                        ' This path is a directory.
                        Call loadarchivedgv(directorystr)
                    Else
                        MsgBox("NO " + cmbxClassAssign.SelectedValue.ToString + " Assignments have been Posted for " + cmbxCourseAssign.Text + "!", MessageBoxIcon.Warning)
                    End If


                End If
            End If
        End If

    End Sub

    Dim NewCopy As String
    Dim ftc As String


    Private Sub btnAttachAssign_Click(sender As Object, e As EventArgs) Handles btnAttachAssign.Click
        If txtAssgnTittle.Text = Nothing Then
            MsgBox("Assignment Tittle Required", MessageBoxIcon.Warning)
            txtAssgnTittle.Focus()

        ElseIf cmbxClassAssign.SelectedValue = Nothing Then
            MsgBox("Please Select Class!", MessageBoxIcon.Warning)
            cmbxClassAssign.Focus()

        ElseIf cmbxCourseAssign.SelectedValue = Nothing Then
            MsgBox("Please select a course!", MessageBoxIcon.Warning)
        Else
            txtAttach.Clear()
            OpenFileDialog1.Filter = "PDF(*.pdf)|*.pdf"
            ' "Document(*.doc,*.docx)|*.doc;*.docx|Excel(*.xls,*.xlsx)|*.xls;*.xlsx|PDF(*.pdf)|*.pdf|Text(*.txt)|*.txt|Image(*.tif,*.tiff,*.jpg,*.gif)|*.tif;*.tiff;*.jpg;*.gif"

            Dim path As String = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + ""

            Dim SourceFileOpen As New System.Windows.Forms.OpenFileDialog
            If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
                With OpenFileDialog1
                    ftc = .FileName
                    Dim ext As String = System.IO.Path.GetExtension(ftc)
                    NewCopy = Convert.ToString(path + "\" + txtAssgnTittle.Text + ext)
                    txtAttach.Text = ftc
                    If ftc = Nothing Then
                        MessageBox.Show("Please select the file to Copy")

                    ElseIf System.IO.File.Exists(ftc) = True Then

                        Dim di As DirectoryInfo = New DirectoryInfo("\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + "")
                        Dim FILE_NAME As String = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + "\" + txtAssgnTittle.Text + ".txt"
                        Try
                            ' Determine whether the directory exists.
                            If di.Exists Then
                                ' dir already exists.
                                Try
                                    System.IO.File.Copy(ftc, NewCopy)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MessageBoxIcon.Warning)
                                End Try
                            Else

                                ' dir does not exist so does the file
                                di.Create()
                                Try
                                    System.IO.File.Copy(ftc, NewCopy)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MessageBoxIcon.Warning)
                                End Try
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MessageBoxIcon.Warning)
                        End Try
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub loadarchivedgv(ByVal folderPath As String)

        table = New DataTable()
        With table
            .Columns.Add("Name", GetType(String))
            .Columns.Add("FileType", GetType(String))
            .Columns.Add("Directory", GetType(String))
            .Columns.Add("FileSize", GetType(Long))
            .Columns.Add("Issue Date", GetType(Date))
        End With

        'Declare an array of file extensions, add more if needed
        Dim exts As String = "*.txt"

        'Create a directoryinfo object
        Dim dirInfo As New IO.DirectoryInfo(folderPath)

        'Loop thru the extension array and get files for each extension type
        Dim files As IO.FileInfo() = Nothing
        For Each ext As String In exts
            files = dirInfo.GetFiles(exts, System.IO.SearchOption.AllDirectories)
            table.Rows.Clear()
            'loop thru the fileinfo array and add rows to datatable
            For Each fi As IO.FileInfo In files
                Dim fil As String = System.IO.Path.GetFileNameWithoutExtension(fi.Name)
                table.Rows.Add(fil, fi.Extension, fi.Directory, fi.Length, fi.CreationTime.Date)
            Next
        Next
        'Bind the table to the bindingsource, then the bindingsource to the datagridview
        Me.myBindingSource.DataSource = table
        dgv.DataSource = Me.myBindingSource
        dgv.Columns(2).Visible = False
        dgv.Columns(1).Visible = False
    End Sub

    Dim directorystr As String
    Private Sub btnViewAssign_Click(sender As Object, e As EventArgs) Handles btnViewAssign.Click
        If gpbPostAssign.Visible = True Then
            dgv = dgvpostAssign
        Else
            dgv = dgvviewAssign
        End If

        If cmbxClassAssign.SelectedValue = Nothing Then
            MsgBox("Please select class First!", MessageBoxIcon.Warning)
        Else
            directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + ""
            If Directory.Exists(directorystr) Then
                ' This path is a directory.
                Call loadarchivedgv(directorystr)
                dgv.ClearSelection()
            Else
                MsgBox("NO " + cmbxClassAssign.SelectedValue.ToString + " Assignments have been Posted for " + cmbxCourseAssign.Text + "!", MessageBoxIcon.Warning)
                If Not dgv.RowCount <= 0 Then
                    dgv.DataSource = Nothing
                End If
            End If
        End If

        txtPreviewAssign.Clear()
    End Sub

    Private Sub dgvviewAssign_SelectionChanged(sender As Object, e As EventArgs) Handles dgvviewAssign.SelectionChanged
        Me.txtPreviewAssign.LoadFile(directorystr + "\" + Me.dgvviewAssign.CurrentRow.Cells(0).Value.ToString + ".txt", RichTextBoxStreamType.PlainText)
        FileClose()
        Me.txtPreviewAssign.ReadOnly = True
        Dim attachment As String = Nothing
        Dim content As String

        content = dgvviewAssign.CurrentRow.Cells(0).Value.ToString + ".pdf"
        Dim Path As String = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + ""
        Dim File_To_Copy As String = ("" & Path & "\" & content & "")
        If System.IO.File.Exists(File_To_Copy) = True Then
            btnDownload.Visible = True
        Else
            btnDownload.Visible = False
        End If
        Exit Sub
    End Sub

    Private Sub btnEditAssign_Click(sender As Object, e As EventArgs) Handles btnEditAssign.Click
        formaFile = directorystr + "\" + Me.dgvpostAssign.CurrentRow.Cells(0).Value.ToString + ".txt"
        Me.txtMessage.LoadFile(directorystr + "\" + Me.dgvpostAssign.CurrentRow.Cells(0).Value.ToString + ".txt", RichTextBoxStreamType.PlainText)
        Me.txtAssgnTittle.Text = Me.dgvpostAssign.CurrentRow.Cells(0).Value.ToString
        FileClose(1)
        Me.btnEditAssign.Visible = False
        Me.btnSaveAssign.Visible = True
        Exit Sub
    End Sub

    Private Sub dgvpostAssign_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpostAssign.CellDoubleClick
        btnEditAssign.Visible = True
        btnSaveAssign.Visible = True
    End Sub
    Dim formaFile As String = Nothing

    Private Sub btnSaveAssign_Click(sender As Object, e As EventArgs) Handles btnSaveAssign.Click
        formaFile = Me.dgvpostAssign.CurrentRow.Cells(0).Value.ToString
        My.Computer.FileSystem.DeleteFile("\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + "\" + formaFile + ".txt")
        Dim FILE_NAME As String = "\\SDE-KYTON\Users\Public\SIMS_Core\" + cmbxClassAssign.SelectedValue + "\" + cmbxCourseAssign.SelectedValue + "\" + txtAssgnTittle.Text + ".txt"
        FileOpen(1, FILE_NAME, OpenMode.Output)
        For Each line In txtMessage.Lines
            PrintLine(1, line)
        Next
        FileClose(1)
        txtMessage.Clear()
        txtAssgnTittle.Clear()
        btnViewAssign.PerformClick()
        btnSaveAssign.Visible = False
        btnPostAssign.Visible = True
    End Sub

    Private Sub btnCancelAnnounce_Click(sender As Object, e As EventArgs) Handles btnCancelAnnounce.Click
        dgvcompAnnounce.ClearSelection()
        txtCompAnnaunceTittle.Clear()
        txtCompose.Clear()
        btnPostAnnounce.Visible = True
        btnEditAnnounce.Visible = False
        btnSaveAnnounce.Visible = False
        Me.txtCompose.ReadOnly = False
        Me.txtCompAnnaunceTittle.ReadOnly = False
        Me.txtCompose.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub btnPostAnnounce_Click(sender As Object, e As EventArgs) Handles btnPostAnnounce.Click
        dgv = dgvcompAnnounce
        If txtCompAnnaunceTittle.Text = Nothing Then
            MsgBox("Announcement Tittle Required", MessageBoxIcon.Warning)
            txtAssgnTittle.Focus()

        ElseIf txtCompose.Text = Nothing Then
            MsgBox("Annonucement Details Required", MessageBoxIcon.Warning)
            txtMessage.Focus()
        Else

            Dim di As DirectoryInfo = New DirectoryInfo("\\SDE-KYTON\Users\Public\SIMS_Core\Announcements")
            Dim FILE_NAME As String = Convert.ToString(di) + "\" + txtCompAnnaunceTittle.Text + ".txt"
            Try
                ' Determine whether the directory exists.
                If di.Exists Then
                    ' dir already exists.
                    If System.IO.File.Exists(FILE_NAME) = True Then
                        'File already exists
                        MsgBox("Announcement already Posted!")
                        'lbMessage.Text = Nothing

                    Else
                        'File does not exist
                        FileOpen(1, FILE_NAME, OpenMode.Output)
                        For Each line In txtCompose.Lines
                            PrintLine(1, line)
                        Next
                        FileClose()
                        txtCompose.Clear()
                        txtCompAnnaunceTittle.Clear()
                        btnEditAnnounce.Visible = True
                    End If
                Else

                    ' dir does not exist so does the file
                    di.Create()
                    FileOpen(1, FILE_NAME, OpenMode.Output)
                    For Each line In txtCompose.Lines
                        PrintLine(1, line)
                    Next
                    FileClose()
                    txtCompose.Clear()
                    txtCompAnnaunceTittle.Clear()
                    btnEditAnnounce.Visible = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxIcon.Warning)
            End Try
            If gpbPostAnnounce.Visible = True Then
                directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements"
                If Directory.Exists(directorystr) Then
                    ' This path is a directory.
                    Call loadarchivedgv(directorystr)
                    dgv.Columns(3).Visible = False
                Else
                    MsgBox("NO Announcements have been Posted! ", MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub dgvcompAnnounce_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcompAnnounce.CellContentDoubleClick
        Me.txtCompose.LoadFile("\\SDE-KYTON\Users\Public\SIMS_Core\Announcements\" + Me.dgvcompAnnounce.CurrentRow.Cells(0).Value.ToString + ".txt", RichTextBoxStreamType.PlainText)
        Me.txtCompAnnaunceTittle.Text = Me.dgvcompAnnounce.CurrentRow.Cells(0).Value.ToString
        FileClose()
        Me.txtCompose.ReadOnly = True
        Me.txtCompAnnaunceTittle.ReadOnly = True
        Me.txtCompose.BorderStyle = BorderStyle.None
        btnPostAnnounce.Visible = False
        btnEditAnnounce.Visible = True
        btnSaveAnnounce.Visible = False
    End Sub
    Private Sub btnEditAnnounce_Click(sender As Object, e As EventArgs) Handles btnEditAnnounce.Click
        btnPostAnnounce.Visible = False
        btnEditAnnounce.Visible = False
        btnSaveAnnounce.Visible = True
        Me.txtCompose.ReadOnly = False
        Me.txtCompAnnaunceTittle.ReadOnly = False
        Me.txtCompose.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub btnSaveAnnounce_Click(sender As Object, e As EventArgs) Handles btnSaveAnnounce.Click
        formaFile = Me.dgvcompAnnounce.CurrentRow.Cells(0).Value.ToString
        My.Computer.FileSystem.DeleteFile("\\SDE-KYTON\Users\Public\SIMS_Core\Announcements\" + formaFile + ".txt")
        Dim FILE_NAME As String = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements\" + txtCompAnnaunceTittle.Text + ".txt"
        FileOpen(1, FILE_NAME, OpenMode.Output)
        For Each line In txtCompose.Lines
            PrintLine(1, line)
        Next
        FileClose(1)
        If gpbPostAnnounce.Visible = True Then
            dgv = dgvcompAnnounce
            directorystr = "\\SDE-KYTON\Users\Public\SIMS_Core\Announcements"
            If Directory.Exists(directorystr) Then
                ' This path is a directory.
                Call loadarchivedgv(directorystr)
                dgv.Columns(3).Visible = False
            Else
                MsgBox("NO Announcements have been Posted! ", MessageBoxIcon.Warning)
            End If
        End If
        btnCancelAnnounce.PerformClick()
    End Sub

    Private Sub dgvAnnouncements_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnnouncements.CellDoubleClick
        Me.txtAnnouncement.LoadFile("\\SDE-KYTON\Users\Public\SIMS_Core\Announcements\" + Me.dgvAnnouncements.CurrentRow.Cells(0).Value.ToString + ".txt", RichTextBoxStreamType.PlainText)
        Me.txtAnnounceTittle.Text = Me.dgvAnnouncements.CurrentRow.Cells(0).Value.ToString
        FileClose()
        Me.txtAnnouncement.ReadOnly = True
        Me.txtAnnounceTittle.ReadOnly = True
    End Sub
    Dim MsgResult As Integer
    Private Sub btnCloseGrades_Click(sender As Object, e As EventArgs) Handles btnCloseGrades.Click
        MsgResult = MessageBox.Show(" " & frmHome.lb_loggedas.Text & " !!  You are Closing current window ! Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If MsgResult = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If

        'MsgResult = MessageBox.Show(" " & Home.lb_loggedas.Text & " !!  The System Will Shut Down ! Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)



        'If MsgResult = Windows.Forms.DialogResult.Yes Then


        '    Application.Exit()

        'End If

    End Sub

    Private Sub pbUpploaGrades_Click(sender As Object, e As EventArgs) Handles pbUpploadGrades.Click
        GradesManagementToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbAnnounce_Click(sender As Object, e As EventArgs) Handles pbAnnounce.Click
        AnnouncementsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbgradebook_Click(sender As Object, e As EventArgs) Handles pbgradebook.Click
        GradeBookToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbClasses_Click(sender As Object, e As EventArgs) Handles pbClasses.Click
        CLassesToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbClassesLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbClassesLink.LinkClicked
        CLassesToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbAssignment_Click(sender As Object, e As EventArgs) Handles pbAssignment.Click
        AssignmentToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbAssignLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbAssignLink.LinkClicked
        AssignmentToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbGradesUploadLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbGradesUploadLink.LinkClicked
        GradesManagementToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbgradebookLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbgradebookLink.LinkClicked
        GradeBookToolStripMenuItem.PerformClick()
    End Sub

    Private Sub pbAttend_Click(sender As Object, e As EventArgs) Handles pbAttend.Click
        AttendanceToolStripMenuItem.PerformClick()

    End Sub

    Private Sub pbAttendLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbAttendLink.LinkClicked
        AttendanceToolStripMenuItem.PerformClick()

    End Sub

    Private Sub pbAnnounceLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbAnnounceLink.LinkClicked
        AnnouncementsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        lbCDate.Text = Today.ToLongDateString
        TabLect.TabPages.Remove(TabAssignment)
        TabLect.TabPages.Remove(TabGrade)
        TabLect.TabPages.Remove(TabClasses)
        TabLect.TabPages.Remove(TabAnnouncement)
        TabLect.TabPages.Remove(TabAttendance)
        TabLect.TabPages.Remove(TabGradeBook)
        TabLect.Visible = False
        btnBack.Visible = False
        btnPostAssignPannel.Visible = False
        btnViewAssigPannel.Visible = False
    End Sub

    Private Sub btnSaveAttend_Click(sender As Object, e As EventArgs) Handles btnSaveAttend.Click
        cmbxClassAttend.Text = Nothing
        cmbxCourseAttend.Text = Nothing
        dgvClassAttend.DataSource = Nothing
        Me.dgvClassAttend.Columns.RemoveAt(0)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cmbxClassAttend.Text = Nothing
        cmbxCourseAttend.Text = Nothing
        dgvClassAttend.DataSource = Nothing
        Me.dgvClassAttend.Columns.RemoveAt(0)
    End Sub

    Private Sub btnViewAssigPannel_Click(sender As Object, e As EventArgs) Handles btnViewAssigPannel.Click
        Me.gpbViewAssign.Visible = True
        Me.gpbPostAssign.Visible = False
        btnViewAssigPannel.Visible = False
        btnPostAssignPannel.Visible = True
    End Sub

    Private Sub btnPostAssignPannel_Click(sender As Object, e As EventArgs) Handles btnPostAssignPannel.Click
        Me.gpbViewAssign.Visible = False
        Me.gpbPostAssign.Visible = True
        btnViewAssigPannel.Visible = True
        btnPostAssignPannel.Visible = False
    End Sub


End Class