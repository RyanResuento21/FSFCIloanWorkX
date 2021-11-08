<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelectBorrower
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
        Me.components = New System.ComponentModel.Container()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnProfile = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSelect = New DevComponents.DotNetBar.ButtonX()
        Me.CbxPrefix_B = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cbxSuffix_B = New SergeUtils.EasyCompletionComboBox()
        Me.TxtLastN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMiddleN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFirstN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxBorrower = New SergeUtils.EasyCompletionComboBox()
        Me.lblBorrower = New DevComponents.DotNetBar.LabelX()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cbxOtherBranch = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.PanelEx3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnProfile)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSelect)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 86)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(908, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 36
        '
        'btnProfile
        '
        Me.btnProfile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnProfile.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnProfile.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.Image = Global.FSFC_System.My.Resources.Resources.Person
        Me.btnProfile.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btnProfile.Location = New System.Drawing.Point(353, 4)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(107, 30)
        Me.btnProfile.TabIndex = 51
        Me.btnProfile.Text = "Profile"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(240, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "Close"
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.FSFC_System.My.Resources.Resources.Refresh
        Me.btnRefresh.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnRefresh.Location = New System.Drawing.Point(127, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(107, 30)
        Me.btnRefresh.TabIndex = 45
        Me.btnRefresh.Text = "Re&fresh"
        '
        'btnSelect
        '
        Me.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSelect.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Image = Global.FSFC_System.My.Resources.Resources.Selected
        Me.btnSelect.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btnSelect.Location = New System.Drawing.Point(14, 4)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(107, 30)
        Me.btnSelect.TabIndex = 40
        Me.btnSelect.Text = "&Select"
        '
        'CbxPrefix_B
        '
        Me.CbxPrefix_B.DisplayMember = "PREFIX"
        Me.CbxPrefix_B.Enabled = False
        Me.CbxPrefix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxPrefix_B.FormattingEnabled = True
        Me.CbxPrefix_B.Location = New System.Drawing.Point(145, 47)
        Me.CbxPrefix_B.Name = "CbxPrefix_B"
        Me.CbxPrefix_B.Size = New System.Drawing.Size(72, 25)
        Me.CbxPrefix_B.TabIndex = 135
        Me.CbxPrefix_B.ValueMember = "ID"
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
        Me.LabelX1.Location = New System.Drawing.Point(7, 49)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(133, 23)
        Me.LabelX1.TabIndex = 140
        Me.LabelX1.Text = "Full Name :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxSuffix_B
        '
        Me.cbxSuffix_B.DisplayMember = "Suffix"
        Me.cbxSuffix_B.Enabled = False
        Me.cbxSuffix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxSuffix_B.FormattingEnabled = True
        Me.cbxSuffix_B.Location = New System.Drawing.Point(841, 48)
        Me.cbxSuffix_B.Name = "cbxSuffix_B"
        Me.cbxSuffix_B.Size = New System.Drawing.Size(44, 25)
        Me.cbxSuffix_B.TabIndex = 139
        '
        'TxtLastN_B
        '
        '
        '
        '
        Me.TxtLastN_B.Border.Class = "TextBoxBorder"
        Me.TxtLastN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLastN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLastN_B.Enabled = False
        Me.TxtLastN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastN_B.Location = New System.Drawing.Point(635, 48)
        Me.TxtLastN_B.Name = "TxtLastN_B"
        Me.TxtLastN_B.PreventEnterBeep = True
        Me.TxtLastN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtLastN_B.TabIndex = 138
        Me.TxtLastN_B.WatermarkText = "Last Name"
        '
        'TxtMiddleN_B
        '
        '
        '
        '
        Me.TxtMiddleN_B.Border.Class = "TextBoxBorder"
        Me.TxtMiddleN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMiddleN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMiddleN_B.Enabled = False
        Me.TxtMiddleN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMiddleN_B.Location = New System.Drawing.Point(429, 48)
        Me.TxtMiddleN_B.Name = "TxtMiddleN_B"
        Me.TxtMiddleN_B.PreventEnterBeep = True
        Me.TxtMiddleN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtMiddleN_B.TabIndex = 137
        Me.TxtMiddleN_B.WatermarkText = "Middle Name"
        '
        'TxtFirstN_B
        '
        '
        '
        '
        Me.TxtFirstN_B.Border.Class = "TextBoxBorder"
        Me.TxtFirstN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFirstN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFirstN_B.Enabled = False
        Me.TxtFirstN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFirstN_B.Location = New System.Drawing.Point(223, 47)
        Me.TxtFirstN_B.Name = "TxtFirstN_B"
        Me.TxtFirstN_B.PreventEnterBeep = True
        Me.TxtFirstN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtFirstN_B.TabIndex = 136
        Me.TxtFirstN_B.WatermarkText = "First Name"
        '
        'cbxBorrower
        '
        Me.cbxBorrower.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBorrower.FormattingEnabled = True
        Me.cbxBorrower.Location = New System.Drawing.Point(145, 15)
        Me.cbxBorrower.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxBorrower.Name = "cbxBorrower"
        Me.cbxBorrower.Size = New System.Drawing.Size(651, 25)
        Me.cbxBorrower.TabIndex = 133
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblBorrower.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBorrower.Location = New System.Drawing.Point(7, 15)
        Me.lblBorrower.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Size = New System.Drawing.Size(132, 25)
        Me.lblBorrower.TabIndex = 134
        Me.lblBorrower.Text = "Name :"
        Me.lblBorrower.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Timer1
        '
        Me.Timer1.Interval = 300000
        '
        'cbxOtherBranch
        '
        Me.cbxOtherBranch.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxOtherBranch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxOtherBranch.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOtherBranch.Location = New System.Drawing.Point(802, 15)
        Me.cbxOtherBranch.Name = "cbxOtherBranch"
        Me.cbxOtherBranch.Size = New System.Drawing.Size(83, 23)
        Me.cbxOtherBranch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxOtherBranch.TabIndex = 134
        Me.cbxOtherBranch.Text = "All Branch"
        Me.cbxOtherBranch.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'FrmSelectBorrower
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 123)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxOtherBranch)
        Me.Controls.Add(Me.CbxPrefix_B)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.cbxSuffix_B)
        Me.Controls.Add(Me.TxtLastN_B)
        Me.Controls.Add(Me.TxtMiddleN_B)
        Me.Controls.Add(Me.TxtFirstN_B)
        Me.Controls.Add(Me.cbxBorrower)
        Me.Controls.Add(Me.lblBorrower)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSelectBorrower"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSelect As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CbxPrefix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxSuffix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents TxtLastN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMiddleN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFirstN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxBorrower As SergeUtils.EasyCompletionComboBox
    Public WithEvents lblBorrower As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnProfile As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cbxOtherBranch As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
