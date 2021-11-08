<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCreditReferralSlip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreditReferralSlip))
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnModify = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.btnBack = New DevComponents.DotNetBar.ButtonX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanelEx10 = New DevComponents.DotNetBar.PanelEx()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLedger2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuBar3 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLedger = New DevComponents.DotNetBar.ButtonItem()
        Me.iTotal_Score = New DevComponents.Editors.DoubleInput()
        Me.iCredit_Score = New DevComponents.Editors.DoubleInput()
        Me.iSettlement_Score = New DevComponents.Editors.DoubleInput()
        Me.iRepayment_Score = New DevComponents.Editors.DoubleInput()
        Me.iHistory_Score = New DevComponents.Editors.DoubleInput()
        Me.iTime_Score = New DevComponents.Editors.DoubleInput()
        Me.txtDocumentNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAccountNumber = New SergeUtils.EasyCompletionComboBox()
        Me.cbxRequested = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX65 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX64 = New DevComponents.DotNetBar.LabelX()
        Me.cbxPreparedBy = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX63 = New DevComponents.DotNetBar.LabelX()
        Me.rExplanation = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelX62 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX61 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemarks_Score = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX59 = New DevComponents.DotNetBar.LabelX()
        Me.dTotal_Score = New DevComponents.Editors.DoubleInput()
        Me.LabelX60 = New DevComponents.DotNetBar.LabelX()
        Me.dCredit_Score = New DevComponents.Editors.DoubleInput()
        Me.LabelX57 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX58 = New DevComponents.DotNetBar.LabelX()
        Me.dSettlement_Score = New DevComponents.Editors.DoubleInput()
        Me.LabelX55 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX56 = New DevComponents.DotNetBar.LabelX()
        Me.dRepayment_Score = New DevComponents.Editors.DoubleInput()
        Me.LabelX53 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.dHistory_Score = New DevComponents.Editors.DoubleInput()
        Me.LabelX51 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX52 = New DevComponents.DotNetBar.LabelX()
        Me.dTime_Score = New DevComponents.Editors.DoubleInput()
        Me.LabelX50 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX46 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX44 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX42 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        Me.cbxLoanType = New SergeUtils.EasyCompletionComboBox()
        Me.txtPresentStatus = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.txtDeliquency = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.txtNumberLPC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX38 = New DevComponents.DotNetBar.LabelX()
        Me.txtTerms = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.iPayments = New DevComponents.Editors.IntegerInput()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.dPrincipalBalance = New DevComponents.Editors.DoubleInput()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.txtInsuranceInCharge = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.txtOR = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.txtInsuranceCompany = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.dAmount_Renewal = New DevComponents.Editors.DoubleInput()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.dtpGranted_Policy = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.dAmount_Policy = New DevComponents.Editors.DoubleInput()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.dtpGranted_Insurance = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.dAmount_Insurance = New DevComponents.Editors.DoubleInput()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.dAmountDue = New DevComponents.Editors.DoubleInput()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.dUDI = New DevComponents.Editors.DoubleInput()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.dRPPD = New DevComponents.Editors.DoubleInput()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.dBalance = New DevComponents.Editors.DoubleInput()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.dLPC = New DevComponents.Editors.DoubleInput()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.dInterestDue = New DevComponents.Editors.DoubleInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.dOutstanding = New DevComponents.Editors.DoubleInput()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.dtpAsOf = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.cbxMonthly = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxBimonthly = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxWeekly = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxDaily = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtCollateral_7 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dMonthlyAmortization = New DevComponents.Editors.DoubleInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtCollateral_6 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpGranted = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.iDue = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtCollateral_5 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCollateral_4 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCollateral_3 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCollateral_2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dFaceAmount = New DevComponents.Editors.DoubleInput()
        Me.LabelX45 = New DevComponents.DotNetBar.LabelX()
        Me.dPrincipal = New DevComponents.Editors.DoubleInput()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.lblPlateNum = New DevComponents.DotNetBar.LabelX()
        Me.txtCollateral_1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.txtComaker4 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.txtComaker3 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.txtComaker2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtComaker1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dtpDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cbxApplication = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tabSetup = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelEx19 = New DevComponents.DotNetBar.PanelEx()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.cbxAll = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxDisplay = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX47 = New DevComponents.DotNetBar.LabelX()
        Me.dtpTo = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.dtpFrom = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX49 = New DevComponents.DotNetBar.LabelX()
        Me.tabList = New DevComponents.DotNetBar.SuperTabItem()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.PanelEx10.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTotal_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iCredit_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iSettlement_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iRepayment_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iHistory_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTime_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTotal_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dCredit_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dSettlement_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dRepayment_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dHistory_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTime_Score, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPrincipalBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_Renewal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpGranted_Policy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_Policy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpGranted_Insurance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_Insurance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmountDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dUDI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dRPPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dLPC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dInterestDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dOutstanding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpAsOf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dMonthlyAmortization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpGranted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dFaceAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx19.SuspendLayout()
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "CREDIT REFERRAL SLIP"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btnLogs)
        Me.PanelEx1.Controls.Add(Me.lblTitle)
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1167, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1009
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(1131, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
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
        Me.PanelEx3.Controls.Add(Me.btnAdd)
        Me.PanelEx3.Controls.Add(Me.btnModify)
        Me.PanelEx3.Controls.Add(Me.btnNext)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.Controls.Add(Me.btnBack)
        Me.PanelEx3.Controls.Add(Me.btnDelete)
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 662)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1167, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1012
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.FSFC_System.My.Resources.Resources.Add
        Me.btnAdd.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnAdd.Location = New System.Drawing.Point(231, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(107, 30)
        Me.btnAdd.TabIndex = 1007
        Me.btnAdd.Text = "&Add New"
        '
        'btnModify
        '
        Me.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnModify.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnModify.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Image = Global.FSFC_System.My.Resources.Resources.Modify
        Me.btnModify.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnModify.Location = New System.Drawing.Point(683, 4)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(107, 30)
        Me.btnModify.TabIndex = 1021
        Me.btnModify.Text = "&Modify"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnNext.Font = New System.Drawing.Font("Century Gothic", 27.75!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnNext.Location = New System.Drawing.Point(118, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(107, 30)
        Me.btnNext.Symbol = ""
        Me.btnNext.SymbolColor = System.Drawing.Color.Black
        Me.btnNext.SymbolSize = 24.0!
        Me.btnNext.TabIndex = 1006
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(570, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1020
        Me.btnCancel.Text = "Close"
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.FSFC_System.My.Resources.Resources.Refresh
        Me.btnRefresh.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnRefresh.Location = New System.Drawing.Point(457, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(107, 30)
        Me.btnRefresh.TabIndex = 1015
        Me.btnRefresh.Text = "Re&fresh"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(344, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 1010
        Me.btnSave.Text = "&Save"
        '
        'btnBack
        '
        Me.btnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnBack.Font = New System.Drawing.Font("Century Gothic", 27.75!, System.Drawing.FontStyle.Bold)
        Me.btnBack.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnBack.Location = New System.Drawing.Point(5, 4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(107, 30)
        Me.btnBack.Symbol = ""
        Me.btnBack.SymbolSize = 24.0!
        Me.btnBack.TabIndex = 1005
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDelete.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.FSFC_System.My.Resources.Resources.Delete
        Me.btnDelete.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnDelete.Location = New System.Drawing.Point(796, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(107, 30)
        Me.btnDelete.TabIndex = 1022
        Me.btnDelete.Text = "Cancel"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.FSFC_System.My.Resources.Resources.Print
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrint.Location = New System.Drawing.Point(909, 4)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 30)
        Me.btnPrint.TabIndex = 1025
        Me.btnPrint.Text = "&Print"
        '
        'SuperTabControl1
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.FixedTabSize = New System.Drawing.Size(175, 25)
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 66)
        Me.SuperTabControl1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(1167, 596)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1014
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabSetup, Me.tabList})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.PanelEx10)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.tabSetup
        '
        'PanelEx10
        '
        Me.PanelEx10.AutoScroll = True
        Me.PanelEx10.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx10.Controls.Add(Me.ContextMenuBar1)
        Me.PanelEx10.Controls.Add(Me.ContextMenuBar3)
        Me.PanelEx10.Controls.Add(Me.iTotal_Score)
        Me.PanelEx10.Controls.Add(Me.iCredit_Score)
        Me.PanelEx10.Controls.Add(Me.iSettlement_Score)
        Me.PanelEx10.Controls.Add(Me.iRepayment_Score)
        Me.PanelEx10.Controls.Add(Me.iHistory_Score)
        Me.PanelEx10.Controls.Add(Me.iTime_Score)
        Me.PanelEx10.Controls.Add(Me.txtDocumentNumber)
        Me.PanelEx10.Controls.Add(Me.LabelX17)
        Me.PanelEx10.Controls.Add(Me.cbxAccountNumber)
        Me.PanelEx10.Controls.Add(Me.GridControl2)
        Me.PanelEx10.Controls.Add(Me.cbxRequested)
        Me.PanelEx10.Controls.Add(Me.LabelX65)
        Me.PanelEx10.Controls.Add(Me.LabelX64)
        Me.PanelEx10.Controls.Add(Me.cbxPreparedBy)
        Me.PanelEx10.Controls.Add(Me.LabelX63)
        Me.PanelEx10.Controls.Add(Me.rExplanation)
        Me.PanelEx10.Controls.Add(Me.GridControl3)
        Me.PanelEx10.Controls.Add(Me.LabelX62)
        Me.PanelEx10.Controls.Add(Me.LabelX61)
        Me.PanelEx10.Controls.Add(Me.txtRemarks_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX59)
        Me.PanelEx10.Controls.Add(Me.dTotal_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX60)
        Me.PanelEx10.Controls.Add(Me.dCredit_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX57)
        Me.PanelEx10.Controls.Add(Me.LabelX58)
        Me.PanelEx10.Controls.Add(Me.dSettlement_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX55)
        Me.PanelEx10.Controls.Add(Me.LabelX56)
        Me.PanelEx10.Controls.Add(Me.dRepayment_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX53)
        Me.PanelEx10.Controls.Add(Me.LabelX54)
        Me.PanelEx10.Controls.Add(Me.dHistory_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX51)
        Me.PanelEx10.Controls.Add(Me.LabelX52)
        Me.PanelEx10.Controls.Add(Me.dTime_Score)
        Me.PanelEx10.Controls.Add(Me.LabelX50)
        Me.PanelEx10.Controls.Add(Me.LabelX46)
        Me.PanelEx10.Controls.Add(Me.LabelX44)
        Me.PanelEx10.Controls.Add(Me.LabelX43)
        Me.PanelEx10.Controls.Add(Me.LabelX42)
        Me.PanelEx10.Controls.Add(Me.LabelX41)
        Me.PanelEx10.Controls.Add(Me.cbxLoanType)
        Me.PanelEx10.Controls.Add(Me.txtPresentStatus)
        Me.PanelEx10.Controls.Add(Me.LabelX40)
        Me.PanelEx10.Controls.Add(Me.txtDeliquency)
        Me.PanelEx10.Controls.Add(Me.LabelX39)
        Me.PanelEx10.Controls.Add(Me.txtNumberLPC)
        Me.PanelEx10.Controls.Add(Me.LabelX38)
        Me.PanelEx10.Controls.Add(Me.txtTerms)
        Me.PanelEx10.Controls.Add(Me.LabelX37)
        Me.PanelEx10.Controls.Add(Me.LabelX35)
        Me.PanelEx10.Controls.Add(Me.iPayments)
        Me.PanelEx10.Controls.Add(Me.LabelX33)
        Me.PanelEx10.Controls.Add(Me.dPrincipalBalance)
        Me.PanelEx10.Controls.Add(Me.LabelX34)
        Me.PanelEx10.Controls.Add(Me.txtInsuranceInCharge)
        Me.PanelEx10.Controls.Add(Me.LabelX32)
        Me.PanelEx10.Controls.Add(Me.txtOR)
        Me.PanelEx10.Controls.Add(Me.LabelX31)
        Me.PanelEx10.Controls.Add(Me.txtInsuranceCompany)
        Me.PanelEx10.Controls.Add(Me.LabelX26)
        Me.PanelEx10.Controls.Add(Me.dAmount_Renewal)
        Me.PanelEx10.Controls.Add(Me.LabelX29)
        Me.PanelEx10.Controls.Add(Me.LabelX30)
        Me.PanelEx10.Controls.Add(Me.dtpGranted_Policy)
        Me.PanelEx10.Controls.Add(Me.LabelX25)
        Me.PanelEx10.Controls.Add(Me.dAmount_Policy)
        Me.PanelEx10.Controls.Add(Me.LabelX27)
        Me.PanelEx10.Controls.Add(Me.LabelX28)
        Me.PanelEx10.Controls.Add(Me.dtpGranted_Insurance)
        Me.PanelEx10.Controls.Add(Me.LabelX24)
        Me.PanelEx10.Controls.Add(Me.LabelX23)
        Me.PanelEx10.Controls.Add(Me.dAmount_Insurance)
        Me.PanelEx10.Controls.Add(Me.LabelX22)
        Me.PanelEx10.Controls.Add(Me.LabelX21)
        Me.PanelEx10.Controls.Add(Me.LabelX20)
        Me.PanelEx10.Controls.Add(Me.dAmountDue)
        Me.PanelEx10.Controls.Add(Me.LabelX19)
        Me.PanelEx10.Controls.Add(Me.dUDI)
        Me.PanelEx10.Controls.Add(Me.LabelX18)
        Me.PanelEx10.Controls.Add(Me.dRPPD)
        Me.PanelEx10.Controls.Add(Me.LabelX16)
        Me.PanelEx10.Controls.Add(Me.dBalance)
        Me.PanelEx10.Controls.Add(Me.LabelX15)
        Me.PanelEx10.Controls.Add(Me.dLPC)
        Me.PanelEx10.Controls.Add(Me.LabelX14)
        Me.PanelEx10.Controls.Add(Me.dInterestDue)
        Me.PanelEx10.Controls.Add(Me.LabelX10)
        Me.PanelEx10.Controls.Add(Me.dOutstanding)
        Me.PanelEx10.Controls.Add(Me.LabelX8)
        Me.PanelEx10.Controls.Add(Me.dtpAsOf)
        Me.PanelEx10.Controls.Add(Me.LabelX7)
        Me.PanelEx10.Controls.Add(Me.cbxMonthly)
        Me.PanelEx10.Controls.Add(Me.cbxBimonthly)
        Me.PanelEx10.Controls.Add(Me.cbxWeekly)
        Me.PanelEx10.Controls.Add(Me.cbxDaily)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_7)
        Me.PanelEx10.Controls.Add(Me.dMonthlyAmortization)
        Me.PanelEx10.Controls.Add(Me.LabelX5)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_6)
        Me.PanelEx10.Controls.Add(Me.dtpGranted)
        Me.PanelEx10.Controls.Add(Me.LabelX4)
        Me.PanelEx10.Controls.Add(Me.iDue)
        Me.PanelEx10.Controls.Add(Me.LabelX3)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_5)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_4)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_3)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_2)
        Me.PanelEx10.Controls.Add(Me.dFaceAmount)
        Me.PanelEx10.Controls.Add(Me.LabelX45)
        Me.PanelEx10.Controls.Add(Me.dPrincipal)
        Me.PanelEx10.Controls.Add(Me.LabelX36)
        Me.PanelEx10.Controls.Add(Me.lblPlateNum)
        Me.PanelEx10.Controls.Add(Me.txtCollateral_1)
        Me.PanelEx10.Controls.Add(Me.LabelX13)
        Me.PanelEx10.Controls.Add(Me.txtComaker4)
        Me.PanelEx10.Controls.Add(Me.LabelX12)
        Me.PanelEx10.Controls.Add(Me.txtComaker3)
        Me.PanelEx10.Controls.Add(Me.LabelX9)
        Me.PanelEx10.Controls.Add(Me.txtComaker2)
        Me.PanelEx10.Controls.Add(Me.LabelX6)
        Me.PanelEx10.Controls.Add(Me.txtComaker1)
        Me.PanelEx10.Controls.Add(Me.LabelX2)
        Me.PanelEx10.Controls.Add(Me.dtpDate)
        Me.PanelEx10.Controls.Add(Me.cbxApplication)
        Me.PanelEx10.Controls.Add(Me.LabelX155)
        Me.PanelEx10.Controls.Add(Me.LabelX1)
        Me.PanelEx10.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx10.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PanelEx10.Name = "PanelEx10"
        Me.PanelEx10.Size = New System.Drawing.Size(1167, 569)
        Me.PanelEx10.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx10.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx10.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx10.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx10.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left
        Me.PanelEx10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx10.Style.GradientAngle = 90
        Me.PanelEx10.TabIndex = 10
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(726, 1116)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(114, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 1968
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnLedger2})
        '
        'BtnLedger2
        '
        Me.BtnLedger2.Name = "BtnLedger2"
        Me.BtnLedger2.Text = "Account Ledger"
        '
        'ContextMenuBar3
        '
        Me.ContextMenuBar3.AntiAlias = True
        Me.ContextMenuBar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.ContextMenuBar3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem5})
        Me.ContextMenuBar3.Location = New System.Drawing.Point(726, 849)
        Me.ContextMenuBar3.Name = "ContextMenuBar3"
        Me.ContextMenuBar3.Size = New System.Drawing.Size(114, 25)
        Me.ContextMenuBar3.Stretch = True
        Me.ContextMenuBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar3.TabIndex = 1967
        Me.ContextMenuBar3.TabStop = False
        Me.ContextMenuBar3.Text = "ContextMenuBar3"
        '
        'GridControl2
        '
        Me.ContextMenuBar3.SetContextMenuEx(Me.GridControl2, Me.ButtonItem5)
        Me.GridControl2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl2.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl2.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl2.Location = New System.Drawing.Point(15, 764)
        Me.GridControl2.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1122, 236)
        Me.GridControl2.TabIndex = 1950
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.DetailTip.Options.UseFont = True
        Me.GridView2.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.Empty.Options.UseBackColor = True
        Me.GridView2.Appearance.Empty.Options.UseFont = True
        Me.GridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView2.Appearance.EvenRow.Options.UseFont = True
        Me.GridView2.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.FilterCloseButton.Options.UseFont = True
        Me.GridView2.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView2.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.FilterPanel.Options.UseFont = True
        Me.GridView2.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView2.Appearance.FixedLine.Options.UseFont = True
        Me.GridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView2.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedRow.Options.UseFont = True
        Me.GridView2.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.GridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView2.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupButton.Options.UseFont = True
        Me.GridView2.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupFooter.Options.UseFont = True
        Me.GridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupPanel.Options.UseFont = True
        Me.GridView2.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupRow.Options.UseFont = True
        Me.GridView2.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView2.Appearance.HideSelectionRow.Options.UseFont = True
        Me.GridView2.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView2.Appearance.HorzLine.Options.UseFont = True
        Me.GridView2.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView2.Appearance.OddRow.Options.UseFont = True
        Me.GridView2.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView2.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.GridView2.Appearance.Preview.Options.UseBackColor = True
        Me.GridView2.Appearance.Preview.Options.UseFont = True
        Me.GridView2.Appearance.Preview.Options.UseForeColor = True
        Me.GridView2.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.Row.Options.UseBackColor = True
        Me.GridView2.Appearance.Row.Options.UseFont = True
        Me.GridView2.Appearance.Row.Options.UseForeColor = True
        Me.GridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView2.Appearance.RowSeparator.Options.UseFont = True
        Me.GridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.SelectedRow.Options.UseFont = True
        Me.GridView2.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView2.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.TopNewRow.Options.UseBackColor = True
        Me.GridView2.Appearance.TopNewRow.Options.UseFont = True
        Me.GridView2.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView2.Appearance.VertLine.Options.UseFont = True
        Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView2.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn19, Me.GridColumn20})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.GroupPanelText = "General Requirements"
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsLayout.StoreAllOptions = True
        Me.GridView2.OptionsLayout.StoreAppearance = True
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView2.OptionsView.EnableAppearanceOddRow = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.PaintStyleName = "Style3D"
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Account Number"
        Me.GridColumn6.FieldName = "Account Number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 135
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Principal"
        Me.GridColumn7.FieldName = "Principal"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 135
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Face Amount"
        Me.GridColumn8.FieldName = "Face Amount"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 2
        Me.GridColumn8.Width = 135
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "Outstanding Bal"
        Me.GridColumn10.FieldName = "Outstanding Bal"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        Me.GridColumn10.Width = 135
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.Caption = "GMA"
        Me.GridColumn11.FieldName = "GMA"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 135
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Date Granted"
        Me.GridColumn12.FieldName = "Date Granted"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 5
        Me.GridColumn12.Width = 135
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.Caption = "Maturity Date"
        Me.GridColumn19.FieldName = "Maturity Date"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 6
        Me.GridColumn19.Width = 135
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Remarks"
        Me.GridColumn20.FieldName = "Remarks"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 7
        Me.GridColumn20.Width = 159
        '
        'ButtonItem5
        '
        Me.ButtonItem5.AutoExpandOnClick = True
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnLedger})
        '
        'BtnLedger
        '
        Me.BtnLedger.Name = "BtnLedger"
        Me.BtnLedger.Text = "Account Ledger"
        '
        'iTotal_Score
        '
        '
        '
        '
        Me.iTotal_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iTotal_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iTotal_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iTotal_Score.Enabled = False
        Me.iTotal_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iTotal_Score.ForeColor = System.Drawing.Color.Black
        Me.iTotal_Score.Increment = 1.0R
        Me.iTotal_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iTotal_Score.Location = New System.Drawing.Point(846, 678)
        Me.iTotal_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iTotal_Score.MinValue = 0R
        Me.iTotal_Score.Name = "iTotal_Score"
        Me.iTotal_Score.ShowUpDown = True
        Me.iTotal_Score.Size = New System.Drawing.Size(93, 23)
        Me.iTotal_Score.TabIndex = 1966
        '
        'iCredit_Score
        '
        '
        '
        '
        Me.iCredit_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iCredit_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iCredit_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iCredit_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iCredit_Score.ForeColor = System.Drawing.Color.Black
        Me.iCredit_Score.Increment = 1.0R
        Me.iCredit_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iCredit_Score.Location = New System.Drawing.Point(846, 649)
        Me.iCredit_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iCredit_Score.MaxValue = 20.0R
        Me.iCredit_Score.MinValue = 0R
        Me.iCredit_Score.Name = "iCredit_Score"
        Me.iCredit_Score.ShowUpDown = True
        Me.iCredit_Score.Size = New System.Drawing.Size(93, 23)
        Me.iCredit_Score.TabIndex = 50
        '
        'iSettlement_Score
        '
        '
        '
        '
        Me.iSettlement_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iSettlement_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iSettlement_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iSettlement_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iSettlement_Score.ForeColor = System.Drawing.Color.Black
        Me.iSettlement_Score.Increment = 1.0R
        Me.iSettlement_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iSettlement_Score.Location = New System.Drawing.Point(846, 620)
        Me.iSettlement_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iSettlement_Score.MaxValue = 20.0R
        Me.iSettlement_Score.MinValue = 0R
        Me.iSettlement_Score.Name = "iSettlement_Score"
        Me.iSettlement_Score.ShowUpDown = True
        Me.iSettlement_Score.Size = New System.Drawing.Size(93, 23)
        Me.iSettlement_Score.TabIndex = 49
        '
        'iRepayment_Score
        '
        '
        '
        '
        Me.iRepayment_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iRepayment_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iRepayment_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iRepayment_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iRepayment_Score.ForeColor = System.Drawing.Color.Black
        Me.iRepayment_Score.Increment = 1.0R
        Me.iRepayment_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iRepayment_Score.Location = New System.Drawing.Point(846, 591)
        Me.iRepayment_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iRepayment_Score.MaxValue = 20.0R
        Me.iRepayment_Score.MinValue = 0R
        Me.iRepayment_Score.Name = "iRepayment_Score"
        Me.iRepayment_Score.ShowUpDown = True
        Me.iRepayment_Score.Size = New System.Drawing.Size(93, 23)
        Me.iRepayment_Score.TabIndex = 48
        '
        'iHistory_Score
        '
        '
        '
        '
        Me.iHistory_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iHistory_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iHistory_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iHistory_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iHistory_Score.ForeColor = System.Drawing.Color.Black
        Me.iHistory_Score.Increment = 1.0R
        Me.iHistory_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iHistory_Score.Location = New System.Drawing.Point(846, 562)
        Me.iHistory_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iHistory_Score.MaxValue = 20.0R
        Me.iHistory_Score.MinValue = 0R
        Me.iHistory_Score.Name = "iHistory_Score"
        Me.iHistory_Score.ShowUpDown = True
        Me.iHistory_Score.Size = New System.Drawing.Size(93, 23)
        Me.iHistory_Score.TabIndex = 47
        '
        'iTime_Score
        '
        '
        '
        '
        Me.iTime_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iTime_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iTime_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iTime_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iTime_Score.ForeColor = System.Drawing.Color.Black
        Me.iTime_Score.Increment = 1.0R
        Me.iTime_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iTime_Score.Location = New System.Drawing.Point(846, 531)
        Me.iTime_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iTime_Score.MaxValue = 20.0R
        Me.iTime_Score.MinValue = 0R
        Me.iTime_Score.Name = "iTime_Score"
        Me.iTime_Score.ShowUpDown = True
        Me.iTime_Score.Size = New System.Drawing.Size(93, 23)
        Me.iTime_Score.TabIndex = 46
        '
        'txtDocumentNumber
        '
        '
        '
        '
        Me.txtDocumentNumber.Border.Class = "TextBoxBorder"
        Me.txtDocumentNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDocumentNumber.Enabled = False
        Me.txtDocumentNumber.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumentNumber.Location = New System.Drawing.Point(563, 45)
        Me.txtDocumentNumber.MaxLength = 70
        Me.txtDocumentNumber.Name = "txtDocumentNumber"
        Me.txtDocumentNumber.PreventEnterBeep = True
        Me.txtDocumentNumber.Size = New System.Drawing.Size(153, 23)
        Me.txtDocumentNumber.TabIndex = 1960
        Me.txtDocumentNumber.Text = "CRS-CEB18-00001"
        Me.txtDocumentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(418, 45)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(139, 23)
        Me.LabelX17.TabIndex = 1959
        Me.LabelX17.Text = "Document Number :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxAccountNumber
        '
        Me.cbxAccountNumber.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAccountNumber.FormattingEnabled = True
        Me.cbxAccountNumber.Location = New System.Drawing.Point(149, 45)
        Me.cbxAccountNumber.Name = "cbxAccountNumber"
        Me.cbxAccountNumber.Size = New System.Drawing.Size(263, 25)
        Me.cbxAccountNumber.TabIndex = 2
        '
        'cbxRequested
        '
        Me.cbxRequested.DisplayMember = "PREFIX"
        Me.cbxRequested.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxRequested.FormattingEnabled = True
        Me.cbxRequested.Location = New System.Drawing.Point(300, 1380)
        Me.cbxRequested.Name = "cbxRequested"
        Me.cbxRequested.Size = New System.Drawing.Size(279, 25)
        Me.cbxRequested.TabIndex = 1957
        Me.cbxRequested.ValueMember = "ID"
        '
        'LabelX65
        '
        Me.LabelX65.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX65.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX65.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX65.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX65.Location = New System.Drawing.Point(300, 1355)
        Me.LabelX65.Name = "LabelX65"
        Me.LabelX65.Size = New System.Drawing.Size(96, 23)
        Me.LabelX65.TabIndex = 1958
        Me.LabelX65.Text = "Requested By :"
        '
        'LabelX64
        '
        Me.LabelX64.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX64.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX64.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX64.ForeColor = System.Drawing.Color.White
        Me.LabelX64.Location = New System.Drawing.Point(15, 1274)
        Me.LabelX64.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX64.Name = "LabelX64"
        Me.LabelX64.Size = New System.Drawing.Size(225, 23)
        Me.LabelX64.TabIndex = 1956
        Me.LabelX64.Text = "REMARKS"
        Me.LabelX64.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cbxPreparedBy
        '
        Me.cbxPreparedBy.DisplayMember = "PREFIX"
        Me.cbxPreparedBy.Enabled = False
        Me.cbxPreparedBy.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxPreparedBy.FormattingEnabled = True
        Me.cbxPreparedBy.Location = New System.Drawing.Point(15, 1380)
        Me.cbxPreparedBy.Name = "cbxPreparedBy"
        Me.cbxPreparedBy.Size = New System.Drawing.Size(279, 25)
        Me.cbxPreparedBy.TabIndex = 1954
        Me.cbxPreparedBy.ValueMember = "ID"
        '
        'LabelX63
        '
        Me.LabelX63.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX63.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX63.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX63.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX63.Location = New System.Drawing.Point(15, 1355)
        Me.LabelX63.Name = "LabelX63"
        Me.LabelX63.Size = New System.Drawing.Size(96, 23)
        Me.LabelX63.TabIndex = 1955
        Me.LabelX63.Text = "Prepared By :"
        '
        'rExplanation
        '
        Me.rExplanation.BackColorRichTextBox = System.Drawing.Color.White
        '
        '
        '
        Me.rExplanation.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.rExplanation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rExplanation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rExplanation.ForeColor = System.Drawing.Color.Black
        Me.rExplanation.Location = New System.Drawing.Point(15, 1304)
        Me.rExplanation.MaxLength = 255
        Me.rExplanation.Name = "rExplanation"
        Me.rExplanation.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 " &
    "Century Gothic;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{\*\generator Riched20 10.0.19041}\viewkind4\uc1 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\pard\f0\f" &
    "s20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rExplanation.Size = New System.Drawing.Size(1122, 45)
        Me.rExplanation.TabIndex = 200
        '
        'GridControl3
        '
        Me.ContextMenuBar1.SetContextMenuEx(Me.GridControl3, Me.ButtonItem1)
        Me.GridControl3.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl3.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl3.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl3.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl3.Location = New System.Drawing.Point(15, 1031)
        Me.GridControl3.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1122, 236)
        Me.GridControl3.TabIndex = 1952
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.DetailTip.Options.UseFont = True
        Me.GridView3.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.Empty.Options.UseBackColor = True
        Me.GridView3.Appearance.Empty.Options.UseFont = True
        Me.GridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView3.Appearance.EvenRow.Options.UseFont = True
        Me.GridView3.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView3.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.FilterCloseButton.Options.UseFont = True
        Me.GridView3.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView3.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView3.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.FilterPanel.Options.UseFont = True
        Me.GridView3.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView3.Appearance.FixedLine.Options.UseFont = True
        Me.GridView3.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView3.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView3.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.FocusedRow.Options.UseFont = True
        Me.GridView3.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView3.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.GridView3.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView3.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupButton.Options.UseFont = True
        Me.GridView3.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView3.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupFooter.Options.UseFont = True
        Me.GridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupPanel.Options.UseFont = True
        Me.GridView3.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupRow.Options.UseFont = True
        Me.GridView3.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView3.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView3.Appearance.HideSelectionRow.Options.UseFont = True
        Me.GridView3.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView3.Appearance.HorzLine.Options.UseFont = True
        Me.GridView3.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView3.Appearance.OddRow.Options.UseFont = True
        Me.GridView3.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView3.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.GridView3.Appearance.Preview.Options.UseBackColor = True
        Me.GridView3.Appearance.Preview.Options.UseFont = True
        Me.GridView3.Appearance.Preview.Options.UseForeColor = True
        Me.GridView3.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.Row.Options.UseBackColor = True
        Me.GridView3.Appearance.Row.Options.UseFont = True
        Me.GridView3.Appearance.Row.Options.UseForeColor = True
        Me.GridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView3.Appearance.RowSeparator.Options.UseFont = True
        Me.GridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.SelectedRow.Options.UseFont = True
        Me.GridView3.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView3.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.TopNewRow.Options.UseBackColor = True
        Me.GridView3.Appearance.TopNewRow.Options.UseFont = True
        Me.GridView3.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView3.Appearance.VertLine.Options.UseFont = True
        Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView3.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.GroupPanelText = "General Requirements"
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsLayout.StoreAllOptions = True
        Me.GridView3.OptionsLayout.StoreAppearance = True
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView3.OptionsView.EnableAppearanceOddRow = True
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.PaintStyleName = "Style3D"
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn21.Caption = "Account Number"
        Me.GridColumn21.FieldName = "Account Number"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 0
        Me.GridColumn21.Width = 135
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.Caption = "Principal"
        Me.GridColumn22.FieldName = "Principal"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 1
        Me.GridColumn22.Width = 135
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "Face Amount"
        Me.GridColumn23.FieldName = "Face Amount"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 2
        Me.GridColumn23.Width = 135
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.Caption = "Outstanding Bal"
        Me.GridColumn24.FieldName = "Outstanding Bal"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 3
        Me.GridColumn24.Width = 135
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.Caption = "GMA"
        Me.GridColumn25.FieldName = "GMA"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 4
        Me.GridColumn25.Width = 135
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.Caption = "Date Granted"
        Me.GridColumn26.FieldName = "Date Granted"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 5
        Me.GridColumn26.Width = 135
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.Caption = "Maturity Date"
        Me.GridColumn27.FieldName = "Maturity Date"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 6
        Me.GridColumn27.Width = 135
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Remarks"
        Me.GridColumn28.FieldName = "Remarks"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 7
        Me.GridColumn28.Width = 159
        '
        'LabelX62
        '
        Me.LabelX62.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX62.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX62.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX62.ForeColor = System.Drawing.Color.White
        Me.LabelX62.Location = New System.Drawing.Point(15, 1007)
        Me.LabelX62.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX62.Name = "LabelX62"
        Me.LabelX62.Size = New System.Drawing.Size(225, 23)
        Me.LabelX62.TabIndex = 1951
        Me.LabelX62.Text = "ACCOUNT CLOSED"
        Me.LabelX62.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX61
        '
        Me.LabelX61.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX61.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX61.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX61.ForeColor = System.Drawing.Color.White
        Me.LabelX61.Location = New System.Drawing.Point(15, 740)
        Me.LabelX61.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX61.Name = "LabelX61"
        Me.LabelX61.Size = New System.Drawing.Size(225, 23)
        Me.LabelX61.TabIndex = 1949
        Me.LabelX61.Text = "ACTIVE ACCOUNTS"
        Me.LabelX61.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtRemarks_Score
        '
        '
        '
        '
        Me.txtRemarks_Score.Border.Class = "TextBoxBorder"
        Me.txtRemarks_Score.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemarks_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks_Score.Location = New System.Drawing.Point(846, 708)
        Me.txtRemarks_Score.MaxLength = 50
        Me.txtRemarks_Score.Name = "txtRemarks_Score"
        Me.txtRemarks_Score.PreventEnterBeep = True
        Me.txtRemarks_Score.Size = New System.Drawing.Size(291, 23)
        Me.txtRemarks_Score.TabIndex = 70
        '
        'LabelX59
        '
        Me.LabelX59.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX59.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX59.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX59.Location = New System.Drawing.Point(615, 708)
        Me.LabelX59.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX59.Name = "LabelX59"
        Me.LabelX59.Size = New System.Drawing.Size(225, 23)
        Me.LabelX59.TabIndex = 1947
        Me.LabelX59.Text = "Remarks "
        '
        'dTotal_Score
        '
        '
        '
        '
        Me.dTotal_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTotal_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTotal_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTotal_Score.Enabled = False
        Me.dTotal_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dTotal_Score.ForeColor = System.Drawing.Color.Black
        Me.dTotal_Score.Increment = 1.0R
        Me.dTotal_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dTotal_Score.Location = New System.Drawing.Point(1044, 677)
        Me.dTotal_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dTotal_Score.MinValue = 0R
        Me.dTotal_Score.Name = "dTotal_Score"
        Me.dTotal_Score.ShowUpDown = True
        Me.dTotal_Score.Size = New System.Drawing.Size(93, 23)
        Me.dTotal_Score.TabIndex = 1946
        '
        'LabelX60
        '
        Me.LabelX60.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX60.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX60.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX60.ForeColor = System.Drawing.Color.White
        Me.LabelX60.Location = New System.Drawing.Point(615, 678)
        Me.LabelX60.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX60.Name = "LabelX60"
        Me.LabelX60.Size = New System.Drawing.Size(225, 23)
        Me.LabelX60.TabIndex = 1942
        Me.LabelX60.Text = "T O T A L"
        Me.LabelX60.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'dCredit_Score
        '
        '
        '
        '
        Me.dCredit_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dCredit_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dCredit_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dCredit_Score.Enabled = False
        Me.dCredit_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dCredit_Score.ForeColor = System.Drawing.Color.Black
        Me.dCredit_Score.Increment = 1.0R
        Me.dCredit_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dCredit_Score.Location = New System.Drawing.Point(1044, 648)
        Me.dCredit_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dCredit_Score.MinValue = 0R
        Me.dCredit_Score.Name = "dCredit_Score"
        Me.dCredit_Score.ShowUpDown = True
        Me.dCredit_Score.Size = New System.Drawing.Size(93, 23)
        Me.dCredit_Score.TabIndex = 1941
        '
        'LabelX57
        '
        Me.LabelX57.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX57.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX57.Location = New System.Drawing.Point(945, 649)
        Me.LabelX57.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX57.Name = "LabelX57"
        Me.LabelX57.Size = New System.Drawing.Size(93, 23)
        Me.LabelX57.TabIndex = 1940
        Me.LabelX57.Text = "10.00 %"
        Me.LabelX57.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX58
        '
        Me.LabelX58.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX58.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX58.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX58.Location = New System.Drawing.Point(615, 649)
        Me.LabelX58.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX58.Name = "LabelX58"
        Me.LabelX58.Size = New System.Drawing.Size(225, 23)
        Me.LabelX58.TabIndex = 1937
        Me.LabelX58.Text = "Credit/Court Checking"
        '
        'dSettlement_Score
        '
        '
        '
        '
        Me.dSettlement_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dSettlement_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dSettlement_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dSettlement_Score.Enabled = False
        Me.dSettlement_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dSettlement_Score.ForeColor = System.Drawing.Color.Black
        Me.dSettlement_Score.Increment = 1.0R
        Me.dSettlement_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dSettlement_Score.Location = New System.Drawing.Point(1044, 619)
        Me.dSettlement_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dSettlement_Score.MinValue = 0R
        Me.dSettlement_Score.Name = "dSettlement_Score"
        Me.dSettlement_Score.ShowUpDown = True
        Me.dSettlement_Score.Size = New System.Drawing.Size(93, 23)
        Me.dSettlement_Score.TabIndex = 1936
        '
        'LabelX55
        '
        Me.LabelX55.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX55.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX55.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX55.Location = New System.Drawing.Point(945, 620)
        Me.LabelX55.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX55.Name = "LabelX55"
        Me.LabelX55.Size = New System.Drawing.Size(93, 23)
        Me.LabelX55.TabIndex = 1935
        Me.LabelX55.Text = "15.00 %"
        Me.LabelX55.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX56
        '
        Me.LabelX56.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX56.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX56.Location = New System.Drawing.Point(615, 620)
        Me.LabelX56.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX56.Name = "LabelX56"
        Me.LabelX56.Size = New System.Drawing.Size(225, 23)
        Me.LabelX56.TabIndex = 1932
        Me.LabelX56.Text = "Settlements of Accounts"
        '
        'dRepayment_Score
        '
        '
        '
        '
        Me.dRepayment_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dRepayment_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dRepayment_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dRepayment_Score.Enabled = False
        Me.dRepayment_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dRepayment_Score.ForeColor = System.Drawing.Color.Black
        Me.dRepayment_Score.Increment = 1.0R
        Me.dRepayment_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dRepayment_Score.Location = New System.Drawing.Point(1044, 590)
        Me.dRepayment_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dRepayment_Score.MinValue = 0R
        Me.dRepayment_Score.Name = "dRepayment_Score"
        Me.dRepayment_Score.ShowUpDown = True
        Me.dRepayment_Score.Size = New System.Drawing.Size(93, 23)
        Me.dRepayment_Score.TabIndex = 1931
        '
        'LabelX53
        '
        Me.LabelX53.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX53.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX53.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX53.Location = New System.Drawing.Point(945, 591)
        Me.LabelX53.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX53.Name = "LabelX53"
        Me.LabelX53.Size = New System.Drawing.Size(93, 23)
        Me.LabelX53.TabIndex = 1930
        Me.LabelX53.Text = "20.00 %"
        Me.LabelX53.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX54
        '
        Me.LabelX54.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX54.Location = New System.Drawing.Point(615, 591)
        Me.LabelX54.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(225, 23)
        Me.LabelX54.TabIndex = 1927
        Me.LabelX54.Text = "Mode of Repayment"
        '
        'dHistory_Score
        '
        '
        '
        '
        Me.dHistory_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dHistory_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dHistory_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dHistory_Score.Enabled = False
        Me.dHistory_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dHistory_Score.ForeColor = System.Drawing.Color.Black
        Me.dHistory_Score.Increment = 1.0R
        Me.dHistory_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dHistory_Score.Location = New System.Drawing.Point(1044, 561)
        Me.dHistory_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dHistory_Score.MinValue = 0R
        Me.dHistory_Score.Name = "dHistory_Score"
        Me.dHistory_Score.ShowUpDown = True
        Me.dHistory_Score.Size = New System.Drawing.Size(93, 23)
        Me.dHistory_Score.TabIndex = 1926
        '
        'LabelX51
        '
        Me.LabelX51.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX51.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX51.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX51.Location = New System.Drawing.Point(945, 562)
        Me.LabelX51.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX51.Name = "LabelX51"
        Me.LabelX51.Size = New System.Drawing.Size(93, 23)
        Me.LabelX51.TabIndex = 1925
        Me.LabelX51.Text = "25.00 %"
        Me.LabelX51.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX52
        '
        Me.LabelX52.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX52.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX52.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX52.Location = New System.Drawing.Point(615, 562)
        Me.LabelX52.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX52.Name = "LabelX52"
        Me.LabelX52.Size = New System.Drawing.Size(225, 23)
        Me.LabelX52.TabIndex = 1922
        Me.LabelX52.Text = "History of PDC's"
        '
        'dTime_Score
        '
        '
        '
        '
        Me.dTime_Score.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTime_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTime_Score.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTime_Score.Enabled = False
        Me.dTime_Score.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dTime_Score.ForeColor = System.Drawing.Color.Black
        Me.dTime_Score.Increment = 1.0R
        Me.dTime_Score.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dTime_Score.Location = New System.Drawing.Point(1044, 530)
        Me.dTime_Score.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dTime_Score.MinValue = 0R
        Me.dTime_Score.Name = "dTime_Score"
        Me.dTime_Score.ShowUpDown = True
        Me.dTime_Score.Size = New System.Drawing.Size(93, 23)
        Me.dTime_Score.TabIndex = 1921
        '
        'LabelX50
        '
        Me.LabelX50.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX50.Location = New System.Drawing.Point(945, 531)
        Me.LabelX50.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX50.Name = "LabelX50"
        Me.LabelX50.Size = New System.Drawing.Size(93, 23)
        Me.LabelX50.TabIndex = 1920
        Me.LabelX50.Text = "30.00 %"
        Me.LabelX50.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX46
        '
        Me.LabelX46.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX46.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX46.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX46.Location = New System.Drawing.Point(615, 531)
        Me.LabelX46.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX46.Name = "LabelX46"
        Me.LabelX46.Size = New System.Drawing.Size(225, 23)
        Me.LabelX46.TabIndex = 1917
        Me.LabelX46.Text = "Time of Payment"
        '
        'LabelX44
        '
        Me.LabelX44.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX44.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX44.ForeColor = System.Drawing.Color.White
        Me.LabelX44.Location = New System.Drawing.Point(1044, 497)
        Me.LabelX44.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX44.Name = "LabelX44"
        Me.LabelX44.Size = New System.Drawing.Size(93, 23)
        Me.LabelX44.TabIndex = 1916
        Me.LabelX44.Text = "T O T A L"
        Me.LabelX44.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX43
        '
        Me.LabelX43.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX43.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX43.ForeColor = System.Drawing.Color.White
        Me.LabelX43.Location = New System.Drawing.Point(945, 497)
        Me.LabelX43.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(93, 23)
        Me.LabelX43.TabIndex = 1915
        Me.LabelX43.Text = "Rate"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX42
        '
        Me.LabelX42.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX42.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX42.ForeColor = System.Drawing.Color.White
        Me.LabelX42.Location = New System.Drawing.Point(846, 497)
        Me.LabelX42.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX42.Name = "LabelX42"
        Me.LabelX42.Size = New System.Drawing.Size(93, 23)
        Me.LabelX42.TabIndex = 1914
        Me.LabelX42.Text = "Score"
        Me.LabelX42.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX41
        '
        Me.LabelX41.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX41.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX41.ForeColor = System.Drawing.Color.White
        Me.LabelX41.Location = New System.Drawing.Point(615, 497)
        Me.LabelX41.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX41.Name = "LabelX41"
        Me.LabelX41.Size = New System.Drawing.Size(225, 23)
        Me.LabelX41.TabIndex = 1913
        Me.LabelX41.Text = "Summary"
        Me.LabelX41.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cbxLoanType
        '
        Me.cbxLoanType.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxLoanType.FormattingEnabled = True
        Me.cbxLoanType.Items.AddRange(New Object() {"NEW", "RELOAN", "RESTRUCTURE", "ASSUMPTION", "ASSUMPTION RESTRUCTURE"})
        Me.cbxLoanType.Location = New System.Drawing.Point(241, 708)
        Me.cbxLoanType.Name = "cbxLoanType"
        Me.cbxLoanType.Size = New System.Drawing.Size(213, 25)
        Me.cbxLoanType.TabIndex = 19
        Me.cbxLoanType.Text = "RELOAN"
        '
        'txtPresentStatus
        '
        '
        '
        '
        Me.txtPresentStatus.Border.Class = "TextBoxBorder"
        Me.txtPresentStatus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPresentStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresentStatus.Location = New System.Drawing.Point(241, 679)
        Me.txtPresentStatus.MaxLength = 70
        Me.txtPresentStatus.Name = "txtPresentStatus"
        Me.txtPresentStatus.PreventEnterBeep = True
        Me.txtPresentStatus.Size = New System.Drawing.Size(213, 23)
        Me.txtPresentStatus.TabIndex = 18
        '
        'LabelX40
        '
        Me.LabelX40.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX40.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX40.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX40.Location = New System.Drawing.Point(15, 678)
        Me.LabelX40.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.Size = New System.Drawing.Size(220, 23)
        Me.LabelX40.TabIndex = 1910
        Me.LabelX40.Text = "Present Status :"
        Me.LabelX40.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtDeliquency
        '
        '
        '
        '
        Me.txtDeliquency.Border.Class = "TextBoxBorder"
        Me.txtDeliquency.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDeliquency.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliquency.Location = New System.Drawing.Point(241, 650)
        Me.txtDeliquency.MaxLength = 70
        Me.txtDeliquency.Name = "txtDeliquency"
        Me.txtDeliquency.PreventEnterBeep = True
        Me.txtDeliquency.Size = New System.Drawing.Size(213, 23)
        Me.txtDeliquency.TabIndex = 17
        '
        'LabelX39
        '
        Me.LabelX39.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX39.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX39.Location = New System.Drawing.Point(15, 649)
        Me.LabelX39.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.Size = New System.Drawing.Size(220, 23)
        Me.LabelX39.TabIndex = 1908
        Me.LabelX39.Text = "Deliquency Range :"
        Me.LabelX39.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtNumberLPC
        '
        '
        '
        '
        Me.txtNumberLPC.Border.Class = "TextBoxBorder"
        Me.txtNumberLPC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumberLPC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberLPC.Location = New System.Drawing.Point(241, 621)
        Me.txtNumberLPC.MaxLength = 70
        Me.txtNumberLPC.Name = "txtNumberLPC"
        Me.txtNumberLPC.PreventEnterBeep = True
        Me.txtNumberLPC.Size = New System.Drawing.Size(213, 23)
        Me.txtNumberLPC.TabIndex = 16
        '
        'LabelX38
        '
        Me.LabelX38.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX38.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX38.Location = New System.Drawing.Point(15, 620)
        Me.LabelX38.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX38.Name = "LabelX38"
        Me.LabelX38.Size = New System.Drawing.Size(220, 23)
        Me.LabelX38.TabIndex = 1906
        Me.LabelX38.Text = "Number of LPC's :"
        Me.LabelX38.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtTerms
        '
        '
        '
        '
        Me.txtTerms.Border.Class = "TextBoxBorder"
        Me.txtTerms.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTerms.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(241, 592)
        Me.txtTerms.MaxLength = 70
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.PreventEnterBeep = True
        Me.txtTerms.Size = New System.Drawing.Size(213, 23)
        Me.txtTerms.TabIndex = 15
        '
        'LabelX37
        '
        Me.LabelX37.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX37.Location = New System.Drawing.Point(15, 591)
        Me.LabelX37.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(220, 23)
        Me.LabelX37.TabIndex = 1904
        Me.LabelX37.Text = "Term of Loan :"
        Me.LabelX37.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX35
        '
        Me.LabelX35.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX35.Location = New System.Drawing.Point(15, 1415)
        Me.LabelX35.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(1122, 23)
        Me.LabelX35.TabIndex = 1903
        Me.LabelX35.Text = resources.GetString("LabelX35.Text")
        Me.LabelX35.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'iPayments
        '
        '
        '
        '
        Me.iPayments.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iPayments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iPayments.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iPayments.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iPayments.ForeColor = System.Drawing.Color.Black
        Me.iPayments.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iPayments.Location = New System.Drawing.Point(241, 531)
        Me.iPayments.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iPayments.MaxValue = 1000
        Me.iPayments.MinValue = 0
        Me.iPayments.Name = "iPayments"
        Me.iPayments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.iPayments.ShowUpDown = True
        Me.iPayments.Size = New System.Drawing.Size(213, 23)
        Me.iPayments.TabIndex = 14
        Me.iPayments.Value = 1
        '
        'LabelX33
        '
        Me.LabelX33.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX33.Location = New System.Drawing.Point(15, 531)
        Me.LabelX33.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(220, 23)
        Me.LabelX33.TabIndex = 1901
        Me.LabelX33.Text = "Number of Payments Made :"
        Me.LabelX33.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dPrincipalBalance
        '
        '
        '
        '
        Me.dPrincipalBalance.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dPrincipalBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dPrincipalBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dPrincipalBalance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dPrincipalBalance.ForeColor = System.Drawing.Color.Black
        Me.dPrincipalBalance.Increment = 1.0R
        Me.dPrincipalBalance.Location = New System.Drawing.Point(241, 500)
        Me.dPrincipalBalance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dPrincipalBalance.MinValue = 0R
        Me.dPrincipalBalance.Name = "dPrincipalBalance"
        Me.dPrincipalBalance.ShowUpDown = True
        Me.dPrincipalBalance.Size = New System.Drawing.Size(213, 23)
        Me.dPrincipalBalance.TabIndex = 13
        '
        'LabelX34
        '
        Me.LabelX34.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX34.Location = New System.Drawing.Point(15, 499)
        Me.LabelX34.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(220, 23)
        Me.LabelX34.TabIndex = 1899
        Me.LabelX34.Text = "Principal Balance :"
        Me.LabelX34.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtInsuranceInCharge
        '
        '
        '
        '
        Me.txtInsuranceInCharge.Border.Class = "TextBoxBorder"
        Me.txtInsuranceInCharge.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInsuranceInCharge.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsuranceInCharge.Location = New System.Drawing.Point(816, 282)
        Me.txtInsuranceInCharge.MaxLength = 100
        Me.txtInsuranceInCharge.Name = "txtInsuranceInCharge"
        Me.txtInsuranceInCharge.PreventEnterBeep = True
        Me.txtInsuranceInCharge.Size = New System.Drawing.Size(321, 23)
        Me.txtInsuranceInCharge.TabIndex = 21
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX32.Location = New System.Drawing.Point(816, 312)
        Me.LabelX32.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(321, 23)
        Me.LabelX32.TabIndex = 1895
        Me.LabelX32.Text = "Insurance In-Charge"
        Me.LabelX32.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtOR
        '
        '
        '
        '
        Me.txtOR.Border.Class = "TextBoxBorder"
        Me.txtOR.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOR.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOR.Location = New System.Drawing.Point(615, 436)
        Me.txtOR.MaxLength = 70
        Me.txtOR.Name = "txtOR"
        Me.txtOR.PreventEnterBeep = True
        Me.txtOR.Size = New System.Drawing.Size(522, 23)
        Me.txtOR.TabIndex = 45
        '
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX31.Location = New System.Drawing.Point(460, 438)
        Me.LabelX31.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(149, 23)
        Me.LabelX31.TabIndex = 1893
        Me.LabelX31.Text = "OR/CR :"
        Me.LabelX31.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtInsuranceCompany
        '
        '
        '
        '
        Me.txtInsuranceCompany.Border.Class = "TextBoxBorder"
        Me.txtInsuranceCompany.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInsuranceCompany.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsuranceCompany.Location = New System.Drawing.Point(1001, 405)
        Me.txtInsuranceCompany.MaxLength = 50
        Me.txtInsuranceCompany.Name = "txtInsuranceCompany"
        Me.txtInsuranceCompany.PreventEnterBeep = True
        Me.txtInsuranceCompany.Size = New System.Drawing.Size(136, 23)
        Me.txtInsuranceCompany.TabIndex = 40
        '
        'LabelX26
        '
        Me.LabelX26.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX26.Location = New System.Drawing.Point(834, 404)
        Me.LabelX26.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(161, 23)
        Me.LabelX26.TabIndex = 1891
        Me.LabelX26.Text = "Insurance Company :"
        Me.LabelX26.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dAmount_Renewal
        '
        '
        '
        '
        Me.dAmount_Renewal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_Renewal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_Renewal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_Renewal.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_Renewal.ForeColor = System.Drawing.Color.Black
        Me.dAmount_Renewal.Increment = 1.0R
        Me.dAmount_Renewal.Location = New System.Drawing.Point(1001, 375)
        Me.dAmount_Renewal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dAmount_Renewal.MinValue = 0R
        Me.dAmount_Renewal.Name = "dAmount_Renewal"
        Me.dAmount_Renewal.ShowUpDown = True
        Me.dAmount_Renewal.Size = New System.Drawing.Size(136, 23)
        Me.dAmount_Renewal.TabIndex = 30
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
        Me.LabelX29.Location = New System.Drawing.Point(834, 374)
        Me.LabelX29.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(161, 23)
        Me.LabelX29.TabIndex = 1889
        Me.LabelX29.Text = "Amount :"
        Me.LabelX29.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX30
        '
        Me.LabelX30.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX30.Location = New System.Drawing.Point(805, 343)
        Me.LabelX30.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(149, 23)
        Me.LabelX30.TabIndex = 1888
        Me.LabelX30.Text = "Due for Renewal"
        Me.LabelX30.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpGranted_Policy
        '
        '
        '
        '
        Me.dtpGranted_Policy.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpGranted_Policy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Policy.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpGranted_Policy.ButtonDropDown.Visible = True
        Me.dtpGranted_Policy.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpGranted_Policy.ForeColor = System.Drawing.Color.Black
        Me.dtpGranted_Policy.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpGranted_Policy.IsPopupCalendarOpen = False
        Me.dtpGranted_Policy.Location = New System.Drawing.Point(656, 403)
        '
        '
        '
        Me.dtpGranted_Policy.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpGranted_Policy.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Policy.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpGranted_Policy.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpGranted_Policy.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Policy.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpGranted_Policy.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpGranted_Policy.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpGranted_Policy.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpGranted_Policy.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpGranted_Policy.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpGranted_Policy.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Policy.MonthCalendar.TodayButtonVisible = True
        Me.dtpGranted_Policy.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpGranted_Policy.Name = "dtpGranted_Policy"
        Me.dtpGranted_Policy.Size = New System.Drawing.Size(154, 23)
        Me.dtpGranted_Policy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpGranted_Policy.TabIndex = 35
        Me.dtpGranted_Policy.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX25
        '
        Me.LabelX25.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX25.Location = New System.Drawing.Point(489, 403)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(161, 23)
        Me.LabelX25.TabIndex = 1887
        Me.LabelX25.Text = "Date Granted :"
        Me.LabelX25.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dAmount_Policy
        '
        '
        '
        '
        Me.dAmount_Policy.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_Policy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_Policy.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_Policy.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_Policy.ForeColor = System.Drawing.Color.Black
        Me.dAmount_Policy.Increment = 1.0R
        Me.dAmount_Policy.Location = New System.Drawing.Point(656, 373)
        Me.dAmount_Policy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dAmount_Policy.MinValue = 0R
        Me.dAmount_Policy.Name = "dAmount_Policy"
        Me.dAmount_Policy.ShowUpDown = True
        Me.dAmount_Policy.Size = New System.Drawing.Size(154, 23)
        Me.dAmount_Policy.TabIndex = 25
        '
        'LabelX27
        '
        Me.LabelX27.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX27.Location = New System.Drawing.Point(489, 372)
        Me.LabelX27.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(161, 23)
        Me.LabelX27.TabIndex = 1883
        Me.LabelX27.Text = "Amount :"
        Me.LabelX27.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX28.Location = New System.Drawing.Point(460, 341)
        Me.LabelX28.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(149, 23)
        Me.LabelX28.TabIndex = 1882
        Me.LabelX28.Text = "Existing Policy"
        Me.LabelX28.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpGranted_Insurance
        '
        '
        '
        '
        Me.dtpGranted_Insurance.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpGranted_Insurance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Insurance.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpGranted_Insurance.ButtonDropDown.Visible = True
        Me.dtpGranted_Insurance.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpGranted_Insurance.ForeColor = System.Drawing.Color.Black
        Me.dtpGranted_Insurance.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpGranted_Insurance.IsPopupCalendarOpen = False
        Me.dtpGranted_Insurance.Location = New System.Drawing.Point(656, 313)
        '
        '
        '
        Me.dtpGranted_Insurance.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpGranted_Insurance.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Insurance.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpGranted_Insurance.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpGranted_Insurance.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Insurance.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpGranted_Insurance.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpGranted_Insurance.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpGranted_Insurance.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpGranted_Insurance.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpGranted_Insurance.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpGranted_Insurance.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted_Insurance.MonthCalendar.TodayButtonVisible = True
        Me.dtpGranted_Insurance.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpGranted_Insurance.Name = "dtpGranted_Insurance"
        Me.dtpGranted_Insurance.Size = New System.Drawing.Size(154, 23)
        Me.dtpGranted_Insurance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpGranted_Insurance.TabIndex = 22
        Me.dtpGranted_Insurance.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX24.Location = New System.Drawing.Point(489, 313)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(161, 23)
        Me.LabelX24.TabIndex = 1881
        Me.LabelX24.Text = "Date Granted :"
        Me.LabelX24.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX23.Location = New System.Drawing.Point(656, 253)
        Me.LabelX23.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(154, 23)
        Me.LabelX23.TabIndex = 1879
        Me.LabelX23.Text = "(Accounts Receivable)"
        Me.LabelX23.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'dAmount_Insurance
        '
        '
        '
        '
        Me.dAmount_Insurance.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_Insurance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_Insurance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_Insurance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_Insurance.ForeColor = System.Drawing.Color.Black
        Me.dAmount_Insurance.Increment = 1.0R
        Me.dAmount_Insurance.Location = New System.Drawing.Point(656, 284)
        Me.dAmount_Insurance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dAmount_Insurance.MinValue = 0R
        Me.dAmount_Insurance.Name = "dAmount_Insurance"
        Me.dAmount_Insurance.ShowUpDown = True
        Me.dAmount_Insurance.Size = New System.Drawing.Size(154, 23)
        Me.dAmount_Insurance.TabIndex = 20
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX22.Location = New System.Drawing.Point(489, 282)
        Me.LabelX22.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(161, 23)
        Me.LabelX22.TabIndex = 1877
        Me.LabelX22.Text = "Amount :"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX21
        '
        Me.LabelX21.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX21.Location = New System.Drawing.Point(460, 251)
        Me.LabelX21.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(149, 23)
        Me.LabelX21.TabIndex = 1876
        Me.LabelX21.Text = "Unpaid Insurance"
        Me.LabelX21.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.Color.White
        Me.LabelX20.Location = New System.Drawing.Point(460, 220)
        Me.LabelX20.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(350, 23)
        Me.LabelX20.TabIndex = 1875
        Me.LabelX20.Text = "INSURANCE"
        Me.LabelX20.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'dAmountDue
        '
        '
        '
        '
        Me.dAmountDue.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmountDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmountDue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmountDue.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmountDue.ForeColor = System.Drawing.Color.Black
        Me.dAmountDue.Increment = 1.0R
        Me.dAmountDue.Location = New System.Drawing.Point(241, 438)
        Me.dAmountDue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dAmountDue.MinValue = 0R
        Me.dAmountDue.Name = "dAmountDue"
        Me.dAmountDue.ShowUpDown = True
        Me.dAmountDue.Size = New System.Drawing.Size(213, 23)
        Me.dAmountDue.TabIndex = 12
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX19.Location = New System.Drawing.Point(15, 437)
        Me.LabelX19.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(220, 23)
        Me.LabelX19.TabIndex = 1873
        Me.LabelX19.Text = "Total Amount Due :"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dUDI
        '
        '
        '
        '
        Me.dUDI.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dUDI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dUDI.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dUDI.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dUDI.ForeColor = System.Drawing.Color.Black
        Me.dUDI.Increment = 1.0R
        Me.dUDI.Location = New System.Drawing.Point(241, 407)
        Me.dUDI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dUDI.MinValue = 0R
        Me.dUDI.Name = "dUDI"
        Me.dUDI.ShowUpDown = True
        Me.dUDI.Size = New System.Drawing.Size(213, 23)
        Me.dUDI.TabIndex = 11
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX18.Location = New System.Drawing.Point(15, 406)
        Me.LabelX18.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(220, 23)
        Me.LabelX18.TabIndex = 1871
        Me.LabelX18.Text = "UDI :"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dRPPD
        '
        '
        '
        '
        Me.dRPPD.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dRPPD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dRPPD.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dRPPD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dRPPD.ForeColor = System.Drawing.Color.Black
        Me.dRPPD.Increment = 1.0R
        Me.dRPPD.Location = New System.Drawing.Point(241, 376)
        Me.dRPPD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dRPPD.MinValue = 0R
        Me.dRPPD.Name = "dRPPD"
        Me.dRPPD.ShowUpDown = True
        Me.dRPPD.Size = New System.Drawing.Size(213, 23)
        Me.dRPPD.TabIndex = 10
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX16.Location = New System.Drawing.Point(15, 375)
        Me.LabelX16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(220, 23)
        Me.LabelX16.TabIndex = 1869
        Me.LabelX16.Text = "Less : RPPD :"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dBalance
        '
        '
        '
        '
        Me.dBalance.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dBalance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dBalance.ForeColor = System.Drawing.Color.Black
        Me.dBalance.Increment = 1.0R
        Me.dBalance.Location = New System.Drawing.Point(241, 345)
        Me.dBalance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dBalance.MinValue = 0R
        Me.dBalance.Name = "dBalance"
        Me.dBalance.ShowUpDown = True
        Me.dBalance.Size = New System.Drawing.Size(213, 23)
        Me.dBalance.TabIndex = 9
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(15, 344)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(220, 23)
        Me.LabelX15.TabIndex = 1867
        Me.LabelX15.Text = "Balance :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dLPC
        '
        '
        '
        '
        Me.dLPC.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dLPC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dLPC.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dLPC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dLPC.ForeColor = System.Drawing.Color.Black
        Me.dLPC.Increment = 1.0R
        Me.dLPC.Location = New System.Drawing.Point(241, 314)
        Me.dLPC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dLPC.MinValue = 0R
        Me.dLPC.Name = "dLPC"
        Me.dLPC.ShowUpDown = True
        Me.dLPC.Size = New System.Drawing.Size(213, 23)
        Me.dLPC.TabIndex = 8
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.Location = New System.Drawing.Point(15, 313)
        Me.LabelX14.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(220, 23)
        Me.LabelX14.TabIndex = 1865
        Me.LabelX14.Text = "LPC :"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dInterestDue
        '
        '
        '
        '
        Me.dInterestDue.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dInterestDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dInterestDue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dInterestDue.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dInterestDue.ForeColor = System.Drawing.Color.Black
        Me.dInterestDue.Increment = 1.0R
        Me.dInterestDue.Location = New System.Drawing.Point(241, 283)
        Me.dInterestDue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dInterestDue.MinValue = 0R
        Me.dInterestDue.Name = "dInterestDue"
        Me.dInterestDue.ShowUpDown = True
        Me.dInterestDue.Size = New System.Drawing.Size(213, 23)
        Me.dInterestDue.TabIndex = 7
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX10.Location = New System.Drawing.Point(15, 282)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(220, 23)
        Me.LabelX10.TabIndex = 1863
        Me.LabelX10.Text = "Plus : Interest Due :"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dOutstanding
        '
        '
        '
        '
        Me.dOutstanding.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dOutstanding.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dOutstanding.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dOutstanding.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dOutstanding.ForeColor = System.Drawing.Color.Black
        Me.dOutstanding.Increment = 1.0R
        Me.dOutstanding.Location = New System.Drawing.Point(241, 252)
        Me.dOutstanding.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dOutstanding.MinValue = 0R
        Me.dOutstanding.Name = "dOutstanding"
        Me.dOutstanding.ShowUpDown = True
        Me.dOutstanding.Size = New System.Drawing.Size(213, 23)
        Me.dOutstanding.TabIndex = 6
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
        Me.LabelX8.Location = New System.Drawing.Point(15, 251)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(220, 23)
        Me.LabelX8.TabIndex = 1861
        Me.LabelX8.Text = "Outstanding Balance :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpAsOf
        '
        '
        '
        '
        Me.dtpAsOf.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpAsOf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpAsOf.ButtonDropDown.Visible = True
        Me.dtpAsOf.CustomFormat = "MMMM dd, yyyy"
        Me.dtpAsOf.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAsOf.ForeColor = System.Drawing.Color.Black
        Me.dtpAsOf.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpAsOf.IsPopupCalendarOpen = False
        Me.dtpAsOf.Location = New System.Drawing.Point(149, 222)
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpAsOf.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpAsOf.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpAsOf.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.MonthCalendar.TodayButtonVisible = True
        Me.dtpAsOf.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpAsOf.Name = "dtpAsOf"
        Me.dtpAsOf.Size = New System.Drawing.Size(153, 23)
        Me.dtpAsOf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpAsOf.TabIndex = 5
        Me.dtpAsOf.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX7.Location = New System.Drawing.Point(46, 222)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(97, 23)
        Me.LabelX7.TabIndex = 1860
        Me.LabelX7.Text = "As of :"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxMonthly
        '
        Me.cbxMonthly.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxMonthly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMonthly.Enabled = False
        Me.cbxMonthly.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMonthly.Location = New System.Drawing.Point(317, 193)
        Me.cbxMonthly.Name = "cbxMonthly"
        Me.cbxMonthly.Size = New System.Drawing.Size(76, 23)
        Me.cbxMonthly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMonthly.TabIndex = 1858
        Me.cbxMonthly.Text = "Monthly"
        '
        'cbxBimonthly
        '
        Me.cbxBimonthly.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxBimonthly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxBimonthly.Enabled = False
        Me.cbxBimonthly.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBimonthly.Location = New System.Drawing.Point(225, 193)
        Me.cbxBimonthly.Name = "cbxBimonthly"
        Me.cbxBimonthly.Size = New System.Drawing.Size(116, 23)
        Me.cbxBimonthly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxBimonthly.TabIndex = 1857
        Me.cbxBimonthly.Text = "Bimonthly"
        '
        'cbxWeekly
        '
        Me.cbxWeekly.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxWeekly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxWeekly.Enabled = False
        Me.cbxWeekly.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxWeekly.Location = New System.Drawing.Point(150, 193)
        Me.cbxWeekly.Name = "cbxWeekly"
        Me.cbxWeekly.Size = New System.Drawing.Size(116, 23)
        Me.cbxWeekly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxWeekly.TabIndex = 1856
        Me.cbxWeekly.Text = "Weekly"
        '
        'cbxDaily
        '
        Me.cbxDaily.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDaily.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDaily.Enabled = False
        Me.cbxDaily.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDaily.Location = New System.Drawing.Point(91, 193)
        Me.cbxDaily.Name = "cbxDaily"
        Me.cbxDaily.Size = New System.Drawing.Size(116, 23)
        Me.cbxDaily.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDaily.TabIndex = 1855
        Me.cbxDaily.Text = "Daily"
        '
        'txtCollateral_7
        '
        '
        '
        '
        Me.txtCollateral_7.Border.Class = "TextBoxBorder"
        Me.txtCollateral_7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_7.Enabled = False
        Me.txtCollateral_7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_7.Location = New System.Drawing.Point(816, 193)
        Me.txtCollateral_7.MaxLength = 70
        Me.txtCollateral_7.Name = "txtCollateral_7"
        Me.txtCollateral_7.PreventEnterBeep = True
        Me.txtCollateral_7.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_7.TabIndex = 1854
        '
        'dMonthlyAmortization
        '
        '
        '
        '
        Me.dMonthlyAmortization.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dMonthlyAmortization.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dMonthlyAmortization.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dMonthlyAmortization.Enabled = False
        Me.dMonthlyAmortization.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dMonthlyAmortization.ForeColor = System.Drawing.Color.Black
        Me.dMonthlyAmortization.Increment = 1.0R
        Me.dMonthlyAmortization.Location = New System.Drawing.Point(563, 194)
        Me.dMonthlyAmortization.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dMonthlyAmortization.MinValue = 0R
        Me.dMonthlyAmortization.Name = "dMonthlyAmortization"
        Me.dMonthlyAmortization.ShowUpDown = True
        Me.dMonthlyAmortization.Size = New System.Drawing.Size(153, 23)
        Me.dMonthlyAmortization.TabIndex = 1853
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(399, 193)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(158, 23)
        Me.LabelX5.TabIndex = 1852
        Me.LabelX5.Text = "Monthly Amortization :"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtCollateral_6
        '
        '
        '
        '
        Me.txtCollateral_6.Border.Class = "TextBoxBorder"
        Me.txtCollateral_6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_6.Enabled = False
        Me.txtCollateral_6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_6.Location = New System.Drawing.Point(816, 160)
        Me.txtCollateral_6.MaxLength = 70
        Me.txtCollateral_6.Name = "txtCollateral_6"
        Me.txtCollateral_6.PreventEnterBeep = True
        Me.txtCollateral_6.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_6.TabIndex = 1851
        '
        'dtpGranted
        '
        '
        '
        '
        Me.dtpGranted.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpGranted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpGranted.ButtonDropDown.Visible = True
        Me.dtpGranted.CustomFormat = "MMMM dd, yyyy"
        Me.dtpGranted.Enabled = False
        Me.dtpGranted.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpGranted.ForeColor = System.Drawing.Color.Black
        Me.dtpGranted.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpGranted.IsPopupCalendarOpen = False
        Me.dtpGranted.Location = New System.Drawing.Point(563, 103)
        '
        '
        '
        Me.dtpGranted.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpGranted.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpGranted.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpGranted.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpGranted.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpGranted.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpGranted.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpGranted.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpGranted.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpGranted.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpGranted.MonthCalendar.TodayButtonVisible = True
        Me.dtpGranted.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpGranted.Name = "dtpGranted"
        Me.dtpGranted.Size = New System.Drawing.Size(153, 23)
        Me.dtpGranted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpGranted.TabIndex = 1849
        Me.dtpGranted.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
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
        Me.LabelX4.Location = New System.Drawing.Point(418, 103)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(139, 23)
        Me.LabelX4.TabIndex = 1850
        Me.LabelX4.Text = "Date Granted :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iDue
        '
        '
        '
        '
        Me.iDue.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iDue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iDue.Enabled = False
        Me.iDue.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iDue.ForeColor = System.Drawing.Color.Black
        Me.iDue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.iDue.Location = New System.Drawing.Point(563, 74)
        Me.iDue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iDue.MaxValue = 1000
        Me.iDue.MinValue = 0
        Me.iDue.Name = "iDue"
        Me.iDue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.iDue.ShowUpDown = True
        Me.iDue.Size = New System.Drawing.Size(153, 23)
        Me.iDue.TabIndex = 1848
        Me.iDue.Value = 1
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(418, 74)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(139, 23)
        Me.LabelX3.TabIndex = 1847
        Me.LabelX3.Text = "Due :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtCollateral_5
        '
        '
        '
        '
        Me.txtCollateral_5.Border.Class = "TextBoxBorder"
        Me.txtCollateral_5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_5.Enabled = False
        Me.txtCollateral_5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_5.Location = New System.Drawing.Point(816, 131)
        Me.txtCollateral_5.MaxLength = 70
        Me.txtCollateral_5.Name = "txtCollateral_5"
        Me.txtCollateral_5.PreventEnterBeep = True
        Me.txtCollateral_5.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_5.TabIndex = 1846
        '
        'txtCollateral_4
        '
        '
        '
        '
        Me.txtCollateral_4.Border.Class = "TextBoxBorder"
        Me.txtCollateral_4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_4.Enabled = False
        Me.txtCollateral_4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_4.Location = New System.Drawing.Point(816, 102)
        Me.txtCollateral_4.MaxLength = 70
        Me.txtCollateral_4.Name = "txtCollateral_4"
        Me.txtCollateral_4.PreventEnterBeep = True
        Me.txtCollateral_4.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_4.TabIndex = 1845
        '
        'txtCollateral_3
        '
        '
        '
        '
        Me.txtCollateral_3.Border.Class = "TextBoxBorder"
        Me.txtCollateral_3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_3.Enabled = False
        Me.txtCollateral_3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_3.Location = New System.Drawing.Point(816, 73)
        Me.txtCollateral_3.MaxLength = 70
        Me.txtCollateral_3.Name = "txtCollateral_3"
        Me.txtCollateral_3.PreventEnterBeep = True
        Me.txtCollateral_3.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_3.TabIndex = 1844
        '
        'txtCollateral_2
        '
        '
        '
        '
        Me.txtCollateral_2.Border.Class = "TextBoxBorder"
        Me.txtCollateral_2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_2.Enabled = False
        Me.txtCollateral_2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_2.Location = New System.Drawing.Point(816, 44)
        Me.txtCollateral_2.MaxLength = 70
        Me.txtCollateral_2.Name = "txtCollateral_2"
        Me.txtCollateral_2.PreventEnterBeep = True
        Me.txtCollateral_2.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_2.TabIndex = 1843
        '
        'dFaceAmount
        '
        '
        '
        '
        Me.dFaceAmount.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dFaceAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dFaceAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dFaceAmount.Enabled = False
        Me.dFaceAmount.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dFaceAmount.ForeColor = System.Drawing.Color.Black
        Me.dFaceAmount.Increment = 1.0R
        Me.dFaceAmount.Location = New System.Drawing.Point(563, 163)
        Me.dFaceAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dFaceAmount.MinValue = 0R
        Me.dFaceAmount.Name = "dFaceAmount"
        Me.dFaceAmount.ShowUpDown = True
        Me.dFaceAmount.Size = New System.Drawing.Size(153, 23)
        Me.dFaceAmount.TabIndex = 1784
        '
        'LabelX45
        '
        Me.LabelX45.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX45.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX45.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX45.Location = New System.Drawing.Point(418, 162)
        Me.LabelX45.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX45.Name = "LabelX45"
        Me.LabelX45.Size = New System.Drawing.Size(139, 23)
        Me.LabelX45.TabIndex = 1781
        Me.LabelX45.Text = "Face Amount :"
        Me.LabelX45.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.dPrincipal.Location = New System.Drawing.Point(563, 132)
        Me.dPrincipal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dPrincipal.MinValue = 0R
        Me.dPrincipal.Name = "dPrincipal"
        Me.dPrincipal.ShowUpDown = True
        Me.dPrincipal.Size = New System.Drawing.Size(153, 23)
        Me.dPrincipal.TabIndex = 1758
        '
        'LabelX36
        '
        Me.LabelX36.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX36.Location = New System.Drawing.Point(418, 131)
        Me.LabelX36.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(139, 23)
        Me.LabelX36.TabIndex = 1752
        Me.LabelX36.Text = "Principal :"
        Me.LabelX36.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblPlateNum
        '
        Me.lblPlateNum.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblPlateNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPlateNum.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlateNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPlateNum.Location = New System.Drawing.Point(46, 45)
        Me.lblPlateNum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblPlateNum.Name = "lblPlateNum"
        Me.lblPlateNum.Size = New System.Drawing.Size(97, 23)
        Me.lblPlateNum.TabIndex = 1723
        Me.lblPlateNum.Text = "Account No. :"
        Me.lblPlateNum.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtCollateral_1
        '
        '
        '
        '
        Me.txtCollateral_1.Border.Class = "TextBoxBorder"
        Me.txtCollateral_1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCollateral_1.Enabled = False
        Me.txtCollateral_1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollateral_1.Location = New System.Drawing.Point(816, 14)
        Me.txtCollateral_1.MaxLength = 70
        Me.txtCollateral_1.Name = "txtCollateral_1"
        Me.txtCollateral_1.PreventEnterBeep = True
        Me.txtCollateral_1.Size = New System.Drawing.Size(321, 23)
        Me.txtCollateral_1.TabIndex = 1721
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.Location = New System.Drawing.Point(722, 13)
        Me.LabelX13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(88, 23)
        Me.LabelX13.TabIndex = 1720
        Me.LabelX13.Text = "Collateral :"
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtComaker4
        '
        '
        '
        '
        Me.txtComaker4.Border.Class = "TextBoxBorder"
        Me.txtComaker4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComaker4.Enabled = False
        Me.txtComaker4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComaker4.Location = New System.Drawing.Point(149, 161)
        Me.txtComaker4.MaxLength = 70
        Me.txtComaker4.Name = "txtComaker4"
        Me.txtComaker4.PreventEnterBeep = True
        Me.txtComaker4.Size = New System.Drawing.Size(263, 23)
        Me.txtComaker4.TabIndex = 1716
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX12.Location = New System.Drawing.Point(6, 160)
        Me.LabelX12.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(137, 23)
        Me.LabelX12.TabIndex = 1715
        Me.LabelX12.Text = "Co-maker IV :"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtComaker3
        '
        '
        '
        '
        Me.txtComaker3.Border.Class = "TextBoxBorder"
        Me.txtComaker3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComaker3.Enabled = False
        Me.txtComaker3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComaker3.Location = New System.Drawing.Point(149, 132)
        Me.txtComaker3.MaxLength = 70
        Me.txtComaker3.Name = "txtComaker3"
        Me.txtComaker3.PreventEnterBeep = True
        Me.txtComaker3.Size = New System.Drawing.Size(263, 23)
        Me.txtComaker3.TabIndex = 1711
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX9.Location = New System.Drawing.Point(6, 131)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(137, 23)
        Me.LabelX9.TabIndex = 1710
        Me.LabelX9.Text = "Co-maker III :"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtComaker2
        '
        '
        '
        '
        Me.txtComaker2.Border.Class = "TextBoxBorder"
        Me.txtComaker2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComaker2.Enabled = False
        Me.txtComaker2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComaker2.Location = New System.Drawing.Point(149, 103)
        Me.txtComaker2.MaxLength = 70
        Me.txtComaker2.Name = "txtComaker2"
        Me.txtComaker2.PreventEnterBeep = True
        Me.txtComaker2.Size = New System.Drawing.Size(263, 23)
        Me.txtComaker2.TabIndex = 1706
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
        Me.LabelX6.Location = New System.Drawing.Point(7, 102)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(136, 23)
        Me.LabelX6.TabIndex = 1705
        Me.LabelX6.Text = "Co-maker II :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtComaker1
        '
        '
        '
        '
        Me.txtComaker1.Border.Class = "TextBoxBorder"
        Me.txtComaker1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComaker1.Enabled = False
        Me.txtComaker1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComaker1.Location = New System.Drawing.Point(149, 74)
        Me.txtComaker1.MaxLength = 70
        Me.txtComaker1.Name = "txtComaker1"
        Me.txtComaker1.PreventEnterBeep = True
        Me.txtComaker1.Size = New System.Drawing.Size(263, 23)
        Me.txtComaker1.TabIndex = 1696
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
        Me.LabelX2.Location = New System.Drawing.Point(7, 73)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(136, 23)
        Me.LabelX2.TabIndex = 1695
        Me.LabelX2.Text = "Co-maker I :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpDate
        '
        '
        '
        '
        Me.dtpDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpDate.ButtonDropDown.Visible = True
        Me.dtpDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.ForeColor = System.Drawing.Color.Black
        Me.dtpDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpDate.IsPopupCalendarOpen = False
        Me.dtpDate.Location = New System.Drawing.Point(563, 14)
        '
        '
        '
        Me.dtpDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(153, 23)
        Me.dtpDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpDate.TabIndex = 1
        Me.dtpDate.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'cbxApplication
        '
        Me.cbxApplication.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxApplication.FormattingEnabled = True
        Me.cbxApplication.Location = New System.Drawing.Point(149, 14)
        Me.cbxApplication.Name = "cbxApplication"
        Me.cbxApplication.Size = New System.Drawing.Size(263, 25)
        Me.cbxApplication.TabIndex = 0
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX155.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX155.BackgroundStyle.BorderBottomWidth = 3
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX155.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX155.Location = New System.Drawing.Point(7, 16)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(137, 23)
        Me.LabelX155.TabIndex = 487
        Me.LabelX155.Text = "Borrower :"
        Me.LabelX155.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(418, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(139, 23)
        Me.LabelX1.TabIndex = 490
        Me.LabelX1.Text = "Document Date :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tabSetup
        '
        Me.tabSetup.AttachedControl = Me.SuperTabControlPanel1
        Me.tabSetup.GlobalItem = False
        Me.tabSetup.Name = "tabSetup"
        Me.tabSetup.Text = "Credit Referral Slip"
        Me.tabSetup.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = True
        Me.SuperTabControlPanel2.Controls.Add(Me.GridControl1)
        Me.SuperTabControlPanel2.Controls.Add(Me.PanelEx19)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabList
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(0, 66)
        Me.GridControl1.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1167, 503)
        Me.GridControl1.TabIndex = 1678
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.DetailTip.Options.UseFont = True
        Me.GridView1.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.Empty.Options.UseBackColor = True
        Me.GridView1.Appearance.Empty.Options.UseFont = True
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.EvenRow.Options.UseFont = True
        Me.GridView1.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.FilterCloseButton.Options.UseFont = True
        Me.GridView1.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView1.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.FilterPanel.Options.UseFont = True
        Me.GridView1.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView1.Appearance.FixedLine.Options.UseFont = True
        Me.GridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseFont = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.GridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupButton.Options.UseFont = True
        Me.GridView1.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupFooter.Options.UseFont = True
        Me.GridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupPanel.Options.UseFont = True
        Me.GridView1.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupRow.Options.UseFont = True
        Me.GridView1.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView1.Appearance.HideSelectionRow.Options.UseFont = True
        Me.GridView1.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView1.Appearance.HorzLine.Options.UseFont = True
        Me.GridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.Options.UseFont = True
        Me.GridView1.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.GridView1.Appearance.Preview.Options.UseBackColor = True
        Me.GridView1.Appearance.Preview.Options.UseFont = True
        Me.GridView1.Appearance.Preview.Options.UseForeColor = True
        Me.GridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.Row.Options.UseBackColor = True
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Appearance.Row.Options.UseForeColor = True
        Me.GridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView1.Appearance.RowSeparator.Options.UseFont = True
        Me.GridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.SelectedRow.Options.UseFont = True
        Me.GridView1.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.TopNewRow.Options.UseBackColor = True
        Me.GridView1.Appearance.TopNewRow.Options.UseFont = True
        Me.GridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView1.Appearance.VertLine.Options.UseFont = True
        Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView1.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn9, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn29})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupPanelText = "General Requirements"
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreAppearance = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PaintStyleName = "Style3D"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Document Date"
        Me.GridColumn2.FieldName = "Document Date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 125
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Document No"
        Me.GridColumn3.FieldName = "Document Number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 125
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "BorrowerID"
        Me.GridColumn4.FieldName = "BorrowerID"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Borrower"
        Me.GridColumn5.FieldName = "Borrower"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 200
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Credit Number"
        Me.GridColumn9.FieldName = "Credit Number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 135
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Account Number"
        Me.GridColumn13.FieldName = "Account Number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 4
        Me.GridColumn13.Width = 135
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Total Score"
        Me.GridColumn14.FieldName = "Total Score"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 5
        Me.GridColumn14.Width = 114
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "Score Rate"
        Me.GridColumn15.FieldName = "Score Rate"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 6
        Me.GridColumn15.Width = 113
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Prepared By"
        Me.GridColumn16.FieldName = "Prepared By"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 7
        Me.GridColumn16.Width = 200
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Requested By"
        Me.GridColumn17.FieldName = "Requested By"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 8
        Me.GridColumn17.Width = 200
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Remarks"
        Me.GridColumn18.FieldName = "Remarks"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 9
        Me.GridColumn18.Width = 350
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Branch"
        Me.GridColumn29.FieldName = "Branch"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Width = 200
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "True"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "False"
        '
        'PanelEx19
        '
        Me.PanelEx19.AutoScroll = True
        Me.PanelEx19.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx19.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx19.Controls.Add(Me.btnSearch)
        Me.PanelEx19.Controls.Add(Me.cbxAll)
        Me.PanelEx19.Controls.Add(Me.cbxDisplay)
        Me.PanelEx19.Controls.Add(Me.LabelX47)
        Me.PanelEx19.Controls.Add(Me.dtpTo)
        Me.PanelEx19.Controls.Add(Me.LabelX48)
        Me.PanelEx19.Controls.Add(Me.dtpFrom)
        Me.PanelEx19.Controls.Add(Me.LabelX49)
        Me.PanelEx19.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx19.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx19.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx19.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx19.Name = "PanelEx19"
        Me.PanelEx19.Size = New System.Drawing.Size(1167, 66)
        Me.PanelEx19.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx19.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx19.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx19.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx19.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx19.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left
        Me.PanelEx19.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx19.Style.GradientAngle = 90
        Me.PanelEx19.TabIndex = 1681
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnSearch.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSearch.Location = New System.Drawing.Point(507, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 30)
        Me.btnSearch.TabIndex = 40
        Me.btnSearch.Text = "Search"
        '
        'cbxAll
        '
        Me.cbxAll.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAll.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAll.Location = New System.Drawing.Point(456, 6)
        Me.cbxAll.Name = "cbxAll"
        Me.cbxAll.Size = New System.Drawing.Size(45, 23)
        Me.cbxAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAll.TabIndex = 10
        Me.cbxAll.Text = "All"
        '
        'cbxDisplay
        '
        Me.cbxDisplay.DisplayMember = "PREFIX"
        Me.cbxDisplay.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDisplay.FormattingEnabled = True
        Me.cbxDisplay.Items.AddRange(New Object() {"Today", "This Week", "This Month", "This Year", "Range"})
        Me.cbxDisplay.Location = New System.Drawing.Point(71, 6)
        Me.cbxDisplay.Name = "cbxDisplay"
        Me.cbxDisplay.Size = New System.Drawing.Size(379, 25)
        Me.cbxDisplay.TabIndex = 5
        Me.cbxDisplay.ValueMember = "ID"
        '
        'LabelX47
        '
        Me.LabelX47.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX47.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX47.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX47.Location = New System.Drawing.Point(9, 6)
        Me.LabelX47.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX47.Name = "LabelX47"
        Me.LabelX47.Size = New System.Drawing.Size(56, 23)
        Me.LabelX47.TabIndex = 96
        Me.LabelX47.Text = "Display :"
        Me.LabelX47.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpTo
        '
        '
        '
        '
        Me.dtpTo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpTo.ButtonDropDown.Visible = True
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.ForeColor = System.Drawing.Color.Black
        Me.dtpTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpTo.IsPopupCalendarOpen = False
        Me.dtpTo.Location = New System.Drawing.Point(289, 35)
        '
        '
        '
        Me.dtpTo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpTo.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTo.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpTo.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpTo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTo.MonthCalendar.TodayButtonVisible = True
        Me.dtpTo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(161, 23)
        Me.dtpTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpTo.TabIndex = 20
        Me.dtpTo.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX48
        '
        Me.LabelX48.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX48.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX48.Location = New System.Drawing.Point(237, 35)
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Size = New System.Drawing.Size(46, 23)
        Me.LabelX48.TabIndex = 94
        Me.LabelX48.Text = "To :"
        Me.LabelX48.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpFrom
        '
        '
        '
        '
        Me.dtpFrom.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFrom.ButtonDropDown.Visible = True
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.ForeColor = System.Drawing.Color.Black
        Me.dtpFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpFrom.IsPopupCalendarOpen = False
        Me.dtpFrom.Location = New System.Drawing.Point(71, 35)
        '
        '
        '
        Me.dtpFrom.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpFrom.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFrom.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpFrom.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFrom.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFrom.MonthCalendar.TodayButtonVisible = True
        Me.dtpFrom.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(161, 23)
        Me.dtpFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFrom.TabIndex = 15
        Me.dtpFrom.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX49
        '
        Me.LabelX49.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX49.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX49.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX49.Location = New System.Drawing.Point(9, 35)
        Me.LabelX49.Name = "LabelX49"
        Me.LabelX49.Size = New System.Drawing.Size(56, 23)
        Me.LabelX49.TabIndex = 92
        Me.LabelX49.Text = "From :"
        Me.LabelX49.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tabList
        '
        Me.tabList.AttachedControl = Me.SuperTabControlPanel2
        Me.tabList.GlobalItem = False
        Me.tabList.Name = "tabList"
        Me.tabList.Text = "Credit Referral List"
        Me.tabList.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'FrmCreditReferralSlip
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCreditReferralSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.PanelEx10.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTotal_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iCredit_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iSettlement_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iRepayment_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iHistory_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTime_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTotal_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dCredit_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dSettlement_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dRepayment_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dHistory_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTime_Score, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPrincipalBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_Renewal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpGranted_Policy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_Policy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpGranted_Insurance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_Insurance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmountDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dUDI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dRPPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dLPC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dInterestDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dOutstanding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpAsOf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dMonthlyAmortization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpGranted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dFaceAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx19.ResumeLayout(False)
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnModify As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBack As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanelEx10 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbxRequested As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX65 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX64 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxPreparedBy As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX63 As DevComponents.DotNetBar.LabelX
    Friend WithEvents rExplanation As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX62 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX61 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemarks_Score As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX59 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dTotal_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX60 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dCredit_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX57 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX58 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dSettlement_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX55 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX56 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dRepayment_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX53 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dHistory_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX51 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX52 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dTime_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX50 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX46 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX44 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX42 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxLoanType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtPresentStatus As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDeliquency As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNumberLPC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX38 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTerms As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iPayments As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dPrincipalBalance As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtInsuranceInCharge As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtOR As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtInsuranceCompany As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dAmount_Renewal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpGranted_Policy As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dAmount_Policy As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpGranted_Insurance As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dAmount_Insurance As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dAmountDue As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dUDI As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dRPPD As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dBalance As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dLPC As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dInterestDue As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dOutstanding As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpAsOf As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxMonthly As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxBimonthly As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxWeekly As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxDaily As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtCollateral_7 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dMonthlyAmortization As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCollateral_6 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpGranted As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iDue As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCollateral_5 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCollateral_4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCollateral_3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCollateral_2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dFaceAmount As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX45 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dPrincipal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPlateNum As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCollateral_1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtComaker4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtComaker3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtComaker2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtComaker1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cbxApplication As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tabSetup As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tabList As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents PanelEx19 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxDisplay As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX47 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpTo As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpFrom As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX49 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAccountNumber As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtDocumentNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents iTotal_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents iCredit_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents iSettlement_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents iRepayment_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents iHistory_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents iTime_Score As DevComponents.Editors.DoubleInput
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuBar3 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLedger As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLedger2 As DevComponents.DotNetBar.ButtonItem
End Class
