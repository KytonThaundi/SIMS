Imports System.Data.SqlClient
Imports SIMS.The_MileLtd.globalVariables
Imports System.Configuration
Public Class Report

    Dim status As String = Nothing
    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadcmbcmbxReportProgOS()
        cmbxReportProgOS.Text = Nothing
        loadcmbxRClass()
        cmbxRClass.Text = Nothing
        cmbxReportstr.Items.Clear()
        cmbxReportstr.Items.Add("Grades")
        'cmbxReportstr.Items.Add("Attendance")
        cmbxReportstr.Items.Add("Registered Students")
        cmbxReportstr.Items.Add("Unregistered Students")
        'cmbxReportstr.Items.Add("Module")
        cmbxReportstr.Items.Add("Major Courses")
        dgvReports.DataSource = Nothing
        cmbxReportstr.SelectedItem = Nothing
        cmbxReportstr.Text = Nothing
        Label5.Visible = False
        cmbxRModule.Visible = False
        checkb.Visible = False
    End Sub
    Public Sub filtercmbxRClass()
        cmbxRClass.Text = Nothing
        connection.Close()
        If Not cmbxReportProgOS.Text.ToString = vbNullString Then
            connection.Open()
            Dim da3 As New SqlDataAdapter("Select [Class_Id] FROM [dbo].[Class] WHERE [Class_Id] Like '" & cmbxReportProgOS.SelectedValue.ToString & "%'", connection)
            Dim ds3 As New DataSet
            da3.Fill(ds3, "class")
            Me.cmbxRClass.DataSource = ds3.Tables(0)
            Me.cmbxRClass.ValueMember = "Class_Id"
            Me.cmbxRClass.DisplayMember = "Class_Id"
            connection.Close()
        End If
    End Sub

    Public Sub loadcmbxRClass()
        connection.Close()
        connection.Open()
        Dim da3 As New SqlDataAdapter("SELECT [Class_Id] FROM [dbo].[Class]", connection)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "class")
        Me.cmbxRClass.DataSource = ds3.Tables(0)
        Me.cmbxRClass.ValueMember = "Class_Id"
        Me.cmbxRClass.DisplayMember = "Class_Id"
        connection.Close()

    End Sub
    Public Sub loadcmbcmbxReportProgOS()
        connection.Close()
        connection.Open()
        Dim da3 As New SqlDataAdapter("SELECT Prog_id, ProgName FROM dbo.Programme", connection)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "prog")
        Me.cmbxReportProgOS.DataSource = ds3.Tables(0)
        Me.cmbxReportProgOS.ValueMember = "Prog_id"
        Me.cmbxReportProgOS.DisplayMember = "ProgName"
        connection.Close()

    End Sub
    Private Sub cmbxReportProgOS_TextChanged(sender As Object, e As EventArgs) Handles cmbxReportProgOS.TextChanged
        filtercmbxRClass()
    End Sub

    Dim dgv As DataGridView
    Private Sub gradesviewReport()
        dgv = dgvReports
        Try
            connection.Open()
            Dim strSQL As String = "SELECT [ExamNum] AS [Examination Number], [Course_id] As [Course Code],(SELECT [CourseName] FROM [dbo].[Course] WHERE [Course_id] = [dbo].[Grade].[Course_id]) AS [Course Name], [Grade] AS [Grade (%)] FROM [dbo].[Grade] WHERE [ExamNum] like '" & cmbxRClass.SelectedValue.ToString & "%'"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "Grades")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
            connection.Close()
            If dgv.RowCount <= 0 Then
                MsgBox("No Grades For " + cmbxRClass.SelectedValue + " Are Currently not Available!", MsgBoxStyle.Critical)
            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub loadgradesperModule()
        dgv = dgvReports
        Try
            connection.Close()
            connection.Open()
            Dim strSQL As String = "SELECT [ExamNum] AS [Examination Number], [Course_id] As [Course Code],(SELECT [CourseName] FROM [dbo].[Course] WHERE [Course_id] = [dbo].[Grade].[Course_id]) AS [Course Name], [Grade] AS [Grade (%)] FROM [dbo].[Grade] WHERE [ExamNum] like '" & cmbxRClass.SelectedValue.ToString & "%' AND [dbo].[Grade].[Course_id] = '" & cmbxRModule.SelectedValue & "'"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "Grades")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
            connection.Close()
            If dgv.RowCount <= 0 Then
                MsgBox(cmbxRClass.SelectedValue + " Grades For " + cmbxRModule.Text + " Are Currently not Available!", MsgBoxStyle.Critical)
                connection.Close()
            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub



    Private Sub loadMajors()
        dgv = dgvReports
        Try
            connection.Open()
            Dim strSQL As String = "SELECT [Course_id] AS [Course Code],(select [CourseName] from dbo.Course where Course_id = dbo.Major.Course_id) AS [Course Name] ,[Prog_id] AS [Programme Code],(select ProgName From dbo.Programme where Prog_id = dbo.Major.Prog_id)AS [Programme Name], [YrOStudy]AS [Year Of Study] FROM [dbo].[Major] WHERE [dbo].[Major].[Prog_id] ='" & cmbxReportProgOS.SelectedValue & "' AND [dbo].[Major].[Prog_id]+[dbo].[Major].[YrOStudy] = '" & cmbxRClass.SelectedValue & "' ORDER BY [Course_id] ASC"
            connection.Close()
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "Courses")
            dgv.DataSource = ds.Tables(0)
            dgv.Columns(4).Visible = False
            dgv.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub loadRegiState()
        dgv = dgvReports

        Try
            connection.Close()
            connection.Open()
            ' "(Select [Class_Id] FROM [dbo].[Student_Class] WHERE [Student_Id] = [dbo].[Student].[Student_Id]) As [Class]," &
            Dim strSQL As String = " Select [Student_Id] As [Registration Number],([Fname] +' '+[Surname]) AS [Student Name]," &
                "(select [ProgName] from [dbo].[Programme] where [Prog_id] = [dbo].[Student].[ProgramOfStudy]) As [Programme Of Study]," &
            "[Gender],[YOA] As [Year of Admission] FROM [dbo].[Student] Where [ProgramOfStudy] ='" & cmbxReportProgOS.SelectedValue & "'" &
            "And [RegStatus] ='" & status & "'"

            connection.Close()
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "registered")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
    Private Sub loadcmbxRModule()

        Try
            connection.Close()
            connection.Open()
            Dim strSQL As String = "SELECT  [Course_id] , [CourseName] FROM [dbo].[Course] ORDER BY [Course_id] ASC "
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "course")
            cmbxRModule.DataSource = ds.Tables(0)
            cmbxRModule.DisplayMember = "CourseName"
            cmbxRModule.ValueMember = "Course_id"
            connection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub

    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        If cmbxReportstr.SelectedItem = "Grades" Then
            dgvReports.DataSource = Nothing
            If checkb.Checked = True Then
                loadgradesperModule()
            Else
                gradesviewReport()
            End If
        ElseIf cmbxReportstr.SelectedItem = "Attendance" Then
            checkb.Checked = False
            Label5.Visible = False
            cmbxRModule.Visible = False
            cmbxRModule.DataSource = Nothing
            dgvReports.DataSource = Nothing
        ElseIf cmbxReportstr.SelectedItem = "Registered Students" Then
            status = "1"
            loadRegiState()
        ElseIf cmbxReportstr.SelectedItem = "Unregistered Students" Then
            status = "0"
            loadRegiState()
        ElseIf cmbxReportstr.SelectedItem = "Module" Then
            checkb.Checked = False
            Label5.Visible = False
            cmbxRModule.Visible = False
            cmbxRModule.DataSource = Nothing
            dgvReports.DataSource = Nothing
        ElseIf cmbxReportstr.SelectedItem = "Major Courses" Then
            checkb.Checked = False
            Label5.Visible = False
            cmbxRModule.Visible = False
            cmbxRModule.DataSource = Nothing
            dgvReports.DataSource = Nothing
            loadMajors()

        Else

        End If
    End Sub

    Private Sub cmbxReportstr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxReportstr.SelectedIndexChanged
        If cmbxReportstr.SelectedIndex = 0 Then
            checkb.Visible = True
        Else
            checkb.Checked = False
            checkb.Visible = False
            Label5.Visible = False
            cmbxRModule.Visible = False
            cmbxRModule.DataSource = Nothing
            dgvReports.DataSource = Nothing
        End If

    End Sub

    Private Sub checkb_CheckedChanged(sender As Object, e As EventArgs) Handles checkb.CheckedChanged
        If checkb.Checked = True Then
            Label5.Visible = True
            loadcmbxRModule()
            cmbxRModule.Visible = True
        Else
            Label5.Visible = False
            cmbxRModule.DataSource = Nothing
            cmbxRModule.Visible = False

        End If
    End Sub

    Private Sub cmbxRModule_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbxRModule.SelectedValueChanged
        btnViewReport.Focus()
    End Sub
End Class