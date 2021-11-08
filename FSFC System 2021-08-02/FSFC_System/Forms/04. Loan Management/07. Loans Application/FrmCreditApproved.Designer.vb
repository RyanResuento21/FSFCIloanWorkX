<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCreditApproved
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
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnBOLA = New DevComponents.DotNetBar.ButtonX()
        Me.btnRequirements = New DevComponents.DotNetBar.ButtonX()
        Me.btnAttach = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnApproved = New DevComponents.DotNetBar.ButtonX()
        Me.btnDisapproved = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx9 = New DevComponents.DotNetBar.PanelEx()
        Me.cbxOutsource = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxOutsourceBranch = New SergeUtils.EasyCompletionComboBox()
        Me.lblFA_C = New DevComponents.DotNetBar.LabelX()
        Me.dFA_C = New DevComponents.Editors.DoubleInput()
        Me.cbxCI = New SergeUtils.EasyCompletionComboBox()
        Me.lblCI = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.lblInterest = New DevComponents.DotNetBar.LabelX()
        Me.dServiceChargeA = New DevComponents.Editors.DoubleInput()
        Me.dInterestRateA = New DevComponents.Editors.DoubleInput()
        Me.iTermsA = New DevComponents.Editors.IntegerInput()
        Me.cbxTermsA = New SergeUtils.EasyCompletionComboBox()
        Me.dPrincipalA = New DevComponents.Editors.DoubleInput()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.dServiceCharge = New DevComponents.Editors.DoubleInput()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.dInterestRate = New DevComponents.Editors.DoubleInput()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.iTerms = New DevComponents.Editors.IntegerInput()
        Me.cbxTerms = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.dPrincipal = New DevComponents.Editors.DoubleInput()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.dtpApproved = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX68 = New DevComponents.DotNetBar.LabelX()
        Me.lblCreditNumber = New DevComponents.DotNetBar.LabelX()
        Me.LabelX100 = New DevComponents.DotNetBar.LabelX()
        Me.dNetProceeds_C = New DevComponents.Editors.DoubleInput()
        Me.cbxProduct = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX82 = New DevComponents.DotNetBar.LabelX()
        Me.lblExcessP = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.lblExcess = New DevComponents.DotNetBar.LabelX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.lblPrincipal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.lblThreshold = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.lblTotalBooking = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.lblThresholdMessage = New DevComponents.DotNetBar.LabelX()
        Me.lblWarning = New DevComponents.DotNetBar.LabelX()
        Me.btnUpdate = New DevComponents.DotNetBar.ButtonX()
        Me.gRequirements = New DevExpress.XtraEditors.GroupControl()
        Me.lblIncP = New DevComponents.DotNetBar.LabelX()
        Me.lblCompP = New DevComponents.DotNetBar.LabelX()
        Me.lblIncN = New DevComponents.DotNetBar.LabelX()
        Me.lblCompN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.gPassDue = New DevExpress.XtraEditors.GroupControl()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.lblMaximum = New DevComponents.DotNetBar.LabelX()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX49 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX50 = New DevComponents.DotNetBar.LabelX()
        Me.lblMinimum = New DevComponents.DotNetBar.LabelX()
        Me.lblAverageN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX55 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX56 = New DevComponents.DotNetBar.LabelX()
        Me.gPayments = New DevExpress.XtraEditors.GroupControl()
        Me.lblPassP = New DevComponents.DotNetBar.LabelX()
        Me.lblAdvanceP = New DevComponents.DotNetBar.LabelX()
        Me.lblPassN = New DevComponents.DotNetBar.LabelX()
        Me.lblAdvanceN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX45 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX46 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX47 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.gLoans = New DevExpress.XtraEditors.GroupControl()
        Me.lblCheckP = New DevComponents.DotNetBar.LabelX()
        Me.lblCheckN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.lblShowmoneyP = New DevComponents.DotNetBar.LabelX()
        Me.lblShowmoneyN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.lblPaydayP = New DevComponents.DotNetBar.LabelX()
        Me.lblPaydayN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.lblSalarySisterP = New DevComponents.DotNetBar.LabelX()
        Me.lblSalarySisterN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.lblSalaryP = New DevComponents.DotNetBar.LabelX()
        Me.lblSalaryN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.lblCarP = New DevComponents.DotNetBar.LabelX()
        Me.lblCarN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.lblRealEstateP = New DevComponents.DotNetBar.LabelX()
        Me.lblVehicleP = New DevComponents.DotNetBar.LabelX()
        Me.lblRealEstateN = New DevComponents.DotNetBar.LabelX()
        Me.lblVehicleN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.gApplication = New DevExpress.XtraEditors.GroupControl()
        Me.lblDisapprovedP = New DevComponents.DotNetBar.LabelX()
        Me.lblDisapprovedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.lblApprovedP = New DevComponents.DotNetBar.LabelX()
        Me.lblPendingP = New DevComponents.DotNetBar.LabelX()
        Me.lblApprovedN = New DevComponents.DotNetBar.LabelX()
        Me.lblPendingN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.CbxPrefix_B = New SergeUtils.EasyCompletionComboBox()
        Me.cbxSuffix_B = New SergeUtils.EasyCompletionComboBox()
        Me.TxtLastN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMiddleN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFirstN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.pb_B = New DevExpress.XtraEditors.PictureEdit()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx9.SuspendLayout()
        CType(Me.dFA_C, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dServiceChargeA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dInterestRateA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTermsA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPrincipalA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dServiceCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dInterestRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dNetProceeds_C, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gRequirements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gRequirements.SuspendLayout()
        CType(Me.gPassDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gPassDue.SuspendLayout()
        CType(Me.gPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gPayments.SuspendLayout()
        CType(Me.gLoans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gLoans.SuspendLayout()
        CType(Me.gApplication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gApplication.SuspendLayout()
        CType(Me.pb_B.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btnLogs)
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.lblTitle)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1163, 73)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 9
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
        Me.PictureEdit1.Size = New System.Drawing.Size(307, 71)
        Me.PictureEdit1.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(649, 34)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(476, 32)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Company Policy <b><u>strictly prohibits</u></b> employees from soliciting or rece" &
    "iving any compensation in the processing of loan applications."
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.lblTitle.Location = New System.Drawing.Point(649, 4)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(476, 32)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "CREDIT APPLICATION - APPROVAL"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnBOLA)
        Me.PanelEx3.Controls.Add(Me.btnRequirements)
        Me.PanelEx3.Controls.Add(Me.btnAttach)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnApproved)
        Me.PanelEx3.Controls.Add(Me.btnDisapproved)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 672)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1163, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1001
        '
        'btnBOLA
        '
        Me.btnBOLA.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBOLA.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnBOLA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBOLA.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnBOLA.Location = New System.Drawing.Point(229, 4)
        Me.btnBOLA.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnBOLA.Name = "btnBOLA"
        Me.btnBOLA.Size = New System.Drawing.Size(107, 30)
        Me.btnBOLA.TabIndex = 1011
        Me.btnBOLA.Text = "Base On Last Approval"
        '
        'btnRequirements
        '
        Me.btnRequirements.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRequirements.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRequirements.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequirements.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnRequirements.Location = New System.Drawing.Point(568, 4)
        Me.btnRequirements.Name = "btnRequirements"
        Me.btnRequirements.Size = New System.Drawing.Size(107, 30)
        Me.btnRequirements.TabIndex = 1022
        Me.btnRequirements.Text = "Requirements"
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
        Me.btnAttach.TabIndex = 1014
        Me.btnAttach.Text = "Attach"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(455, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1015
        Me.btnCancel.Text = "Close"
        '
        'btnApproved
        '
        Me.btnApproved.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnApproved.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnApproved.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApproved.Image = Global.FSFC_System.My.Resources.Resources.Approve
        Me.btnApproved.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnApproved.Location = New System.Drawing.Point(3, 4)
        Me.btnApproved.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnApproved.Name = "btnApproved"
        Me.btnApproved.Size = New System.Drawing.Size(107, 30)
        Me.btnApproved.TabIndex = 1005
        Me.btnApproved.Text = "&Approve"
        '
        'btnDisapproved
        '
        Me.btnDisapproved.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDisapproved.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDisapproved.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisapproved.Image = Global.FSFC_System.My.Resources.Resources.Dislike
        Me.btnDisapproved.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnDisapproved.Location = New System.Drawing.Point(116, 4)
        Me.btnDisapproved.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnDisapproved.Name = "btnDisapproved"
        Me.btnDisapproved.Size = New System.Drawing.Size(107, 30)
        Me.btnDisapproved.TabIndex = 1010
        Me.btnDisapproved.Text = "&Disapprove"
        '
        'PanelEx9
        '
        Me.PanelEx9.AutoScroll = True
        Me.PanelEx9.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx9.Controls.Add(Me.cbxOutsource)
        Me.PanelEx9.Controls.Add(Me.cbxOutsourceBranch)
        Me.PanelEx9.Controls.Add(Me.lblFA_C)
        Me.PanelEx9.Controls.Add(Me.dFA_C)
        Me.PanelEx9.Controls.Add(Me.cbxCI)
        Me.PanelEx9.Controls.Add(Me.lblCI)
        Me.PanelEx9.Controls.Add(Me.LabelX3)
        Me.PanelEx9.Controls.Add(Me.LabelX5)
        Me.PanelEx9.Controls.Add(Me.LabelX22)
        Me.PanelEx9.Controls.Add(Me.lblInterest)
        Me.PanelEx9.Controls.Add(Me.dServiceChargeA)
        Me.PanelEx9.Controls.Add(Me.dInterestRateA)
        Me.PanelEx9.Controls.Add(Me.iTermsA)
        Me.PanelEx9.Controls.Add(Me.cbxTermsA)
        Me.PanelEx9.Controls.Add(Me.dPrincipalA)
        Me.PanelEx9.Controls.Add(Me.LabelX25)
        Me.PanelEx9.Controls.Add(Me.LabelX28)
        Me.PanelEx9.Controls.Add(Me.dServiceCharge)
        Me.PanelEx9.Controls.Add(Me.LabelX29)
        Me.PanelEx9.Controls.Add(Me.dInterestRate)
        Me.PanelEx9.Controls.Add(Me.LabelX31)
        Me.PanelEx9.Controls.Add(Me.iTerms)
        Me.PanelEx9.Controls.Add(Me.cbxTerms)
        Me.PanelEx9.Controls.Add(Me.LabelX32)
        Me.PanelEx9.Controls.Add(Me.dPrincipal)
        Me.PanelEx9.Controls.Add(Me.LabelX34)
        Me.PanelEx9.Controls.Add(Me.dtpApproved)
        Me.PanelEx9.Controls.Add(Me.LabelX68)
        Me.PanelEx9.Controls.Add(Me.lblCreditNumber)
        Me.PanelEx9.Controls.Add(Me.LabelX100)
        Me.PanelEx9.Controls.Add(Me.dNetProceeds_C)
        Me.PanelEx9.Controls.Add(Me.cbxProduct)
        Me.PanelEx9.Controls.Add(Me.LabelX82)
        Me.PanelEx9.Controls.Add(Me.lblExcessP)
        Me.PanelEx9.Controls.Add(Me.LabelX7)
        Me.PanelEx9.Controls.Add(Me.lblExcess)
        Me.PanelEx9.Controls.Add(Me.LabelX26)
        Me.PanelEx9.Controls.Add(Me.lblPrincipal)
        Me.PanelEx9.Controls.Add(Me.LabelX23)
        Me.PanelEx9.Controls.Add(Me.lblThreshold)
        Me.PanelEx9.Controls.Add(Me.LabelX8)
        Me.PanelEx9.Controls.Add(Me.lblTotalBooking)
        Me.PanelEx9.Controls.Add(Me.LabelX4)
        Me.PanelEx9.Controls.Add(Me.lblThresholdMessage)
        Me.PanelEx9.Controls.Add(Me.lblWarning)
        Me.PanelEx9.Controls.Add(Me.btnUpdate)
        Me.PanelEx9.Controls.Add(Me.gRequirements)
        Me.PanelEx9.Controls.Add(Me.gPassDue)
        Me.PanelEx9.Controls.Add(Me.gPayments)
        Me.PanelEx9.Controls.Add(Me.gLoans)
        Me.PanelEx9.Controls.Add(Me.gApplication)
        Me.PanelEx9.Controls.Add(Me.CbxPrefix_B)
        Me.PanelEx9.Controls.Add(Me.cbxSuffix_B)
        Me.PanelEx9.Controls.Add(Me.TxtLastN_B)
        Me.PanelEx9.Controls.Add(Me.TxtMiddleN_B)
        Me.PanelEx9.Controls.Add(Me.TxtFirstN_B)
        Me.PanelEx9.Controls.Add(Me.LabelX43)
        Me.PanelEx9.Controls.Add(Me.pb_B)
        Me.PanelEx9.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx9.Location = New System.Drawing.Point(0, 73)
        Me.PanelEx9.Name = "PanelEx9"
        Me.PanelEx9.Size = New System.Drawing.Size(1163, 599)
        Me.PanelEx9.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx9.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx9.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx9.Style.GradientAngle = 90
        Me.PanelEx9.TabIndex = 1002
        '
        'cbxOutsource
        '
        Me.cbxOutsource.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxOutsource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxOutsource.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOutsource.Location = New System.Drawing.Point(498, 192)
        Me.cbxOutsource.Name = "cbxOutsource"
        Me.cbxOutsource.Size = New System.Drawing.Size(108, 23)
        Me.cbxOutsource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxOutsource.TabIndex = 1792
        Me.cbxOutsource.Text = "Outsource CI :"
        '
        'cbxOutsourceBranch
        '
        Me.cbxOutsourceBranch.Enabled = False
        Me.cbxOutsourceBranch.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxOutsourceBranch.FormattingEnabled = True
        Me.cbxOutsourceBranch.Location = New System.Drawing.Point(611, 192)
        Me.cbxOutsourceBranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxOutsourceBranch.Name = "cbxOutsourceBranch"
        Me.cbxOutsourceBranch.Size = New System.Drawing.Size(200, 25)
        Me.cbxOutsourceBranch.TabIndex = 1791
        '
        'lblFA_C
        '
        Me.lblFA_C.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblFA_C.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFA_C.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFA_C.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFA_C.Location = New System.Drawing.Point(815, 99)
        Me.lblFA_C.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblFA_C.Name = "lblFA_C"
        Me.lblFA_C.Size = New System.Drawing.Size(127, 23)
        Me.lblFA_C.TabIndex = 1788
        Me.lblFA_C.Text = "Face Amount :"
        Me.lblFA_C.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dFA_C
        '
        '
        '
        '
        Me.dFA_C.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dFA_C.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dFA_C.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dFA_C.Enabled = False
        Me.dFA_C.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dFA_C.ForeColor = System.Drawing.Color.Black
        Me.dFA_C.Increment = 1.0R
        Me.dFA_C.Location = New System.Drawing.Point(947, 99)
        Me.dFA_C.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dFA_C.MinValue = 0.0R
        Me.dFA_C.Name = "dFA_C"
        Me.dFA_C.ShowUpDown = True
        Me.dFA_C.Size = New System.Drawing.Size(200, 23)
        Me.dFA_C.TabIndex = 1789
        '
        'cbxCI
        '
        Me.cbxCI.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxCI.FormattingEnabled = True
        Me.cbxCI.Location = New System.Drawing.Point(611, 225)
        Me.cbxCI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxCI.Name = "cbxCI"
        Me.cbxCI.Size = New System.Drawing.Size(200, 25)
        Me.cbxCI.TabIndex = 1787
        '
        'lblCI
        '
        Me.lblCI.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblCI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCI.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCI.Location = New System.Drawing.Point(479, 225)
        Me.lblCI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCI.Name = "lblCI"
        Me.lblCI.Size = New System.Drawing.Size(127, 23)
        Me.lblCI.TabIndex = 1786
        Me.lblCI.Text = "Assigned CI :"
        Me.lblCI.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(734, 161)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 23)
        Me.LabelX3.TabIndex = 1783
        Me.LabelX3.Text = "%"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(528, 161)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(77, 23)
        Me.LabelX5.TabIndex = 1782
        Me.LabelX5.Text = "%"
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX22.Location = New System.Drawing.Point(734, 130)
        Me.LabelX22.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(77, 23)
        Me.LabelX22.TabIndex = 1781
        Me.LabelX22.Text = "% / annum"
        '
        'lblInterest
        '
        Me.lblInterest.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblInterest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblInterest.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblInterest.Location = New System.Drawing.Point(528, 130)
        Me.lblInterest.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblInterest.Name = "lblInterest"
        Me.lblInterest.Size = New System.Drawing.Size(77, 23)
        Me.lblInterest.TabIndex = 1780
        Me.lblInterest.Text = "% / annum"
        '
        'dServiceChargeA
        '
        '
        '
        '
        Me.dServiceChargeA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dServiceChargeA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dServiceChargeA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dServiceChargeA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dServiceChargeA.ForeColor = System.Drawing.Color.Black
        Me.dServiceChargeA.Increment = 1.0R
        Me.dServiceChargeA.Location = New System.Drawing.Point(611, 161)
        Me.dServiceChargeA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dServiceChargeA.MinValue = 0.0R
        Me.dServiceChargeA.Name = "dServiceChargeA"
        Me.dServiceChargeA.ShowUpDown = True
        Me.dServiceChargeA.Size = New System.Drawing.Size(117, 23)
        Me.dServiceChargeA.TabIndex = 1779
        '
        'dInterestRateA
        '
        '
        '
        '
        Me.dInterestRateA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dInterestRateA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dInterestRateA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dInterestRateA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dInterestRateA.ForeColor = System.Drawing.Color.Black
        Me.dInterestRateA.Increment = 1.0R
        Me.dInterestRateA.Location = New System.Drawing.Point(611, 130)
        Me.dInterestRateA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dInterestRateA.MinValue = 0.0R
        Me.dInterestRateA.Name = "dInterestRateA"
        Me.dInterestRateA.ShowUpDown = True
        Me.dInterestRateA.Size = New System.Drawing.Size(117, 23)
        Me.dInterestRateA.TabIndex = 1778
        '
        'iTermsA
        '
        '
        '
        '
        Me.iTermsA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iTermsA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iTermsA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iTermsA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iTermsA.ForeColor = System.Drawing.Color.Black
        Me.iTermsA.Location = New System.Drawing.Point(611, 99)
        Me.iTermsA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iTermsA.MaxValue = 120
        Me.iTermsA.MinValue = 0
        Me.iTermsA.Name = "iTermsA"
        Me.iTermsA.ShowUpDown = True
        Me.iTermsA.Size = New System.Drawing.Size(72, 23)
        Me.iTermsA.TabIndex = 1776
        '
        'cbxTermsA
        '
        Me.cbxTermsA.Enabled = False
        Me.cbxTermsA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxTermsA.FormattingEnabled = True
        Me.cbxTermsA.Location = New System.Drawing.Point(689, 99)
        Me.cbxTermsA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxTermsA.Name = "cbxTermsA"
        Me.cbxTermsA.Size = New System.Drawing.Size(122, 25)
        Me.cbxTermsA.TabIndex = 1777
        '
        'dPrincipalA
        '
        '
        '
        '
        Me.dPrincipalA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dPrincipalA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dPrincipalA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dPrincipalA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dPrincipalA.ForeColor = System.Drawing.Color.Black
        Me.dPrincipalA.Increment = 1.0R
        Me.dPrincipalA.Location = New System.Drawing.Point(611, 68)
        Me.dPrincipalA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dPrincipalA.MinValue = 0.0R
        Me.dPrincipalA.Name = "dPrincipalA"
        Me.dPrincipalA.ShowUpDown = True
        Me.dPrincipalA.Size = New System.Drawing.Size(200, 23)
        Me.dPrincipalA.TabIndex = 1775
        '
        'LabelX25
        '
        Me.LabelX25.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.ForeColor = System.Drawing.Color.White
        Me.LabelX25.Location = New System.Drawing.Point(611, 38)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(200, 23)
        Me.LabelX25.TabIndex = 1774
        Me.LabelX25.Text = "Approved"
        Me.LabelX25.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX28.Location = New System.Drawing.Point(273, 161)
        Me.LabelX28.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(127, 23)
        Me.LabelX28.TabIndex = 1772
        Me.LabelX28.Text = "Service Charge :"
        Me.LabelX28.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dServiceCharge
        '
        '
        '
        '
        Me.dServiceCharge.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dServiceCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dServiceCharge.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dServiceCharge.Enabled = False
        Me.dServiceCharge.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dServiceCharge.ForeColor = System.Drawing.Color.Black
        Me.dServiceCharge.Increment = 1.0R
        Me.dServiceCharge.Location = New System.Drawing.Point(405, 161)
        Me.dServiceCharge.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dServiceCharge.MinValue = 0.0R
        Me.dServiceCharge.Name = "dServiceCharge"
        Me.dServiceCharge.ShowUpDown = True
        Me.dServiceCharge.Size = New System.Drawing.Size(117, 23)
        Me.dServiceCharge.TabIndex = 1773
        '
        'LabelX29
        '
        Me.LabelX29.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX29.Location = New System.Drawing.Point(273, 130)
        Me.LabelX29.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(127, 23)
        Me.LabelX29.TabIndex = 1770
        Me.LabelX29.Text = "Interest Rate :"
        Me.LabelX29.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dInterestRate
        '
        '
        '
        '
        Me.dInterestRate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dInterestRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dInterestRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dInterestRate.Enabled = False
        Me.dInterestRate.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dInterestRate.ForeColor = System.Drawing.Color.Black
        Me.dInterestRate.Increment = 1.0R
        Me.dInterestRate.Location = New System.Drawing.Point(405, 130)
        Me.dInterestRate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dInterestRate.MinValue = 0.0R
        Me.dInterestRate.Name = "dInterestRate"
        Me.dInterestRate.ShowUpDown = True
        Me.dInterestRate.Size = New System.Drawing.Size(117, 23)
        Me.dInterestRate.TabIndex = 1771
        '
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX31.Location = New System.Drawing.Point(273, 99)
        Me.LabelX31.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(126, 23)
        Me.LabelX31.TabIndex = 1767
        Me.LabelX31.Text = "Term :"
        Me.LabelX31.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iTerms
        '
        '
        '
        '
        Me.iTerms.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iTerms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iTerms.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iTerms.Enabled = False
        Me.iTerms.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iTerms.Location = New System.Drawing.Point(405, 99)
        Me.iTerms.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iTerms.MaxValue = 120
        Me.iTerms.MinValue = 0
        Me.iTerms.Name = "iTerms"
        Me.iTerms.ShowUpDown = True
        Me.iTerms.Size = New System.Drawing.Size(72, 23)
        Me.iTerms.TabIndex = 1768
        '
        'cbxTerms
        '
        Me.cbxTerms.Enabled = False
        Me.cbxTerms.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxTerms.FormattingEnabled = True
        Me.cbxTerms.Location = New System.Drawing.Point(483, 99)
        Me.cbxTerms.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxTerms.Name = "cbxTerms"
        Me.cbxTerms.Size = New System.Drawing.Size(122, 25)
        Me.cbxTerms.TabIndex = 1769
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX32.Location = New System.Drawing.Point(273, 68)
        Me.LabelX32.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(127, 23)
        Me.LabelX32.TabIndex = 1765
        Me.LabelX32.Text = "Principal :"
        Me.LabelX32.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dPrincipal
        '
        '
        '
        '
        Me.dPrincipal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dPrincipal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dPrincipal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dPrincipal.Enabled = False
        Me.dPrincipal.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dPrincipal.ForeColor = System.Drawing.Color.Black
        Me.dPrincipal.Increment = 1.0R
        Me.dPrincipal.Location = New System.Drawing.Point(405, 68)
        Me.dPrincipal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dPrincipal.MinValue = 0.0R
        Me.dPrincipal.Name = "dPrincipal"
        Me.dPrincipal.ShowUpDown = True
        Me.dPrincipal.Size = New System.Drawing.Size(200, 23)
        Me.dPrincipal.TabIndex = 1766
        '
        'LabelX34
        '
        Me.LabelX34.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX34.ForeColor = System.Drawing.Color.White
        Me.LabelX34.Location = New System.Drawing.Point(405, 38)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(200, 23)
        Me.LabelX34.TabIndex = 1764
        Me.LabelX34.Text = "Request"
        Me.LabelX34.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'dtpApproved
        '
        '
        '
        '
        Me.dtpApproved.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpApproved.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpApproved.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpApproved.ButtonDropDown.Visible = True
        Me.dtpApproved.CustomFormat = "MMMM dd, yyyy"
        Me.dtpApproved.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpApproved.ForeColor = System.Drawing.Color.Black
        Me.dtpApproved.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpApproved.IsPopupCalendarOpen = False
        Me.dtpApproved.Location = New System.Drawing.Point(947, 161)
        '
        '
        '
        Me.dtpApproved.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpApproved.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpApproved.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpApproved.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpApproved.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpApproved.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpApproved.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpApproved.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpApproved.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpApproved.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpApproved.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpApproved.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpApproved.MonthCalendar.TodayButtonVisible = True
        Me.dtpApproved.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpApproved.Name = "dtpApproved"
        Me.dtpApproved.Size = New System.Drawing.Size(200, 23)
        Me.dtpApproved.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpApproved.TabIndex = 1761
        Me.dtpApproved.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX68
        '
        Me.LabelX68.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX68.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX68.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX68.Location = New System.Drawing.Point(815, 161)
        Me.LabelX68.Name = "LabelX68"
        Me.LabelX68.Size = New System.Drawing.Size(127, 23)
        Me.LabelX68.TabIndex = 1760
        Me.LabelX68.Text = "Approved Date :"
        Me.LabelX68.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCreditNumber
        '
        Me.lblCreditNumber.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblCreditNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCreditNumber.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditNumber.ForeColor = System.Drawing.Color.Red
        Me.lblCreditNumber.Location = New System.Drawing.Point(817, 192)
        Me.lblCreditNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCreditNumber.Name = "lblCreditNumber"
        Me.lblCreditNumber.Size = New System.Drawing.Size(330, 58)
        Me.lblCreditNumber.TabIndex = 1759
        Me.lblCreditNumber.Text = "CI000201704-0001"
        Me.lblCreditNumber.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX100
        '
        Me.LabelX100.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX100.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX100.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelX100.ForeColor = System.Drawing.Color.Red
        Me.LabelX100.Location = New System.Drawing.Point(815, 130)
        Me.LabelX100.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX100.Name = "LabelX100"
        Me.LabelX100.Size = New System.Drawing.Size(127, 23)
        Me.LabelX100.TabIndex = 1758
        Me.LabelX100.Text = "Net Proceeds :"
        Me.LabelX100.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dNetProceeds_C
        '
        '
        '
        '
        Me.dNetProceeds_C.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dNetProceeds_C.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dNetProceeds_C.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dNetProceeds_C.Enabled = False
        Me.dNetProceeds_C.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dNetProceeds_C.ForeColor = System.Drawing.Color.Red
        Me.dNetProceeds_C.Increment = 1.0R
        Me.dNetProceeds_C.Location = New System.Drawing.Point(947, 130)
        Me.dNetProceeds_C.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dNetProceeds_C.MinValue = 0.0R
        Me.dNetProceeds_C.Name = "dNetProceeds_C"
        Me.dNetProceeds_C.ShowUpDown = True
        Me.dNetProceeds_C.Size = New System.Drawing.Size(200, 23)
        Me.dNetProceeds_C.TabIndex = 1757
        '
        'cbxProduct
        '
        Me.cbxProduct.Enabled = False
        Me.cbxProduct.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProduct.FormattingEnabled = True
        Me.cbxProduct.Location = New System.Drawing.Point(947, 68)
        Me.cbxProduct.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxProduct.Name = "cbxProduct"
        Me.cbxProduct.Size = New System.Drawing.Size(200, 25)
        Me.cbxProduct.TabIndex = 1752
        '
        'LabelX82
        '
        Me.LabelX82.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX82.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX82.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX82.Location = New System.Drawing.Point(815, 68)
        Me.LabelX82.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX82.Name = "LabelX82"
        Me.LabelX82.Size = New System.Drawing.Size(127, 23)
        Me.LabelX82.TabIndex = 1751
        Me.LabelX82.Text = "Product : "
        Me.LabelX82.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblExcessP
        '
        Me.lblExcessP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExcessP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExcessP.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExcessP.ForeColor = System.Drawing.Color.Red
        Me.lblExcessP.Location = New System.Drawing.Point(1031, 518)
        Me.lblExcessP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblExcessP.Name = "lblExcessP"
        Me.lblExcessP.Size = New System.Drawing.Size(120, 23)
        Me.lblExcessP.TabIndex = 1721
        Me.lblExcessP.Text = "10.00%"
        Me.lblExcessP.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblExcessP.Visible = False
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Red
        Me.LabelX7.Location = New System.Drawing.Point(930, 518)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(95, 23)
        Me.LabelX7.TabIndex = 1720
        Me.LabelX7.Text = "Excess % :"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX7.Visible = False
        '
        'lblExcess
        '
        Me.lblExcess.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExcess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExcess.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExcess.ForeColor = System.Drawing.Color.Red
        Me.lblExcess.Location = New System.Drawing.Point(1031, 487)
        Me.lblExcess.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblExcess.Name = "lblExcess"
        Me.lblExcess.Size = New System.Drawing.Size(120, 23)
        Me.lblExcess.TabIndex = 1719
        Me.lblExcess.Text = "100,000.00"
        Me.lblExcess.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblExcess.Visible = False
        '
        'LabelX26
        '
        Me.LabelX26.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX26.ForeColor = System.Drawing.Color.Red
        Me.LabelX26.Location = New System.Drawing.Point(930, 487)
        Me.LabelX26.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(95, 23)
        Me.LabelX26.TabIndex = 1718
        Me.LabelX26.Text = "Excess :"
        Me.LabelX26.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX26.Visible = False
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblPrincipal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPrincipal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal.ForeColor = System.Drawing.Color.Red
        Me.lblPrincipal.Location = New System.Drawing.Point(1031, 456)
        Me.lblPrincipal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Size = New System.Drawing.Size(120, 23)
        Me.lblPrincipal.TabIndex = 1717
        Me.lblPrincipal.Text = "100,000.00"
        Me.lblPrincipal.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblPrincipal.Visible = False
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.Red
        Me.LabelX23.Location = New System.Drawing.Point(930, 456)
        Me.LabelX23.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(95, 23)
        Me.LabelX23.TabIndex = 1716
        Me.LabelX23.Text = "Principal :"
        Me.LabelX23.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX23.Visible = False
        '
        'lblThreshold
        '
        Me.lblThreshold.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblThreshold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblThreshold.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThreshold.ForeColor = System.Drawing.Color.Red
        Me.lblThreshold.Location = New System.Drawing.Point(1031, 425)
        Me.lblThreshold.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblThreshold.Name = "lblThreshold"
        Me.lblThreshold.Size = New System.Drawing.Size(120, 23)
        Me.lblThreshold.TabIndex = 1715
        Me.lblThreshold.Text = "100,000.00"
        Me.lblThreshold.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblThreshold.Visible = False
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Red
        Me.LabelX8.Location = New System.Drawing.Point(930, 425)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(95, 23)
        Me.LabelX8.TabIndex = 1714
        Me.LabelX8.Text = "Threshold :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX8.Visible = False
        '
        'lblTotalBooking
        '
        Me.lblTotalBooking.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotalBooking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotalBooking.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBooking.ForeColor = System.Drawing.Color.Red
        Me.lblTotalBooking.Location = New System.Drawing.Point(1031, 394)
        Me.lblTotalBooking.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTotalBooking.Name = "lblTotalBooking"
        Me.lblTotalBooking.Size = New System.Drawing.Size(120, 23)
        Me.lblTotalBooking.TabIndex = 1713
        Me.lblTotalBooking.Text = "100,000.00"
        Me.lblTotalBooking.TextAlignment = System.Drawing.StringAlignment.Far
        Me.lblTotalBooking.Visible = False
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Red
        Me.LabelX4.Location = New System.Drawing.Point(930, 394)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 23)
        Me.LabelX4.TabIndex = 1712
        Me.LabelX4.Text = "Total Booking :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX4.Visible = False
        '
        'lblThresholdMessage
        '
        Me.lblThresholdMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblThresholdMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblThresholdMessage.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThresholdMessage.ForeColor = System.Drawing.Color.Red
        Me.lblThresholdMessage.Location = New System.Drawing.Point(930, 325)
        Me.lblThresholdMessage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblThresholdMessage.Name = "lblThresholdMessage"
        Me.lblThresholdMessage.Size = New System.Drawing.Size(230, 64)
        Me.lblThresholdMessage.TabIndex = 1711
        Me.lblThresholdMessage.Text = "Approved principal amount has reached or exceeded to its threshold amount for Pro" &
    "duct."
        Me.lblThresholdMessage.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.lblThresholdMessage.WordWrap = True
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWarning.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(932, 270)
        Me.lblWarning.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(228, 47)
        Me.lblWarning.TabIndex = 1710
        Me.lblWarning.Text = "Warning!!!"
        Me.lblWarning.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblWarning.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnUpdate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnUpdate.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnUpdate.Location = New System.Drawing.Point(817, 36)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(107, 30)
        Me.btnUpdate.TabIndex = 1707
        Me.btnUpdate.Text = "Update Computation"
        Me.btnUpdate.Visible = False
        '
        'gRequirements
        '
        Me.gRequirements.Appearance.BackColor = System.Drawing.Color.White
        Me.gRequirements.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gRequirements.Appearance.Options.UseBackColor = True
        Me.gRequirements.Appearance.Options.UseFont = True
        Me.gRequirements.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gRequirements.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gRequirements.AppearanceCaption.Options.UseFont = True
        Me.gRequirements.AppearanceCaption.Options.UseForeColor = True
        Me.gRequirements.Controls.Add(Me.lblIncP)
        Me.gRequirements.Controls.Add(Me.lblCompP)
        Me.gRequirements.Controls.Add(Me.lblIncN)
        Me.gRequirements.Controls.Add(Me.lblCompN)
        Me.gRequirements.Controls.Add(Me.LabelX10)
        Me.gRequirements.Controls.Add(Me.LabelX11)
        Me.gRequirements.Controls.Add(Me.LabelX12)
        Me.gRequirements.Controls.Add(Me.LabelX17)
        Me.gRequirements.Location = New System.Drawing.Point(6, 270)
        Me.gRequirements.LookAndFeel.SkinName = "Darkroom"
        Me.gRequirements.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gRequirements.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gRequirements.Name = "gRequirements"
        Me.gRequirements.Size = New System.Drawing.Size(273, 127)
        Me.gRequirements.TabIndex = 1706
        Me.gRequirements.Text = "Submitted Requirements"
        '
        'lblIncP
        '
        '
        '
        '
        Me.lblIncP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblIncP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblIncP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblIncP.Location = New System.Drawing.Point(191, 94)
        Me.lblIncP.Name = "lblIncP"
        Me.lblIncP.Size = New System.Drawing.Size(80, 25)
        Me.lblIncP.TabIndex = 1044
        Me.lblIncP.Text = "0.00 %"
        Me.lblIncP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCompP
        '
        '
        '
        '
        Me.lblCompP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCompP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCompP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCompP.Location = New System.Drawing.Point(191, 63)
        Me.lblCompP.Name = "lblCompP"
        Me.lblCompP.Size = New System.Drawing.Size(80, 25)
        Me.lblCompP.TabIndex = 1043
        Me.lblCompP.Text = "0.00 %"
        Me.lblCompP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblIncN
        '
        '
        '
        '
        Me.lblIncN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblIncN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblIncN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblIncN.Location = New System.Drawing.Point(105, 94)
        Me.lblIncN.Name = "lblIncN"
        Me.lblIncN.Size = New System.Drawing.Size(80, 25)
        Me.lblIncN.TabIndex = 1042
        Me.lblIncN.Text = "0"
        Me.lblIncN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCompN
        '
        '
        '
        '
        Me.lblCompN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCompN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCompN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCompN.Location = New System.Drawing.Point(105, 63)
        Me.lblCompN.Name = "lblCompN"
        Me.lblCompN.Size = New System.Drawing.Size(80, 25)
        Me.lblCompN.TabIndex = 1041
        Me.lblCompN.Text = "0"
        Me.lblCompN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX10.Location = New System.Drawing.Point(191, 32)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(80, 25)
        Me.LabelX10.TabIndex = 1040
        Me.LabelX10.Text = "Percentage"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX11.Location = New System.Drawing.Point(105, 32)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(80, 25)
        Me.LabelX11.TabIndex = 1039
        Me.LabelX11.Text = "Number"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX12.Location = New System.Drawing.Point(5, 94)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(94, 25)
        Me.LabelX12.TabIndex = 1038
        Me.LabelX12.Text = "INC :"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(5, 63)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(94, 25)
        Me.LabelX17.TabIndex = 1037
        Me.LabelX17.Text = "Complete :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gPassDue
        '
        Me.gPassDue.Appearance.BackColor = System.Drawing.Color.White
        Me.gPassDue.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gPassDue.Appearance.Options.UseBackColor = True
        Me.gPassDue.Appearance.Options.UseFont = True
        Me.gPassDue.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gPassDue.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gPassDue.AppearanceCaption.Options.UseFont = True
        Me.gPassDue.AppearanceCaption.Options.UseForeColor = True
        Me.gPassDue.Controls.Add(Me.LabelX37)
        Me.gPassDue.Controls.Add(Me.lblMaximum)
        Me.gPassDue.Controls.Add(Me.LabelX39)
        Me.gPassDue.Controls.Add(Me.LabelX49)
        Me.gPassDue.Controls.Add(Me.LabelX50)
        Me.gPassDue.Controls.Add(Me.lblMinimum)
        Me.gPassDue.Controls.Add(Me.lblAverageN)
        Me.gPassDue.Controls.Add(Me.LabelX54)
        Me.gPassDue.Controls.Add(Me.LabelX55)
        Me.gPassDue.Controls.Add(Me.LabelX56)
        Me.gPassDue.Location = New System.Drawing.Point(653, 402)
        Me.gPassDue.LookAndFeel.SkinName = "Darkroom"
        Me.gPassDue.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gPassDue.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gPassDue.Name = "gPassDue"
        Me.gPassDue.Size = New System.Drawing.Size(273, 158)
        Me.gPassDue.TabIndex = 1704
        Me.gPassDue.Text = "Days of Past Due"
        '
        'LabelX37
        '
        '
        '
        '
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX37.Location = New System.Drawing.Point(191, 125)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(80, 25)
        Me.LabelX37.TabIndex = 1047
        Me.LabelX37.Text = "Day(s)"
        Me.LabelX37.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMaximum
        '
        '
        '
        '
        Me.lblMaximum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMaximum.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMaximum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblMaximum.Location = New System.Drawing.Point(105, 125)
        Me.lblMaximum.Name = "lblMaximum"
        Me.lblMaximum.Size = New System.Drawing.Size(80, 25)
        Me.lblMaximum.TabIndex = 1046
        Me.lblMaximum.Text = "0"
        Me.lblMaximum.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX39
        '
        '
        '
        '
        Me.LabelX39.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX39.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX39.Location = New System.Drawing.Point(5, 125)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.Size = New System.Drawing.Size(94, 25)
        Me.LabelX39.TabIndex = 1045
        Me.LabelX39.Text = "Maximum :"
        Me.LabelX39.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX49
        '
        '
        '
        '
        Me.LabelX49.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX49.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX49.Location = New System.Drawing.Point(191, 94)
        Me.LabelX49.Name = "LabelX49"
        Me.LabelX49.Size = New System.Drawing.Size(80, 25)
        Me.LabelX49.TabIndex = 1044
        Me.LabelX49.Text = "Day(s)"
        Me.LabelX49.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX50
        '
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX50.Location = New System.Drawing.Point(191, 63)
        Me.LabelX50.Name = "LabelX50"
        Me.LabelX50.Size = New System.Drawing.Size(80, 25)
        Me.LabelX50.TabIndex = 1043
        Me.LabelX50.Text = "Day(s)"
        Me.LabelX50.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMinimum
        '
        '
        '
        '
        Me.lblMinimum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMinimum.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMinimum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblMinimum.Location = New System.Drawing.Point(105, 94)
        Me.lblMinimum.Name = "lblMinimum"
        Me.lblMinimum.Size = New System.Drawing.Size(80, 25)
        Me.lblMinimum.TabIndex = 1042
        Me.lblMinimum.Text = "0"
        Me.lblMinimum.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblAverageN
        '
        '
        '
        '
        Me.lblAverageN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAverageN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblAverageN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAverageN.Location = New System.Drawing.Point(105, 63)
        Me.lblAverageN.Name = "lblAverageN"
        Me.lblAverageN.Size = New System.Drawing.Size(80, 25)
        Me.lblAverageN.TabIndex = 1041
        Me.lblAverageN.Text = "0"
        Me.lblAverageN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX54
        '
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX54.Location = New System.Drawing.Point(105, 32)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(80, 25)
        Me.LabelX54.TabIndex = 1039
        Me.LabelX54.Text = "Number"
        Me.LabelX54.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX55
        '
        '
        '
        '
        Me.LabelX55.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX55.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX55.Location = New System.Drawing.Point(5, 94)
        Me.LabelX55.Name = "LabelX55"
        Me.LabelX55.Size = New System.Drawing.Size(94, 25)
        Me.LabelX55.TabIndex = 1038
        Me.LabelX55.Text = "Minimum :"
        Me.LabelX55.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX56
        '
        '
        '
        '
        Me.LabelX56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX56.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX56.Location = New System.Drawing.Point(5, 63)
        Me.LabelX56.Name = "LabelX56"
        Me.LabelX56.Size = New System.Drawing.Size(94, 25)
        Me.LabelX56.TabIndex = 1037
        Me.LabelX56.Text = "Average :"
        Me.LabelX56.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gPayments
        '
        Me.gPayments.Appearance.BackColor = System.Drawing.Color.White
        Me.gPayments.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gPayments.Appearance.Options.UseBackColor = True
        Me.gPayments.Appearance.Options.UseFont = True
        Me.gPayments.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gPayments.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gPayments.AppearanceCaption.Options.UseFont = True
        Me.gPayments.AppearanceCaption.Options.UseForeColor = True
        Me.gPayments.Controls.Add(Me.lblPassP)
        Me.gPayments.Controls.Add(Me.lblAdvanceP)
        Me.gPayments.Controls.Add(Me.lblPassN)
        Me.gPayments.Controls.Add(Me.lblAdvanceN)
        Me.gPayments.Controls.Add(Me.LabelX45)
        Me.gPayments.Controls.Add(Me.LabelX46)
        Me.gPayments.Controls.Add(Me.LabelX47)
        Me.gPayments.Controls.Add(Me.LabelX48)
        Me.gPayments.Location = New System.Drawing.Point(653, 269)
        Me.gPayments.LookAndFeel.SkinName = "Darkroom"
        Me.gPayments.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gPayments.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gPayments.Name = "gPayments"
        Me.gPayments.Size = New System.Drawing.Size(273, 127)
        Me.gPayments.TabIndex = 1703
        Me.gPayments.Text = "Total Payments Made"
        '
        'lblPassP
        '
        '
        '
        '
        Me.lblPassP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPassP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPassP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPassP.Location = New System.Drawing.Point(191, 94)
        Me.lblPassP.Name = "lblPassP"
        Me.lblPassP.Size = New System.Drawing.Size(80, 25)
        Me.lblPassP.TabIndex = 1044
        Me.lblPassP.Text = "0.00 %"
        Me.lblPassP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblAdvanceP
        '
        '
        '
        '
        Me.lblAdvanceP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAdvanceP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblAdvanceP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAdvanceP.Location = New System.Drawing.Point(191, 63)
        Me.lblAdvanceP.Name = "lblAdvanceP"
        Me.lblAdvanceP.Size = New System.Drawing.Size(80, 25)
        Me.lblAdvanceP.TabIndex = 1043
        Me.lblAdvanceP.Text = "0.00 %"
        Me.lblAdvanceP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblPassN
        '
        '
        '
        '
        Me.lblPassN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPassN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPassN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPassN.Location = New System.Drawing.Point(105, 94)
        Me.lblPassN.Name = "lblPassN"
        Me.lblPassN.Size = New System.Drawing.Size(80, 25)
        Me.lblPassN.TabIndex = 1042
        Me.lblPassN.Text = "0"
        Me.lblPassN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblAdvanceN
        '
        '
        '
        '
        Me.lblAdvanceN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAdvanceN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblAdvanceN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAdvanceN.Location = New System.Drawing.Point(105, 63)
        Me.lblAdvanceN.Name = "lblAdvanceN"
        Me.lblAdvanceN.Size = New System.Drawing.Size(80, 25)
        Me.lblAdvanceN.TabIndex = 1041
        Me.lblAdvanceN.Text = "0"
        Me.lblAdvanceN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX45
        '
        '
        '
        '
        Me.LabelX45.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX45.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX45.Location = New System.Drawing.Point(191, 32)
        Me.LabelX45.Name = "LabelX45"
        Me.LabelX45.Size = New System.Drawing.Size(80, 25)
        Me.LabelX45.TabIndex = 1040
        Me.LabelX45.Text = "Percentage"
        Me.LabelX45.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX46
        '
        '
        '
        '
        Me.LabelX46.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX46.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX46.Location = New System.Drawing.Point(105, 32)
        Me.LabelX46.Name = "LabelX46"
        Me.LabelX46.Size = New System.Drawing.Size(80, 25)
        Me.LabelX46.TabIndex = 1039
        Me.LabelX46.Text = "Number"
        Me.LabelX46.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX47
        '
        '
        '
        '
        Me.LabelX47.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX47.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX47.Location = New System.Drawing.Point(5, 94)
        Me.LabelX47.Name = "LabelX47"
        Me.LabelX47.Size = New System.Drawing.Size(94, 25)
        Me.LabelX47.TabIndex = 1038
        Me.LabelX47.Text = "Past Due :"
        Me.LabelX47.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX48
        '
        '
        '
        '
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX48.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX48.Location = New System.Drawing.Point(5, 63)
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Size = New System.Drawing.Size(94, 25)
        Me.LabelX48.TabIndex = 1037
        Me.LabelX48.Text = "Advance :"
        Me.LabelX48.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gLoans
        '
        Me.gLoans.Appearance.BackColor = System.Drawing.Color.White
        Me.gLoans.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gLoans.Appearance.Options.UseBackColor = True
        Me.gLoans.Appearance.Options.UseFont = True
        Me.gLoans.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gLoans.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gLoans.AppearanceCaption.Options.UseFont = True
        Me.gLoans.AppearanceCaption.Options.UseForeColor = True
        Me.gLoans.Controls.Add(Me.lblCheckP)
        Me.gLoans.Controls.Add(Me.lblCheckN)
        Me.gLoans.Controls.Add(Me.LabelX30)
        Me.gLoans.Controls.Add(Me.lblShowmoneyP)
        Me.gLoans.Controls.Add(Me.lblShowmoneyN)
        Me.gLoans.Controls.Add(Me.LabelX33)
        Me.gLoans.Controls.Add(Me.lblPaydayP)
        Me.gLoans.Controls.Add(Me.lblPaydayN)
        Me.gLoans.Controls.Add(Me.LabelX36)
        Me.gLoans.Controls.Add(Me.lblSalarySisterP)
        Me.gLoans.Controls.Add(Me.lblSalarySisterN)
        Me.gLoans.Controls.Add(Me.LabelX27)
        Me.gLoans.Controls.Add(Me.lblSalaryP)
        Me.gLoans.Controls.Add(Me.lblSalaryN)
        Me.gLoans.Controls.Add(Me.LabelX24)
        Me.gLoans.Controls.Add(Me.lblCarP)
        Me.gLoans.Controls.Add(Me.lblCarN)
        Me.gLoans.Controls.Add(Me.LabelX9)
        Me.gLoans.Controls.Add(Me.lblRealEstateP)
        Me.gLoans.Controls.Add(Me.lblVehicleP)
        Me.gLoans.Controls.Add(Me.lblRealEstateN)
        Me.gLoans.Controls.Add(Me.lblVehicleN)
        Me.gLoans.Controls.Add(Me.LabelX18)
        Me.gLoans.Controls.Add(Me.LabelX19)
        Me.gLoans.Controls.Add(Me.LabelX20)
        Me.gLoans.Controls.Add(Me.LabelX21)
        Me.gLoans.Location = New System.Drawing.Point(285, 270)
        Me.gLoans.LookAndFeel.SkinName = "Darkroom"
        Me.gLoans.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gLoans.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gLoans.Name = "gLoans"
        Me.gLoans.Size = New System.Drawing.Size(362, 322)
        Me.gLoans.TabIndex = 1702
        Me.gLoans.Text = "Total Number of Loans"
        '
        'lblCheckP
        '
        '
        '
        '
        Me.lblCheckP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCheckP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCheckP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCheckP.Location = New System.Drawing.Point(276, 279)
        Me.lblCheckP.Name = "lblCheckP"
        Me.lblCheckP.Size = New System.Drawing.Size(80, 25)
        Me.lblCheckP.TabIndex = 1062
        Me.lblCheckP.Text = "0.00 %"
        Me.lblCheckP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCheckN
        '
        '
        '
        '
        Me.lblCheckN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCheckN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCheckN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCheckN.Location = New System.Drawing.Point(190, 279)
        Me.lblCheckN.Name = "lblCheckN"
        Me.lblCheckN.Size = New System.Drawing.Size(80, 25)
        Me.lblCheckN.TabIndex = 1061
        Me.lblCheckN.Text = "0"
        Me.lblCheckN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX30
        '
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX30.Location = New System.Drawing.Point(5, 280)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(187, 25)
        Me.LabelX30.TabIndex = 1060
        Me.LabelX30.Text = "Check Rediscounting Loan :"
        Me.LabelX30.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblShowmoneyP
        '
        '
        '
        '
        Me.lblShowmoneyP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblShowmoneyP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblShowmoneyP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblShowmoneyP.Location = New System.Drawing.Point(276, 248)
        Me.lblShowmoneyP.Name = "lblShowmoneyP"
        Me.lblShowmoneyP.Size = New System.Drawing.Size(80, 25)
        Me.lblShowmoneyP.TabIndex = 1059
        Me.lblShowmoneyP.Text = "0.00 %"
        Me.lblShowmoneyP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblShowmoneyN
        '
        '
        '
        '
        Me.lblShowmoneyN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblShowmoneyN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblShowmoneyN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblShowmoneyN.Location = New System.Drawing.Point(190, 248)
        Me.lblShowmoneyN.Name = "lblShowmoneyN"
        Me.lblShowmoneyN.Size = New System.Drawing.Size(80, 25)
        Me.lblShowmoneyN.TabIndex = 1058
        Me.lblShowmoneyN.Text = "0"
        Me.lblShowmoneyN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX33
        '
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX33.Location = New System.Drawing.Point(5, 249)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(187, 25)
        Me.LabelX33.TabIndex = 1057
        Me.LabelX33.Text = "Showmoney Loan :"
        Me.LabelX33.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblPaydayP
        '
        '
        '
        '
        Me.lblPaydayP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPaydayP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPaydayP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPaydayP.Location = New System.Drawing.Point(276, 217)
        Me.lblPaydayP.Name = "lblPaydayP"
        Me.lblPaydayP.Size = New System.Drawing.Size(80, 25)
        Me.lblPaydayP.TabIndex = 1056
        Me.lblPaydayP.Text = "0.00 %"
        Me.lblPaydayP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblPaydayN
        '
        '
        '
        '
        Me.lblPaydayN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPaydayN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPaydayN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPaydayN.Location = New System.Drawing.Point(190, 217)
        Me.lblPaydayN.Name = "lblPaydayN"
        Me.lblPaydayN.Size = New System.Drawing.Size(80, 25)
        Me.lblPaydayN.TabIndex = 1055
        Me.lblPaydayN.Text = "0"
        Me.lblPaydayN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX36
        '
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX36.Location = New System.Drawing.Point(5, 218)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(187, 25)
        Me.LabelX36.TabIndex = 1054
        Me.LabelX36.Text = "Payday Loan :"
        Me.LabelX36.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblSalarySisterP
        '
        '
        '
        '
        Me.lblSalarySisterP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSalarySisterP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSalarySisterP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblSalarySisterP.Location = New System.Drawing.Point(276, 186)
        Me.lblSalarySisterP.Name = "lblSalarySisterP"
        Me.lblSalarySisterP.Size = New System.Drawing.Size(80, 25)
        Me.lblSalarySisterP.TabIndex = 1053
        Me.lblSalarySisterP.Text = "0.00 %"
        Me.lblSalarySisterP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblSalarySisterN
        '
        '
        '
        '
        Me.lblSalarySisterN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSalarySisterN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSalarySisterN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblSalarySisterN.Location = New System.Drawing.Point(190, 186)
        Me.lblSalarySisterN.Name = "lblSalarySisterN"
        Me.lblSalarySisterN.Size = New System.Drawing.Size(80, 25)
        Me.lblSalarySisterN.TabIndex = 1052
        Me.lblSalarySisterN.Text = "0"
        Me.lblSalarySisterN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX27
        '
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX27.Location = New System.Drawing.Point(5, 187)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(187, 25)
        Me.LabelX27.TabIndex = 1051
        Me.LabelX27.Text = "Salary Loan-Sister Company :"
        Me.LabelX27.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblSalaryP
        '
        '
        '
        '
        Me.lblSalaryP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSalaryP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSalaryP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblSalaryP.Location = New System.Drawing.Point(276, 155)
        Me.lblSalaryP.Name = "lblSalaryP"
        Me.lblSalaryP.Size = New System.Drawing.Size(80, 25)
        Me.lblSalaryP.TabIndex = 1050
        Me.lblSalaryP.Text = "0.00 %"
        Me.lblSalaryP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblSalaryN
        '
        '
        '
        '
        Me.lblSalaryN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSalaryN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSalaryN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblSalaryN.Location = New System.Drawing.Point(190, 155)
        Me.lblSalaryN.Name = "lblSalaryN"
        Me.lblSalaryN.Size = New System.Drawing.Size(80, 25)
        Me.lblSalaryN.TabIndex = 1049
        Me.lblSalaryN.Text = "0"
        Me.lblSalaryN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX24
        '
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX24.Location = New System.Drawing.Point(5, 156)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(187, 25)
        Me.LabelX24.TabIndex = 1048
        Me.LabelX24.Text = "Salary Loan-FSFC :"
        Me.LabelX24.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCarP
        '
        '
        '
        '
        Me.lblCarP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCarP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCarP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCarP.Location = New System.Drawing.Point(276, 124)
        Me.lblCarP.Name = "lblCarP"
        Me.lblCarP.Size = New System.Drawing.Size(80, 25)
        Me.lblCarP.TabIndex = 1047
        Me.lblCarP.Text = "0.00 %"
        Me.lblCarP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCarN
        '
        '
        '
        '
        Me.lblCarN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCarN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCarN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCarN.Location = New System.Drawing.Point(190, 124)
        Me.lblCarN.Name = "lblCarN"
        Me.lblCarN.Size = New System.Drawing.Size(80, 25)
        Me.lblCarN.TabIndex = 1046
        Me.lblCarN.Text = "0"
        Me.lblCarN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX9.Location = New System.Drawing.Point(5, 125)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(187, 25)
        Me.LabelX9.TabIndex = 1045
        Me.LabelX9.Text = "Car Dealership Loan : "
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblRealEstateP
        '
        '
        '
        '
        Me.lblRealEstateP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRealEstateP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblRealEstateP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblRealEstateP.Location = New System.Drawing.Point(276, 93)
        Me.lblRealEstateP.Name = "lblRealEstateP"
        Me.lblRealEstateP.Size = New System.Drawing.Size(80, 25)
        Me.lblRealEstateP.TabIndex = 1044
        Me.lblRealEstateP.Text = "0.00 %"
        Me.lblRealEstateP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblVehicleP
        '
        '
        '
        '
        Me.lblVehicleP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblVehicleP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblVehicleP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblVehicleP.Location = New System.Drawing.Point(276, 62)
        Me.lblVehicleP.Name = "lblVehicleP"
        Me.lblVehicleP.Size = New System.Drawing.Size(80, 25)
        Me.lblVehicleP.TabIndex = 1043
        Me.lblVehicleP.Text = "0.00 %"
        Me.lblVehicleP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblRealEstateN
        '
        '
        '
        '
        Me.lblRealEstateN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRealEstateN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblRealEstateN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblRealEstateN.Location = New System.Drawing.Point(190, 93)
        Me.lblRealEstateN.Name = "lblRealEstateN"
        Me.lblRealEstateN.Size = New System.Drawing.Size(80, 25)
        Me.lblRealEstateN.TabIndex = 1042
        Me.lblRealEstateN.Text = "0"
        Me.lblRealEstateN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblVehicleN
        '
        '
        '
        '
        Me.lblVehicleN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblVehicleN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblVehicleN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblVehicleN.Location = New System.Drawing.Point(190, 62)
        Me.lblVehicleN.Name = "lblVehicleN"
        Me.lblVehicleN.Size = New System.Drawing.Size(80, 25)
        Me.lblVehicleN.TabIndex = 1041
        Me.lblVehicleN.Text = "0"
        Me.lblVehicleN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX18.Location = New System.Drawing.Point(276, 31)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(80, 25)
        Me.LabelX18.TabIndex = 1040
        Me.LabelX18.Text = "Percentage"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX19.Location = New System.Drawing.Point(190, 31)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(80, 25)
        Me.LabelX19.TabIndex = 1039
        Me.LabelX19.Text = "Number"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX20.Location = New System.Drawing.Point(5, 94)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(187, 25)
        Me.LabelX20.TabIndex = 1038
        Me.LabelX20.Text = "Real Estate Loan :"
        Me.LabelX20.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX21.Location = New System.Drawing.Point(5, 63)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(187, 25)
        Me.LabelX21.TabIndex = 1037
        Me.LabelX21.Text = "Vehicle Loan :"
        Me.LabelX21.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gApplication
        '
        Me.gApplication.Appearance.BackColor = System.Drawing.Color.White
        Me.gApplication.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gApplication.Appearance.Options.UseBackColor = True
        Me.gApplication.Appearance.Options.UseFont = True
        Me.gApplication.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gApplication.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gApplication.AppearanceCaption.Options.UseFont = True
        Me.gApplication.AppearanceCaption.Options.UseForeColor = True
        Me.gApplication.Controls.Add(Me.lblDisapprovedP)
        Me.gApplication.Controls.Add(Me.lblDisapprovedN)
        Me.gApplication.Controls.Add(Me.LabelX6)
        Me.gApplication.Controls.Add(Me.lblApprovedP)
        Me.gApplication.Controls.Add(Me.lblPendingP)
        Me.gApplication.Controls.Add(Me.lblApprovedN)
        Me.gApplication.Controls.Add(Me.lblPendingN)
        Me.gApplication.Controls.Add(Me.LabelX13)
        Me.gApplication.Controls.Add(Me.LabelX14)
        Me.gApplication.Controls.Add(Me.LabelX15)
        Me.gApplication.Controls.Add(Me.LabelX16)
        Me.gApplication.Location = New System.Drawing.Point(6, 402)
        Me.gApplication.LookAndFeel.SkinName = "Darkroom"
        Me.gApplication.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gApplication.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gApplication.Name = "gApplication"
        Me.gApplication.Size = New System.Drawing.Size(273, 158)
        Me.gApplication.TabIndex = 1701
        Me.gApplication.Text = "Total Number of Application"
        '
        'lblDisapprovedP
        '
        '
        '
        '
        Me.lblDisapprovedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDisapprovedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDisapprovedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDisapprovedP.Location = New System.Drawing.Point(191, 125)
        Me.lblDisapprovedP.Name = "lblDisapprovedP"
        Me.lblDisapprovedP.Size = New System.Drawing.Size(80, 25)
        Me.lblDisapprovedP.TabIndex = 1047
        Me.lblDisapprovedP.Text = "0.00 %"
        Me.lblDisapprovedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDisapprovedN
        '
        '
        '
        '
        Me.lblDisapprovedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDisapprovedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDisapprovedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDisapprovedN.Location = New System.Drawing.Point(105, 125)
        Me.lblDisapprovedN.Name = "lblDisapprovedN"
        Me.lblDisapprovedN.Size = New System.Drawing.Size(80, 25)
        Me.lblDisapprovedN.TabIndex = 1046
        Me.lblDisapprovedN.Text = "0"
        Me.lblDisapprovedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(5, 125)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(94, 25)
        Me.LabelX6.TabIndex = 1045
        Me.LabelX6.Text = "Disapproved :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblApprovedP
        '
        '
        '
        '
        Me.lblApprovedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblApprovedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblApprovedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblApprovedP.Location = New System.Drawing.Point(191, 94)
        Me.lblApprovedP.Name = "lblApprovedP"
        Me.lblApprovedP.Size = New System.Drawing.Size(80, 25)
        Me.lblApprovedP.TabIndex = 1044
        Me.lblApprovedP.Text = "0.00 %"
        Me.lblApprovedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblPendingP
        '
        '
        '
        '
        Me.lblPendingP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPendingP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPendingP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPendingP.Location = New System.Drawing.Point(191, 63)
        Me.lblPendingP.Name = "lblPendingP"
        Me.lblPendingP.Size = New System.Drawing.Size(80, 25)
        Me.lblPendingP.TabIndex = 1043
        Me.lblPendingP.Text = "0.00 %"
        Me.lblPendingP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblApprovedN
        '
        '
        '
        '
        Me.lblApprovedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblApprovedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblApprovedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblApprovedN.Location = New System.Drawing.Point(105, 94)
        Me.lblApprovedN.Name = "lblApprovedN"
        Me.lblApprovedN.Size = New System.Drawing.Size(80, 25)
        Me.lblApprovedN.TabIndex = 1042
        Me.lblApprovedN.Text = "0"
        Me.lblApprovedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblPendingN
        '
        '
        '
        '
        Me.lblPendingN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPendingN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPendingN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPendingN.Location = New System.Drawing.Point(105, 63)
        Me.lblPendingN.Name = "lblPendingN"
        Me.lblPendingN.Size = New System.Drawing.Size(80, 25)
        Me.lblPendingN.TabIndex = 1041
        Me.lblPendingN.Text = "0"
        Me.lblPendingN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.Location = New System.Drawing.Point(191, 32)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(80, 25)
        Me.LabelX13.TabIndex = 1040
        Me.LabelX13.Text = "Percentage"
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.Location = New System.Drawing.Point(105, 32)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(80, 25)
        Me.LabelX14.TabIndex = 1039
        Me.LabelX14.Text = "Number"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(5, 94)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(94, 25)
        Me.LabelX15.TabIndex = 1038
        Me.LabelX15.Text = "Approved :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX16.Location = New System.Drawing.Point(5, 63)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(94, 25)
        Me.LabelX16.TabIndex = 1037
        Me.LabelX16.Text = "Pending :"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'CbxPrefix_B
        '
        Me.CbxPrefix_B.DisplayMember = "PREFIX"
        Me.CbxPrefix_B.Enabled = False
        Me.CbxPrefix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxPrefix_B.FormattingEnabled = True
        Me.CbxPrefix_B.Location = New System.Drawing.Point(405, 7)
        Me.CbxPrefix_B.MaxLength = 15
        Me.CbxPrefix_B.Name = "CbxPrefix_B"
        Me.CbxPrefix_B.Size = New System.Drawing.Size(72, 25)
        Me.CbxPrefix_B.TabIndex = 77
        Me.CbxPrefix_B.ValueMember = "ID"
        '
        'cbxSuffix_B
        '
        Me.cbxSuffix_B.Enabled = False
        Me.cbxSuffix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxSuffix_B.FormattingEnabled = True
        Me.cbxSuffix_B.Location = New System.Drawing.Point(1101, 7)
        Me.cbxSuffix_B.MaxLength = 10
        Me.cbxSuffix_B.Name = "cbxSuffix_B"
        Me.cbxSuffix_B.Size = New System.Drawing.Size(44, 25)
        Me.cbxSuffix_B.TabIndex = 81
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
        Me.TxtLastN_B.Location = New System.Drawing.Point(895, 7)
        Me.TxtLastN_B.MaxLength = 35
        Me.TxtLastN_B.Name = "TxtLastN_B"
        Me.TxtLastN_B.PreventEnterBeep = True
        Me.TxtLastN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtLastN_B.TabIndex = 80
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
        Me.TxtMiddleN_B.Location = New System.Drawing.Point(689, 7)
        Me.TxtMiddleN_B.MaxLength = 35
        Me.TxtMiddleN_B.Name = "TxtMiddleN_B"
        Me.TxtMiddleN_B.PreventEnterBeep = True
        Me.TxtMiddleN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtMiddleN_B.TabIndex = 79
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
        Me.TxtFirstN_B.Location = New System.Drawing.Point(483, 7)
        Me.TxtFirstN_B.MaxLength = 35
        Me.TxtFirstN_B.Name = "TxtFirstN_B"
        Me.TxtFirstN_B.PreventEnterBeep = True
        Me.TxtFirstN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtFirstN_B.TabIndex = 78
        Me.TxtFirstN_B.WatermarkText = "First Name"
        '
        'LabelX43
        '
        Me.LabelX43.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX43.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX43.Location = New System.Drawing.Point(273, 7)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(127, 23)
        Me.LabelX43.TabIndex = 76
        Me.LabelX43.Text = "Borrower's Name :"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'pb_B
        '
        Me.pb_B.EditValue = Global.FSFC_System.My.Resources.Resources.Avatar
        Me.pb_B.Location = New System.Drawing.Point(6, 7)
        Me.pb_B.Name = "pb_B"
        Me.pb_B.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.pb_B.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.pb_B.Properties.Appearance.Options.UseBackColor = True
        Me.pb_B.Properties.Appearance.Options.UseFont = True
        Me.pb_B.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pb_B.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_B.Size = New System.Drawing.Size(255, 256)
        Me.pb_B.TabIndex = 6
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(1127, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 73)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'FrmCreditApproved
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 709)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx9)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCreditApproved"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx9.ResumeLayout(False)
        CType(Me.dFA_C, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dServiceChargeA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dInterestRateA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTermsA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPrincipalA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dServiceCharge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dInterestRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dNetProceeds_C, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gRequirements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gRequirements.ResumeLayout(False)
        CType(Me.gPassDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gPassDue.ResumeLayout(False)
        CType(Me.gPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gPayments.ResumeLayout(False)
        CType(Me.gLoans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gLoans.ResumeLayout(False)
        CType(Me.gApplication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gApplication.ResumeLayout(False)
        CType(Me.pb_B.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnApproved As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDisapproved As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx9 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents pb_B As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents CbxPrefix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxSuffix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents TxtLastN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMiddleN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFirstN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gApplication As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblDisapprovedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDisapprovedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblApprovedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPendingP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblApprovedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPendingN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gLoans As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblCarP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCarN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblRealEstateP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblVehicleP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblRealEstateN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblVehicleN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gPayments As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblPassP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAdvanceP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPassN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAdvanceN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX45 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX46 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX47 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCheckP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCheckN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblShowmoneyP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblShowmoneyN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPaydayP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPaydayN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSalarySisterP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSalarySisterN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSalaryP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSalaryN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gPassDue As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMaximum As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX49 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX50 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMinimum As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAverageN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX55 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX56 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gRequirements As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblIncP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCompP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblIncN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCompN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnUpdate As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAttach As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRequirements As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblExcessP As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExcess As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPrincipal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblThreshold As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotalBooking As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblThresholdMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblWarning As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblInterest As DevComponents.DotNetBar.LabelX
    Friend WithEvents dServiceChargeA As DevComponents.Editors.DoubleInput
    Friend WithEvents dInterestRateA As DevComponents.Editors.DoubleInput
    Friend WithEvents iTermsA As DevComponents.Editors.IntegerInput
    Friend WithEvents cbxTermsA As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dPrincipalA As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dServiceCharge As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dInterestRate As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iTerms As DevComponents.Editors.IntegerInput
    Friend WithEvents cbxTerms As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dPrincipal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpApproved As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX68 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCreditNumber As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX100 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dNetProceeds_C As DevComponents.Editors.DoubleInput
    Friend WithEvents cbxProduct As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX82 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxCI As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblCI As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFA_C As DevComponents.DotNetBar.LabelX
    Friend WithEvents dFA_C As DevComponents.Editors.DoubleInput
    Friend WithEvents btnBOLA As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxOutsourceBranch As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxOutsource As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
