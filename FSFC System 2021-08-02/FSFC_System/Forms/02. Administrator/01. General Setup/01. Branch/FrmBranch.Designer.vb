<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBranch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBranch))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabControl2 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.btnTariff = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.iAvailedPenalty = New DevComponents.Editors.IntegerInput()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.iAvailedRPPD = New DevComponents.Editors.IntegerInput()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.txtEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.dPenalty = New DevComponents.Editors.DoubleInput()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.dRPPD = New DevComponents.Editors.DoubleInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.iRPPD_Start = New DevComponents.Editors.IntegerInput()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.cbxRoundUp = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.tabCreditApplication = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel8 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.cbxApprover4 = New SergeUtils.EasyCompletionComboBox()
        Me.cbxApprover3 = New SergeUtils.EasyCompletionComboBox()
        Me.cbxApprover2 = New SergeUtils.EasyCompletionComboBox()
        Me.cbxApprover1 = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX38 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.dOIC = New DevComponents.Editors.DoubleInput()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.dBM = New DevComponents.Editors.DoubleInput()
        Me.LabelX44 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.dDM = New DevComponents.Editors.DoubleInput()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.dRM = New DevComponents.Editors.DoubleInput()
        Me.dOIC_CA = New DevComponents.Editors.DoubleInput()
        Me.dBM_CA = New DevComponents.Editors.DoubleInput()
        Me.dDM_CA = New DevComponents.Editors.DoubleInput()
        Me.dRM_CA = New DevComponents.Editors.DoubleInput()
        Me.tabApproval = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.btnReset = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAuto_Off = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX46 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAuto_On = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxEmail_Off = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.cbxEmail_On = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxSMS_Off = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.cbxSMS_On = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.tabSettings = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LabelX51 = New DevComponents.DotNetBar.LabelX()
        Me.cbxOther_Off = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX52 = New DevComponents.DotNetBar.LabelX()
        Me.cbxOther_On = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.cbxBankBranch = New SergeUtils.EasyCompletionComboBox()
        Me.cbxUseOtherBank = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX49 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAvancePrincipal_Off = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX50 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAvancePrincipal_On = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX47 = New DevComponents.DotNetBar.LabelX()
        Me.cbxDeferred_Off = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX45 = New DevComponents.DotNetBar.LabelX()
        Me.cbxDeferred_On = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.dPettyCash = New DevComponents.Editors.DoubleInput()
        Me.tabFinancial = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.btnYard = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.iRedemption = New DevComponents.Editors.IntegerInput()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.iReservation = New DevComponents.Editors.IntegerInput()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.cbxOverstay = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.iOverstay = New DevComponents.Editors.IntegerInput()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.dTransactionAmount = New DevComponents.Editors.DoubleInput()
        Me.tabROPOA = New DevComponents.DotNetBar.SuperTabItem()
        Me.PanelEx10 = New DevComponents.DotNetBar.PanelEx()
        Me.cbxBranchCode = New SergeUtils.EasyCompletionComboBox()
        Me.cbxMicrofinance = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX42 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAddress = New SergeUtils.EasyCompletionComboBox()
        Me.txtTIN = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.txtPath = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnBrowse = New DevComponents.DotNetBar.ButtonX()
        Me.pb_Location = New DevExpress.XtraEditors.PictureEdit()
        Me.txtEmailAddress = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.txtContactN3 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.txtContactN2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txtContactN1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtAddress = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.cbxNA = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.dtpOpened = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtBranchID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtBranchCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtBranch = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.tabBranch = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn87 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn85 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn86 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn89 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn90 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn91 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn92 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabList = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn88 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn77 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn82 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn83 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn84 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn93 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn94 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn79 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn95 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn80 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn96 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn81 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabMicroBranch = New DevComponents.DotNetBar.SuperTabItem()
        Me.btnMap = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnModify = New DevComponents.DotNetBar.ButtonX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.btnBack = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl2.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.iAvailedPenalty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iAvailedRPPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPenalty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dRPPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iRPPD_Start, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel8.SuspendLayout()
        CType(Me.dOIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dDM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dRM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dOIC_CA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dBM_CA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dDM_CA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dRM_CA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel6.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.dPettyCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.iRedemption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iReservation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iOverstay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTransactionAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx10.SuspendLayout()
        CType(Me.pb_Location.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpOpened, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel7.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.PanelEx1.TabIndex = 12
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
        Me.btnLogs.TabIndex = 1031
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
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "BRANCH SETUP"
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel7)
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
        Me.SuperTabControl1.TabIndex = 37
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabBranch, Me.tabList, Me.tabMicroBranch})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock
        Me.SuperTabControl1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.SuperTabControl2)
        Me.SuperTabControlPanel1.Controls.Add(Me.PanelEx10)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.tabBranch
        '
        'SuperTabControl2
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl2.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl2.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl2.ControlBox.Name = ""
        Me.SuperTabControl2.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl2.ControlBox.MenuBox, Me.SuperTabControl2.ControlBox.CloseBox})
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel8)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel6)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl2.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl2.FixedTabSize = New System.Drawing.Size(150, 30)
        Me.SuperTabControl2.Location = New System.Drawing.Point(0, 340)
        Me.SuperTabControl2.Name = "SuperTabControl2"
        Me.SuperTabControl2.ReorderTabsEnabled = True
        Me.SuperTabControl2.SelectedTabFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl2.SelectedTabIndex = 0
        Me.SuperTabControl2.Size = New System.Drawing.Size(1167, 229)
        Me.SuperTabControl2.TabFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl2.TabIndex = 101
        Me.SuperTabControl2.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabCreditApplication, Me.tabROPOA, Me.tabFinancial, Me.tabSettings, Me.tabApproval})
        Me.SuperTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock
        Me.SuperTabControl2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.btnTariff)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX32)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX31)
        Me.SuperTabControlPanel3.Controls.Add(Me.iAvailedPenalty)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX30)
        Me.SuperTabControlPanel3.Controls.Add(Me.iAvailedRPPD)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX26)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX24)
        Me.SuperTabControlPanel3.Controls.Add(Me.txtEmail)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX23)
        Me.SuperTabControlPanel3.Controls.Add(Me.dPenalty)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX19)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX20)
        Me.SuperTabControlPanel3.Controls.Add(Me.dRPPD)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX10)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX4)
        Me.SuperTabControlPanel3.Controls.Add(Me.iRPPD_Start)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX12)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX13)
        Me.SuperTabControlPanel3.Controls.Add(Me.cbxRoundUp)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 32)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1167, 197)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.tabCreditApplication
        '
        'btnTariff
        '
        Me.btnTariff.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnTariff.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnTariff.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTariff.Image = Global.FSFC_System.My.Resources.Resources.Add
        Me.btnTariff.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnTariff.Location = New System.Drawing.Point(385, 12)
        Me.btnTariff.Name = "btnTariff"
        Me.btnTariff.Size = New System.Drawing.Size(107, 30)
        Me.btnTariff.TabIndex = 1709
        Me.btnTariff.Text = "Add Tariff"
        Me.btnTariff.Visible = False
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX32.ForeColor = System.Drawing.Color.Red
        Me.LabelX32.Location = New System.Drawing.Point(321, 160)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(240, 23)
        Me.LabelX32.TabIndex = 1706
        Me.LabelX32.Text = "Banking Day(s) for availed Penalty."
        '
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX31.ForeColor = System.Drawing.Color.Red
        Me.LabelX31.Location = New System.Drawing.Point(321, 131)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(240, 23)
        Me.LabelX31.TabIndex = 1705
        Me.LabelX31.Text = "Banking Day(s) for availed RPPD."
        '
        'iAvailedPenalty
        '
        '
        '
        '
        Me.iAvailedPenalty.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iAvailedPenalty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iAvailedPenalty.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iAvailedPenalty.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iAvailedPenalty.Location = New System.Drawing.Point(143, 162)
        Me.iAvailedPenalty.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iAvailedPenalty.MaxValue = 99
        Me.iAvailedPenalty.MinValue = 0
        Me.iAvailedPenalty.Name = "iAvailedPenalty"
        Me.iAvailedPenalty.ShowUpDown = True
        Me.iAvailedPenalty.Size = New System.Drawing.Size(173, 23)
        Me.iAvailedPenalty.TabIndex = 95
        '
        'LabelX30
        '
        Me.LabelX30.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX30.Location = New System.Drawing.Point(3, 162)
        Me.LabelX30.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(134, 23)
        Me.LabelX30.TabIndex = 1704
        Me.LabelX30.Text = "Availed Penalty :"
        Me.LabelX30.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iAvailedRPPD
        '
        '
        '
        '
        Me.iAvailedRPPD.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iAvailedRPPD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iAvailedRPPD.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iAvailedRPPD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iAvailedRPPD.Location = New System.Drawing.Point(143, 131)
        Me.iAvailedRPPD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iAvailedRPPD.MaxValue = 99
        Me.iAvailedRPPD.MinValue = 0
        Me.iAvailedRPPD.Name = "iAvailedRPPD"
        Me.iAvailedRPPD.ShowUpDown = True
        Me.iAvailedRPPD.Size = New System.Drawing.Size(173, 23)
        Me.iAvailedRPPD.TabIndex = 90
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
        Me.LabelX26.Location = New System.Drawing.Point(3, 131)
        Me.LabelX26.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(134, 23)
        Me.LabelX26.TabIndex = 1702
        Me.LabelX26.Text = "Availed RPPD :"
        Me.LabelX26.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Red
        Me.LabelX24.Location = New System.Drawing.Point(579, 160)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(537, 26)
        Me.LabelX24.TabIndex = 1692
        Me.LabelX24.Text = "The confidential email that will create the system generated crecomm approval."
        Me.LabelX24.Visible = False
        Me.LabelX24.WordWrap = True
        '
        'txtEmail
        '
        '
        '
        '
        Me.txtEmail.Border.Class = "TextBoxBorder"
        Me.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEmail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(736, 131)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PreventEnterBeep = True
        Me.txtEmail.Size = New System.Drawing.Size(263, 23)
        Me.txtEmail.TabIndex = 115
        Me.txtEmail.Visible = False
        Me.txtEmail.WatermarkText = "Email Address"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX23.Location = New System.Drawing.Point(565, 129)
        Me.LabelX23.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(165, 25)
        Me.LabelX23.TabIndex = 1687
        Me.LabelX23.Text = "Confidential EmailAdd :"
        Me.LabelX23.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX23.Visible = False
        '
        'dPenalty
        '
        '
        '
        '
        Me.dPenalty.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dPenalty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dPenalty.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dPenalty.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dPenalty.ForeColor = System.Drawing.Color.Black
        Me.dPenalty.Increment = 1.0R
        Me.dPenalty.Location = New System.Drawing.Point(143, 101)
        Me.dPenalty.MaxValue = 100.0R
        Me.dPenalty.MinValue = 0.0R
        Me.dPenalty.Name = "dPenalty"
        Me.dPenalty.ShowUpDown = True
        Me.dPenalty.Size = New System.Drawing.Size(173, 23)
        Me.dPenalty.TabIndex = 86
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
        Me.LabelX19.Location = New System.Drawing.Point(3, 101)
        Me.LabelX19.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(134, 23)
        Me.LabelX19.TabIndex = 96
        Me.LabelX19.Text = "Penalty :"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX20.Location = New System.Drawing.Point(322, 101)
        Me.LabelX20.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(45, 23)
        Me.LabelX20.TabIndex = 97
        Me.LabelX20.Text = "%"
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
        Me.dRPPD.Location = New System.Drawing.Point(143, 12)
        Me.dRPPD.MaxValue = 100.0R
        Me.dRPPD.MinValue = 0.0R
        Me.dRPPD.Name = "dRPPD"
        Me.dRPPD.ShowUpDown = True
        Me.dRPPD.Size = New System.Drawing.Size(173, 23)
        Me.dRPPD.TabIndex = 75
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
        Me.LabelX10.Location = New System.Drawing.Point(3, 12)
        Me.LabelX10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(134, 23)
        Me.LabelX10.TabIndex = 90
        Me.LabelX10.Text = "RPPD :"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.LabelX4.Location = New System.Drawing.Point(322, 12)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(45, 23)
        Me.LabelX4.TabIndex = 91
        Me.LabelX4.Text = "%"
        '
        'iRPPD_Start
        '
        '
        '
        '
        Me.iRPPD_Start.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iRPPD_Start.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iRPPD_Start.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iRPPD_Start.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iRPPD_Start.Location = New System.Drawing.Point(143, 42)
        Me.iRPPD_Start.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iRPPD_Start.MaxValue = 99
        Me.iRPPD_Start.MinValue = 0
        Me.iRPPD_Start.Name = "iRPPD_Start"
        Me.iRPPD_Start.ShowUpDown = True
        Me.iRPPD_Start.Size = New System.Drawing.Size(173, 23)
        Me.iRPPD_Start.TabIndex = 80
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
        Me.LabelX12.Location = New System.Drawing.Point(3, 42)
        Me.LabelX12.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(134, 23)
        Me.LabelX12.TabIndex = 93
        Me.LabelX12.Text = "RPPD Start at :"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.LabelX13.Location = New System.Drawing.Point(322, 42)
        Me.LabelX13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(45, 23)
        Me.LabelX13.TabIndex = 94
        Me.LabelX13.Text = "Month"
        '
        'cbxRoundUp
        '
        Me.cbxRoundUp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxRoundUp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxRoundUp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRoundUp.Location = New System.Drawing.Point(143, 72)
        Me.cbxRoundUp.Name = "cbxRoundUp"
        Me.cbxRoundUp.Size = New System.Drawing.Size(349, 23)
        Me.cbxRoundUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxRoundUp.TabIndex = 85
        Me.cbxRoundUp.Text = "Round Up the 0.50 decimal to the nearest peso"
        Me.cbxRoundUp.TextColor = System.Drawing.Color.Maroon
        '
        'tabCreditApplication
        '
        Me.tabCreditApplication.AttachedControl = Me.SuperTabControlPanel3
        Me.tabCreditApplication.GlobalItem = False
        Me.tabCreditApplication.Name = "tabCreditApplication"
        Me.tabCreditApplication.Text = "Credit Application"
        Me.tabCreditApplication.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel8
        '
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX43)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX41)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX40)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX39)
        Me.SuperTabControlPanel8.Controls.Add(Me.cbxApprover4)
        Me.SuperTabControlPanel8.Controls.Add(Me.cbxApprover3)
        Me.SuperTabControlPanel8.Controls.Add(Me.cbxApprover2)
        Me.SuperTabControlPanel8.Controls.Add(Me.cbxApprover1)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX38)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX29)
        Me.SuperTabControlPanel8.Controls.Add(Me.dOIC)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX25)
        Me.SuperTabControlPanel8.Controls.Add(Me.dBM)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX44)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX27)
        Me.SuperTabControlPanel8.Controls.Add(Me.dDM)
        Me.SuperTabControlPanel8.Controls.Add(Me.LabelX28)
        Me.SuperTabControlPanel8.Controls.Add(Me.dRM)
        Me.SuperTabControlPanel8.Controls.Add(Me.dOIC_CA)
        Me.SuperTabControlPanel8.Controls.Add(Me.dBM_CA)
        Me.SuperTabControlPanel8.Controls.Add(Me.dDM_CA)
        Me.SuperTabControlPanel8.Controls.Add(Me.dRM_CA)
        Me.SuperTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel8.Location = New System.Drawing.Point(0, 32)
        Me.SuperTabControlPanel8.Name = "SuperTabControlPanel8"
        Me.SuperTabControlPanel8.Size = New System.Drawing.Size(1167, 197)
        Me.SuperTabControlPanel8.TabIndex = 0
        Me.SuperTabControlPanel8.TabItem = Me.tabApproval
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
        Me.LabelX43.Location = New System.Drawing.Point(12, 134)
        Me.LabelX43.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(73, 23)
        Me.LabelX43.TabIndex = 1798
        Me.LabelX43.Text = "Level IV :"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.LabelX41.Location = New System.Drawing.Point(12, 103)
        Me.LabelX41.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX41.Name = "LabelX41"
        Me.LabelX41.Size = New System.Drawing.Size(73, 23)
        Me.LabelX41.TabIndex = 1797
        Me.LabelX41.Text = "Level III :"
        Me.LabelX41.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.LabelX40.Location = New System.Drawing.Point(12, 72)
        Me.LabelX40.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.Size = New System.Drawing.Size(73, 23)
        Me.LabelX40.TabIndex = 1796
        Me.LabelX40.Text = "Level II :"
        Me.LabelX40.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.LabelX39.Location = New System.Drawing.Point(12, 41)
        Me.LabelX39.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.Size = New System.Drawing.Size(73, 23)
        Me.LabelX39.TabIndex = 1795
        Me.LabelX39.Text = "Level I :"
        Me.LabelX39.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxApprover4
        '
        Me.cbxApprover4.DisplayMember = "CITY"
        Me.cbxApprover4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxApprover4.FormattingEnabled = True
        Me.cbxApprover4.Location = New System.Drawing.Point(91, 130)
        Me.cbxApprover4.MaxLength = 100
        Me.cbxApprover4.Name = "cbxApprover4"
        Me.cbxApprover4.Size = New System.Drawing.Size(326, 25)
        Me.cbxApprover4.TabIndex = 50
        Me.cbxApprover4.ValueMember = "ID"
        '
        'cbxApprover3
        '
        Me.cbxApprover3.DisplayMember = "CITY"
        Me.cbxApprover3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxApprover3.FormattingEnabled = True
        Me.cbxApprover3.Location = New System.Drawing.Point(91, 99)
        Me.cbxApprover3.MaxLength = 100
        Me.cbxApprover3.Name = "cbxApprover3"
        Me.cbxApprover3.Size = New System.Drawing.Size(326, 25)
        Me.cbxApprover3.TabIndex = 35
        Me.cbxApprover3.ValueMember = "ID"
        '
        'cbxApprover2
        '
        Me.cbxApprover2.DisplayMember = "CITY"
        Me.cbxApprover2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxApprover2.FormattingEnabled = True
        Me.cbxApprover2.Location = New System.Drawing.Point(91, 69)
        Me.cbxApprover2.MaxLength = 100
        Me.cbxApprover2.Name = "cbxApprover2"
        Me.cbxApprover2.Size = New System.Drawing.Size(326, 25)
        Me.cbxApprover2.TabIndex = 20
        Me.cbxApprover2.ValueMember = "ID"
        '
        'cbxApprover1
        '
        Me.cbxApprover1.DisplayMember = "CITY"
        Me.cbxApprover1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxApprover1.FormattingEnabled = True
        Me.cbxApprover1.Location = New System.Drawing.Point(91, 39)
        Me.cbxApprover1.MaxLength = 100
        Me.cbxApprover1.Name = "cbxApprover1"
        Me.cbxApprover1.Size = New System.Drawing.Size(326, 25)
        Me.cbxApprover1.TabIndex = 5
        Me.cbxApprover1.ValueMember = "ID"
        '
        'LabelX38
        '
        Me.LabelX38.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX38.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX38.ForeColor = System.Drawing.Color.White
        Me.LabelX38.Location = New System.Drawing.Point(602, 10)
        Me.LabelX38.Name = "LabelX38"
        Me.LabelX38.Size = New System.Drawing.Size(173, 23)
        Me.LabelX38.TabIndex = 1794
        Me.LabelX38.Text = "Cash Advance"
        Me.LabelX38.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX29
        '
        Me.LabelX29.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX29.ForeColor = System.Drawing.Color.White
        Me.LabelX29.Location = New System.Drawing.Point(423, 10)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(173, 23)
        Me.LabelX29.TabIndex = 1793
        Me.LabelX29.Text = "Credit Application"
        Me.LabelX29.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'dOIC
        '
        '
        '
        '
        Me.dOIC.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dOIC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dOIC.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dOIC.Enabled = False
        Me.dOIC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dOIC.ForeColor = System.Drawing.Color.Black
        Me.dOIC.Increment = 1.0R
        Me.dOIC.Location = New System.Drawing.Point(423, 39)
        Me.dOIC.MaxValue = 999999999.0R
        Me.dOIC.MinValue = 0.0R
        Me.dOIC.Name = "dOIC"
        Me.dOIC.ShowUpDown = True
        Me.dOIC.Size = New System.Drawing.Size(173, 23)
        Me.dOIC.TabIndex = 10
        '
        'LabelX25
        '
        Me.LabelX25.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX25.Location = New System.Drawing.Point(781, 68)
        Me.LabelX25.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(371, 23)
        Me.LabelX25.TabIndex = 1694
        Me.LabelX25.Text = "Position"
        '
        'dBM
        '
        '
        '
        '
        Me.dBM.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dBM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dBM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dBM.Enabled = False
        Me.dBM.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dBM.ForeColor = System.Drawing.Color.Black
        Me.dBM.Increment = 1.0R
        Me.dBM.Location = New System.Drawing.Point(423, 69)
        Me.dBM.MaxValue = 999999999.0R
        Me.dBM.MinValue = 0.0R
        Me.dBM.Name = "dBM"
        Me.dBM.ShowUpDown = True
        Me.dBM.Size = New System.Drawing.Size(173, 23)
        Me.dBM.TabIndex = 25
        '
        'LabelX44
        '
        Me.LabelX44.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX44.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX44.Location = New System.Drawing.Point(781, 39)
        Me.LabelX44.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX44.Name = "LabelX44"
        Me.LabelX44.Size = New System.Drawing.Size(371, 23)
        Me.LabelX44.TabIndex = 1708
        Me.LabelX44.Text = "Position"
        '
        'LabelX27
        '
        Me.LabelX27.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX27.Location = New System.Drawing.Point(781, 98)
        Me.LabelX27.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(371, 23)
        Me.LabelX27.TabIndex = 1697
        Me.LabelX27.Text = "Position"
        '
        'dDM
        '
        '
        '
        '
        Me.dDM.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dDM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dDM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dDM.Enabled = False
        Me.dDM.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dDM.ForeColor = System.Drawing.Color.Black
        Me.dDM.Increment = 1.0R
        Me.dDM.Location = New System.Drawing.Point(423, 99)
        Me.dDM.MaxValue = 999999999.0R
        Me.dDM.MinValue = 0.0R
        Me.dDM.Name = "dDM"
        Me.dDM.ShowUpDown = True
        Me.dDM.Size = New System.Drawing.Size(173, 23)
        Me.dDM.TabIndex = 40
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX28.Location = New System.Drawing.Point(781, 128)
        Me.LabelX28.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(371, 23)
        Me.LabelX28.TabIndex = 1699
        Me.LabelX28.Text = "Position"
        '
        'dRM
        '
        '
        '
        '
        Me.dRM.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dRM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dRM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dRM.Enabled = False
        Me.dRM.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dRM.ForeColor = System.Drawing.Color.Black
        Me.dRM.Increment = 1.0R
        Me.dRM.Location = New System.Drawing.Point(423, 129)
        Me.dRM.MaxValue = 999999999.0R
        Me.dRM.MinValue = 0.0R
        Me.dRM.Name = "dRM"
        Me.dRM.ShowUpDown = True
        Me.dRM.Size = New System.Drawing.Size(173, 23)
        Me.dRM.TabIndex = 55
        '
        'dOIC_CA
        '
        '
        '
        '
        Me.dOIC_CA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dOIC_CA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dOIC_CA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dOIC_CA.Enabled = False
        Me.dOIC_CA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dOIC_CA.ForeColor = System.Drawing.Color.Black
        Me.dOIC_CA.Increment = 1.0R
        Me.dOIC_CA.Location = New System.Drawing.Point(602, 39)
        Me.dOIC_CA.MaxValue = 999999999.0R
        Me.dOIC_CA.MinValue = 0.0R
        Me.dOIC_CA.Name = "dOIC_CA"
        Me.dOIC_CA.ShowUpDown = True
        Me.dOIC_CA.Size = New System.Drawing.Size(173, 23)
        Me.dOIC_CA.TabIndex = 15
        '
        'dBM_CA
        '
        '
        '
        '
        Me.dBM_CA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dBM_CA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dBM_CA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dBM_CA.Enabled = False
        Me.dBM_CA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dBM_CA.ForeColor = System.Drawing.Color.Black
        Me.dBM_CA.Increment = 1.0R
        Me.dBM_CA.Location = New System.Drawing.Point(602, 68)
        Me.dBM_CA.MaxValue = 999999999.0R
        Me.dBM_CA.MinValue = 0.0R
        Me.dBM_CA.Name = "dBM_CA"
        Me.dBM_CA.ShowUpDown = True
        Me.dBM_CA.Size = New System.Drawing.Size(173, 23)
        Me.dBM_CA.TabIndex = 30
        '
        'dDM_CA
        '
        '
        '
        '
        Me.dDM_CA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dDM_CA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dDM_CA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dDM_CA.Enabled = False
        Me.dDM_CA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dDM_CA.ForeColor = System.Drawing.Color.Black
        Me.dDM_CA.Increment = 1.0R
        Me.dDM_CA.Location = New System.Drawing.Point(602, 97)
        Me.dDM_CA.MaxValue = 999999999.0R
        Me.dDM_CA.MinValue = 0.0R
        Me.dDM_CA.Name = "dDM_CA"
        Me.dDM_CA.ShowUpDown = True
        Me.dDM_CA.Size = New System.Drawing.Size(173, 23)
        Me.dDM_CA.TabIndex = 45
        '
        'dRM_CA
        '
        '
        '
        '
        Me.dRM_CA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dRM_CA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dRM_CA.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dRM_CA.Enabled = False
        Me.dRM_CA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dRM_CA.ForeColor = System.Drawing.Color.Black
        Me.dRM_CA.Increment = 1.0R
        Me.dRM_CA.Location = New System.Drawing.Point(602, 127)
        Me.dRM_CA.MaxValue = 999999999.0R
        Me.dRM_CA.MinValue = 0.0R
        Me.dRM_CA.Name = "dRM_CA"
        Me.dRM_CA.ShowUpDown = True
        Me.dRM_CA.Size = New System.Drawing.Size(173, 23)
        Me.dRM_CA.TabIndex = 60
        '
        'tabApproval
        '
        Me.tabApproval.AttachedControl = Me.SuperTabControlPanel8
        Me.tabApproval.GlobalItem = False
        Me.tabApproval.Name = "tabApproval"
        Me.tabApproval.Text = "Approval"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.btnReset)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX48)
        Me.SuperTabControlPanel6.Controls.Add(Me.cbxAuto_Off)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX46)
        Me.SuperTabControlPanel6.Controls.Add(Me.cbxAuto_On)
        Me.SuperTabControlPanel6.Controls.Add(Me.cbxEmail_Off)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX36)
        Me.SuperTabControlPanel6.Controls.Add(Me.cbxEmail_On)
        Me.SuperTabControlPanel6.Controls.Add(Me.cbxSMS_Off)
        Me.SuperTabControlPanel6.Controls.Add(Me.LabelX35)
        Me.SuperTabControlPanel6.Controls.Add(Me.cbxSMS_On)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 32)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(1167, 197)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.tabSettings
        '
        'btnReset
        '
        Me.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnReset.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = Global.FSFC_System.My.Resources.Resources.Delete
        Me.btnReset.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnReset.Location = New System.Drawing.Point(143, 99)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(107, 30)
        Me.btnReset.TabIndex = 35
        Me.btnReset.Text = "Reset Data"
        Me.btnReset.Visible = False
        '
        'LabelX48
        '
        Me.LabelX48.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX48.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX48.ForeColor = System.Drawing.Color.Red
        Me.LabelX48.Location = New System.Drawing.Point(235, 70)
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Size = New System.Drawing.Size(471, 23)
        Me.LabelX48.TabIndex = 1720
        Me.LabelX48.Text = "This will automatically send the SMS and Email for branch for notification."
        '
        'cbxAuto_Off
        '
        Me.cbxAuto_Off.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAuto_Off.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAuto_Off.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAuto_Off.Location = New System.Drawing.Point(189, 70)
        Me.cbxAuto_Off.Name = "cbxAuto_Off"
        Me.cbxAuto_Off.Size = New System.Drawing.Size(51, 23)
        Me.cbxAuto_Off.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAuto_Off.TabIndex = 30
        Me.cbxAuto_Off.Text = "Off"
        '
        'LabelX46
        '
        Me.LabelX46.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX46.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX46.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX46.Location = New System.Drawing.Point(3, 70)
        Me.LabelX46.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX46.Name = "LabelX46"
        Me.LabelX46.Size = New System.Drawing.Size(134, 23)
        Me.LabelX46.TabIndex = 109
        Me.LabelX46.Text = "Auto Notification :"
        Me.LabelX46.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxAuto_On
        '
        Me.cbxAuto_On.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAuto_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAuto_On.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAuto_On.Location = New System.Drawing.Point(143, 70)
        Me.cbxAuto_On.Name = "cbxAuto_On"
        Me.cbxAuto_On.Size = New System.Drawing.Size(51, 23)
        Me.cbxAuto_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAuto_On.TabIndex = 25
        Me.cbxAuto_On.Text = "On"
        '
        'cbxEmail_Off
        '
        Me.cbxEmail_Off.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxEmail_Off.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxEmail_Off.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxEmail_Off.Location = New System.Drawing.Point(189, 41)
        Me.cbxEmail_Off.Name = "cbxEmail_Off"
        Me.cbxEmail_Off.Size = New System.Drawing.Size(51, 23)
        Me.cbxEmail_Off.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxEmail_Off.TabIndex = 20
        Me.cbxEmail_Off.Text = "Off"
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
        Me.LabelX36.Location = New System.Drawing.Point(3, 41)
        Me.LabelX36.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(134, 23)
        Me.LabelX36.TabIndex = 106
        Me.LabelX36.Text = "Email Notification :"
        Me.LabelX36.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxEmail_On
        '
        Me.cbxEmail_On.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxEmail_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxEmail_On.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxEmail_On.Location = New System.Drawing.Point(143, 41)
        Me.cbxEmail_On.Name = "cbxEmail_On"
        Me.cbxEmail_On.Size = New System.Drawing.Size(51, 23)
        Me.cbxEmail_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxEmail_On.TabIndex = 15
        Me.cbxEmail_On.Text = "On"
        '
        'cbxSMS_Off
        '
        Me.cbxSMS_Off.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxSMS_Off.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxSMS_Off.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSMS_Off.Location = New System.Drawing.Point(189, 12)
        Me.cbxSMS_Off.Name = "cbxSMS_Off"
        Me.cbxSMS_Off.Size = New System.Drawing.Size(51, 23)
        Me.cbxSMS_Off.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxSMS_Off.TabIndex = 10
        Me.cbxSMS_Off.Text = "Off"
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
        Me.LabelX35.Location = New System.Drawing.Point(3, 12)
        Me.LabelX35.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(134, 23)
        Me.LabelX35.TabIndex = 103
        Me.LabelX35.Text = "SMS Notification :"
        Me.LabelX35.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxSMS_On
        '
        Me.cbxSMS_On.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxSMS_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxSMS_On.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSMS_On.Location = New System.Drawing.Point(143, 12)
        Me.cbxSMS_On.Name = "cbxSMS_On"
        Me.cbxSMS_On.Size = New System.Drawing.Size(51, 23)
        Me.cbxSMS_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxSMS_On.TabIndex = 5
        Me.cbxSMS_On.Text = "On"
        '
        'tabSettings
        '
        Me.tabSettings.AttachedControl = Me.SuperTabControlPanel6
        Me.tabSettings.GlobalItem = False
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Text = "Settings"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX51)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxOther_Off)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX52)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxOther_On)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX11)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxBankBranch)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxUseOtherBank)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX49)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxAvancePrincipal_Off)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX50)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxAvancePrincipal_On)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX47)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxDeferred_Off)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX45)
        Me.SuperTabControlPanel5.Controls.Add(Me.cbxDeferred_On)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX34)
        Me.SuperTabControlPanel5.Controls.Add(Me.LabelX33)
        Me.SuperTabControlPanel5.Controls.Add(Me.dPettyCash)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 32)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(1167, 197)
        Me.SuperTabControlPanel5.TabIndex = 10
        Me.SuperTabControlPanel5.TabItem = Me.tabFinancial
        '
        'LabelX51
        '
        Me.LabelX51.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX51.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX51.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX51.ForeColor = System.Drawing.Color.Red
        Me.LabelX51.Location = New System.Drawing.Point(235, 42)
        Me.LabelX51.Name = "LabelX51"
        Me.LabelX51.Size = New System.Drawing.Size(307, 23)
        Me.LabelX51.TabIndex = 1728
        Me.LabelX51.Text = "PCV and CAS from other branch."
        '
        'cbxOther_Off
        '
        Me.cbxOther_Off.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxOther_Off.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxOther_Off.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOther_Off.Location = New System.Drawing.Point(189, 43)
        Me.cbxOther_Off.Name = "cbxOther_Off"
        Me.cbxOther_Off.Size = New System.Drawing.Size(51, 23)
        Me.cbxOther_Off.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxOther_Off.TabIndex = 7
        Me.cbxOther_Off.Text = "Off"
        '
        'LabelX52
        '
        Me.LabelX52.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX52.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX52.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX52.Location = New System.Drawing.Point(3, 43)
        Me.LabelX52.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX52.Name = "LabelX52"
        Me.LabelX52.Size = New System.Drawing.Size(134, 23)
        Me.LabelX52.TabIndex = 1727
        Me.LabelX52.Text = "From Other Branch :"
        Me.LabelX52.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxOther_On
        '
        Me.cbxOther_On.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxOther_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxOther_On.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOther_On.Location = New System.Drawing.Point(143, 43)
        Me.cbxOther_On.Name = "cbxOther_On"
        Me.cbxOther_On.Size = New System.Drawing.Size(51, 23)
        Me.cbxOther_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxOther_On.TabIndex = 6
        Me.cbxOther_On.Text = "On"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX11.Location = New System.Drawing.Point(3, 156)
        Me.LabelX11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(134, 23)
        Me.LabelX11.TabIndex = 1724
        Me.LabelX11.Text = "Branch :"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxBankBranch
        '
        Me.cbxBankBranch.DisplayMember = "CITY"
        Me.cbxBankBranch.Enabled = False
        Me.cbxBankBranch.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBankBranch.FormattingEnabled = True
        Me.cbxBankBranch.Location = New System.Drawing.Point(143, 156)
        Me.cbxBankBranch.MaxLength = 100
        Me.cbxBankBranch.Name = "cbxBankBranch"
        Me.cbxBankBranch.Size = New System.Drawing.Size(383, 25)
        Me.cbxBankBranch.TabIndex = 27
        Me.cbxBankBranch.ValueMember = "ID"
        '
        'cbxUseOtherBank
        '
        Me.cbxUseOtherBank.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxUseOtherBank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxUseOtherBank.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxUseOtherBank.Location = New System.Drawing.Point(143, 127)
        Me.cbxUseOtherBank.Name = "cbxUseOtherBank"
        Me.cbxUseOtherBank.Size = New System.Drawing.Size(173, 23)
        Me.cbxUseOtherBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxUseOtherBank.TabIndex = 26
        Me.cbxUseOtherBank.Text = "Use other Branch Bank"
        '
        'LabelX49
        '
        Me.LabelX49.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX49.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX49.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX49.ForeColor = System.Drawing.Color.Red
        Me.LabelX49.Location = New System.Drawing.Point(235, 100)
        Me.LabelX49.Name = "LabelX49"
        Me.LabelX49.Size = New System.Drawing.Size(307, 23)
        Me.LabelX49.TabIndex = 1723
        Me.LabelX49.Text = "Advance payment will be used on Principal."
        '
        'cbxAvancePrincipal_Off
        '
        Me.cbxAvancePrincipal_Off.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAvancePrincipal_Off.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAvancePrincipal_Off.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAvancePrincipal_Off.Location = New System.Drawing.Point(189, 101)
        Me.cbxAvancePrincipal_Off.Name = "cbxAvancePrincipal_Off"
        Me.cbxAvancePrincipal_Off.Size = New System.Drawing.Size(51, 23)
        Me.cbxAvancePrincipal_Off.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAvancePrincipal_Off.TabIndex = 25
        Me.cbxAvancePrincipal_Off.Text = "Off"
        '
        'LabelX50
        '
        Me.LabelX50.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX50.Location = New System.Drawing.Point(3, 101)
        Me.LabelX50.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX50.Name = "LabelX50"
        Me.LabelX50.Size = New System.Drawing.Size(134, 23)
        Me.LabelX50.TabIndex = 1722
        Me.LabelX50.Text = "Advance Principal :"
        Me.LabelX50.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxAvancePrincipal_On
        '
        Me.cbxAvancePrincipal_On.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAvancePrincipal_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAvancePrincipal_On.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAvancePrincipal_On.Location = New System.Drawing.Point(143, 101)
        Me.cbxAvancePrincipal_On.Name = "cbxAvancePrincipal_On"
        Me.cbxAvancePrincipal_On.Size = New System.Drawing.Size(51, 23)
        Me.cbxAvancePrincipal_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAvancePrincipal_On.TabIndex = 20
        Me.cbxAvancePrincipal_On.Text = "On"
        '
        'LabelX47
        '
        Me.LabelX47.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX47.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX47.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX47.ForeColor = System.Drawing.Color.Red
        Me.LabelX47.Location = New System.Drawing.Point(235, 71)
        Me.LabelX47.Name = "LabelX47"
        Me.LabelX47.Size = New System.Drawing.Size(307, 23)
        Me.LabelX47.TabIndex = 1719
        Me.LabelX47.Text = "The system will suggest for a deferred income."
        '
        'cbxDeferred_Off
        '
        Me.cbxDeferred_Off.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDeferred_Off.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDeferred_Off.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDeferred_Off.Location = New System.Drawing.Point(189, 72)
        Me.cbxDeferred_Off.Name = "cbxDeferred_Off"
        Me.cbxDeferred_Off.Size = New System.Drawing.Size(51, 23)
        Me.cbxDeferred_Off.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDeferred_Off.TabIndex = 15
        Me.cbxDeferred_Off.Text = "Off"
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
        Me.LabelX45.Location = New System.Drawing.Point(3, 72)
        Me.LabelX45.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX45.Name = "LabelX45"
        Me.LabelX45.Size = New System.Drawing.Size(134, 23)
        Me.LabelX45.TabIndex = 1718
        Me.LabelX45.Text = "Deferred Income :"
        Me.LabelX45.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxDeferred_On
        '
        Me.cbxDeferred_On.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDeferred_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDeferred_On.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDeferred_On.Location = New System.Drawing.Point(143, 72)
        Me.cbxDeferred_On.Name = "cbxDeferred_On"
        Me.cbxDeferred_On.Size = New System.Drawing.Size(51, 23)
        Me.cbxDeferred_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDeferred_On.TabIndex = 1
        Me.cbxDeferred_On.Text = "On"
        '
        'LabelX34
        '
        Me.LabelX34.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX34.ForeColor = System.Drawing.Color.Red
        Me.LabelX34.Location = New System.Drawing.Point(322, 14)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(240, 23)
        Me.LabelX34.TabIndex = 1706
        Me.LabelX34.Text = "Petty Cash Budget."
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
        Me.LabelX33.Location = New System.Drawing.Point(3, 14)
        Me.LabelX33.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(134, 23)
        Me.LabelX33.TabIndex = 101
        Me.LabelX33.Text = "Petty Cash :"
        Me.LabelX33.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dPettyCash
        '
        '
        '
        '
        Me.dPettyCash.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dPettyCash.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dPettyCash.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dPettyCash.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dPettyCash.ForeColor = System.Drawing.Color.Black
        Me.dPettyCash.Increment = 1.0R
        Me.dPettyCash.Location = New System.Drawing.Point(143, 14)
        Me.dPettyCash.MaxValue = 100000000.0R
        Me.dPettyCash.MinValue = 0.0R
        Me.dPettyCash.Name = "dPettyCash"
        Me.dPettyCash.ShowUpDown = True
        Me.dPettyCash.Size = New System.Drawing.Size(173, 23)
        Me.dPettyCash.TabIndex = 5
        '
        'tabFinancial
        '
        Me.tabFinancial.AttachedControl = Me.SuperTabControlPanel5
        Me.tabFinancial.GlobalItem = False
        Me.tabFinancial.Name = "tabFinancial"
        Me.tabFinancial.Text = "Financial"
        Me.tabFinancial.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.btnYard)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX21)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX22)
        Me.SuperTabControlPanel4.Controls.Add(Me.iRedemption)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX18)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX15)
        Me.SuperTabControlPanel4.Controls.Add(Me.iReservation)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX14)
        Me.SuperTabControlPanel4.Controls.Add(Me.cbxOverstay)
        Me.SuperTabControlPanel4.Controls.Add(Me.iOverstay)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX17)
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX16)
        Me.SuperTabControlPanel4.Controls.Add(Me.dTransactionAmount)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 32)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1167, 197)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.tabROPOA
        '
        'btnYard
        '
        Me.btnYard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnYard.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnYard.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYard.Image = Global.FSFC_System.My.Resources.Resources.Add
        Me.btnYard.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnYard.Location = New System.Drawing.Point(143, 135)
        Me.btnYard.Name = "btnYard"
        Me.btnYard.Size = New System.Drawing.Size(107, 30)
        Me.btnYard.TabIndex = 106
        Me.btnYard.Text = "Add Yard"
        '
        'LabelX21
        '
        Me.LabelX21.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX21.Location = New System.Drawing.Point(322, 105)
        Me.LabelX21.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(519, 23)
        Me.LabelX21.TabIndex = 107
        Me.LabelX21.Text = "th Month the system will notify for the ROPOA Real Estate Consolidation."
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
        Me.LabelX22.Location = New System.Drawing.Point(3, 105)
        Me.LabelX22.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(134, 23)
        Me.LabelX22.TabIndex = 106
        Me.LabelX22.Text = "Redemption Month :"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iRedemption
        '
        '
        '
        '
        Me.iRedemption.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iRedemption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iRedemption.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iRedemption.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iRedemption.Location = New System.Drawing.Point(143, 105)
        Me.iRedemption.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iRedemption.MaxValue = 11
        Me.iRedemption.MinValue = 4
        Me.iRedemption.Name = "iRedemption"
        Me.iRedemption.ShowUpDown = True
        Me.iRedemption.Size = New System.Drawing.Size(173, 23)
        Me.iRedemption.TabIndex = 105
        Me.iRedemption.Value = 11
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX18.Location = New System.Drawing.Point(322, 74)
        Me.LabelX18.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(446, 23)
        Me.LabelX18.TabIndex = 104
        Me.LabelX18.Text = "Default Reservation Days. [Reservation Amount is not refundable]"
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
        Me.LabelX15.Location = New System.Drawing.Point(3, 74)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(134, 23)
        Me.LabelX15.TabIndex = 103
        Me.LabelX15.Text = "Reservation Days :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iReservation
        '
        '
        '
        '
        Me.iReservation.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iReservation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iReservation.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iReservation.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iReservation.Location = New System.Drawing.Point(143, 74)
        Me.iReservation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iReservation.MaxValue = 99
        Me.iReservation.MinValue = 0
        Me.iReservation.Name = "iReservation"
        Me.iReservation.ShowUpDown = True
        Me.iReservation.Size = New System.Drawing.Size(173, 23)
        Me.iReservation.TabIndex = 100
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
        Me.LabelX14.Location = New System.Drawing.Point(3, 14)
        Me.LabelX14.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(134, 23)
        Me.LabelX14.TabIndex = 101
        Me.LabelX14.Text = "No. of Months :"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxOverstay
        '
        Me.cbxOverstay.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxOverstay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxOverstay.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOverstay.Location = New System.Drawing.Point(322, 14)
        Me.cbxOverstay.Name = "cbxOverstay"
        Me.cbxOverstay.Size = New System.Drawing.Size(419, 23)
        Me.cbxOverstay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxOverstay.TabIndex = 91
        Me.cbxOverstay.Text = "System will notify units with beyond stay period (for VE only)."
        '
        'iOverstay
        '
        '
        '
        '
        Me.iOverstay.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iOverstay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iOverstay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iOverstay.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iOverstay.Location = New System.Drawing.Point(143, 14)
        Me.iOverstay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iOverstay.MaxValue = 99
        Me.iOverstay.MinValue = 0
        Me.iOverstay.Name = "iOverstay"
        Me.iOverstay.ShowUpDown = True
        Me.iOverstay.Size = New System.Drawing.Size(173, 23)
        Me.iOverstay.TabIndex = 90
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(322, 44)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(446, 23)
        Me.LabelX17.TabIndex = 100
        Me.LabelX17.Text = "Transaction Amount and above that needs approval to BM/OIC."
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
        Me.LabelX16.Location = New System.Drawing.Point(3, 44)
        Me.LabelX16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(134, 23)
        Me.LabelX16.TabIndex = 99
        Me.LabelX16.Text = "Transaction Amount :"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dTransactionAmount
        '
        '
        '
        '
        Me.dTransactionAmount.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTransactionAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTransactionAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTransactionAmount.Enabled = False
        Me.dTransactionAmount.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dTransactionAmount.ForeColor = System.Drawing.Color.Black
        Me.dTransactionAmount.Increment = 1.0R
        Me.dTransactionAmount.Location = New System.Drawing.Point(143, 44)
        Me.dTransactionAmount.MaxValue = 100000000.0R
        Me.dTransactionAmount.MinValue = 0.0R
        Me.dTransactionAmount.Name = "dTransactionAmount"
        Me.dTransactionAmount.ShowUpDown = True
        Me.dTransactionAmount.Size = New System.Drawing.Size(173, 23)
        Me.dTransactionAmount.TabIndex = 95
        '
        'tabROPOA
        '
        Me.tabROPOA.AttachedControl = Me.SuperTabControlPanel4
        Me.tabROPOA.GlobalItem = False
        Me.tabROPOA.Name = "tabROPOA"
        Me.tabROPOA.Text = "ROPA"
        Me.tabROPOA.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'PanelEx10
        '
        Me.PanelEx10.AutoScroll = True
        Me.PanelEx10.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx10.Controls.Add(Me.cbxBranchCode)
        Me.PanelEx10.Controls.Add(Me.cbxMicrofinance)
        Me.PanelEx10.Controls.Add(Me.LabelX42)
        Me.PanelEx10.Controls.Add(Me.cbxAddress)
        Me.PanelEx10.Controls.Add(Me.txtTIN)
        Me.PanelEx10.Controls.Add(Me.LabelX37)
        Me.PanelEx10.Controls.Add(Me.txtPath)
        Me.PanelEx10.Controls.Add(Me.btnBrowse)
        Me.PanelEx10.Controls.Add(Me.pb_Location)
        Me.PanelEx10.Controls.Add(Me.txtEmailAddress)
        Me.PanelEx10.Controls.Add(Me.LabelX9)
        Me.PanelEx10.Controls.Add(Me.txtContactN3)
        Me.PanelEx10.Controls.Add(Me.LabelX8)
        Me.PanelEx10.Controls.Add(Me.txtContactN2)
        Me.PanelEx10.Controls.Add(Me.LabelX7)
        Me.PanelEx10.Controls.Add(Me.txtContactN1)
        Me.PanelEx10.Controls.Add(Me.LabelX6)
        Me.PanelEx10.Controls.Add(Me.txtAddress)
        Me.PanelEx10.Controls.Add(Me.LabelX5)
        Me.PanelEx10.Controls.Add(Me.cbxNA)
        Me.PanelEx10.Controls.Add(Me.dtpOpened)
        Me.PanelEx10.Controls.Add(Me.LabelX3)
        Me.PanelEx10.Controls.Add(Me.txtBranchID)
        Me.PanelEx10.Controls.Add(Me.LabelX2)
        Me.PanelEx10.Controls.Add(Me.txtBranchCode)
        Me.PanelEx10.Controls.Add(Me.LabelX1)
        Me.PanelEx10.Controls.Add(Me.txtBranch)
        Me.PanelEx10.Controls.Add(Me.LabelX155)
        Me.PanelEx10.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx10.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx10.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PanelEx10.Name = "PanelEx10"
        Me.PanelEx10.Size = New System.Drawing.Size(1167, 340)
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
        'cbxBranchCode
        '
        Me.cbxBranchCode.DisplayMember = "CITY"
        Me.cbxBranchCode.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranchCode.FormattingEnabled = True
        Me.cbxBranchCode.Location = New System.Drawing.Point(531, 73)
        Me.cbxBranchCode.MaxLength = 100
        Me.cbxBranchCode.Name = "cbxBranchCode"
        Me.cbxBranchCode.Size = New System.Drawing.Size(146, 25)
        Me.cbxBranchCode.TabIndex = 17
        Me.cbxBranchCode.ValueMember = "ID"
        Me.cbxBranchCode.Visible = False
        '
        'cbxMicrofinance
        '
        Me.cbxMicrofinance.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxMicrofinance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMicrofinance.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMicrofinance.Location = New System.Drawing.Point(414, 74)
        Me.cbxMicrofinance.Name = "cbxMicrofinance"
        Me.cbxMicrofinance.Size = New System.Drawing.Size(112, 23)
        Me.cbxMicrofinance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMicrofinance.TabIndex = 16
        Me.cbxMicrofinance.Text = "Micro Finance"
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
        Me.LabelX42.Location = New System.Drawing.Point(12, 161)
        Me.LabelX42.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX42.Name = "LabelX42"
        Me.LabelX42.Size = New System.Drawing.Size(147, 23)
        Me.LabelX42.TabIndex = 105
        Me.LabelX42.Text = "City/Province/Region :"
        Me.LabelX42.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxAddress
        '
        Me.cbxAddress.DisplayMember = "CITY"
        Me.cbxAddress.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAddress.FormattingEnabled = True
        Me.cbxAddress.Location = New System.Drawing.Point(165, 161)
        Me.cbxAddress.MaxLength = 100
        Me.cbxAddress.Name = "cbxAddress"
        Me.cbxAddress.Size = New System.Drawing.Size(512, 25)
        Me.cbxAddress.TabIndex = 41
        Me.cbxAddress.ValueMember = "ID"
        '
        'txtTIN
        '
        '
        '
        '
        Me.txtTIN.Border.Class = "TextBoxBorder"
        Me.txtTIN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTIN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(165, 103)
        Me.txtTIN.MaxLength = 15
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.PreventEnterBeep = True
        Me.txtTIN.Size = New System.Drawing.Size(243, 23)
        Me.txtTIN.TabIndex = 16
        Me.txtTIN.WatermarkText = "TIN"
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
        Me.LabelX37.Location = New System.Drawing.Point(12, 103)
        Me.LabelX37.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(147, 23)
        Me.LabelX37.TabIndex = 103
        Me.LabelX37.Text = "TIN :"
        Me.LabelX37.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtPath
        '
        '
        '
        '
        Me.txtPath.Border.Class = "TextBoxBorder"
        Me.txtPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPath.Enabled = False
        Me.txtPath.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.Location = New System.Drawing.Point(691, 306)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.PreventEnterBeep = True
        Me.txtPath.Size = New System.Drawing.Size(384, 23)
        Me.txtPath.TabIndex = 80
        Me.txtPath.WatermarkText = "Please attach a printscreen google map location."
        '
        'btnBrowse
        '
        Me.btnBrowse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBrowse.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnBrowse.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(1081, 306)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(71, 23)
        Me.btnBrowse.TabIndex = 85
        Me.btnBrowse.Text = "Browse"
        '
        'pb_Location
        '
        Me.pb_Location.EditValue = CType(resources.GetObject("pb_Location.EditValue"), Object)
        Me.pb_Location.Location = New System.Drawing.Point(691, 16)
        Me.pb_Location.Name = "pb_Location"
        Me.pb_Location.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.pb_Location.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.pb_Location.Properties.Appearance.Options.UseBackColor = True
        Me.pb_Location.Properties.Appearance.Options.UseFont = True
        Me.pb_Location.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pb_Location.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_Location.Size = New System.Drawing.Size(461, 284)
        Me.pb_Location.TabIndex = 75
        '
        'txtEmailAddress
        '
        '
        '
        '
        Me.txtEmailAddress.Border.Class = "TextBoxBorder"
        Me.txtEmailAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEmailAddress.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.Location = New System.Drawing.Point(165, 279)
        Me.txtEmailAddress.MaxLength = 50
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.PreventEnterBeep = True
        Me.txtEmailAddress.Size = New System.Drawing.Size(243, 23)
        Me.txtEmailAddress.TabIndex = 60
        Me.txtEmailAddress.WatermarkText = "Email Address"
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
        Me.LabelX9.Location = New System.Drawing.Point(12, 279)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(147, 23)
        Me.LabelX9.TabIndex = 98
        Me.LabelX9.Text = "Email Address :"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtContactN3
        '
        '
        '
        '
        Me.txtContactN3.Border.Class = "TextBoxBorder"
        Me.txtContactN3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContactN3.Enabled = False
        Me.txtContactN3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactN3.Location = New System.Drawing.Point(165, 250)
        Me.txtContactN3.MaxLength = 50
        Me.txtContactN3.Name = "txtContactN3"
        Me.txtContactN3.PreventEnterBeep = True
        Me.txtContactN3.Size = New System.Drawing.Size(243, 23)
        Me.txtContactN3.TabIndex = 55
        Me.txtContactN3.WatermarkText = "Telephone or Mobile number 3"
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
        Me.LabelX8.Location = New System.Drawing.Point(12, 250)
        Me.LabelX8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(147, 23)
        Me.LabelX8.TabIndex = 96
        Me.LabelX8.Text = "Contact Number 3 :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtContactN2
        '
        '
        '
        '
        Me.txtContactN2.Border.Class = "TextBoxBorder"
        Me.txtContactN2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContactN2.Enabled = False
        Me.txtContactN2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactN2.Location = New System.Drawing.Point(165, 221)
        Me.txtContactN2.MaxLength = 50
        Me.txtContactN2.Name = "txtContactN2"
        Me.txtContactN2.PreventEnterBeep = True
        Me.txtContactN2.Size = New System.Drawing.Size(243, 23)
        Me.txtContactN2.TabIndex = 50
        Me.txtContactN2.WatermarkText = "Telephone or Mobile number 2"
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
        Me.LabelX7.Location = New System.Drawing.Point(12, 221)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(147, 23)
        Me.LabelX7.TabIndex = 94
        Me.LabelX7.Text = "Contact Number 2 :"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtContactN1
        '
        '
        '
        '
        Me.txtContactN1.Border.Class = "TextBoxBorder"
        Me.txtContactN1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContactN1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactN1.Location = New System.Drawing.Point(165, 192)
        Me.txtContactN1.MaxLength = 50
        Me.txtContactN1.Name = "txtContactN1"
        Me.txtContactN1.PreventEnterBeep = True
        Me.txtContactN1.Size = New System.Drawing.Size(243, 23)
        Me.txtContactN1.TabIndex = 45
        Me.txtContactN1.WatermarkText = "Telephone or Mobile number 1"
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
        Me.LabelX6.Location = New System.Drawing.Point(12, 192)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(147, 23)
        Me.LabelX6.TabIndex = 92
        Me.LabelX6.Text = "Contact Number 1 :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtAddress
        '
        '
        '
        '
        Me.txtAddress.Border.Class = "TextBoxBorder"
        Me.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAddress.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(165, 132)
        Me.txtAddress.MaxLength = 255
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.PreventEnterBeep = True
        Me.txtAddress.Size = New System.Drawing.Size(512, 23)
        Me.txtAddress.TabIndex = 40
        Me.txtAddress.WatermarkText = "Address"
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
        Me.LabelX5.Location = New System.Drawing.Point(12, 132)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(147, 23)
        Me.LabelX5.TabIndex = 90
        Me.LabelX5.Text = "Address :"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxNA
        '
        Me.cbxNA.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxNA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxNA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxNA.Location = New System.Drawing.Point(344, 308)
        Me.cbxNA.Name = "cbxNA"
        Me.cbxNA.Size = New System.Drawing.Size(64, 23)
        Me.cbxNA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxNA.TabIndex = 70
        Me.cbxNA.Text = "NA"
        '
        'dtpOpened
        '
        '
        '
        '
        Me.dtpOpened.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpOpened.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpOpened.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpOpened.ButtonDropDown.Visible = True
        Me.dtpOpened.CustomFormat = "MMMM dd, yyyy"
        Me.dtpOpened.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpOpened.ForeColor = System.Drawing.Color.Black
        Me.dtpOpened.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpOpened.IsPopupCalendarOpen = False
        Me.dtpOpened.Location = New System.Drawing.Point(165, 308)
        '
        '
        '
        Me.dtpOpened.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpOpened.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpOpened.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpOpened.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpOpened.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpOpened.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpOpened.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpOpened.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpOpened.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpOpened.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpOpened.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpOpened.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpOpened.MonthCalendar.TodayButtonVisible = True
        Me.dtpOpened.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpOpened.Name = "dtpOpened"
        Me.dtpOpened.Size = New System.Drawing.Size(173, 23)
        Me.dtpOpened.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpOpened.TabIndex = 65
        Me.dtpOpened.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
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
        Me.LabelX3.Location = New System.Drawing.Point(12, 308)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(147, 23)
        Me.LabelX3.TabIndex = 82
        Me.LabelX3.Text = "Date Opened :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtBranchID
        '
        '
        '
        '
        Me.txtBranchID.Border.Class = "TextBoxBorder"
        Me.txtBranchID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBranchID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBranchID.Enabled = False
        Me.txtBranchID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchID.Location = New System.Drawing.Point(165, 74)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.PreventEnterBeep = True
        Me.txtBranchID.Size = New System.Drawing.Size(243, 23)
        Me.txtBranchID.TabIndex = 15
        Me.txtBranchID.WatermarkText = "eg. 005"
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
        Me.LabelX2.Location = New System.Drawing.Point(12, 74)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(147, 23)
        Me.LabelX2.TabIndex = 81
        Me.LabelX2.Text = "Branch ID :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtBranchCode
        '
        '
        '
        '
        Me.txtBranchCode.Border.Class = "TextBoxBorder"
        Me.txtBranchCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBranchCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBranchCode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCode.Location = New System.Drawing.Point(165, 45)
        Me.txtBranchCode.MaxLength = 6
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.PreventEnterBeep = True
        Me.txtBranchCode.Size = New System.Drawing.Size(243, 23)
        Me.txtBranchCode.TabIndex = 10
        Me.txtBranchCode.WatermarkText = "eg. CEB"
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
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(147, 23)
        Me.LabelX1.TabIndex = 79
        Me.LabelX1.Text = "Branch Code :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtBranch
        '
        '
        '
        '
        Me.txtBranch.Border.Class = "TextBoxBorder"
        Me.txtBranch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBranch.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(165, 16)
        Me.txtBranch.MaxLength = 50
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.PreventEnterBeep = True
        Me.txtBranch.Size = New System.Drawing.Size(512, 23)
        Me.txtBranch.TabIndex = 5
        Me.txtBranch.WatermarkText = "eg. CEBU"
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX155.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX155.Location = New System.Drawing.Point(12, 16)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(147, 23)
        Me.LabelX155.TabIndex = 77
        Me.LabelX155.Text = "Branch :"
        Me.LabelX155.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tabBranch
        '
        Me.tabBranch.AttachedControl = Me.SuperTabControlPanel1
        Me.tabBranch.GlobalItem = False
        Me.tabBranch.Name = "tabBranch"
        Me.tabBranch.Text = "Branch Setup"
        Me.tabBranch.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = True
        Me.SuperTabControlPanel2.Controls.Add(Me.GridControl1)
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
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl1.TabIndex = 1677
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn13, Me.GridColumn27, Me.GridColumn26, Me.GridColumn33, Me.GridColumn6, Me.GridColumn37, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn12, Me.GridColumn11, Me.GridColumn14, Me.GridColumn15, Me.GridColumn19, Me.GridColumn29, Me.GridColumn28, Me.GridColumn22, Me.GridColumn16, Me.GridColumn18, Me.GridColumn17, Me.GridColumn20, Me.GridColumn21, Me.GridColumn30, Me.GridColumn87, Me.GridColumn40, Me.GridColumn42, Me.GridColumn31, Me.GridColumn32, Me.GridColumn41, Me.GridColumn85, Me.GridColumn86, Me.GridColumn89, Me.GridColumn38, Me.GridColumn39, Me.GridColumn90, Me.GridColumn25, Me.GridColumn36, Me.GridColumn91, Me.GridColumn24, Me.GridColumn35, Me.GridColumn92, Me.GridColumn23, Me.GridColumn34})
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
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Branch"
        Me.GridColumn2.FieldName = "Branch"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 150
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Branch Code"
        Me.GridColumn3.FieldName = "Branch Code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 105
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Branch ID"
        Me.GridColumn4.FieldName = "Branch ID"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 100
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Branch Manager"
        Me.GridColumn5.FieldName = "Branch Manager"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 200
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Officer In-Charge"
        Me.GridColumn13.FieldName = "Officer In-Charge"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn13.Width = 200
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "District Manager"
        Me.GridColumn27.FieldName = "District Manager"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn27.Width = 200
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Regional Manager"
        Me.GridColumn26.FieldName = "Regional Manager"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn26.Width = 200
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "TIN"
        Me.GridColumn33.FieldName = "TIN"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 4
        Me.GridColumn33.Width = 100
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Address"
        Me.GridColumn6.FieldName = "Address"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 400
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "City/Province/Region"
        Me.GridColumn37.FieldName = "City/Province/Region"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 6
        Me.GridColumn37.Width = 400
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Contact Num 1"
        Me.GridColumn7.FieldName = "Contact Num 1"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 7
        Me.GridColumn7.Width = 125
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Contact Num 2"
        Me.GridColumn8.FieldName = "Contact Num 2"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 8
        Me.GridColumn8.Width = 125
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Contact Num 3"
        Me.GridColumn9.FieldName = "Contact Num 3"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 9
        Me.GridColumn9.Width = 125
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Email Address"
        Me.GridColumn10.FieldName = "Email Address"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 10
        Me.GridColumn10.Width = 250
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Date Opened"
        Me.GridColumn12.FieldName = "Date Opened"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 11
        Me.GridColumn12.Width = 135
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.Caption = "RPPD"
        Me.GridColumn11.FieldName = "RPPD"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 12
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "RPPD Start"
        Me.GridColumn14.FieldName = "RPPD Start"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 13
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "Round Up"
        Me.GridColumn15.FieldName = "Round Up"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 14
        Me.GridColumn15.Width = 80
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.Caption = "Penalty"
        Me.GridColumn19.FieldName = "Penalty"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 15
        Me.GridColumn19.Width = 100
        '
        'GridColumn29
        '
        Me.GridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn29.Caption = "Availed RPPD"
        Me.GridColumn29.FieldName = "Availed RPPD"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 16
        Me.GridColumn29.Width = 125
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.Caption = "Availed Penalty"
        Me.GridColumn28.FieldName = "Availed Penalty"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 17
        Me.GridColumn28.Width = 125
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Email Address"
        Me.GridColumn22.FieldName = "Email"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 18
        Me.GridColumn22.Width = 250
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.Caption = "Overstayed Months"
        Me.GridColumn16.FieldName = "Overstayed Months"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 19
        Me.GridColumn16.Width = 100
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.Caption = "Overstayed"
        Me.GridColumn18.FieldName = "Overstayed"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 20
        Me.GridColumn18.Width = 100
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "Transaction Amount"
        Me.GridColumn17.DisplayFormat.FormatString = "n2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "Transaction Amount"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 21
        Me.GridColumn17.Width = 100
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn20.Caption = "Reserved Days"
        Me.GridColumn20.FieldName = "Reserved Days"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 22
        Me.GridColumn20.Width = 100
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn21.Caption = "Redemption"
        Me.GridColumn21.FieldName = "Redemption"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 23
        Me.GridColumn21.Width = 100
        '
        'GridColumn30
        '
        Me.GridColumn30.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn30.Caption = "Petty Cash"
        Me.GridColumn30.DisplayFormat.FormatString = "n2"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "Petty Cash"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 24
        Me.GridColumn30.Width = 100
        '
        'GridColumn87
        '
        Me.GridColumn87.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn87.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn87.Caption = "Allow From Other Branch"
        Me.GridColumn87.FieldName = "Allow From Other Branch"
        Me.GridColumn87.Name = "GridColumn87"
        Me.GridColumn87.Visible = True
        Me.GridColumn87.VisibleIndex = 25
        Me.GridColumn87.Width = 125
        '
        'GridColumn40
        '
        Me.GridColumn40.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn40.Caption = "Deferred Income"
        Me.GridColumn40.FieldName = "Deferred Income"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 26
        Me.GridColumn40.Width = 125
        '
        'GridColumn42
        '
        Me.GridColumn42.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn42.Caption = "Advance on Principal"
        Me.GridColumn42.FieldName = "Advance on Principal"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 27
        Me.GridColumn42.Width = 125
        '
        'GridColumn31
        '
        Me.GridColumn31.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn31.Caption = "SMS Notification"
        Me.GridColumn31.FieldName = "SMS Notification"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 28
        Me.GridColumn31.Width = 125
        '
        'GridColumn32
        '
        Me.GridColumn32.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn32.Caption = "Email Notification"
        Me.GridColumn32.FieldName = "Email Notification"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 29
        Me.GridColumn32.Width = 125
        '
        'GridColumn41
        '
        Me.GridColumn41.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn41.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn41.Caption = "Auto Notification"
        Me.GridColumn41.FieldName = "Auto Notification"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 30
        Me.GridColumn41.Width = 125
        '
        'GridColumn85
        '
        Me.GridColumn85.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn85.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn85.Caption = "Use other Bank"
        Me.GridColumn85.FieldName = "Use other Bank"
        Me.GridColumn85.Name = "GridColumn85"
        Me.GridColumn85.Visible = True
        Me.GridColumn85.VisibleIndex = 31
        Me.GridColumn85.Width = 125
        '
        'GridColumn86
        '
        Me.GridColumn86.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn86.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn86.Caption = "Branch Bank"
        Me.GridColumn86.FieldName = "Branch Bank"
        Me.GridColumn86.Name = "GridColumn86"
        Me.GridColumn86.Visible = True
        Me.GridColumn86.VisibleIndex = 32
        Me.GridColumn86.Width = 125
        '
        'GridColumn89
        '
        Me.GridColumn89.Caption = "Approver 1"
        Me.GridColumn89.FieldName = "Approver 1"
        Me.GridColumn89.Name = "GridColumn89"
        Me.GridColumn89.Visible = True
        Me.GridColumn89.VisibleIndex = 33
        Me.GridColumn89.Width = 175
        '
        'GridColumn38
        '
        Me.GridColumn38.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn38.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn38.Caption = "Credit Application"
        Me.GridColumn38.DisplayFormat.FormatString = "n2"
        Me.GridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn38.FieldName = "OIC Override"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 34
        Me.GridColumn38.Width = 125
        '
        'GridColumn39
        '
        Me.GridColumn39.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn39.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn39.Caption = "Cash Advance"
        Me.GridColumn39.DisplayFormat.FormatString = "n2"
        Me.GridColumn39.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn39.FieldName = "OIC CA"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 35
        Me.GridColumn39.Width = 125
        '
        'GridColumn90
        '
        Me.GridColumn90.Caption = "Approver 2"
        Me.GridColumn90.FieldName = "Approver 2"
        Me.GridColumn90.Name = "GridColumn90"
        Me.GridColumn90.Visible = True
        Me.GridColumn90.VisibleIndex = 36
        Me.GridColumn90.Width = 175
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.Caption = "Credit Application"
        Me.GridColumn25.DisplayFormat.FormatString = "n2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "BM Override"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 37
        Me.GridColumn25.Width = 125
        '
        'GridColumn36
        '
        Me.GridColumn36.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn36.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn36.Caption = "Cash Advance"
        Me.GridColumn36.DisplayFormat.FormatString = "n2"
        Me.GridColumn36.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn36.FieldName = "BM CA"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 38
        Me.GridColumn36.Width = 125
        '
        'GridColumn91
        '
        Me.GridColumn91.Caption = "Approver 3"
        Me.GridColumn91.FieldName = "Approver 3"
        Me.GridColumn91.Name = "GridColumn91"
        Me.GridColumn91.Visible = True
        Me.GridColumn91.VisibleIndex = 39
        Me.GridColumn91.Width = 175
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.Caption = "Credit Application"
        Me.GridColumn24.DisplayFormat.FormatString = "n2"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "DM Override"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 40
        Me.GridColumn24.Width = 125
        '
        'GridColumn35
        '
        Me.GridColumn35.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn35.Caption = "Cash Advance"
        Me.GridColumn35.DisplayFormat.FormatString = "n2"
        Me.GridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn35.FieldName = "BM CA"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 41
        Me.GridColumn35.Width = 125
        '
        'GridColumn92
        '
        Me.GridColumn92.Caption = "Approver 4"
        Me.GridColumn92.FieldName = "Approver 4"
        Me.GridColumn92.Name = "GridColumn92"
        Me.GridColumn92.Visible = True
        Me.GridColumn92.VisibleIndex = 42
        Me.GridColumn92.Width = 175
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "Credit Application"
        Me.GridColumn23.DisplayFormat.FormatString = "n2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "RM Override"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 43
        Me.GridColumn23.Width = 125
        '
        'GridColumn34
        '
        Me.GridColumn34.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn34.Caption = "Cash Advance"
        Me.GridColumn34.DisplayFormat.FormatString = "n2"
        Me.GridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn34.FieldName = "RM CA"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 44
        Me.GridColumn34.Width = 125
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
        'tabList
        '
        Me.tabList.AttachedControl = Me.SuperTabControlPanel2
        Me.tabList.GlobalItem = False
        Me.tabList.Name = "tabList"
        Me.tabList.Text = "Branch List"
        Me.tabList.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.GridControl2)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.tabMicroBranch
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl2.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl2.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GridControl2.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl2.TabIndex = 1678
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
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn70, Me.GridColumn71, Me.GridColumn72, Me.GridColumn73, Me.GridColumn74, Me.GridColumn75, Me.GridColumn88, Me.GridColumn76, Me.GridColumn77, Me.GridColumn82, Me.GridColumn83, Me.GridColumn84, Me.GridColumn93, Me.GridColumn66, Me.GridColumn78, Me.GridColumn94, Me.GridColumn67, Me.GridColumn79, Me.GridColumn95, Me.GridColumn68, Me.GridColumn80, Me.GridColumn96, Me.GridColumn69, Me.GridColumn81})
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
        'GridColumn43
        '
        Me.GridColumn43.Caption = "ID"
        Me.GridColumn43.FieldName = "ID"
        Me.GridColumn43.Name = "GridColumn43"
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Branch"
        Me.GridColumn44.FieldName = "Branch"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 0
        Me.GridColumn44.Width = 150
        '
        'GridColumn45
        '
        Me.GridColumn45.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn45.Caption = "Branch Code"
        Me.GridColumn45.FieldName = "Branch Code"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 1
        Me.GridColumn45.Width = 105
        '
        'GridColumn46
        '
        Me.GridColumn46.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn46.Caption = "Branch ID"
        Me.GridColumn46.FieldName = "Branch ID"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 2
        Me.GridColumn46.Width = 100
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Branch Manager"
        Me.GridColumn47.FieldName = "Branch Manager"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 3
        Me.GridColumn47.Width = 200
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Officer In-Charge"
        Me.GridColumn48.FieldName = "Officer In-Charge"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn48.Width = 200
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "District Manager"
        Me.GridColumn49.FieldName = "District Manager"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn49.Width = 200
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Regional Manager"
        Me.GridColumn50.FieldName = "Regional Manager"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn50.Width = 200
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "TIN"
        Me.GridColumn51.FieldName = "TIN"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 4
        Me.GridColumn51.Width = 100
        '
        'GridColumn52
        '
        Me.GridColumn52.Caption = "Address"
        Me.GridColumn52.FieldName = "Address"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 5
        Me.GridColumn52.Width = 400
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "City/Province/Region"
        Me.GridColumn53.FieldName = "City/Province/Region"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 6
        Me.GridColumn53.Width = 400
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "Contact Num 1"
        Me.GridColumn54.FieldName = "Contact Num 1"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 7
        Me.GridColumn54.Width = 125
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Contact Num 2"
        Me.GridColumn55.FieldName = "Contact Num 2"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 8
        Me.GridColumn55.Width = 125
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "Contact Num 3"
        Me.GridColumn56.FieldName = "Contact Num 3"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 9
        Me.GridColumn56.Width = 125
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "Email Address"
        Me.GridColumn57.FieldName = "Email Address"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 10
        Me.GridColumn57.Width = 250
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "Date Opened"
        Me.GridColumn58.FieldName = "Date Opened"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 11
        Me.GridColumn58.Width = 135
        '
        'GridColumn59
        '
        Me.GridColumn59.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn59.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn59.Caption = "RPPD"
        Me.GridColumn59.FieldName = "RPPD"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 12
        '
        'GridColumn60
        '
        Me.GridColumn60.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn60.Caption = "RPPD Start"
        Me.GridColumn60.FieldName = "RPPD Start"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 13
        '
        'GridColumn61
        '
        Me.GridColumn61.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn61.Caption = "Round Up"
        Me.GridColumn61.FieldName = "Round Up"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 14
        Me.GridColumn61.Width = 80
        '
        'GridColumn62
        '
        Me.GridColumn62.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn62.Caption = "Penalty"
        Me.GridColumn62.FieldName = "Penalty"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn62.Visible = True
        Me.GridColumn62.VisibleIndex = 15
        Me.GridColumn62.Width = 100
        '
        'GridColumn63
        '
        Me.GridColumn63.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn63.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn63.Caption = "Availed RPPD"
        Me.GridColumn63.FieldName = "Availed RPPD"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 16
        Me.GridColumn63.Width = 125
        '
        'GridColumn64
        '
        Me.GridColumn64.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn64.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn64.Caption = "Availed Penalty"
        Me.GridColumn64.FieldName = "Availed Penalty"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 17
        Me.GridColumn64.Width = 125
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "Email Address"
        Me.GridColumn65.FieldName = "Email"
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn65.Visible = True
        Me.GridColumn65.VisibleIndex = 18
        Me.GridColumn65.Width = 250
        '
        'GridColumn70
        '
        Me.GridColumn70.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn70.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn70.Caption = "Overstayed Months"
        Me.GridColumn70.FieldName = "Overstayed Months"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 19
        Me.GridColumn70.Width = 100
        '
        'GridColumn71
        '
        Me.GridColumn71.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn71.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn71.Caption = "Overstayed"
        Me.GridColumn71.FieldName = "Overstayed"
        Me.GridColumn71.Name = "GridColumn71"
        Me.GridColumn71.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn71.Visible = True
        Me.GridColumn71.VisibleIndex = 20
        Me.GridColumn71.Width = 100
        '
        'GridColumn72
        '
        Me.GridColumn72.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn72.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn72.Caption = "Transaction Amount"
        Me.GridColumn72.DisplayFormat.FormatString = "n2"
        Me.GridColumn72.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn72.FieldName = "Transaction Amount"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 21
        Me.GridColumn72.Width = 100
        '
        'GridColumn73
        '
        Me.GridColumn73.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn73.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn73.Caption = "Reserved Days"
        Me.GridColumn73.FieldName = "Reserved Days"
        Me.GridColumn73.Name = "GridColumn73"
        Me.GridColumn73.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn73.Visible = True
        Me.GridColumn73.VisibleIndex = 22
        Me.GridColumn73.Width = 100
        '
        'GridColumn74
        '
        Me.GridColumn74.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn74.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn74.Caption = "Redemption"
        Me.GridColumn74.FieldName = "Redemption"
        Me.GridColumn74.Name = "GridColumn74"
        Me.GridColumn74.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn74.Visible = True
        Me.GridColumn74.VisibleIndex = 23
        Me.GridColumn74.Width = 100
        '
        'GridColumn75
        '
        Me.GridColumn75.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn75.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn75.Caption = "Petty Cash"
        Me.GridColumn75.DisplayFormat.FormatString = "n2"
        Me.GridColumn75.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn75.FieldName = "Petty Cash"
        Me.GridColumn75.Name = "GridColumn75"
        Me.GridColumn75.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn75.Visible = True
        Me.GridColumn75.VisibleIndex = 24
        Me.GridColumn75.Width = 100
        '
        'GridColumn88
        '
        Me.GridColumn88.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn88.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn88.Caption = "Allow From Other Branch"
        Me.GridColumn88.FieldName = "Allow From Other Branch"
        Me.GridColumn88.Name = "GridColumn88"
        Me.GridColumn88.Visible = True
        Me.GridColumn88.VisibleIndex = 25
        Me.GridColumn88.Width = 125
        '
        'GridColumn76
        '
        Me.GridColumn76.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn76.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn76.Caption = "Deferred Income"
        Me.GridColumn76.FieldName = "Deferred Income"
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn76.Visible = True
        Me.GridColumn76.VisibleIndex = 26
        Me.GridColumn76.Width = 125
        '
        'GridColumn77
        '
        Me.GridColumn77.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn77.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn77.Caption = "Advance on Principal"
        Me.GridColumn77.FieldName = "Advance on Principal"
        Me.GridColumn77.Name = "GridColumn77"
        Me.GridColumn77.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn77.Visible = True
        Me.GridColumn77.VisibleIndex = 27
        Me.GridColumn77.Width = 125
        '
        'GridColumn82
        '
        Me.GridColumn82.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn82.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn82.Caption = "SMS Notification"
        Me.GridColumn82.FieldName = "SMS Notification"
        Me.GridColumn82.Name = "GridColumn82"
        Me.GridColumn82.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn82.Visible = True
        Me.GridColumn82.VisibleIndex = 28
        Me.GridColumn82.Width = 125
        '
        'GridColumn83
        '
        Me.GridColumn83.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn83.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn83.Caption = "Email Notification"
        Me.GridColumn83.FieldName = "Email Notification"
        Me.GridColumn83.Name = "GridColumn83"
        Me.GridColumn83.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn83.Visible = True
        Me.GridColumn83.VisibleIndex = 29
        Me.GridColumn83.Width = 125
        '
        'GridColumn84
        '
        Me.GridColumn84.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn84.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn84.Caption = "Auto Notification"
        Me.GridColumn84.FieldName = "Auto Notification"
        Me.GridColumn84.Name = "GridColumn84"
        Me.GridColumn84.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn84.Visible = True
        Me.GridColumn84.VisibleIndex = 30
        Me.GridColumn84.Width = 125
        '
        'GridColumn93
        '
        Me.GridColumn93.Caption = "Approver 1"
        Me.GridColumn93.FieldName = "Approver 1"
        Me.GridColumn93.Name = "GridColumn93"
        Me.GridColumn93.Visible = True
        Me.GridColumn93.VisibleIndex = 31
        Me.GridColumn93.Width = 175
        '
        'GridColumn66
        '
        Me.GridColumn66.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn66.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn66.Caption = "Credit Application"
        Me.GridColumn66.DisplayFormat.FormatString = "n2"
        Me.GridColumn66.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn66.FieldName = "OIC Override"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 32
        Me.GridColumn66.Width = 125
        '
        'GridColumn78
        '
        Me.GridColumn78.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn78.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn78.Caption = "Cash Advance"
        Me.GridColumn78.DisplayFormat.FormatString = "n2"
        Me.GridColumn78.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn78.FieldName = "OIC CA"
        Me.GridColumn78.Name = "GridColumn78"
        Me.GridColumn78.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn78.Visible = True
        Me.GridColumn78.VisibleIndex = 33
        Me.GridColumn78.Width = 125
        '
        'GridColumn94
        '
        Me.GridColumn94.Caption = "Approver 2"
        Me.GridColumn94.FieldName = "Approver 2"
        Me.GridColumn94.Name = "GridColumn94"
        Me.GridColumn94.Visible = True
        Me.GridColumn94.VisibleIndex = 34
        Me.GridColumn94.Width = 175
        '
        'GridColumn67
        '
        Me.GridColumn67.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn67.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn67.Caption = "Credit Application"
        Me.GridColumn67.DisplayFormat.FormatString = "n2"
        Me.GridColumn67.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn67.FieldName = "BM Override"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn67.Visible = True
        Me.GridColumn67.VisibleIndex = 35
        Me.GridColumn67.Width = 125
        '
        'GridColumn79
        '
        Me.GridColumn79.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn79.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn79.Caption = "Cash Advance"
        Me.GridColumn79.DisplayFormat.FormatString = "n2"
        Me.GridColumn79.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn79.FieldName = "BM CA"
        Me.GridColumn79.Name = "GridColumn79"
        Me.GridColumn79.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn79.Visible = True
        Me.GridColumn79.VisibleIndex = 36
        Me.GridColumn79.Width = 125
        '
        'GridColumn95
        '
        Me.GridColumn95.Caption = "Approver 3"
        Me.GridColumn95.FieldName = "Approver 3"
        Me.GridColumn95.Name = "GridColumn95"
        Me.GridColumn95.Visible = True
        Me.GridColumn95.VisibleIndex = 37
        Me.GridColumn95.Width = 175
        '
        'GridColumn68
        '
        Me.GridColumn68.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn68.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn68.Caption = "Credit Application"
        Me.GridColumn68.DisplayFormat.FormatString = "n2"
        Me.GridColumn68.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn68.FieldName = "DM Override"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 38
        Me.GridColumn68.Width = 125
        '
        'GridColumn80
        '
        Me.GridColumn80.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn80.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn80.Caption = "Cash Advance"
        Me.GridColumn80.DisplayFormat.FormatString = "n2"
        Me.GridColumn80.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn80.FieldName = "BM CA"
        Me.GridColumn80.Name = "GridColumn80"
        Me.GridColumn80.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn80.Visible = True
        Me.GridColumn80.VisibleIndex = 39
        Me.GridColumn80.Width = 125
        '
        'GridColumn96
        '
        Me.GridColumn96.Caption = "Approver 4"
        Me.GridColumn96.FieldName = "Approver 4"
        Me.GridColumn96.Name = "GridColumn96"
        Me.GridColumn96.Visible = True
        Me.GridColumn96.VisibleIndex = 40
        Me.GridColumn96.Width = 175
        '
        'GridColumn69
        '
        Me.GridColumn69.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn69.Caption = "Credit Application"
        Me.GridColumn69.DisplayFormat.FormatString = "n2"
        Me.GridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn69.FieldName = "RM Override"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 41
        Me.GridColumn69.Width = 125
        '
        'GridColumn81
        '
        Me.GridColumn81.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn81.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn81.Caption = "Cash Advance"
        Me.GridColumn81.DisplayFormat.FormatString = "n2"
        Me.GridColumn81.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn81.FieldName = "RM CA"
        Me.GridColumn81.Name = "GridColumn81"
        Me.GridColumn81.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn81.Visible = True
        Me.GridColumn81.VisibleIndex = 42
        Me.GridColumn81.Width = 125
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit2.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit2.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit2.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit2.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit2.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit2.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "True"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "False"
        '
        'tabMicroBranch
        '
        Me.tabMicroBranch.AttachedControl = Me.SuperTabControlPanel7
        Me.tabMicroBranch.GlobalItem = False
        Me.tabMicroBranch.Name = "tabMicroBranch"
        Me.tabMicroBranch.Text = "Micro Finance Branch List"
        '
        'btnMap
        '
        Me.btnMap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMap.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnMap.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMap.Image = Global.FSFC_System.My.Resources.Resources.PlaceHolder
        Me.btnMap.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnMap.Location = New System.Drawing.Point(1022, 4)
        Me.btnMap.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.Size = New System.Drawing.Size(107, 30)
        Me.btnMap.TabIndex = 1030
        Me.btnMap.Text = "Google   Map"
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnMap)
        Me.PanelEx3.Controls.Add(Me.btnAdd)
        Me.PanelEx3.Controls.Add(Me.btnModify)
        Me.PanelEx3.Controls.Add(Me.btnDelete)
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.Controls.Add(Me.btnNext)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.Controls.Add(Me.btnBack)
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
        Me.PanelEx3.TabIndex = 1002
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
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrint.Location = New System.Drawing.Point(909, 4)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 30)
        Me.btnPrint.TabIndex = 1025
        Me.btnPrint.Text = "&Print"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnNext.Font = New System.Drawing.Font("Century Gothic", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnBack.Font = New System.Drawing.Font("Century Gothic", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnBack.Location = New System.Drawing.Point(5, 4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(107, 30)
        Me.btnBack.Symbol = ""
        Me.btnBack.SymbolSize = 24.0!
        Me.btnBack.TabIndex = 1005
        '
        'FrmBranch
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
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBranch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.SuperTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl2.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.iAvailedPenalty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iAvailedRPPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPenalty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dRPPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iRPPD_Start, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel8.ResumeLayout(False)
        CType(Me.dOIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dDM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dRM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dOIC_CA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dBM_CA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dDM_CA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dRM_CA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel6.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        CType(Me.dPettyCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.iRedemption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iReservation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iOverstay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTransactionAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx10.ResumeLayout(False)
        CType(Me.pb_Location.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpOpened, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel7.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanelEx10 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtBranchCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtBranch As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tabBranch As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tabList As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBack As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtBranchID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpOpened As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cbxNA As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnModify As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtAddress As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtEmailAddress As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtContactN3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtContactN2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtContactN1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pb_Location As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtPath As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnBrowse As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dRPPD As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iRPPD_Start As DevComponents.Editors.IntegerInput
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbxRoundUp As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents iOverstay As DevComponents.Editors.IntegerInput
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dTransactionAmount As DevComponents.Editors.DoubleInput
    Friend WithEvents SuperTabControl2 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabROPOA As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabCreditApplication As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbxOverstay As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iReservation As DevComponents.Editors.IntegerInput
    Friend WithEvents dPenalty As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iRedemption As DevComponents.Editors.IntegerInput
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dRM As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dDM As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dBM As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iAvailedPenalty As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iAvailedRPPD As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dPettyCash As DevComponents.Editors.DoubleInput
    Friend WithEvents tabFinancial As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents cbxEmail_Off As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxEmail_On As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxSMS_Off As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxSMS_On As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents tabSettings As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtTIN As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dRM_CA As DevComponents.Editors.DoubleInput
    Friend WithEvents dDM_CA As DevComponents.Editors.DoubleInput
    Friend WithEvents dBM_CA As DevComponents.Editors.DoubleInput
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX42 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAddress As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dOIC_CA As DevComponents.Editors.DoubleInput
    Friend WithEvents dOIC As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX44 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnMap As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxAuto_Off As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX46 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAuto_On As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxDeferred_Off As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX45 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxDeferred_On As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX47 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX49 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAvancePrincipal_Off As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX50 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAvancePrincipal_On As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbxMicrofinance As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn79 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn80 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn81 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn82 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn83 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn84 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tabMicroBranch As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents cbxBranchCode As SergeUtils.EasyCompletionComboBox
    Friend WithEvents btnReset As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnYard As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxBankBranch As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxUseOtherBank As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn85 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn86 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnTariff As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX51 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxOther_Off As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX52 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxOther_On As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GridColumn87 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn88 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SuperTabControlPanel8 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabApproval As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents cbxApprover4 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxApprover3 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxApprover2 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxApprover1 As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX38 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn89 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn90 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn91 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn92 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn93 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn94 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn95 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn96 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
End Class
