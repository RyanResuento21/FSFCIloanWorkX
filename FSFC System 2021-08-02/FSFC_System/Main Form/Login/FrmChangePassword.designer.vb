<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmChangePassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.txtOldP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txtUserType = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtNewP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtConfirmP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtUserName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.btnUpdate = New DevComponents.DotNetBar.ButtonX()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.btnWaive = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        '
        '
        '
        Me.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Broadway", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(341, 46)
        Me.lblTitle.TabIndex = 1320
        Me.lblTitle.Text = "CHANGE PASSWORD"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtOldP
        '
        Me.txtOldP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtOldP.Border.Class = "TextBoxBorder"
        Me.txtOldP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOldP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldP.ForeColor = System.Drawing.Color.Black
        Me.txtOldP.Location = New System.Drawing.Point(136, 95)
        Me.txtOldP.Name = "txtOldP"
        Me.txtOldP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldP.Size = New System.Drawing.Size(197, 21)
        Me.txtOldP.TabIndex = 3
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(12, 97)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(118, 17)
        Me.LabelX7.TabIndex = 1339
        Me.LabelX7.Text = "OLD PASSWORD:"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtUserType
        '
        Me.txtUserType.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUserType.Border.Class = "TextBoxBorder"
        Me.txtUserType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUserType.Enabled = False
        Me.txtUserType.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserType.ForeColor = System.Drawing.Color.Black
        Me.txtUserType.Location = New System.Drawing.Point(136, 70)
        Me.txtUserType.Name = "txtUserType"
        Me.txtUserType.Size = New System.Drawing.Size(197, 21)
        Me.txtUserType.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 72)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(118, 17)
        Me.LabelX1.TabIndex = 1341
        Me.LabelX1.Text = "USERTYPE:"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtNewP
        '
        Me.txtNewP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNewP.Border.Class = "TextBoxBorder"
        Me.txtNewP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNewP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewP.ForeColor = System.Drawing.Color.Black
        Me.txtNewP.Location = New System.Drawing.Point(136, 120)
        Me.txtNewP.Name = "txtNewP"
        Me.txtNewP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewP.Size = New System.Drawing.Size(197, 21)
        Me.txtNewP.TabIndex = 4
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 122)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(118, 17)
        Me.LabelX2.TabIndex = 1343
        Me.LabelX2.Text = "NEW PASSWORD:"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtConfirmP
        '
        Me.txtConfirmP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtConfirmP.Border.Class = "TextBoxBorder"
        Me.txtConfirmP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConfirmP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmP.ForeColor = System.Drawing.Color.Black
        Me.txtConfirmP.Location = New System.Drawing.Point(136, 145)
        Me.txtConfirmP.Name = "txtConfirmP"
        Me.txtConfirmP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmP.Size = New System.Drawing.Size(197, 21)
        Me.txtConfirmP.TabIndex = 5
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 147)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(118, 17)
        Me.LabelX3.TabIndex = 1345
        Me.LabelX3.Text = "CONFIRM PASSWORD:"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUserName.Border.Class = "TextBoxBorder"
        Me.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUserName.Enabled = False
        Me.txtUserName.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.ForeColor = System.Drawing.Color.Black
        Me.txtUserName.Location = New System.Drawing.Point(136, 45)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(197, 21)
        Me.txtUserName.TabIndex = 1
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 47)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(118, 17)
        Me.LabelX4.TabIndex = 1347
        Me.LabelX4.Text = "USERNAME:"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnUpdate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnUpdate.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnUpdate.Location = New System.Drawing.Point(0, 170)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(107, 30)
        Me.btnUpdate.TabIndex = 1348
        Me.btnUpdate.Text = "&Update"
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnClose.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(113, 170)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 30)
        Me.btnClose.TabIndex = 1349
        Me.btnClose.Text = "Close"
        '
        'btnWaive
        '
        Me.btnWaive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnWaive.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnWaive.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaive.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnWaive.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnWaive.Location = New System.Drawing.Point(226, 170)
        Me.btnWaive.Name = "btnWaive"
        Me.btnWaive.Size = New System.Drawing.Size(107, 30)
        Me.btnWaive.TabIndex = 1350
        Me.btnWaive.Text = "&Waive"
        Me.btnWaive.Visible = False
        '
        'FrmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(341, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnWaive)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txtConfirmP)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txtNewP)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txtUserType)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtOldP)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtOldP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUserType As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNewP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtConfirmP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUserName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnUpdate As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnWaive As DevComponents.DotNetBar.ButtonX
End Class
