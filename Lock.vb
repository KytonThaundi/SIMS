Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports SIMS.The_MileLtd.globalVariables
Imports System.Configuration
Imports System.Text
Public Class Lock

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        frmHome.Close()
        Me.Close()
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        If txtPword.Text = Nothing Then
            MsgBox("Please Enter Your Password!", MsgBoxStyle.Critical)
        Else
            txtPword.Text = GenerateHash(txtPword.Text)
            If txtPword.Text = Login.txtPword.Text Then
                Me.Hide()
            Else
                MsgBox("Invalid Password!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub Lock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPword.Clear()
    End Sub
End Class