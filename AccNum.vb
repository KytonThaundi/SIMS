Imports SIMS_Core.globalVariables
Imports MySql.Data.MySqlClient
Public Class AccNum
    Dim connection = New MySqlConnection(My.Settings.ConString)
    Private Sub AccNum_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub LoadAccNo()

        connection.Open()
        Dim da1 As New MySqlDataAdapter("SELECT AccNo, (SELECT [Fname] +' '+[Surname] FROM [dbo].[Student] WHERE [Student_Id] = [dbo].[Accounts].[Student_Id]) AS [Name] FROM dbo.Accounts ORDER BY AccNo ASC", connection)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "ACC")
        cmbxAccNoAccNum.DataSource = ds1.Tables(0)
        cmbxAccNoAccNum.DisplayMember = "AccNo"
        cmbxAccNoAccNum.ValueMember = "AccNo"
        connection.Close()
    End Sub

    Private Sub btnAccNumOk_Click(sender As Object, e As EventArgs) Handles btnAccNumOk.Click
        frmHome.acc = cmbxAccNoAccNum.SelectedValue
        Call frmHome.loadgdvAccState()
        connection.Close()
        frmHome.grpbxFinance.Show()
        frmHome.grpbxFinance.BringToFront()
        Me.Hide()
    End Sub

    Private Sub CheckAccNum_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAccNum.CheckedChanged
        If CheckAccNum.Checked = True Then
            StName.Checked = False
            cmbxAccNoAccNum.DataSource = Nothing
            LoadAccNo()
            cmbxAccNoAccNum.Text = Nothing
        Else
            cmbxAccNoAccNum.DataSource = Nothing
        End If
    End Sub

    Private Sub StName_CheckedChanged(sender As Object, e As EventArgs) Handles StName.CheckedChanged
        If StName.Checked = True Then
            CheckAccNum.Checked = False
            cmbxAccNoAccNum.DataSource = Nothing
            loadStudentName()
            cmbxAccNoAccNum.Text = Nothing
        Else
            cmbxAccNoAccNum.DataSource = Nothing
        End If
    End Sub

    Sub loadStudentName()

        connection.Open()
        'Dim ds1 As New DataSet
        Dim da1 As New MySqlDataAdapter("SELECT AccNo, (SELECT [Fname] +' '+[Surname] FROM [dbo].[Student] WHERE [Student_Id] = [dbo].[Accounts].[Student_Id]) AS [Name] FROM dbo.Accounts ORDER BY AccNo ASC", connection)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "Name")
        cmbxAccNoAccNum.DataSource = ds1.Tables(0)
        cmbxAccNoAccNum.DisplayMember = "Name"
        cmbxAccNoAccNum.ValueMember = "AccNo"
        connection.Close()

    End Sub

End Class