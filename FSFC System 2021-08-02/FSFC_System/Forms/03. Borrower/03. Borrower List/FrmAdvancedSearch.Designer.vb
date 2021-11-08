<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdvancedSearch
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
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.txtKeyword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.cbxFemale_B = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxMale_B = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblGender = New DevComponents.DotNetBar.LabelX()
        Me.cbxWidowed_B = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxSeparated_B = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxMarried_B = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxSingle_B = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblCivil = New DevComponents.DotNetBar.LabelX()
        Me.iFrom = New DevComponents.Editors.IntegerInput()
        Me.lblAge = New DevComponents.DotNetBar.LabelX()
        Me.lblTo = New DevComponents.DotNetBar.LabelX()
        Me.iTo = New DevComponents.Editors.IntegerInput()
        Me.cbxLarge = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxMedium = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxSmall = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxMicro = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblFirm = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        CType(Me.iFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.LabelX11)
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(645, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 17
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX11.Location = New System.Drawing.Point(278, 20)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(355, 26)
        Me.LabelX11.TabIndex = 6
        Me.LabelX11.Text = "ADVANCED SEARCH"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(9, 1)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
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
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnSearch)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 200)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(645, 38)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1058
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnSearch.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSearch.Location = New System.Drawing.Point(3, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 30)
        Me.btnSearch.TabIndex = 1005
        Me.btnSearch.Text = "&Search"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(116, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1010
        Me.btnCancel.Text = "Close"
        '
        'txtKeyword
        '
        '
        '
        '
        Me.txtKeyword.Border.Class = "TextBoxBorder"
        Me.txtKeyword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtKeyword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKeyword.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyword.Location = New System.Drawing.Point(132, 76)
        Me.txtKeyword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.PreventEnterBeep = True
        Me.txtKeyword.Size = New System.Drawing.Size(432, 23)
        Me.txtKeyword.TabIndex = 5
        Me.txtKeyword.WatermarkText = "Please fill any keyword to search."
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
        Me.LabelX17.Location = New System.Drawing.Point(13, 76)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(115, 23)
        Me.LabelX17.TabIndex = 1423
        Me.LabelX17.Text = "Keyword :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxFemale_B
        '
        Me.cbxFemale_B.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxFemale_B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxFemale_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxFemale_B.Location = New System.Drawing.Point(200, 135)
        Me.cbxFemale_B.Name = "cbxFemale_B"
        Me.cbxFemale_B.Size = New System.Drawing.Size(71, 23)
        Me.cbxFemale_B.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxFemale_B.TabIndex = 25
        Me.cbxFemale_B.Text = "Female"
        '
        'cbxMale_B
        '
        Me.cbxMale_B.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxMale_B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMale_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMale_B.Location = New System.Drawing.Point(132, 135)
        Me.cbxMale_B.Name = "cbxMale_B"
        Me.cbxMale_B.Size = New System.Drawing.Size(62, 23)
        Me.cbxMale_B.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMale_B.TabIndex = 20
        Me.cbxMale_B.Text = "Male"
        '
        'lblGender
        '
        Me.lblGender.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblGender.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGender.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblGender.Location = New System.Drawing.Point(13, 135)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(114, 23)
        Me.lblGender.TabIndex = 1425
        Me.lblGender.Text = "Gender :"
        Me.lblGender.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxWidowed_B
        '
        Me.cbxWidowed_B.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxWidowed_B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxWidowed_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxWidowed_B.Location = New System.Drawing.Point(444, 164)
        Me.cbxWidowed_B.Name = "cbxWidowed_B"
        Me.cbxWidowed_B.Size = New System.Drawing.Size(90, 23)
        Me.cbxWidowed_B.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxWidowed_B.TabIndex = 45
        Me.cbxWidowed_B.Text = "Widowed"
        '
        'cbxSeparated_B
        '
        Me.cbxSeparated_B.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxSeparated_B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxSeparated_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSeparated_B.Location = New System.Drawing.Point(279, 164)
        Me.cbxSeparated_B.Name = "cbxSeparated_B"
        Me.cbxSeparated_B.Size = New System.Drawing.Size(161, 23)
        Me.cbxSeparated_B.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxSeparated_B.TabIndex = 40
        Me.cbxSeparated_B.Text = "Separated / Divorced"
        '
        'cbxMarried_B
        '
        Me.cbxMarried_B.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxMarried_B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMarried_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMarried_B.Location = New System.Drawing.Point(200, 164)
        Me.cbxMarried_B.Name = "cbxMarried_B"
        Me.cbxMarried_B.Size = New System.Drawing.Size(71, 23)
        Me.cbxMarried_B.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMarried_B.TabIndex = 35
        Me.cbxMarried_B.Text = "Married"
        '
        'cbxSingle_B
        '
        Me.cbxSingle_B.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxSingle_B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxSingle_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSingle_B.Location = New System.Drawing.Point(132, 164)
        Me.cbxSingle_B.Name = "cbxSingle_B"
        Me.cbxSingle_B.Size = New System.Drawing.Size(62, 23)
        Me.cbxSingle_B.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxSingle_B.TabIndex = 30
        Me.cbxSingle_B.Text = "Single"
        '
        'lblCivil
        '
        Me.lblCivil.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblCivil.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCivil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCivil.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCivil.Location = New System.Drawing.Point(13, 164)
        Me.lblCivil.Name = "lblCivil"
        Me.lblCivil.Size = New System.Drawing.Size(111, 23)
        Me.lblCivil.TabIndex = 1424
        Me.lblCivil.Text = "Civil Status :"
        Me.lblCivil.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iFrom
        '
        '
        '
        '
        Me.iFrom.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iFrom.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iFrom.ForeColor = System.Drawing.Color.Black
        Me.iFrom.Location = New System.Drawing.Point(132, 106)
        Me.iFrom.MaxValue = 100
        Me.iFrom.MinValue = 0
        Me.iFrom.Name = "iFrom"
        Me.iFrom.ShowUpDown = True
        Me.iFrom.Size = New System.Drawing.Size(83, 23)
        Me.iFrom.TabIndex = 10
        Me.iFrom.Tag = ""
        '
        'lblAge
        '
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblAge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAge.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAge.Location = New System.Drawing.Point(10, 106)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(117, 23)
        Me.lblAge.TabIndex = 1432
        Me.lblAge.Text = "Age Between :"
        Me.lblAge.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTo.Location = New System.Drawing.Point(221, 106)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(42, 23)
        Me.lblTo.TabIndex = 1434
        Me.lblTo.Text = "to"
        Me.lblTo.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'iTo
        '
        '
        '
        '
        Me.iTo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iTo.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iTo.ForeColor = System.Drawing.Color.Black
        Me.iTo.Location = New System.Drawing.Point(269, 106)
        Me.iTo.MaxValue = 100
        Me.iTo.MinValue = 0
        Me.iTo.Name = "iTo"
        Me.iTo.ShowUpDown = True
        Me.iTo.Size = New System.Drawing.Size(83, 23)
        Me.iTo.TabIndex = 15
        Me.iTo.Tag = ""
        '
        'cbxLarge
        '
        Me.cbxLarge.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxLarge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxLarge.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLarge.Location = New System.Drawing.Point(352, 106)
        Me.cbxLarge.Name = "cbxLarge"
        Me.cbxLarge.Size = New System.Drawing.Size(90, 23)
        Me.cbxLarge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxLarge.TabIndex = 30
        Me.cbxLarge.Text = "Large"
        Me.cbxLarge.Visible = False
        '
        'cbxMedium
        '
        Me.cbxMedium.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxMedium.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMedium.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMedium.Location = New System.Drawing.Point(269, 106)
        Me.cbxMedium.Name = "cbxMedium"
        Me.cbxMedium.Size = New System.Drawing.Size(86, 23)
        Me.cbxMedium.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMedium.TabIndex = 20
        Me.cbxMedium.Text = "Medium"
        Me.cbxMedium.Visible = False
        '
        'cbxSmall
        '
        Me.cbxSmall.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxSmall.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxSmall.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSmall.Location = New System.Drawing.Point(200, 106)
        Me.cbxSmall.Name = "cbxSmall"
        Me.cbxSmall.Size = New System.Drawing.Size(71, 23)
        Me.cbxSmall.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxSmall.TabIndex = 15
        Me.cbxSmall.Text = "Small"
        Me.cbxSmall.Visible = False
        '
        'cbxMicro
        '
        Me.cbxMicro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxMicro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMicro.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMicro.Location = New System.Drawing.Point(132, 106)
        Me.cbxMicro.Name = "cbxMicro"
        Me.cbxMicro.Size = New System.Drawing.Size(62, 23)
        Me.cbxMicro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMicro.TabIndex = 10
        Me.cbxMicro.Text = "Micro"
        Me.cbxMicro.Visible = False
        '
        'lblFirm
        '
        Me.lblFirm.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblFirm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFirm.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFirm.Location = New System.Drawing.Point(17, 106)
        Me.lblFirm.Name = "lblFirm"
        Me.lblFirm.Size = New System.Drawing.Size(111, 23)
        Me.lblFirm.TabIndex = 1439
        Me.lblFirm.Text = "Firm Size :"
        Me.lblFirm.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblFirm.Visible = False
        '
        'FrmAdvancedSearch
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxFemale_B)
        Me.Controls.Add(Me.cbxMale_B)
        Me.Controls.Add(Me.cbxWidowed_B)
        Me.Controls.Add(Me.cbxSeparated_B)
        Me.Controls.Add(Me.cbxMarried_B)
        Me.Controls.Add(Me.cbxSingle_B)
        Me.Controls.Add(Me.lblCivil)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.cbxLarge)
        Me.Controls.Add(Me.iTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.iFrom)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.lblFirm)
        Me.Controls.Add(Me.cbxMicro)
        Me.Controls.Add(Me.cbxSmall)
        Me.Controls.Add(Me.cbxMedium)
        Me.Controls.Add(Me.txtKeyword)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAdvancedSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.iFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtKeyword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxFemale_B As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxMale_B As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblGender As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxWidowed_B As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxSeparated_B As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxMarried_B As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxSingle_B As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblCivil As DevComponents.DotNetBar.LabelX
    Friend WithEvents iFrom As DevComponents.Editors.IntegerInput
    Friend WithEvents lblAge As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTo As DevComponents.DotNetBar.LabelX
    Friend WithEvents iTo As DevComponents.Editors.IntegerInput
    Friend WithEvents cbxLarge As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxMedium As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxSmall As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxMicro As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblFirm As DevComponents.DotNetBar.LabelX
End Class
