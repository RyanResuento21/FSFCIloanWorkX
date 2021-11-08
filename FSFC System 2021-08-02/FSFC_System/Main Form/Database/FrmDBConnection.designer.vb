<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDBConnection
    Inherits DevComponents.DotNetBar.Office2007Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.txtServerName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtDatabaseName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtUserName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtPassword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnAmazonDB = New DevComponents.DotNetBar.ButtonX()
        Me.btnOnPremiseDB = New DevComponents.DotNetBar.ButtonX()
        Me.btnTestDB = New DevComponents.DotNetBar.ButtonX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(32260, 32146)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(99, 61)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "ButtonX1"
        '
        'txtServerName
        '
        Me.txtServerName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtServerName.Border.Class = "TextBoxBorder"
        Me.txtServerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtServerName.FocusHighlightColor = System.Drawing.Color.LightBlue
        Me.txtServerName.FocusHighlightEnabled = True
        Me.txtServerName.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerName.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.txtServerName, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.Highlighter1.SetHighlightOnFocus(Me.txtServerName, True)
        Me.txtServerName.Location = New System.Drawing.Point(134, 16)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(120, 22)
        Me.txtServerName.TabIndex = 1
        Me.txtServerName.WatermarkText = "Server Name"
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtDatabaseName.Border.Class = "TextBoxBorder"
        Me.txtDatabaseName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDatabaseName.FocusHighlightColor = System.Drawing.Color.LightBlue
        Me.txtDatabaseName.FocusHighlightEnabled = True
        Me.txtDatabaseName.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabaseName.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.txtDatabaseName, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.Highlighter1.SetHighlightOnFocus(Me.txtDatabaseName, True)
        Me.txtDatabaseName.Location = New System.Drawing.Point(134, 45)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(120, 22)
        Me.txtDatabaseName.TabIndex = 2
        Me.txtDatabaseName.WatermarkText = "Database Name"
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUserName.Border.Class = "TextBoxBorder"
        Me.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUserName.FocusHighlightColor = System.Drawing.Color.LightBlue
        Me.txtUserName.FocusHighlightEnabled = True
        Me.txtUserName.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.txtUserName, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.Highlighter1.SetHighlightOnFocus(Me.txtUserName, True)
        Me.txtUserName.Location = New System.Drawing.Point(331, 16)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(120, 22)
        Me.txtUserName.TabIndex = 3
        Me.txtUserName.WatermarkText = "Username"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtPassword.Border.Class = "TextBoxBorder"
        Me.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPassword.FocusHighlightColor = System.Drawing.Color.LightBlue
        Me.txtPassword.FocusHighlightEnabled = True
        Me.txtPassword.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.Highlighter1.SetHighlightOnFocus(Me.txtPassword, True)
        Me.txtPassword.Location = New System.Drawing.Point(331, 45)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 22)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.WatermarkText = "Password"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(29, 19)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(81, 17)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Server Name:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(29, 48)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 17)
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Database Name:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(261, 19)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(64, 17)
        Me.LabelX3.TabIndex = 7
        Me.LabelX3.Text = "Username:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(261, 48)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(60, 17)
        Me.LabelX4.TabIndex = 8
        Me.LabelX4.Text = "Password:"
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOK.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(348, 78)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 33)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&Connect"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnAmazonDB)
        Me.GroupPanel1.Controls.Add(Me.btnOnPremiseDB)
        Me.GroupPanel1.Controls.Add(Me.btnTestDB)
        Me.GroupPanel1.Controls.Add(Me.txtUserName)
        Me.GroupPanel1.Controls.Add(Me.btnOK)
        Me.GroupPanel1.Controls.Add(Me.txtServerName)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.txtDatabaseName)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.txtPassword)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(510, 126)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 10
        '
        'btnAmazonDB
        '
        Me.btnAmazonDB.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAmazonDB.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAmazonDB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAmazonDB.Location = New System.Drawing.Point(242, 78)
        Me.btnAmazonDB.Name = "btnAmazonDB"
        Me.btnAmazonDB.Size = New System.Drawing.Size(100, 33)
        Me.btnAmazonDB.TabIndex = 11
        Me.btnAmazonDB.Text = "Production DB"
        '
        'btnOnPremiseDB
        '
        Me.btnOnPremiseDB.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOnPremiseDB.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOnPremiseDB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnPremiseDB.Location = New System.Drawing.Point(31, 78)
        Me.btnOnPremiseDB.Name = "btnOnPremiseDB"
        Me.btnOnPremiseDB.Size = New System.Drawing.Size(100, 33)
        Me.btnOnPremiseDB.TabIndex = 10
        Me.btnOnPremiseDB.Text = "On Premise DB"
        '
        'btnTestDB
        '
        Me.btnTestDB.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnTestDB.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnTestDB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestDB.Location = New System.Drawing.Point(137, 78)
        Me.btnTestDB.Name = "btnTestDB"
        Me.btnTestDB.Size = New System.Drawing.Size(100, 33)
        Me.btnTestDB.TabIndex = 9
        Me.btnTestDB.Text = "Test DB"
        '
        'FrmDBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(510, 126)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ButtonX1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDBConnection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Connection"
        Me.TopMost = True
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtServerName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDatabaseName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUserName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents btnAmazonDB As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOnPremiseDB As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnTestDB As DevComponents.DotNetBar.ButtonX
End Class
