<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRequirements
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
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.txtDocument = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.dtpReceived = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemarks = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cbxIncomplete = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxComplete = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnAttach = New DevComponents.DotNetBar.ButtonX()
        Me.btnPDC = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx3.SuspendLayout()
        CType(Me.dtpReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnRefresh)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 201)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(786, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 55
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(238, 3)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "Close"
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.FSFC_System.My.Resources.Resources.Refresh
        Me.btnRefresh.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnRefresh.Location = New System.Drawing.Point(125, 3)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(107, 30)
        Me.btnRefresh.TabIndex = 45
        Me.btnRefresh.Text = "Re&fresh"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(12, 3)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 40
        Me.btnSave.Text = "&Save"
        '
        'txtDocument
        '
        '
        '
        '
        Me.txtDocument.Border.Class = "TextBoxBorder"
        Me.txtDocument.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDocument.Enabled = False
        Me.txtDocument.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocument.Location = New System.Drawing.Point(125, 12)
        Me.txtDocument.Name = "txtDocument"
        Me.txtDocument.PreventEnterBeep = True
        Me.txtDocument.Size = New System.Drawing.Size(640, 23)
        Me.txtDocument.TabIndex = 5
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
        Me.LabelX13.Location = New System.Drawing.Point(14, 12)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(105, 23)
        Me.LabelX13.TabIndex = 31
        Me.LabelX13.Text = "Document :"
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.dtpReceived.CustomFormat = "MMMM dd, yyyy hh:mm:ss tt"
        Me.dtpReceived.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReceived.ForeColor = System.Drawing.Color.Black
        Me.dtpReceived.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpReceived.IsPopupCalendarOpen = False
        Me.dtpReceived.Location = New System.Drawing.Point(125, 41)
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
        Me.dtpReceived.Size = New System.Drawing.Size(256, 23)
        Me.dtpReceived.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpReceived.TabIndex = 10
        Me.dtpReceived.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX10.Location = New System.Drawing.Point(-31, 41)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(150, 23)
        Me.LabelX10.TabIndex = 33
        Me.LabelX10.Text = "Date Received :"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtRemarks
        '
        '
        '
        '
        Me.txtRemarks.Border.Class = "TextBoxBorder"
        Me.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemarks.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(125, 99)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.PreventEnterBeep = True
        Me.txtRemarks.Size = New System.Drawing.Size(640, 23)
        Me.txtRemarks.TabIndex = 35
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(14, 99)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(105, 23)
        Me.LabelX1.TabIndex = 35
        Me.LabelX1.Text = "Remarks :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxIncomplete
        '
        Me.cbxIncomplete.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxIncomplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxIncomplete.Checked = True
        Me.cbxIncomplete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxIncomplete.CheckValue = "Y"
        Me.cbxIncomplete.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxIncomplete.Location = New System.Drawing.Point(228, 70)
        Me.cbxIncomplete.Name = "cbxIncomplete"
        Me.cbxIncomplete.Size = New System.Drawing.Size(103, 23)
        Me.cbxIncomplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxIncomplete.TabIndex = 30
        Me.cbxIncomplete.Text = "Incomplete"
        '
        'cbxComplete
        '
        Me.cbxComplete.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxComplete.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxComplete.Location = New System.Drawing.Point(125, 70)
        Me.cbxComplete.Name = "cbxComplete"
        Me.cbxComplete.Size = New System.Drawing.Size(103, 23)
        Me.cbxComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxComplete.TabIndex = 25
        Me.cbxComplete.Text = "Complete"
        '
        'btnAttach
        '
        Me.btnAttach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAttach.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAttach.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttach.Image = Global.FSFC_System.My.Resources.Resources.Upload
        Me.btnAttach.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnAttach.Location = New System.Drawing.Point(387, 41)
        Me.btnAttach.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(107, 30)
        Me.btnAttach.TabIndex = 15
        Me.btnAttach.Text = "Attach Document"
        '
        'btnPDC
        '
        Me.btnPDC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPDC.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPDC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPDC.Image = Global.FSFC_System.My.Resources.Resources.Cheque
        Me.btnPDC.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPDC.Location = New System.Drawing.Point(500, 41)
        Me.btnPDC.Name = "btnPDC"
        Me.btnPDC.Size = New System.Drawing.Size(107, 31)
        Me.btnPDC.TabIndex = 57
        Me.btnPDC.Text = "Check Registry"
        Me.btnPDC.Visible = False
        '
        'FrmRequirements
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(786, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPDC)
        Me.Controls.Add(Me.btnAttach)
        Me.Controls.Add(Me.cbxIncomplete)
        Me.Controls.Add(Me.cbxComplete)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.dtpReceived)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.txtDocument)
        Me.Controls.Add(Me.LabelX13)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmRequirements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.dtpReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnAttach As DevComponents.DotNetBar.ButtonX
    Public WithEvents txtDocument As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents dtpReceived As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents txtRemarks As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents cbxIncomplete As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents cbxComplete As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnPDC As DevComponents.DotNetBar.ButtonX
End Class
