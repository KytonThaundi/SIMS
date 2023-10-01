Imports System.Data.SqlClient
Imports SIMS.The_MileLtd.globalVariables
Imports System.Configuration
Public Class StudentManager
    Dim Dtreader As SqlDataReader
    Dim gender As String = Nothing
    Private Sub btnAddStudent_Click(sender As Object, e As EventArgs) Handles btnAddStudent.Click
        Dim Studentcode As Integer
        If txtSMStudentID.Text = Nothing Then
            MsgBox("Please enter a Student ID!", MessageBoxIcon.Warning)
            txtSMStudentID.Focus()

        ElseIf txtSMFname.Text = Nothing Then
            MsgBox("Please enter a First Name!", MessageBoxIcon.Warning)
            txtSMFname.Focus()

        ElseIf txtSMSurname.Text = Nothing Then
            MsgBox("Please enter a Surname!", MessageBoxIcon.Warning)
            txtSMSurname.Focus()
        ElseIf cmbAccomodation.Text = Nothing Then
            MsgBox("Please select Accomodation Type!", MessageBoxIcon.Warning)
            cmbAccomodation.Focus()
        ElseIf cmbTOA.Text = Nothing Then
            MsgBox("Please Select Type of Admission!", "error", MessageBoxIcon.Warning)
        ElseIf RadioFemale.Checked = False And RadioMale.Checked = False Then
            MsgBox("Please select Gender!", MessageBoxIcon.Warning)
        Else
            Dim sid As String = txtSMStudentID.Text
            Dim pos As String = cmbSMProgOfStudy.SelectedValue
            Dim fn As String = txtSMFname.Text
            Dim sn As String = txtSMSurname.Text

            If RadioMale.Checked = True Then
                gender = "Male"
            ElseIf RadioFemale.Checked = True Then
                gender = "Female"

            End If
            Dim yrOfA As String = Today.Year
            Dim TOA As String = cmbTOA.Text
            Dim Accommodation As String = cmbAccomodation.Text
            connection.Close()
            connection.Open()
            Dim strSQL As String = "SELECT [StudentCode] FROM [dbo].Student"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count <= 0 Then
                Studentcode = 100
            Else
                For Each dr1 As DataRow In dt.Rows

                    Dim Stcode As Integer = Convert.ToInt64(dr1("StudentCode"))

                    Studentcode = Stcode + 1

                Next

                connection.Close()

                If Studentcode > 1100 Then

                    MessageBox.Show("You Have Reached The Maximum Number Of Students For This Version", "Students Information Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()

                Else
                    Try
                        connection.Close()
                        connection.Open()
                        Dim command As New SqlCommand("INSERT INTO dbo.Student (Student_Id,ProgramOfStudy,Fname,Surname,Gender,YOA,TOA,Accommodation,RegStatus,[StudentCode]) VALUES('" & sid & "','" & pos & "','" & fn & "','" & sn & "','" & gender & "','" & yrOfA & "','" & TOA & "','" & Accommodation & "',0,'" & Studentcode & "')", connection)
                        command.ExecuteNonQuery()
                        connection.Close()

                        ' Audit Trail
                        Try
                            ipadd()
                            Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                            Dim cmmd As SqlCommand = New SqlCommand(theQuery, connection)
                            cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                            cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                            cmmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                            cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                            cmmd.Parameters.AddWithValue("@TransTyp", "Add Student")
                            cmmd.Parameters.AddWithValue("@TransVal", txtSMStudentID.Text + ", " + gender + ", " + cmbSMProgOfStudy.Text + ", " + cmbTOA.Text)
                            connection.Close()
                            connection.Open()
                            cmmd.ExecuteNonQuery().Equals(1)
                            connection.Close()
                        Catch ex As Exception
                            MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                        End Try

                        UserManagement.txtUMusername.Text = txtSMStudentID.Text
                        Dim pwrd As String = "" & (pos + yrOfA.Substring(yrOfA.Length - 2) + "-" + fn).ToString & ""

                        UserManagement.txtUMPword.Text = pwrd
                        UserManagement.txtUMConfPword.Text = pwrd
                        UserManagement.Adduser()

                        Me.Hide()
                        txtSMStudentID.Clear()
                        txtSMFname.Clear()
                        txtSMSurname.Clear()
                        txtAccNum.Clear()
                        cmbTOA.Text = Nothing
                        cmbSMProgOfStudy.Text = Nothing
                        cmbAccomodation.Text = Nothing

                    Catch ex As Exception
                        MsgBox("Error in population the Database. Error is :" & ex.Message)
                        connection.Close()
                    End Try
                End If
            End If
        End If

    End Sub
    Private Sub StudentManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAddStudent.Visible = True
        btnSMSave.Visible = False
        txtAccNum.Clear()
        txtSMStudentID.Clear()
        txtSMFname.Clear()
        txtSMSurname.Clear()
        loadcmbxpid()
        Call dgvStudentsload()
        txtSMStudentID.ForeColor = Color.Black
        txtSMFname.ForeColor = Color.Black
        txtSMSurname.ForeColor = Color.Black
        cmbSMProgOfStudy.ForeColor = Color.Black
        cmbTOA.ForeColor = Color.Black
        cmbAccomodation.ForeColor = Color.Black
        Call Tuition_Management.loadcmbSMProgOfStudy()
        cmbxPID.Text = Nothing
        cmbSMProgOfStudy.Text = Nothing
    End Sub

    Private Sub btnDelStudent_Click(sender As Object, e As EventArgs) Handles btnDelStudent.Click
        If dgvStudents.RowCount <= 0 Then
            MsgBox("There are No Students in the System. Please Add First!", MsgBoxStyle.Critical)
            txtSMFname.Focus()
        Else
            Dim SID As String = Me.dgvStudents.SelectedRows(0).Cells(0).Value.ToString
            Dim pos As String = Me.dgvStudents.SelectedRows(0).Cells(1).Value.ToString
            Dim gnd As String = Me.dgvStudents.SelectedRows(0).Cells(4).Value.ToString
            Dim typOA As String = Me.dgvStudents.SelectedRows(0).Cells(5).Value.ToString
            connection.Open()
            Dim command As New SqlCommand("DELETE FROM dbo.Student WHERE Student_Id ='" & SID & "'", connection)

            command.CommandType = CommandType.Text

            If (command.ExecuteNonQuery().Equals(1)) Then
                MsgBox("Student Deleted")
                connection.Close()
                ' Audit Trail
                Try
                    ipadd()
                    Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                    Dim cmmd As SqlCommand = New SqlCommand(theQuery, connection)
                    cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                    cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                    cmmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                    cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                    cmmd.Parameters.AddWithValue("@TransTyp", "Delete Student")
                    cmmd.Parameters.AddWithValue("@TransVal", SID + ", " + gnd + ", " + pos + ", " + typOA)
                    connection.Close()
                    connection.Open()
                    cmmd.ExecuteNonQuery().Equals(1)
                    connection.Close()
                Catch ex As Exception
                    MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                End Try
                Call dgvStudentsload()
            End If
        End If
    End Sub

    Private Sub btnEditStudent_Click(sender As Object, e As EventArgs) Handles btnEditStudent.Click
        If dgvStudents.RowCount <= 0 Then
            MsgBox("There are No Students in the System. Please Add First!", MsgBoxStyle.Critical)
            txtSMFname.Focus()
        Else
            Dim sid As String = Me.dgvStudents.SelectedRows(0).Cells(0).Value.ToString
            Dim pos As String = Me.dgvStudents.SelectedRows(0).Cells(1).Value.ToString
            Dim fn As String = Me.dgvStudents.SelectedRows(0).Cells(2).Value.ToString
            Dim sn As String = Me.dgvStudents.SelectedRows(0).Cells(3).Value.ToString
            Dim toa As String = Me.dgvStudents.SelectedRows(0).Cells(4).Value.ToString
            'Dim acco As String = Me.dgvStudents.SelectedRows(0).Cells(5).Value.ToString
            RadioFemale.Checked = False
            RadioMale.Checked = False
            'cmbAccomodation.Text = acco
            cmbTOA.Text = toa
            txtSMStudentID.Text = sid
            txtSMFname.Text = fn
            txtSMSurname.Text = sn
            cmbSMProgOfStudy.Text = pos
            GroupBoxSM.Enabled = False
            btnAddStudent.Hide()
            btnSMSave.Show()
            txtSMStudentID.ForeColor = Color.Red
            txtSMFname.ForeColor = Color.Red
            txtSMSurname.ForeColor = Color.Red
            cmbSMProgOfStudy.ForeColor = Color.Red
            cmbAccomodation.ForeColor = Color.Red
            cmbTOA.ForeColor = Color.Red
            txtSMStudentID.Focus()
        End If
    End Sub

    Private Sub dgvStudentsload()
        Try
            connection.Open()
            Dim strSQL As String = "SELECT Student_Id AS [REGISTRATION NUMBER], ProgramOfStudy AS [PROGRAME OF STUDY], Fname AS [FIRST NAME], Surname AS [SURNAME],[Gender] AS [GENDER],[TOA] As [TYPE OF ADMISSION] FROM dbo.Student ORDER BY ProgramOfStudy ASC"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "Student")
            dgvStudents.DataSource = ds.Tables(0)
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        connection.Close()
    End Sub

    Private Sub generateExamID()

        Try
            connection.Close()
            connection.Open()
            Dim strSQL As String = "SELECT [Student_Id],[YOA] FROM [dbo].[Student] WHERE [ProgramOfStudy] = '" & cmbxPID.SelectedValue & "' AND [YOA] = '" & ((Date.Now.Year + 1) - NUDYrOStudy.Value) & "' ORDER BY [Student_Id] DESC"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim dt As New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                Dim count As Integer = 0
                count = count + 1
                Dim strDetail As String
                strDetail = row("Student_Id")
                Dim stclass As String = "" & cmbxPID.SelectedValue & "" & ((Date.Now.Year - Convert.ToDouble(row("YOA"))) + 1) & ""
                Dim examnum As String = "" & cmbxPID.SelectedValue & "" & ((Date.Now.Year - Convert.ToDouble(row("YOA"))) + 1) & "/" & count.ToString & ""   ' & row("YOA").Substring(row("YOA").Length - 2) & "/"
                connection.Close()

                Dim command As New SqlCommand("SELECT [ExamNum], [Student_id], [Class], [Semester] FROM [dbo].[Exam] WHERE [ExamNum] = '" & examnum & "' AND [Student_id] = '" & strDetail & "' AND [Semester] = '" & cmbxSemester.Text & "'", connection)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                reader.Read()
                If reader.HasRows Then
                    MsgBox("Exam Numbers Already Exist for this Class!", MessageBoxIcon.Warning)
                    reader.Close()
                    connection.Close()
                    Exit Sub
                Else
                    connection.Close()
                    connection.Open()
                    Dim cmd As New SqlCommand("INSERT INTO [dbo].[Exam] ([ExamNum], [Student_id], [Class], [Semester]) VALUES ('" & examnum & "','" & strDetail & "','" & stclass & "','" & cmbxSemester.Text & "')", connection)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery().Equals(1)
                    connection.Close()
                End If
                reader.Close()
                connection.Close()
            Next row
            MsgBox("Exam Numbers Generated Successfuly!", MessageBoxIcon.Warning)
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        connection.Close()
    End Sub

    Private Sub btnSMSave_Click(sender As Object, e As EventArgs) Handles btnSMSave.Click
        If txtSMStudentID.Text = Nothing Then
            MsgBox("Please enter a Student ID!", MessageBoxIcon.Warning)
            txtSMStudentID.Focus()

        ElseIf txtSMFname.Text = Nothing Then
            MsgBox("Please enter a First Name!", MessageBoxIcon.Warning)
            txtSMFname.Focus()

        ElseIf txtSMSurname.Text = Nothing Then
            MsgBox("Please enter a Surname!", MessageBoxIcon.Warning)
            txtSMSurname.Focus()

        ElseIf cmbAccomodation.Text = Nothing Then
            MsgBox("Please select Accomodation type!", MessageBoxIcon.Warning)
            cmbAccomodation.Focus()

        ElseIf RadioFemale.Checked = False And RadioMale.Checked = False Then
            MsgBox("Please select Gender!", MessageBoxIcon.Warning)
        Else
            If RadioMale.Checked = True Then
                gender = "Male"
            ElseIf RadioFemale.Checked = True Then
                gender = "Female"
            End If
            Try
                connection.Open()
                Dim cmd As New SqlCommand("UPDATE dbo.Student SET Student_Id = '" & txtSMStudentID.Text & "', ProgramOfStudy = '" & cmbSMProgOfStudy.SelectedValue & "',Fname ='" & txtSMFname.Text & "',Surname = '" & txtSMSurname.Text & "',[Accommodation] = '" & cmbAccomodation.Text & "',[TOA] = '" & cmbTOA.Text & "',Gender = '" & gender & "' WHERE Student_Id = '" & Me.dgvStudents.SelectedRows(0).Cells(0).Value.ToString & "'", connection)
                cmd.CommandType = CommandType.Text

                If (cmd.ExecuteNonQuery().Equals(1)) Then
                    MsgBox("Edit successiful")
                    connection.Close()
                    ' Audit Trail
                    Try
                        ipadd()
                        Dim theQuery As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                        Dim cmmd As SqlCommand = New SqlCommand(theQuery, connection)
                        cmmd.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                        cmmd.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                        cmmd.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                        cmmd.Parameters.AddWithValue("@ipAdd", Ipaddress)
                        cmmd.Parameters.AddWithValue("@TransTyp", "Edit Student")
                        cmmd.Parameters.AddWithValue("@TransVal", txtSMFname.Text + ", " + txtSMSurname.Text + ", " + gender + ", " + txtSMStudentID.Text + ", " + cmbSMProgOfStudy.SelectedValue + ", " + cmbTOA.Text + ", " + cmbAccomodation.Text)
                        connection.Close()
                        connection.Open()
                        cmmd.ExecuteNonQuery().Equals(1)
                        connection.Close()
                    Catch ex As Exception
                        MsgBox("Audit Trail Error! ", ex.Message, MessageBoxIcon.Warning)
                    End Try
                    txtSMStudentID.Clear()
                    txtSMFname.Clear()
                    txtSMSurname.Clear()
                    cmbTOA.Text = Nothing
                    cmbSMProgOfStudy.Text = Nothing
                    cmbAccomodation.Text = Nothing
                    Call dgvStudentsload()
                    GroupBoxSM.Enabled = True
                Else
                    MsgBox("EDIT FAILED", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                End If
            Catch ex As Exception
                MsgBox("Error in Editing User. Error is :" & ex.Message)
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub txtSearchStudent_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStudent.TextChanged
        Try
            connection.Open()
            Dim strSQL As String = "SELECT Student_Id AS [REGISTRATION NUMBER], ProgramOfStudy AS [PROGRAME OF STUDY], Fname AS [FIRST NAME], Surname AS [SURNAME],[TOA] As [TYPE OF ADMISSION],[Accommodation] AS [ACCOMMODATION] FROM dbo.Student WHERE  Student_Id like '" & txtSearchStudent.Text & "%' ORDER BY ProgramOfStudy ASC"
            Dim da As New SqlDataAdapter(strSQL, connection)
            Dim ds As New DataSet
            da.Fill(ds, "Student")
            dgvStudents.DataSource = ds.Tables(0)
            connection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Public Sub btnSMGetSID_Click(sender As Object, e As EventArgs)
        Dim number As String = Nothing
        Dim selector As String = Convert.ToString(cmbSMProgOfStudy.SelectedValue)
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT Student_Id, ProgramOfStudy, Fname ,Surname FROM dbo.Student WHERE ProgramOfStudy = '" & selector & "' ORDER BY Fname ASC", connection)
            Dim adp As New SqlDataAdapter(cmd)
            cmd.Connection.Open()
            Dim ds As New Data.DataSet
            Dim dt As New Data.DataTable
            adp.Fill(ds)
            dt = ds.Tables(0)
            Dim count As Integer = dt.Rows.Count
            number = (count + 1).ToString()
            cmd.Connection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Dim year As Date = Today.Date
        Dim yr As String = year.ToString("yy")
        txtSMStudentID.Text = (selector + "/" + yr + "/" + number).ToString
        txtAccNum.Text = (selector + yr + "NO" + number).ToString
        Call openAcc()
    End Sub

    Private Sub openAcc()
        Try
            connection.Open()
            Dim command As New SqlCommand("INSERT INTO dbo.Accounts(AccNo, Student_Id, AccBal) VALUES ('" & txtAccNum.Text & "','" & txtSMStudentID.Text & "','0')", connection)
            command.ExecuteNonQuery()
            connection.Close()
        Catch ex As Exception
            MsgBox("Error in population the Database. Error is :" & ex.Message)
            connection.Close()
        End Try

    End Sub

    Private Sub btnSMClose_Click(sender As Object, e As EventArgs) Handles btnSMClose.Click
        msgResult = MessageBox.Show(" " & frmHome.lb_loggedas.Text & " !!  You are Closing current window ! Comfirm ?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgResult = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
    Public Sub loadcmbxpid()
        connection.Close()
        connection.Open()
        Dim da3 As New SqlDataAdapter("SELECT Prog_id, ProgName FROM dbo.Programme", connection)
        Dim ds3 As New DataSet
        da3.Fill(ds3, "prog")
        cmbxPID.DataSource = ds3.Tables(0)
        cmbxPID.ValueMember = "Prog_id"
        cmbxPID.DisplayMember = "ProgName"
        connection.Close()

    End Sub

    Private Sub btnGenerateExamNums_Click(sender As Object, e As EventArgs) Handles btnGenerateExamNums.Click
        If cmbxPID.SelectedValue = Nothing Then
            MsgBox("Please Select a Programme Of Study", MessageBoxIcon.Warning)
            cmbxPID.Focus()
        ElseIf cmbxSemester.Text = Nothing Then
            MsgBox("Please Select a Semester", MessageBoxIcon.Warning)
            cmbxSemester.Focus()
        ElseIf NUDYrOStudy.Value = Nothing Or NUDYrOStudy.Value <= 0 Then
            MsgBox("Please Select a Year Of Study", MessageBoxIcon.Warning)
            NUDYrOStudy.Focus()
        Else
            generateExamID()
        End If
    End Sub
End Class