<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCashAdvanceSlip
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCashAdvanceSlip))
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.cbxReceived = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxForLiquidation = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxForCheckVoucher = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxCancelled = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxLiquidated = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ContextMenuBar3 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCheckVoucher = New DevComponents.DotNetBar.ButtonItem()
        Me.btnTagCheckVoucher = New DevComponents.DotNetBar.ButtonItem()
        Me.iLiquidate = New DevComponents.DotNetBar.ButtonItem()
        Me.iTagLiquidate = New DevComponents.DotNetBar.ButtonItem()
        Me.iReturn = New DevComponents.DotNetBar.ButtonItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cbxForApproval = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.PanelEx19 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.cbxStatus = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.cbxAll = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxDisplay = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.dtpTo = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        Me.dtpFrom = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX42 = New DevComponents.DotNetBar.LabelX()
        Me.tabList = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanelEx10 = New DevComponents.DotNetBar.PanelEx()
        Me.cbxOther = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxPreparedBy = New SergeUtils.EasyCompletionComboBox()
        Me.txtReceivedDate = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.txtReceived = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtApproved = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX44 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX38 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.gSignatory = New DevExpress.XtraEditors.GroupControl()
        Me.txtName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpDate_2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtpPayroll = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.dtpLiquidate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.gLiquidation = New DevExpress.XtraEditors.GroupControl()
        Me.dtp_7 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_7 = New DevComponents.Editors.DoubleInput()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.dTotalLiquidation = New DevComponents.Editors.DoubleInput()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.dtp_6 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_6 = New DevComponents.Editors.DoubleInput()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.dtp_5 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_5 = New DevComponents.Editors.DoubleInput()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.dtp_4 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_4 = New DevComponents.Editors.DoubleInput()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.dtp_3 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_3 = New DevComponents.Editors.DoubleInput()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.dtp_2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_2 = New DevComponents.Editors.DoubleInput()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.dtp_1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dAmount_1 = New DevComponents.Editors.DoubleInput()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.gRequest = New DevExpress.XtraEditors.GroupControl()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.dTotal = New DevComponents.Editors.DoubleInput()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.dOthers = New DevComponents.Editors.DoubleInput()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.dNotarizationF = New DevComponents.Editors.DoubleInput()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.dLTO = New DevComponents.Editors.DoubleInput()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.dRD = New DevComponents.Editors.DoubleInput()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dBIR = New DevComponents.Editors.DoubleInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.dTransportation = New DevComponents.Editors.DoubleInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX99 = New DevComponents.DotNetBar.LabelX()
        Me.dMeal = New DevComponents.Editors.DoubleInput()
        Me.LabelX100 = New DevComponents.DotNetBar.LabelX()
        Me.txtAccountNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.dtpDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.cbxPayee = New SergeUtils.EasyCompletionComboBox()
        Me.txtPurpose = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tabSetup = New DevComponents.DotNetBar.SuperTabItem()
        Me.btnApproveCrecomm = New DevComponents.DotNetBar.ButtonX()
        Me.btnReceive = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnModify = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.btnBack = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnEmailCrecom = New DevComponents.DotNetBar.ButtonX()
        Me.btnDisapprove = New DevComponents.DotNetBar.ButtonX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnAttach = New DevComponents.DotNetBar.ButtonX()
        Me.btnApprove = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx19.SuspendLayout()
        CType(Me.cbxStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.PanelEx10.SuspendLayout()
        CType(Me.gSignatory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gSignatory.SuspendLayout()
        CType(Me.dtpDate_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpLiquidate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gLiquidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gLiquidation.SuspendLayout()
        CType(Me.dtp_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTotalLiquidation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtp_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dAmount_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gRequest.SuspendLayout()
        CType(Me.dTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dOthers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dNotarizationF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dLTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dBIR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTransportation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dMeal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
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
        Me.SuperTabControl1.TabIndex = 1012
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabSetup, Me.tabList})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = True
        Me.SuperTabControlPanel2.Controls.Add(Me.cbxReceived)
        Me.SuperTabControlPanel2.Controls.Add(Me.cbxForLiquidation)
        Me.SuperTabControlPanel2.Controls.Add(Me.cbxForCheckVoucher)
        Me.SuperTabControlPanel2.Controls.Add(Me.cbxCancelled)
        Me.SuperTabControlPanel2.Controls.Add(Me.cbxLiquidated)
        Me.SuperTabControlPanel2.Controls.Add(Me.ContextMenuBar3)
        Me.SuperTabControlPanel2.Controls.Add(Me.cbxForApproval)
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
        'cbxReceived
        '
        Me.cbxReceived.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxReceived.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxReceived.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxReceived.Location = New System.Drawing.Point(500, 213)
        Me.cbxReceived.Name = "cbxReceived"
        Me.cbxReceived.Size = New System.Drawing.Size(140, 23)
        Me.cbxReceived.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxReceived.TabIndex = 1753
        Me.cbxReceived.Text = "Received"
        Me.cbxReceived.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.cbxReceived.Visible = False
        '
        'cbxForLiquidation
        '
        Me.cbxForLiquidation.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxForLiquidation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxForLiquidation.Checked = True
        Me.cbxForLiquidation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxForLiquidation.CheckValue = "Y"
        Me.cbxForLiquidation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxForLiquidation.Location = New System.Drawing.Point(559, 184)
        Me.cbxForLiquidation.Name = "cbxForLiquidation"
        Me.cbxForLiquidation.Size = New System.Drawing.Size(140, 23)
        Me.cbxForLiquidation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxForLiquidation.TabIndex = 45
        Me.cbxForLiquidation.Text = "For Liquidation"
        Me.cbxForLiquidation.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.cbxForLiquidation.Visible = False
        '
        'cbxForCheckVoucher
        '
        Me.cbxForCheckVoucher.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxForCheckVoucher.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxForCheckVoucher.Checked = True
        Me.cbxForCheckVoucher.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxForCheckVoucher.CheckValue = "Y"
        Me.cbxForCheckVoucher.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxForCheckVoucher.Location = New System.Drawing.Point(398, 184)
        Me.cbxForCheckVoucher.Name = "cbxForCheckVoucher"
        Me.cbxForCheckVoucher.Size = New System.Drawing.Size(159, 23)
        Me.cbxForCheckVoucher.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxForCheckVoucher.TabIndex = 36
        Me.cbxForCheckVoucher.Text = "For Check Voucher"
        Me.cbxForCheckVoucher.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.cbxForCheckVoucher.Visible = False
        '
        'cbxCancelled
        '
        Me.cbxCancelled.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxCancelled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxCancelled.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCancelled.Location = New System.Drawing.Point(398, 213)
        Me.cbxCancelled.Name = "cbxCancelled"
        Me.cbxCancelled.Size = New System.Drawing.Size(140, 23)
        Me.cbxCancelled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxCancelled.TabIndex = 50
        Me.cbxCancelled.Text = "Cancelled"
        Me.cbxCancelled.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.cbxCancelled.Visible = False
        '
        'cbxLiquidated
        '
        Me.cbxLiquidated.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxLiquidated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxLiquidated.Checked = True
        Me.cbxLiquidated.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxLiquidated.CheckValue = "Y"
        Me.cbxLiquidated.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLiquidated.Location = New System.Drawing.Point(252, 213)
        Me.cbxLiquidated.Name = "cbxLiquidated"
        Me.cbxLiquidated.Size = New System.Drawing.Size(140, 23)
        Me.cbxLiquidated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxLiquidated.TabIndex = 35
        Me.cbxLiquidated.Text = "Liquidated"
        Me.cbxLiquidated.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.cbxLiquidated.Visible = False
        '
        'ContextMenuBar3
        '
        Me.ContextMenuBar3.AntiAlias = True
        Me.ContextMenuBar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.ContextMenuBar3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem5})
        Me.ContextMenuBar3.Location = New System.Drawing.Point(809, 184)
        Me.ContextMenuBar3.Name = "ContextMenuBar3"
        Me.ContextMenuBar3.Size = New System.Drawing.Size(114, 25)
        Me.ContextMenuBar3.Stretch = True
        Me.ContextMenuBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar3.TabIndex = 1752
        Me.ContextMenuBar3.TabStop = False
        Me.ContextMenuBar3.Text = "ContextMenuBar3"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.AutoExpandOnClick = True
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnCheckVoucher, Me.btnTagCheckVoucher, Me.iLiquidate, Me.iTagLiquidate, Me.iReturn})
        '
        'btnCheckVoucher
        '
        Me.btnCheckVoucher.Name = "btnCheckVoucher"
        Me.btnCheckVoucher.Text = "Check Voucher"
        '
        'btnTagCheckVoucher
        '
        Me.btnTagCheckVoucher.Name = "btnTagCheckVoucher"
        Me.btnTagCheckVoucher.Text = "Tag Check Voucher"
        '
        'iLiquidate
        '
        Me.iLiquidate.Name = "iLiquidate"
        Me.iLiquidate.Text = "Liquidate"
        '
        'iTagLiquidate
        '
        Me.iTagLiquidate.Name = "iTagLiquidate"
        Me.iTagLiquidate.Text = "Tag Petty Cash Liquidation"
        '
        'iReturn
        '
        Me.iReturn.Name = "iReturn"
        Me.iReturn.Text = "Return As Cash"
        '
        'GridControl1
        '
        Me.ContextMenuBar3.SetContextMenuEx(Me.GridControl1, Me.ButtonItem5)
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn35, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn34, Me.GridColumn33, Me.GridColumn28, Me.GridColumn29, Me.GridColumn31, Me.GridColumn30, Me.GridColumn32})
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
        Me.GridColumn2.Caption = "Payee_ID"
        Me.GridColumn2.FieldName = "Payee_ID"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Payee"
        Me.GridColumn3.FieldName = "Payee"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 250
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Document Date"
        Me.GridColumn4.FieldName = "Date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 125
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Document No"
        Me.GridColumn5.FieldName = "Account Number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 125
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Purpose"
        Me.GridColumn6.FieldName = "Purpose"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 370
        '
        'GridColumn35
        '
        Me.GridColumn35.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn35.Caption = "Total"
        Me.GridColumn35.DisplayFormat.FormatString = "n2"
        Me.GridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn35.FieldName = "Total"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 5
        Me.GridColumn35.Width = 125
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Meals"
        Me.GridColumn7.DisplayFormat.FormatString = "n2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "Meals"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 125
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Transportation"
        Me.GridColumn8.DisplayFormat.FormatString = "n2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "Transportation"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 125
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "BIR"
        Me.GridColumn9.DisplayFormat.FormatString = "n2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "BIR"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 125
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "RD"
        Me.GridColumn10.DisplayFormat.FormatString = "n2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "RD"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        Me.GridColumn10.Width = 125
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.Caption = "LTO"
        Me.GridColumn11.DisplayFormat.FormatString = "n2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "LTO"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 10
        Me.GridColumn11.Width = 125
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.Caption = "Notarization"
        Me.GridColumn12.DisplayFormat.FormatString = "n2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "Notarization"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 11
        Me.GridColumn12.Width = 125
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.Caption = "Others"
        Me.GridColumn13.DisplayFormat.FormatString = "n2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "Others"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 12
        Me.GridColumn13.Width = 125
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Date 1"
        Me.GridColumn14.FieldName = "Date 1"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 13
        Me.GridColumn14.Width = 125
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn15.Caption = "Amount 1"
        Me.GridColumn15.DisplayFormat.FormatString = "n2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "Amount 1"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 14
        Me.GridColumn15.Width = 125
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.Caption = "Date 2"
        Me.GridColumn16.FieldName = "Date 2"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 15
        Me.GridColumn16.Width = 125
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "Amount 2"
        Me.GridColumn17.DisplayFormat.FormatString = "n2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "Amount 2"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 16
        Me.GridColumn17.Width = 125
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.Caption = "Date 3"
        Me.GridColumn18.FieldName = "Date 3"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 17
        Me.GridColumn18.Width = 125
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Amount 3"
        Me.GridColumn19.DisplayFormat.FormatString = "n2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "Amount 3"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 18
        Me.GridColumn19.Width = 125
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn20.Caption = "Date 4"
        Me.GridColumn20.FieldName = "Date4"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 19
        Me.GridColumn20.Width = 125
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.Caption = "Amount 4"
        Me.GridColumn21.DisplayFormat.FormatString = "n2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "Amount 4"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 20
        Me.GridColumn21.Width = 125
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.Caption = "Date 5"
        Me.GridColumn22.FieldName = "Date 5"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 21
        Me.GridColumn22.Width = 125
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "Amount 5"
        Me.GridColumn23.DisplayFormat.FormatString = "n2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "Amount 5"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 22
        Me.GridColumn23.Width = 125
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn24.Caption = "Date 6"
        Me.GridColumn24.FieldName = "Date 6"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 23
        Me.GridColumn24.Width = 125
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.Caption = "Amount 6"
        Me.GridColumn25.DisplayFormat.FormatString = "n2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "Amount 6"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 24
        Me.GridColumn25.Width = 125
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.Caption = "Date7"
        Me.GridColumn26.FieldName = "Date 7"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 25
        Me.GridColumn26.Width = 125
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.Caption = "Amount 7"
        Me.GridColumn27.DisplayFormat.FormatString = "n2"
        Me.GridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn27.FieldName = "Amount 7"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 26
        Me.GridColumn27.Width = 125
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Prepared By"
        Me.GridColumn34.FieldName = "Prepared By"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 27
        Me.GridColumn34.Width = 250
        '
        'GridColumn33
        '
        Me.GridColumn33.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn33.Caption = "Disbursement Date"
        Me.GridColumn33.FieldName = "Received Date"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 28
        Me.GridColumn33.Width = 130
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.Caption = "Liquidation Date"
        Me.GridColumn28.FieldName = "Liquidation Date"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 29
        Me.GridColumn28.Width = 125
        '
        'GridColumn29
        '
        Me.GridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn29.Caption = "Salary Date"
        Me.GridColumn29.FieldName = "Salary Date"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 30
        Me.GridColumn29.Width = 125
        '
        'GridColumn31
        '
        Me.GridColumn31.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn31.Caption = "Status"
        Me.GridColumn31.FieldName = "Slip_Status"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 3
        Me.GridColumn31.Width = 155
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Branch"
        Me.GridColumn30.FieldName = "Branch"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn30.Width = 200
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Attach"
        Me.GridColumn32.FieldName = "Attach"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
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
        'cbxForApproval
        '
        Me.cbxForApproval.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxForApproval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxForApproval.Checked = True
        Me.cbxForApproval.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxForApproval.CheckValue = "Y"
        Me.cbxForApproval.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxForApproval.Location = New System.Drawing.Point(252, 184)
        Me.cbxForApproval.Name = "cbxForApproval"
        Me.cbxForApproval.Size = New System.Drawing.Size(140, 23)
        Me.cbxForApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxForApproval.TabIndex = 30
        Me.cbxForApproval.Text = "For Approval"
        Me.cbxForApproval.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.cbxForApproval.Visible = False
        '
        'PanelEx19
        '
        Me.PanelEx19.AutoScroll = True
        Me.PanelEx19.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx19.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx19.Controls.Add(Me.LabelX39)
        Me.PanelEx19.Controls.Add(Me.cbxStatus)
        Me.PanelEx19.Controls.Add(Me.btnSearch)
        Me.PanelEx19.Controls.Add(Me.cbxAll)
        Me.PanelEx19.Controls.Add(Me.cbxDisplay)
        Me.PanelEx19.Controls.Add(Me.LabelX40)
        Me.PanelEx19.Controls.Add(Me.dtpTo)
        Me.PanelEx19.Controls.Add(Me.LabelX41)
        Me.PanelEx19.Controls.Add(Me.dtpFrom)
        Me.PanelEx19.Controls.Add(Me.LabelX42)
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
        Me.PanelEx19.TabIndex = 1680
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
        Me.LabelX39.Location = New System.Drawing.Point(487, 6)
        Me.LabelX39.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.Size = New System.Drawing.Size(60, 23)
        Me.LabelX39.TabIndex = 1006
        Me.LabelX39.Text = "Status :"
        Me.LabelX39.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxStatus
        '
        Me.cbxStatus.Location = New System.Drawing.Point(553, 6)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxStatus.Properties.Appearance.Options.UseFont = True
        Me.cbxStatus.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxStatus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbxStatus.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxStatus.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbxStatus.Properties.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxStatus.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbxStatus.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxStatus.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbxStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbxStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.cbxStatus.Properties.DropDownRows = 15
        Me.cbxStatus.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cbxStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbxStatus.Properties.PopupSizeable = False
        Me.cbxStatus.Size = New System.Drawing.Size(183, 26)
        Me.cbxStatus.TabIndex = 1753
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnSearch.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSearch.Location = New System.Drawing.Point(742, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 30)
        Me.btnSearch.TabIndex = 50
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
        'LabelX40
        '
        Me.LabelX40.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX40.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX40.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX40.Location = New System.Drawing.Point(9, 6)
        Me.LabelX40.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.Size = New System.Drawing.Size(56, 23)
        Me.LabelX40.TabIndex = 96
        Me.LabelX40.Text = "Display :"
        Me.LabelX40.TextAlignment = System.Drawing.StringAlignment.Far
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
        'LabelX41
        '
        Me.LabelX41.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX41.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX41.Location = New System.Drawing.Point(237, 35)
        Me.LabelX41.Name = "LabelX41"
        Me.LabelX41.Size = New System.Drawing.Size(46, 23)
        Me.LabelX41.TabIndex = 94
        Me.LabelX41.Text = "To :"
        Me.LabelX41.TextAlignment = System.Drawing.StringAlignment.Far
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
        'LabelX42
        '
        Me.LabelX42.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX42.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX42.Location = New System.Drawing.Point(9, 35)
        Me.LabelX42.Name = "LabelX42"
        Me.LabelX42.Size = New System.Drawing.Size(56, 23)
        Me.LabelX42.TabIndex = 92
        Me.LabelX42.Text = "From :"
        Me.LabelX42.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tabList
        '
        Me.tabList.AttachedControl = Me.SuperTabControlPanel2
        Me.tabList.GlobalItem = False
        Me.tabList.Name = "tabList"
        Me.tabList.Text = "Cash Advance List"
        Me.tabList.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
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
        Me.PanelEx10.Controls.Add(Me.cbxOther)
        Me.PanelEx10.Controls.Add(Me.cbxPreparedBy)
        Me.PanelEx10.Controls.Add(Me.txtReceivedDate)
        Me.PanelEx10.Controls.Add(Me.LabelX43)
        Me.PanelEx10.Controls.Add(Me.txtReceived)
        Me.PanelEx10.Controls.Add(Me.txtApproved)
        Me.PanelEx10.Controls.Add(Me.LabelX44)
        Me.PanelEx10.Controls.Add(Me.LabelX38)
        Me.PanelEx10.Controls.Add(Me.LabelX36)
        Me.PanelEx10.Controls.Add(Me.LabelX37)
        Me.PanelEx10.Controls.Add(Me.LabelX35)
        Me.PanelEx10.Controls.Add(Me.LabelX34)
        Me.PanelEx10.Controls.Add(Me.gSignatory)
        Me.PanelEx10.Controls.Add(Me.gLiquidation)
        Me.PanelEx10.Controls.Add(Me.gRequest)
        Me.PanelEx10.Controls.Add(Me.txtAccountNumber)
        Me.PanelEx10.Controls.Add(Me.LabelX6)
        Me.PanelEx10.Controls.Add(Me.dtpDate)
        Me.PanelEx10.Controls.Add(Me.LabelX10)
        Me.PanelEx10.Controls.Add(Me.cbxPayee)
        Me.PanelEx10.Controls.Add(Me.txtPurpose)
        Me.PanelEx10.Controls.Add(Me.LabelX1)
        Me.PanelEx10.Controls.Add(Me.LabelX2)
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
        'cbxOther
        '
        Me.cbxOther.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxOther.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxOther.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOther.Location = New System.Drawing.Point(414, 16)
        Me.cbxOther.Name = "cbxOther"
        Me.cbxOther.Size = New System.Drawing.Size(106, 25)
        Me.cbxOther.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxOther.TabIndex = 6
        Me.cbxOther.Text = "Other Branch"
        Me.cbxOther.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'cbxPreparedBy
        '
        Me.cbxPreparedBy.DisplayMember = "PREFIX"
        Me.cbxPreparedBy.Enabled = False
        Me.cbxPreparedBy.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxPreparedBy.FormattingEnabled = True
        Me.cbxPreparedBy.Location = New System.Drawing.Point(12, 509)
        Me.cbxPreparedBy.Name = "cbxPreparedBy"
        Me.cbxPreparedBy.Size = New System.Drawing.Size(297, 25)
        Me.cbxPreparedBy.TabIndex = 1548
        Me.cbxPreparedBy.ValueMember = "ID"
        '
        'txtReceivedDate
        '
        '
        '
        '
        Me.txtReceivedDate.Border.Class = "TextBoxBorder"
        Me.txtReceivedDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReceivedDate.Enabled = False
        Me.txtReceivedDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedDate.Location = New System.Drawing.Point(921, 509)
        Me.txtReceivedDate.MaxLength = 350
        Me.txtReceivedDate.Name = "txtReceivedDate"
        Me.txtReceivedDate.PreventEnterBeep = True
        Me.txtReceivedDate.Size = New System.Drawing.Size(231, 23)
        Me.txtReceivedDate.TabIndex = 1522
        Me.txtReceivedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX43
        '
        Me.LabelX43.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX43.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX43.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX43.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX43.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX43.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX43.BackgroundStyle.BorderTopWidth = 2
        Me.LabelX43.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX43.Location = New System.Drawing.Point(12, 540)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(297, 23)
        Me.LabelX43.TabIndex = 1550
        Me.LabelX43.Text = "Print Name and Signature"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtReceived
        '
        '
        '
        '
        Me.txtReceived.Border.Class = "TextBoxBorder"
        Me.txtReceived.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReceived.Enabled = False
        Me.txtReceived.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceived.Location = New System.Drawing.Point(618, 509)
        Me.txtReceived.MaxLength = 350
        Me.txtReceived.Name = "txtReceived"
        Me.txtReceived.PreventEnterBeep = True
        Me.txtReceived.Size = New System.Drawing.Size(297, 23)
        Me.txtReceived.TabIndex = 1521
        Me.txtReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtApproved
        '
        '
        '
        '
        Me.txtApproved.Border.Class = "TextBoxBorder"
        Me.txtApproved.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtApproved.Enabled = False
        Me.txtApproved.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApproved.Location = New System.Drawing.Point(315, 509)
        Me.txtApproved.MaxLength = 350
        Me.txtApproved.Name = "txtApproved"
        Me.txtApproved.PreventEnterBeep = True
        Me.txtApproved.Size = New System.Drawing.Size(297, 23)
        Me.txtApproved.TabIndex = 1520
        Me.txtApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX44
        '
        Me.LabelX44.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX44.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX44.Location = New System.Drawing.Point(12, 480)
        Me.LabelX44.Name = "LabelX44"
        Me.LabelX44.Size = New System.Drawing.Size(96, 23)
        Me.LabelX44.TabIndex = 1549
        Me.LabelX44.Text = "Prepared By :"
        '
        'LabelX38
        '
        Me.LabelX38.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX38.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX38.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX38.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX38.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX38.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX38.BackgroundStyle.BorderTopWidth = 2
        Me.LabelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX38.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX38.Location = New System.Drawing.Point(921, 540)
        Me.LabelX38.Name = "LabelX38"
        Me.LabelX38.Size = New System.Drawing.Size(231, 23)
        Me.LabelX38.TabIndex = 1518
        Me.LabelX38.Text = "Date"
        Me.LabelX38.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX36
        '
        Me.LabelX36.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX36.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX36.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX36.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX36.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX36.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX36.BackgroundStyle.BorderTopWidth = 2
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX36.Location = New System.Drawing.Point(618, 540)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(297, 23)
        Me.LabelX36.TabIndex = 1515
        Me.LabelX36.Text = "Print Name and Signature"
        Me.LabelX36.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.LabelX37.Location = New System.Drawing.Point(618, 479)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(123, 23)
        Me.LabelX37.TabIndex = 1514
        Me.LabelX37.Text = "Received By :"
        '
        'LabelX35
        '
        Me.LabelX35.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX35.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX35.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX35.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX35.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX35.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX35.BackgroundStyle.BorderTopWidth = 2
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX35.Location = New System.Drawing.Point(315, 540)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(297, 23)
        Me.LabelX35.TabIndex = 1512
        Me.LabelX35.Text = "Department Head"
        Me.LabelX35.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.LabelX34.Location = New System.Drawing.Point(315, 480)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(123, 23)
        Me.LabelX34.TabIndex = 1511
        Me.LabelX34.Text = "Approved By :"
        '
        'gSignatory
        '
        Me.gSignatory.Appearance.BackColor = System.Drawing.Color.White
        Me.gSignatory.Appearance.BackColor2 = System.Drawing.Color.White
        Me.gSignatory.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gSignatory.Appearance.Options.UseBackColor = True
        Me.gSignatory.Appearance.Options.UseFont = True
        Me.gSignatory.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gSignatory.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gSignatory.AppearanceCaption.Options.UseFont = True
        Me.gSignatory.AppearanceCaption.Options.UseForeColor = True
        Me.gSignatory.Controls.Add(Me.txtName)
        Me.gSignatory.Controls.Add(Me.dtpDate_2)
        Me.gSignatory.Controls.Add(Me.dtpPayroll)
        Me.gSignatory.Controls.Add(Me.LabelX30)
        Me.gSignatory.Controls.Add(Me.dtpLiquidate)
        Me.gSignatory.Controls.Add(Me.LabelX29)
        Me.gSignatory.Controls.Add(Me.LabelX31)
        Me.gSignatory.Controls.Add(Me.LabelX32)
        Me.gSignatory.Location = New System.Drawing.Point(768, 74)
        Me.gSignatory.LookAndFeel.SkinName = "Darkroom"
        Me.gSignatory.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gSignatory.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gSignatory.Name = "gSignatory"
        Me.gSignatory.Size = New System.Drawing.Size(384, 339)
        Me.gSignatory.TabIndex = 1509
        '
        'txtName
        '
        '
        '
        '
        Me.txtName.Border.Class = "TextBoxBorder"
        Me.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtName.Enabled = False
        Me.txtName.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(162, 289)
        Me.txtName.MaxLength = 140
        Me.txtName.Name = "txtName"
        Me.txtName.PreventEnterBeep = True
        Me.txtName.Size = New System.Drawing.Size(216, 23)
        Me.txtName.TabIndex = 140
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtName.WatermarkText = "Mark Kevin M. Gotico"
        '
        'dtpDate_2
        '
        '
        '
        '
        Me.dtpDate_2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpDate_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate_2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpDate_2.ButtonDropDown.Visible = True
        Me.dtpDate_2.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDate_2.Enabled = False
        Me.dtpDate_2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate_2.ForeColor = System.Drawing.Color.Black
        Me.dtpDate_2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpDate_2.IsPopupCalendarOpen = False
        Me.dtpDate_2.Location = New System.Drawing.Point(6, 289)
        '
        '
        '
        Me.dtpDate_2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpDate_2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate_2.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpDate_2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpDate_2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate_2.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpDate_2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpDate_2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpDate_2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpDate_2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpDate_2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpDate_2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate_2.MonthCalendar.TodayButtonVisible = True
        Me.dtpDate_2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpDate_2.Name = "dtpDate_2"
        Me.dtpDate_2.Size = New System.Drawing.Size(152, 23)
        Me.dtpDate_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpDate_2.TabIndex = 135
        Me.dtpDate_2.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dtpPayroll
        '
        '
        '
        '
        Me.dtpPayroll.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpPayroll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpPayroll.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpPayroll.ButtonDropDown.Visible = True
        Me.dtpPayroll.CustomFormat = "MMMM dd, yyyy"
        Me.dtpPayroll.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPayroll.ForeColor = System.Drawing.Color.Black
        Me.dtpPayroll.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpPayroll.IsPopupCalendarOpen = False
        Me.dtpPayroll.Location = New System.Drawing.Point(93, 184)
        '
        '
        '
        Me.dtpPayroll.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpPayroll.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpPayroll.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpPayroll.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpPayroll.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpPayroll.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpPayroll.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpPayroll.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpPayroll.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpPayroll.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpPayroll.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpPayroll.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpPayroll.MonthCalendar.TodayButtonVisible = True
        Me.dtpPayroll.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpPayroll.Name = "dtpPayroll"
        Me.dtpPayroll.Size = New System.Drawing.Size(233, 31)
        Me.dtpPayroll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpPayroll.TabIndex = 130
        Me.dtpPayroll.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX30
        '
        Me.LabelX30.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX30.Location = New System.Drawing.Point(6, 92)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(372, 133)
        Me.LabelX30.TabIndex = 1508
        Me.LabelX30.Text = "If I fail to liquidate this in full on or before the said date, I am aware that t" &
    "he balances will be deducted by the accouting department in full from my salary " &
    "on"
        Me.LabelX30.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX30.WordWrap = True
        '
        'dtpLiquidate
        '
        '
        '
        '
        Me.dtpLiquidate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpLiquidate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpLiquidate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpLiquidate.ButtonDropDown.Visible = True
        Me.dtpLiquidate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpLiquidate.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLiquidate.ForeColor = System.Drawing.Color.Black
        Me.dtpLiquidate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpLiquidate.IsPopupCalendarOpen = False
        Me.dtpLiquidate.Location = New System.Drawing.Point(141, 61)
        '
        '
        '
        Me.dtpLiquidate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpLiquidate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpLiquidate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpLiquidate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpLiquidate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpLiquidate.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpLiquidate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpLiquidate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpLiquidate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpLiquidate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpLiquidate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpLiquidate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpLiquidate.MonthCalendar.TodayButtonVisible = True
        Me.dtpLiquidate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpLiquidate.Name = "dtpLiquidate"
        Me.dtpLiquidate.Size = New System.Drawing.Size(237, 31)
        Me.dtpLiquidate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpLiquidate.TabIndex = 125
        Me.dtpLiquidate.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX29
        '
        Me.LabelX29.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX29.Location = New System.Drawing.Point(6, 17)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(372, 81)
        Me.LabelX29.TabIndex = 1506
        Me.LabelX29.Text = "I hereby promise to liquidate this cash advance within 7 days from receipt, speci" &
    "fically on"
        Me.LabelX29.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX29.WordWrap = True
        '
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX31.Location = New System.Drawing.Point(6, 310)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(152, 23)
        Me.LabelX31.TabIndex = 1522
        Me.LabelX31.Text = "Date"
        Me.LabelX31.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX32.Location = New System.Drawing.Point(162, 310)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(216, 23)
        Me.LabelX32.TabIndex = 1524
        Me.LabelX32.Text = "Print name and signature"
        Me.LabelX32.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'gLiquidation
        '
        Me.gLiquidation.Appearance.BackColor = System.Drawing.Color.White
        Me.gLiquidation.Appearance.BackColor2 = System.Drawing.Color.White
        Me.gLiquidation.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gLiquidation.Appearance.Options.UseBackColor = True
        Me.gLiquidation.Appearance.Options.UseFont = True
        Me.gLiquidation.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gLiquidation.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gLiquidation.AppearanceCaption.Options.UseFont = True
        Me.gLiquidation.AppearanceCaption.Options.UseForeColor = True
        Me.gLiquidation.Controls.Add(Me.dtp_7)
        Me.gLiquidation.Controls.Add(Me.dAmount_7)
        Me.gLiquidation.Controls.Add(Me.LabelX33)
        Me.gLiquidation.Controls.Add(Me.dTotalLiquidation)
        Me.gLiquidation.Controls.Add(Me.LabelX28)
        Me.gLiquidation.Controls.Add(Me.dtp_6)
        Me.gLiquidation.Controls.Add(Me.dAmount_6)
        Me.gLiquidation.Controls.Add(Me.LabelX27)
        Me.gLiquidation.Controls.Add(Me.dtp_5)
        Me.gLiquidation.Controls.Add(Me.dAmount_5)
        Me.gLiquidation.Controls.Add(Me.LabelX26)
        Me.gLiquidation.Controls.Add(Me.dtp_4)
        Me.gLiquidation.Controls.Add(Me.dAmount_4)
        Me.gLiquidation.Controls.Add(Me.LabelX25)
        Me.gLiquidation.Controls.Add(Me.dtp_3)
        Me.gLiquidation.Controls.Add(Me.dAmount_3)
        Me.gLiquidation.Controls.Add(Me.LabelX24)
        Me.gLiquidation.Controls.Add(Me.dtp_2)
        Me.gLiquidation.Controls.Add(Me.dAmount_2)
        Me.gLiquidation.Controls.Add(Me.LabelX23)
        Me.gLiquidation.Controls.Add(Me.dtp_1)
        Me.gLiquidation.Controls.Add(Me.dAmount_1)
        Me.gLiquidation.Controls.Add(Me.LabelX21)
        Me.gLiquidation.Controls.Add(Me.LabelX20)
        Me.gLiquidation.Controls.Add(Me.LabelX22)
        Me.gLiquidation.Enabled = False
        Me.gLiquidation.Location = New System.Drawing.Point(391, 74)
        Me.gLiquidation.LookAndFeel.SkinName = "Darkroom"
        Me.gLiquidation.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gLiquidation.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gLiquidation.Name = "gLiquidation"
        Me.gLiquidation.Size = New System.Drawing.Size(373, 339)
        Me.gLiquidation.TabIndex = 1509
        Me.gLiquidation.Text = "Partial Liquidation"
        '
        'dtp_7
        '
        Me.dtp_7.AccessibleDescription = ""
        '
        '
        '
        Me.dtp_7.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_7.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_7.ButtonDropDown.Visible = True
        Me.dtp_7.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_7.Enabled = False
        Me.dtp_7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_7.ForeColor = System.Drawing.Color.Black
        Me.dtp_7.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_7.IsPopupCalendarOpen = False
        Me.dtp_7.Location = New System.Drawing.Point(6, 245)
        '
        '
        '
        Me.dtp_7.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_7.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_7.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_7.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_7.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_7.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_7.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_7.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_7.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_7.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_7.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_7.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_7.MonthCalendar.TodayButtonVisible = True
        Me.dtp_7.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_7.Name = "dtp_7"
        Me.dtp_7.Size = New System.Drawing.Size(154, 23)
        Me.dtp_7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_7.TabIndex = 115
        Me.dtp_7.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_7
        '
        '
        '
        '
        Me.dAmount_7.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_7.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_7.Enabled = False
        Me.dAmount_7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_7.ForeColor = System.Drawing.Color.Black
        Me.dAmount_7.Increment = 1.0R
        Me.dAmount_7.Location = New System.Drawing.Point(201, 245)
        Me.dAmount_7.MinValue = 0R
        Me.dAmount_7.Name = "dAmount_7"
        Me.dAmount_7.ShowUpDown = True
        Me.dAmount_7.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_7.TabIndex = 120
        '
        'LabelX33
        '
        Me.LabelX33.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX33.Location = New System.Drawing.Point(157, 245)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(38, 23)
        Me.LabelX33.TabIndex = 1526
        Me.LabelX33.Text = "Php"
        Me.LabelX33.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dTotalLiquidation
        '
        '
        '
        '
        Me.dTotalLiquidation.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTotalLiquidation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTotalLiquidation.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTotalLiquidation.Enabled = False
        Me.dTotalLiquidation.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dTotalLiquidation.ForeColor = System.Drawing.Color.Black
        Me.dTotalLiquidation.Increment = 1.0R
        Me.dTotalLiquidation.Location = New System.Drawing.Point(201, 302)
        Me.dTotalLiquidation.MinValue = 0R
        Me.dTotalLiquidation.Name = "dTotalLiquidation"
        Me.dTotalLiquidation.ShowUpDown = True
        Me.dTotalLiquidation.Size = New System.Drawing.Size(166, 31)
        Me.dTotalLiquidation.TabIndex = 1522
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX28.Location = New System.Drawing.Point(141, 302)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(54, 31)
        Me.LabelX28.TabIndex = 1523
        Me.LabelX28.Text = "Php"
        Me.LabelX28.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtp_6
        '
        '
        '
        '
        Me.dtp_6.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_6.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_6.ButtonDropDown.Visible = True
        Me.dtp_6.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_6.Enabled = False
        Me.dtp_6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_6.ForeColor = System.Drawing.Color.Black
        Me.dtp_6.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_6.IsPopupCalendarOpen = False
        Me.dtp_6.Location = New System.Drawing.Point(6, 216)
        '
        '
        '
        Me.dtp_6.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_6.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_6.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_6.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_6.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_6.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_6.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_6.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_6.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_6.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_6.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_6.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_6.MonthCalendar.TodayButtonVisible = True
        Me.dtp_6.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_6.Name = "dtp_6"
        Me.dtp_6.Size = New System.Drawing.Size(154, 23)
        Me.dtp_6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_6.TabIndex = 105
        Me.dtp_6.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_6
        '
        '
        '
        '
        Me.dAmount_6.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_6.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_6.Enabled = False
        Me.dAmount_6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_6.ForeColor = System.Drawing.Color.Black
        Me.dAmount_6.Increment = 1.0R
        Me.dAmount_6.Location = New System.Drawing.Point(201, 216)
        Me.dAmount_6.MinValue = 0R
        Me.dAmount_6.Name = "dAmount_6"
        Me.dAmount_6.ShowUpDown = True
        Me.dAmount_6.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_6.TabIndex = 110
        '
        'LabelX27
        '
        Me.LabelX27.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX27.Location = New System.Drawing.Point(157, 216)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(38, 23)
        Me.LabelX27.TabIndex = 1521
        Me.LabelX27.Text = "Php"
        Me.LabelX27.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtp_5
        '
        '
        '
        '
        Me.dtp_5.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_5.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_5.ButtonDropDown.Visible = True
        Me.dtp_5.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_5.Enabled = False
        Me.dtp_5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_5.ForeColor = System.Drawing.Color.Black
        Me.dtp_5.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_5.IsPopupCalendarOpen = False
        Me.dtp_5.Location = New System.Drawing.Point(6, 187)
        '
        '
        '
        Me.dtp_5.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_5.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_5.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_5.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_5.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_5.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_5.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_5.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_5.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_5.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_5.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_5.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_5.MonthCalendar.TodayButtonVisible = True
        Me.dtp_5.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_5.Name = "dtp_5"
        Me.dtp_5.Size = New System.Drawing.Size(154, 23)
        Me.dtp_5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_5.TabIndex = 95
        Me.dtp_5.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_5
        '
        '
        '
        '
        Me.dAmount_5.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_5.Enabled = False
        Me.dAmount_5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_5.ForeColor = System.Drawing.Color.Black
        Me.dAmount_5.Increment = 1.0R
        Me.dAmount_5.Location = New System.Drawing.Point(201, 187)
        Me.dAmount_5.MinValue = 0R
        Me.dAmount_5.Name = "dAmount_5"
        Me.dAmount_5.ShowUpDown = True
        Me.dAmount_5.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_5.TabIndex = 100
        '
        'LabelX26
        '
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX26.Location = New System.Drawing.Point(157, 187)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(38, 23)
        Me.LabelX26.TabIndex = 1518
        Me.LabelX26.Text = "Php"
        Me.LabelX26.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtp_4
        '
        '
        '
        '
        Me.dtp_4.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_4.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_4.ButtonDropDown.Visible = True
        Me.dtp_4.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_4.Enabled = False
        Me.dtp_4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_4.ForeColor = System.Drawing.Color.Black
        Me.dtp_4.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_4.IsPopupCalendarOpen = False
        Me.dtp_4.Location = New System.Drawing.Point(6, 158)
        '
        '
        '
        Me.dtp_4.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_4.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_4.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_4.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_4.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_4.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_4.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_4.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_4.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_4.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_4.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_4.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_4.MonthCalendar.TodayButtonVisible = True
        Me.dtp_4.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_4.Name = "dtp_4"
        Me.dtp_4.Size = New System.Drawing.Size(154, 23)
        Me.dtp_4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_4.TabIndex = 85
        Me.dtp_4.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_4
        '
        '
        '
        '
        Me.dAmount_4.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_4.Enabled = False
        Me.dAmount_4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_4.ForeColor = System.Drawing.Color.Black
        Me.dAmount_4.Increment = 1.0R
        Me.dAmount_4.Location = New System.Drawing.Point(201, 158)
        Me.dAmount_4.MinValue = 0R
        Me.dAmount_4.Name = "dAmount_4"
        Me.dAmount_4.ShowUpDown = True
        Me.dAmount_4.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_4.TabIndex = 90
        '
        'LabelX25
        '
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX25.Location = New System.Drawing.Point(157, 158)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(38, 23)
        Me.LabelX25.TabIndex = 1515
        Me.LabelX25.Text = "Php"
        Me.LabelX25.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtp_3
        '
        '
        '
        '
        Me.dtp_3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_3.ButtonDropDown.Visible = True
        Me.dtp_3.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_3.Enabled = False
        Me.dtp_3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_3.ForeColor = System.Drawing.Color.Black
        Me.dtp_3.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_3.IsPopupCalendarOpen = False
        Me.dtp_3.Location = New System.Drawing.Point(6, 129)
        '
        '
        '
        Me.dtp_3.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_3.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_3.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_3.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_3.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_3.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_3.MonthCalendar.TodayButtonVisible = True
        Me.dtp_3.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_3.Name = "dtp_3"
        Me.dtp_3.Size = New System.Drawing.Size(154, 23)
        Me.dtp_3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_3.TabIndex = 75
        Me.dtp_3.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_3
        '
        '
        '
        '
        Me.dAmount_3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_3.Enabled = False
        Me.dAmount_3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_3.ForeColor = System.Drawing.Color.Black
        Me.dAmount_3.Increment = 1.0R
        Me.dAmount_3.Location = New System.Drawing.Point(201, 129)
        Me.dAmount_3.MinValue = 0R
        Me.dAmount_3.Name = "dAmount_3"
        Me.dAmount_3.ShowUpDown = True
        Me.dAmount_3.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_3.TabIndex = 80
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX24.Location = New System.Drawing.Point(157, 129)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(38, 23)
        Me.LabelX24.TabIndex = 1512
        Me.LabelX24.Text = "Php"
        Me.LabelX24.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtp_2
        '
        '
        '
        '
        Me.dtp_2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_2.ButtonDropDown.Visible = True
        Me.dtp_2.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_2.Enabled = False
        Me.dtp_2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_2.ForeColor = System.Drawing.Color.Black
        Me.dtp_2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_2.IsPopupCalendarOpen = False
        Me.dtp_2.Location = New System.Drawing.Point(6, 100)
        '
        '
        '
        Me.dtp_2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_2.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_2.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_2.MonthCalendar.TodayButtonVisible = True
        Me.dtp_2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_2.Name = "dtp_2"
        Me.dtp_2.Size = New System.Drawing.Size(154, 23)
        Me.dtp_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_2.TabIndex = 65
        Me.dtp_2.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_2
        '
        '
        '
        '
        Me.dAmount_2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_2.Enabled = False
        Me.dAmount_2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_2.ForeColor = System.Drawing.Color.Black
        Me.dAmount_2.Increment = 1.0R
        Me.dAmount_2.Location = New System.Drawing.Point(201, 100)
        Me.dAmount_2.MinValue = 0R
        Me.dAmount_2.Name = "dAmount_2"
        Me.dAmount_2.ShowUpDown = True
        Me.dAmount_2.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_2.TabIndex = 70
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX23.Location = New System.Drawing.Point(157, 100)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(38, 23)
        Me.LabelX23.TabIndex = 1509
        Me.LabelX23.Text = "Php"
        Me.LabelX23.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtp_1
        '
        '
        '
        '
        Me.dtp_1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtp_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtp_1.ButtonDropDown.Visible = True
        Me.dtp_1.CustomFormat = "MMMM dd, yyyy"
        Me.dtp_1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_1.ForeColor = System.Drawing.Color.Black
        Me.dtp_1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtp_1.IsPopupCalendarOpen = False
        Me.dtp_1.Location = New System.Drawing.Point(6, 71)
        '
        '
        '
        Me.dtp_1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtp_1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtp_1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_1.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtp_1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtp_1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtp_1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtp_1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtp_1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtp_1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtp_1.MonthCalendar.TodayButtonVisible = True
        Me.dtp_1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtp_1.Name = "dtp_1"
        Me.dtp_1.Size = New System.Drawing.Size(154, 23)
        Me.dtp_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtp_1.TabIndex = 55
        Me.dtp_1.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'dAmount_1
        '
        '
        '
        '
        Me.dAmount_1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount_1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount_1.Enabled = False
        Me.dAmount_1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount_1.ForeColor = System.Drawing.Color.Black
        Me.dAmount_1.Increment = 1.0R
        Me.dAmount_1.Location = New System.Drawing.Point(201, 71)
        Me.dAmount_1.MinValue = 0R
        Me.dAmount_1.Name = "dAmount_1"
        Me.dAmount_1.ShowUpDown = True
        Me.dAmount_1.Size = New System.Drawing.Size(166, 23)
        Me.dAmount_1.TabIndex = 60
        '
        'LabelX21
        '
        Me.LabelX21.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.White
        Me.LabelX21.Location = New System.Drawing.Point(166, 42)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(201, 23)
        Me.LabelX21.TabIndex = 243
        Me.LabelX21.Text = "Amount"
        Me.LabelX21.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.Color.White
        Me.LabelX20.Location = New System.Drawing.Point(6, 42)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(154, 23)
        Me.LabelX20.TabIndex = 242
        Me.LabelX20.Text = "Date"
        Me.LabelX20.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX22.Location = New System.Drawing.Point(157, 71)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(38, 23)
        Me.LabelX22.TabIndex = 1506
        Me.LabelX22.Text = "Php"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gRequest
        '
        Me.gRequest.Appearance.BackColor = System.Drawing.Color.White
        Me.gRequest.Appearance.BackColor2 = System.Drawing.Color.White
        Me.gRequest.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gRequest.Appearance.Options.UseBackColor = True
        Me.gRequest.Appearance.Options.UseFont = True
        Me.gRequest.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gRequest.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gRequest.AppearanceCaption.Options.UseFont = True
        Me.gRequest.AppearanceCaption.Options.UseForeColor = True
        Me.gRequest.Controls.Add(Me.LabelX18)
        Me.gRequest.Controls.Add(Me.dTotal)
        Me.gRequest.Controls.Add(Me.LabelX19)
        Me.gRequest.Controls.Add(Me.LabelX16)
        Me.gRequest.Controls.Add(Me.dOthers)
        Me.gRequest.Controls.Add(Me.LabelX17)
        Me.gRequest.Controls.Add(Me.LabelX14)
        Me.gRequest.Controls.Add(Me.dNotarizationF)
        Me.gRequest.Controls.Add(Me.LabelX15)
        Me.gRequest.Controls.Add(Me.LabelX12)
        Me.gRequest.Controls.Add(Me.dLTO)
        Me.gRequest.Controls.Add(Me.LabelX13)
        Me.gRequest.Controls.Add(Me.LabelX8)
        Me.gRequest.Controls.Add(Me.dRD)
        Me.gRequest.Controls.Add(Me.LabelX9)
        Me.gRequest.Controls.Add(Me.LabelX5)
        Me.gRequest.Controls.Add(Me.dBIR)
        Me.gRequest.Controls.Add(Me.LabelX7)
        Me.gRequest.Controls.Add(Me.LabelX3)
        Me.gRequest.Controls.Add(Me.dTransportation)
        Me.gRequest.Controls.Add(Me.LabelX4)
        Me.gRequest.Controls.Add(Me.LabelX99)
        Me.gRequest.Controls.Add(Me.dMeal)
        Me.gRequest.Controls.Add(Me.LabelX100)
        Me.gRequest.Location = New System.Drawing.Point(12, 74)
        Me.gRequest.LookAndFeel.SkinName = "Darkroom"
        Me.gRequest.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gRequest.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gRequest.Name = "gRequest"
        Me.gRequest.Size = New System.Drawing.Size(373, 339)
        Me.gRequest.TabIndex = 1508
        Me.gRequest.Text = "Breakdown of Advance Requested"
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX18.Location = New System.Drawing.Point(97, 302)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(54, 31)
        Me.LabelX18.TabIndex = 263
        Me.LabelX18.Text = "Php"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dTotal
        '
        '
        '
        '
        Me.dTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTotal.Enabled = False
        Me.dTotal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dTotal.ForeColor = System.Drawing.Color.Black
        Me.dTotal.Increment = 1.0R
        Me.dTotal.Location = New System.Drawing.Point(157, 302)
        Me.dTotal.MinValue = 0R
        Me.dTotal.Name = "dTotal"
        Me.dTotal.ShowUpDown = True
        Me.dTotal.Size = New System.Drawing.Size(210, 31)
        Me.dTotal.TabIndex = 261
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX19.Location = New System.Drawing.Point(7, 302)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(140, 31)
        Me.LabelX19.TabIndex = 262
        Me.LabelX19.Text = "TOTAL"
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX16.Location = New System.Drawing.Point(113, 216)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(38, 23)
        Me.LabelX16.TabIndex = 260
        Me.LabelX16.Text = "Php"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dOthers
        '
        '
        '
        '
        Me.dOthers.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dOthers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dOthers.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dOthers.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dOthers.ForeColor = System.Drawing.Color.Black
        Me.dOthers.Increment = 1.0R
        Me.dOthers.Location = New System.Drawing.Point(157, 216)
        Me.dOthers.MinValue = 0R
        Me.dOthers.Name = "dOthers"
        Me.dOthers.ShowUpDown = True
        Me.dOthers.Size = New System.Drawing.Size(210, 23)
        Me.dOthers.TabIndex = 50
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
        Me.LabelX17.Location = New System.Drawing.Point(7, 216)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(140, 23)
        Me.LabelX17.TabIndex = 259
        Me.LabelX17.Text = "Others"
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.Location = New System.Drawing.Point(113, 187)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(38, 23)
        Me.LabelX14.TabIndex = 257
        Me.LabelX14.Text = "Php"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dNotarizationF
        '
        '
        '
        '
        Me.dNotarizationF.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dNotarizationF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dNotarizationF.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dNotarizationF.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dNotarizationF.ForeColor = System.Drawing.Color.Black
        Me.dNotarizationF.Increment = 1.0R
        Me.dNotarizationF.Location = New System.Drawing.Point(157, 187)
        Me.dNotarizationF.MinValue = 0R
        Me.dNotarizationF.Name = "dNotarizationF"
        Me.dNotarizationF.ShowUpDown = True
        Me.dNotarizationF.Size = New System.Drawing.Size(210, 23)
        Me.dNotarizationF.TabIndex = 45
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(7, 187)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(140, 23)
        Me.LabelX15.TabIndex = 256
        Me.LabelX15.Text = "Notarization Fee"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX12.Location = New System.Drawing.Point(113, 158)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(38, 23)
        Me.LabelX12.TabIndex = 254
        Me.LabelX12.Text = "Php"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dLTO
        '
        '
        '
        '
        Me.dLTO.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dLTO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dLTO.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dLTO.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dLTO.ForeColor = System.Drawing.Color.Black
        Me.dLTO.Increment = 1.0R
        Me.dLTO.Location = New System.Drawing.Point(157, 158)
        Me.dLTO.MinValue = 0R
        Me.dLTO.Name = "dLTO"
        Me.dLTO.ShowUpDown = True
        Me.dLTO.Size = New System.Drawing.Size(210, 23)
        Me.dLTO.TabIndex = 40
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.Location = New System.Drawing.Point(7, 158)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(140, 23)
        Me.LabelX13.TabIndex = 253
        Me.LabelX13.Text = "LTO"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX8.Location = New System.Drawing.Point(113, 129)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(38, 23)
        Me.LabelX8.TabIndex = 251
        Me.LabelX8.Text = "Php"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dRD
        '
        '
        '
        '
        Me.dRD.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dRD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dRD.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dRD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dRD.ForeColor = System.Drawing.Color.Black
        Me.dRD.Increment = 1.0R
        Me.dRD.Location = New System.Drawing.Point(157, 129)
        Me.dRD.MinValue = 0R
        Me.dRD.Name = "dRD"
        Me.dRD.ShowUpDown = True
        Me.dRD.Size = New System.Drawing.Size(210, 23)
        Me.dRD.TabIndex = 35
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX9.Location = New System.Drawing.Point(7, 129)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(140, 23)
        Me.LabelX9.TabIndex = 250
        Me.LabelX9.Text = "RD"
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
        Me.LabelX5.Location = New System.Drawing.Point(113, 100)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(38, 23)
        Me.LabelX5.TabIndex = 248
        Me.LabelX5.Text = "Php"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dBIR
        '
        '
        '
        '
        Me.dBIR.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dBIR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dBIR.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dBIR.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dBIR.ForeColor = System.Drawing.Color.Black
        Me.dBIR.Increment = 1.0R
        Me.dBIR.Location = New System.Drawing.Point(157, 100)
        Me.dBIR.MinValue = 0R
        Me.dBIR.Name = "dBIR"
        Me.dBIR.ShowUpDown = True
        Me.dBIR.Size = New System.Drawing.Size(210, 23)
        Me.dBIR.TabIndex = 30
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX7.Location = New System.Drawing.Point(7, 100)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(140, 23)
        Me.LabelX7.TabIndex = 247
        Me.LabelX7.Text = "BIR"
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
        Me.LabelX3.Location = New System.Drawing.Point(113, 71)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(38, 23)
        Me.LabelX3.TabIndex = 245
        Me.LabelX3.Text = "Php"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dTransportation
        '
        '
        '
        '
        Me.dTransportation.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTransportation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTransportation.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTransportation.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dTransportation.ForeColor = System.Drawing.Color.Black
        Me.dTransportation.Increment = 1.0R
        Me.dTransportation.Location = New System.Drawing.Point(157, 71)
        Me.dTransportation.MinValue = 0R
        Me.dTransportation.Name = "dTransportation"
        Me.dTransportation.ShowUpDown = True
        Me.dTransportation.Size = New System.Drawing.Size(210, 23)
        Me.dTransportation.TabIndex = 25
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
        Me.LabelX4.Location = New System.Drawing.Point(7, 71)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(140, 23)
        Me.LabelX4.TabIndex = 244
        Me.LabelX4.Text = "Transportation"
        '
        'LabelX99
        '
        Me.LabelX99.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX99.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX99.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX99.Location = New System.Drawing.Point(113, 42)
        Me.LabelX99.Name = "LabelX99"
        Me.LabelX99.Size = New System.Drawing.Size(38, 23)
        Me.LabelX99.TabIndex = 242
        Me.LabelX99.Text = "Php"
        Me.LabelX99.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dMeal
        '
        '
        '
        '
        Me.dMeal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dMeal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dMeal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dMeal.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dMeal.ForeColor = System.Drawing.Color.Black
        Me.dMeal.Increment = 1.0R
        Me.dMeal.Location = New System.Drawing.Point(157, 42)
        Me.dMeal.MinValue = 0R
        Me.dMeal.Name = "dMeal"
        Me.dMeal.ShowUpDown = True
        Me.dMeal.Size = New System.Drawing.Size(210, 23)
        Me.dMeal.TabIndex = 20
        '
        'LabelX100
        '
        Me.LabelX100.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX100.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX100.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX100.Location = New System.Drawing.Point(7, 42)
        Me.LabelX100.Name = "LabelX100"
        Me.LabelX100.Size = New System.Drawing.Size(140, 23)
        Me.LabelX100.TabIndex = 241
        Me.LabelX100.Text = "Meals"
        '
        'txtAccountNumber
        '
        '
        '
        '
        Me.txtAccountNumber.Border.Class = "TextBoxBorder"
        Me.txtAccountNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountNumber.Enabled = False
        Me.txtAccountNumber.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountNumber.Location = New System.Drawing.Point(984, 16)
        Me.txtAccountNumber.MaxLength = 30
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.PreventEnterBeep = True
        Me.txtAccountNumber.Size = New System.Drawing.Size(168, 23)
        Me.txtAccountNumber.TabIndex = 1506
        Me.txtAccountNumber.Text = "CAS-CEB18-0001"
        Me.txtAccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.LabelX6.Location = New System.Drawing.Point(831, 16)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(147, 23)
        Me.LabelX6.TabIndex = 1507
        Me.LabelX6.Text = "Document Number :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.dtpDate.Location = New System.Drawing.Point(647, 16)
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
        Me.dtpDate.Size = New System.Drawing.Size(178, 23)
        Me.dtpDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpDate.TabIndex = 10
        Me.dtpDate.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
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
        Me.LabelX10.Location = New System.Drawing.Point(526, 16)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(115, 23)
        Me.LabelX10.TabIndex = 1505
        Me.LabelX10.Text = "Document Date :"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxPayee
        '
        Me.cbxPayee.DisplayMember = "PREFIX"
        Me.cbxPayee.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxPayee.FormattingEnabled = True
        Me.cbxPayee.Location = New System.Drawing.Point(86, 16)
        Me.cbxPayee.Name = "cbxPayee"
        Me.cbxPayee.Size = New System.Drawing.Size(322, 25)
        Me.cbxPayee.TabIndex = 5
        Me.cbxPayee.ValueMember = "ID"
        '
        'txtPurpose
        '
        '
        '
        '
        Me.txtPurpose.Border.Class = "TextBoxBorder"
        Me.txtPurpose.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPurpose.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.Location = New System.Drawing.Point(86, 45)
        Me.txtPurpose.MaxLength = 350
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.PreventEnterBeep = True
        Me.txtPurpose.Size = New System.Drawing.Size(1066, 23)
        Me.txtPurpose.TabIndex = 15
        Me.txtPurpose.WatermarkText = "Purpose"
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
        Me.LabelX1.Location = New System.Drawing.Point(12, 45)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(68, 23)
        Me.LabelX1.TabIndex = 1496
        Me.LabelX1.Text = "<span align='right'><font color='red'>*</font>Purpose :</span>"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.LabelX2.Location = New System.Drawing.Point(12, 16)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(68, 23)
        Me.LabelX2.TabIndex = 84
        Me.LabelX2.Text = "<span align='right'><font color='red'>*</font>Payee :</span>"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tabSetup
        '
        Me.tabSetup.AttachedControl = Me.SuperTabControlPanel1
        Me.tabSetup.GlobalItem = False
        Me.tabSetup.Name = "tabSetup"
        Me.tabSetup.Text = "Cash Advance Slip"
        Me.tabSetup.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'btnApproveCrecomm
        '
        Me.btnApproveCrecomm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnApproveCrecomm.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnApproveCrecomm.Enabled = False
        Me.btnApproveCrecomm.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApproveCrecomm.Image = Global.FSFC_System.My.Resources.Resources.Approve
        Me.btnApproveCrecomm.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnApproveCrecomm.Location = New System.Drawing.Point(1022, 4)
        Me.btnApproveCrecomm.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnApproveCrecomm.Name = "btnApproveCrecomm"
        Me.btnApproveCrecomm.Size = New System.Drawing.Size(107, 30)
        Me.btnApproveCrecomm.TabIndex = 1030
        Me.btnApproveCrecomm.Text = "Approve Crecomm"
        Me.btnApproveCrecomm.Visible = False
        '
        'btnReceive
        '
        Me.btnReceive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReceive.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnReceive.Enabled = False
        Me.btnReceive.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceive.Image = Global.FSFC_System.My.Resources.Resources.Receive
        Me.btnReceive.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnReceive.Location = New System.Drawing.Point(1022, 4)
        Me.btnReceive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReceive.Name = "btnReceive"
        Me.btnReceive.Size = New System.Drawing.Size(107, 30)
        Me.btnReceive.TabIndex = 1030
        Me.btnReceive.Text = "Receive"
        Me.btnReceive.Visible = False
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
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.Controls.Add(Me.btnEmailCrecom)
        Me.PanelEx3.Controls.Add(Me.btnDisapprove)
        Me.PanelEx3.Controls.Add(Me.btnDelete)
        Me.PanelEx3.Controls.Add(Me.btnAttach)
        Me.PanelEx3.Controls.Add(Me.btnReceive)
        Me.PanelEx3.Controls.Add(Me.btnApproveCrecomm)
        Me.PanelEx3.Controls.Add(Me.btnApprove)
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
        Me.PanelEx3.TabIndex = 1011
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
        'btnEmailCrecom
        '
        Me.btnEmailCrecom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEmailCrecom.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnEmailCrecom.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmailCrecom.Image = CType(resources.GetObject("btnEmailCrecom.Image"), System.Drawing.Image)
        Me.btnEmailCrecom.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnEmailCrecom.Location = New System.Drawing.Point(909, 4)
        Me.btnEmailCrecom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEmailCrecom.Name = "btnEmailCrecom"
        Me.btnEmailCrecom.Size = New System.Drawing.Size(107, 30)
        Me.btnEmailCrecom.SymbolColor = System.Drawing.Color.Black
        Me.btnEmailCrecom.TabIndex = 1523
        Me.btnEmailCrecom.Text = "Send &Email"
        '
        'btnDisapprove
        '
        Me.btnDisapprove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDisapprove.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDisapprove.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisapprove.Image = Global.FSFC_System.My.Resources.Resources.Dislike
        Me.btnDisapprove.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnDisapprove.Location = New System.Drawing.Point(796, 4)
        Me.btnDisapprove.Name = "btnDisapprove"
        Me.btnDisapprove.Size = New System.Drawing.Size(107, 30)
        Me.btnDisapprove.TabIndex = 1523
        Me.btnDisapprove.Text = "Disapprove"
        Me.btnDisapprove.Visible = False
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
        'btnAttach
        '
        Me.btnAttach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAttach.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAttach.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttach.Image = Global.FSFC_System.My.Resources.Resources.Upload
        Me.btnAttach.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnAttach.Location = New System.Drawing.Point(1022, 4)
        Me.btnAttach.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(107, 30)
        Me.btnAttach.TabIndex = 1681
        Me.btnAttach.Text = "Attach"
        Me.btnAttach.Visible = False
        '
        'btnApprove
        '
        Me.btnApprove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnApprove.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnApprove.Enabled = False
        Me.btnApprove.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove.Image = Global.FSFC_System.My.Resources.Resources.Approve
        Me.btnApprove.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnApprove.Location = New System.Drawing.Point(1022, 4)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(107, 30)
        Me.btnApprove.TabIndex = 1030
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.Visible = False
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
        Me.PanelEx1.TabIndex = 1010
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
        Me.lblTitle.Text = "CASH ADVANCE SLIP"
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
        'FrmCashAdvanceSlip
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
        Me.Name = "FrmCashAdvanceSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx19.ResumeLayout(False)
        CType(Me.cbxStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.PanelEx10.ResumeLayout(False)
        CType(Me.gSignatory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gSignatory.ResumeLayout(False)
        CType(Me.dtpDate_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpLiquidate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gLiquidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gLiquidation.ResumeLayout(False)
        CType(Me.dtp_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTotalLiquidation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtp_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dAmount_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gRequest.ResumeLayout(False)
        CType(Me.dTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dOthers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dNotarizationF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dLTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dBIR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTransportation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dMeal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanelEx10 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtPurpose As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tabSetup As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tabList As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnModify As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBack As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents cbxPayee As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtAccountNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gRequest As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gSignatory As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gLiquidation As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpDate_2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpPayroll As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpLiquidate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dTotalLiquidation As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_6 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_6 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_5 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_5 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_4 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_4 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_3 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_3 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_2 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_1 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dOthers As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dNotarizationF As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dLTO As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dRD As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dBIR As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dTransportation As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX99 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dMeal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX100 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtp_7 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dAmount_7 As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtReceived As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtApproved As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX38 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnReceive As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnApprove As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnApproveCrecomm As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelEx19 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents cbxLiquidated As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxDisplay As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpTo As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpFrom As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX42 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxForApproval As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxForCheckVoucher As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtReceivedDate As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxForLiquidation As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnAttach As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnDisapprove As DevComponents.DotNetBar.ButtonX
    Public WithEvents btnEmailCrecom As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbxPreparedBy As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX44 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbxCancelled As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ContextMenuBar3 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iLiquidate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iTagLiquidate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iReturn As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cbxOther As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCheckVoucher As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTagCheckVoucher As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cbxStatus As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents cbxReceived As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
