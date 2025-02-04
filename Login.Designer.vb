<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents txtUname As System.Windows.Forms.TextBox
    Friend WithEvents txtPword As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.txtUname = New System.Windows.Forms.TextBox()
        Me.txtPword = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LLCancel = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'txtUname
        '
        Me.txtUname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtUname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtUname.BackColor = System.Drawing.Color.White
        Me.txtUname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUname.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUname.Location = New System.Drawing.Point(200, 148)
        Me.txtUname.Name = "txtUname"
        Me.txtUname.Size = New System.Drawing.Size(197, 25)
        Me.txtUname.TabIndex = 1
        '
        'txtPword
        '
        Me.txtPword.BackColor = System.Drawing.Color.White
        Me.txtPword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPword.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPword.Location = New System.Drawing.Point(200, 206)
        Me.txtPword.Name = "txtPword"
        Me.txtPword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPword.Size = New System.Drawing.Size(197, 25)
        Me.txtPword.TabIndex = 3
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.Color.White
        Me.OK.BackgroundImage = CType(resources.GetObject("OK.BackgroundImage"), System.Drawing.Image)
        Me.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OK.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.Location = New System.Drawing.Point(209, 252)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(169, 27)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&Login"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(197, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(197, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Password"
        '
        'LLCancel
        '
        Me.LLCancel.AutoSize = True
        Me.LLCancel.BackColor = System.Drawing.Color.Transparent
        Me.LLCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LLCancel.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LLCancel.Location = New System.Drawing.Point(269, 309)
        Me.LLCancel.Name = "LLCancel"
        Me.LLCancel.Size = New System.Drawing.Size(53, 20)
        Me.LLCancel.TabIndex = 8
        Me.LLCancel.TabStop = True
        Me.LLCancel.Text = "Cancel"
        '
        'Login
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.BackgroundImage = Global.SIMS.The_MileLtd.My.Resources.Resources.login
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(605, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.LLCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPword)
        Me.Controls.Add(Me.txtUname)
        Me.Controls.Add(Me.OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LLCancel As System.Windows.Forms.LinkLabel
End Class
