
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports SIMS.The_MileLtd.globalVariables
Imports System.IO




Public Class SystemBackup
    Dim check As String = Nothing
    Private Sub llbBrowse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbBrowse.LinkClicked
        'SaveFileDialog1.FileName = "dbSIMS"
        'SaveFileDialog1.ShowDialog()
        'lblDestination.Text = SaveFileDialog1.FileName
        check = "custom"
        btnSave.PerformClick()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Dim dateandtime As String
    Private Sub SystemBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateandtime = Now
        dateandtime = Format(Now, "dd.MM.yyyy_h.mm.ss ")
        lblDateAndTime.Hide()
        Me.lblDestination.Text = "C:\Users\MSSQL$SQLEXPRESS\Downloads\SIMS Backup"
        check = Nothing
        Me.lblName.Text = "SIMS"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If check = "custom" Then
                connection.Close()
                connection.Open()
                SaveFileDialog1.FileName = "dbSIMS_Backup_" + dateandtime + "_SIMS.BAK'"
                SaveFileDialog1.ShowDialog()
                Timer1.Enabled = True
                backupProgressBar.Visible = True
                Dim s As String
                s = SaveFileDialog1.FileName
                Dim cmd As New SqlCommand("BACKUP DATABASE dbSIMS TO DISK='" + s)
                cmd.CommandType = CommandType.Text
                cmd.Connection = connection
                cmd.ExecuteNonQuery()

                connection.Close()
            Else
                lblDestination.ReadOnly = True
                connection.Close()
                connection.Open()
                Timer1.Enabled = True
                backupProgressBar.Visible = True
                Dim cmd As New SqlCommand("BACKUP DATABASE dbSIMS TO DISK='" + lblDestination.Text + "\dbSIMS_Backup_" + dateandtime + "_SIMS.BAK'")
                cmd.CommandType = CommandType.Text
                cmd.Connection = connection
                cmd.ExecuteNonQuery()
                connection.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & "", "SIMS Management Information System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If backupProgressBar.Value = 100 Then
            Timer1.Enabled = False
            backupProgressBar.Visible = False
            MessageBox.Show("Backup Succeeded ", "SIMS Management Information System", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
        Else
            backupProgressBar.Value = backupProgressBar.Value + 5
        End If
    End Sub
End Class