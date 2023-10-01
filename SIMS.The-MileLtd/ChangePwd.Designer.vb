<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePwd))
        Me.lbconfirm = New System.Windows.Forms.Label()
        Me.txtCPConfirmPwd = New System.Windows.Forms.TextBox()
        Me.LLCPCancel = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCPPword = New System.Windows.Forms.TextBox()
        Me.txtCPUname = New System.Windows.Forms.TextBox()
        Me.btnChangePwd = New System.Windows.Forms.Button()
        Me.lbLoginPwd = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOldPwd = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbconfirm
        '
        Me.lbconfirm.AutoSize = True
        Me.lbconfirm.BackColor = System.Drawing.Color.Transparent
        Me.lbconfirm.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbconfirm.ForeColor = System.Drawing.Color.White
        Me.lbconfirm.Location = New System.Drawing.Point(194, 224)
        Me.lbconfirm.Name = "lbconfirm"
        Me.lbconfirm.Size = New System.Drawing.Size(104, 15)
        Me.lbconfirm.TabIndex = 19
        Me.lbconfirm.Text = "Confirm Password"
        '
        'txtCPConfirmPwd
        '
        Me.txtCPConfirmPwd.BackColor = System.Drawing.Color.White
        Me.txtCPConfirmPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCPConfirmPwd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCPConfirmPwd.Location = New System.Drawing.Point(196, 240)
        Me.txtCPConfirmPwd.Name = "txtCPConfirmPwd"
        Me.txtCPConfirmPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCPConfirmPwd.Size = New System.Drawing.Size(197, 23)
        Me.txtCPConfirmPwd.TabIndex = 18
        '
        'LLCPCancel
        '
        Me.LLCPCancel.AutoSize = True
        Me.LLCPCancel.BackColor = System.Drawing.Color.Transparent
        Me.LLCPCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLCPCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LLCPCancel.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LLCPCancel.Location = New System.Drawing.Point(272, 312)
        Me.LLCPCancel.Name = "LLCPCancel"
        Me.LLCPCancel.Size = New System.Drawing.Size(42, 15)
        Me.LLCPCancel.TabIndex = 17
        Me.LLCPCancel.TabStop = True
        Me.LLCPCancel.Text = "Cancel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(194, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "New Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(209, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Username"
        '
        'txtCPPword
        '
        Me.txtCPPword.BackColor = System.Drawing.Color.White
        Me.txtCPPword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCPPword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCPPword.Location = New System.Drawing.Point(196, 194)
        Me.txtCPPword.Name = "txtCPPword"
        Me.txtCPPword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCPPword.Size = New System.Drawing.Size(197, 23)
        Me.txtCPPword.TabIndex = 13
        '
        'txtCPUname
        '
        Me.txtCPUname.BackColor = System.Drawing.Color.White
        Me.txtCPUname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCPUname.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCPUname.Location = New System.Drawing.Point(207, 105)
        Me.txtCPUname.Name = "txtCPUname"
        Me.txtCPUname.Size = New System.Drawing.Size(174, 23)
        Me.txtCPUname.TabIndex = 12
        '
        'btnChangePwd
        '
        Me.btnChangePwd.BackColor = System.Drawing.Color.White
        Me.btnChangePwd.BackgroundImage = CType(resources.GetObject("btnChangePwd.BackgroundImage"), System.Drawing.Image)
        Me.btnChangePwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnChangePwd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePwd.Location = New System.Drawing.Point(212, 276)
        Me.btnChangePwd.Name = "btnChangePwd"
        Me.btnChangePwd.Size = New System.Drawing.Size(169, 25)
        Me.btnChangePwd.TabIndex = 20
        Me.btnChangePwd.Text = "&Change Password"
        Me.btnChangePwd.UseVisualStyleBackColor = False
        '
        'lbLoginPwd
        '
        Me.lbLoginPwd.AutoSize = True
        Me.lbLoginPwd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLoginPwd.Location = New System.Drawing.Point(201, 196)
        Me.lbLoginPwd.Name = "lbLoginPwd"
        Me.lbLoginPwd.Size = New System.Drawing.Size(41, 15)
        Me.lbLoginPwd.TabIndex = 21
        Me.lbLoginPwd.Text = "Label3"
        Me.lbLoginPwd.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(193, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Old Password"
        '
        'txtOldPwd
        '
        Me.txtOldPwd.BackColor = System.Drawing.Color.White
        Me.txtOldPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldPwd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPwd.Location = New System.Drawing.Point(196, 150)
        Me.txtOldPwd.Name = "txtOldPwd"
        Me.txtOldPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPwd.Size = New System.Drawing.Size(197, 23)
        Me.txtOldPwd.TabIndex = 22
        '
        'ChangePwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(605, 394)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOldPwd)
        Me.Controls.Add(Me.lbconfirm)
        Me.Controls.Add(Me.txtCPConfirmPwd)
        Me.Controls.Add(Me.LLCPCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCPUname)
        Me.Controls.Add(Me.btnChangePwd)
        Me.Controls.Add(Me.txtCPPword)
        Me.Controls.Add(Me.lbLoginPwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChangePwd"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ChangePwd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbconfirm As Label
    Friend WithEvents txtCPConfirmPwd As TextBox
    Friend WithEvents LLCPCancel As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCPPword As TextBox
    Friend WithEvents txtCPUname As TextBox
    Friend WithEvents btnChangePwd As Button
    Friend WithEvents lbLoginPwd As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtOldPwd As TextBox
End Class
