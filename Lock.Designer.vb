<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lock))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPword = New System.Windows.Forms.TextBox()
        Me.pbLock = New System.Windows.Forms.PictureBox()
        Me.btnUnlock = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.pbLock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(19, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Password"
        '
        'txtPword
        '
        Me.txtPword.BackColor = System.Drawing.Color.White
        Me.txtPword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPword.Location = New System.Drawing.Point(78, 120)
        Me.txtPword.Name = "txtPword"
        Me.txtPword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPword.Size = New System.Drawing.Size(156, 20)
        Me.txtPword.TabIndex = 8
        '
        'pbLock
        '
        Me.pbLock.BackColor = System.Drawing.Color.Transparent
        Me.pbLock.Image = CType(resources.GetObject("pbLock.Image"), System.Drawing.Image)
        Me.pbLock.Location = New System.Drawing.Point(83, 0)
        Me.pbLock.Name = "pbLock"
        Me.pbLock.Size = New System.Drawing.Size(113, 106)
        Me.pbLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLock.TabIndex = 10
        Me.pbLock.TabStop = False
        '
        'btnUnlock
        '
        Me.btnUnlock.Location = New System.Drawing.Point(78, 146)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(75, 23)
        Me.btnUnlock.TabIndex = 11
        Me.btnUnlock.Text = "&Unlock"
        Me.btnUnlock.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(159, 146)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "&EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Lock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SIMS.The_MileLtd.My.Resources.Resources.login1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(268, 174)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnUnlock)
        Me.Controls.Add(Me.pbLock)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Lock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lock"
        CType(Me.pbLock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPword As System.Windows.Forms.TextBox
    Friend WithEvents pbLock As System.Windows.Forms.PictureBox
    Friend WithEvents btnUnlock As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
