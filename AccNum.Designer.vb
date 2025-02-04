<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccNum
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccNum))
        Me.cmbxAccNoAccNum = New System.Windows.Forms.ComboBox()
        Me.btnAccNumOk = New System.Windows.Forms.Button()
        Me.btnAccNumCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StName = New System.Windows.Forms.CheckBox()
        Me.CheckAccNum = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmbxAccNoAccNum
        '
        Me.cmbxAccNoAccNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbxAccNoAccNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbxAccNoAccNum.FormattingEnabled = True
        Me.cmbxAccNoAccNum.Location = New System.Drawing.Point(330, 116)
        Me.cmbxAccNoAccNum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbxAccNoAccNum.Name = "cmbxAccNoAccNum"
        Me.cmbxAccNoAccNum.Size = New System.Drawing.Size(589, 53)
        Me.cmbxAccNoAccNum.TabIndex = 0
        '
        'btnAccNumOk
        '
        Me.btnAccNumOk.BackgroundImage = CType(resources.GetObject("btnAccNumOk.BackgroundImage"), System.Drawing.Image)
        Me.btnAccNumOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAccNumOk.Location = New System.Drawing.Point(330, 245)
        Me.btnAccNumOk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAccNumOk.Name = "btnAccNumOk"
        Me.btnAccNumOk.Size = New System.Drawing.Size(87, 52)
        Me.btnAccNumOk.TabIndex = 1
        Me.btnAccNumOk.Text = "&OK"
        Me.btnAccNumOk.UseVisualStyleBackColor = True
        '
        'btnAccNumCancel
        '
        Me.btnAccNumCancel.BackgroundImage = CType(resources.GetObject("btnAccNumCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnAccNumCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAccNumCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAccNumCancel.Location = New System.Drawing.Point(774, 245)
        Me.btnAccNumCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAccNumCancel.Name = "btnAccNumCancel"
        Me.btnAccNumCancel.Size = New System.Drawing.Size(145, 52)
        Me.btnAccNumCancel.TabIndex = 2
        Me.btnAccNumCancel.Text = "&Cancel"
        Me.btnAccNumCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 45)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select a Student By:  "
        '
        'StName
        '
        Me.StName.AutoSize = True
        Me.StName.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.StName.Location = New System.Drawing.Point(330, 39)
        Me.StName.Name = "StName"
        Me.StName.Size = New System.Drawing.Size(267, 49)
        Me.StName.TabIndex = 4
        Me.StName.Text = "Student Name"
        Me.StName.UseVisualStyleBackColor = True
        '
        'CheckAccNum
        '
        Me.CheckAccNum.AutoSize = True
        Me.CheckAccNum.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.CheckAccNum.Location = New System.Drawing.Point(614, 39)
        Me.CheckAccNum.Name = "CheckAccNum"
        Me.CheckAccNum.Size = New System.Drawing.Size(305, 49)
        Me.CheckAccNum.TabIndex = 5
        Me.CheckAccNum.Text = "Account Number"
        Me.CheckAccNum.UseVisualStyleBackColor = True
        '
        'AccNum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(18.0!, 45.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.CancelButton = Me.btnAccNumCancel
        Me.ClientSize = New System.Drawing.Size(932, 338)
        Me.Controls.Add(Me.CheckAccNum)
        Me.Controls.Add(Me.StName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAccNumCancel)
        Me.Controls.Add(Me.btnAccNumOk)
        Me.Controls.Add(Me.cmbxAccNoAccNum)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccNum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Getting Student Account Number"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbxAccNoAccNum As ComboBox
    Friend WithEvents btnAccNumOk As Button
    Friend WithEvents btnAccNumCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents StName As CheckBox
    Friend WithEvents CheckAccNum As CheckBox
End Class
