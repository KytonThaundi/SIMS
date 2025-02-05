
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports SIMS_Core.globalVariables
Imports System.Configuration
Imports System.Text
Public Class UserManagement
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim connStr As String = ConfigurationManager.ConnectionStrings("MyDBConnection").ConnectionString
    Dim conn As New SqlConnection(connStr)


    Dim access1 As Integer
    Dim access2 As Integer
    Dim access3 As Integer
    Dim access4 As Integer
    Dim access5 As Integer
    Dim access6 As Integer
    Dim access7 As Integer
    Dim access8 As Integer
    Dim access9 As Integer
    Dim access10 As Integer
    Dim access11 As Integer
    Dim access12 As Integer
    Dim access13 As Integer
    Dim access14 As Integer
    Dim access15 As Integer
    Dim access16 As Integer
    Dim access17 As Integer
    Dim access18 As Integer
    Dim access19 As Integer
    Dim access20 As Integer
    Dim access21 As Integer
    Dim access22 As Integer

    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNewUser.Show()
        btnUMView.Hide()
        cmbxtyp.Enabled = True
        cmbxtyp.Text = Nothing
        gpbrights.Enabled = False
        cmbxtyp.Items.Clear()
        cmbxtyp.Items.Add("Student")
        cmbxtyp.Items.Add("Admin")
        cmbxtyp.Items.Add("Accountant")
        cmbxtyp.Items.Add("Lecturer")
        cmbxtyp.Items.Add("Registrar")
        btnCustome.Visible = True
        btnBack.Visible = False
        gpbAccessRights.Visible = False
        btnDelUser.Enabled = True
        gpbviewRights.Visible = True
        btnCustome.Visible = True
        btnNewUser.BringToFront()
        btnBack.Visible = False
        btnEditUser.Enabled = True
        conn.Close()
        If Application.OpenForms().OfType(Of StudentManager).Any Then
            Call dgvuserLoad()
            GroupBoxUM.Enabled = True
            'txtUMConfPword.Clear()
            'txtUMPword.Clear()
            txtUMusername.ForeColor = Color.Black
            txtUMConfPword.ForeColor = Color.Black
            txtUMPword.ForeColor = Color.Black
            txtUMusername.Focus()
            btnUMSave.Hide()
            btnAddUser.Show()
            lbUT.Visible = False
            cmbxtyp.Visible = False


        Else
            cmbxtyp.Items.Clear()
            cmbxtyp.Items.Add("Student")
            cmbxtyp.Items.Add("Admin")
            cmbxtyp.Items.Add("Accountant")
            cmbxtyp.Items.Add("Lecturer")
            cmbxtyp.Items.Add("Registrar")
            lbUT.Visible = True
            cmbxtyp.Visible = True
            gpbrights.Enabled = False
            Call dgvuserLoad()
            GroupBoxUM.Enabled = True
            txtUMusername.Clear()
            txtUMConfPword.Clear()
            txtUMPword.Clear()
            txtUMusername.ForeColor = Color.Black
            txtUMConfPword.ForeColor = Color.Black
            txtUMPword.ForeColor = Color.Black
            txtUMusername.Focus()
            btnUMSave.Hide()
            btnAddUser.Show()
            StudentManager.Close()

        End If

    End Sub

    Public Sub Adduser()
        If txtUMPword.Text = "" Or txtUMPword.Text Like " " Then
            MsgBox("Please Enter A Password!")
            txtUMPword.Focus()

        ElseIf txtUMConfPword.Text = "" Or txtUMConfPword.Text Like " " Then
            MsgBox("Please Confirm your Password!")
            txtUMConfPword.Focus()

        ElseIf txtUMPword.Text <> txtUMConfPword.Text Then
            MsgBox("Passwords Mismatch!")
            txtUMConfPword.Clear()
            txtUMPword.Clear()
            txtUMPword.Focus()
        Else


            Try
                txtUMPword.Text = GenerateHash(txtUMPword.Text)
                txtUMConfPword.Text = GenerateHash(txtUMConfPword.Text)
            Dim dtp As String = Date.Now.Date

                Try
                    Dim reader As SqlDataReader = Nothing
                    conn.Open()
                    Dim command As New SqlCommand("SELECT username FROM dbSIMS.dbo.users WHERE username='" & txtUMusername.Text & "'",  conn) ' and password='" & txtUMPword.Text & "'"
                    reader = command.ExecuteReader()
                    If (reader.Read() = True) Then
                        'reader.Read()
                        'If reader.HasRows Then
                        MessageBox.Show("Unsuccessful!! User Name Already Exist.", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtUMusername.Clear()
                        txtUMusername.Focus()
                    Else
                        conn.Close()
                        conn.Open()
                        Dim cmd As New SqlCommand("insert into dbo.users values('" & txtUMusername.Text & "','" & txtUMPword.Text & "','" & cmbxtyp.SelectedItem & "','" & dtp & "')",  conn)
                        cmd.CommandType = CommandType.Text

                        If (cmd.ExecuteNonQuery().Equals(1)) Then
                            conn.Close()
                            ' Audit Trail
                            Try
                                If Application.OpenForms().OfType(Of StudentManager).Any Then
                                    cmbxtyp.SelectedItem = "Student"
                                End If
                                ipadd()
                                Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                                Dim cmmd As SqlCommand = New SqlCommand(theQuery,  conn)
                                cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                                cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                                cmmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                                cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                                cmmd.Parameters.AddWithValue("@TransTyp", "Add User")
                                cmmd.Parameters.AddWithValue("@TransVal", txtUMusername.Text + ", " + txtUMPword.Text + "," + cmbxtyp.SelectedItem) '"Username: " + txtUname.Text + ", Password: " + txtPword.Text
                                conn.Close()
                                conn.Open()
                                cmmd.ExecuteNonQuery().Equals(1)
                                conn.Close()
                            Catch ex As Exception
                                MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                            End Try



                            If Application.OpenForms().OfType(Of StudentManager).Any Then
                                conn.Open()
                                Dim comd As New SqlCommand("UPDATE [dbo].[users] SET [usertyp] = 'Student' WHERE [username] = '" & txtUMusername.Text & "'",  conn)
                                comd.CommandType = CommandType.Text

                                If (comd.ExecuteNonQuery().Equals(1)) Then
                                    MsgBox("Student Added Successfully")
                                    conn.Close()
                                    txtUMusername.Enabled = True
                                    txtUMConfPword.Enabled = True
                                    txtUMPword.Enabled = True
                                    txtUMusername.Clear()
                                    txtUMPword.Clear()
                                    txtUMConfPword.Clear()
                                    Call dgvuserLoad()
                                End If

                                frmHome.btnFinControl.PerformClick()
                                'Home.cmbxAccNo.SelectedValue = txtUMusername.Text
                                'Home.cmbxAccNo.Enabled = False
                                Me.Hide()
                                'Else
                            ElseIf Application.OpenForms().OfType(Of frmHome).Any And frmHome.insert = "Yes" Then
                                MessageBox.Show("Lecturer Added Successfully!" & vbCrLf & "Username:  " & frmHome.lectid & "" & vbCrLf & "Password:  " & frmHome.LecDefaultPwd & "", "Student Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                txtUMusername.Enabled = True
                                txtUMConfPword.Enabled = True
                                txtUMPword.Enabled = True
                                txtUMusername.Clear()
                                txtUMPword.Clear()
                                txtUMConfPword.Clear()
                                frmHome.insert = Nothing
                                Call dgvuserLoad()




                            Else

                                If cmbxtyp.Text = "Custom" Then

                                    If StudentProfile.Checked = True Then
                                        access1 = 1
                                    Else
                                        access1 = 0
                                    End If

                                    If Courses.Checked = True Then
                                        access2 = 1
                                    Else
                                        access2 = 0

                                    End If

                                    If AddAssignmnet.Checked = True Then
                                        access3 = 1
                                    Else
                                        access3 = 0
                                    End If

                                    If GradeBook.Checked = True Then
                                        access4 = 1
                                    Else
                                        access4 = 0

                                    End If

                                    If Library.Checked = True Then
                                        access5 = 1
                                    Else
                                        access5 = 0

                                    End If

                                    If MajorCourses.Checked = True Then
                                        access6 = 1
                                    Else
                                        access6 = 0

                                    End If


                                    If CheckAssignment.Checked = True Then
                                        access7 = 1
                                    Else
                                        access7 = 0

                                    End If


                                    If Classes.Checked = True Then
                                        access8 = 1
                                    Else
                                        access8 = 0
                                    End If

                                    If TuitionSettings.Checked = True Then
                                        access9 = 1
                                    Else
                                        access9 = 0
                                    End If

                                    If Uploadgrades.Checked = True Then
                                        access10 = 1
                                    Else
                                        access10 = 0

                                    End If
                                    If PostAnnouncements.Checked = True Then
                                        access11 = 1
                                    Else
                                        access11 = 0
                                    End If

                                    If Attendance.Checked = True Then
                                        access12 = 1
                                    Else
                                        access12 = 0
                                    End If

                                    If AddStudent.Checked = True Then
                                        access13 = 1
                                    Else
                                        access13 = 0
                                    End If

                                    If ExamNum.Checked = True Then
                                        access14 = 1
                                    Else
                                        access14 = 0
                                    End If

                                    If SystemBackup.Checked = True Then
                                        access15 = 1
                                    Else
                                        access15 = 0

                                    End If

                                    If AccStatement.Checked = True Then
                                        access16 = 1
                                    Else
                                        access16 = 0

                                    End If

                                    If GeneralLedger.Checked = True Then
                                        access17 = 1
                                    Else
                                        access17 = 0

                                    End If

                                    If ReceivePayment.Checked = True Then
                                        access18 = 1
                                    Else
                                        access18 = 0

                                    End If

                                    If DataView.Checked = True Then
                                        access19 = 1
                                    Else
                                        access19 = 0

                                    End If


                                    If UserAccess.Checked = True Then
                                        access20 = 1
                                    Else
                                        access20 = 0

                                    End If

                                    If setTimetable.Checked = True Then
                                        access21 = 1
                                    Else
                                        access21 = 0
                                    End If

                                    If AddLecturer.Checked = True Then
                                        access22 = 1
                                    Else
                                        access22 = 0

                                    End If


                                    conn.Close()
                                        conn.Open()
                                    Dim comd As New SqlCommand("INSERT INTO [dbo].[AuthorisingAccess]([username], [StudentProfile], [Courses], [AddAssignment], [GradeBook], [Library], [MajorCourses], [CheckAssignment], [Classes], [TuitionSettings],[Uploadgrades], [PostAnnouncements], [Attendance], [AddStudents], [ExamNum], [SystemBackup], [AccStatement], [GeneralLedger], [RecievePayment], [DataView], [UserAccess], [SetTimetable], [AddLecturer])VALUES('" & txtUMusername.Text & "','" & access1 & "','" & access2 & "','" & access3 & "','" & access4 & "','" & access5 & "','" & access6 & "','" & access7 & "','" & access8 & "','" & access9 & "','" & access10 & "','" & access11 & "','" & access12 & "','" & access13 & "','" & access14 & "','" & access15 & "','" & access16 & "','" & access17 & "','" & access18 & "','" & access19 & "','" & access20 & "','" & access21 & "','" & access22 & "')",  conn)
                                    comd.CommandType = CommandType.Text

                                        comd.ExecuteNonQuery().Equals(1)

                                End If
                                    MsgBox("User Added Successfully", MessageBoxIcon.Information)
                                gpbviewRights.Visible = True
                                btnDelUser.Enabled = True
                                txtUMusername.Enabled = True
                                txtUMConfPword.Enabled = True
                                txtUMPword.Enabled = True
                                txtUMusername.Clear()
                                txtUMPword.Clear()
                                txtUMConfPword.Clear()
                                Call dgvuserLoad()
                            End If
                        Else
                            MsgBox("USER NOT Added", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error in Reading From the Database. Error is :" & ex.Message)
                    conn.Close()
                End Try
            Catch ex As Exception
                MsgBox("Error in population the Database. Error is :" & ex.Message)
                conn.Close()
            End Try
        End If


    End Sub
    Private Sub btnDelUser_Click(sender As Object, e As EventArgs) Handles btnDelUser.Click
        If dgvusers.RowCount <= 0 Then
            MsgBox("There are No User in the System. Please Add First!", MsgBoxStyle.Critical)
            txtUMusername.Focus()
        Else
            conn.Close()
            msgResult = MessageBox.Show("The User " + Me.dgvusers.SelectedRows(0).Cells(0).Value.ToString + " Will be removed from the System !Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If msgResult = Windows.Forms.DialogResult.Yes Then

                Dim username As String = Me.dgvusers.SelectedRows(0).Cells(0).Value.ToString
                Dim Utyp As String = Me.dgvusers.SelectedRows(0).Cells(1).Value.ToString
                Dim dte As String = Me.dgvusers.SelectedRows(0).Cells(2).Value.ToString
                conn.Close()
                conn.Open()
                Dim command As New SqlCommand("DELETE FROM dbo.users WHERE username ='" & username & "' And usertyp='" & Utyp & "' And DateEntered ='" & dte & "'",  conn)

                command.CommandType = CommandType.Text
                If Utyp = "Custom" Then
                    Dim command1 As New SqlCommand("DELETE FROM [dbo].[AuthorisingAccess] WHERE [username] ='" & username & "'",  conn)
                    command1.CommandType = CommandType.Text
                    command1.ExecuteNonQuery()
                End If
                If (command.ExecuteNonQuery().Equals(1)) Then
                        MsgBox("User Deleted", MessageBoxIcon.Information)
                        conn.Close()
                        ' Audit Trail
                        Try
                            ipadd()
                            Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                            Dim cmmd As SqlCommand = New SqlCommand(theQuery,  conn)
                            cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                            cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                            cmmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                            cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                            cmmd.Parameters.AddWithValue("@TransTyp", "Delete User")
                            cmmd.Parameters.AddWithValue("@TransVal", dte + "," + username + ", " + Utyp)
                            conn.Close()
                            conn.Open()
                            cmmd.ExecuteNonQuery().Equals(1)
                            conn.Close()
                        Catch ex As Exception
                            MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                        End Try
                        Call dgvuserLoad()
                        conn.Close()

                    End If
                Else
                    MsgBox("NO User Deleted", MessageBoxIcon.Information)
            End If



        End If
    End Sub
    Private Sub txtSearchUser_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUser.TextChanged
        Try
            conn.Close()
            conn.Open()
            Dim strSQL As String = "SELECT username AS USERNAME, usertyp AS [ACCESS LEVEL], [DateEntered] AS [DATE OF ENTRY] FROM dbo.users WHERE username like '" & txtSearchUser.Text & "%' AND username <> 'Admin' ORDER BY [DateEntered] ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL,  conn)
            Dim ds As New DataSet
            da.Fill(ds, "Users")
            dgvusers.DataSource = ds.Tables(0)
            conn.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub dgvuserLoad()
        Try
            conn.Close()
            conn.Open()
            Dim strSQL As String = "SELECT [username] AS [USERNAME], [usertyp] AS [ACCESS LEVEL],[DateEntered] AS [DATE OF ENTRY] FROM dbo.users WHERE [username] <> 'Admin' ORDER BY [DateEntered] ASC"
            conn.Close()
            Dim da As New SqlDataAdapter(strSQL,  conn)
            Dim ds As New DataSet
            da.Fill(ds, "Users")
            dgvusers.DataSource = ds.Tables(0)
            conn.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        cmbxtyp.Items.Clear()
        cmbxtyp.Items.Add("Student")
        cmbxtyp.Items.Add("Admin")
        cmbxtyp.Items.Add("Accountant")
        cmbxtyp.Items.Add("Lecturer")
        cmbxtyp.Items.Add("Registrar")
        cmbxtyp.Visible = True
        If dgvusers.RowCount <= 0 Then
            MsgBox("There are No Users in the System. Please Add First!", MsgBoxStyle.Critical)
            txtUMusername.Focus()
        Else
            Dim username As String = Me.dgvusers.SelectedRows(0).Cells(0).Value.ToString
            Dim password As String = Me.dgvusers.SelectedRows(0).Cells(1).Value.ToString
            txtUMusername.Text = username
            txtUMPword.Text = password
            txtUMConfPword.Text = password
            'GroupBoxUM.Enabled = False
            gpbviewRights.Visible = False
            btnDelUser.Enabled = False
            gpbAccessRights.Visible = True
            btnAddUser.Hide()
            btnUMSave.Show()
            txtUMusername.ForeColor = Color.Red
            txtUMConfPword.ForeColor = Color.Red
            txtUMPword.ForeColor = Color.Red
            txtUMusername.Focus()
        End If
    End Sub

    Private Sub btnUMSave_Click(sender As Object, e As EventArgs) Handles btnUMSave.Click

        If txtUMPword.Text = Nothing Then
            MsgBox("Please Enter A Password!", MessageBoxIcon.Warning)
            txtUMPword.Focus()

        ElseIf txtUMConfPword.Text = Nothing Then
            MsgBox("Please Confirm your Password!", MessageBoxIcon.Warning)
            txtUMConfPword.Focus()

        ElseIf txtUMPword.Text <> txtUMConfPword.Text Then
            MsgBox("Passwords Mismatch!", MessageBoxIcon.Warning)
            txtUMConfPword.Clear()
            txtUMPword.Clear()
            txtUMPword.Focus()
        Else
            conn.Close()


            Try
                txtUMPword.Text = GenerateHash(txtUMPword.Text)
                txtUMConfPword.Text = GenerateHash(txtUMConfPword.Text)
                conn.Open()
                Dim cmd As New SqlCommand("UPDATE dbo.users SET username = '" & txtUMusername.Text & "', password= '" & txtUMPword.Text & "',usertyp = '" & cmbxtyp.SelectedItem & "' WHERE username = '" & Me.dgvusers.SelectedRows(0).Cells(0).Value.ToString & "'And  usertyp = '" & Me.dgvusers.SelectedRows(0).Cells(1).Value.ToString & "'",  conn)
                cmd.CommandType = CommandType.Text

                If (cmd.ExecuteNonQuery().Equals(1)) Then
                    MsgBox("Edit successful")
                    conn.Close()

                    If cmbxtyp.SelectedItem = "Custom" Then
                        conn.Open()
                        Dim comd As New SqlCommand("UPDATE [dbo].[AuthorisingAccess] SET [username] = '" & txtUMusername.Text & "',[StudentProfile] = '" & access1 & "',[Courses] ='" & access2 & "',[AddAssignment] = '" & access3 & "' ,[GradeBook] ='" & access4 & "',[Library] = '" & access5 & "' ,[MajorCourses] = '" & access6 & "' ,[CheckAssignment] = '" & access7 & "' ,[Classes] = '" & access8 & "' ,[TuitionSettings] = '" & access9 & "' ,[UploadGrades] = '" & access10 & "',[PostAnnouncements] = '" & access11 & "',[Attendance] = '" & access12 & "',[AddStudents] = '" & access13 & "',[ExamNum] = '" & access14 & "' ,[SystemBackup] = '" & access15 & "',[AccStatement] = '" & access16 & "',[GeneralLedger] = '" & access17 & "' ,[RecievePayment] = '" & access18 & "' ,[DataView] = '" & access19 & "' ,[UserAccess] = '" & access20 & "',[AddLecturer] = '" & access22 & "' WHERE [username] = '" & Me.dgvusers.SelectedRows(0).Cells(0).Value.ToString & "'",  conn)
                        comd.CommandType = CommandType.Text

                        comd.ExecuteNonQuery().Equals(1)
                        conn.Close()
                    End If
                    ' Audit Trail
                    Try
                            ipadd()
                            Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                            Dim cmmd As SqlCommand = New SqlCommand(theQuery,  conn)
                            cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                            cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                            cmmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                            cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                            cmmd.Parameters.AddWithValue("@TransTyp", "Edit User")
                            cmmd.Parameters.AddWithValue("@TransVal", txtUMusername.Text + ", " + txtUMPword.Text + "," + cmbxtyp.SelectedItem) '"Username: " + txtUname.Text + ", Password: " + txtPword.Text
                            conn.Close()
                            conn.Open()
                            cmmd.ExecuteNonQuery().Equals(1)
                            conn.Close()
                        Catch ex As Exception
                            MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                        End Try
                        txtUMusername.Clear()
                        txtUMPword.Clear()
                        txtUMConfPword.Clear()
                        Call dgvuserLoad()
                        GroupBoxUM.Enabled = True
                    Else
                        MsgBox("EDIT FAILED", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                End If
            Catch ex As Exception
                MsgBox("Error in Editing User. Error is :" & ex.Message)
                conn.Close()
            End Try
        End If
    End Sub



    Private Sub SelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll.CheckedChanged

        If SelectAll.Checked = True Then

            StudentProfile.Checked = True
            Courses.Checked = True
            AddAssignmnet.Checked = True
            GradeBook.Checked = True
            Library.Checked = True
            MajorCourses.Checked = True
            CheckAssignment.Checked = True
            Classes.Checked = True
            TuitionSettings.Checked = True
            Library.Checked = True
            Uploadgrades.Checked = True
            PostAnnouncements.Checked = True
            Attendance.Checked = True
            AddStudent.Checked = True
            ExamNum.Checked = True
            SystemBackup.Checked = True
            AccStatement.Checked = True
            ReceivePayment.Checked = True
            GeneralLedger.Checked = True
            DataView.Checked = True
            UserAccess.Checked = True
            setTimetable.Checked = True
            AddLecturer.Checked = True








        Else
            StudentProfile.Checked = False
            Courses.Checked = False
            AddAssignmnet.Checked = False
            GradeBook.Checked = False
            Library.Checked = False
            MajorCourses.Checked = False
            CheckAssignment.Checked = False
            Classes.Checked = False
            TuitionSettings.Checked = False
            Library.Checked = False
            Uploadgrades.Checked = False
            PostAnnouncements.Checked = False
            Attendance.Checked = False
            AddStudent.Checked = False
            ExamNum.Checked = False
            SystemBackup.Checked = False
            AccStatement.Checked = False
            ReceivePayment.Checked = False
            GeneralLedger.Checked = False
            DataView.Checked = False
            UserAccess.Checked = False
            setTimetable.Checked = False
            AddLecturer.Checked = False

        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resert()
    End Sub

    Sub resert()
        StudentProfile.Checked = False
        Courses.Checked = False
        AddAssignmnet.Checked = False
        GradeBook.Checked = False
        Library.Checked = False
        MajorCourses.Checked = False
        CheckAssignment.Checked = False
        Classes.Checked = False
        TuitionSettings.Checked = False
        Library.Checked = False
        Uploadgrades.Checked = False
        PostAnnouncements.Checked = False
        Attendance.Checked = False
        AddStudent.Checked = False
        ExamNum.Checked = False
        SystemBackup.Checked = False
        AccStatement.Checked = False
        ReceivePayment.Checked = False
        GeneralLedger.Checked = False
        DataView.Checked = False
        UserAccess.Checked = False
        setTimetable.Checked = False
        AddLecturer.Checked = False
        SelectAll.Checked = False


    End Sub

    Private Sub btnCustome_Click(sender As Object, e As EventArgs) Handles btnCustome.Click
        cmbxtyp.Items.Clear()
        cmbxtyp.Items.Add("Student")
        cmbxtyp.Items.Add("Admin")
        cmbxtyp.Items.Add("Accountant")
        cmbxtyp.Items.Add("Lecturer")
        cmbxtyp.Items.Add("Registrar")
        cmbxtyp.Items.Add("Custom")
        cmbxtyp.SelectedItem = "Custom"
        cmbxtyp.Enabled = False
        gpbrights.Enabled = True
        btnCustome.Visible = False
        btnBack.Visible = True
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        cmbxtyp.Items.Clear()
        cmbxtyp.Text = Nothing
        cmbxtyp.Items.Add("Student")
        cmbxtyp.Items.Add("Admin")
        cmbxtyp.Items.Add("Accountant")
        cmbxtyp.Items.Add("Lecturer")
        cmbxtyp.Items.Add("Registrar")
        gpbrights.Enabled = False
        cmbxtyp.Enabled = True
        btnBack.Visible = False
        btnCustome.Visible = True
    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        gpbviewRights.Visible = False
        btnEditUser.Enabled = False
        btnDelUser.Enabled = False
        gpbAccessRights.Visible = True
        btnNewUser.Visible = False
        btnUMView.Visible = True
        btnBack.PerformClick()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        msgResult = MessageBox.Show("Closing window, Comfirm?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgResult = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnAddUser_Click_1(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Adduser()
    End Sub

    Private Sub btnUMView_Click(sender As Object, e As EventArgs) Handles btnUMView.Click
        btnEditUser.Enabled = True
        btnDelUser.Enabled = True
        gpbviewRights.Visible = True
        gpbAccessRights.Visible = False
        btnUMView.Visible = False
        btnNewUser.Visible = True
    End Sub


    'Public Function IsFormOpen(ByVal frm As Form) As Boolean
    '    If Application.OpenForms.OfType(Of Form).Contains(frm) Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function


End Class