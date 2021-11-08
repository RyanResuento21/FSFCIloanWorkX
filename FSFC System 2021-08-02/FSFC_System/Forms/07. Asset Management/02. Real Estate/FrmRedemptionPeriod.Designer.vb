<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRedemptionPeriod
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.dtpCOS = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.lblCOS = New DevComponents.DotNetBar.LabelX()
        Me.dtpReceived = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.iDays = New DevComponents.Editors.IntegerInput()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.dtpConsolidation = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtTCT = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.lblArea = New DevComponents.DotNetBar.LabelX()
        Me.lblTCTN = New DevComponents.DotNetBar.LabelX()
        Me.lblAccountN = New DevComponents.DotNetBar.LabelX()
        Me.lblAssetN = New DevComponents.DotNetBar.LabelX()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        CType(Me.dtpCOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpConsolidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btnLogs)
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.Controls.Add(Me.lblTitle)
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
        Me.PanelEx1.TabIndex = 14
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
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(324, 4)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(348, 58)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "REDEMPTION PERIOD"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnDelete)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 218)
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
        Me.PanelEx3.TabIndex = 1058
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.FSFC_System.My.Resources.Resources.Delete
        Me.btnDelete.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnDelete.Location = New System.Drawing.Point(345, 4)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(107, 30)
        Me.btnDelete.TabIndex = 1016
        Me.btnDelete.Text = "Cancel"
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
        Me.btnSave.Text = "&Redemption"
        '
        'dtpCOS
        '
        '
        '
        '
        Me.dtpCOS.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpCOS.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpCOS.ButtonDropDown.Visible = True
        Me.dtpCOS.CustomFormat = "MMMM dd, yyyy"
        Me.dtpCOS.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCOS.ForeColor = System.Drawing.Color.Black
        Me.dtpCOS.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpCOS.IsPopupCalendarOpen = False
        Me.dtpCOS.Location = New System.Drawing.Point(189, 102)
        '
        '
        '
        Me.dtpCOS.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpCOS.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpCOS.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpCOS.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpCOS.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpCOS.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpCOS.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpCOS.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpCOS.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpCOS.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpCOS.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpCOS.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpCOS.MonthCalendar.TodayButtonVisible = True
        Me.dtpCOS.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpCOS.Name = "dtpCOS"
        Me.dtpCOS.Size = New System.Drawing.Size(202, 23)
        Me.dtpCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpCOS.TabIndex = 10
        Me.dtpCOS.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'lblCOS
        '
        Me.lblCOS.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCOS.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCOS.Location = New System.Drawing.Point(7, 102)
        Me.lblCOS.Name = "lblCOS"
        Me.lblCOS.Size = New System.Drawing.Size(175, 23)
        Me.lblCOS.TabIndex = 1542
        Me.lblCOS.Text = "COS Annotation Date :"
        Me.lblCOS.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpReceived
        '
        '
        '
        '
        Me.dtpReceived.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpReceived.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpReceived.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpReceived.ButtonDropDown.Visible = True
        Me.dtpReceived.CustomFormat = "MMMM dd, yyyy"
        Me.dtpReceived.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReceived.ForeColor = System.Drawing.Color.Black
        Me.dtpReceived.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpReceived.IsPopupCalendarOpen = False
        Me.dtpReceived.Location = New System.Drawing.Point(189, 73)
        '
        '
        '
        Me.dtpReceived.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpReceived.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpReceived.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpReceived.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpReceived.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpReceived.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpReceived.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpReceived.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpReceived.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpReceived.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpReceived.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpReceived.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpReceived.MonthCalendar.TodayButtonVisible = True
        Me.dtpReceived.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpReceived.Name = "dtpReceived"
        Me.dtpReceived.Size = New System.Drawing.Size(202, 23)
        Me.dtpReceived.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpReceived.TabIndex = 5
        Me.dtpReceived.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
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
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(175, 23)
        Me.LabelX2.TabIndex = 1544
        Me.LabelX2.Text = "Received COS Date :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iDays
        '
        '
        '
        '
        Me.iDays.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iDays.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iDays.Enabled = False
        Me.iDays.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iDays.ForeColor = System.Drawing.Color.Black
        Me.iDays.Location = New System.Drawing.Point(189, 131)
        Me.iDays.MinValue = 0
        Me.iDays.Name = "iDays"
        Me.iDays.ShowUpDown = True
        Me.iDays.Size = New System.Drawing.Size(94, 23)
        Me.iDays.TabIndex = 15
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
        Me.LabelX36.Location = New System.Drawing.Point(7, 131)
        Me.LabelX36.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(176, 23)
        Me.LabelX36.TabIndex = 1546
        Me.LabelX36.Text = "Days Interval :"
        Me.LabelX36.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'dtpConsolidation
        '
        '
        '
        '
        Me.dtpConsolidation.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpConsolidation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpConsolidation.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpConsolidation.ButtonDropDown.Visible = True
        Me.dtpConsolidation.CustomFormat = "MMMM dd, yyyy"
        Me.dtpConsolidation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpConsolidation.ForeColor = System.Drawing.Color.Black
        Me.dtpConsolidation.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpConsolidation.IsPopupCalendarOpen = False
        Me.dtpConsolidation.Location = New System.Drawing.Point(189, 160)
        '
        '
        '
        Me.dtpConsolidation.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpConsolidation.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpConsolidation.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpConsolidation.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpConsolidation.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpConsolidation.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpConsolidation.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpConsolidation.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpConsolidation.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpConsolidation.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpConsolidation.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpConsolidation.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpConsolidation.MonthCalendar.TodayButtonVisible = True
        Me.dtpConsolidation.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpConsolidation.Name = "dtpConsolidation"
        Me.dtpConsolidation.Size = New System.Drawing.Size(202, 23)
        Me.dtpConsolidation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpConsolidation.TabIndex = 20
        Me.dtpConsolidation.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        Me.dtpConsolidation.Visible = False
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
        Me.LabelX3.Location = New System.Drawing.Point(7, 160)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(175, 23)
        Me.LabelX3.TabIndex = 1548
        Me.LabelX3.Text = "Consolidation Date :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX3.Visible = False
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
        Me.LabelX4.Location = New System.Drawing.Point(41, 188)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(141, 23)
        Me.LabelX4.TabIndex = 1550
        Me.LabelX4.Text = "Title Number :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX4.Visible = False
        '
        'txtTCT
        '
        '
        '
        '
        Me.txtTCT.Border.Class = "TextBoxBorder"
        Me.txtTCT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTCT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTCT.Location = New System.Drawing.Point(189, 189)
        Me.txtTCT.MaxLength = 25
        Me.txtTCT.Name = "txtTCT"
        Me.txtTCT.PreventEnterBeep = True
        Me.txtTCT.Size = New System.Drawing.Size(202, 23)
        Me.txtTCT.TabIndex = 25
        Me.txtTCT.Visible = False
        Me.txtTCT.WatermarkText = "TCT No."
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Red
        Me.LabelX5.Location = New System.Drawing.Point(397, 181)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(299, 36)
        Me.LabelX5.TabIndex = 1551
        Me.LabelX5.Text = "Note : New Title Number. If TCT was not change, please enter the old TCT."
        Me.LabelX5.Visible = False
        Me.LabelX5.WordWrap = True
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
        Me.LabelX6.Location = New System.Drawing.Point(397, 73)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(132, 23)
        Me.LabelX6.TabIndex = 1552
        Me.LabelX6.Text = "Asset Number :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX6.Visible = False
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
        Me.LabelX7.Location = New System.Drawing.Point(397, 102)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(132, 23)
        Me.LabelX7.TabIndex = 1553
        Me.LabelX7.Text = "Account No. :"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX7.Visible = False
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
        Me.LabelX8.Location = New System.Drawing.Point(397, 131)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(132, 23)
        Me.LabelX8.TabIndex = 1554
        Me.LabelX8.Text = "Title Number (Old) :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX8.Visible = False
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
        Me.LabelX9.Location = New System.Drawing.Point(397, 160)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(132, 23)
        Me.LabelX9.TabIndex = 1555
        Me.LabelX9.Text = "Area (SQM) :"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX9.Visible = False
        '
        'lblArea
        '
        Me.lblArea.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArea.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArea.Location = New System.Drawing.Point(535, 160)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(161, 23)
        Me.lblArea.TabIndex = 1559
        Me.lblArea.Visible = False
        '
        'lblTCTN
        '
        Me.lblTCTN.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTCTN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTCTN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTCTN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTCTN.Location = New System.Drawing.Point(535, 131)
        Me.lblTCTN.Name = "lblTCTN"
        Me.lblTCTN.Size = New System.Drawing.Size(161, 23)
        Me.lblTCTN.TabIndex = 1558
        Me.lblTCTN.Visible = False
        '
        'lblAccountN
        '
        Me.lblAccountN.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblAccountN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAccountN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAccountN.Location = New System.Drawing.Point(535, 102)
        Me.lblAccountN.Name = "lblAccountN"
        Me.lblAccountN.Size = New System.Drawing.Size(161, 23)
        Me.lblAccountN.TabIndex = 1557
        Me.lblAccountN.Visible = False
        '
        'lblAssetN
        '
        Me.lblAssetN.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblAssetN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAssetN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAssetN.Location = New System.Drawing.Point(535, 73)
        Me.lblAssetN.Name = "lblAssetN"
        Me.lblAssetN.Size = New System.Drawing.Size(161, 23)
        Me.lblAssetN.TabIndex = 1556
        Me.lblAssetN.Visible = False
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(672, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'FrmRedemptionPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(708, 256)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.lblTCTN)
        Me.Controls.Add(Me.lblAccountN)
        Me.Controls.Add(Me.lblAssetN)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txtTCT)
        Me.Controls.Add(Me.dtpConsolidation)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.iDays)
        Me.Controls.Add(Me.LabelX36)
        Me.Controls.Add(Me.dtpReceived)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.dtpCOS)
        Me.Controls.Add(Me.lblCOS)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmRedemptionPeriod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.dtpCOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpConsolidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dtpCOS As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lblCOS As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpReceived As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iDays As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dtpConsolidation As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents txtTCT As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArea As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTCTN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAccountN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAssetN As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
