<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCASignatories
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CbxPrefix_S1 = New SergeUtils.EasyCompletionComboBox()
        Me.cbxSuffix_S1 = New SergeUtils.EasyCompletionComboBox()
        Me.TxtLastN_S1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMiddleN_S1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFirstN_S1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CbxPrefix_S2 = New SergeUtils.EasyCompletionComboBox()
        Me.cbxSuffix_S2 = New SergeUtils.EasyCompletionComboBox()
        Me.TxtLastN_S2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMiddleN_S2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFirstN_S2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(708, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 13
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(6, 1)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.PictureEdit1.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.Appearance.Options.UseFont = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(263, 64)
        Me.PictureEdit1.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(324, 4)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(354, 58)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "CURRENT ACCOUNT SIGNATORIES"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'CbxPrefix_S1
        '
        Me.CbxPrefix_S1.DisplayMember = "PREFIX"
        Me.CbxPrefix_S1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxPrefix_S1.FormattingEnabled = True
        Me.CbxPrefix_S1.Location = New System.Drawing.Point(131, 75)
        Me.CbxPrefix_S1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxPrefix_S1.MaxLength = 15
        Me.CbxPrefix_S1.Name = "CbxPrefix_S1"
        Me.CbxPrefix_S1.Size = New System.Drawing.Size(83, 25)
        Me.CbxPrefix_S1.TabIndex = 5
        Me.CbxPrefix_S1.ValueMember = "ID"
        '
        'cbxSuffix_S1
        '
        Me.cbxSuffix_S1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxSuffix_S1.FormattingEnabled = True
        Me.cbxSuffix_S1.Location = New System.Drawing.Point(646, 75)
        Me.cbxSuffix_S1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cbxSuffix_S1.MaxLength = 10
        Me.cbxSuffix_S1.Name = "cbxSuffix_S1"
        Me.cbxSuffix_S1.Size = New System.Drawing.Size(48, 25)
        Me.cbxSuffix_S1.TabIndex = 25
        '
        'TxtLastN_S1
        '
        '
        '
        '
        Me.TxtLastN_S1.Border.Class = "TextBoxBorder"
        Me.TxtLastN_S1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLastN_S1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLastN_S1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastN_S1.Location = New System.Drawing.Point(506, 75)
        Me.TxtLastN_S1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtLastN_S1.MaxLength = 35
        Me.TxtLastN_S1.Name = "TxtLastN_S1"
        Me.TxtLastN_S1.PreventEnterBeep = True
        Me.TxtLastN_S1.Size = New System.Drawing.Size(133, 23)
        Me.TxtLastN_S1.TabIndex = 20
        Me.TxtLastN_S1.WatermarkText = "Last Name"
        '
        'TxtMiddleN_S1
        '
        '
        '
        '
        Me.TxtMiddleN_S1.Border.Class = "TextBoxBorder"
        Me.TxtMiddleN_S1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMiddleN_S1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMiddleN_S1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMiddleN_S1.Location = New System.Drawing.Point(366, 75)
        Me.TxtMiddleN_S1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtMiddleN_S1.MaxLength = 35
        Me.TxtMiddleN_S1.Name = "TxtMiddleN_S1"
        Me.TxtMiddleN_S1.PreventEnterBeep = True
        Me.TxtMiddleN_S1.Size = New System.Drawing.Size(133, 23)
        Me.TxtMiddleN_S1.TabIndex = 15
        Me.TxtMiddleN_S1.WatermarkText = "Middle Name"
        '
        'TxtFirstN_S1
        '
        '
        '
        '
        Me.TxtFirstN_S1.Border.Class = "TextBoxBorder"
        Me.TxtFirstN_S1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFirstN_S1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFirstN_S1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFirstN_S1.Location = New System.Drawing.Point(226, 75)
        Me.TxtFirstN_S1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtFirstN_S1.MaxLength = 35
        Me.TxtFirstN_S1.Name = "TxtFirstN_S1"
        Me.TxtFirstN_S1.PreventEnterBeep = True
        Me.TxtFirstN_S1.Size = New System.Drawing.Size(133, 23)
        Me.TxtFirstN_S1.TabIndex = 10
        Me.TxtFirstN_S1.WatermarkText = "First Name"
        '
        'CbxPrefix_S2
        '
        Me.CbxPrefix_S2.DisplayMember = "PREFIX"
        Me.CbxPrefix_S2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxPrefix_S2.FormattingEnabled = True
        Me.CbxPrefix_S2.Location = New System.Drawing.Point(131, 124)
        Me.CbxPrefix_S2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxPrefix_S2.MaxLength = 15
        Me.CbxPrefix_S2.Name = "CbxPrefix_S2"
        Me.CbxPrefix_S2.Size = New System.Drawing.Size(83, 25)
        Me.CbxPrefix_S2.TabIndex = 30
        Me.CbxPrefix_S2.ValueMember = "ID"
        '
        'cbxSuffix_S2
        '
        Me.cbxSuffix_S2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxSuffix_S2.FormattingEnabled = True
        Me.cbxSuffix_S2.Location = New System.Drawing.Point(646, 124)
        Me.cbxSuffix_S2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cbxSuffix_S2.MaxLength = 10
        Me.cbxSuffix_S2.Name = "cbxSuffix_S2"
        Me.cbxSuffix_S2.Size = New System.Drawing.Size(48, 25)
        Me.cbxSuffix_S2.TabIndex = 50
        '
        'TxtLastN_S2
        '
        '
        '
        '
        Me.TxtLastN_S2.Border.Class = "TextBoxBorder"
        Me.TxtLastN_S2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLastN_S2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLastN_S2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastN_S2.Location = New System.Drawing.Point(506, 124)
        Me.TxtLastN_S2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtLastN_S2.MaxLength = 35
        Me.TxtLastN_S2.Name = "TxtLastN_S2"
        Me.TxtLastN_S2.PreventEnterBeep = True
        Me.TxtLastN_S2.Size = New System.Drawing.Size(133, 23)
        Me.TxtLastN_S2.TabIndex = 45
        Me.TxtLastN_S2.WatermarkText = "Last Name"
        '
        'TxtMiddleN_S2
        '
        '
        '
        '
        Me.TxtMiddleN_S2.Border.Class = "TextBoxBorder"
        Me.TxtMiddleN_S2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMiddleN_S2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMiddleN_S2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMiddleN_S2.Location = New System.Drawing.Point(366, 124)
        Me.TxtMiddleN_S2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtMiddleN_S2.MaxLength = 35
        Me.TxtMiddleN_S2.Name = "TxtMiddleN_S2"
        Me.TxtMiddleN_S2.PreventEnterBeep = True
        Me.TxtMiddleN_S2.Size = New System.Drawing.Size(133, 23)
        Me.TxtMiddleN_S2.TabIndex = 40
        Me.TxtMiddleN_S2.WatermarkText = "Middle Name"
        '
        'TxtFirstN_S2
        '
        '
        '
        '
        Me.TxtFirstN_S2.Border.Class = "TextBoxBorder"
        Me.TxtFirstN_S2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFirstN_S2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFirstN_S2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFirstN_S2.Location = New System.Drawing.Point(226, 124)
        Me.TxtFirstN_S2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtFirstN_S2.MaxLength = 35
        Me.TxtFirstN_S2.Name = "TxtFirstN_S2"
        Me.TxtFirstN_S2.PreventEnterBeep = True
        Me.TxtFirstN_S2.Size = New System.Drawing.Size(133, 23)
        Me.TxtFirstN_S2.TabIndex = 35
        Me.TxtFirstN_S2.WatermarkText = "First Name"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX8.Location = New System.Drawing.Point(12, 74)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(112, 28)
        Me.LabelX8.TabIndex = 1055
        Me.LabelX8.Text = "Signatory 1 :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(12, 123)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(112, 28)
        Me.LabelX2.TabIndex = 1056
        Me.LabelX2.Text = "Signatory 2 :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 203)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(708, 38)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1057
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(232, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1015
        Me.btnCancel.Text = "Close"
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.FSFC_System.My.Resources.Resources.Refresh
        Me.btnRefresh.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnRefresh.Location = New System.Drawing.Point(119, 4)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(107, 30)
        Me.btnRefresh.TabIndex = 1010
        Me.btnRefresh.Text = "Re&fresh"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(6, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 1005
        Me.btnSave.Text = "&Save"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Red
        Me.LabelX3.Location = New System.Drawing.Point(0, 156)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(708, 47)
        Me.LabelX3.TabIndex = 1058
        Me.LabelX3.Text = "Note : Current Account Signatories. Please fill the signatories for checks if reg" & _
    "istered representatives are not the signatories for the checks."
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX3.WordWrap = True
        '
        'FrmCA_Signatories
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 241)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.CbxPrefix_S2)
        Me.Controls.Add(Me.cbxSuffix_S2)
        Me.Controls.Add(Me.TxtLastN_S2)
        Me.Controls.Add(Me.TxtMiddleN_S2)
        Me.Controls.Add(Me.TxtFirstN_S2)
        Me.Controls.Add(Me.CbxPrefix_S1)
        Me.Controls.Add(Me.cbxSuffix_S1)
        Me.Controls.Add(Me.TxtLastN_S1)
        Me.Controls.Add(Me.TxtMiddleN_S1)
        Me.Controls.Add(Me.TxtFirstN_S1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCA_Signatories"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CbxPrefix_S1 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxSuffix_S1 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents TxtLastN_S1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMiddleN_S1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFirstN_S1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CbxPrefix_S2 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxSuffix_S2 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents TxtLastN_S2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMiddleN_S2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFirstN_S2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
