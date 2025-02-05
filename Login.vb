Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports SIMS_Core.globalVariables
Imports System.Configuration
Imports System.Text
Public Class Login

    Dim login As String = Nothing
    Dim password As String
    Dim username As String
    Dim dt As New DataTable
    Dim usertyp As String = Nothing
    Public Shared Property addCourseAcces As String = Nothing
    Public accstate As String = Nothing
    Dim connStr As String = ConfigurationManager.ConnectionStrings("MyDBConnection").ConnectionString
    Dim conn As New SqlConnection(connStr)


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim reader As SqlDataReader = Nothing
        If txtUname.Text = Nothing Then
            MsgBox("PLEASE ENTER YOUR USERNAME!", MessageBoxIcon.Warning)
            txtUname.Focus()
        ElseIf txtPword.Text = Nothing Then
            MsgBox("PLEASE ENTER YOUR PASSWORD!", MessageBoxIcon.Warning)
            txtPword.Focus()
        Else
            Try
                Me.UseWaitCursor = True
                txtPword.Text = GenerateHash(txtPword.Text)

                conn.Open()
                Dim command As New SqlCommand("SELECT username, password FROM dbSIMS.dbo.users WHERE username='" & txtUname.Text & "' and password='" & txtPword.Text & "'", conn)
                reader = command.ExecuteReader()
                reader.Read()
                If reader.HasRows Then
                    login = "go"
                    Me.UseWaitCursor = False

                ElseIf Not reader.HasRows Then
                    login = Nothing
                    Me.UseWaitCursor = False
                    reader.Close()
                    MsgBox("Invalid credentials", MessageBoxIcon.Warning)
                    txtPword.Clear()
                    txtUname.Clear()
                    txtUname.Focus()

                End If

                If Not login = Nothing Then
                    Call logintype()

                End If

            Catch ex As Exception
                MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
            Finally
                reader.Close()
            End Try

        End If

        conn.Close()
        Exit Sub
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Application.OpenForms().OfType(Of ChangePwd).Any Then
            ChangePwd.Close()
        End If
        txtUname.Clear()
        txtPword.Clear()
        txtUname.Focus()

    End Sub
    Dim MsgResult As Integer
    Private Sub LLCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LLCancel.LinkClicked
        MsgResult = MessageBox.Show("The System Will Shut Down ! Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If MsgResult = Windows.Forms.DialogResult.Yes Then

            Application.Exit()

        End If
    End Sub

    Private Sub logintype()
        Lecturers.btnPostAssignPannel.Visible = False
        Lecturers.btnViewAssigPannel.Visible = False
        'frmHome.gpbTimetable.Show()
        'frmHome.gpbtimetableControls.Hide()
        frmHome.StudentProfpblink.Enabled = True
        frmHome.pbstudentprof.Enabled = True
        frmHome.LinkSProf.Enabled = True
        frmHome.gpbManageCourses.Visible = True
        frmHome.dgvCorses.Visible = True
        frmHome.pbCourses.Enabled = True
        frmHome.llCourses.Enabled = True
        Lecturers.AssignmentToolStripMenuItem.Enabled = True
        Lecturers.pbAssignment.Enabled = True
        Lecturers.pbAssignLink.Enabled = True
        Lecturers.gpbPostAssign.Visible = True
        Lecturers.gbGradebook.Visible = True
        Lecturers.GradeBookToolStripMenuItem.Enabled = True
        Lecturers.pbgradebookLink.Enabled = True
        Lecturers.pbgradebook.Enabled = True
        frmHome.LinkLib.Enabled = True
        frmHome.gpbManageCourses.Visible = True
        frmHome.pbCourses.Enabled = True
        frmHome.llCourses.Enabled = True
        frmHome.gpbCourseMajor.Enabled = True
        frmHome.btnViewMajors.Enabled = True
        frmHome.btnBackcourses.Enabled = True
        frmHome.PbAddLect.Visible = True
        frmHome.pbAddLectlink.Visible = True
        frmHome.PbAddLect.Enabled = True
        frmHome.pbAddLectlink.Enabled = True
        frmHome.pbTimetable.Enabled = True
        frmHome.pbTimetableLink.Enabled = True
        frmHome.gpbtimetableControls.Hide()
        frmHome.gpbTimetable.Show()


        Lecturers.AssignmentToolStripMenuItem.Enabled = True
        Lecturers.pbAssignment.Enabled = True
        Lecturers.pbAssignLink.Enabled = True
        Lecturers.gpbViewAssign.Visible = True
        Lecturers.CLassesToolStripMenuItem.Enabled = True
        Lecturers.pbClasses.Enabled = True
        Lecturers.pbClassesLink.Enabled = True
        frmHome.pbSettingsTuit.Enabled = True
        frmHome.lbTuition.Enabled = True
        Lecturers.GradesManagementToolStripMenuItem.Enabled = True
        Lecturers.pbGradesUploadLink.Enabled = True
        Lecturers.pbUpploadGrades.Enabled = True
        Lecturers.AnnouncementsToolStripMenuItem.Enabled = True
        Lecturers.pbAnnounce.Enabled = True
        Lecturers.pbAnnounceLink.Enabled = True
        Lecturers.gpbPostAnnounce.Visible = True
        Lecturers.AttendanceToolStripMenuItem.Enabled = True
        Lecturers.pbAttend.Enabled = True
        Lecturers.pbAttendLink.Enabled = True
        StudentManager.gpbStudentMan.Enabled = True
        StudentManager.gpbExam.Enabled = True
        frmHome.SystemBackupToolStripMenuItem.Enabled = True
        frmHome.btnAccState.Enabled = True
        frmHome.btnTrasactionLeger.Enabled = True
        frmHome.btnPost.Enabled = True
        frmHome.pbReport.Enabled = True
        frmHome.lbReports.Enabled = True
        frmHome.pbUerManager.Enabled = True
        frmHome.LinkUsermanager.Enabled = True
        frmHome.pbUerManager.Visible = True
        frmHome.LinkUsermanager.Visible = True
        frmHome.pbStudentMan.Visible = True
        frmHome.LinkStudentMan.Visible = True
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        frmHome.btnSetTT.Show()
        frmHome.btnViewTT.Show()
        frmHome.btnEditTT.Show()
        frmHome.pbSettingsTuit.Visible = True
        frmHome.lbTuition.Visible = True
        frmHome.pbReport.Visible = True
        frmHome.lbReports.Visible = True
        Lecturers.btnPostAssignPannel.Visible = True
        Lecturers.btnViewAssigPannel.Visible = True
        Lecturers.GradesManagementToolStripMenuItem.Visible = True
        Lecturers.pbGradesUploadLink.Visible = True
        Lecturers.pbUpploadGrades.Visible = True
        Lecturers.pbAttend.Visible = True
        Lecturers.pbAttendLink.Visible = True
        Lecturers.CLassesToolStripMenuItem.Visible = True
        Lecturers.pbClasses.Visible = True
        Lecturers.pbClassesLink.Visible = True
        Lecturers.AttendanceToolStripMenuItem.Visible = True
        conn.Close()
        conn.Open()
        Dim command As New SqlCommand("SELECT [usertyp] FROM dbo.users WHERE [username] = '" & txtUname.Text & "'", conn)
        Try
            Dim dr As SqlDataReader = command.ExecuteReader()
            dr.Read()

            If dr("usertyp") = "Student" Then
                frmHome.lbusertype.Text = "Student"
                frmHome.btnViewTT.Hide()
                frmHome.btnSetTT.Hide()
                frmHome.btnEditTT.Hide()
                frmHome.gpbtimetableControls.Hide()
                frmHome.gpbTimetable.Show()
                frmHome.pbUerManager.Visible = False
                frmHome.LinkUsermanager.Visible = False
                frmHome.pbStudentMan.Visible = False
                frmHome.LinkStudentMan.Visible = False
                frmHome.PbAddLect.Visible = False
                frmHome.pbAddLectlink.Visible = False
                frmHome.pbReport.Visible = False
                frmHome.lbReports.Visible = False
                frmHome.pbSettingsTuit.Visible = False
                frmHome.lbTuition.Visible = False
                frmHome.SystemBackupToolStripMenuItem.Visible = False
                frmHome.gpbtimetableControls.Hide()
                Lecturers.btnPostAssignPannel.Visible = False
                Lecturers.btnViewAssigPannel.Visible = False
                Lecturers.GradesManagementToolStripMenuItem.Visible = False
                Lecturers.pbGradesUploadLink.Visible = False
                Lecturers.pbUpploadGrades.Visible = False
                Lecturers.pbAttend.Visible = False
                Lecturers.pbAttendLink.Visible = False
                Lecturers.CLassesToolStripMenuItem.Visible = False
                Lecturers.pbClasses.Visible = False
                Lecturers.pbClassesLink.Visible = False
                Lecturers.AttendanceToolStripMenuItem.Visible = False
                frmHome.lb_loggedas.Text = txtUname.Text
                If Application.OpenForms().OfType(Of ChangePwd).Any Then
                    ChangePwd.Close()
                End If
                frmHome.Show()
                Me.Hide()
            ElseIf dr("usertyp") = "Admin" Then
                frmHome.lbusertype.Text = "Admin"
                frmHome.lb_loggedas.Text = txtUname.Text
                frmHome.Show()
                Me.Hide()
            ElseIf dr("usertyp") = "Accountant" Then
                frmHome.lbusertype.Text = "Accountant"
                Lecturers.LbClass_course.Visible = False     'hide the "Class" module ***************
                'Lecturers.pbClass.visible = False
                frmHome.lb_loggedas.Text = txtUname.Text
                frmHome.pbUerManager.Visible = False
                frmHome.LinkUsermanager.Visible = False
                frmHome.pbStudentMan.Visible = False
                frmHome.LinkStudentMan.Visible = False
                frmHome.PbAddLect.Visible = False
                frmHome.pbAddLectlink.Visible = False
                frmHome.pbSettingsTuit.Visible = False
                frmHome.lbTuition.Visible = False
                frmHome.pbReport.Visible = True
                frmHome.lbReports.Visible = True
                Lecturers.GradesManagementToolStripMenuItem.Visible = False
                Lecturers.pbGradesUploadLink.Visible = False
                Lecturers.pbUpploadGrades.Visible = False
                Lecturers.pbAttend.Visible = False
                Lecturers.pbAttendLink.Visible = False
                Lecturers.CLassesToolStripMenuItem.Visible = True
                Lecturers.pbClasses.Visible = True
                Lecturers.pbClassesLink.Visible = True
                Lecturers.AttendanceToolStripMenuItem.Visible = True
                frmHome.Show()
                Me.Hide()

            ElseIf dr("usertyp") = "Lecturer" Then
                frmHome.lbusertype.Text = "Lecturer"
                frmHome.lb_loggedas.Text = txtUname.Text
                Lecturers.LbClass_course.Visible = True     'unhide the "Class" module ***************
                'Lecturers.pbClass.visible = False
                frmHome.btnSetTT.Hide()
                frmHome.gpbTimetable.Show()
                frmHome.gpbtimetableControls.Hide()
                frmHome.lb_loggedas.Text = txtUname.Text
                frmHome.pbUerManager.Visible = False
                frmHome.LinkUsermanager.Visible = False
                frmHome.pbStudentMan.Visible = False
                frmHome.LinkStudentMan.Visible = False
                frmHome.PbAddLect.Visible = False
                frmHome.pbAddLectlink.Visible = False
                frmHome.pbSettingsTuit.Visible = False
                frmHome.lbTuition.Visible = False
                frmHome.pbReport.Visible = True
                frmHome.lbReports.Visible = True
                Lecturers.GradesManagementToolStripMenuItem.Visible = True
                Lecturers.pbGradesUploadLink.Visible = True
                Lecturers.pbUpploadGrades.Visible = True
                Lecturers.pbAttend.Visible = True
                Lecturers.pbAttendLink.Visible = True
                Lecturers.CLassesToolStripMenuItem.Visible = True
                Lecturers.pbClasses.Visible = True
                Lecturers.pbClassesLink.Visible = True
                Lecturers.AttendanceToolStripMenuItem.Visible = True
                frmHome.Show()
                Me.Hide()

            ElseIf dr("usertyp") = "Registrar" Then
                frmHome.lbusertype.Text = "Registrar"
                frmHome.lb_loggedas.Text = txtUname.Text
                frmHome.pbUerManager.Visible = False
                frmHome.LinkUsermanager.Visible = False
                frmHome.pbStudentMan.Visible = True
                frmHome.LinkStudentMan.Visible = True
                frmHome.PbAddLect.Visible = True
                frmHome.pbAddLectlink.Visible = True
                frmHome.pbSettingsTuit.Visible = True
                frmHome.lbTuition.Visible = True
                frmHome.pbReport.Visible = True
                frmHome.lbReports.Visible = True
                frmHome.btnSetTT.Hide()
                frmHome.gpbTimetable.Show()
                frmHome.gpbtimetableControls.Hide()
                Lecturers.GradesManagementToolStripMenuItem.Visible = True
                Lecturers.pbGradesUploadLink.Visible = True
                Lecturers.pbUpploadGrades.Visible = True
                Lecturers.pbAttend.Visible = True
                Lecturers.pbAttendLink.Visible = True
                Lecturers.CLassesToolStripMenuItem.Visible = True
                Lecturers.pbClasses.Visible = True
                Lecturers.pbClassesLink.Visible = True
                Lecturers.AttendanceToolStripMenuItem.Visible = False
                frmHome.Show()
                Me.Hide()

            ElseIf dr("usertyp") = "Custom" Then
                frmHome.lbusertype.Text = "Custom"
                frmHome.lb_loggedas.Text = txtUname.Text
                conn.Close()
                conn.Open()
                Dim command1 As New SqlCommand("SELECT * FROM [dbo].[AuthorisingAccess] WHERE [username] = '" & txtUname.Text & "'", conn)
                Try
                    Dim dr1 As SqlDataReader = command1.ExecuteReader()
                    dr1.Read()

                    If dr1("StudentProfile") = "1" Then
                        frmHome.StudentProfpblink.Enabled = True
                        frmHome.pbstudentprof.Enabled = True
                        frmHome.LinkSProf.Enabled = True
                    Else
                        frmHome.StudentProfpblink.Enabled = False
                        frmHome.pbstudentprof.Enabled = False
                        frmHome.LinkSProf.Enabled = False
                    End If

                    If dr1("Courses") = "1" Then
                        frmHome.gpbManageCourses.Visible = True
                        frmHome.gpbSelectCourses.Visible = False
                        frmHome.dgvCorses.Visible = True
                        frmHome.pbCourses.Enabled = True
                        frmHome.llCourses.Enabled = True

                    Else
                        frmHome.dgvCorses.Visible = False
                        frmHome.gpbMagageCourseControls.Enabled = False

                    End If

                    If dr1("AddAssignment") = "1" Then
                        Lecturers.AssignmentToolStripMenuItem.Enabled = True
                        Lecturers.pbAssignment.Enabled = True
                        Lecturers.pbAssignLink.Enabled = True
                        Lecturers.gpbPostAssign.Visible = True
                        Lecturers.gpbViewAssign.Visible = False
                        Lecturers.btnViewAssigPannel.Visible = False
                        Lecturers.btnPostAssignPannel.Visible = False
                    Else
                        Lecturers.AssignmentToolStripMenuItem.Enabled = False
                        Lecturers.pbAssignment.Enabled = False
                        Lecturers.pbAssignLink.Enabled = False
                        Lecturers.btnViewAssigPannel.Visible = True
                        Lecturers.btnPostAssignPannel.Visible = True
                    End If


                    If dr1("GradeBook") = "1" Then
                        Lecturers.gbGradebook.Visible = True
                        Lecturers.GradeBookToolStripMenuItem.Enabled = True
                        Lecturers.pbgradebookLink.Enabled = True
                        Lecturers.pbgradebook.Enabled = True
                    Else
                        Lecturers.GradeBookToolStripMenuItem.Enabled = False
                        Lecturers.pbgradebookLink.Enabled = False
                        Lecturers.pbgradebook.Enabled = False

                    End If

                    If dr1("Library") = "1" Then
                        frmHome.LinkLib.Enabled = True
                    Else
                        frmHome.LinkLib.Enabled = False

                    End If

                    If dr1("MajorCourses") = "1" Then
                        addCourseAcces = "NO"
                        frmHome.gpbManageCourses.Visible = True
                        frmHome.gpbSelectCourses.Visible = False
                        frmHome.pbCourses.Enabled = True
                        frmHome.llCourses.Enabled = True
                        frmHome.gpbCourseMajor.Enabled = True
                        frmHome.btnViewMajors.Enabled = True
                        frmHome.btnBackcourses.Enabled = True
                    Else
                        frmHome.gpbCourseMajor.Enabled = False
                        frmHome.btnViewMajors.Enabled = False
                        frmHome.btnBackcourses.Enabled = False

                    End If


                    If dr1("CheckAssignment") = "1" Then
                        Lecturers.AssignmentToolStripMenuItem.Enabled = True
                        Lecturers.pbAssignment.Enabled = True
                        Lecturers.pbAssignLink.Enabled = True
                        Lecturers.gpbPostAssign.Visible = False
                        Lecturers.gpbViewAssign.Visible = True
                        Lecturers.btnViewAssigPannel.Visible = False
                        Lecturers.btnPostAssignPannel.Visible = False
                    Else
                        Lecturers.AssignmentToolStripMenuItem.Enabled = False
                        Lecturers.pbAssignment.Enabled = False
                        Lecturers.pbAssignLink.Enabled = False
                        Lecturers.btnViewAssigPannel.Visible = True
                        Lecturers.btnPostAssignPannel.Visible = True
                    End If


                    If dr1("Classes") = "1" Then
                        Lecturers.CLassesToolStripMenuItem.Enabled = True
                        Lecturers.pbClasses.Enabled = True
                        Lecturers.pbClassesLink.Enabled = True
                    Else
                        Lecturers.CLassesToolStripMenuItem.Enabled = False
                        Lecturers.pbClasses.Enabled = False
                        Lecturers.pbClassesLink.Enabled = False
                    End If

                    If dr1("TuitionSettings") = "1" Then
                        frmHome.pbSettingsTuit.Enabled = True
                        frmHome.lbTuition.Enabled = True
                    Else
                        frmHome.pbSettingsTuit.Enabled = False
                        frmHome.lbTuition.Enabled = False
                    End If


                    If dr1("Uploadgrades") = "1" Then
                        Lecturers.GradesManagementToolStripMenuItem.Enabled = True
                        Lecturers.pbGradesUploadLink.Enabled = True
                        Lecturers.pbUpploadGrades.Enabled = True
                    Else
                        Lecturers.GradesManagementToolStripMenuItem.Enabled = False
                        Lecturers.pbGradesUploadLink.Enabled = False
                        Lecturers.pbUpploadGrades.Enabled = False

                    End If

                    If dr1("PostAnnouncements") = "1" Then
                        Postannounce = "Yes"
                        Lecturers.AnnouncementsToolStripMenuItem.Enabled = True
                        Lecturers.pbAnnounce.Enabled = True
                        Lecturers.pbAnnounceLink.Enabled = True
                        Lecturers.gpbPostAnnounce.Visible = True
                    Else
                        'Lecturers.AnnouncementsToolStripMenuItem.Enabled = True
                        'Lecturers.pbAnnounce.Enabled = True
                        'Lecturers.pbAnnounceLink.Enabled = True
                        Lecturers.gpbPostAnnounce.Visible = False
                    End If

                    If dr1("Attendance") = "1" Then
                        Lecturers.AttendanceToolStripMenuItem.Enabled = True
                        Lecturers.pbAttend.Enabled = True
                        Lecturers.pbAttendLink.Enabled = True
                    Else
                        Lecturers.AttendanceToolStripMenuItem.Enabled = False
                        Lecturers.pbAttend.Enabled = False
                        Lecturers.pbAttendLink.Enabled = False
                    End If

                    If dr1("AddStudents") = "1" Then
                        StudentManager.gpbStudentMan.Enabled = True
                    Else
                        StudentManager.gpbStudentMan.Enabled = False
                    End If

                    If dr1("ExamNum") = "1" Then
                        StudentManager.gpbExam.Enabled = True
                    Else
                        StudentManager.gpbExam.Enabled = False
                    End If

                    If dr1("SystemBackup") = "1" Then
                        frmHome.SystemBackupToolStripMenuItem.Enabled = True
                    Else
                        frmHome.SystemBackupToolStripMenuItem.Enabled = False

                    End If

                    If dr1("AccStatement") = "1" Then
                        frmHome.btnAccState.Enabled = True
                        accstate = "YES"

                    Else
                        frmHome.btnAccState.Enabled = False

                    End If

                    If dr1("GeneralLedger") = "1" Then
                        frmHome.btnTrasactionLeger.Enabled = True
                    Else
                        frmHome.btnTrasactionLeger.Enabled = False

                    End If

                    If dr1("RecievePayment") = "1" Then
                        frmHome.btnPost.Enabled = True
                    Else
                        frmHome.btnPost.Enabled = False

                    End If

                    If dr1("DataView") = "1" Then
                        frmHome.pbReport.Enabled = True
                        frmHome.lbReports.Enabled = True
                    Else
                        frmHome.pbReport.Enabled = False
                        frmHome.lbReports.Enabled = False

                    End If


                    If dr1("UserAccess") = "1" Then
                        frmHome.pbUerManager.Enabled = True
                        frmHome.LinkUsermanager.Enabled = True
                    Else
                        frmHome.pbUerManager.Enabled = False
                        frmHome.LinkUsermanager.Enabled = False
                    End If

                    If dr("SetTimetable") = "1" Then
                        frmHome.gpbTimetable.Show()
                        frmHome.gpbtimetableControls.Show()
                        frmHome.btnSetTT.Show()
                        frmHome.btnViewTT.Show()
                    Else
                        frmHome.gpbTimetable.Show()
                        frmHome.gpbtimetableControls.Hide()
                        frmHome.btnSetTT.Hide()
                        frmHome.btnViewTT.Hide()
                    End If

                    If dr1("AddLecturer") = "1" Then
                        frmHome.PbAddLect.Enabled = True
                        frmHome.pbAddLectlink.Enabled = True
                    Else
                        frmHome.PbAddLect.Enabled = False
                        frmHome.pbAddLectlink.Enabled = False
                    End If

                Catch ex As SqlException
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                End Try
                frmHome.Show()
                Me.Hide()
            End If
            dr.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        conn.Close()

    End Sub

    ' Audit Trail
    Public Sub loginaudit()
        Try
            ipadd()
            Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
            Dim cmd As SqlCommand = New SqlCommand(theQuery, conn)
            cmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
            cmd.Parameters.AddWithValue("@Uname", txtUname.Text)
            cmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
            cmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
            cmd.Parameters.AddWithValue("@TransTyp", Me.Text)
            cmd.Parameters.AddWithValue("@TransVal", txtUname.Text + ", " + txtPword.Text)
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
    End Sub


End Class
