Imports System.Data.SqlClient
Imports SIMS_Core.globalVariables
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Public Class ChangePwd
    Public uname As String
    Public pword As String
    Private Sub btnChangePwd_Click(sender As Object, e As EventArgs) Handles btnChangePwd.Click
        If txtCPConfirmPwd.Text = Nothing Then
            MsgBox("Please Confirm your Password!", MessageBoxIcon.Warning)
            txtCPConfirmPwd.Focus()
        ElseIf txtCPPword.Text = Nothing Then
            MsgBox("Please Enter your Password", MessageBoxIcon.Warning)
            txtCPPword.Focus()
        ElseIf txtCPUname.Text = Nothing Then
            MsgBox("Please enter your Username", MessageBoxIcon.Warning)
            txtCPUname.Focus()

        ElseIf txtOldPwd.Text = Nothing Then
            MsgBox("Please enter your Old Password", MessageBoxIcon.Warning)
            txtOldPwd.Focus()
        ElseIf txtOldPwd.Text = txtCPPword.Text Then
            MsgBox("Please Enter a different Password! ", MessageBoxIcon.Warning)
            txtCPPword.Clear()
            txtCPConfirmPwd.Clear()
            txtCPPword.Focus()
        ElseIf txtCPPword.Text <> txtCPConfirmPwd.Text Then
            MsgBox("Passwords Mismatch!", MessageBoxIcon.Warning)
            txtCPConfirmPwd.Clear()
            txtCPPword.Clear()
            txtCPPword.Focus()

        Else
            Try
                connection.Close()
                connection.Open()
                txtCPPword.Text = GenerateHash(txtCPPword.Text)
                Dim cmd As New SqlCommand("UPDATE dbo.users SET username = '" & txtCPUname.Text & "', password= '" & txtCPPword.Text & "',usertyp = '" & frmHome.lbusertype.Text & "' WHERE username = '" & Login.txtUname.Text & "'And  password= '" & Login.txtPword.Text & "'", connection)
                cmd.CommandType = CommandType.Text

                If (cmd.ExecuteNonQuery().Equals(1)) Then
                    MsgBox("Password Changed Successiful", MessageBoxIcon.Information)
                    connection.Close()
                    ' Audit Trail
                    Try
                        txtOldPwd.Text = GenerateHash(txtOldPwd.Text)
                        ipadd()
                        Dim theQuery2 As String = "INSERT INTO [dbo].[AuditTrail] ([DtTim],[username],[usertyp],[ipAdd],[TransactionTyp],[TransactionVal]) VALUES (@DtTim, @Uname, @Utyp, @ipAdd, @TransTyp, @TransVal)"
                        Dim cmd1 As SqlCommand = New SqlCommand(theQuery2, connection)
                        cmd1.Parameters.AddWithValue("@DtTim", Date.Now.ToString)
                        cmd1.Parameters.AddWithValue("@Uname", Login.txtUname.Text)
                        cmd1.Parameters.AddWithValue("@Utyp", frmHome.lbusertype.Text)
                        cmd1.Parameters.AddWithValue("@ipAdd", Ipaddress)
                        cmd1.Parameters.AddWithValue("@TransTyp", "Change Password")
                        cmd1.Parameters.AddWithValue("@TransVal", txtCPUname.Text + ", " + txtOldPwd.Text + ", " + txtCPPword.Text)
                        connection.Close()
                        connection.Open()
                        cmd1.ExecuteNonQuery().Equals(1)
                        connection.Close()

                    Catch ex As SqlException
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "SQL Error")
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    End Try
                    connection.Close()

                    frmHome.auditval = "" & txtCPUname.Text & ", " & txtOldPwd.Text & ""
                    txtCPConfirmPwd.Clear()
                    txtCPPword.Clear()
                    txtCPUname.Clear()
                    txtOldPwd.Clear()
                    txtCPUname.Enabled = True
                    Login.txtPword.Text = txtCPPword.Text
                    frmHome.btnLogout.PerformClick()

                Else
                    MsgBox("CHANGE PASSWORD FAILED !", MsgBoxStyle.Critical, MsgBoxStyle.DefaultButton1)
                End If
            Catch ex As Exception
                MsgBox("Error in Changing Password. Error is :" & ex.Message)
                connection.Close()
            End Try
        End If
    End Sub
    Dim MsgResult As Integer
    Private Sub LLCPCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LLCPCancel.LinkClicked
        If Not lbLoginPwd.Text = "Label3" Then
            MsgResult = MessageBox.Show("You will be Logged off from the System! Comfirm?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If MsgResult = Windows.Forms.DialogResult.Yes Then
                Login.Show()
                Login.txtUname.Clear()
                Login.txtPword.Clear()
                Login.txtUname.Focus()
                Me.Close()
                frmHome.Close()
                'Application.Exit()

            End If
        Else
            MsgResult = MessageBox.Show("You Have Not changed your Password! Close Window Comfirm?  ", "Students Information Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If MsgResult = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub


End Class