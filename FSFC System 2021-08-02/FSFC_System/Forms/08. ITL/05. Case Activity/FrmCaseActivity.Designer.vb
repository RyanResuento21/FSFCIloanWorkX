<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCaseActivity
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim SeriesPoint1 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jan", New Object() {CType(1.04R, Object)})
        Dim SeriesPoint2 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Feb", New Object() {CType(1.5R, Object)})
        Dim SeriesPoint3 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Mar", New Object() {CType(2.24R, Object)})
        Dim SeriesPoint4 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Apr", New Object() {CType(1.01R, Object)})
        Dim SeriesPoint5 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("May", New Object() {CType(0.95R, Object)})
        Dim SeriesPoint6 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jun", New Object() {CType(1.5R, Object)})
        Dim SeriesPoint7 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jul", New Object() {CType(1.6R, Object)})
        Dim SeriesPoint8 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Aug", New Object() {CType(1.2R, Object)})
        Dim SeriesPoint9 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Sep", New Object() {CType(1.7R, Object)})
        Dim SeriesPoint10 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Oct", New Object() {CType(0.2R, Object)})
        Dim SeriesPoint11 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Nov", New Object() {CType(0.9R, Object)})
        Dim SeriesPoint12 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Dec", New Object() {CType(2.2R, Object)})
        Dim SideBySideBarSeriesLabel2 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PieSeriesLabel1 As DevExpress.XtraCharts.PieSeriesLabel = New DevExpress.XtraCharts.PieSeriesLabel()
        Dim SeriesPoint13 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Vehicle", New Object() {CType(34252.0R, Object)}, 0)
        Dim SeriesPoint14 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Real Estate", New Object() {CType(8925.0R, Object)}, 1)
        Dim SeriesPoint15 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Salary", New Object() {CType(26029.0R, Object)}, 3)
        Dim SeriesPoint16 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Payday", New Object() {CType(17491.0R, Object)}, 4)
        Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView(New Integer(-1) {})
        Dim DoughnutSeriesLabel1 As DevExpress.XtraCharts.DoughnutSeriesLabel = New DevExpress.XtraCharts.DoughnutSeriesLabel()
        Dim DoughnutSeriesView1 As DevExpress.XtraCharts.DoughnutSeriesView = New DevExpress.XtraCharts.DoughnutSeriesView()
        Dim ChartTitle2 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx19 = New DevComponents.DotNetBar.PanelEx()
        Me.cbxCase = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cbxBranch = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.cbxAll = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxDisplay = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.dtpTo = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        Me.dtpFrom = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX42 = New DevComponents.DotNetBar.LabelX()
        Me.gLog = New DevExpress.XtraEditors.GroupControl()
        Me.lblLastUpdate_DA = New DevComponents.DotNetBar.LabelX()
        Me.lblLastUpdate_D = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Chart1 = New DevExpress.XtraCharts.ChartControl()
        Me.pBookValue = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.pPayments = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.pBalance = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.lblStatus = New DevComponents.DotNetBar.LabelX()
        Me.gCivilStatus = New DevExpress.XtraEditors.GroupControl()
        Me.lblWrittenOffP = New DevComponents.DotNetBar.LabelX()
        Me.lblWrittenOffD = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchivedP = New DevComponents.DotNetBar.LabelX()
        Me.lblArchivedD = New DevComponents.DotNetBar.LabelX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissedP = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissedD = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecutedP = New DevComponents.DotNetBar.LabelX()
        Me.lblExecutedD = New DevComponents.DotNetBar.LabelX()
        Me.lblDecidedP = New DevComponents.DotNetBar.LabelX()
        Me.lblOngoingP = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecidedD = New DevComponents.DotNetBar.LabelX()
        Me.lblOngoingD = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.ChartControl2 = New DevExpress.XtraCharts.ChartControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.lblActionPlan = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx19.SuspendLayout()
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gLog.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pBookValue.SuspendLayout()
        Me.pPayments.SuspendLayout()
        Me.pBalance.SuspendLayout()
        CType(Me.gCivilStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gCivilStatus.SuspendLayout()
        CType(Me.ChartControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
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
        Me.PanelEx1.TabIndex = 1688
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
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "CASE ACTIVITY"
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
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 662)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1167, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1689
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.FSFC_System.My.Resources.Resources.Print
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrint.Location = New System.Drawing.Point(116, 3)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 30)
        Me.btnPrint.TabIndex = 1015
        Me.btnPrint.Text = "&Print"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(3, 3)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1010
        Me.btnCancel.Text = "Close"
        '
        'PanelEx19
        '
        Me.PanelEx19.AutoScroll = True
        Me.PanelEx19.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx19.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx19.Controls.Add(Me.cbxCase)
        Me.PanelEx19.Controls.Add(Me.LabelX2)
        Me.PanelEx19.Controls.Add(Me.cbxBranch)
        Me.PanelEx19.Controls.Add(Me.LabelX1)
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
        Me.PanelEx19.Location = New System.Drawing.Point(0, 66)
        Me.PanelEx19.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx19.Name = "PanelEx19"
        Me.PanelEx19.Size = New System.Drawing.Size(1167, 73)
        Me.PanelEx19.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx19.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx19.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx19.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx19.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx19.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None
        Me.PanelEx19.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx19.Style.GradientAngle = 90
        Me.PanelEx19.TabIndex = 1690
        '
        'cbxCase
        '
        Me.cbxCase.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxCase.FormattingEnabled = True
        Me.cbxCase.Location = New System.Drawing.Point(569, 37)
        Me.cbxCase.Name = "cbxCase"
        Me.cbxCase.Size = New System.Drawing.Size(379, 25)
        Me.cbxCase.TabIndex = 30
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
        Me.LabelX2.Location = New System.Drawing.Point(456, 37)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(107, 23)
        Me.LabelX2.TabIndex = 100
        Me.LabelX2.Text = "Case :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxBranch
        '
        Me.cbxBranch.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranch.FormattingEnabled = True
        Me.cbxBranch.Location = New System.Drawing.Point(569, 6)
        Me.cbxBranch.Name = "cbxBranch"
        Me.cbxBranch.Size = New System.Drawing.Size(379, 25)
        Me.cbxBranch.TabIndex = 25
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
        Me.LabelX1.Location = New System.Drawing.Point(507, 6)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 23)
        Me.LabelX1.TabIndex = 98
        Me.LabelX1.Text = "Branch :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnSearch.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSearch.Location = New System.Drawing.Point(954, 6)
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
        'gLog
        '
        Me.gLog.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gLog.Appearance.Options.UseFont = True
        Me.gLog.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gLog.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gLog.AppearanceCaption.Options.UseFont = True
        Me.gLog.AppearanceCaption.Options.UseForeColor = True
        Me.gLog.Controls.Add(Me.lblLastUpdate_DA)
        Me.gLog.Controls.Add(Me.lblLastUpdate_D)
        Me.gLog.Controls.Add(Me.LabelX13)
        Me.gLog.Controls.Add(Me.LabelX14)
        Me.gLog.Location = New System.Drawing.Point(9, 212)
        Me.gLog.LookAndFeel.SkinName = "Darkroom"
        Me.gLog.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gLog.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gLog.Name = "gLog"
        Me.gLog.Size = New System.Drawing.Size(286, 100)
        Me.gLog.TabIndex = 1691
        Me.gLog.Text = "Last Update"
        '
        'lblLastUpdate_DA
        '
        '
        '
        '
        Me.lblLastUpdate_DA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblLastUpdate_DA.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblLastUpdate_DA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblLastUpdate_DA.Location = New System.Drawing.Point(209, 63)
        Me.lblLastUpdate_DA.Name = "lblLastUpdate_DA"
        Me.lblLastUpdate_DA.Size = New System.Drawing.Size(69, 25)
        Me.lblLastUpdate_DA.TabIndex = 1043
        Me.lblLastUpdate_DA.Text = "0"
        Me.lblLastUpdate_DA.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblLastUpdate_D
        '
        '
        '
        '
        Me.lblLastUpdate_D.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblLastUpdate_D.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblLastUpdate_D.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblLastUpdate_D.Location = New System.Drawing.Point(6, 63)
        Me.lblLastUpdate_D.Name = "lblLastUpdate_D"
        Me.lblLastUpdate_D.Size = New System.Drawing.Size(197, 25)
        Me.lblLastUpdate_D.TabIndex = 1041
        Me.lblLastUpdate_D.Text = "-"
        Me.lblLastUpdate_D.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX13.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX13.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.Location = New System.Drawing.Point(209, 32)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(69, 25)
        Me.LabelX13.TabIndex = 1040
        Me.LabelX13.Text = "Days Ago"
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX14.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX14.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.Location = New System.Drawing.Point(6, 32)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(197, 25)
        Me.LabelX14.TabIndex = 1039
        Me.LabelX14.Text = "Date"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(570, 381)
        Me.GridControl1.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(582, 277)
        Me.GridControl1.TabIndex = 1693
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
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
        Me.GridColumn1.Caption = "Action"
        Me.GridColumn1.FieldName = "Action"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 374
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Date & Time"
        Me.GridColumn2.FieldName = "Date & Time"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 190
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
        'Chart1
        '
        XyDiagram1.AxisX.Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.Chart1.Diagram = XyDiagram1
        Me.Chart1.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.Chart1.Location = New System.Drawing.Point(569, 150)
        Me.Chart1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Chart1.Name = "Chart1"
        Me.Chart1.PaletteName = "FSFC Palette"
        Me.Chart1.PaletteRepository.Add("Case Palette", New DevExpress.XtraCharts.Palette("Case Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(88, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(88, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(89, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(89, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(255, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(0, Byte), Integer)))}))
        Me.Chart1.PaletteRepository.Add("FSFC Palette", New DevExpress.XtraCharts.Palette("FSFC Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)))}))
        SideBySideBarSeriesLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        SideBySideBarSeriesLabel1.TextPattern = "{V:P0}"
        Series1.Label = SideBySideBarSeriesLabel1
        Series1.LegendTextPattern = "{V:G}"
        Series1.Name = "Borrower"
        Series1.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint1, SeriesPoint2, SeriesPoint3, SeriesPoint4, SeriesPoint5, SeriesPoint6, SeriesPoint7, SeriesPoint8, SeriesPoint9, SeriesPoint10, SeriesPoint11, SeriesPoint12})
        Me.Chart1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        SideBySideBarSeriesLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        SideBySideBarSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.Chart1.SeriesTemplate.Label = SideBySideBarSeriesLabel2
        Me.Chart1.Size = New System.Drawing.Size(582, 225)
        Me.Chart1.TabIndex = 1694
        ChartTitle1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartTitle1.Text = "Monthly Collection"
        ChartTitle1.TextColor = System.Drawing.Color.Black
        ChartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.Chart1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'pBookValue
        '
        Me.pBookValue.CanvasColor = System.Drawing.SystemColors.Control
        Me.pBookValue.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pBookValue.Controls.Add(Me.LabelX155)
        Me.pBookValue.DisabledBackColor = System.Drawing.Color.Empty
        Me.pBookValue.Location = New System.Drawing.Point(9, 150)
        Me.pBookValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pBookValue.Name = "pBookValue"
        Me.pBookValue.Size = New System.Drawing.Size(180, 55)
        Me.pBookValue.Style.Alignment = System.Drawing.StringAlignment.Far
        Me.pBookValue.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pBookValue.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pBookValue.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pBookValue.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pBookValue.Style.Font = New System.Drawing.Font("Century Gothic", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pBookValue.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pBookValue.Style.GradientAngle = 90
        Me.pBookValue.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pBookValue.TabIndex = 1696
        Me.pBookValue.Text = "0.00"
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.LabelX155.ForeColor = System.Drawing.Color.White
        Me.LabelX155.Location = New System.Drawing.Point(1, 1)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(180, 22)
        Me.LabelX155.TabIndex = 77
        Me.LabelX155.Text = "Book Value"
        '
        'pPayments
        '
        Me.pPayments.CanvasColor = System.Drawing.SystemColors.Control
        Me.pPayments.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pPayments.Controls.Add(Me.LabelX35)
        Me.pPayments.DisabledBackColor = System.Drawing.Color.Empty
        Me.pPayments.Location = New System.Drawing.Point(196, 151)
        Me.pPayments.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pPayments.Name = "pPayments"
        Me.pPayments.Size = New System.Drawing.Size(180, 55)
        Me.pPayments.Style.Alignment = System.Drawing.StringAlignment.Far
        Me.pPayments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pPayments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pPayments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pPayments.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pPayments.Style.Font = New System.Drawing.Font("Century Gothic", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pPayments.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pPayments.Style.GradientAngle = 90
        Me.pPayments.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pPayments.TabIndex = 1697
        Me.pPayments.Text = "0.00"
        '
        'LabelX35
        '
        Me.LabelX35.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.LabelX35.ForeColor = System.Drawing.Color.White
        Me.LabelX35.Location = New System.Drawing.Point(1, 1)
        Me.LabelX35.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(180, 22)
        Me.LabelX35.TabIndex = 77
        Me.LabelX35.Text = "Collection"
        '
        'pBalance
        '
        Me.pBalance.CanvasColor = System.Drawing.SystemColors.Control
        Me.pBalance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pBalance.Controls.Add(Me.LabelX3)
        Me.pBalance.DisabledBackColor = System.Drawing.Color.Empty
        Me.pBalance.Location = New System.Drawing.Point(383, 151)
        Me.pBalance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pBalance.Name = "pBalance"
        Me.pBalance.Size = New System.Drawing.Size(180, 55)
        Me.pBalance.Style.Alignment = System.Drawing.StringAlignment.Far
        Me.pBalance.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pBalance.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pBalance.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pBalance.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pBalance.Style.Font = New System.Drawing.Font("Century Gothic", 18.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pBalance.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pBalance.Style.GradientAngle = 90
        Me.pBalance.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pBalance.TabIndex = 1698
        Me.pBalance.Text = "0.00"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.LabelX3.ForeColor = System.Drawing.Color.White
        Me.LabelX3.Location = New System.Drawing.Point(1, 1)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(180, 22)
        Me.LabelX3.TabIndex = 77
        Me.LabelX3.Text = "Balance"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.SeaGreen
        '
        '
        '
        Me.lblStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblStatus.Font = New System.Drawing.Font("Century Gothic", 18.75!)
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(6, 29)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(251, 65)
        Me.lblStatus.TabIndex = 1699
        Me.lblStatus.Text = "Active"
        Me.lblStatus.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'gCivilStatus
        '
        Me.gCivilStatus.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gCivilStatus.Appearance.Options.UseFont = True
        Me.gCivilStatus.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gCivilStatus.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gCivilStatus.AppearanceCaption.Options.UseFont = True
        Me.gCivilStatus.AppearanceCaption.Options.UseForeColor = True
        Me.gCivilStatus.Controls.Add(Me.lblWrittenOffP)
        Me.gCivilStatus.Controls.Add(Me.lblWrittenOffD)
        Me.gCivilStatus.Controls.Add(Me.LabelX9)
        Me.gCivilStatus.Controls.Add(Me.lblArchivedP)
        Me.gCivilStatus.Controls.Add(Me.lblArchivedD)
        Me.gCivilStatus.Controls.Add(Me.LabelX54)
        Me.gCivilStatus.Controls.Add(Me.lblDismissedP)
        Me.gCivilStatus.Controls.Add(Me.lblDismissedD)
        Me.gCivilStatus.Controls.Add(Me.LabelX22)
        Me.gCivilStatus.Controls.Add(Me.lblExecutedP)
        Me.gCivilStatus.Controls.Add(Me.lblExecutedD)
        Me.gCivilStatus.Controls.Add(Me.lblDecidedP)
        Me.gCivilStatus.Controls.Add(Me.lblOngoingP)
        Me.gCivilStatus.Controls.Add(Me.LabelX19)
        Me.gCivilStatus.Controls.Add(Me.lblDecidedD)
        Me.gCivilStatus.Controls.Add(Me.lblOngoingD)
        Me.gCivilStatus.Controls.Add(Me.LabelX15)
        Me.gCivilStatus.Controls.Add(Me.LabelX5)
        Me.gCivilStatus.Controls.Add(Me.LabelX6)
        Me.gCivilStatus.Controls.Add(Me.LabelX16)
        Me.gCivilStatus.Location = New System.Drawing.Point(9, 318)
        Me.gCivilStatus.LookAndFeel.SkinName = "Darkroom"
        Me.gCivilStatus.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gCivilStatus.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gCivilStatus.Name = "gCivilStatus"
        Me.gCivilStatus.Size = New System.Drawing.Size(286, 250)
        Me.gCivilStatus.TabIndex = 1700
        Me.gCivilStatus.Text = "Days in Category"
        '
        'lblWrittenOffP
        '
        '
        '
        '
        Me.lblWrittenOffP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWrittenOffP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblWrittenOffP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblWrittenOffP.Location = New System.Drawing.Point(191, 218)
        Me.lblWrittenOffP.Name = "lblWrittenOffP"
        Me.lblWrittenOffP.Size = New System.Drawing.Size(80, 25)
        Me.lblWrittenOffP.TabIndex = 1056
        Me.lblWrittenOffP.Text = "0.00 %"
        Me.lblWrittenOffP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblWrittenOffD
        '
        '
        '
        '
        Me.lblWrittenOffD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWrittenOffD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblWrittenOffD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblWrittenOffD.Location = New System.Drawing.Point(105, 218)
        Me.lblWrittenOffD.Name = "lblWrittenOffD"
        Me.lblWrittenOffD.Size = New System.Drawing.Size(80, 25)
        Me.lblWrittenOffD.TabIndex = 1055
        Me.lblWrittenOffD.Text = "0"
        Me.lblWrittenOffD.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Olive
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX9.ForeColor = System.Drawing.Color.White
        Me.LabelX9.Location = New System.Drawing.Point(5, 125)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(94, 25)
        Me.LabelX9.TabIndex = 1054
        Me.LabelX9.Text = "Executed"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchivedP
        '
        '
        '
        '
        Me.lblArchivedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchivedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblArchivedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchivedP.Location = New System.Drawing.Point(191, 187)
        Me.lblArchivedP.Name = "lblArchivedP"
        Me.lblArchivedP.Size = New System.Drawing.Size(80, 25)
        Me.lblArchivedP.TabIndex = 1053
        Me.lblArchivedP.Text = "0.00 %"
        Me.lblArchivedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchivedD
        '
        '
        '
        '
        Me.lblArchivedD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchivedD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblArchivedD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchivedD.Location = New System.Drawing.Point(105, 187)
        Me.lblArchivedD.Name = "lblArchivedD"
        Me.lblArchivedD.Size = New System.Drawing.Size(80, 25)
        Me.lblArchivedD.TabIndex = 1052
        Me.lblArchivedD.Text = "0"
        Me.lblArchivedD.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX54
        '
        Me.LabelX54.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX54.ForeColor = System.Drawing.Color.White
        Me.LabelX54.Location = New System.Drawing.Point(5, 94)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(94, 25)
        Me.LabelX54.TabIndex = 1051
        Me.LabelX54.Text = "Decided"
        Me.LabelX54.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissedP
        '
        '
        '
        '
        Me.lblDismissedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDismissedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissedP.Location = New System.Drawing.Point(191, 156)
        Me.lblDismissedP.Name = "lblDismissedP"
        Me.lblDismissedP.Size = New System.Drawing.Size(80, 25)
        Me.lblDismissedP.TabIndex = 1050
        Me.lblDismissedP.Text = "0.00 %"
        Me.lblDismissedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissedD
        '
        '
        '
        '
        Me.lblDismissedD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissedD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDismissedD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissedD.Location = New System.Drawing.Point(105, 156)
        Me.lblDismissedD.Name = "lblDismissedD"
        Me.lblDismissedD.Size = New System.Drawing.Size(80, 25)
        Me.lblDismissedD.TabIndex = 1049
        Me.lblDismissedD.Text = "0"
        Me.lblDismissedD.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Maroon
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX22.ForeColor = System.Drawing.Color.White
        Me.LabelX22.Location = New System.Drawing.Point(5, 218)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(94, 25)
        Me.LabelX22.TabIndex = 1048
        Me.LabelX22.Text = "Written Off"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecutedP
        '
        '
        '
        '
        Me.lblExecutedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecutedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblExecutedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecutedP.Location = New System.Drawing.Point(191, 125)
        Me.lblExecutedP.Name = "lblExecutedP"
        Me.lblExecutedP.Size = New System.Drawing.Size(80, 25)
        Me.lblExecutedP.TabIndex = 1047
        Me.lblExecutedP.Text = "0.00 %"
        Me.lblExecutedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecutedD
        '
        '
        '
        '
        Me.lblExecutedD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecutedD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblExecutedD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecutedD.Location = New System.Drawing.Point(105, 125)
        Me.lblExecutedD.Name = "lblExecutedD"
        Me.lblExecutedD.Size = New System.Drawing.Size(80, 25)
        Me.lblExecutedD.TabIndex = 1046
        Me.lblExecutedD.Text = "0"
        Me.lblExecutedD.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecidedP
        '
        '
        '
        '
        Me.lblDecidedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecidedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDecidedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecidedP.Location = New System.Drawing.Point(191, 94)
        Me.lblDecidedP.Name = "lblDecidedP"
        Me.lblDecidedP.Size = New System.Drawing.Size(80, 25)
        Me.lblDecidedP.TabIndex = 1044
        Me.lblDecidedP.Text = "0.00 %"
        Me.lblDecidedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOngoingP
        '
        '
        '
        '
        Me.lblOngoingP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOngoingP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblOngoingP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOngoingP.Location = New System.Drawing.Point(191, 63)
        Me.lblOngoingP.Name = "lblOngoingP"
        Me.lblOngoingP.Size = New System.Drawing.Size(80, 25)
        Me.lblOngoingP.TabIndex = 1043
        Me.lblOngoingP.Text = "0.00 %"
        Me.lblOngoingP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Orange
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX19.ForeColor = System.Drawing.Color.White
        Me.LabelX19.Location = New System.Drawing.Point(5, 187)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(94, 25)
        Me.LabelX19.TabIndex = 1045
        Me.LabelX19.Text = "Archived"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecidedD
        '
        '
        '
        '
        Me.lblDecidedD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecidedD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDecidedD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecidedD.Location = New System.Drawing.Point(105, 94)
        Me.lblDecidedD.Name = "lblDecidedD"
        Me.lblDecidedD.Size = New System.Drawing.Size(80, 25)
        Me.lblDecidedD.TabIndex = 1042
        Me.lblDecidedD.Text = "0"
        Me.lblDecidedD.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOngoingD
        '
        '
        '
        '
        Me.lblOngoingD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOngoingD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblOngoingD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOngoingD.Location = New System.Drawing.Point(105, 63)
        Me.lblOngoingD.Name = "lblOngoingD"
        Me.lblOngoingD.Size = New System.Drawing.Size(80, 25)
        Me.lblOngoingD.TabIndex = 1041
        Me.lblOngoingD.Text = "0"
        Me.lblOngoingD.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.IndianRed
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX15.ForeColor = System.Drawing.Color.White
        Me.LabelX15.Location = New System.Drawing.Point(5, 156)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(94, 25)
        Me.LabelX15.TabIndex = 1038
        Me.LabelX15.Text = "Dismissed"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX5.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(191, 32)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(80, 25)
        Me.LabelX5.TabIndex = 1040
        Me.LabelX5.Text = "Percentage"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX6.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX6.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(105, 32)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(80, 25)
        Me.LabelX6.TabIndex = 1039
        Me.LabelX6.Text = "Days"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.SeaGreen
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX16.ForeColor = System.Drawing.Color.White
        Me.LabelX16.Location = New System.Drawing.Point(5, 63)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(94, 25)
        Me.LabelX16.TabIndex = 1037
        Me.LabelX16.Text = "On Going"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ChartControl2
        '
        Me.ChartControl2.AppearanceNameSerializable = "Chameleon"
        Me.ChartControl2.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChartControl2.Location = New System.Drawing.Point(301, 318)
        Me.ChartControl2.Name = "ChartControl2"
        Me.ChartControl2.PaletteName = "Palette 1"
        Me.ChartControl2.PaletteRepository.Add("Palette 1", New DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Olive, System.Drawing.Color.Olive), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(106, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(106, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Maroon, System.Drawing.Color.Maroon)}))
        PieSeriesLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PieSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        PieSeriesLabel1.TextPattern = "{VP:P2}"
        Series2.Label = PieSeriesLabel1
        Series2.LegendTextPattern = "{S}"
        Series2.Name = "SeriesD"
        Series2.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint13, SeriesPoint14, SeriesPoint15, SeriesPoint16})
        PieSeriesView1.ExplodeMode = DevExpress.XtraCharts.PieExplodeMode.UsePoints
        PieSeriesView1.RuntimeExploding = True
        Series2.View = PieSeriesView1
        Me.ChartControl2.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series2}
        DoughnutSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        DoughnutSeriesLabel1.TextPattern = "{VP:P2}"
        Me.ChartControl2.SeriesTemplate.Label = DoughnutSeriesLabel1
        Me.ChartControl2.SeriesTemplate.View = DoughnutSeriesView1
        Me.ChartControl2.Size = New System.Drawing.Size(262, 250)
        Me.ChartControl2.TabIndex = 1701
        ChartTitle2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartTitle2.Text = "Days In Category"
        ChartTitle2.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.ChartControl2.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle2})
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl1.Controls.Add(Me.lblStatus)
        Me.GroupControl1.Location = New System.Drawing.Point(301, 213)
        Me.GroupControl1.LookAndFeel.SkinName = "Darkroom"
        Me.GroupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(263, 100)
        Me.GroupControl1.TabIndex = 1702
        Me.GroupControl1.Text = "Status"
        '
        'GroupControl2
        '
        Me.GroupControl2.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.Appearance.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.lblActionPlan)
        Me.GroupControl2.Location = New System.Drawing.Point(10, 574)
        Me.GroupControl2.LookAndFeel.SkinName = "Darkroom"
        Me.GroupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(554, 84)
        Me.GroupControl2.TabIndex = 1703
        Me.GroupControl2.Text = "Action Plan"
        '
        'lblActionPlan
        '
        '
        '
        '
        Me.lblActionPlan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblActionPlan.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblActionPlan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblActionPlan.Location = New System.Drawing.Point(6, 29)
        Me.lblActionPlan.Name = "lblActionPlan"
        Me.lblActionPlan.Size = New System.Drawing.Size(542, 52)
        Me.lblActionPlan.TabIndex = 1042
        Me.lblActionPlan.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.lblActionPlan.WordWrap = True
        '
        'FrmCaseActivity
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
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.ChartControl2)
        Me.Controls.Add(Me.gCivilStatus)
        Me.Controls.Add(Me.pBalance)
        Me.Controls.Add(Me.gLog)
        Me.Controls.Add(Me.pPayments)
        Me.Controls.Add(Me.pBookValue)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelEx19)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCaseActivity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx19.ResumeLayout(False)
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gLog.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pBookValue.ResumeLayout(False)
        Me.pPayments.ResumeLayout(False)
        Me.pBalance.ResumeLayout(False)
        CType(Me.gCivilStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gCivilStatus.ResumeLayout(False)
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx19 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxDisplay As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpTo As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpFrom As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX42 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxCase As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxBranch As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gLog As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblLastUpdate_DA As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblLastUpdate_D As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Chart1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents pBookValue As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pPayments As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pBalance As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblStatus As DevComponents.DotNetBar.LabelX
    Friend WithEvents gCivilStatus As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblArchivedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchivedD As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissedD As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecutedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecutedD As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecidedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOngoingP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecidedD As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOngoingD As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblWrittenOffP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblWrittenOffD As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ChartControl2 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblActionPlan As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
