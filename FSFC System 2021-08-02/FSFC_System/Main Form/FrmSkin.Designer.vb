<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSkin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSkin))
        Me.cbxSkin = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.btnApply = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX82 = New DevComponents.DotNetBar.LabelX()
        Me.dFSize = New DevComponents.Editors.DoubleInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dFSizeGrid = New DevComponents.Editors.DoubleInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.cpb1 = New DevComponents.DotNetBar.ColorPickerButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.cpb2 = New DevComponents.DotNetBar.ColorPickerButton()
        Me.cbxFont = New System.Windows.Forms.ComboBox()
        CType(Me.dFSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dFSizeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxSkin
        '
        Me.cbxSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSkin.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSkin.FormattingEnabled = True
        Me.cbxSkin.Items.AddRange(New Object() {"DevExpress Style", "DevExpress Dark Style", "VS2010", "Seven Classic", "Office 2010 Blue", "Office 2010 Black", "Office 2010 Silver", "Office 2013", "Office 2013 Dark Gray", "Office 2013 Light Gray", "Visual Studio 2013 Blue", "Visual Studio 2013 Light", "Visual Studio 2013 Dark", "Coffee", "Liquid Sky", "London Liquid Sky", "Glass Oceans", "Stardust", "Xmas 2008 Blue", "Valentine", "McSkin", "Summer 2008", "Pumpkin", "Dark Side", "Springtime", "Foggy", "High Contrast", "Seven", "Sharp", "Sharp Plus", "The Asphalt World", "Whiteprint", "Caramel", "Money Twins", "Lilian", "iMaginary", "Black", "Office 2007 Blue", "Office 2007 Black", "Office 2007 Silver", "Office 2007 Green", "Office 2007 Pink", "Blue", "Darkroom", "Blueprint", "Metropolis Dark", "Metropolis"})
        Me.cbxSkin.Location = New System.Drawing.Point(138, 164)
        Me.cbxSkin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxSkin.Name = "cbxSkin"
        Me.cbxSkin.Size = New System.Drawing.Size(304, 25)
        Me.cbxSkin.TabIndex = 30
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(561, 164)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 40
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(448, 164)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 35
        Me.btnSave.Text = "Set"
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnClear.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Image = Global.FSFC_System.My.Resources.Resources.Delete
        Me.btnClear.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnClear.Location = New System.Drawing.Point(251, 194)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(107, 30)
        Me.btnClear.TabIndex = 50
        Me.btnClear.Text = "Clear from everyone"
        '
        'btnApply
        '
        Me.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnApply.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnApply.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnApply.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnApply.Location = New System.Drawing.Point(138, 194)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(107, 30)
        Me.btnApply.TabIndex = 45
        Me.btnApply.Text = "Apply to everyone"
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(12, 164)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(120, 23)
        Me.LabelX17.TabIndex = 1426
        Me.LabelX17.Text = "Skin :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(120, 23)
        Me.LabelX1.TabIndex = 1428
        Me.LabelX1.Text = "Font :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX82
        '
        Me.LabelX82.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX82.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX82.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX82.Location = New System.Drawing.Point(12, 44)
        Me.LabelX82.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX82.Name = "LabelX82"
        Me.LabelX82.Size = New System.Drawing.Size(120, 23)
        Me.LabelX82.TabIndex = 1429
        Me.LabelX82.Text = "Font Size :"
        Me.LabelX82.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dFSize
        '
        '
        '
        '
        Me.dFSize.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dFSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dFSize.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dFSize.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dFSize.ForeColor = System.Drawing.Color.Black
        Me.dFSize.Increment = 1.0R
        Me.dFSize.Location = New System.Drawing.Point(138, 44)
        Me.dFSize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dFSize.MaxValue = 14.0R
        Me.dFSize.MinValue = 5.0R
        Me.dFSize.Name = "dFSize"
        Me.dFSize.ShowUpDown = True
        Me.dFSize.Size = New System.Drawing.Size(74, 23)
        Me.dFSize.TabIndex = 10
        Me.dFSize.Value = 8.5R
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(12, 75)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(120, 23)
        Me.LabelX2.TabIndex = 1431
        Me.LabelX2.Text = "Font Size (Grid) :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dFSizeGrid
        '
        '
        '
        '
        Me.dFSizeGrid.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dFSizeGrid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dFSizeGrid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dFSizeGrid.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dFSizeGrid.ForeColor = System.Drawing.Color.Black
        Me.dFSizeGrid.Increment = 1.0R
        Me.dFSizeGrid.Location = New System.Drawing.Point(138, 75)
        Me.dFSizeGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dFSizeGrid.MaxValue = 14.0R
        Me.dFSizeGrid.MinValue = 5.0R
        Me.dFSizeGrid.Name = "dFSizeGrid"
        Me.dFSizeGrid.ShowUpDown = True
        Me.dFSizeGrid.Size = New System.Drawing.Size(74, 23)
        Me.dFSizeGrid.TabIndex = 20
        Me.dFSizeGrid.Value = 8.5R
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(218, 44)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(40, 23)
        Me.LabelX3.TabIndex = 1433
        Me.LabelX3.Text = "pt"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(218, 75)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(40, 23)
        Me.LabelX4.TabIndex = 1434
        Me.LabelX4.Text = "pt"
        '
        'cpb1
        '
        Me.cpb1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cpb1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cpb1.Image = CType(resources.GetObject("cpb1.Image"), System.Drawing.Image)
        Me.cpb1.Location = New System.Drawing.Point(138, 105)
        Me.cpb1.Name = "cpb1"
        Me.cpb1.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.cpb1.Size = New System.Drawing.Size(74, 23)
        Me.cpb1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cpb1.TabIndex = 1435
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(12, 105)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(120, 23)
        Me.LabelX5.TabIndex = 1436
        Me.LabelX5.Text = "Official Color 1 :"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(12, 134)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(120, 23)
        Me.LabelX6.TabIndex = 1438
        Me.LabelX6.Text = "Official Color 2 :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cpb2
        '
        Me.cpb2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cpb2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cpb2.Image = CType(resources.GetObject("cpb2.Image"), System.Drawing.Image)
        Me.cpb2.Location = New System.Drawing.Point(138, 134)
        Me.cpb2.Name = "cpb2"
        Me.cpb2.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.cpb2.Size = New System.Drawing.Size(74, 23)
        Me.cpb2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cpb2.TabIndex = 25
        '
        'cbxFont
        '
        Me.cbxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFont.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxFont.FormattingEnabled = True
        Me.cbxFont.Items.AddRange(New Object() {"DevExpress Style", "DevExpress Dark Style", "VS2010", "Seven Classic", "Office 2010 Blue", "Office 2010 Black", "Office 2010 Silver", "Office 2013", "Office 2013 Dark Gray", "Office 2013 Light Gray", "Visual Studio 2013 Blue", "Visual Studio 2013 Light", "Visual Studio 2013 Dark", "Coffee", "Liquid Sky", "London Liquid Sky", "Glass Oceans", "Stardust", "Xmas 2008 Blue", "Valentine", "McSkin", "Summer 2008", "Pumpkin", "Dark Side", "Springtime", "Foggy", "High Contrast", "Seven", "Sharp", "Sharp Plus", "The Asphalt World", "Whiteprint", "Caramel", "Money Twins", "Lilian", "iMaginary", "Black", "Office 2007 Blue", "Office 2007 Black", "Office 2007 Silver", "Office 2007 Green", "Office 2007 Pink", "Blue", "Darkroom", "Blueprint", "Metropolis Dark", "Metropolis"})
        Me.cbxFont.Location = New System.Drawing.Point(138, 10)
        Me.cbxFont.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxFont.Name = "cbxFont"
        Me.cbxFont.Size = New System.Drawing.Size(530, 25)
        Me.cbxFont.TabIndex = 1439
        '
        'FrmSkin
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 236)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxFont)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.cpb2)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.cpb1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.dFSizeGrid)
        Me.Controls.Add(Me.LabelX82)
        Me.Controls.Add(Me.dFSize)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbxSkin)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSkin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dFSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dFSizeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbxSkin As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnApply As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX82 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dFSize As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dFSizeGrid As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cpb1 As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cpb2 As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents cbxFont As System.Windows.Forms.ComboBox
End Class
