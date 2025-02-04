Imports System.Data.SqlClient
Imports System.Globalization
Imports SIMS_Core.globalVariables
Imports System.Collections.Generic
Imports System.Runtime.Versioning
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration

Public Class frmHome
    Dim connStr As String = ConfigurationManager.ConnectionStrings("MyDBConnection").ConnectionString
    Dim conn As New SqlConnection(connStr)
    Dim selector As String = String.Empty
    Dim Bal As Double = 0
    Dim NewBal As String = String.Empty
    Dim selector1 As String = String.Empty
    Public LecDefaultPwd As Integer
    Public lectid As String
    Public Acyear As Integer = 0
    Private Sub LinkHome_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkHome.LinkClicked
        home()
    End Sub
    Private Sub home()
        LinkHome.LinkVisited = True
        LinkFin.LinkVisited = False
        LinkLib.LinkVisited = False
        LinkSProf.LinkVisited = False
        LinkTool.LinkVisited = False
        pbfinance.Show()
        pbhome.Show()
        pbstudentprof.Show()
        pbtools.Show()
        tbcDashboad.Visible = False
    End Sub
    Private Sub LinkSProf_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSProf.LinkClicked
        clearSP()
        studentprof()
        If Not lbusertype.Text = "Student" Then
            loadSID()
            cmbxstudentselect.Text = Nothing
        End If
    End Sub
    Private Sub clearSP()
        txtSPSID.Clear()
        txtSPFname.Clear()
        txtSPSurname.Clear()
        txtSPPOS.Clear()
        txtSPOnames.Clear()
        Dim dt As String = String.Empty
        dtpSPDOB.Text = Nothing
        txtSPVillage.Clear()
        txtSPTA.Clear()
        txtSPDistrict.Clear()
        txtSPNationality.Clear()
        txtSPPOBox.Clear()
        txtSPEmail.Clear()
        txtSPMobile.Clear()
        cmbGender.Text = Nothing
        txtSPCResidence.Clear()
        dtpYOA.Text = Nothing
        txtTOA.Text = Nothing
        txtAccomodation.Text = Nothing
        txtNOKFname.Clear()
        txtNOKSurname.Clear()
        txtNOKtittle.Clear()
        txtNOKMobile.Clear()
        txtNOKCResidence.Clear()
        txtNOKPOBox.Clear()
        txtNOKRelationship.Clear()
        txtNOKEmail.Clear()
    End Sub
    Private Sub loadSID()

        conn.Open()
        Dim da As New SqlDataAdapter("SELECT [Student_Id] FROM dbo.Student ORDER BY Student_Id ASC", conn)
        Dim ds As New DataSet
        da.Fill(ds, "SID")
        cmbxstudentselect.DataSource = ds.Tables(0)
        cmbxstudentselect.DisplayMember = "Student_Id"
        cmbxstudentselect.ValueMember = "Student_Id"
        conn.Close()

    End Sub
    Private Sub studentprof()
        LinkHome.LinkVisited = False
        LinkFin.LinkVisited = False
        LinkLib.LinkVisited = False
        LinkSProf.LinkVisited = True
        LinkTool.LinkVisited = False

        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabCourses)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Add(TabSProf)
        pbfinance.Hide()
        pbhome.Hide()
        pbstudentprof.Hide()
        pbtools.Hide()
        tbcDashboad.Visible = True
        LinkSProf.LinkVisited = True
        If lbusertype.Text = "Student" Then
            clearSP()
            cmbxstudentselect.Text = Login.txtUname.Text
            cmbxstudentselect.Enabled = False
            btnSPview.Enabled = False
            selector = Login.txtUname.Text
            Call getstudentinfo()
            conn.Close()
            txtSPMobile.Enabled = True
            txtSPEmail.Enabled = True
            btnSPsave.Enabled = False
            btnUpdate.Enabled = True
        Else
            cmbxstudentselect.Enabled = True
            cmbxstudentselect.Focus()
            btnSPsave.Enabled() = True
            btnUpdate.Enabled = True

        End If
    End Sub
    Private Sub LinkLib_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLib.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
        LinkHome.LinkVisited = False
        LinkFin.LinkVisited = False
        LinkLib.LinkVisited = True
        LinkSProf.LinkVisited = False
        LinkTool.LinkVisited = False
        'tbcDashboad.TabPages.Remove(TabSProf)
        'tbcDashboad.TabPages.Remove(TabCalendar)
        'tbcDashboad.TabPages.Remove(TabTools)
        'tbcDashboad.TabPages.Remove(TabFin)
        'tbcDashboad.TabPages.Remove(TabCafe)
        'tbcDashboad.TabPages.Remove(TabLib)
        'tbcDashboad.TabPages.Remove(TabCourses)
        'tbcDashboad.TabPages.Add(TabLib)
        'tbcDashboad.Visible = True
    End Sub
    Public acc As String = Nothing
    Private Sub LinkFin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkFin.LinkClicked
        finance()

    End Sub
    Private Sub finance()
        LinkHome.LinkVisited = False
        LinkFin.LinkVisited = True
        LinkLib.LinkVisited = False
        LinkSProf.LinkVisited = False
        LinkTool.LinkVisited = False
        gpbtransactionLedger.Visible = False
        pbfinance.Hide()
        pbhome.Hide()
        pbstudentprof.Hide()
        pbtools.Hide()

        If lbusertype.Text = "Admin" OrElse lbusertype.Text = "Accountant" Then
            tbcDashboad.TabPages.Remove(TabTimeTable)
            tbcDashboad.TabPages.Remove(TabAddLecturers)
            tbcDashboad.TabPages.Remove(TabSProf)
            tbcDashboad.TabPages.Remove(TabCalendar)
            tbcDashboad.TabPages.Remove(TabFin)
            tbcDashboad.TabPages.Remove(TabCafe)
            tbcDashboad.TabPages.Remove(TabLib)
            tbcDashboad.TabPages.Remove(TabCourses)
            tbcDashboad.TabPages.Remove(TabTools)
            tbcDashboad.TabPages.Add(TabFin)
            grpbxFinance.Hide()
            btnFinControl.Show()
            btnTrasactionLeger.Show()
            btnAccState.Show()
            tbcDashboad.Visible = True
            lbDate.Text = Today.Date.ToLongDateString

        ElseIf lbusertype.Text = "Student" Then
            tbcDashboad.TabPages.Remove(TabTimeTable)
            tbcDashboad.TabPages.Remove(TabAddLecturers)
            tbcDashboad.TabPages.Remove(TabSProf)
            tbcDashboad.TabPages.Remove(TabCalendar)
            tbcDashboad.TabPages.Remove(TabFin)
            tbcDashboad.TabPages.Remove(TabCafe)
            tbcDashboad.TabPages.Remove(TabLib)
            tbcDashboad.TabPages.Remove(TabCourses)
            tbcDashboad.TabPages.Remove(TabTools)
            tbcDashboad.TabPages.Add(TabFin)
            grpbxFinance.Show()
            btnFinControl.Hide()
            tbcDashboad.Visible = True
            lbDate.Text = Today.Date.ToLongDateString
            acc = lbAccNo.Text
            Call loadgdvAccState()

        Else
            tbcDashboad.TabPages.Remove(TabTimeTable)
            tbcDashboad.TabPages.Remove(TabAddLecturers)
            tbcDashboad.TabPages.Remove(TabSProf)
            tbcDashboad.TabPages.Remove(TabCalendar)
            tbcDashboad.TabPages.Remove(TabFin)
            tbcDashboad.TabPages.Remove(TabCafe)
            tbcDashboad.TabPages.Remove(TabLib)
            tbcDashboad.TabPages.Remove(TabCourses)
            tbcDashboad.TabPages.Remove(TabTools)
            tbcDashboad.TabPages.Add(TabFin)
            grpbxFinance.Show()
            btnFinControl.Hide()
            tbcDashboad.Visible = True
            lbDate.Text = Today.Date.ToLongDateString
            acc = lbAccNo.Text
            btnAccState.PerformClick()
            Call loadgdvAccState()
        End If

    End Sub
    Private Sub LinkTool_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkTool.LinkClicked
        tools()
    End Sub
    Private Sub tools()
        LinkHome.LinkVisited = False
        LinkFin.LinkVisited = False
        LinkLib.LinkVisited = False
        LinkSProf.LinkVisited = False
        LinkTool.LinkVisited = True


        pbfinance.Hide()
        pbhome.Hide()
        pbstudentprof.Hide()
        pbtools.Hide()
        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabCourses)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Add(TabTools)
        tbcDashboad.Visible = True
    End Sub
    Private Sub LinkUsermanager_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkUsermanager.LinkClicked
        Call OpenUserManager()
    End Sub

    Private Sub pbUerManager_Click(sender As Object, e As EventArgs) Handles pbUerManager.Click
        Call OpenUserManager()
    End Sub
    Private Sub OpenUserManager()
        UserManagement.ShowDialog()
    End Sub

    Private Sub pbStudentMan_Click(sender As Object, e As EventArgs) Handles pbStudentMan.Click
        Call OpenStudentManager()
    End Sub

    Private Sub LinkStudentMan_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkStudentMan.LinkClicked
        Call OpenStudentManager()
    End Sub

    Private Sub OpenStudentManager()
        StudentManager.ShowDialog()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call acYrSem()
        llExamNum.Visible = False
        rtxtExam.Visible = False
        tssTime.Text = DateAndTime.Now
        linkDeveloper.Links.Add(0, 0, "https://github.com/KytonThaundi")
        Call studenttest()
        Call loadAccNoAccBal()
    End Sub

    Private Sub linkDeveloper_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkDeveloper.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub


    Private Sub pbCalendar_Click(sender As Object, e As EventArgs) Handles pbCalendar.Click
        Call calendartab()
    End Sub

    Private Sub LLCalendar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LLCalendar.LinkClicked
        Call calendartab()
    End Sub

    Private Sub calendartab()
        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Add(TabCalendar)
        tbcDashboad.Visible = True
    End Sub
    Dim ival As Integer = 0
    Dim chngpwd As String = Nothing
    Private Sub studenttest()
        conn.Close()
        conn.Open()
        Dim command As New SqlCommand("SELECT Student_Id, Fname, Surname, RegStatus,ProgramOfStudy,YOA FROM dbo.Student WHERE  Student_Id = '" & lb_loggedas.Text & "'", conn)
        Try
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read
                If reader("Student_Id") = lb_loggedas.Text Then
                    LinkSProf.Show()
                    lb_loggedas.Text = "" & reader("Fname") & " " & reader("Surname") & ""
                    lbSName.Text = "" & reader("Fname") & " " & reader("Surname") & ""
                    lbSID.Text = reader("Student_Id")
                    lbkeepSID.Text = reader("Student_Id")
                    Dim yoa As String = reader("YOA")
                    Dim pwd As String = "" & reader("ProgramOfStudy") & "" & yoa.Substring(yoa.Length - 2) & "-" & reader("Fname") & ""

                    pwd = GenerateHash(pwd)
                    If Login.txtUname.Text = reader("Student_Id") And Login.txtPword.Text = pwd Then 'condition for checking defalt password
                        ChangePwd.lbLoginPwd.Text = pwd
                        chngpwd = "Change"
                    End If
                    'check exam numbers''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Acyear = Date.Now.Year
                    Dim command2 As New SqlCommand("SELECT * FROM [dbo].[Exam] WHERE [AcademicYear] ='" & Acyear & "' And [Student_id]='" & lbkeepSID.Text & "'and [Semester] ='" & tssSem.Text.Substring(tssSem.Text.Length - 1).ToString & "'", conn)
                    'Try
                    Dim reader2 As SqlDataReader = command2.ExecuteReader()
                    If reader2.HasRows Then
                        rtxtExam.Visible = True
                        llExamNum.Visible = True
                    Else
                        rtxtExam.Visible = False
                        llExamNum.Visible = False
                    End If
                    If IsDBNull(reader("RegStatus")) Then
                        pbregi.Visible = True
                        lbregi.Visible = True
                        Timer1.Interval = 300
                        Timer1.Enabled = True
                        ival = 0
                        Timer1.Start()
                        lbregi.Visible = True
                    ElseIf (reader("RegStatus")) = 0 Then
                        pbregi.Visible = True
                        lbregi.Visible = True
                        Timer1.Interval = 300
                        Timer1.Enabled = True
                        ival = 0
                        Timer1.Start()
                        lbregi.Visible = True
                    Else
                        lbregi.Visible = False
                        pbregi.Visible = False
                    End If

                Else
                    lb_loggedas.Text = Login.txtUname.Text
                    LinkSProf.Hide()
                End If
            End While
            If chngpwd = "Change" Then
                Login.Visible = False
                Me.Visible = True
                MessageBox.Show("you must  Change your password!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ChangePwdToolStripMenuItem.PerformClick()
            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()
    End Sub

    Private Sub Timer1_Tick(Sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If lbregi.Visible = True Then
            lbregi.Visible = False
        Else
            lbregi.Visible = True
        End If
        ival = ival + 1
        If ival = 300000 Then
            If lbregi.Visible = False Then
                lbregi.Visible = True
            End If
            Timer1.Stop()
        End If
    End Sub


    Private Sub getstudentinfo()
        Try
            conn.Open()
            Dim command As New SqlCommand("SELECT * FROM dbo.Student WHERE  Student_Id like '" & selector & "%'", conn)
            Dim dr As SqlDataReader = command.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                txtSPSID.Text = dr.Item("Student_Id").ToString
                txtSPFname.Text = dr.Item("Fname").ToString
                txtSPSurname.Text = dr.Item("Surname").ToString
                txtSPPOS.Text = dr.Item("ProgramOfStudy").ToString
                txtSPOnames.Text = dr.Item("OtherName").ToString
                If IsDBNull(dr.Item("DOB")) Then
                    dtpSPDOB.Value = Today.Date
                Else
                    Dim dt As String = Convert.ToDateTime(dr.Item("DOB"))
                    dtpSPDOB.Value = dt
                End If
                cmbGender.Text = dr.Item("Gender").ToString
                txtSPVillage.Text = dr.Item("HomeVillage").ToString
                txtSPTA.Text = dr.Item("TradAuth").ToString
                txtSPDistrict.Text = dr.Item("District").ToString
                txtSPNationality.Text = dr.Item("Nationality").ToString
                txtSPPOBox.Text = dr.Item("PostalAddress").ToString
                txtSPCResidence.Text = dr.Item("CurResi").ToString
                txtSPEmail.Text = dr.Item("EmailAddress").ToString
                txtSPMobile.Text = dr.Item("MobileNo").ToString
                txtTOA.Text = dr.Item("TOA").ToString
                txtAccomodation.Text = dr.Item("Accommodation").ToString
            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            conn.Close()
        End Try
        conn.Close()

        Try
            conn.Open()
            Dim command As New SqlCommand("SELECT * FROM [dbo].[NOK] WHERE  [student_Id] like '" & selector & "%'", conn)
            Dim dr As SqlDataReader = command.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                txtNOKFname.Text = dr.Item("FirstName").ToString
                txtNOKSurname.Text = dr.Item("Surname").ToString
                txtNOKtittle.Text = dr.Item("Title").ToString
                txtNOKMobile.Text = dr.Item("Mobile_Number").ToString
                txtNOKCResidence.Text = dr.Item("NOKResi").ToString
                txtNOKPOBox.Text = dr.Item("Postal").ToString
                txtNOKEmail.Text = dr.Item("Email").ToString
                txtNOKRelationship.Text = dr.Item("Relationship").ToString
                If Not lbusertype.Text = "Student" Then
                    btnSPsave.Show()
                    btnUpdate.Hide()
                Else
                    btnSPsave.Show()
                    btnUpdate.Show()
                End If

            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            conn.Close()
        End Try
        conn.Close()
    End Sub

    Private Sub lbTuition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbTuition.LinkClicked
        Tuition_Management.ShowDialog()
    End Sub

    Private Sub pbSettingsTuit_Click(sender As Object, e As EventArgs) Handles pbSettingsTuit.Click
        Tuition_Management.ShowDialog()
    End Sub

    Private Sub btnSPsave_Click(sender As Object, e As EventArgs) Handles btnSPsave.Click
        If txtSPFname.Text = Nothing Then
            MsgBox("First Name Required!", MsgBoxStyle.Critical)
            txtSPFname.Focus()

        ElseIf txtSPSurname.Text = Nothing Then
            MsgBox("Surname Required", MsgBoxStyle.Critical)
            txtSPSurname.Focus()

        ElseIf txtSPOnames.Text = Nothing Then
            txtSPOnames.Text = "N/A"

        ElseIf dtpSPDOB.Value = Nothing Then
            MsgBox("Date Of Birth Required", MsgBoxStyle.Critical)
            dtpSPDOB.Focus()

        ElseIf txtSPMobile.Text = Nothing Then
            MsgBox("Mobile Number Required!", MsgBoxStyle.Critical)
            txtSPMobile.Focus()

        ElseIf txtSPEmail.Text = Nothing Then
            txtSPEmail.Text = "N/A"


        ElseIf txtSPVillage.Text = Nothing Then
            MsgBox("Home Village Reuired!", MsgBoxStyle.Critical)
            txtSPVillage.Focus()

        ElseIf txtSPTA.Text = Nothing Then
            txtSPTA.Text = "N/A"

        ElseIf txtSPDistrict.Text = Nothing Then
            MsgBox("District Requred!", MsgBoxStyle.Critical)
            txtSPDistrict.Focus()

        ElseIf txtSPNationality.Text = Nothing Then
            MsgBox("Nationality Required!", MsgBoxStyle.Critical)
            txtSPNationality.Focus()

        ElseIf txtSPPOBox.Text = Nothing Then
            MsgBox("Postal Address Required!", MsgBoxStyle.Critical)
            txtSPPOBox.Focus()

        ElseIf txtSPCResidence.Text = Nothing Then
            MsgBox("Current Residence Requiured!", MsgBoxStyle.Critical)
            txtSPCResidence.Focus()

        ElseIf txtSPSID.Text = Nothing Then
            MsgBox("Student Id Required!", MsgBoxStyle.Critical)
            txtSPSID.Focus()

        ElseIf txtSPPOS.Text = Nothing Then
            MsgBox("Program of Study Required!", MsgBoxStyle.Critical)
            txtSPPOS.Focus()

        ElseIf dtpYOA.Value = Nothing Then
            MsgBox("Year of Admission Required!", MsgBoxStyle.Critical)
            dtpYOA.Focus()

        ElseIf txtNOKFname.Text = Nothing Then
            MsgBox("Next of Keen's FirstName Required!", MsgBoxStyle.Critical)
            txtNOKFname.Focus()

        ElseIf txtNOKSurname.Text = Nothing Then
            MsgBox("Next of Keen's Surname Required!", MsgBoxStyle.Critical)
            txtNOKSurname.Focus()


        ElseIf txtNOKtittle.Text = Nothing Then
            MsgBox("Next of Keen Tittle Required!", MsgBoxStyle.Critical)
            txtNOKtittle.Focus()

        ElseIf txtNOKMobile.Text = Nothing Then
            MsgBox("Next of Keen Mobile Number Required!", MsgBoxStyle.Critical)
            txtNOKMobile.Focus()

        ElseIf txtNOKCResidence.Text = Nothing Then
            MsgBox("Next of Keen's Current Place of Residence Required!", MsgBoxStyle.Critical)
            txtNOKCResidence.Focus()

        ElseIf txtNOKPOBox.Text = Nothing Then
            MsgBox("Next of Keen's Postal Address Required!", MsgBoxStyle.Critical)
            txtNOKPOBox.Focus()

        ElseIf txtNOKRelationship.Text = Nothing Then
            MsgBox("Enter Relationship!", MsgBoxStyle.Critical)
            txtNOKRelationship.Focus()

        ElseIf txtNOKEmail.Text = Nothing Then
            MsgBox("Enter Next of Keen's Email!", MsgBoxStyle.Critical)
            txtNOKEmail.Focus()

        Else

            Try
                conn.Open()
                Dim cmd As New SqlCommand("UPDATE dbo.Student SET OtherName = '" & txtSPOnames.Text & "', DOB = '" & dtpSPDOB.Value & "', Gender = '" & cmbGender.Text & "', HomeVillage = '" & txtSPVillage.Text & "', TradAuth = '" & txtSPTA.Text & "', District = '" & txtSPDistrict.Text & "', Nationality = '" & txtSPNationality.Text & "', PostalAddress = '" & txtSPPOBox.Text & "', EmailAddress = '" & txtSPEmail.Text & "', MobileNo = '" & txtSPMobile.Text & "', CurResi = '" & txtSPCResidence.Text & "', YOA = '" & dtpYOA.Text & "', TOA = '" & txtTOA.Text & "', Accommodation = '" & txtAccomodation.Text & "' WHERE Student_Id = '" & txtSPSID.Text & "'", conn)
                cmd.CommandType = CommandType.Text

                Dim cmd1 As New SqlCommand("INSERT INTO [dbo].[NOK] ([Student_Id], [FirstName], [Surname], [Title], [NOKResi], [Mobile_Number], [Email], [Postal], [Relationship]) VALUES ('" & cmbxstudentselect.SelectedValue & "','" & txtNOKFname.Text & "','" & txtNOKSurname.Text & "','" & txtNOKtittle.Text & "','" & txtNOKCResidence.Text & "','" & txtNOKMobile.Text & "','" & txtNOKEmail.Text & "','" & txtNOKPOBox.Text & "','" & txtNOKRelationship.Text & "')", conn)
                cmd1.CommandType = CommandType.Text


                If (cmd.ExecuteNonQuery().Equals(1)) And (cmd1.ExecuteNonQuery().Equals(1)) Then
                    MsgBox("SAVE SUCCESSIFUL!", MessageBoxIcon.Information)
                    conn.Close()
                Else
                    MsgBox("SAVE FAILED!", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                    conn.Close()
                End If
            Catch ex As Exception
                MsgBox("Error in Saving. Error is :" & ex.Message, MessageBoxIcon.Warning)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub btnFinControl_Click_1(sender As Object, e As EventArgs) Handles btnFinControl.Click
        LoadAccNo()
        LinkHome.LinkVisited = False
        LinkFin.LinkVisited = False
        LinkLib.LinkVisited = False
        LinkSProf.LinkVisited = False
        LinkTool.LinkVisited = False


        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabCourses)
        tbcDashboad.TabPages.Add(TabCafe)
        tbcDashboad.Visible = True
    End Sub

    Private Sub loadAccNoAccBal()
        conn.Open()
        Dim command As New SqlCommand("SELECT AccNo ,AccBal FROM dbo.Accounts WHERE Student_Id = '" & lbkeepSID.Text & "'", conn)
        Try
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read
                lbAccNo.Text = reader("AccNo")
                lbAccBal.Text = reader("AccBal")
            End While
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()
    End Sub
    Public Sub loadgdvAccState()

        Try
            conn.Open()
            Dim strSQL As String = "SELECT TransactionDate AS [Transaction Date], Transaction_id  AS [Reference], TransactionDescrp AS [Description], TransactionType AS [Transaction Type], TransactionAmount AS [Transaction Amount], TransactionBal AS [Balance] FROM dbo.Transactions WHERE AccNo = '" & acc & "' ORDER BY [TransactionDate] ASC"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "AccState")
            gdvAccState.DataSource = ds.Tables("AccState")
            gdvAccState.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()
    End Sub
    Public Shared Property auditval As String = Nothing
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If Not Application.OpenForms.OfType(Of ChangePwd).Any Then
            auditval = "" & Login.txtUname.Text & ", " & Login.txtPword.Text & ""
        End If
        ' Audit Trail
        Try
            ipadd()

            Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
            Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
            cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
            cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
            cmd.Parameters.AddWithValue("@Utyp", lbusertype.Text)
            cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
            cmd.Parameters.AddWithValue("@TransTyp", btnLogout.Text)
            cmd.Parameters.AddWithValue("@TransVal", auditval)
            conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery().Equals(1)
            conn.Close()

        Catch ex As Exception
            MsgBox("An error has occured ", ex.Message)
        End Try
        Login.Show()
        Login.txtUname.Clear()
        Login.txtPword.Clear()
        Login.txtUname.Focus()
        Me.Close()
        'If Application.OpenForms().OfType(Of ChangePwd).Any Then
        '    ChangePwd.Visible = False
        'End If
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        Lock.ShowDialog()
    End Sub

    Private Sub lbClass_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbClass.LinkClicked
        Lecturers.ShowDialog()
    End Sub

    Private Sub lbregi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbregi.LinkClicked
        Call register()
    End Sub

    Private Sub pbregi_Click(sender As Object, e As EventArgs) Handles pbregi.Click
        Call register()
    End Sub
    Private Sub register()
        Dim accbal As Double
        Dim outputarr As New List(Of Double)
        Dim creditsum As Double

        Dim comd As New SqlCommand("SELECT [dbo].[Transactions].[TransactionAmount] AS [TransAmount] FROM [dbo].[Transactions] where [AccNo] =(select AccNo from dbo.Accounts where Student_Id = '" & lbkeepSID.Text & "') and TransactionType = 'Credit'", conn)
        Try
            conn.Open()
            Dim dr = comd.ExecuteReader()
            While dr.Read()
                If IsDBNull(dr("TransAmount")) Then
                    creditsum = 0
                Else
                    outputarr.Add(Convert.ToDouble(dr("TransAmount")))
                    creditsum = outputarr.Cast(Of Double).Sum()
                End If
            End While
        Catch e As SqlException
            MessageBox.Show("There was an error accessing your data. DETAIL: " & e.ToString())
        Finally
            conn.Close()
        End Try

        Dim command As New SqlCommand("SELECT AccNo ,AccBal FROM dbo.Accounts WHERE Student_Id = '" & lbkeepSID.Text & "'", conn)
        Try
            conn.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read
                If IsDBNull(reader("AccBal")) Then
                    accbal = 0
                Else
                    Dim var As String = reader("AccBal").ToString
                    accbal = Convert.ToDouble(var)

                End If
            End While
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            conn.Close()
        End Try

        If creditsum < (1 / 4 * accbal) Then
            MessageBox.Show("Your Tuition Fee Balance is Less Than Minimum!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf creditsum = 0 Then
            MessageBox.Show("Your Tuition Fee Balance is Less Than Minimum!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Else
            Try
                conn.Open()
                Dim cmd As New SqlCommand("Update[dbo].[Student] SET [RegStatus] = '1' WHERE [Student_Id] = '" & lbkeepSID.Text & "'", conn)
                cmd.CommandType = CommandType.Text

                If (cmd.ExecuteNonQuery().Equals(1)) Then
                    MsgBox("Registration successiful", MessageBoxIcon.Information)
                    Timer1.Stop()
                    Me.lbregi.Hide()
                    Me.pbregi.Hide()
                End If
            Catch ex As Exception
                MsgBox("Error in population the Database. Error is :" & ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub pbclass_Click(sender As Object, e As EventArgs) Handles pbclass.Click
        Lecturers.ShowDialog()
    End Sub


    Private Sub btnTrasactionLeger_Click_1(sender As Object, e As EventArgs) Handles btnTrasactionLeger.Click
        Call loadtransLedger()
        gpbtransactionLedger.Visible = True
        btnAccState.Visible = False
        btnFinControl.Visible = False
        btnTrasactionLeger.Visible = False
    End Sub
    Private Sub loadtransLedger()
        Try
            conn.Open()
            Dim strSQL As String = " SELECT [TransactionDate] AS [Date],Transaction_id  AS [Reference], [AccNo] AS [Acc Number] ,(SELECT [Fname] +' '+ [Surname] FROM [dbo].[Student] WHERE [Student_Id] IN (SELECT [dbo].[Accounts].[Student_Id] FROM [dbo].[Accounts] WHERE [dbo].[accounts].[AccNo] = [dbo].[Transactions].[AccNo])) AS [Student],[TransactionType] AS [Type],[TransactionDescrp] AS [Description],[TransactionAmount] AS [Amount],[TransactionBal] AS [Balance] FROM [dbo].[Transactions] ORDER BY TransactionDate ASC"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "ledger")
            dgvLedger.DataSource = ds.Tables("ledger")
            dgvLedger.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()
    End Sub

    Private Sub txtsearchledger_TextChanged(sender As Object, e As EventArgs) Handles txtsearchledger.TextChanged
        Try
            conn.Open()
            Dim strSQL As String = " SELECT Transaction_id  AS [Reference], [AccNo] AS [Acc Number] ,(SELECT [Fname] +' '+ [Surname] FROM [dbo].[Student] WHERE [Student_Id] IN (SELECT [dbo].[Accounts].[Student_Id] FROM [dbo].[Accounts] WHERE [dbo].[accounts].[AccNo] = [dbo].[Transactions].[AccNo])) AS [Student],[TransactionDate] AS [Date],[TransactionType] AS [Type],[TransactionDescrp] AS [Description],[TransactionAmount] AS [Amount],[TransactionBal] AS [Balance] FROM [dbo].[Transactions] WHERE [dbo].[Transactions].[AccNo] LIKE '" & txtsearchledger.Text & "%'  ORDER BY TransactionDate ASC"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "ledger")
            dgvLedger.DataSource = ds.Tables("ledger")
            dgvLedger.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()
    End Sub

    Private Sub LoadAccNo()
        conn.Open()
        Dim da1 As New SqlDataAdapter("SELECT AccNo FROM dbo.Accounts ORDER BY AccNo ASC", conn)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "ACC")
        cmbxAccNo.DataSource = ds1.Tables(0)
        cmbxAccNo.DisplayMember = "AccNo"
        cmbxAccNo.ValueMember = "AccNo"
        conn.Close()
    End Sub

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If txtTransAmount.Text = Nothing Then
            MsgBox("Please Enter the Amount to be Posted!", MsgBoxStyle.Critical)
            txtTransAmount.Focus()

        ElseIf txtTransDescrp.Text = Nothing Then
            MsgBox("Please Enter a Description for the Transaction to be Posted!", MsgBoxStyle.Critical)
            txtTransDescrp.Focus()

        ElseIf cmbxTranstype.Text = Nothing Then
            MsgBox("Please select the Transaction Type", MsgBoxStyle.Critical)
            cmbxTranstype.Focus()

        Else
            If cmbxTranstype.Text = "Debit" Then 'increase Account Balacce by the transaction amount

                Try
                    conn.Open()
                    Dim command As New SqlCommand("SELECT * FROM dbo.Accounts WHERE AccNo = '" & cmbxAccNo.SelectedValue & "'", conn)
                    Dim dr As SqlDataReader = command.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        Bal = Convert.ToDouble(dr.Item("AccBal"))
                        NewBal = (Bal + Convert.ToDouble(txtTransAmount.Text)).ToString
                        NewBal = Format(CInt(NewBal), "#,#")
                        'TextBox1.SelectionStart = TextBox1.Text.Length
                        conn.Close()
                        Call PostNewBal()
                        Call PostTransaction()
                    End If
                Catch ex As SqlException
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    conn.Close()
                End Try
            ElseIf cmbxTranstype.Text = "Credit" Then 'reduce Account Balance by the transaction amount

                Try
                    conn.Open()
                    Dim command As New SqlCommand("SELECT * FROM dbo.Accounts WHERE AccNo = '" & cmbxAccNo.SelectedValue & "'", conn)
                    Dim dr As SqlDataReader = command.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        Bal = Convert.ToDouble(dr.Item("AccBal"))
                        NewBal = (Bal - Convert.ToDouble(txtTransAmount.Text)).ToString
                        NewBal = Format(CInt(NewBal), "#,#")
                        conn.Close()
                        Call PostNewBal()
                        Call PostTransaction()
                    End If
                Catch ex As SqlException
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    conn.Close()
                End Try
            End If
        End If

    End Sub
    Private Sub PostTransaction()
        Dim Transaction_id As String = String.Empty
        Dim number As String = Nothing
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM dbo.Transactions ORDER BY Transaction_id ASC", conn)
            Dim adp As New SqlDataAdapter(cmd)
            cmd.connection.Open()
            Dim ds As New Data.DataSet
            Dim dt As New Data.DataTable
            adp.Fill(ds)
            dt = ds.Tables(0)
            Dim count As Integer = dt.Rows.Count
            number = (count + 1).ToString()
            cmd.connection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Dim year As Date = Today.Date
        Dim yr As String = year.ToString("yyyyMMdd")
        Transaction_id = (yr + number).ToString

        Try
            conn.Open()
            Dim command As New SqlCommand("INSERT INTO dbo.Transactions (Transaction_id, AccNo, TransactionDate, TransactionType, TransactionDescrp, TransactionAmount,TransactionBal) VALUES ('" & Transaction_id & "','" & cmbxAccNo.SelectedValue & "','" & dtpTransactdate.Value.ToString & "','" & cmbxTranstype.Text & "','" & txtTransDescrp.Text & "','" & txtTransAmount.Text & "','" & NewBal & "')", conn)
            command.ExecuteNonQuery()
            conn.Close()
            MsgBox("Trasaction Successful!", MsgBoxStyle.Information)
            ' Audit Trail
            Try
                ipadd()
                Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
                cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                cmd.Parameters.AddWithValue("@TransTyp", "Post Transaction")
                cmd.Parameters.AddWithValue("@TransVal", Transaction_id + ", " + cmbxAccNo.SelectedValue + ", " + dtpTransactdate.Value.ToString + ", " + cmbxTranstype.Text + ", " + txtTransDescrp.Text + ", " + txtTransAmount.Text + ", " + NewBal)
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

            txtTransAmount.Clear()
            txtTransDescrp.Clear()
            Call LoadAccNo()
        Catch ex As Exception
            MsgBox("Error in population the Database. Error is :" & ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub PostNewBal()
        Try
            conn.Open()
            Dim command As New SqlCommand("UPDATE dbo.Accounts SET AccBal = '" & NewBal & "' WHERE AccNo = '" & cmbxAccNo.SelectedValue & "'", conn)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error in population the Database. Error is :" & ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub llCourses_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llCourses.LinkClicked
        Call courses()
    End Sub

    Private Sub pbCourses_Click(sender As Object, e As EventArgs) Handles pbCourses.Click
        Call courses()
    End Sub
    Private Sub courses()
        LinkHome.LinkVisited = False
        LinkFin.LinkVisited = False
        LinkLib.LinkVisited = False
        LinkSProf.LinkVisited = False
        LinkTool.LinkVisited = True
        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabCourses)
        tbcDashboad.TabPages.Add(TabCourses)
        tbcDashboad.Visible = True
        Call loadcourses()
        If Me.lbusertype.Text = "Admin" OrElse Me.lbusertype.Text = "Custom" Then
            gpbManageCourses.Show()
            dgv = dgvManageCourses
            Call loadcourses()
            txtCourseIDMajor.Clear()
            btnSaveCourse.Hide()
            btnEdit.Show()
            btnDelMajor.Hide()
            gpbMagageCourseControls.Show()
            btnAddMajor.Show()
            btnSaveMajor.Hide()
            loadcmbxProgMajor()
            dgvManageCourses.BringToFront()
            btnBackcourses.Hide()
            btnViewMajors.Show()
            btnEditMajor.Hide()
            lbTittle.Text = "Available Courses"

        ElseIf Me.lbusertype.Text = "Student" Then
            LbCoursesStudent.Text = lb_loggedas.Text + " " + "(" + lbkeepSID.Text + ")"
            Dim yrnow As Integer = Date.Now.Year
            Dim yos As String = Nothing
            Dim sqlstr As String = "SELECT [YOA] FROM [dbo].[Student] WHERE Student_id = '" & lbkeepSID.Text & "' "
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, conn)
            conn.Open()
            Dim reader1 As SqlDataReader = cmd.ExecuteReader()
            While reader1.Read
                Dim yr As Integer = Convert.ToInt64(reader1("YOA"))

                yos = ((yrnow - yr) + 1).ToString

                lbmyClass.Text = lbkeepSID.Text.Substring(0, 3).ToString + yos
            End While
            conn.Close()

            cmbxSemCourses.Items.Clear()
            cmbxSemCourses.Items.Add("Semester 1")
            cmbxSemCourses.Items.Add("Semester 2")
            gpbSelectCourses.Show()
            gpbManageCourses.Hide()
            dgv = dgvCorses
            Call loadcourses()
            Call loadstudentMajor()
            Dim theQuery As String = "SELECT * FROM [dbo].[Course_Student] WHERE Student_id = '" & lbkeepSID.Text & "' "
            Dim cmd1 As SqlCommand = New SqlCommand(theQuery, conn)
            conn.Open()
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If reader.HasRows Then
                    conn.Close()
                    Call loadselectedcorses()
                End If
            End Using
            conn.Close()
        End If
    End Sub

    Public Sub loadcmbxProgMajor()
        conn.Open()
        Dim da3 As New SqlDataAdapter("SELECT Prog_id, ProgName FROM dbo.Programme", conn)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "prog")
        Me.cmbxProgMajor.DataSource = ds3.Tables(0)
        Me.cmbxProgMajor.ValueMember = "Prog_id"
        Me.cmbxProgMajor.DisplayMember = "ProgName"
        conn.Close()

    End Sub



    Dim dgv As DataGridView = New DataGridView
    Private Sub loadcourses()
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Course_id] AS [Course Code], [CourseName] AS [Course Name], [CreditHours] AS [Credit Hours], [AssesmentType] AS [Assesment Type], [GradingSys] AS [Grading System] FROM [dbo].[Course] ORDER BY [CourseName] ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Courses")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnRegiCourse_Click(sender As Object, e As EventArgs) Handles btnRegiCourse.Click
        If txtCourseID.Text = Nothing Then
            MsgBox("Please enter the Course code", MessageBoxIcon.Warning)
            txtCourseID.Focus()
        ElseIf txtCourseName.Text = Nothing Then
            MsgBox("Please Enter the Course Name", MessageBoxIcon.Warning)
            txtCourseName.Focus()
        ElseIf txtCreditHours.Text = Nothing Then
            MsgBox("Credit hours Required", MessageBoxIcon.Warning)
            txtCreditHours.Focus()
        ElseIf txtAssessmenttyp.Text = Nothing Then
            MsgBox("Please Enter the Assessment Type", MessageBoxIcon.Warning)
            txtAssessmenttyp.Focus()
        ElseIf txtGradingSys.Text = Nothing Then
            MsgBox("Please Enter the Grading System", MessageBoxIcon.Warning)
            txtGradingSys.Focus()
        Else
            Call regCourse()
            dgv = dgvManageCourses
            Call loadcourses()
        End If

    End Sub


    Public Sub regCourse()
        Try
            conn.Open()
            Dim command As New SqlCommand("INSERT INTO [dbo].[Course] ([Course_id], [CourseName], [CreditHours], [AssesmentType], [GradingSys]) VALUES ('" & txtCourseID.Text & "','" & txtCourseName.Text & "','" & txtCreditHours.Text & "','" & txtAssessmenttyp.Text & "','" & txtGradingSys.Text & "')", conn)
            command.ExecuteNonQuery()

            MsgBox("Course Added successfully", MessageBoxIcon.Information)
            conn.Close()
            ' Audit Trail
            Try
                ipadd()
                Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
                cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                cmd.Parameters.AddWithValue("@TransTyp", "Add Course")
                cmd.Parameters.AddWithValue("@TransVal", txtCourseID.Text + ", " + txtCourseName.Text + ", " + txtCreditHours.Text + ", " + txtAssessmenttyp.Text + ", " & txtGradingSys.Text)
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

            txtCourseID.Clear()
            txtCourseName.Clear()
            txtCreditHours.Clear()
            txtAssessmenttyp.Clear()
            txtGradingSys.Clear()

        Catch ex As Exception
            MsgBox("Error in population the Database. Error is :" & ex.Message, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvManageCourses.RowCount <= 0 Then
            MsgBox("There are No Courses in the System. Please Add First!", MsgBoxStyle.Critical)
            txtCourseID.Focus()

        ElseIf Not dgvManageCourses.CurrentRow.Selected Then
            MsgBox("Please Select A Course First!", MsgBoxStyle.Critical)

        Else
            Dim selectedrowscount As Integer = Me.dgvManageCourses.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedrowscount > 1 Then
                MsgBox("Please Select ONE Course to Edit!", MsgBoxStyle.Critical)
            Else
                txtCourseID.Text = Me.dgvManageCourses.SelectedRows(0).Cells(0).Value.ToString
                txtCourseName.Text = Me.dgvManageCourses.SelectedRows(0).Cells(1).Value.ToString
                txtCreditHours.Text = Me.dgvManageCourses.SelectedRows(0).Cells(2).Value.ToString
                txtAssessmenttyp.Text = Me.dgvManageCourses.SelectedRows(0).Cells(3).Value.ToString
                txtGradingSys.Text = Me.dgvManageCourses.SelectedRows(0).Cells(4).Value.ToString
                btnRegiCourse.Hide()
                btnEdit.Hide()
                btnSaveCourse.Show()
                txtCourseID.ForeColor = Color.Red
                txtCourseName.ForeColor = Color.Red
                txtCreditHours.ForeColor = Color.Red
                txtAssessmenttyp.ForeColor = Color.Red
                txtGradingSys.ForeColor = Color.Red
                txtCourseID.Focus()
            End If
        End If
    End Sub
    Private Sub btnDelCourse_Click(sender As Object, e As EventArgs) Handles btnDelCourse.Click
        If dgvManageCourses.RowCount <= 0 Then
            MsgBox("There are No Courses in the System. Please Add First!", MsgBoxStyle.Critical)
            txtCourseID.Focus()

        ElseIf Not dgvManageCourses.CurrentRow.Selected Then
            MsgBox("Please Select A Course First!", MsgBoxStyle.Critical)

        Else

            Dim CID As String = Me.dgvManageCourses.SelectedRows(0).Cells(0).Value.ToString
            Dim CName As String = Me.dgvManageCourses.SelectedRows(0).Cells(1).Value.ToString
            Dim CrHrs As String = Me.dgvManageCourses.SelectedRows(0).Cells(2).Value.ToString
            MsgResult = MessageBox.Show("The Course " + Me.dgvManageCourses.SelectedRows(0).Cells(0).Value.ToString + " Will be removed from the System !Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If MsgResult = Windows.Forms.DialogResult.Yes Then
                Try
                    conn.Open()
                    Dim command As New SqlCommand("DELETE FROM [dbo].[Course] WHERE [Course_id] = '" & CID & "'", conn)
                    command.ExecuteNonQuery()

                    MsgBox("Course Edited successfully", MessageBoxIcon.Information)
                    conn.Close()
                    ' Audit Trail
                    Try
                        ipadd()
                        Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                        Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
                        cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                        cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                        cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                        cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                        cmd.Parameters.AddWithValue("@TransTyp", "Delete Course")
                        cmd.Parameters.AddWithValue("@TransVal", CID + ", " + CName + ", " + CrHrs)
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
                    txtCourseID.Clear()
                    txtCourseName.Clear()
                    txtCreditHours.Clear()
                    txtAssessmenttyp.Clear()
                    txtGradingSys.Clear()
                    btnRegiCourse.Show()
                    btnSaveCourse.Hide()
                    btnEdit.Show()
                    txtCourseID.Focus()
                    dgv = dgvManageCourses
                    Call loadcourses()
                Catch ex As Exception
                    MsgBox("Error in the Database Transaction. Error is :" & ex.Message, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If
        End If
    End Sub
    Private Sub btnSaveCourse_Click(sender As Object, e As EventArgs) Handles btnSaveCourse.Click
        If txtCourseID.Text = Nothing Then
            MsgBox("Please enter the Course code", MessageBoxIcon.Warning)
            txtCourseID.Focus()
        ElseIf txtCourseName.Text = Nothing Then
            MsgBox("Please Enter the Course Name", MessageBoxIcon.Warning)
            txtCourseName.Focus()
        ElseIf txtCreditHours.Text = Nothing Then
            MsgBox("Credit hours Required", MessageBoxIcon.Warning)
            txtCreditHours.Focus()
        ElseIf txtAssessmenttyp.Text = Nothing Then
            MsgBox("Please Enter the Assessment Type", MessageBoxIcon.Warning)
            txtAssessmenttyp.Focus()
        ElseIf txtGradingSys.Text = Nothing Then
            MsgBox("Please Enter the Grading System", MessageBoxIcon.Warning)
            txtGradingSys.Focus()
        Else
            Try
                conn.Open()
                Dim command As New SqlCommand("UPDATE [dbo].[Course] SET [Course_id] = '" & txtCourseID.Text & "',[CourseName] = '" & txtCourseName.Text & "',[CreditHours] = '" & txtCreditHours.Text & "',[AssesmentType] = '" & txtAssessmenttyp.Text & "',[GradingSys] = '" & txtGradingSys.Text & "' WHERE [Course_id] = '" & Me.dgvManageCourses.SelectedRows(0).Cells(0).Value.ToString & "'", conn)
                command.ExecuteNonQuery()

                MsgBox("Course Edited successfully", MessageBoxIcon.Information)
                conn.Close()
                ' Audit Trail
                Try
                    ipadd()
                    Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                    Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
                    cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                    cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                    cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                    cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                    cmd.Parameters.AddWithValue("@TransTyp", "Add Course")
                    cmd.Parameters.AddWithValue("@TransVal", txtCourseID.Text + ", " + txtCourseName.Text + ", " + txtCreditHours.Text + ", " + txtAssessmenttyp.Text + ", " & txtGradingSys.Text)
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
                txtCourseID.Clear()
                txtCourseName.Clear()
                txtCreditHours.Clear()
                txtAssessmenttyp.Clear()
                txtGradingSys.Clear()
                btnRegiCourse.Show()
                btnSaveCourse.Hide()
                btnEdit.Show()
                txtCourseID.ForeColor = Color.Black
                txtCourseName.ForeColor = Color.Black
                txtCreditHours.ForeColor = Color.Black
                txtAssessmenttyp.ForeColor = Color.Black
                txtGradingSys.ForeColor = Color.Black
                txtCourseID.Focus()
                dgv = dgvManageCourses
                Call loadcourses()
            Catch ex As Exception
                MsgBox("Error in population the Database. Error is :" & ex.Message, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim yrnow As Integer = Date.Now.Year
        Dim yos As String = Nothing
        Dim sqlstring As String = "SELECT [YOA] FROM [dbo].[Student] WHERE Student_id = '" & lbkeepSID.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlstring, conn)
        conn.Open()
        Dim reader1 As SqlDataReader = cmd.ExecuteReader()
        While reader1.Read
            Dim yr As String = reader1("YOA")

            yos = ((yrnow - yr) + 1).ToString
        End While
        conn.Close()
        If cmbxSemCourses.SelectedItem = Nothing Then
            MsgBox("Please select a Semester", MessageBoxIcon.Warning)

        ElseIf dgvCorses.RowCount = 0 Or Nothing Then
            MsgBox("There are no courses for selecting", MessageBoxIcon.Warning)

        ElseIf Not dgvCorses.CurrentRow.Selected Then
            MsgBox("Please Select A Course First!", MessageBoxIcon.Warning)
        Else
            dgvSelectedCourses.Show()
            dgvSelectedCourses.ClearSelection()
            dgvdefaltmajors.Hide()
            Dim theQuery As String = "SELECT * FROM [dbo].[Course_Student] WHERE  [Course_id]= @CourseID and [Student_Id] = @SID "
            Dim cmd1 As SqlCommand = New SqlCommand(theQuery, conn)
            cmd1.Parameters.AddWithValue("@CourseID", Me.dgvCorses.SelectedRows(0).Cells(0).Value.ToString)
            cmd1.Parameters.AddWithValue("@SID", Me.lbkeepSID.Text)
            conn.Open()
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If reader.HasRows Then
                    ' Course already exists, close connection
                    conn.Close()
                Else

                    Dim sqlstr As String = "INSERT INTO [dbo].[Course_Student]([Course_id], [Student_Id], [Semester], [YrOStudy]) VALUES (@CourseID, @SID, @Sem, @yr)"
                    Dim sqlstr1 As String = "UPDATE [dbo].[Course_Student] SET [Semester] = '" & cmbxSemCourses.SelectedItem & "',[YrOStudy] = '" & yos & "'WHERE [Semester] IS NULL and [YrOStudy] IS NULL"
                    Dim command As New SqlCommand(sqlstr, conn)
                    Dim command1 As New SqlCommand(sqlstr1, conn)
                    command1.CommandType = CommandType.Text
                    command.CommandType = CommandType.Text
                    command.Parameters.AddWithValue("@CourseID", Me.dgvCorses.SelectedRows(0).Cells(0).Value.ToString)
                    command.Parameters.AddWithValue("@SID", Me.lbkeepSID.Text)
                    command.Parameters.AddWithValue("@Sem", Me.cmbxSemCourses.SelectedItem)
                    command.Parameters.AddWithValue("@yr", yos)

                    Try
                        conn.Close()
                        conn.Open()
                        command.ExecuteNonQuery()
                        command1.ExecuteNonQuery()
                        conn.Close()
                        Call loadselectedcorses()
                    Catch ex As Exception
                        MsgBox("Error in population the Database. Error is :" & ex.Message, MessageBoxIcon.Error)
                        conn.Close()
                    End Try
                End If
            End Using
        End If
    End Sub
    Private Sub loadstudentMajor()
        dgv = dgvdefaltmajors

        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Course_id] AS [Course Code],(select [CourseName] from dbo.Course where Course_id = dbo.Major.Course_id) AS [Course Name],(SELECT [CreditHours] FROM [dbo].[Course] where [dbo].[Course].[Course_id] =[dbo].[Major].[Course_id]) AS [Credit Hours],(SELECT [AssesmentType] FROM [dbo].[Course] where [dbo].[Course].[Course_id] =[dbo].[Major].[Course_id]) AS [Assessment Type],(SELECT [GradingSys] FROM [dbo].[Course] where [dbo].[Course].[Course_id] =[dbo].[Major].[Course_id]) AS [Grading System] FROM [dbo].[Major] WHERE dbo.Major.Prog_id= '" & lbkeepSID.Text.Substring(0, 3).ToString & "' ORDER BY [Course_id] ASC"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Courses")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
            conn.Close()

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")

        End Try

        If dgv.RowCount <= 0 Then
            MsgBox("THE MANAGEMENT HAS NOT YET COMPLETED LOADING COURSES!", MsgBoxStyle.Critical)
        Else
            For i = 0 To dgv.Rows.Count - 1

                Dim cellVal As String = dgv(0, i).Value
                Dim theQuery As String = "SELECT * FROM [dbo].[Course_Student] WHERE  [Course_id]= @CourseID and [Student_Id] = @SID "
                Dim cmd1 As SqlCommand = New SqlCommand(theQuery, conn)
                cmd1.Parameters.AddWithValue("@CourseID", cellVal)
                cmd1.Parameters.AddWithValue("@SID", Me.lbkeepSID.Text)
                conn.Open()
                Using reader As SqlDataReader = cmd1.ExecuteReader()
                    If Not reader.HasRows Then
                        Dim sqlstr As String = "INSERT INTO [dbo].[Course_Student]([Course_id], [Student_Id]) VALUES (@CourseID, @SID)"
                        Dim command As New SqlCommand(sqlstr, conn)
                        command.CommandType = CommandType.Text
                        command.Parameters.AddWithValue("@CourseID", cellVal)
                        command.Parameters.AddWithValue("@SID", Me.lbkeepSID.Text)
                        Try
                            conn.Close()
                            conn.Open()
                            command.ExecuteNonQuery()
                            conn.Close()
                            dgvSelectedCourses.Hide()
                            dgvdefaltmajors.ClearSelection()
                            dgvdefaltmajors.Show()
                        Catch ex As Exception
                            MsgBox("Error in population the Database. Error is :" & ex.Message, MessageBoxIcon.Error)
                            conn.Close()
                        End Try
                    Else
                        dgvSelectedCourses.Show()
                        dgvSelectedCourses.ClearSelection()
                        dgvdefaltmajors.Hide()
                        conn.Close()
                        Call loadselectedcorses()
                    End If

                End Using
                conn.Close()
            Next
        End If
    End Sub
    Private Sub btnAddMajor_Click(sender As Object, e As EventArgs) Handles btnAddMajor.Click
        If dgvManageCourses.RowCount <= 0 Then
            MsgBox("There are No Courses in the System. Please Add First!", MsgBoxStyle.Critical)
            txtCourseID.Focus()

        ElseIf Not dgvManageCourses.CurrentRow.Selected Then
            MsgBox("Please Select A Course First!", MsgBoxStyle.Critical)

        Else
            Dim selectedrowscount As Integer = Me.dgvManageCourses.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedrowscount > 1 Then
                MsgBox("Please Select ONE Course to Edit!", MsgBoxStyle.Critical)
            Else
                gpbCourseMajor.Show()
                dgvManageCourses.Show()
                dgvViwerMajors.Hide()
                btnAddMajor.Hide()
                gpbMagageCourseControls.Hide()
                btnSaveMajor.Show()
                txtCourseIDMajor.Text = Me.dgvManageCourses.SelectedRows(0).Cells(0).Value.ToString
            End If
        End If

    End Sub

    Private Sub btnSaveMajor_Click(sender As Object, e As EventArgs) Handles btnSaveMajor.Click
        If dgvViwerMajors.Visible = True Then

            Dim sqlstr As String = "UPDATE [dbo].[Major] SET [Course_id] = @CourseID ,[Prog_id] = @ProgID, [YrOStudy] = @yr WHERE [Course_id] = '" & Me.dgvViwerMajors.SelectedRows(0).Cells(0).Value.ToString & "'"
            Dim command As New SqlCommand(sqlstr, conn)
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@CourseID", txtCourseIDMajor.Text)
            command.Parameters.AddWithValue("@ProgID", cmbxProgMajor.SelectedValue)
            command.Parameters.AddWithValue("@yr", NumericUpDown1.Value)

            Try
                conn.Open()
                command.ExecuteNonQuery()
                conn.Close()
                MsgBox("Major Edited successfully", MessageBoxIcon.Information)
                ' Audit Trail
                Try
                    ipadd()
                    Dim theQuery2 As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                    Dim cmd As SqlCommand = New SqlCommand(theQuery2, conn)
                    cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                    cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                    cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                    cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                    cmd.Parameters.AddWithValue("@TransTyp", "Edit Major")
                    cmd.Parameters.AddWithValue("@TransVal", txtCourseIDMajor.Text + ", " + cmbxProgMajor.SelectedValue + ", " + NumericUpDown1.Value.ToString)
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
                loadMajors()
                btnSaveMajor.Hide()
                btnEditMajor.Show()
                gpbMagageCourseControls.Show()

            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
            Finally
                conn.Close()
            End Try

        Else
            Dim theQuery As String = "SELECT * FROM [dbo].[Major] WHERE  [Course_id]= @CourseID and [Prog_id]= @ProgID and [YrOStudy]=@yr"
            Dim cmd1 As SqlCommand = New SqlCommand(theQuery, conn)
            cmd1.Parameters.AddWithValue("@CourseID", txtCourseIDMajor.Text)
            cmd1.Parameters.AddWithValue("@ProgID", cmbxProgMajor.SelectedValue)
            cmd1.Parameters.AddWithValue("@yr", NumericUpDown1.Value)
            conn.Open()
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If reader.HasRows Then
                    ' Course already exists
                    MsgBox("Course Already Exist As Major for this Program!", MsgBoxStyle.Exclamation, "SQL ERROR!")
                    btnAddMajor.Show()
                    gpbMagageCourseControls.Show()
                    btnSaveMajor.Hide()
                    txtCourseIDMajor.Clear()
                Else
                    conn.Close()
                    Dim sqlstr As String = "INSERT INTO [dbo].[Major] ([Course_id],[Prog_id],[YrOStudy]) VALUES (@CourseID, @ProgID, @yr)"
                    Dim command As New SqlCommand(sqlstr, conn)
                    command.CommandType = CommandType.Text
                    command.Parameters.AddWithValue("@CourseID", txtCourseIDMajor.Text)
                    command.Parameters.AddWithValue("@ProgID", cmbxProgMajor.SelectedValue)
                    command.Parameters.AddWithValue("@yr", NumericUpDown1.Value)
                    Try
                        conn.Open()
                        Dim count As Integer = command.ExecuteNonQuery()
                        If count > 0 Then
                            MsgBox("Major Added successfully", MessageBoxIcon.Information)
                            ' Audit Trail
                            Try
                                ipadd()
                                Dim theQuery2 As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                                Dim cmd As SqlCommand = New SqlCommand(theQuery2, conn)
                                cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                                cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                                cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                                cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                                cmd.Parameters.AddWithValue("@TransTyp", "Add Major")
                                cmd.Parameters.AddWithValue("@TransVal", txtCourseIDMajor.Text + ", " + cmbxProgMajor.SelectedValue + ", " + NumericUpDown1.Value.ToString
                                                            )
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

                            btnAddMajor.Show()
                            gpbMagageCourseControls.Show()
                            btnSaveMajor.Hide()
                            conn.Close()
                            btnViewMajors.PerformClick()
                        Else
                            MsgBox("FAILED!", MessageBoxIcon.Stop)
                        End If

                    Catch ex As SqlException
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    Finally
                        conn.Close()
                    End Try
                End If
            End Using
            conn.Close()
        End If
    End Sub
    Private Sub btnViewMagors_Click(sender As Object, e As EventArgs) Handles btnViewMajors.Click
        gpbMagageCourseControls.Enabled = False
        dgvManageCourses.Hide()
        dgvViwerMajors.Show()
        btnViewMajors.Hide()
        btnAddMajor.Hide()
        btnSaveMajor.Hide()
        btnEditMajor.Show()
        btnBackcourses.Show()
        loadMajors()
        btnEditMajor.Show()
        btnDelMajor.Show()
        gpbCourseMajor.Show()
        gpbCourseMajor.Enabled = True
        lbTittle.Text = "Major Courses"
    End Sub
    Private Sub loadMajors()
        dgv = dgvViwerMajors
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Course_id] AS [Course Code],(select [CourseName] from dbo.Course where Course_id = dbo.Major.Course_id) AS [Course Name] ,[Prog_id] AS [Programme Code],(select ProgName From dbo.Programme where Prog_id = dbo.Major.Prog_id)AS [Programme Name], [YrOStudy]AS [Year Of Study] FROM [dbo].[Major] ORDER BY [Course_id] ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Courses")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBackcourses.Click
        If Login.addCourseAcces = "NO" Then
            gpbMagageCourseControls.Enabled = False
        Else
            gpbMagageCourseControls.Enabled = True
        End If
        gpbMagageCourseControls.Show()
        dgvManageCourses.Show()
        dgvViwerMajors.Hide()
        btnBackcourses.Hide()
        btnViewMajors.Show()
        btnAddMajor.Show()
        btnDelMajor.Hide()
        btnEditMajor.Hide()
        gpbCourseMajor.Hide()
        txtCourseIDMajor.Clear()
        lbTittle.Text = "Available Courses"

    End Sub

    Private Sub btnEditMajor_Click(sender As Object, e As EventArgs) Handles btnEditMajor.Click
        If dgvViwerMajors.RowCount <= 0 Then
            MsgBox("There are No Major Courses in the System. Please Add First!", MsgBoxStyle.Critical)
            txtCourseID.Focus()

        ElseIf Not dgvViwerMajors.CurrentRow.Selected Then
            MsgBox("Please Select A Major Course First!", MsgBoxStyle.Critical)

        Else
            Dim selectedrowscount As Integer = Me.dgvViwerMajors.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedrowscount > 1 Then
                MsgBox("Please Select ONE Major Course to Edit!", MsgBoxStyle.Critical)
            Else
                btnEditMajor.Hide()
                gpbMagageCourseControls.Hide()
                dgvManageCourses.Visible = False
                dgvViwerMajors.Visible = True
                btnSaveMajor.Show()
                txtCourseIDMajor.Text = Me.dgvViwerMajors.SelectedRows(0).Cells(0).Value.ToString
            End If
        End If

    End Sub

    Private Sub txtTransAmount_TextChanged(sender As Object, e As EventArgs) Handles txtTransAmount.TextChanged
        Try
            txtTransAmount.Text = Format(CInt(txtTransAmount.Text), "#,#").ToString
            txtTransAmount.SelectionStart = txtTransAmount.Text.Length
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadselectedcorses()
        dgvdefaltmajors.Hide()
        dgv = dgvSelectedCourses
        Try
            conn.Open()
            Dim strSQL As String = "SELECT [Course_id] AS [Course Code],(select [CourseName] from dbo.Course where Course_id = [dbo].[Course_Student].[Course_id]) AS [Course Name],(SELECT [CreditHours] FROM [dbo].[Course] where [dbo].[Course].[Course_id] =[dbo].[Course_Student].[Course_id]) AS [Credit Hours],(SELECT [AssesmentType] FROM [dbo].[Course] where [dbo].[Course].[Course_id] =[dbo].[Course_Student].[Course_id]) AS [Assessment Type],(SELECT [GradingSys] FROM [dbo].[Course] where [dbo].[Course].[Course_id] =[dbo].[Course_Student].[Course_id]) AS [Grading System] FROM [dbo].[Course_Student] WHERE [dbo].[Course_Student].[Student_Id]= '" & lbkeepSID.Text & "' ORDER BY [Course_id] ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "Courses")
            dgv.DataSource = ds.Tables(0)
            dgv.ClearSelection()
            dgvSelectedCourses.Show()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        dgv = dgvSelectedCourses
        If dgv.RowCount <= 0 Then
            MsgBox("THERE ARE NO COURSES TO REMOVE!", MsgBoxStyle.Critical)
        ElseIf Not Me.dgv.CurrentRow.Selected Then
            MsgBox("Please Select a Course First!", MsgBoxStyle.Critical)
        Else

            Dim cellval As String = Me.dgv.SelectedRows(0).Cells(0).Value.ToString
            Dim theQuery As String = "SELECT * FROM [dbo].[Major] WHERE  [Course_id]= @CourseID and [Prog_id] = @SID "
            Dim cmd1 As SqlCommand = New SqlCommand(theQuery, conn)
            cmd1.Parameters.AddWithValue("@CourseID", cellval)
            cmd1.Parameters.AddWithValue("@SID", Me.lbkeepSID.Text.Substring(0, 3).ToString)
            conn.Open()
            Using reader As SqlDataReader = cmd1.ExecuteReader()
                If Not reader.HasRows Then
                    Dim sqlstr As String = "DELETE FROM [dbo].[Course_Student] WHERE [Course_id] = @CourseID AND [Student_Id] = @SID"
                    Dim command As New SqlCommand(sqlstr, conn)
                    command.CommandType = CommandType.Text
                    command.Parameters.AddWithValue("@CourseID", cellval)
                    command.Parameters.AddWithValue("@SID", Me.lbkeepSID.Text)
                    Try
                        conn.Close()
                        conn.Open()
                        command.ExecuteNonQuery()
                        conn.Close()
                        dgvSelectedCourses.Show()
                        dgvdefaltmajors.ClearSelection()
                        dgvdefaltmajors.Hide()
                        Call loadselectedcorses()
                    Catch ex As Exception
                        MsgBox("Error in population the Database. Error is :" & ex.Message, MessageBoxIcon.Error)
                        conn.Close()
                    End Try
                Else
                    MsgBox("YOU CAN NOT REMOVE A MAJOR!", MessageBoxIcon.Warning)
                    dgvSelectedCourses.Show()
                    dgvSelectedCourses.ClearSelection()
                    dgvdefaltmajors.Hide()
                    conn.Close()
                    Call loadselectedcorses()
                End If

            End Using
            conn.Close()
            'Next
        End If
    End Sub

    Private Sub btnViewMyMajors_Click(sender As Object, e As EventArgs) Handles btnViewMyMajors.Click
        btnbacktoselected.Show()
        btnViewMyMajors.Hide()
        dgvSelectedCourses.Hide()
        dgvdefaltmajors.ClearSelection()
        dgvdefaltmajors.Show()
        conn.Close()
    End Sub

    Private Sub btnbacktoselected_Click(sender As Object, e As EventArgs) Handles btnbacktoselected.Click
        btnbacktoselected.Hide()
        btnViewMyMajors.Show()
        dgvSelectedCourses.Hide()
        dgvdefaltmajors.ClearSelection()
        dgvdefaltmajors.Show()
        conn.Close()
        Call loadselectedcorses()
    End Sub

    Private Sub reports()
        Report.ShowDialog()
    End Sub
    Private Sub pbReport_Click(sender As Object, e As EventArgs) Handles pbReport.Click
        reports()
    End Sub

    Private Sub lbReports_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbReports.LinkClicked
        reports()
    End Sub

    Private Sub btnAccState_Click_1(sender As Object, e As EventArgs) Handles btnAccState.Click
        'Dim prompt As String = String.Empty
        'Dim title As String = String.Empty
        'Dim defaultResponse As String = String.Empty
        'prompt = " Enter a Student Account Number !"
        '' Set title.
        'title = "Getting Student Account Number"
        '' Set default value.
        'defaultResponse = "Student Acc Number Here"

        '' Display prompt, title, and default value.
        'acc = InputBox(prompt, title, defaultResponse)
        'Call loadgdvAccState()
        'connection.Close()
        'grpbxFinance.Show()
        'grpbxFinance.BringToFront()
        AccNum.ShowDialog()

        conn.Open()
        Dim command1 As New SqlCommand("SELECT [AccNo],[Student_Id],[AccBal]FROM [dbo].[Accounts] WHERE [AccNo] ='" & acc & "'", conn)
        Try
            Dim reader1 As SqlDataReader = command1.ExecuteReader()
            While reader1.Read
                lbAccNo.Text = reader1("AccNo")
                lbAccBal.Text = "MWK " + reader1("AccBal")
                lbSID.Text = reader1("Student_Id")
            End While
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            conn.Close()
        End Try

        conn.Open()
        Dim command As New SqlCommand("SELECT Student_Id, Fname, Surname, RegStatus FROM dbo.Student WHERE  Student_Id = '" & lbSID.Text & "'", conn)
        Try
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read
                lbSName.Text = "" & reader("Fname") & " " & reader("Surname") & ""
                lbSID.Text = reader("Student_Id")
            End While
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            conn.Close()
        End Try
    End Sub
    Dim MsgResult As Integer
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        MsgResult = MessageBox.Show(" " & Me.lb_loggedas.Text & " !!  The System Will Shut Down ! Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If MsgResult = Windows.Forms.DialogResult.Yes Then
            ' Audit Trail
            Try
                ipadd()

                Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
                cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                cmd.Parameters.AddWithValue("@Utyp", lbusertype.Text)
                cmd.Parameters.AddWithValue("@ipAdd", Ipaddress) 'System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).GetValue(0).ToString())
                cmd.Parameters.AddWithValue("@TransTyp", ExitToolStripMenuItem.Text)
                cmd.Parameters.AddWithValue("@TransVal", Login.txtUname.Text + ", " + Login.txtPword.Text) '"Username: " + txtUname.Text + ", Password: " + txtPword.Text
                conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery().Equals(1)
                conn.Close()

            Catch ex As Exception
                MsgBox("An error has occured")
            End Try
            Login.Show()
            Login.txtUname.Clear()
            Login.txtPword.Clear()
            Login.txtUname.Focus()
            Me.Close()
            Application.Exit()

        End If
    End Sub

    Private Sub pbhome_Click(sender As Object, e As EventArgs) Handles pbhome.Click
        home()
    End Sub

    Private Sub pbstudentprof_Click(sender As Object, e As EventArgs) Handles pbstudentprof.Click
        clearSP()
        studentprof()
        If Not lbusertype.Text = "Student" Then
            loadSID()
            cmbxstudentselect.Text = Nothing
        End If
    End Sub

    Private Sub pbfinance_Click(sender As Object, e As EventArgs) Handles pbfinance.Click
        finance()
    End Sub

    Private Sub pbtools_Click(sender As Object, e As EventArgs) Handles pbtools.Click
        tools()
    End Sub

    Private Sub Homepblink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Homepblink.LinkClicked
        home()
    End Sub

    Private Sub StudentProfpblink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles StudentProfpblink.LinkClicked
        clearSP()
        studentprof()
        If Not lbusertype.Text = "Student" Then
            loadSID()
            cmbxstudentselect.Text = Nothing
        End If
    End Sub

    Private Sub FinancepbLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FinancepbLink.LinkClicked
        finance()
    End Sub

    Private Sub ToolspbLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ToolspbLink.LinkClicked
        tools()
    End Sub


    Private Sub btnSPview_Click(sender As Object, e As EventArgs) Handles btnSPview.Click
        clearSP()
        If cmbxstudentselect.Text = Nothing Then
            MsgBox("Please Select A student first!", MessageBoxIcon.Warning)
            cmbxstudentselect.Focus()
        Else
            selector = cmbxstudentselect.SelectedValue
            Call getstudentinfo()
            conn.Close()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtSPFname.Text = Nothing Then
            MsgBox("First Name Required!", MsgBoxStyle.Critical)
            txtSPFname.Focus()

        ElseIf txtSPSurname.Text = Nothing Then
            MsgBox("Surname Required", MsgBoxStyle.Critical)
            txtSPSurname.Focus()

        ElseIf txtSPOnames.Text = Nothing Then
            txtSPOnames.Text = "N/A"

        ElseIf dtpSPDOB.Value = Nothing Then
            MsgBox("Date Of Birth Required", MsgBoxStyle.Critical)
            dtpSPDOB.Focus()

        ElseIf txtSPMobile.Text = Nothing Then
            MsgBox("Mobile Number Required!", MsgBoxStyle.Critical)
            txtSPMobile.Focus()

        ElseIf txtSPEmail.Text = Nothing Then
            txtSPEmail.Text = "N/A"


        ElseIf txtSPVillage.Text = Nothing Then
            MsgBox("Home Village Reuired!", MsgBoxStyle.Critical)
            txtSPVillage.Focus()

        ElseIf txtSPTA.Text = Nothing Then
            txtSPTA.Text = "N/A"

        ElseIf txtSPDistrict.Text = Nothing Then
            MsgBox("District Requred!", MsgBoxStyle.Critical)
            txtSPDistrict.Focus()

        ElseIf txtSPNationality.Text = Nothing Then
            MsgBox("Nationality Required!", MsgBoxStyle.Critical)
            txtSPNationality.Focus()

        ElseIf txtSPPOBox.Text = Nothing Then
            MsgBox("Postal Address Required!", MsgBoxStyle.Critical)
            txtSPPOBox.Focus()

        ElseIf txtSPCResidence.Text = Nothing Then
            MsgBox("Current Residence Requiured!", MsgBoxStyle.Critical)
            txtSPCResidence.Focus()

        ElseIf txtSPSID.Text = Nothing Then
            MsgBox("Student Id Required!", MsgBoxStyle.Critical)
            txtSPSID.Focus()

        ElseIf txtSPPOS.Text = Nothing Then
            MsgBox("Program of Study Required!", MsgBoxStyle.Critical)
            txtSPPOS.Focus()

        ElseIf dtpYOA.Value = Nothing Then
            MsgBox("Year of Admission Required!", MsgBoxStyle.Critical)
            dtpYOA.Focus()

        ElseIf txtNOKFname.Text = Nothing Then
            MsgBox("Next of Keen's FirstName Required!", MsgBoxStyle.Critical)
            txtNOKFname.Focus()

        ElseIf txtNOKSurname.Text = Nothing Then
            MsgBox("Next of Keen's Surname Required!", MsgBoxStyle.Critical)
            txtNOKSurname.Focus()


        ElseIf txtNOKtittle.Text = Nothing Then
            MsgBox("Next of Keen Tittle Required!", MsgBoxStyle.Critical)
            txtNOKtittle.Focus()

        ElseIf txtNOKMobile.Text = Nothing Then
            MsgBox("Next of Keen Mobile Number Required!", MsgBoxStyle.Critical)
            txtNOKMobile.Focus()

        ElseIf txtNOKCResidence.Text = Nothing Then
            MsgBox("Next of Keen's Current Place of Residence Required!", MsgBoxStyle.Critical)
            txtNOKCResidence.Focus()

        ElseIf txtNOKPOBox.Text = Nothing Then
            MsgBox("Next of Keen's Postal Address Required!", MsgBoxStyle.Critical)
            txtNOKPOBox.Focus()

        ElseIf txtNOKRelationship.Text = Nothing Then
            MsgBox("Enter Relationship!", MsgBoxStyle.Critical)
            txtNOKRelationship.Focus()

        ElseIf txtNOKEmail.Text = Nothing Then
            MsgBox("Enter Next of Keen's Email!", MsgBoxStyle.Critical)
            txtNOKEmail.Focus()

        Else
            Try
                conn.Open()
                Dim cmd As New SqlCommand("UPDATE dbo.Student SET OtherName = '" & txtSPOnames.Text & "', DOB = '" & dtpSPDOB.Value & "', Gender = '" & cmbGender.Text & "', HomeVillage = '" & txtSPVillage.Text & "', TradAuth = '" & txtSPTA.Text & "', District = '" & txtSPDistrict.Text & "', Nationality = '" & txtSPNationality.Text & "', PostalAddress = '" & txtSPPOBox.Text & "', EmailAddress = '" & txtSPEmail.Text & "', MobileNo = '" & txtSPMobile.Text & "', CurResi = '" & txtSPCResidence.Text & "', YOA = '" & dtpYOA.Text & "', TOA = '" & txtTOA.Text & "', Accommodation = '" & txtAccomodation.Text & "' WHERE Student_Id = '" & txtSPSID.Text & "'", conn)
                cmd.CommandType = CommandType.Text

                Dim cmd1 As New SqlCommand("UPDATE [dbo].[NOK] SET [Student_Id] = '" & cmbxstudentselect.SelectedValue & "', [FirstName] = '" & txtNOKFname.Text & "', [Surname] = '" & txtNOKSurname.Text & "', [Title] = '" & txtNOKtittle.Text & "', [NOKResi] = '" & txtNOKCResidence.Text & "', [Mobile_Number] = '" & txtNOKMobile.Text & "', [Email] = '" & txtNOKEmail.Text & "', [Postal] = '" & txtNOKPOBox.Text & "', [Relationship] = '" & txtNOKRelationship.Text & "' WHERE [Student_Id] = '" & cmbxstudentselect.SelectedValue & "'", conn)
                cmd1.CommandType = CommandType.Text

                Dim cmd2 As New SqlCommand("UPDATE dbo.Student SET EmailAddress = '" & txtSPEmail.Text & "', MobileNo = '" & txtSPMobile.Text & "' WHERE Student_Id = '" & txtSPSID.Text & "'", conn)
                cmd2.CommandType = CommandType.Text
                If lbusertype.Text = "Student" Then
                    If (cmd2.ExecuteNonQuery().Equals(1)) Then
                        MsgBox("SAVE SUCCESSFUL!", MessageBoxIcon.Information)
                        conn.Close()
                    Else
                        MsgBox("SAVE FAILED!", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                        conn.Close()
                    End If
                Else
                    If (cmd.ExecuteNonQuery().Equals(1)) And (cmd1.ExecuteNonQuery().Equals(1)) Then
                        MsgBox("SAVE SUCCESSFUL!", MessageBoxIcon.Information)
                        conn.Close()
                    Else
                        MsgBox("SAVE FAILED!", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                        conn.Close()
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error in Saving. Error is :" & ex.Message, MessageBoxIcon.Warning)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub SystemBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemBackupToolStripMenuItem.Click
        conn.Close()
        SystemBackup.ShowDialog()
    End Sub

    Private Sub btnDelMajor_Click(sender As Object, e As EventArgs) Handles btnDelMajor.Click
        If dgvViwerMajors.RowCount <= 0 Then
            MsgBox("There are No Major Courses in the System. Please Add First!", MsgBoxStyle.Critical)
            txtCourseID.Focus()

        ElseIf Not dgvViwerMajors.CurrentRow.Selected Then
            MsgBox("Please Select A Major Course First!", MsgBoxStyle.Critical)

        Else
            Dim selectedrowscount As Integer = Me.dgvViwerMajors.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedrowscount > 1 Then
                MsgBox("Please Select ONE Major Course to Edit!", MsgBoxStyle.Critical)
            Else
                MsgResult = MessageBox.Show("Comfirm  Delete Major?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If MsgResult = Windows.Forms.DialogResult.Yes Then
                    Dim sqlstr As String = "DELETE FROM [dbo].[Major] WHERE [Course_id] = @CourseID And [Prog_id] = @ProgID And [YrOStudy] = @yr"
                    Dim command As New SqlCommand(sqlstr, conn)
                    command.CommandType = CommandType.Text
                    command.Parameters.AddWithValue("@CourseID", Me.dgvViwerMajors.SelectedRows(0).Cells(0).Value.ToString)
                    command.Parameters.AddWithValue("@ProgID", Me.dgvViwerMajors.SelectedRows(0).Cells(2).Value.ToString)
                    command.Parameters.AddWithValue("@yr", Me.dgvViwerMajors.SelectedRows(0).Cells(4).Value.ToString)

                    Try
                        conn.Open()
                        command.ExecuteNonQuery()
                        conn.Close()
                        MsgBox("Major Deleted successfully", MessageBoxIcon.Information)
                        ' Audit Trail
                        Try
                            ipadd()
                            Dim theQuery2 As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                            Dim cmd As SqlCommand = New SqlCommand(theQuery2, conn)
                            cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                            cmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                            cmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                            cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                            cmd.Parameters.AddWithValue("@TransTyp", "Delete Major")
                            cmd.Parameters.AddWithValue("@TransVal", Me.dgvViwerMajors.SelectedRows(0).Cells(0).Value.ToString + ", " + Me.dgvViwerMajors.SelectedRows(0).Cells(2).Value.ToString + ", " + Me.dgvViwerMajors.SelectedRows(0).Cells(4).Value.ToString)
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
                        loadMajors()
                        btnSaveMajor.Hide()
                        btnEditMajor.Show()
                        gpbMagageCourseControls.Show()

                    Catch ex As SqlException
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    Finally
                        conn.Close()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub ChangePwdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePwdToolStripMenuItem.Click
        ChangePwd.txtCPUname.Text = Login.txtUname.Text
        ChangePwd.txtCPUname.Enabled = False
        ChangePwd.ShowDialog()

    End Sub

    Private Sub btnCourseSettings_Click(sender As Object, e As EventArgs)
        Me.gpbSelectCourses.Visible = False
        Me.gpbManageCourses.Visible = True
    End Sub

    Private Sub pbTimetable_Click(sender As Object, e As EventArgs) Handles pbTimetable.Click
        timetable()
    End Sub

    Private Sub pbTimetableLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbTimetableLink.LinkClicked
        timetable()
    End Sub
    Sub timetable()
        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Add(TabTimeTable)
        btnSaveEdit.Hide()
        btnSaveTimeTableSlot.Show()
        btndelTT.Hide()
        tbcDashboad.Visible = True
        cmbxlectload()
        cmbxTTClassload()
        cmbxTTSClassload()
        CmbxttClass.Enabled = True
        cmbxDays.Enabled = True
        dtpttAStart.Enabled = True
        dtpttEnd.Enabled = True
        cmbx = cmbxCourseIDTT
        Lecturers.loadcmbx()
        checkLecturer.Checked = False
        cmbxttSLect.Enabled = False
        CheckLecDy.Checked = False
        cmbxdayFilter.Enabled = False
        cmbxCourseIDTT.Text = Nothing
        cmbxDays.Items.Clear()
        cmbxDays.Items.Add("Sunday")
        cmbxDays.Items.Add("Monday")
        cmbxDays.Items.Add("Tuesday")
        cmbxDays.Items.Add("Wednesday")
        cmbxDays.Items.Add("Thursday")
        cmbxDays.Items.Add("Friday")
        cmbxDays.Items.Add("Saturday")


    End Sub
    Sub addLect()
        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Add(TabAddLecturers)
        tbcDashboad.Visible = True
        dgvlectload()
        dgvlecturers.ClearSelection()
        cmbxOR.Items.Clear()
        cmbxOR.Items.Add("Head Of Department")
        cmbxOR.Items.Add("Deputy Head Of Department")
        cmbxOR.Text = Nothing
    End Sub

    Sub dgvlectload()
        Try
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            conn.Close()
            conn.Open()
            Dim strSQL As String = "SELECT [Lecturer_id] AS [LECTURER ID], [FirstName] AS [FIRST NAME], [MiddleName] AS [MIDDLE NAME], [Surname] AS [SURNAME],(SELECT [DeptName] FROM [dbo].[Department] WHERE [Dept_id]=[dbo].[Lecturers].[Dept_id]) AS [DEPARTMENT],[Tittle] AS [TITTLE], [Phone] AS [PHONE], [Email] AS [EMAIL] FROM [dbo].[Lecturers]"
            Dim da As New SqlDataAdapter(strSQL, conn)
            da.Fill(ds, "Lect")
            dgvlecturers.DataSource = ds.Tables("Lect")
            dgvlecturers.ClearSelection()

            If tt.Rows.Count > 0 Then
                tt.Rows.Clear()

            End If

            conn.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Sub cmbDeptload()
        conn.Open()
        Dim da2 As New SqlDataAdapter("Select Dept_id, DeptName FROM dbo.Department", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "dept")
        cmbxALDept.DataSource = ds2.Tables(0)
        cmbxALDept.ValueMember = "Dept_id"
        cmbxALDept.DisplayMember = "DeptName"
        conn.Close()
        cmbxALDept.Text = Nothing
    End Sub

    Private Sub PbAddLect_Click(sender As Object, e As EventArgs) Handles PbAddLect.Click
        addLect()
        cmbDeptload()
    End Sub

    Private Sub pbAddLectlink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles pbAddLectlink.LinkClicked
        addLect()
        cmbDeptload()
    End Sub
    Public insert As String = Nothing
    Private Sub btnLectSave_Click(sender As Object, e As EventArgs) Handles btnLectSave.Click

        'Dim lectid As String = Nothing
        Dim countid As Integer = 0
        Dim OtR As String = Nothing
        If txtLectFname.Text = Nothing Then
            MessageBox.Show("Please Enter First Name! ", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLectFname.Focus()

        ElseIf txtLectMname.Text = Nothing Then
            MessageBox.Show("Pleas Enter Middle Name!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLectMname.Focus()

        ElseIf txtLectSname.Text = Nothing Then
            MessageBox.Show("Please Enter Surname!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLectSname.Focus()

        ElseIf cmbxALDept.SelectedValue = Nothing Then
            MessageBox.Show("Please Select a Department!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxALDept.Focus()

        ElseIf txtLectMNum.Text = Nothing Then
            MessageBox.Show("Please Enter Phone Number!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLectMNum.Focus()

        ElseIf txtLectEmail.Text = Nothing Then
            MessageBox.Show("Please Enter Email!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLectEmail.Focus()

        Else
            If cmbxOR.SelectedItem = Nothing Then
                OtR = "N/A"
            Else
                OtR = cmbxOR.SelectedItem
            End If
            conn.Close()
            conn.Open()
            Dim strSQL As String = "Select [Lecturer_id] FROM [dbo].[Lecturers]"
            Dim da As New SqlDataAdapter(strSQL, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count <= 0 Then

                countid = 100
                lectid = "" & cmbxALDept.SelectedValue & "-LEC" & countid & ""
            Else
                For Each dr As DataRow In dt.Rows
                    countid = Integer.Parse(Regex.Replace(dr("Lecturer_id"), "[^\d]", ""))

                    lectid = "" & cmbxALDept.SelectedValue & "-LEC" & countid + 1 & ""

                Next
                conn.Close()
            End If
            Try
                conn.Close()
                conn.Open()
                Dim command1 As New SqlCommand("Select [Lecturer_id],[FirstName],[MiddleName],[Surname] FROM [dbo].[Lecturers] WHERE [FirstName] = '" & txtLectFname.Text & "' AND [MiddleName] = '" & txtLectMname.Text & "'AND [Surname] = '" & txtLectSname.Text & "'", conn)

                Dim reader1 As SqlDataReader = command1.ExecuteReader()
                Try
                    If reader1.Read = True Then
                        MessageBox.Show("Lecturer Already exists in the System!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        conn.Close()
                        conn.Open()
                        Dim strSQL1 As String = "SELECT [Tittle] FROM [dbo].[Lecturers] WHERE [Dept_id] = '" & cmbxALDept.SelectedValue & "' AND [Tittle] ='" & OtR & "'"
                        Dim da1 As New SqlDataAdapter(strSQL1, conn)
                        Dim dt1 As New DataTable
                        Try
                            da1.Fill(dt1)
                            If dt1.Rows.Count = 0 Then
                                insert = "Yes"
                            Else
                                If dt1.Rows(0).Item(0).ToString = "N/A" Then
                                    insert = "Yes"
                                Else
                                    MessageBox.Show("Departmental Role already Assigned For this Department Already exists in the System!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    cmbxOR.Text = Nothing
                                    cmbxOR.Focus()
                                End If
                            End If

                        Catch ex As SqlException
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                        End Try
                        If insert = "Yes" Then
                            conn.Close()
                            conn.Open()
                            Dim command2 As New SqlCommand("INSERT INTO [dbo].[Lecturers]([Lecturer_id], [FirstName], [MiddleName], [Surname], [Dept_id], [Tittle], [Phone], [Email]) VALUES('" & lectid & "','" & txtLectFname.Text & "','" & txtLectMname.Text & "','" & txtLectSname.Text & "','" & cmbxALDept.SelectedValue & "','" & OtR & "','" & txtLectMNum.Text & "','" & txtLectEmail.Text & "')", conn)
                            command2.ExecuteNonQuery()
                            conn.Close()
                            dgvlectload()
                            ' Audit Trail
                            Try
                                ipadd()
                                Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                                Dim cmmd As SqlCommand = New SqlCommand(theQuery, conn)
                                cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                                cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                                cmmd.Parameters.AddWithValue("@Utyp", Me.lbusertype.Text)
                                cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                                cmmd.Parameters.AddWithValue("@TransTyp", "Add Lecturer")
                                cmmd.Parameters.AddWithValue("@TransVal", lectid + ", " + txtLectFname.Text + " " + txtLectSname.Text + ", " + cmbxALDept.SelectedValue + ", " + txtLectMNum.Text)
                                conn.Close()
                                conn.Open()
                                cmmd.ExecuteNonQuery().Equals(1)
                                conn.Close()

                            Catch ex As Exception
                                MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                            End Try


                            'MessageBox.Show("Lecturer Added Successfully!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Dim Random As Random = New Random()
                            LecDefaultPwd = Random.Next(10000) 'will generate a number 0 To 9999
                            UserManagement.txtUMusername.Text = lectid
                            UserManagement.txtUMPword.Text = LecDefaultPwd
                            UserManagement.txtUMConfPword.Text = LecDefaultPwd
                            UserManagement.cmbxtyp.Items.Add("Lecturer")
                            UserManagement.cmbxtyp.SelectedItem = "Lecturer"
                            UserManagement.Adduser()
                            'MessageBox.Show("Lecturer Added Successfully!" & vbCrLf & "Username:  " & lectid & "" & vbCrLf & "Password:  " & LecDefaultPwd & "", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtLectFname.Clear()
                            txtLectMname.Clear()
                            txtLectSname.Clear()
                            cmbxALDept.Text = Nothing
                            cmbxOR.Text = Nothing
                            txtLectMNum.Clear()
                            txtLectEmail.Clear()
                        Else

                        End If
                    End If
                Catch ex As SqlException
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                End Try


            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
            End Try

            'Catch ex As SqlException
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
            'End Try
        End If
        'End If
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        home()
    End Sub

    Private Sub btnSP_Click(sender As Object, e As EventArgs) Handles btnSP.Click
        clearSP()
        studentprof()
        If Not lbusertype.Text = "Student" Then
            loadSID()
            cmbxstudentselect.Text = Nothing
        End If
    End Sub

    Private Sub btnLib_Click(sender As Object, e As EventArgs) Handles btnLib.Click
        tbcDashboad.TabPages.Remove(TabCourses)
        tbcDashboad.TabPages.Remove(TabTimeTable)
        tbcDashboad.TabPages.Remove(TabAddLecturers)
        tbcDashboad.TabPages.Remove(TabSProf)
        tbcDashboad.TabPages.Remove(TabCalendar)
        tbcDashboad.TabPages.Remove(TabFin)
        tbcDashboad.TabPages.Remove(TabCafe)
        tbcDashboad.TabPages.Remove(TabLib)
        tbcDashboad.TabPages.Remove(TabTools)
        tbcDashboad.TabPages.Add(TabLib)
        tbcDashboad.Visible = True
        RichTextBox1.ReadOnly = True
    End Sub

    Private Sub btn_Fin_Click(sender As Object, e As EventArgs) Handles btn_Fin.Click
        finance()
    End Sub

    Private Sub btnTools_Click(sender As Object, e As EventArgs) Handles btnTools.Click
        tools()
    End Sub

    Private Sub linkweb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkweb.LinkClicked
        Try
            System.Diagnostics.Process.Start("http://www.shareworld.edu.mw/lilongwe/")
        Catch ex As Exception
            MessageBox.Show("Hypalink Error: " & ex.Message & "", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub llExamNum_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llExamNum.LinkClicked
        conn.Close()
        conn.Open()
        Dim command As New SqlCommand("SELECT * FROM [dbo].[Exam] WHERE [Student_id] = '" & lbkeepSID.Text & "' And [AcademicYear] = '" & Acyear & "'", conn)
        Dim dr As SqlDataReader = command.ExecuteReader()
        dr.Read()
        Tuition_Management.txtViewExamNum.Text = dr("ExamNum").ToString
        dr.Close()
        conn.Close()
        Tuition_Management.ShowDialog()

    End Sub
    Private Sub acYrSem()
        Dim strSQL As String = "SELECT * FROM [dbo].[AcademicYear] ORDER BY [YrEnd] DESC"
        Dim da As New SqlDataAdapter(strSQL, conn)
        Dim dt As New DataTable
        conn.Close()
        conn.Open()
        da.Fill(dt)

        If dt.Rows.Count <= 0 Then
            conn.Close()
            tssAcYr.Text = "" & Date.Now.Year.ToString & " Academic Year"
            tssSem.Text = "NULL"
            conn.Close()

        Else
            For Each dr As DataRow In dt.Rows

                If Date.Now > Convert.ToDateTime(dr("YrBegin")) And Date.Now < Convert.ToDateTime(dr("YrBreak")) Then
                    tssAcYr.Text = " Academic Year " & Date.Now.Year.ToString & ""
                    tssSem.Text = ",  Semester 1"
                    conn.Close()
                    Exit For
                ElseIf Date.Now > Convert.ToDateTime(dr("YrResume")) And Date.Now < Convert.ToDateTime(dr("YrEnd")) Then
                    tssAcYr.Text = " Academic Year " & Date.Now.Year.ToString & ""
                    tssSem.Text = ",  Semester 2"
                    conn.Close()
                    Exit For
                End If

            Next
            conn.Close()
        End If
        conn.Close()
    End Sub

    Sub cmbxTTClassload()
        conn.Open()
        Dim da2 As New SqlDataAdapter("SELECT [Class_Id] FROM [dbo].[Class] ORDER BY [Class_Id] ASC", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Class")
        CmbxttClass.DataSource = ds2.Tables(0)
        CmbxttClass.ValueMember = "Class_Id"
        CmbxttClass.DisplayMember = "Class_Id"
        conn.Close()
        CmbxttClass.Text = Nothing
    End Sub

    Sub cmbxlectload()
        conn.Open()
        Dim da2 As New SqlDataAdapter("SELECT [Lecturer_id], ([FirstName] +' '+[Surname]) AS [Name] FROM [dbo].[Lecturers] ORDER BY [Lecturer_id] ASC", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Lect")
        cmbxlect.DataSource = ds2.Tables(0)
        cmbxlect.ValueMember = "Lecturer_id"
        cmbxlect.DisplayMember = "Name"
        conn.Close()
        cmbxlect.Text = Nothing
    End Sub

    Private Sub btnSaveTimeTableSlot_Click(sender As Object, e As EventArgs) Handles btnSaveTimeTableSlot.Click
        If cmbxCourseIDTT.SelectedValue = Nothing Then
            MessageBox.Show("Please select A Course!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxCourseIDTT.Focus()

        ElseIf cmbxlect.SelectedValue = Nothing Then
            MessageBox.Show("Please Select a Lecturer!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxlect.Focus()

        ElseIf txtRoom.Text = Nothing Then
            MessageBox.Show("Please Provide a Room!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoom.Focus()

        ElseIf cmbxDays.SelectedItem = Nothing Then
            MessageBox.Show("Please Select a Day!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxDays.Focus()

        ElseIf dtpttAStart.Value = Nothing Then
            MessageBox.Show("Please Provide a Strating Time!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpttAStart.Focus()

        ElseIf dtpttEnd.Value = Nothing Then
            MessageBox.Show("Please Provide an Ending Time!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpttEnd.Focus()
        Else

            conn.Close()
            conn.Open()
            Dim command As New SqlCommand("SELECT * FROM [dbo].[TimeTable] ORDER BY [Lecturer_id]", conn)
            Dim reader As SqlDataReader = command.ExecuteReader()
            Try
                reader.Read()

                If Not reader.HasRows Then
                    conn.Close()
                    conn.Open()
                    Dim command2 As New SqlCommand("INSERT INTO [dbo].[TimeTable] ([Class_Id],[Course_id],[Lecturer_id],[Room],[DayOfLecture],[StartTime],[EndTime]) VALUES ('" & CmbxttClass.SelectedValue & "','" & cmbxCourseIDTT.SelectedValue & "','" & cmbxlect.SelectedValue & "','" & txtRoom.Text & "','" & cmbxDays.SelectedItem & "','" & dtpttAStart.Text & "','" & dtpttEnd.Text & "')", conn)
                    command2.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Timetable Entry Successful!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CmbxttClass.Text = Nothing
                    cmbxCourseIDTT.Text = Nothing
                    cmbxlect.Text = Nothing
                    txtRoom.Clear()
                    cmbxDays.Text = Nothing
                    dtpttAStart.ResetText()
                    dtpttEnd.ResetText()

                Else
                    If reader("Course_id") = cmbxCourseIDTT.SelectedValue And reader("Lecturer_id") = cmbxlect.SelectedValue And reader("DayOfLecture") = cmbxDays.SelectedItem And (Convert.ToDateTime(reader("StartTime"))) <= (Convert.ToDateTime(dtpttAStart.Text)) And (Convert.ToDateTime(dtpttAStart.Text)) <= (Convert.ToDateTime(reader("EndTime"))) Then '
                        MessageBox.Show("Entry already Exists")
                    ElseIf reader("Class_Id") = CmbxttClass.SelectedValue And cmbxDays.SelectedItem = reader("DayOfLecture") And dtpttAStart.Value >= Convert.ToDateTime(reader("StartTime")) And dtpttAStart.Value <= Convert.ToDateTime(reader("EndTime")) Then
                        MessageBox.Show("Selected Class already have a Lecture At this Time")
                    ElseIf reader("Room") = txtRoom.Text And cmbxDays.SelectedItem = reader("DayOfLecture") And dtpttAStart.Value >= Convert.ToDateTime(reader("StartTime")) And dtpttAStart.Value <= Convert.ToDateTime(reader("EndTime")) Then
                        MessageBox.Show("The specified Room is not available!")
                    ElseIf reader("Lecturer_id") = cmbxlect.SelectedValue And cmbxDays.SelectedItem = reader("DayOfLecture") And dtpttAStart.Value >= Convert.ToDateTime(reader("StartTime")) And dtpttAStart.Value <= Convert.ToDateTime(reader("EndTime")) Then
                        MessageBox.Show("Lecturer Specified is engaged, Please select another Lecturer!")

                    Else
                        conn.Close()
                        conn.Open()
                        Dim command2 As New SqlCommand("INSERT INTO [dbo].[TimeTable] ([Class_Id],[Course_id],[Lecturer_id],[Room],[DayOfLecture],[StartTime],[EndTime]) VALUES ('" & CmbxttClass.SelectedValue & "','" & cmbxCourseIDTT.SelectedValue & "','" & cmbxlect.SelectedValue & "','" & txtRoom.Text & "','" & cmbxDays.SelectedItem & "','" & dtpttAStart.Text & "','" & dtpttEnd.Text & "')", conn)
                        command2.ExecuteNonQuery()
                        conn.Close()
                        MessageBox.Show("Timetable Entry Successful!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CmbxttClass.Text = Nothing
                        cmbxCourseIDTT.Text = Nothing
                        cmbxlect.Text = Nothing
                        txtRoom.Clear()
                        cmbxDays.Text = Nothing
                        dtpttAStart.ResetText()
                        dtpttEnd.ResetText()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error :" + ex.Message, "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Sub cmbxTTSClassload()

        conn.Open()
        Dim da2 As New SqlDataAdapter("Select [Class_Id] FROM [dbo].[Class] ORDER BY [Class_Id] ASC", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Class")
        cmbxTTSclass.DataSource = ds2.Tables(0)
        cmbxTTSclass.ValueMember = "Class_Id"
        cmbxTTSclass.DisplayMember = "Class_Id"
        conn.Close()
        cmbxTTSclass.Text = Nothing
    End Sub

    Public Sub loadTT()
        tt.ReadOnly = True
        Try
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            conn.Close()
            conn.Open()
            Dim strSQL As String = "Select [Course_id] As [Course], (SELECT [FirstName]+' '+[MiddleName]+' '+[Surname] FROM [dbo].[Lecturers] WHERE [Lecturer_id] = [dbo].[TimeTable].[Lecturer_id]) As [Lecturer] , [Room], [DayOfLecture] As [Day], [StartTime] AS [Start Time], [EndTime] AS [End Time] FROM [dbo].[TimeTable] WHERE Class_Id = '" + cmbxTTSclass.Text + "'"
            Dim da As New SqlDataAdapter(strSQL, conn)
            da.Fill(ds, "TT")
            dgvtimetable.DataSource = ds.Tables("TT")
            dgvtimetable.ClearSelection()

            If tt.Rows.Count > 0 Then
                tt.Rows.Clear

            End If

            conn.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub

    Private Sub cmbxTTSclass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxTTSclass.SelectedIndexChanged
        loadTT()
    End Sub

    Private Sub btnViewTT_Click(sender As Object, e As EventArgs) Handles btnViewTT.Click
        gpbtimetableControls.Hide()
        gpbTimetable.Show()
    End Sub

    Private Sub btnSetTT_Click(sender As Object, e As EventArgs) Handles btnSetTT.Click
        gpbtimetableControls.Show()
        gpbTimetable.Hide()
        btnSaveEdit.Hide()
        btnSaveTimeTableSlot.Show()
    End Sub

    Private Sub cmbxdayFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxdayFilter.SelectedIndexChanged
        If cmbxTTSclass.SelectedValue = Nothing Then
            MessageBox.Show("Please Select a class First!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            dgvtimetable.DataSource = Nothing
            cmbxttSLect.Text = Nothing
            tt.ReadOnly = True
            Try
                Dim ds As New DataSet
                Dim ds1 As New DataSet
                conn.Close()
                conn.Open()
                '[Class_Id] As [Class]
                Dim strSQL As String = "SELECT [Course_id] As [Course], (SELECT [FirstName]+' '+[MiddleName]+' '+[Surname] FROM [dbo].[Lecturers] WHERE [Lecturer_id] = [dbo].[TimeTable].[Lecturer_id]) As [Lecturer] , [Room], [DayOfLecture] As [Day], [StartTime] AS [Start Time], [EndTime] AS [End Time] FROM [dbo].[TimeTable] WHERE Class_Id = '" + cmbxTTSclass.Text + "' And [DayOfLecture] ='" + cmbxdayFilter.Text + "' ORDER BY [StartTime]"
                Dim da As New SqlDataAdapter(strSQL, conn)
                da.Fill(ds, "TT")
                dgvtimetable.DataSource = ds.Tables("TT")
                dgvtimetable.ClearSelection()

                If tt.Rows.Count > 0 Then
                    tt.Rows.Clear()

                End If
                conn.Close()
            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        End If
    End Sub
    Sub cmbxttslectload()
        conn.Open()
        Dim da2 As New SqlDataAdapter("SELECT [Lecturer_id], ([FirstName] +' '+[MiddleName]+' '+[Surname]) AS [Name] FROM [dbo].[Lecturers] ORDER BY [Lecturer_id] ASC", conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Lect")
        cmbxttSLect.DataSource = ds2.Tables(0)
        cmbxttSLect.ValueMember = "Lecturer_id"
        cmbxttSLect.DisplayMember = "Name"
        conn.Close()
        cmbxttSLect.Text = Nothing
    End Sub

    Private Sub cmbxttSLect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxttSLect.SelectedIndexChanged

    End Sub

    Private Sub CheckLecDy_CheckedChanged(sender As Object, e As EventArgs) Handles CheckLecDy.CheckedChanged
        If CheckLecDy.Checked = True Then
            cmbxdayFilter.Enabled = True
        Else
            cmbxdayFilter.Text = Nothing
            cmbxdayFilter.Enabled = False
        End If
    End Sub

    Private Sub checkLecturer_CheckedChanged(sender As Object, e As EventArgs) Handles checkLecturer.CheckedChanged
        If checkLecturer.Checked = True Then
            cmbxttSLect.Enabled = True
            cmbxttslectload()
            cmbxttSLect.Text = Nothing
        Else
            cmbxttSLect.Text = Nothing
            cmbxttSLect.Enabled = False
        End If
    End Sub

    Private Sub ttlecSearch_Click(sender As Object, e As EventArgs) Handles ttlecSearch.Click
        If cmbxTTSclass.SelectedValue = Nothing Then
            MessageBox.Show("Please Select a class First!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxTTSclass.Focus()
        ElseIf cmbxttSLect.SelectedValue = Nothing Then
            MessageBox.Show("Please Select a Lecturer First!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxttSLect.Focus()
        Else
            dgvtimetable.DataSource = Nothing
            tt.ReadOnly = True
            Try
                Dim ds As New DataSet
                'Dim ds1 As New DataSet
                conn.Close()
                conn.Open()

                If Not cmbxdayFilter.Text = Nothing And CheckLecDy.Checked = True Then
                    If tt.Rows.Count > 0 Then
                        tt.Rows.Clear()
                    End If
                    Dim strSQL1 As String = "SELECT [Course_id] As [Course], (SELECT [FirstName] +' '+ [MiddleName] +' '+ [Surname] FROM [dbo].[Lecturers] WHERE [Lecturer_id] = [dbo].[TimeTable].[Lecturer_id]) As [Lecturer] , [Room], [DayOfLecture] As [Day], [StartTime] AS [Start Time], [EndTime] AS [End Time] FROM [dbo].[TimeTable] WHERE [Class_Id] = '" + cmbxTTSclass.Text + "' And [DayOfLecture] ='" + cmbxdayFilter.Text + "' And [Lecturer_id] ='" + cmbxttSLect.SelectedValue.ToString + "' ORDER BY [StartTime]"
                    Dim da As New SqlDataAdapter(strSQL1, conn)
                    da.Fill(ds, "TT")
                    dgvtimetable.DataSource = ds.Tables("TT")
                    dgvtimetable.ClearSelection()
                    conn.Close()
                Else
                    If tt.Rows.Count > 0 Then
                        tt.Rows.Clear()
                    End If
                    Dim strSQL As String = "SELECT [Course_id] As [Course], (SELECT [FirstName] +' '+ [MiddleName] +' '+ [Surname] FROM [dbo].[Lecturers] WHERE [Lecturer_id] = [dbo].[TimeTable].[Lecturer_id]) As [Lecturer] , [Room], [DayOfLecture] As [Day], [StartTime] AS [Start Time], [EndTime] AS [End Time] FROM [dbo].[TimeTable] WHERE Class_Id = '" + cmbxTTSclass.Text + "' And Lecturer_id ='" + cmbxttSLect.SelectedValue.ToString + "' ORDER BY [StartTime]"
                    Dim da As New SqlDataAdapter(strSQL, conn)
                    da.Fill(ds, "TT")
                    dgvtimetable.DataSource = ds.Tables("TT")
                    dgvtimetable.ClearSelection()
                    conn.Close()

                End If
                conn.Close()
            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        End If
    End Sub

    Private Sub btnEditTT_Click(sender As Object, e As EventArgs) Handles btnEditTT.Click
        If dgvtimetable.Rows.Count < 1 Then
            MessageBox.Show("No Timetable Enties to Edit, Please Load A Timetable First!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Me.dgvtimetable.CurrentRow.Selected = Nothing Then
            MessageBox.Show("Please Select an entry to Edit!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else
            Dim selectedrowscount As Integer = Me.dgvtimetable.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedrowscount > 1 Then
                MessageBox.Show("Please Select an entry to Edit!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                cmbxCourseIDTT.Text = Me.dgvtimetable.CurrentRow.Cells(0).Value.ToString
                CmbxttClass.Text = Me.cmbxTTSclass.SelectedValue
                cmbxlect.Text = Me.dgvtimetable.CurrentRow.Cells(1).Value.ToString
                txtRoom.Text = Me.dgvtimetable.CurrentRow.Cells(2).Value.ToString
                cmbxDays.Text = Me.dgvtimetable.CurrentRow.Cells(3).Value.ToString
                dtpttAStart.Text = Me.dgvtimetable.CurrentRow.Cells(4).Value.ToString
                dtpttEnd.Text = Me.dgvtimetable.CurrentRow.Cells(5).Value.ToString
                gpbTimetable.Hide()
                gpbtimetableControls.Show()
                btnSaveEdit.Show()
                btnSaveTimeTableSlot.Hide()
                btndelTT.Show()
                CmbxttClass.Enabled = False
                cmbxDays.Enabled = False
                dtpttAStart.Enabled = False
                dtpttEnd.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSaveEdit_Click(sender As Object, e As EventArgs) Handles btnSaveEdit.Click
        If cmbxCourseIDTT.SelectedValue = Nothing Then
            MessageBox.Show("Please select A Course!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxCourseIDTT.Focus()

        ElseIf cmbxlect.SelectedValue = Nothing Then
            MessageBox.Show("Please Select a Lecturer!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxlect.Focus()

        ElseIf txtRoom.Text = Nothing Then
            MessageBox.Show("Please Provide a Room!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoom.Focus()

        ElseIf cmbxDays.SelectedItem = Nothing Then
            MessageBox.Show("Please Select a Day!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbxDays.Focus()

        ElseIf dtpttAStart.Value = Nothing Then
            MessageBox.Show("Please Provide a Strating Time!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpttAStart.Focus()

        ElseIf dtpttEnd.Value = Nothing Then
            MessageBox.Show("Please Provide an Ending Time!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpttEnd.Focus()
        Else

            conn.Close()
            conn.Open()
            Dim command As New SqlCommand("SELECT * FROM [dbo].[TimeTable] ORDER BY [Lecturer_id]", conn)
            Dim reader As SqlDataReader = command.ExecuteReader()
            Try
                reader.Read()

                If reader("Class_Id") = CmbxttClass.SelectedValue And reader("Course_id") = cmbxCourseIDTT.SelectedValue And reader("Lecturer_id") = cmbxlect.SelectedValue And reader("DayOfLecture") = cmbxDays.SelectedItem And (Convert.ToDateTime(reader("StartTime"))) <= (Convert.ToDateTime(dtpttAStart.Text)) And (Convert.ToDateTime(dtpttAStart.Text)) <= (Convert.ToDateTime(reader("EndTime"))) Then '
                    MessageBox.Show("Entry already Exists")
                ElseIf reader("Class_Id") = CmbxttClass.SelectedValue And cmbxDays.SelectedItem = reader("DayOfLecture") And dtpttAStart.Value >= Convert.ToDateTime(reader("StartTime")) And dtpttAStart.Value <= Convert.ToDateTime(reader("EndTime")) Then
                    MessageBox.Show("Selected Class already have a Lecture At this Time")
                ElseIf reader("Room") = txtRoom.Text And cmbxDays.SelectedItem = reader("DayOfLecture") And dtpttAStart.Value >= Convert.ToDateTime(reader("StartTime")) And dtpttAStart.Value <= Convert.ToDateTime(reader("EndTime")) Then
                    MessageBox.Show("The specified Room is not available!")
                ElseIf reader("Class_Id") = CmbxttClass.SelectedValue And reader("Lecturer_id") = cmbxlect.SelectedValue And cmbxDays.SelectedItem = reader("DayOfLecture") And dtpttAStart.Value >= Convert.ToDateTime(reader("StartTime")) And dtpttAStart.Value <= Convert.ToDateTime(reader("EndTime")) Then
                    MessageBox.Show("Lecturer Specified is engaged, Please select another Lecturer!")

                Else
                    conn.Close()
                    conn.Open()
                    Dim command1 As New SqlCommand("UPDATE [dbo].[TimeTable] SET [Class_Id] = '" & CmbxttClass.SelectedValue & "', [Course_id] = '" & cmbxCourseIDTT.SelectedValue & "', [Lecturer_id] = '" & cmbxlect.SelectedValue & "', [Room] = '" & txtRoom.Text & "', [DayOfLecture] = '" & cmbxDays.SelectedItem & "', [StartTime] = '" & dtpttAStart.Text & "', [EndTime] = '" & dtpttEnd.Text & "' WHERE  [Class_Id] = '" & Me.cmbxTTSclass.Text & "' AND [Course_id] = '" & Me.dgvtimetable.CurrentRow.Cells(0).Value.ToString & "' AND [Room] = '" & Me.dgvtimetable.CurrentRow.Cells(2).Value.ToString & "' AND [DayOfLecture] = '" & Me.dgvtimetable.CurrentRow.Cells(3).Value.ToString & "'AND [StartTime] = '" & Me.dgvtimetable.CurrentRow.Cells(4).Value.ToString & "' AND [EndTime] = '" & Me.dgvtimetable.CurrentRow.Cells(5).Value.ToString & "'", conn)
                    command1.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Timetable Edited Successfully!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnSaveEdit.Hide()
                    btnSaveTimeTableSlot.Show()
                    btndelTT.Hide()
                    CmbxttClass.Text = Nothing
                    cmbxCourseIDTT.Text = Nothing
                    cmbxlect.Text = Nothing
                    txtRoom.Clear()
                    cmbxDays.Text = Nothing
                    dtpttAStart.ResetText()
                    dtpttEnd.ResetText()
                    cmbxTTSclass.Text = Nothing
                    dgvtimetable.DataSource = Nothing
                    CmbxttClass.Enabled = True
                    cmbxDays.Enabled = True
                    dtpttAStart.Enabled = True
                    dtpttEnd.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show("Error :" + ex.Message, "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                reader.Close()
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub btndelTT_Click(sender As Object, e As EventArgs) Handles btndelTT.Click
        MsgResult = MessageBox.Show("You are about to Delete a Timetable Entry, Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If MsgResult = Windows.Forms.DialogResult.Yes Then
            Try
                conn.Close()
                conn.Open()
                Dim command1 As New SqlCommand("DELETE FROM [dbo].[TimeTable] WHERE  [Class_Id] = '" & Me.cmbxTTSclass.Text & "' AND [Course_id] = '" & Me.dgvtimetable.CurrentRow.Cells(0).Value.ToString & "' AND [Room] = '" & Me.dgvtimetable.CurrentRow.Cells(2).Value.ToString & "' AND [DayOfLecture] = '" & Me.dgvtimetable.CurrentRow.Cells(3).Value.ToString & "'AND [StartTime] = '" & Me.dgvtimetable.CurrentRow.Cells(4).Value.ToString & "' AND [EndTime] = '" & Me.dgvtimetable.CurrentRow.Cells(5).Value.ToString & "'", conn)
                command1.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Timetable Entry Deleted Successfully!", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSaveEdit.Hide()
                btnSaveTimeTableSlot.Show()
                btndelTT.Hide()
                CmbxttClass.Text = Nothing
                cmbxCourseIDTT.Text = Nothing
                cmbxlect.Text = Nothing
                txtRoom.Clear()
                cmbxDays.Text = Nothing
                dtpttAStart.ResetText()
                dtpttEnd.ResetText()
                cmbxTTSclass.Text = Nothing
                dgvtimetable.DataSource = Nothing
                CmbxttClass.Enabled = True
                cmbxDays.Enabled = True
                dtpttAStart.Enabled = True
                dtpttEnd.Enabled = True

            Catch ex As Exception
                MessageBox.Show("Error :" + ex.Message, "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                conn.Close()
            End Try

        End If
    End Sub

    Private Sub btnbackFin_Click(sender As Object, e As EventArgs) Handles btnbackFin.Click
        AccNum.CheckAccNum.Checked = False
        AccNum.StName.Checked = False
        AccNum.cmbxAccNoAccNum.DataSource = Nothing
        btn_Fin.PerformClick()
        btnAccState.PerformClick()
    End Sub

    Private Sub btnBackLdgr_Click(sender As Object, e As EventArgs) Handles btnBackLdgr.Click
        btn_Fin.PerformClick()
    End Sub

    Private Sub btnBackPostTrans_Click(sender As Object, e As EventArgs) Handles btnBackPostTrans.Click
        btn_Fin.PerformClick()
    End Sub

    Private Sub btnBackSP_Click(sender As Object, e As EventArgs) Handles btnBackSP.Click
        btnhome.PerformClick()
    End Sub
End Class