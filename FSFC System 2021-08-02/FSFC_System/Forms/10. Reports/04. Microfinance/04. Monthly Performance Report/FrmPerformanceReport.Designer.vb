<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPerformanceReport
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
        Me.PanelEx19 = New DevComponents.DotNetBar.PanelEx()
        Me.cbxAll = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxDisplay = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.dtpTo = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        Me.dtpFrom = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.lblFrom = New DevComponents.DotNetBar.LabelX()
        Me.cbxBusinessCenter = New SergeUtils.EasyCompletionComboBox()
        Me.btnPrintCustomized = New DevComponents.DotNetBar.ButtonX()
        Me.cbxAllB = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxBranch = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.iLedger = New DevComponents.DotNetBar.ButtonItem()
        Me.iSOA = New DevComponents.DotNetBar.ButtonItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ContextMenuBar3 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.iDetails = New DevComponents.DotNetBar.ButtonItem()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx19.SuspendLayout()
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx19
        '
        Me.PanelEx19.AutoScroll = True
        Me.PanelEx19.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx19.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx19.Controls.Add(Me.cbxAll)
        Me.PanelEx19.Controls.Add(Me.cbxDisplay)
        Me.PanelEx19.Controls.Add(Me.LabelX40)
        Me.PanelEx19.Controls.Add(Me.dtpTo)
        Me.PanelEx19.Controls.Add(Me.LabelX41)
        Me.PanelEx19.Controls.Add(Me.dtpFrom)
        Me.PanelEx19.Controls.Add(Me.lblFrom)
        Me.PanelEx19.Controls.Add(Me.cbxBusinessCenter)
        Me.PanelEx19.Controls.Add(Me.btnPrintCustomized)
        Me.PanelEx19.Controls.Add(Me.cbxAllB)
        Me.PanelEx19.Controls.Add(Me.cbxBranch)
        Me.PanelEx19.Controls.Add(Me.LabelX1)
        Me.PanelEx19.Controls.Add(Me.btnSearch)
        Me.PanelEx19.Controls.Add(Me.btnPrint)
        Me.PanelEx19.Controls.Add(Me.btnCancel)
        Me.PanelEx19.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx19.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx19.Location = New System.Drawing.Point(0, 66)
        Me.PanelEx19.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx19.Name = "PanelEx19"
        Me.PanelEx19.Size = New System.Drawing.Size(1167, 100)
        Me.PanelEx19.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx19.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx19.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx19.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx19.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx19.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left
        Me.PanelEx19.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx19.Style.GradientAngle = 90
        Me.PanelEx19.TabIndex = 1761
        '
        'cbxAll
        '
        Me.cbxAll.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAll.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAll.Location = New System.Drawing.Point(456, 37)
        Me.cbxAll.Name = "cbxAll"
        Me.cbxAll.Size = New System.Drawing.Size(45, 23)
        Me.cbxAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAll.TabIndex = 40
        Me.cbxAll.Text = "All"
        '
        'cbxDisplay
        '
        Me.cbxDisplay.DisplayMember = "PREFIX"
        Me.cbxDisplay.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDisplay.FormattingEnabled = True
        Me.cbxDisplay.Items.AddRange(New Object() {"Today", "This Week", "This Month", "This Year", "Range", "As Of"})
        Me.cbxDisplay.Location = New System.Drawing.Point(71, 37)
        Me.cbxDisplay.Name = "cbxDisplay"
        Me.cbxDisplay.Size = New System.Drawing.Size(379, 25)
        Me.cbxDisplay.TabIndex = 35
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
        Me.LabelX40.Location = New System.Drawing.Point(9, 37)
        Me.LabelX40.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.Size = New System.Drawing.Size(56, 23)
        Me.LabelX40.TabIndex = 1709
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
        Me.dtpTo.Location = New System.Drawing.Point(289, 68)
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
        Me.dtpTo.TabIndex = 50
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
        Me.LabelX41.Location = New System.Drawing.Point(237, 68)
        Me.LabelX41.Name = "LabelX41"
        Me.LabelX41.Size = New System.Drawing.Size(46, 23)
        Me.LabelX41.TabIndex = 1708
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
        Me.dtpFrom.Location = New System.Drawing.Point(71, 68)
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
        Me.dtpFrom.TabIndex = 45
        Me.dtpFrom.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'lblFrom
        '
        Me.lblFrom.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFrom.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFrom.Location = New System.Drawing.Point(9, 68)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(56, 23)
        Me.lblFrom.TabIndex = 1707
        Me.lblFrom.Text = "From :"
        Me.lblFrom.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxBusinessCenter
        '
        Me.cbxBusinessCenter.DisplayMember = "PREFIX"
        Me.cbxBusinessCenter.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBusinessCenter.FormattingEnabled = True
        Me.cbxBusinessCenter.Location = New System.Drawing.Point(289, 6)
        Me.cbxBusinessCenter.Name = "cbxBusinessCenter"
        Me.cbxBusinessCenter.Size = New System.Drawing.Size(161, 25)
        Me.cbxBusinessCenter.TabIndex = 10
        Me.cbxBusinessCenter.ValueMember = "ID"
        '
        'btnPrintCustomized
        '
        Me.btnPrintCustomized.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrintCustomized.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrintCustomized.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintCustomized.Image = Global.FSFC_System.My.Resources.Resources.Print
        Me.btnPrintCustomized.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrintCustomized.Location = New System.Drawing.Point(846, 6)
        Me.btnPrintCustomized.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrintCustomized.Name = "btnPrintCustomized"
        Me.btnPrintCustomized.Size = New System.Drawing.Size(107, 30)
        Me.btnPrintCustomized.TabIndex = 1689
        Me.btnPrintCustomized.Text = "Customize"
        '
        'cbxAllB
        '
        Me.cbxAllB.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAllB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAllB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAllB.Location = New System.Drawing.Point(456, 6)
        Me.cbxAllB.Name = "cbxAllB"
        Me.cbxAllB.Size = New System.Drawing.Size(45, 23)
        Me.cbxAllB.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAllB.TabIndex = 15
        Me.cbxAllB.Text = "All"
        '
        'cbxBranch
        '
        Me.cbxBranch.DisplayMember = "PREFIX"
        Me.cbxBranch.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranch.FormattingEnabled = True
        Me.cbxBranch.Items.AddRange(New Object() {"Today", "This Week", "This Month", "This Year", "Range"})
        Me.cbxBranch.Location = New System.Drawing.Point(71, 6)
        Me.cbxBranch.Name = "cbxBranch"
        Me.cbxBranch.Size = New System.Drawing.Size(212, 25)
        Me.cbxBranch.TabIndex = 5
        Me.cbxBranch.ValueMember = "ID"
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
        Me.LabelX1.Location = New System.Drawing.Point(9, 6)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 23)
        Me.LabelX1.TabIndex = 1033
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
        Me.btnSearch.Location = New System.Drawing.Point(507, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 30)
        Me.btnSearch.TabIndex = 50
        Me.btnSearch.Text = "Generate"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.FSFC_System.My.Resources.Resources.Print
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrint.Location = New System.Drawing.Point(733, 6)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 30)
        Me.btnPrint.TabIndex = 1025
        Me.btnPrint.Text = "&Print"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(620, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1020
        Me.btnCancel.Text = "Close"
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
        Me.PanelEx1.TabIndex = 1760
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
        Me.lblTitle.Location = New System.Drawing.Point(320, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(591, 26)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "PERFORMANCE REPORT PER ACCOUNT OFFICER"
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
        'ButtonItem5
        '
        Me.ButtonItem5.AutoExpandOnClick = True
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.iLedger, Me.iSOA})
        '
        'iLedger
        '
        Me.iLedger.Name = "iLedger"
        Me.iLedger.Text = "Account Ledger"
        '
        'iSOA
        '
        Me.iSOA.Name = "iSOA"
        Me.iSOA.Text = "Statement of Account"
        '
        'GridControl1
        '
        Me.ContextMenuBar3.SetContextMenuEx(Me.GridControl1, Me.ButtonItem1)
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(0, 166)
        Me.GridControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.BandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1167, 533)
        Me.GridControl1.TabIndex = 1762
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView1})
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView1.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView1.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView1.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView1.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.Row.Options.UseFont = True
        Me.BandedGridView1.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5, Me.gridBand6})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn11})
        Me.BandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView1.GridControl = Me.GridControl1
        Me.BandedGridView1.GroupPanelText = "General Requirements"
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsBehavior.Editable = False
        Me.BandedGridView1.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView1.OptionsLayout.StoreAppearance = True
        Me.BandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView1.OptionsSelection.MultiSelect = True
        Me.BandedGridView1.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView1.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView1.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand2.AppearanceHeader.Options.UseFont = True
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Account Officer"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.RowCount = 2
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 199
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn1.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn1.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn1.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn1.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn1.Caption = " "
        Me.BandedGridColumn1.FieldName = "Account Officer"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 199
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand3.AppearanceHeader.Options.UseFont = True
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Porfolio"
        Me.gridBand3.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 190
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn2.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn2.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn2.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn2.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn2.Caption = "Outstanding"
        Me.BandedGridColumn2.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn2.FieldName = "Outstanding_1"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 105
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn3.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn3.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn3.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn3.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn3.Caption = "No. of Clients"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "Client_1"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 85
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand4.AppearanceHeader.Options.UseFont = True
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "PAST DUE (Arrears)"
        Me.gridBand4.Columns.Add(Me.BandedGridColumn4)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn5)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 2
        Me.gridBand4.Width = 285
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn4.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn4.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn4.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn4.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn4.Caption = "Amount"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn4.FieldName = "Amount_2"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 115
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn5.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn5.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn5.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn5.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn5.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn5.Caption = "Ratio"
        Me.BandedGridColumn5.FieldName = "Ratio_2"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 85
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn6.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn6.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn6.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn6.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn6.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn6.Caption = "No. of Clients"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "Client_2"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 85
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand5.AppearanceHeader.Options.UseFont = True
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridBand5.Caption = "Releases"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 3
        Me.gridBand5.Width = 190
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn7.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn7.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn7.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn7.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn7.Caption = "Amount"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "Amount_3"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 100
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn8.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn8.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn8.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn8.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn8.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn8.Caption = "No. of Releases"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "Release_3"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 90
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand6.AppearanceHeader.Options.UseFont = True
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Collections"
        Me.gridBand6.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand6.Columns.Add(Me.BandedGridColumn10)
        Me.gridBand6.Columns.Add(Me.BandedGridColumn11)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 4
        Me.gridBand6.Width = 285
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn9.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn9.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn9.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn9.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn9.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn9.Caption = "Principal"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "Principal_4"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 95
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn10.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn10.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn10.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn10.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn10.Caption = "Interest"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "Interest_4"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 95
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn11.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn11.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn11.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn11.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn11.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn11.Caption = "Penalties"
        Me.BandedGridColumn11.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn11.FieldName = "Penalties_4"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn11.Visible = True
        Me.BandedGridColumn11.Width = 95
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
        'ContextMenuBar3
        '
        Me.ContextMenuBar3.AntiAlias = True
        Me.ContextMenuBar3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ContextMenuBar3.Location = New System.Drawing.Point(320, 346)
        Me.ContextMenuBar3.Name = "ContextMenuBar3"
        Me.ContextMenuBar3.Size = New System.Drawing.Size(114, 25)
        Me.ContextMenuBar3.Stretch = True
        Me.ContextMenuBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar3.TabIndex = 1765
        Me.ContextMenuBar3.TabStop = False
        Me.ContextMenuBar3.Text = "ContextMenuBar3"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.iDetails})
        '
        'iDetails
        '
        Me.iDetails.Name = "iDetails"
        Me.iDetails.Text = "Details"
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
        'FrmPerformanceReport
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
        Me.Controls.Add(Me.ContextMenuBar3)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelEx19)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmPerformanceReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx19.ResumeLayout(False)
        CType(Me.dtpTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx19 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents cbxAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxDisplay As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpTo As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpFrom As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lblFrom As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxBusinessCenter As SergeUtils.EasyCompletionComboBox
    Friend WithEvents btnPrintCustomized As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxAllB As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxBranch As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iLedger As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iSOA As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ContextMenuBar3 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iDetails As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
