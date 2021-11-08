<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmITLDashboard
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
        Me.Chart1 = New DevExpress.XtraCharts.ChartControl()
        Me.gCivilStatus = New DevExpress.XtraEditors.GroupControl()
        Me.lblFullyPaidP = New DevComponents.DotNetBar.LabelX()
        Me.lblFullyPaidN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.lblWrittenOffP = New DevComponents.DotNetBar.LabelX()
        Me.lblWrittenOffN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchivedP = New DevComponents.DotNetBar.LabelX()
        Me.lblArchivedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissedP = New DevComponents.DotNetBar.LabelX()
        Me.lblActiveP = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissedN = New DevComponents.DotNetBar.LabelX()
        Me.lblActiveN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.btnChangeView = New DevComponents.DotNetBar.ButtonX()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.lblCase5P = New DevComponents.DotNetBar.LabelX()
        Me.lblCase5N = New DevComponents.DotNetBar.LabelX()
        Me.lblCase5B = New DevComponents.DotNetBar.LabelX()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.lblCase4P = New DevComponents.DotNetBar.LabelX()
        Me.lblCase4N = New DevComponents.DotNetBar.LabelX()
        Me.lblCase4B = New DevComponents.DotNetBar.LabelX()
        Me.lblCase3P = New DevComponents.DotNetBar.LabelX()
        Me.lblCase3N = New DevComponents.DotNetBar.LabelX()
        Me.lblCase3B = New DevComponents.DotNetBar.LabelX()
        Me.lblCase2P = New DevComponents.DotNetBar.LabelX()
        Me.lblCase1P = New DevComponents.DotNetBar.LabelX()
        Me.lblCase2N = New DevComponents.DotNetBar.LabelX()
        Me.lblCase1N = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.lblCase2B = New DevComponents.DotNetBar.LabelX()
        Me.lblCase1B = New DevComponents.DotNetBar.LabelX()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.lblBV5P = New DevComponents.DotNetBar.LabelX()
        Me.lblBV5A = New DevComponents.DotNetBar.LabelX()
        Me.lblBV5B = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.lblBV4P = New DevComponents.DotNetBar.LabelX()
        Me.lblBV4A = New DevComponents.DotNetBar.LabelX()
        Me.lblBV4B = New DevComponents.DotNetBar.LabelX()
        Me.lblBV3P = New DevComponents.DotNetBar.LabelX()
        Me.lblBV3A = New DevComponents.DotNetBar.LabelX()
        Me.lblBV3B = New DevComponents.DotNetBar.LabelX()
        Me.lblBV2P = New DevComponents.DotNetBar.LabelX()
        Me.lblBV1P = New DevComponents.DotNetBar.LabelX()
        Me.lblBV2A = New DevComponents.DotNetBar.LabelX()
        Me.lblBV1A = New DevComponents.DotNetBar.LabelX()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX49 = New DevComponents.DotNetBar.LabelX()
        Me.lblBV2B = New DevComponents.DotNetBar.LabelX()
        Me.lblBV1B = New DevComponents.DotNetBar.LabelX()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblCollected5P = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected5A = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected5B = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected4P = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected4A = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected4B = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected3P = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected3A = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected3B = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected2P = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected1P = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected2A = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected1A = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected2B = New DevComponents.DotNetBar.LabelX()
        Me.lblCollected1B = New DevComponents.DotNetBar.LabelX()
        Me.pCases = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.pBookValue = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX61 = New DevComponents.DotNetBar.LabelX()
        Me.pCollected = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX62 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gCivilStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gCivilStatus.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.pCases.SuspendLayout()
        Me.pBookValue.SuspendLayout()
        Me.pCollected.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        XyDiagram1.AxisX.Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Interlaced = True
        XyDiagram1.AxisY.Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram1.DefaultPane.BorderVisible = False
        Me.Chart1.Diagram = XyDiagram1
        Me.Chart1.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.Chart1.Location = New System.Drawing.Point(12, 326)
        Me.Chart1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Chart1.Name = "Chart1"
        Me.Chart1.PaletteName = "Case Palette"
        Me.Chart1.PaletteRepository.Add("Case Palette", New DevExpress.XtraCharts.Palette("Case Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(89, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(89, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(0, Byte), Integer)))}))
        Me.Chart1.PaletteRepository.Add("FSFC Palette", New DevExpress.XtraCharts.Palette("FSFC Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Maroon, System.Drawing.Color.Maroon), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(51, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(51, Byte), Integer)))}))
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
        Me.Chart1.Size = New System.Drawing.Size(1140, 355)
        Me.Chart1.TabIndex = 1059
        ChartTitle1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartTitle1.Text = "Number of Cases"
        ChartTitle1.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.Chart1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'gCivilStatus
        '
        Me.gCivilStatus.Appearance.BackColor = System.Drawing.Color.White
        Me.gCivilStatus.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gCivilStatus.Appearance.Options.UseBackColor = True
        Me.gCivilStatus.Appearance.Options.UseFont = True
        Me.gCivilStatus.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gCivilStatus.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gCivilStatus.AppearanceCaption.Options.UseFont = True
        Me.gCivilStatus.AppearanceCaption.Options.UseForeColor = True
        Me.gCivilStatus.Controls.Add(Me.lblFullyPaidP)
        Me.gCivilStatus.Controls.Add(Me.lblFullyPaidN)
        Me.gCivilStatus.Controls.Add(Me.LabelX54)
        Me.gCivilStatus.Controls.Add(Me.lblWrittenOffP)
        Me.gCivilStatus.Controls.Add(Me.lblWrittenOffN)
        Me.gCivilStatus.Controls.Add(Me.LabelX22)
        Me.gCivilStatus.Controls.Add(Me.lblArchivedP)
        Me.gCivilStatus.Controls.Add(Me.lblArchivedN)
        Me.gCivilStatus.Controls.Add(Me.LabelX19)
        Me.gCivilStatus.Controls.Add(Me.lblDismissedP)
        Me.gCivilStatus.Controls.Add(Me.lblActiveP)
        Me.gCivilStatus.Controls.Add(Me.lblDismissedN)
        Me.gCivilStatus.Controls.Add(Me.lblActiveN)
        Me.gCivilStatus.Controls.Add(Me.LabelX13)
        Me.gCivilStatus.Controls.Add(Me.LabelX14)
        Me.gCivilStatus.Controls.Add(Me.LabelX15)
        Me.gCivilStatus.Controls.Add(Me.LabelX16)
        Me.gCivilStatus.Location = New System.Drawing.Point(12, 94)
        Me.gCivilStatus.LookAndFeel.SkinName = "Darkroom"
        Me.gCivilStatus.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gCivilStatus.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gCivilStatus.Name = "gCivilStatus"
        Me.gCivilStatus.Size = New System.Drawing.Size(273, 226)
        Me.gCivilStatus.TabIndex = 1060
        Me.gCivilStatus.Text = "Case Status"
        '
        'lblFullyPaidP
        '
        '
        '
        '
        Me.lblFullyPaidP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFullyPaidP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFullyPaidP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFullyPaidP.Location = New System.Drawing.Point(191, 187)
        Me.lblFullyPaidP.Name = "lblFullyPaidP"
        Me.lblFullyPaidP.Size = New System.Drawing.Size(80, 25)
        Me.lblFullyPaidP.TabIndex = 1053
        Me.lblFullyPaidP.Text = "3.29 %"
        Me.lblFullyPaidP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblFullyPaidN
        '
        '
        '
        '
        Me.lblFullyPaidN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFullyPaidN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFullyPaidN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFullyPaidN.Location = New System.Drawing.Point(105, 187)
        Me.lblFullyPaidN.Name = "lblFullyPaidN"
        Me.lblFullyPaidN.Size = New System.Drawing.Size(80, 25)
        Me.lblFullyPaidN.TabIndex = 1052
        Me.lblFullyPaidN.Text = "291"
        Me.lblFullyPaidN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX54
        '
        Me.LabelX54.BackColor = System.Drawing.Color.Olive
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX54.ForeColor = System.Drawing.Color.White
        Me.LabelX54.Location = New System.Drawing.Point(5, 187)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(94, 25)
        Me.LabelX54.TabIndex = 1051
        Me.LabelX54.Text = "Fully Paid"
        Me.LabelX54.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblWrittenOffP
        '
        '
        '
        '
        Me.lblWrittenOffP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWrittenOffP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblWrittenOffP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblWrittenOffP.Location = New System.Drawing.Point(191, 156)
        Me.lblWrittenOffP.Name = "lblWrittenOffP"
        Me.lblWrittenOffP.Size = New System.Drawing.Size(80, 25)
        Me.lblWrittenOffP.TabIndex = 1050
        Me.lblWrittenOffP.Text = "3.29 %"
        Me.lblWrittenOffP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblWrittenOffN
        '
        '
        '
        '
        Me.lblWrittenOffN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWrittenOffN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblWrittenOffN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblWrittenOffN.Location = New System.Drawing.Point(105, 156)
        Me.lblWrittenOffN.Name = "lblWrittenOffN"
        Me.lblWrittenOffN.Size = New System.Drawing.Size(80, 25)
        Me.lblWrittenOffN.TabIndex = 1049
        Me.lblWrittenOffN.Text = "291"
        Me.lblWrittenOffN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX22.ForeColor = System.Drawing.Color.White
        Me.LabelX22.Location = New System.Drawing.Point(5, 156)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(94, 25)
        Me.LabelX22.TabIndex = 1048
        Me.LabelX22.Text = "Written Off"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchivedP
        '
        '
        '
        '
        Me.lblArchivedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchivedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblArchivedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchivedP.Location = New System.Drawing.Point(191, 125)
        Me.lblArchivedP.Name = "lblArchivedP"
        Me.lblArchivedP.Size = New System.Drawing.Size(80, 25)
        Me.lblArchivedP.TabIndex = 1047
        Me.lblArchivedP.Text = "13.29 %"
        Me.lblArchivedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchivedN
        '
        '
        '
        '
        Me.lblArchivedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchivedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblArchivedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchivedN.Location = New System.Drawing.Point(105, 125)
        Me.lblArchivedN.Name = "lblArchivedN"
        Me.lblArchivedN.Size = New System.Drawing.Size(80, 25)
        Me.lblArchivedN.TabIndex = 1046
        Me.lblArchivedN.Text = "1,592"
        Me.lblArchivedN.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.LabelX19.Location = New System.Drawing.Point(5, 125)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(94, 25)
        Me.LabelX19.TabIndex = 1045
        Me.LabelX19.Text = "Archived"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissedP
        '
        '
        '
        '
        Me.lblDismissedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDismissedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissedP.Location = New System.Drawing.Point(191, 94)
        Me.lblDismissedP.Name = "lblDismissedP"
        Me.lblDismissedP.Size = New System.Drawing.Size(80, 25)
        Me.lblDismissedP.TabIndex = 1044
        Me.lblDismissedP.Text = "52.29 %"
        Me.lblDismissedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblActiveP
        '
        '
        '
        '
        Me.lblActiveP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblActiveP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblActiveP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblActiveP.Location = New System.Drawing.Point(191, 63)
        Me.lblActiveP.Name = "lblActiveP"
        Me.lblActiveP.Size = New System.Drawing.Size(80, 25)
        Me.lblActiveP.TabIndex = 1043
        Me.lblActiveP.Text = "23.52 %"
        Me.lblActiveP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissedN
        '
        '
        '
        '
        Me.lblDismissedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDismissedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissedN.Location = New System.Drawing.Point(105, 94)
        Me.lblDismissedN.Name = "lblDismissedN"
        Me.lblDismissedN.Size = New System.Drawing.Size(80, 25)
        Me.lblDismissedN.TabIndex = 1042
        Me.lblDismissedN.Text = "3,502"
        Me.lblDismissedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblActiveN
        '
        '
        '
        '
        Me.lblActiveN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblActiveN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblActiveN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblActiveN.Location = New System.Drawing.Point(105, 63)
        Me.lblActiveN.Name = "lblActiveN"
        Me.lblActiveN.Size = New System.Drawing.Size(80, 25)
        Me.lblActiveN.TabIndex = 1041
        Me.lblActiveN.Text = "2,520"
        Me.lblActiveN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX13.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX13.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.LabelX14.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX14.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.LabelX15.BackColor = System.Drawing.Color.IndianRed
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX15.ForeColor = System.Drawing.Color.White
        Me.LabelX15.Location = New System.Drawing.Point(5, 94)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(94, 25)
        Me.LabelX15.TabIndex = 1038
        Me.LabelX15.Text = "Dismissed"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.LabelX16.Text = "Active"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'btnChangeView
        '
        Me.btnChangeView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnChangeView.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnChangeView.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeView.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnChangeView.Location = New System.Drawing.Point(17, 333)
        Me.btnChangeView.Name = "btnChangeView"
        Me.btnChangeView.Size = New System.Drawing.Size(107, 30)
        Me.btnChangeView.TabIndex = 1061
        Me.btnChangeView.Text = "Change View"
        Me.btnChangeView.Visible = False
        '
        'GroupControl2
        '
        Me.GroupControl2.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl2.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.Appearance.Options.UseBackColor = True
        Me.GroupControl2.Appearance.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.lblCase5P)
        Me.GroupControl2.Controls.Add(Me.lblCase5N)
        Me.GroupControl2.Controls.Add(Me.lblCase5B)
        Me.GroupControl2.Controls.Add(Me.LabelX37)
        Me.GroupControl2.Controls.Add(Me.lblCase4P)
        Me.GroupControl2.Controls.Add(Me.lblCase4N)
        Me.GroupControl2.Controls.Add(Me.lblCase4B)
        Me.GroupControl2.Controls.Add(Me.lblCase3P)
        Me.GroupControl2.Controls.Add(Me.lblCase3N)
        Me.GroupControl2.Controls.Add(Me.lblCase3B)
        Me.GroupControl2.Controls.Add(Me.lblCase2P)
        Me.GroupControl2.Controls.Add(Me.lblCase1P)
        Me.GroupControl2.Controls.Add(Me.lblCase2N)
        Me.GroupControl2.Controls.Add(Me.lblCase1N)
        Me.GroupControl2.Controls.Add(Me.LabelX33)
        Me.GroupControl2.Controls.Add(Me.LabelX34)
        Me.GroupControl2.Controls.Add(Me.lblCase2B)
        Me.GroupControl2.Controls.Add(Me.lblCase1B)
        Me.GroupControl2.Location = New System.Drawing.Point(291, 94)
        Me.GroupControl2.LookAndFeel.SkinName = "Darkroom"
        Me.GroupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(273, 226)
        Me.GroupControl2.TabIndex = 1064
        Me.GroupControl2.Text = "Top Branches Number of Cases"
        '
        'lblCase5P
        '
        '
        '
        '
        Me.lblCase5P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase5P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase5P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase5P.Location = New System.Drawing.Point(191, 187)
        Me.lblCase5P.Name = "lblCase5P"
        Me.lblCase5P.Size = New System.Drawing.Size(80, 25)
        Me.lblCase5P.TabIndex = 1068
        Me.lblCase5P.Text = "0.00 %"
        Me.lblCase5P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase5N
        '
        '
        '
        '
        Me.lblCase5N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase5N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase5N.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase5N.Location = New System.Drawing.Point(105, 187)
        Me.lblCase5N.Name = "lblCase5N"
        Me.lblCase5N.Size = New System.Drawing.Size(80, 25)
        Me.lblCase5N.TabIndex = 1067
        Me.lblCase5N.Text = "0"
        Me.lblCase5N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase5B
        '
        '
        '
        '
        Me.lblCase5B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase5B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase5B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase5B.Location = New System.Drawing.Point(5, 187)
        Me.lblCase5B.Name = "lblCase5B"
        Me.lblCase5B.Size = New System.Drawing.Size(94, 25)
        Me.lblCase5B.TabIndex = 1066
        Me.lblCase5B.Text = "5. "
        '
        'LabelX37
        '
        '
        '
        '
        Me.LabelX37.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX37.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX37.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX37.Location = New System.Drawing.Point(6, 32)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(93, 25)
        Me.LabelX37.TabIndex = 1065
        Me.LabelX37.Text = "Branches"
        Me.LabelX37.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase4P
        '
        '
        '
        '
        Me.lblCase4P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase4P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase4P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase4P.Location = New System.Drawing.Point(191, 156)
        Me.lblCase4P.Name = "lblCase4P"
        Me.lblCase4P.Size = New System.Drawing.Size(80, 25)
        Me.lblCase4P.TabIndex = 1050
        Me.lblCase4P.Text = "0.00 %"
        Me.lblCase4P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase4N
        '
        '
        '
        '
        Me.lblCase4N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase4N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase4N.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase4N.Location = New System.Drawing.Point(105, 156)
        Me.lblCase4N.Name = "lblCase4N"
        Me.lblCase4N.Size = New System.Drawing.Size(80, 25)
        Me.lblCase4N.TabIndex = 1049
        Me.lblCase4N.Text = "0"
        Me.lblCase4N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase4B
        '
        '
        '
        '
        Me.lblCase4B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase4B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase4B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase4B.Location = New System.Drawing.Point(5, 156)
        Me.lblCase4B.Name = "lblCase4B"
        Me.lblCase4B.Size = New System.Drawing.Size(94, 25)
        Me.lblCase4B.TabIndex = 1048
        Me.lblCase4B.Text = "4."
        '
        'lblCase3P
        '
        '
        '
        '
        Me.lblCase3P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase3P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase3P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase3P.Location = New System.Drawing.Point(191, 125)
        Me.lblCase3P.Name = "lblCase3P"
        Me.lblCase3P.Size = New System.Drawing.Size(80, 25)
        Me.lblCase3P.TabIndex = 1047
        Me.lblCase3P.Text = "0.00 %"
        Me.lblCase3P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase3N
        '
        '
        '
        '
        Me.lblCase3N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase3N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase3N.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase3N.Location = New System.Drawing.Point(105, 125)
        Me.lblCase3N.Name = "lblCase3N"
        Me.lblCase3N.Size = New System.Drawing.Size(80, 25)
        Me.lblCase3N.TabIndex = 1046
        Me.lblCase3N.Text = "0"
        Me.lblCase3N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase3B
        '
        '
        '
        '
        Me.lblCase3B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase3B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase3B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase3B.Location = New System.Drawing.Point(5, 125)
        Me.lblCase3B.Name = "lblCase3B"
        Me.lblCase3B.Size = New System.Drawing.Size(94, 25)
        Me.lblCase3B.TabIndex = 1045
        Me.lblCase3B.Text = "3. "
        '
        'lblCase2P
        '
        '
        '
        '
        Me.lblCase2P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase2P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase2P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase2P.Location = New System.Drawing.Point(191, 94)
        Me.lblCase2P.Name = "lblCase2P"
        Me.lblCase2P.Size = New System.Drawing.Size(80, 25)
        Me.lblCase2P.TabIndex = 1044
        Me.lblCase2P.Text = "0.00 %"
        Me.lblCase2P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase1P
        '
        '
        '
        '
        Me.lblCase1P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase1P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase1P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase1P.Location = New System.Drawing.Point(191, 63)
        Me.lblCase1P.Name = "lblCase1P"
        Me.lblCase1P.Size = New System.Drawing.Size(80, 25)
        Me.lblCase1P.TabIndex = 1043
        Me.lblCase1P.Text = "0.00 %"
        Me.lblCase1P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase2N
        '
        '
        '
        '
        Me.lblCase2N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase2N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase2N.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase2N.Location = New System.Drawing.Point(105, 94)
        Me.lblCase2N.Name = "lblCase2N"
        Me.lblCase2N.Size = New System.Drawing.Size(80, 25)
        Me.lblCase2N.TabIndex = 1042
        Me.lblCase2N.Text = "0"
        Me.lblCase2N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase1N
        '
        '
        '
        '
        Me.lblCase1N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase1N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase1N.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase1N.Location = New System.Drawing.Point(105, 63)
        Me.lblCase1N.Name = "lblCase1N"
        Me.lblCase1N.Size = New System.Drawing.Size(80, 25)
        Me.lblCase1N.TabIndex = 1041
        Me.lblCase1N.Text = "0"
        Me.lblCase1N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX33
        '
        '
        '
        '
        Me.LabelX33.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX33.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX33.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX33.Location = New System.Drawing.Point(191, 32)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(80, 25)
        Me.LabelX33.TabIndex = 1040
        Me.LabelX33.Text = "Percentage"
        Me.LabelX33.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX34
        '
        '
        '
        '
        Me.LabelX34.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX34.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX34.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX34.Location = New System.Drawing.Point(105, 32)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(80, 25)
        Me.LabelX34.TabIndex = 1039
        Me.LabelX34.Text = "Number"
        Me.LabelX34.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCase2B
        '
        '
        '
        '
        Me.lblCase2B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase2B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase2B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase2B.Location = New System.Drawing.Point(5, 94)
        Me.lblCase2B.Name = "lblCase2B"
        Me.lblCase2B.Size = New System.Drawing.Size(94, 25)
        Me.lblCase2B.TabIndex = 1038
        Me.lblCase2B.Text = "2. "
        '
        'lblCase1B
        '
        '
        '
        '
        Me.lblCase1B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCase1B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCase1B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCase1B.Location = New System.Drawing.Point(5, 63)
        Me.lblCase1B.Name = "lblCase1B"
        Me.lblCase1B.Size = New System.Drawing.Size(94, 25)
        Me.lblCase1B.TabIndex = 1037
        Me.lblCase1B.Text = "1. "
        '
        'GroupControl3
        '
        Me.GroupControl3.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl3.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl3.Appearance.Options.UseBackColor = True
        Me.GroupControl3.Appearance.Options.UseFont = True
        Me.GroupControl3.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl3.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GroupControl3.AppearanceCaption.Options.UseFont = True
        Me.GroupControl3.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl3.Controls.Add(Me.lblBV5P)
        Me.GroupControl3.Controls.Add(Me.lblBV5A)
        Me.GroupControl3.Controls.Add(Me.lblBV5B)
        Me.GroupControl3.Controls.Add(Me.LabelX21)
        Me.GroupControl3.Controls.Add(Me.lblBV4P)
        Me.GroupControl3.Controls.Add(Me.lblBV4A)
        Me.GroupControl3.Controls.Add(Me.lblBV4B)
        Me.GroupControl3.Controls.Add(Me.lblBV3P)
        Me.GroupControl3.Controls.Add(Me.lblBV3A)
        Me.GroupControl3.Controls.Add(Me.lblBV3B)
        Me.GroupControl3.Controls.Add(Me.lblBV2P)
        Me.GroupControl3.Controls.Add(Me.lblBV1P)
        Me.GroupControl3.Controls.Add(Me.lblBV2A)
        Me.GroupControl3.Controls.Add(Me.lblBV1A)
        Me.GroupControl3.Controls.Add(Me.LabelX48)
        Me.GroupControl3.Controls.Add(Me.LabelX49)
        Me.GroupControl3.Controls.Add(Me.lblBV2B)
        Me.GroupControl3.Controls.Add(Me.lblBV1B)
        Me.GroupControl3.Location = New System.Drawing.Point(570, 94)
        Me.GroupControl3.LookAndFeel.SkinName = "Darkroom"
        Me.GroupControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.GroupControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(288, 226)
        Me.GroupControl3.TabIndex = 1065
        Me.GroupControl3.Text = "Top Branches Book Value"
        '
        'lblBV5P
        '
        '
        '
        '
        Me.lblBV5P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV5P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV5P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV5P.Location = New System.Drawing.Point(202, 187)
        Me.lblBV5P.Name = "lblBV5P"
        Me.lblBV5P.Size = New System.Drawing.Size(80, 25)
        Me.lblBV5P.TabIndex = 1068
        Me.lblBV5P.Text = "0.00 %"
        Me.lblBV5P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV5A
        '
        '
        '
        '
        Me.lblBV5A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV5A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV5A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV5A.Location = New System.Drawing.Point(84, 187)
        Me.lblBV5A.Name = "lblBV5A"
        Me.lblBV5A.Size = New System.Drawing.Size(112, 25)
        Me.lblBV5A.TabIndex = 1067
        Me.lblBV5A.Text = "0.00"
        Me.lblBV5A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblBV5B
        '
        '
        '
        '
        Me.lblBV5B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV5B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV5B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV5B.Location = New System.Drawing.Point(5, 187)
        Me.lblBV5B.Name = "lblBV5B"
        Me.lblBV5B.Size = New System.Drawing.Size(73, 25)
        Me.lblBV5B.TabIndex = 1066
        Me.lblBV5B.Text = "5. "
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX21.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX21.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX21.Location = New System.Drawing.Point(6, 32)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(72, 25)
        Me.LabelX21.TabIndex = 1065
        Me.LabelX21.Text = "Branches"
        Me.LabelX21.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV4P
        '
        '
        '
        '
        Me.lblBV4P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV4P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV4P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV4P.Location = New System.Drawing.Point(202, 156)
        Me.lblBV4P.Name = "lblBV4P"
        Me.lblBV4P.Size = New System.Drawing.Size(80, 25)
        Me.lblBV4P.TabIndex = 1050
        Me.lblBV4P.Text = "0.00 %"
        Me.lblBV4P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV4A
        '
        '
        '
        '
        Me.lblBV4A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV4A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV4A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV4A.Location = New System.Drawing.Point(84, 156)
        Me.lblBV4A.Name = "lblBV4A"
        Me.lblBV4A.Size = New System.Drawing.Size(112, 25)
        Me.lblBV4A.TabIndex = 1049
        Me.lblBV4A.Text = "0.00"
        Me.lblBV4A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblBV4B
        '
        '
        '
        '
        Me.lblBV4B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV4B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV4B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV4B.Location = New System.Drawing.Point(5, 156)
        Me.lblBV4B.Name = "lblBV4B"
        Me.lblBV4B.Size = New System.Drawing.Size(73, 25)
        Me.lblBV4B.TabIndex = 1048
        Me.lblBV4B.Text = "4. "
        '
        'lblBV3P
        '
        '
        '
        '
        Me.lblBV3P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV3P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV3P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV3P.Location = New System.Drawing.Point(202, 125)
        Me.lblBV3P.Name = "lblBV3P"
        Me.lblBV3P.Size = New System.Drawing.Size(80, 25)
        Me.lblBV3P.TabIndex = 1047
        Me.lblBV3P.Text = "0.00 %"
        Me.lblBV3P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV3A
        '
        '
        '
        '
        Me.lblBV3A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV3A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV3A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV3A.Location = New System.Drawing.Point(84, 125)
        Me.lblBV3A.Name = "lblBV3A"
        Me.lblBV3A.Size = New System.Drawing.Size(112, 25)
        Me.lblBV3A.TabIndex = 1046
        Me.lblBV3A.Text = "0.00"
        Me.lblBV3A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblBV3B
        '
        '
        '
        '
        Me.lblBV3B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV3B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV3B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV3B.Location = New System.Drawing.Point(5, 125)
        Me.lblBV3B.Name = "lblBV3B"
        Me.lblBV3B.Size = New System.Drawing.Size(73, 25)
        Me.lblBV3B.TabIndex = 1045
        Me.lblBV3B.Text = "3. "
        '
        'lblBV2P
        '
        '
        '
        '
        Me.lblBV2P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV2P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV2P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV2P.Location = New System.Drawing.Point(202, 94)
        Me.lblBV2P.Name = "lblBV2P"
        Me.lblBV2P.Size = New System.Drawing.Size(80, 25)
        Me.lblBV2P.TabIndex = 1044
        Me.lblBV2P.Text = "0.00 %"
        Me.lblBV2P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV1P
        '
        '
        '
        '
        Me.lblBV1P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV1P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV1P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV1P.Location = New System.Drawing.Point(202, 63)
        Me.lblBV1P.Name = "lblBV1P"
        Me.lblBV1P.Size = New System.Drawing.Size(80, 25)
        Me.lblBV1P.TabIndex = 1043
        Me.lblBV1P.Text = "0.00 %"
        Me.lblBV1P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV2A
        '
        '
        '
        '
        Me.lblBV2A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV2A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV2A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV2A.Location = New System.Drawing.Point(84, 94)
        Me.lblBV2A.Name = "lblBV2A"
        Me.lblBV2A.Size = New System.Drawing.Size(112, 25)
        Me.lblBV2A.TabIndex = 1042
        Me.lblBV2A.Text = "0.00"
        Me.lblBV2A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblBV1A
        '
        '
        '
        '
        Me.lblBV1A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV1A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV1A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV1A.Location = New System.Drawing.Point(84, 63)
        Me.lblBV1A.Name = "lblBV1A"
        Me.lblBV1A.Size = New System.Drawing.Size(112, 25)
        Me.lblBV1A.TabIndex = 1041
        Me.lblBV1A.Text = "0.00"
        Me.lblBV1A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX48
        '
        '
        '
        '
        Me.LabelX48.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX48.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX48.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX48.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX48.Location = New System.Drawing.Point(202, 32)
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Size = New System.Drawing.Size(80, 25)
        Me.LabelX48.TabIndex = 1040
        Me.LabelX48.Text = "Percentage"
        Me.LabelX48.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX49
        '
        '
        '
        '
        Me.LabelX49.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX49.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX49.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX49.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX49.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX49.Location = New System.Drawing.Point(84, 32)
        Me.LabelX49.Name = "LabelX49"
        Me.LabelX49.Size = New System.Drawing.Size(112, 25)
        Me.LabelX49.TabIndex = 1039
        Me.LabelX49.Text = "Book Value"
        Me.LabelX49.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblBV2B
        '
        '
        '
        '
        Me.lblBV2B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV2B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV2B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV2B.Location = New System.Drawing.Point(5, 94)
        Me.lblBV2B.Name = "lblBV2B"
        Me.lblBV2B.Size = New System.Drawing.Size(73, 25)
        Me.lblBV2B.TabIndex = 1038
        Me.lblBV2B.Text = "2. "
        '
        'lblBV1B
        '
        '
        '
        '
        Me.lblBV1B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBV1B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblBV1B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBV1B.Location = New System.Drawing.Point(5, 63)
        Me.lblBV1B.Name = "lblBV1B"
        Me.lblBV1B.Size = New System.Drawing.Size(73, 25)
        Me.lblBV1B.TabIndex = 1037
        Me.lblBV1B.Text = "1. "
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl1.Controls.Add(Me.lblCollected5P)
        Me.GroupControl1.Controls.Add(Me.lblCollected5A)
        Me.GroupControl1.Controls.Add(Me.lblCollected5B)
        Me.GroupControl1.Controls.Add(Me.LabelX1)
        Me.GroupControl1.Controls.Add(Me.lblCollected4P)
        Me.GroupControl1.Controls.Add(Me.lblCollected4A)
        Me.GroupControl1.Controls.Add(Me.lblCollected4B)
        Me.GroupControl1.Controls.Add(Me.lblCollected3P)
        Me.GroupControl1.Controls.Add(Me.lblCollected3A)
        Me.GroupControl1.Controls.Add(Me.lblCollected3B)
        Me.GroupControl1.Controls.Add(Me.lblCollected2P)
        Me.GroupControl1.Controls.Add(Me.lblCollected1P)
        Me.GroupControl1.Controls.Add(Me.lblCollected2A)
        Me.GroupControl1.Controls.Add(Me.lblCollected1A)
        Me.GroupControl1.Controls.Add(Me.LabelX12)
        Me.GroupControl1.Controls.Add(Me.LabelX17)
        Me.GroupControl1.Controls.Add(Me.lblCollected2B)
        Me.GroupControl1.Controls.Add(Me.lblCollected1B)
        Me.GroupControl1.Location = New System.Drawing.Point(864, 94)
        Me.GroupControl1.LookAndFeel.SkinName = "Darkroom"
        Me.GroupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(288, 226)
        Me.GroupControl1.TabIndex = 1066
        Me.GroupControl1.Text = "Top Branches Collected"
        '
        'lblCollected5P
        '
        '
        '
        '
        Me.lblCollected5P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected5P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected5P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected5P.Location = New System.Drawing.Point(203, 187)
        Me.lblCollected5P.Name = "lblCollected5P"
        Me.lblCollected5P.Size = New System.Drawing.Size(80, 25)
        Me.lblCollected5P.TabIndex = 1068
        Me.lblCollected5P.Text = "0.00 %"
        Me.lblCollected5P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected5A
        '
        '
        '
        '
        Me.lblCollected5A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected5A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected5A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected5A.Location = New System.Drawing.Point(85, 187)
        Me.lblCollected5A.Name = "lblCollected5A"
        Me.lblCollected5A.Size = New System.Drawing.Size(112, 25)
        Me.lblCollected5A.TabIndex = 1067
        Me.lblCollected5A.Text = "0.00"
        Me.lblCollected5A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCollected5B
        '
        '
        '
        '
        Me.lblCollected5B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected5B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected5B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected5B.Location = New System.Drawing.Point(6, 187)
        Me.lblCollected5B.Name = "lblCollected5B"
        Me.lblCollected5B.Size = New System.Drawing.Size(73, 25)
        Me.lblCollected5B.TabIndex = 1066
        Me.lblCollected5B.Text = "5. "
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(6, 32)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(72, 25)
        Me.LabelX1.TabIndex = 1065
        Me.LabelX1.Text = "Branches"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected4P
        '
        '
        '
        '
        Me.lblCollected4P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected4P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected4P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected4P.Location = New System.Drawing.Point(202, 156)
        Me.lblCollected4P.Name = "lblCollected4P"
        Me.lblCollected4P.Size = New System.Drawing.Size(80, 25)
        Me.lblCollected4P.TabIndex = 1050
        Me.lblCollected4P.Text = "0.00 %"
        Me.lblCollected4P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected4A
        '
        '
        '
        '
        Me.lblCollected4A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected4A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected4A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected4A.Location = New System.Drawing.Point(84, 156)
        Me.lblCollected4A.Name = "lblCollected4A"
        Me.lblCollected4A.Size = New System.Drawing.Size(112, 25)
        Me.lblCollected4A.TabIndex = 1049
        Me.lblCollected4A.Text = "0.00"
        Me.lblCollected4A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCollected4B
        '
        '
        '
        '
        Me.lblCollected4B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected4B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected4B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected4B.Location = New System.Drawing.Point(5, 156)
        Me.lblCollected4B.Name = "lblCollected4B"
        Me.lblCollected4B.Size = New System.Drawing.Size(73, 25)
        Me.lblCollected4B.TabIndex = 1048
        Me.lblCollected4B.Text = "4. "
        '
        'lblCollected3P
        '
        '
        '
        '
        Me.lblCollected3P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected3P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected3P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected3P.Location = New System.Drawing.Point(202, 125)
        Me.lblCollected3P.Name = "lblCollected3P"
        Me.lblCollected3P.Size = New System.Drawing.Size(80, 25)
        Me.lblCollected3P.TabIndex = 1047
        Me.lblCollected3P.Text = "0.00 %"
        Me.lblCollected3P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected3A
        '
        '
        '
        '
        Me.lblCollected3A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected3A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected3A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected3A.Location = New System.Drawing.Point(84, 125)
        Me.lblCollected3A.Name = "lblCollected3A"
        Me.lblCollected3A.Size = New System.Drawing.Size(112, 25)
        Me.lblCollected3A.TabIndex = 1046
        Me.lblCollected3A.Text = "0.00"
        Me.lblCollected3A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCollected3B
        '
        '
        '
        '
        Me.lblCollected3B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected3B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected3B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected3B.Location = New System.Drawing.Point(5, 125)
        Me.lblCollected3B.Name = "lblCollected3B"
        Me.lblCollected3B.Size = New System.Drawing.Size(73, 25)
        Me.lblCollected3B.TabIndex = 1045
        Me.lblCollected3B.Text = "3. "
        '
        'lblCollected2P
        '
        '
        '
        '
        Me.lblCollected2P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected2P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected2P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected2P.Location = New System.Drawing.Point(201, 94)
        Me.lblCollected2P.Name = "lblCollected2P"
        Me.lblCollected2P.Size = New System.Drawing.Size(80, 25)
        Me.lblCollected2P.TabIndex = 1044
        Me.lblCollected2P.Text = "0.00 %"
        Me.lblCollected2P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected1P
        '
        '
        '
        '
        Me.lblCollected1P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected1P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected1P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected1P.Location = New System.Drawing.Point(201, 63)
        Me.lblCollected1P.Name = "lblCollected1P"
        Me.lblCollected1P.Size = New System.Drawing.Size(80, 25)
        Me.lblCollected1P.TabIndex = 1043
        Me.lblCollected1P.Text = "0.00 %"
        Me.lblCollected1P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected2A
        '
        '
        '
        '
        Me.lblCollected2A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected2A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected2A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected2A.Location = New System.Drawing.Point(84, 94)
        Me.lblCollected2A.Name = "lblCollected2A"
        Me.lblCollected2A.Size = New System.Drawing.Size(112, 25)
        Me.lblCollected2A.TabIndex = 1042
        Me.lblCollected2A.Text = "0.00"
        Me.lblCollected2A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblCollected1A
        '
        '
        '
        '
        Me.lblCollected1A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected1A.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected1A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected1A.Location = New System.Drawing.Point(84, 63)
        Me.lblCollected1A.Name = "lblCollected1A"
        Me.lblCollected1A.Size = New System.Drawing.Size(112, 25)
        Me.lblCollected1A.TabIndex = 1041
        Me.lblCollected1A.Text = "0.00"
        Me.lblCollected1A.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX12.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX12.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX12.Location = New System.Drawing.Point(202, 32)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(80, 25)
        Me.LabelX12.TabIndex = 1040
        Me.LabelX12.Text = "Percentage"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX17.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(84, 32)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(112, 25)
        Me.LabelX17.TabIndex = 1039
        Me.LabelX17.Text = "Amount"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCollected2B
        '
        '
        '
        '
        Me.lblCollected2B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected2B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected2B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected2B.Location = New System.Drawing.Point(5, 94)
        Me.lblCollected2B.Name = "lblCollected2B"
        Me.lblCollected2B.Size = New System.Drawing.Size(73, 25)
        Me.lblCollected2B.TabIndex = 1038
        Me.lblCollected2B.Text = "2. "
        '
        'lblCollected1B
        '
        '
        '
        '
        Me.lblCollected1B.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCollected1B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCollected1B.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCollected1B.Location = New System.Drawing.Point(5, 63)
        Me.lblCollected1B.Name = "lblCollected1B"
        Me.lblCollected1B.Size = New System.Drawing.Size(73, 25)
        Me.lblCollected1B.TabIndex = 1037
        Me.lblCollected1B.Text = "1. "
        '
        'pCases
        '
        Me.pCases.CanvasColor = System.Drawing.SystemColors.Control
        Me.pCases.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pCases.Controls.Add(Me.LabelX155)
        Me.pCases.DisabledBackColor = System.Drawing.Color.Empty
        Me.pCases.Location = New System.Drawing.Point(12, 13)
        Me.pCases.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pCases.Name = "pCases"
        Me.pCases.Size = New System.Drawing.Size(371, 74)
        Me.pCases.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pCases.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pCases.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pCases.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pCases.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pCases.Style.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pCases.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pCases.Style.GradientAngle = 90
        Me.pCases.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pCases.TabIndex = 1067
        Me.pCases.Text = "1,252"
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX155.ForeColor = System.Drawing.Color.White
        Me.LabelX155.Location = New System.Drawing.Point(1, 1)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(270, 22)
        Me.LabelX155.TabIndex = 77
        Me.LabelX155.Text = "Total Cases"
        '
        'pBookValue
        '
        Me.pBookValue.CanvasColor = System.Drawing.SystemColors.Control
        Me.pBookValue.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pBookValue.Controls.Add(Me.LabelX61)
        Me.pBookValue.DisabledBackColor = System.Drawing.Color.Empty
        Me.pBookValue.Location = New System.Drawing.Point(389, 13)
        Me.pBookValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pBookValue.Name = "pBookValue"
        Me.pBookValue.Size = New System.Drawing.Size(371, 74)
        Me.pBookValue.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pBookValue.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pBookValue.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pBookValue.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pBookValue.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pBookValue.Style.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pBookValue.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pBookValue.Style.GradientAngle = 90
        Me.pBookValue.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pBookValue.TabIndex = 1068
        Me.pBookValue.Text = "625,340,252.00"
        '
        'LabelX61
        '
        Me.LabelX61.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX61.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX61.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX61.ForeColor = System.Drawing.Color.White
        Me.LabelX61.Location = New System.Drawing.Point(1, 1)
        Me.LabelX61.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX61.Name = "LabelX61"
        Me.LabelX61.Size = New System.Drawing.Size(270, 22)
        Me.LabelX61.TabIndex = 77
        Me.LabelX61.Text = "Total Book Value"
        '
        'pCollected
        '
        Me.pCollected.CanvasColor = System.Drawing.SystemColors.Control
        Me.pCollected.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pCollected.Controls.Add(Me.LabelX62)
        Me.pCollected.DisabledBackColor = System.Drawing.Color.Empty
        Me.pCollected.Location = New System.Drawing.Point(766, 13)
        Me.pCollected.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pCollected.Name = "pCollected"
        Me.pCollected.Size = New System.Drawing.Size(386, 74)
        Me.pCollected.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pCollected.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pCollected.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pCollected.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pCollected.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pCollected.Style.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pCollected.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pCollected.Style.GradientAngle = 90
        Me.pCollected.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pCollected.TabIndex = 1069
        Me.pCollected.Text = "793,260,851.00"
        '
        'LabelX62
        '
        Me.LabelX62.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX62.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX62.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX62.ForeColor = System.Drawing.Color.White
        Me.LabelX62.Location = New System.Drawing.Point(1, 1)
        Me.LabelX62.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX62.Name = "LabelX62"
        Me.LabelX62.Size = New System.Drawing.Size(270, 22)
        Me.LabelX62.TabIndex = 77
        Me.LabelX62.Text = "Total Collected"
        '
        'FrmITLDashboard
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
        Me.Controls.Add(Me.pCollected)
        Me.Controls.Add(Me.pBookValue)
        Me.Controls.Add(Me.pCases)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.btnChangeView)
        Me.Controls.Add(Me.gCivilStatus)
        Me.Controls.Add(Me.Chart1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmITLDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gCivilStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gCivilStatus.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.pCases.ResumeLayout(False)
        Me.pBookValue.ResumeLayout(False)
        Me.pCollected.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents gCivilStatus As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblWrittenOffP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblWrittenOffN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchivedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchivedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblActiveP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblActiveN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnChangeView As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase4P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase4N As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase4B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase3P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase3N As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase3B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase2P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase1P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase2N As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase1N As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase2B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase1B As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV4P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV4A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV4B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV3P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV3A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV3B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV2P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV1P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV2A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV1A As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX49 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV2B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV1B As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected4P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected4A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected4B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected3P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected3A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected3B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected2P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected1P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected2A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected1A As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected2B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected1B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFullyPaidP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFullyPaidN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase5P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase5N As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCase5B As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV5P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV5A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblBV5B As DevComponents.DotNetBar.LabelX
    Friend WithEvents pCases As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected5P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected5A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCollected5B As DevComponents.DotNetBar.LabelX
    Friend WithEvents pBookValue As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX61 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pCollected As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX62 As DevComponents.DotNetBar.LabelX
End Class
