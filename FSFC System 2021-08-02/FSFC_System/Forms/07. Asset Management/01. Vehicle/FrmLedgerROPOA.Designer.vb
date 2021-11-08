<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLedgerROPOA
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
        Me.btnApproved = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn0 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabList_2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanelEx10 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.dAmount = New DevComponents.Editors.DoubleInput()
        Me.cbxDeduct = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAdd = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtReference = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemarks = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.cbxTransaction = New SergeUtils.EasyCompletionComboBox()
        Me.dtpDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.dTotal = New DevComponents.Editors.DoubleInput()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.tabSetup = New DevComponents.DotNetBar.SuperTabItem()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.PanelEx10.SuspendLayout()
        CType(Me.dAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnAdd)
        Me.PanelEx3.Controls.Add(Me.btnModify)
        Me.PanelEx3.Controls.Add(Me.btnDelete)
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.Controls.Add(Me.btnNext)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.Controls.Add(Me.btnBack)
        Me.PanelEx3.Controls.Add(Me.btnApproved)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 662)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1153, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1004
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
        Me.btnAdd.TabIndex = 1006
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
        Me.btnDelete.Text = "&Delete"
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
        'btnApproved
        '
        Me.btnApproved.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnApproved.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnApproved.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApproved.Image = Global.FSFC_System.My.Resources.Resources.Approve
        Me.btnApproved.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnApproved.Location = New System.Drawing.Point(1022, 4)
        Me.btnApproved.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnApproved.Name = "btnApproved"
        Me.btnApproved.Size = New System.Drawing.Size(107, 30)
        Me.btnApproved.TabIndex = 1030
        Me.btnApproved.Text = "Approved"
        Me.btnApproved.Visible = False
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
        Me.PanelEx1.Size = New System.Drawing.Size(1153, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1005
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
        Me.lblTitle.Text = "ROPOA LEDGER"
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.FixedTabSize = New System.Drawing.Size(175, 25)
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 66)
        Me.SuperTabControl1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(1153, 596)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1424
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabSetup, Me.tabList_2})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.GridControl2)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1153, 569)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.tabList_2
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
        Me.GridControl2.Size = New System.Drawing.Size(1153, 569)
        Me.GridControl2.TabIndex = 1679
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
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn0, Me.GridColumn7, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn8, Me.GridColumn6, Me.GridColumn9})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.GroupPanelText = "General Requirements"
        Me.GridView2.Name = "GridView2"
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
        'GridColumn0
        '
        Me.GridColumn0.Caption = "ID"
        Me.GridColumn0.FieldName = "ID"
        Me.GridColumn0.Name = "GridColumn0"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ledger_code"
        Me.GridColumn7.FieldName = "ledger_code"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Date"
        Me.GridColumn1.FieldName = "Date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Transaction"
        Me.GridColumn2.FieldName = "Transaction"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 150
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Remarks"
        Me.GridColumn3.FieldName = "Remarks"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 456
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Reference No."
        Me.GridColumn4.FieldName = "Reference No."
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 120
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Amount"
        Me.GridColumn5.DisplayFormat.FormatString = "{0:#,##0.00;(#,##0.00);0.00}"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn5.FieldName = "Amount"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 120
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Running Balance"
        Me.GridColumn8.DisplayFormat.FormatString = "{0:#,##0.00;(#,##0.00);0.00}"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn8.FieldName = "Total"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 120
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Type"
        Me.GridColumn6.FieldName = "Type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 70
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Approved Status"
        Me.GridColumn9.FieldName = "Approved Status"
        Me.GridColumn9.Name = "GridColumn9"
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
        'tabList_2
        '
        Me.tabList_2.AttachedControl = Me.SuperTabControlPanel3
        Me.tabList_2.GlobalItem = False
        Me.tabList_2.Name = "tabList_2"
        Me.tabList_2.Text = "Ledger"
        Me.tabList_2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.PanelEx10)
        Me.SuperTabControlPanel1.Controls.Add(Me.dTotal)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX18)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1153, 569)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.tabSetup
        '
        'PanelEx10
        '
        Me.PanelEx10.AutoScroll = True
        Me.PanelEx10.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx10.Controls.Add(Me.LabelX15)
        Me.PanelEx10.Controls.Add(Me.dAmount)
        Me.PanelEx10.Controls.Add(Me.cbxDeduct)
        Me.PanelEx10.Controls.Add(Me.LabelX1)
        Me.PanelEx10.Controls.Add(Me.cbxAdd)
        Me.PanelEx10.Controls.Add(Me.LabelX3)
        Me.PanelEx10.Controls.Add(Me.txtReference)
        Me.PanelEx10.Controls.Add(Me.LabelX16)
        Me.PanelEx10.Controls.Add(Me.txtRemarks)
        Me.PanelEx10.Controls.Add(Me.LabelX43)
        Me.PanelEx10.Controls.Add(Me.cbxTransaction)
        Me.PanelEx10.Controls.Add(Me.dtpDate)
        Me.PanelEx10.Controls.Add(Me.LabelX14)
        Me.PanelEx10.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx10.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PanelEx10.Name = "PanelEx10"
        Me.PanelEx10.Size = New System.Drawing.Size(1153, 569)
        Me.PanelEx10.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx10.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx10.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx10.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx10.Style.GradientAngle = 90
        Me.PanelEx10.TabIndex = 1679
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
        Me.LabelX15.Location = New System.Drawing.Point(12, 196)
        Me.LabelX15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(115, 23)
        Me.LabelX15.TabIndex = 1455
        Me.LabelX15.Text = "Amount :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dAmount
        '
        '
        '
        '
        Me.dAmount.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dAmount.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dAmount.ForeColor = System.Drawing.Color.Black
        Me.dAmount.Increment = 1.0R
        Me.dAmount.Location = New System.Drawing.Point(132, 196)
        Me.dAmount.MinValue = 0.0R
        Me.dAmount.Name = "dAmount"
        Me.dAmount.ShowUpDown = True
        Me.dAmount.Size = New System.Drawing.Size(254, 23)
        Me.dAmount.TabIndex = 35
        '
        'cbxDeduct
        '
        Me.cbxDeduct.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDeduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDeduct.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDeduct.Location = New System.Drawing.Point(211, 167)
        Me.cbxDeduct.Name = "cbxDeduct"
        Me.cbxDeduct.Size = New System.Drawing.Size(73, 23)
        Me.cbxDeduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDeduct.TabIndex = 30
        Me.cbxDeduct.Text = "Deduct"
        Me.cbxDeduct.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
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
        Me.LabelX1.Location = New System.Drawing.Point(12, 167)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(114, 23)
        Me.LabelX1.TabIndex = 1452
        Me.LabelX1.Text = "Type :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxAdd
        '
        Me.cbxAdd.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAdd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAdd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAdd.Location = New System.Drawing.Point(132, 167)
        Me.cbxAdd.Name = "cbxAdd"
        Me.cbxAdd.Size = New System.Drawing.Size(73, 23)
        Me.cbxAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAdd.TabIndex = 25
        Me.cbxAdd.Text = "Add"
        Me.cbxAdd.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
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
        Me.LabelX3.Location = New System.Drawing.Point(11, 136)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(115, 23)
        Me.LabelX3.TabIndex = 1450
        Me.LabelX3.Text = "Reference Num :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtReference
        '
        '
        '
        '
        Me.txtReference.Border.Class = "TextBoxBorder"
        Me.txtReference.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReference.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReference.Location = New System.Drawing.Point(132, 136)
        Me.txtReference.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReference.MaxLength = 20
        Me.txtReference.Name = "txtReference"
        Me.txtReference.PreventEnterBeep = True
        Me.txtReference.Size = New System.Drawing.Size(254, 23)
        Me.txtReference.TabIndex = 20
        Me.txtReference.WatermarkText = "Reference Number"
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
        Me.LabelX16.Location = New System.Drawing.Point(12, 75)
        Me.LabelX16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(115, 23)
        Me.LabelX16.TabIndex = 1448
        Me.LabelX16.Text = "Remarks :"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtRemarks
        '
        '
        '
        '
        Me.txtRemarks.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.txtRemarks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemarks.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.ForeColor = System.Drawing.Color.Black
        Me.txtRemarks.Location = New System.Drawing.Point(132, 75)
        Me.txtRemarks.MaxLength = 255
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Century Got" & _
    "hic;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtRemarks.Size = New System.Drawing.Size(619, 54)
        Me.txtRemarks.TabIndex = 15
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
        Me.LabelX43.Location = New System.Drawing.Point(11, 43)
        Me.LabelX43.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(116, 23)
        Me.LabelX43.TabIndex = 1446
        Me.LabelX43.Text = "Transaction :"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxTransaction
        '
        Me.cbxTransaction.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxTransaction.FormattingEnabled = True
        Me.cbxTransaction.Location = New System.Drawing.Point(132, 43)
        Me.cbxTransaction.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxTransaction.MaxLength = 30
        Me.cbxTransaction.Name = "cbxTransaction"
        Me.cbxTransaction.Size = New System.Drawing.Size(254, 25)
        Me.cbxTransaction.TabIndex = 10
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
        Me.dtpDate.Location = New System.Drawing.Point(132, 13)
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
        Me.dtpDate.Size = New System.Drawing.Size(254, 23)
        Me.dtpDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpDate.TabIndex = 5
        Me.dtpDate.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
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
        Me.LabelX14.Location = New System.Drawing.Point(11, 13)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(116, 23)
        Me.LabelX14.TabIndex = 1444
        Me.LabelX14.Text = "Date :"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dTotal
        '
        '
        '
        '
        Me.dTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dTotal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.dTotal.ForeColor = System.Drawing.Color.Red
        Me.dTotal.Increment = 1.0R
        Me.dTotal.Location = New System.Drawing.Point(778, 598)
        Me.dTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dTotal.MinValue = 0.0R
        Me.dTotal.Name = "dTotal"
        Me.dTotal.ShowUpDown = True
        Me.dTotal.Size = New System.Drawing.Size(237, 31)
        Me.dTotal.TabIndex = 1678
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.Red
        Me.LabelX18.Location = New System.Drawing.Point(667, 602)
        Me.LabelX18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(93, 31)
        Me.LabelX18.TabIndex = 1676
        Me.LabelX18.Text = "Total :"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tabSetup
        '
        Me.tabSetup.AttachedControl = Me.SuperTabControlPanel1
        Me.tabSetup.GlobalItem = False
        Me.tabSetup.Name = "tabSetup"
        Me.tabSetup.Text = "Transaction Entry"
        Me.tabSetup.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(1117, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'FrmLedger_ROPOA
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmLedgerROPOA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.PanelEx10.ResumeLayout(False)
        CType(Me.dAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnModify As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBack As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabList_2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanelEx10 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents dTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tabSetup As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn0 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents dtpDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxTransaction As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemarks As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReference As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxDeduct As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAdd As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dAmount As DevComponents.Editors.DoubleInput
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnApproved As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
