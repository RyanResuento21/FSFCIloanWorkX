<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSoldROPOA
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
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnPurchase = New DevComponents.DotNetBar.ButtonX()
        Me.btnCheckRegistry = New DevComponents.DotNetBar.ButtonX()
        Me.btnAttach = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.txtPlus63 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtContact_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.CbxPrefix_B = New SergeUtils.EasyCompletionComboBox()
        Me.TxtFirstN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMiddleN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtLastN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxSuffix_B = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtNoC_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtStreetC_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtBarangayC_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxAddressC_B = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.iDays = New DevComponents.Editors.IntegerInput()
        Me.txtRemarks = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.dSoldAmount = New DevComponents.Editors.DoubleInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.dROPOAValue = New DevComponents.Editors.DoubleInput()
        Me.dSellingPrice = New DevComponents.Editors.DoubleInput()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.cbxDealer = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtDealersContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxDealerName = New SergeUtils.EasyCompletionComboBox()
        Me.cbxMarketing = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtMarketingContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxMarketingName = New SergeUtils.EasyCompletionComboBox()
        Me.cbxAgent = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtAgentContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxAgentName = New SergeUtils.EasyCompletionComboBox()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx2.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        CType(Me.iDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dSoldAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dROPOAValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dSellingPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.btnLogs)
        Me.PanelEx2.Controls.Add(Me.lblTitle)
        Me.PanelEx2.Controls.Add(Me.PictureEdit1)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx2.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx2.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(995, 66)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 1684
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(372, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(408, 26)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "ROPA PURCHASE"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.PanelEx3.Controls.Add(Me.btnPurchase)
        Me.PanelEx3.Controls.Add(Me.btnCheckRegistry)
        Me.PanelEx3.Controls.Add(Me.btnAttach)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 442)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(995, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1685
        '
        'btnPurchase
        '
        Me.btnPurchase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPurchase.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPurchase.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchase.Image = Global.FSFC_System.My.Resources.Resources.Payment
        Me.btnPurchase.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPurchase.Location = New System.Drawing.Point(568, 4)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(107, 31)
        Me.btnPurchase.TabIndex = 1023
        Me.btnPurchase.Text = "Payment from Owner"
        '
        'btnCheckRegistry
        '
        Me.btnCheckRegistry.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCheckRegistry.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCheckRegistry.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckRegistry.Image = Global.FSFC_System.My.Resources.Resources.Cheque
        Me.btnCheckRegistry.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCheckRegistry.Location = New System.Drawing.Point(455, 4)
        Me.btnCheckRegistry.Name = "btnCheckRegistry"
        Me.btnCheckRegistry.Size = New System.Drawing.Size(107, 31)
        Me.btnCheckRegistry.TabIndex = 1022
        Me.btnCheckRegistry.Text = "Check Registry"
        '
        'btnAttach
        '
        Me.btnAttach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAttach.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAttach.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttach.Image = Global.FSFC_System.My.Resources.Resources.Upload
        Me.btnAttach.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnAttach.Location = New System.Drawing.Point(342, 4)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(107, 30)
        Me.btnAttach.TabIndex = 1021
        Me.btnAttach.Text = "&Attach"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(229, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1010
        Me.btnCancel.Text = "Close"
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.FSFC_System.My.Resources.Resources.Refresh
        Me.btnRefresh.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnRefresh.Location = New System.Drawing.Point(116, 4)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(107, 30)
        Me.btnRefresh.TabIndex = 1005
        Me.btnRefresh.Text = "Re&fresh"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btnSave.Location = New System.Drawing.Point(3, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 1000
        Me.btnSave.Text = "&Save"
        '
        'txtPlus63
        '
        '
        '
        '
        Me.txtPlus63.Border.Class = "TextBoxBorder"
        Me.txtPlus63.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPlus63.Enabled = False
        Me.txtPlus63.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlus63.Location = New System.Drawing.Point(116, 169)
        Me.txtPlus63.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPlus63.MaxLength = 10
        Me.txtPlus63.Name = "txtPlus63"
        Me.txtPlus63.PreventEnterBeep = True
        Me.txtPlus63.Size = New System.Drawing.Size(33, 23)
        Me.txtPlus63.TabIndex = 1732
        Me.txtPlus63.Text = "+63"
        '
        'txtContact_B
        '
        '
        '
        '
        Me.txtContact_B.Border.Class = "TextBoxBorder"
        Me.txtContact_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContact_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact_B.Location = New System.Drawing.Point(155, 169)
        Me.txtContact_B.MaxLength = 10
        Me.txtContact_B.Name = "txtContact_B"
        Me.txtContact_B.PreventEnterBeep = True
        Me.txtContact_B.Size = New System.Drawing.Size(133, 23)
        Me.txtContact_B.TabIndex = 50
        Me.txtContact_B.WatermarkText = "eg. 9123456789"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(9, 169)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(100, 23)
        Me.LabelX4.TabIndex = 1730
        Me.LabelX4.Text = "Mobile No. :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'CbxPrefix_B
        '
        Me.CbxPrefix_B.DisplayMember = "PREFIX"
        Me.CbxPrefix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxPrefix_B.FormattingEnabled = True
        Me.CbxPrefix_B.Location = New System.Drawing.Point(116, 105)
        Me.CbxPrefix_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxPrefix_B.MaxLength = 15
        Me.CbxPrefix_B.Name = "CbxPrefix_B"
        Me.CbxPrefix_B.Size = New System.Drawing.Size(83, 25)
        Me.CbxPrefix_B.TabIndex = 5
        Me.CbxPrefix_B.ValueMember = "ID"
        '
        'TxtFirstN_B
        '
        '
        '
        '
        Me.TxtFirstN_B.Border.Class = "TextBoxBorder"
        Me.TxtFirstN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFirstN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFirstN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFirstN_B.Location = New System.Drawing.Point(207, 105)
        Me.TxtFirstN_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtFirstN_B.MaxLength = 35
        Me.TxtFirstN_B.Name = "TxtFirstN_B"
        Me.TxtFirstN_B.PreventEnterBeep = True
        Me.TxtFirstN_B.Size = New System.Drawing.Size(233, 23)
        Me.TxtFirstN_B.TabIndex = 10
        Me.TxtFirstN_B.WatermarkText = "First Name"
        '
        'TxtMiddleN_B
        '
        '
        '
        '
        Me.TxtMiddleN_B.Border.Class = "TextBoxBorder"
        Me.TxtMiddleN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMiddleN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMiddleN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMiddleN_B.Location = New System.Drawing.Point(446, 105)
        Me.TxtMiddleN_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtMiddleN_B.MaxLength = 35
        Me.TxtMiddleN_B.Name = "TxtMiddleN_B"
        Me.TxtMiddleN_B.PreventEnterBeep = True
        Me.TxtMiddleN_B.Size = New System.Drawing.Size(233, 23)
        Me.TxtMiddleN_B.TabIndex = 15
        Me.TxtMiddleN_B.WatermarkText = "Middle Name"
        '
        'TxtLastN_B
        '
        '
        '
        '
        Me.TxtLastN_B.Border.Class = "TextBoxBorder"
        Me.TxtLastN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLastN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLastN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastN_B.Location = New System.Drawing.Point(685, 105)
        Me.TxtLastN_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtLastN_B.MaxLength = 35
        Me.TxtLastN_B.Name = "TxtLastN_B"
        Me.TxtLastN_B.PreventEnterBeep = True
        Me.TxtLastN_B.Size = New System.Drawing.Size(233, 23)
        Me.TxtLastN_B.TabIndex = 20
        Me.TxtLastN_B.WatermarkText = "Last Name"
        '
        'cbxSuffix_B
        '
        Me.cbxSuffix_B.DisplayMember = "Suffix"
        Me.cbxSuffix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxSuffix_B.FormattingEnabled = True
        Me.cbxSuffix_B.Location = New System.Drawing.Point(924, 105)
        Me.cbxSuffix_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxSuffix_B.MaxLength = 10
        Me.cbxSuffix_B.Name = "cbxSuffix_B"
        Me.cbxSuffix_B.Size = New System.Drawing.Size(59, 25)
        Me.cbxSuffix_B.TabIndex = 25
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(9, 105)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(101, 25)
        Me.LabelX1.TabIndex = 1726
        Me.LabelX1.Text = "Name :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(9, 137)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(101, 24)
        Me.LabelX6.TabIndex = 1727
        Me.LabelX6.Text = "Address :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtNoC_B
        '
        '
        '
        '
        Me.txtNoC_B.Border.Class = "TextBoxBorder"
        Me.txtNoC_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoC_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoC_B.Location = New System.Drawing.Point(116, 138)
        Me.txtNoC_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNoC_B.MaxLength = 10
        Me.txtNoC_B.Name = "txtNoC_B"
        Me.txtNoC_B.PreventEnterBeep = True
        Me.txtNoC_B.Size = New System.Drawing.Size(55, 23)
        Me.txtNoC_B.TabIndex = 30
        Me.txtNoC_B.WatermarkText = "No."
        '
        'txtStreetC_B
        '
        '
        '
        '
        Me.txtStreetC_B.Border.Class = "TextBoxBorder"
        Me.txtStreetC_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtStreetC_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreetC_B.Location = New System.Drawing.Point(178, 138)
        Me.txtStreetC_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtStreetC_B.MaxLength = 35
        Me.txtStreetC_B.Name = "txtStreetC_B"
        Me.txtStreetC_B.PreventEnterBeep = True
        Me.txtStreetC_B.Size = New System.Drawing.Size(146, 23)
        Me.txtStreetC_B.TabIndex = 35
        Me.txtStreetC_B.WatermarkText = "Street"
        '
        'txtBarangayC_B
        '
        '
        '
        '
        Me.txtBarangayC_B.Border.Class = "TextBoxBorder"
        Me.txtBarangayC_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBarangayC_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayC_B.Location = New System.Drawing.Point(327, 138)
        Me.txtBarangayC_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBarangayC_B.MaxLength = 35
        Me.txtBarangayC_B.Name = "txtBarangayC_B"
        Me.txtBarangayC_B.PreventEnterBeep = True
        Me.txtBarangayC_B.Size = New System.Drawing.Size(146, 23)
        Me.txtBarangayC_B.TabIndex = 40
        Me.txtBarangayC_B.WatermarkText = "Barangay"
        '
        'cbxAddressC_B
        '
        Me.cbxAddressC_B.DisplayMember = "CITY"
        Me.cbxAddressC_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAddressC_B.FormattingEnabled = True
        Me.cbxAddressC_B.Location = New System.Drawing.Point(479, 137)
        Me.cbxAddressC_B.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxAddressC_B.MaxLength = 85
        Me.cbxAddressC_B.Name = "cbxAddressC_B"
        Me.cbxAddressC_B.Size = New System.Drawing.Size(504, 25)
        Me.cbxAddressC_B.TabIndex = 45
        Me.cbxAddressC_B.ValueMember = "ID"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.White
        Me.LabelX3.Location = New System.Drawing.Point(9, 75)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(974, 23)
        Me.LabelX3.TabIndex = 1733
        Me.LabelX3.Text = "Buyer's Information"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.White
        Me.LabelX2.Location = New System.Drawing.Point(9, 198)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(974, 23)
        Me.LabelX2.TabIndex = 1734
        Me.LabelX2.Text = "Payment Information"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(9, 258)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(101, 23)
        Me.LabelX17.TabIndex = 1742
        Me.LabelX17.Text = "Reservation :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iDays
        '
        '
        '
        '
        Me.iDays.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iDays.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iDays.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iDays.ForeColor = System.Drawing.Color.Black
        Me.iDays.Location = New System.Drawing.Point(116, 258)
        Me.iDays.MaxValue = 29
        Me.iDays.MinValue = 0
        Me.iDays.Name = "iDays"
        Me.iDays.ShowUpDown = True
        Me.iDays.Size = New System.Drawing.Size(55, 23)
        Me.iDays.TabIndex = 70
        '
        'txtRemarks
        '
        '
        '
        '
        Me.txtRemarks.Border.Class = "TextBoxBorder"
        Me.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemarks.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtRemarks.ForeColor = System.Drawing.Color.Black
        Me.txtRemarks.Location = New System.Drawing.Point(116, 289)
        Me.txtRemarks.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRemarks.MaxLength = 150
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.PreventEnterBeep = True
        Me.txtRemarks.Size = New System.Drawing.Size(867, 23)
        Me.txtRemarks.TabIndex = 80
        Me.txtRemarks.WatermarkColor = System.Drawing.Color.Silver
        Me.txtRemarks.WatermarkText = "Remarks"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelX7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX7.Location = New System.Drawing.Point(9, 289)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(101, 23)
        Me.LabelX7.TabIndex = 1743
        Me.LabelX7.Text = "Remarks :"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(9, 228)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(101, 23)
        Me.LabelX15.TabIndex = 1741
        Me.LabelX15.Text = "Sold Price :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dSoldAmount
        '
        '
        '
        '
        Me.dSoldAmount.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dSoldAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dSoldAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dSoldAmount.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dSoldAmount.ForeColor = System.Drawing.Color.Black
        Me.dSoldAmount.Increment = 1.0R
        Me.dSoldAmount.Location = New System.Drawing.Point(116, 228)
        Me.dSoldAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dSoldAmount.MinValue = 0.0R
        Me.dSoldAmount.Name = "dSoldAmount"
        Me.dSoldAmount.ShowUpDown = True
        Me.dSoldAmount.Size = New System.Drawing.Size(172, 23)
        Me.dSoldAmount.TabIndex = 55
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(356, 228)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(101, 23)
        Me.LabelX5.TabIndex = 1747
        Me.LabelX5.Text = "Selling Price :"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelX8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX8.Location = New System.Drawing.Point(700, 228)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(101, 23)
        Me.LabelX8.TabIndex = 1749
        Me.LabelX8.Text = "ROPOA Value :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dROPOAValue
        '
        '
        '
        '
        Me.dROPOAValue.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dROPOAValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dROPOAValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dROPOAValue.Enabled = False
        Me.dROPOAValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dROPOAValue.ForeColor = System.Drawing.Color.Black
        Me.dROPOAValue.Increment = 1.0R
        Me.dROPOAValue.Location = New System.Drawing.Point(807, 228)
        Me.dROPOAValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dROPOAValue.MinValue = 0.0R
        Me.dROPOAValue.Name = "dROPOAValue"
        Me.dROPOAValue.ShowUpDown = True
        Me.dROPOAValue.Size = New System.Drawing.Size(176, 23)
        Me.dROPOAValue.TabIndex = 1748
        '
        'dSellingPrice
        '
        '
        '
        '
        Me.dSellingPrice.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dSellingPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dSellingPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dSellingPrice.Enabled = False
        Me.dSellingPrice.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dSellingPrice.ForeColor = System.Drawing.Color.Black
        Me.dSellingPrice.Increment = 1.0R
        Me.dSellingPrice.Location = New System.Drawing.Point(461, 228)
        Me.dSellingPrice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dSellingPrice.MinValue = 0.0R
        Me.dSellingPrice.Name = "dSellingPrice"
        Me.dSellingPrice.ShowUpDown = True
        Me.dSellingPrice.Size = New System.Drawing.Size(172, 23)
        Me.dSellingPrice.TabIndex = 1750
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic)
        Me.LabelX18.ForeColor = System.Drawing.Color.Red
        Me.LabelX18.Location = New System.Drawing.Point(177, 258)
        Me.LabelX18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(436, 23)
        Me.LabelX18.TabIndex = 1751
        Me.LabelX18.Text = "<i>Number of <b>RESERVATION DAYS</b></i>"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.White
        Me.LabelX9.Location = New System.Drawing.Point(9, 318)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(974, 23)
        Me.LabelX9.TabIndex = 1752
        Me.LabelX9.Text = "Referral Information"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cbxDealer
        '
        Me.cbxDealer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDealer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDealer.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDealer.Location = New System.Drawing.Point(9, 409)
        Me.cbxDealer.Name = "cbxDealer"
        Me.cbxDealer.Size = New System.Drawing.Size(100, 23)
        Me.cbxDealer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDealer.TabIndex = 115
        Me.cbxDealer.Text = "Dealer "
        '
        'txtDealersContact
        '
        '
        '
        '
        Me.txtDealersContact.Border.Class = "TextBoxBorder"
        Me.txtDealersContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDealersContact.Enabled = False
        Me.txtDealersContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDealersContact.Location = New System.Drawing.Point(446, 409)
        Me.txtDealersContact.MaxLength = 70
        Me.txtDealersContact.Name = "txtDealersContact"
        Me.txtDealersContact.PreventEnterBeep = True
        Me.txtDealersContact.Size = New System.Drawing.Size(233, 23)
        Me.txtDealersContact.TabIndex = 125
        Me.txtDealersContact.WatermarkText = "Contact No."
        '
        'cbxDealerName
        '
        Me.cbxDealerName.Enabled = False
        Me.cbxDealerName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDealerName.FormattingEnabled = True
        Me.cbxDealerName.Location = New System.Drawing.Point(116, 409)
        Me.cbxDealerName.MaxLength = 70
        Me.cbxDealerName.Name = "cbxDealerName"
        Me.cbxDealerName.Size = New System.Drawing.Size(324, 25)
        Me.cbxDealerName.TabIndex = 120
        '
        'cbxMarketing
        '
        Me.cbxMarketing.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxMarketing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMarketing.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMarketing.Location = New System.Drawing.Point(9, 378)
        Me.cbxMarketing.Name = "cbxMarketing"
        Me.cbxMarketing.Size = New System.Drawing.Size(100, 23)
        Me.cbxMarketing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMarketing.TabIndex = 100
        Me.cbxMarketing.Text = "Employee "
        '
        'txtMarketingContact
        '
        '
        '
        '
        Me.txtMarketingContact.Border.Class = "TextBoxBorder"
        Me.txtMarketingContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMarketingContact.Enabled = False
        Me.txtMarketingContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketingContact.Location = New System.Drawing.Point(446, 378)
        Me.txtMarketingContact.MaxLength = 70
        Me.txtMarketingContact.Name = "txtMarketingContact"
        Me.txtMarketingContact.PreventEnterBeep = True
        Me.txtMarketingContact.Size = New System.Drawing.Size(233, 23)
        Me.txtMarketingContact.TabIndex = 110
        Me.txtMarketingContact.WatermarkText = "Contact No."
        '
        'cbxMarketingName
        '
        Me.cbxMarketingName.Enabled = False
        Me.cbxMarketingName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxMarketingName.FormattingEnabled = True
        Me.cbxMarketingName.Location = New System.Drawing.Point(116, 378)
        Me.cbxMarketingName.MaxLength = 70
        Me.cbxMarketingName.Name = "cbxMarketingName"
        Me.cbxMarketingName.Size = New System.Drawing.Size(324, 25)
        Me.cbxMarketingName.TabIndex = 105
        '
        'cbxAgent
        '
        Me.cbxAgent.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAgent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAgent.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAgent.Location = New System.Drawing.Point(9, 347)
        Me.cbxAgent.Name = "cbxAgent"
        Me.cbxAgent.Size = New System.Drawing.Size(100, 23)
        Me.cbxAgent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAgent.TabIndex = 85
        Me.cbxAgent.Text = "Agent "
        '
        'txtAgentContact
        '
        '
        '
        '
        Me.txtAgentContact.Border.Class = "TextBoxBorder"
        Me.txtAgentContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAgentContact.Enabled = False
        Me.txtAgentContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgentContact.Location = New System.Drawing.Point(446, 347)
        Me.txtAgentContact.MaxLength = 70
        Me.txtAgentContact.Name = "txtAgentContact"
        Me.txtAgentContact.PreventEnterBeep = True
        Me.txtAgentContact.Size = New System.Drawing.Size(233, 23)
        Me.txtAgentContact.TabIndex = 95
        Me.txtAgentContact.WatermarkText = "Contact No."
        '
        'cbxAgentName
        '
        Me.cbxAgentName.Enabled = False
        Me.cbxAgentName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAgentName.FormattingEnabled = True
        Me.cbxAgentName.Location = New System.Drawing.Point(116, 347)
        Me.cbxAgentName.MaxLength = 70
        Me.cbxAgentName.Name = "cbxAgentName"
        Me.cbxAgentName.Size = New System.Drawing.Size(324, 25)
        Me.cbxAgentName.TabIndex = 90
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(959, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'FrmSoldROPOA
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 479)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxDealer)
        Me.Controls.Add(Me.txtDealersContact)
        Me.Controls.Add(Me.cbxDealerName)
        Me.Controls.Add(Me.cbxMarketing)
        Me.Controls.Add(Me.txtMarketingContact)
        Me.Controls.Add(Me.cbxMarketingName)
        Me.Controls.Add(Me.cbxAgent)
        Me.Controls.Add(Me.txtAgentContact)
        Me.Controls.Add(Me.cbxAgentName)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX18)
        Me.Controls.Add(Me.dSellingPrice)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.dROPOAValue)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.iDays)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX15)
        Me.Controls.Add(Me.dSoldAmount)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txtPlus63)
        Me.Controls.Add(Me.txtContact_B)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.CbxPrefix_B)
        Me.Controls.Add(Me.TxtFirstN_B)
        Me.Controls.Add(Me.TxtMiddleN_B)
        Me.Controls.Add(Me.TxtLastN_B)
        Me.Controls.Add(Me.cbxSuffix_B)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.txtNoC_B)
        Me.Controls.Add(Me.txtStreetC_B)
        Me.Controls.Add(Me.txtBarangayC_B)
        Me.Controls.Add(Me.cbxAddressC_B)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSoldROPOA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.iDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dSoldAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dROPOAValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dSellingPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtPlus63 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtContact_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CbxPrefix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents TxtFirstN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMiddleN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtLastN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxSuffix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNoC_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtStreetC_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtBarangayC_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxAddressC_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iDays As DevComponents.Editors.IntegerInput
    Friend WithEvents txtRemarks As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Public WithEvents dSoldAmount As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents dROPOAValue As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents dSellingPrice As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnAttach As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxDealer As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtDealersContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxDealerName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxMarketing As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtMarketingContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxMarketingName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxAgent As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtAgentContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxAgentName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents btnCheckRegistry As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPurchase As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
