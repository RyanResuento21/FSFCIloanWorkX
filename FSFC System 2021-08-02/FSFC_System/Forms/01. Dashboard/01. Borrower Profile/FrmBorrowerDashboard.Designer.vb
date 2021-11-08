<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBorrowerDashboard
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
        Me.components = New System.ComponentModel.Container()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PieSeriesLabel1 As DevExpress.XtraCharts.PieSeriesLabel = New DevExpress.XtraCharts.PieSeriesLabel()
        Dim SeriesPoint1 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Individual", New Object() {CType(340252.0R, Object)}, 0)
        Dim SeriesPoint2 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Corporate", New Object() {CType(15206.0R, Object)}, 2)
        Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
        Dim DoughnutSeriesLabel1 As DevExpress.XtraCharts.DoughnutSeriesLabel = New DevExpress.XtraCharts.DoughnutSeriesLabel()
        Dim DoughnutSeriesView1 As DevExpress.XtraCharts.DoughnutSeriesView = New DevExpress.XtraCharts.DoughnutSeriesView()
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim SeriesPoint3 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jan", New Object() {CType(1.04R, Object)})
        Dim SeriesPoint4 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Feb", New Object() {CType(1.5R, Object)})
        Dim SeriesPoint5 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Mar", New Object() {CType(2.24R, Object)})
        Dim SeriesPoint6 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Apr", New Object() {CType(1.01R, Object)})
        Dim SeriesPoint7 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("May", New Object() {CType(0.95R, Object)})
        Dim SeriesPoint8 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jun", New Object() {CType(1.5R, Object)})
        Dim SeriesPoint9 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jul", New Object() {CType(1.6R, Object)})
        Dim SeriesPoint10 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Aug", New Object() {CType(1.2R, Object)})
        Dim SeriesPoint11 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Sep", New Object() {CType(1.7R, Object)})
        Dim SeriesPoint12 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Oct", New Object() {CType(0.2R, Object)})
        Dim SeriesPoint13 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Nov", New Object() {CType(0.9R, Object)})
        Dim SeriesPoint14 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Dec", New Object() {CType(2.2R, Object)})
        Dim Series3 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SeriesPoint15 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jan", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint16 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Feb", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint17 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Mar", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint18 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Apr", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint19 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("May", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint20 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jun", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint21 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jul", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint22 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Aug", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint23 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Sep", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint24 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Oct", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint25 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Nov", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint26 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Dec", New Object() {CType(1.0R, Object)})
        Dim Series4 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SeriesPoint27 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jan", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint28 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Feb", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint29 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Mar", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint30 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Apr", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint31 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("May", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint32 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jun", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint33 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Jul", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint34 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Aug", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint35 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Sep", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint36 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Oct", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint37 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Nov", New Object() {CType(1.0R, Object)})
        Dim SeriesPoint38 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Dec", New Object() {CType(1.0R, Object)})
        Dim SideBySideBarSeriesLabel2 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim ChartTitle2 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.pIndividual = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.gGender = New DevExpress.XtraEditors.GroupControl()
        Me.lblFemaleP = New DevComponents.DotNetBar.LabelX()
        Me.lblMaleP = New DevComponents.DotNetBar.LabelX()
        Me.lblFemaleN = New DevComponents.DotNetBar.LabelX()
        Me.lblMaleN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.gCivilStatus = New DevExpress.XtraEditors.GroupControl()
        Me.lblWidowedP = New DevComponents.DotNetBar.LabelX()
        Me.lblWidowedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.lblSeparatedP = New DevComponents.DotNetBar.LabelX()
        Me.lblSeparatedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.lblMarriedP = New DevComponents.DotNetBar.LabelX()
        Me.lblSingleP = New DevComponents.DotNetBar.LabelX()
        Me.lblMarriedN = New DevComponents.DotNetBar.LabelX()
        Me.lblSingleN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.gAge = New DevExpress.XtraEditors.GroupControl()
        Me.lbl51AboveP = New DevComponents.DotNetBar.LabelX()
        Me.lbl51AboveN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.lbl41_50P = New DevComponents.DotNetBar.LabelX()
        Me.lbl41_50N = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.lbl31_40P = New DevComponents.DotNetBar.LabelX()
        Me.lbl31_40N = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.lbl21_30P = New DevComponents.DotNetBar.LabelX()
        Me.lbl20BelowP = New DevComponents.DotNetBar.LabelX()
        Me.lbl21_30N = New DevComponents.DotNetBar.LabelX()
        Me.lbl20BelowN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.gCitizenship = New DevExpress.XtraEditors.GroupControl()
        Me.lblForeignerP = New DevComponents.DotNetBar.LabelX()
        Me.lblFilipinoP = New DevComponents.DotNetBar.LabelX()
        Me.lblForeignerN = New DevComponents.DotNetBar.LabelX()
        Me.lblFilipinoN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX44 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX45 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX46 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX47 = New DevComponents.DotNetBar.LabelX()
        Me.gDependents = New DevExpress.XtraEditors.GroupControl()
        Me.lbl4DependentP = New DevComponents.DotNetBar.LabelX()
        Me.lbl4DependentN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX50 = New DevComponents.DotNetBar.LabelX()
        Me.lbl3DependentP = New DevComponents.DotNetBar.LabelX()
        Me.lbl3DependentN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX53 = New DevComponents.DotNetBar.LabelX()
        Me.lbl2DependentP = New DevComponents.DotNetBar.LabelX()
        Me.lbl2DependentN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX56 = New DevComponents.DotNetBar.LabelX()
        Me.lbl1DependentP = New DevComponents.DotNetBar.LabelX()
        Me.lbl0DependentP = New DevComponents.DotNetBar.LabelX()
        Me.lbl1DependentN = New DevComponents.DotNetBar.LabelX()
        Me.lbl0DependentN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX61 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX62 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX63 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX64 = New DevComponents.DotNetBar.LabelX()
        Me.gHouseOwnership = New DevExpress.XtraEditors.GroupControl()
        Me.lblRentedP = New DevComponents.DotNetBar.LabelX()
        Me.lblRentedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX70 = New DevComponents.DotNetBar.LabelX()
        Me.lblFreeP = New DevComponents.DotNetBar.LabelX()
        Me.lblOwnedP = New DevComponents.DotNetBar.LabelX()
        Me.lblFreeN = New DevComponents.DotNetBar.LabelX()
        Me.lblOwnedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX75 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX76 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX77 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX78 = New DevComponents.DotNetBar.LabelX()
        Me.pCorporate = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX87 = New DevComponents.DotNetBar.LabelX()
        Me.gFirmSize = New DevExpress.XtraEditors.GroupControl()
        Me.lblLargeP = New DevComponents.DotNetBar.LabelX()
        Me.lblLargeN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX90 = New DevComponents.DotNetBar.LabelX()
        Me.lblMediumP = New DevComponents.DotNetBar.LabelX()
        Me.lblMediumN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX93 = New DevComponents.DotNetBar.LabelX()
        Me.lblSmallP = New DevComponents.DotNetBar.LabelX()
        Me.lblMicroP = New DevComponents.DotNetBar.LabelX()
        Me.lblSmallN = New DevComponents.DotNetBar.LabelX()
        Me.lblMicroN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX98 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX99 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX100 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX101 = New DevComponents.DotNetBar.LabelX()
        Me.c1 = New DevExpress.XtraCharts.ChartControl()
        Me.pTotal = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX102 = New DevComponents.DotNetBar.LabelX()
        Me.c2 = New DevExpress.XtraCharts.ChartControl()
        Me.btnChangeView = New DevComponents.DotNetBar.ButtonX()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Timer_Refresh = New System.Windows.Forms.Timer(Me.components)
        Me.pIndividual.SuspendLayout()
        CType(Me.gGender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gGender.SuspendLayout()
        CType(Me.gCivilStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gCivilStatus.SuspendLayout()
        CType(Me.gAge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gAge.SuspendLayout()
        CType(Me.gCitizenship, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gCitizenship.SuspendLayout()
        CType(Me.gDependents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDependents.SuspendLayout()
        CType(Me.gHouseOwnership, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gHouseOwnership.SuspendLayout()
        Me.pCorporate.SuspendLayout()
        CType(Me.gFirmSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gFirmSize.SuspendLayout()
        CType(Me.c1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pTotal.SuspendLayout()
        CType(Me.c2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pIndividual
        '
        Me.pIndividual.CanvasColor = System.Drawing.SystemColors.Control
        Me.pIndividual.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pIndividual.Controls.Add(Me.LabelX155)
        Me.pIndividual.DisabledBackColor = System.Drawing.Color.Empty
        Me.pIndividual.Location = New System.Drawing.Point(12, 13)
        Me.pIndividual.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pIndividual.Name = "pIndividual"
        Me.pIndividual.Size = New System.Drawing.Size(371, 74)
        Me.pIndividual.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pIndividual.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pIndividual.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pIndividual.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pIndividual.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.pIndividual.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.pIndividual.Style.BorderWidth = 4
        Me.pIndividual.Style.Font = New System.Drawing.Font("Century Gothic", 36.0!)
        Me.pIndividual.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pIndividual.Style.GradientAngle = 90
        Me.pIndividual.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pIndividual.TabIndex = 10
        Me.pIndividual.Text = "340,252"
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        '
        '
        '
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.LabelX155.ForeColor = System.Drawing.Color.White
        Me.LabelX155.Location = New System.Drawing.Point(1, 1)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(270, 22)
        Me.LabelX155.TabIndex = 77
        Me.LabelX155.Text = "Total No. of Individual Borrowers"
        '
        'gGender
        '
        Me.gGender.Appearance.BackColor = System.Drawing.Color.White
        Me.gGender.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gGender.Appearance.Options.UseBackColor = True
        Me.gGender.Appearance.Options.UseFont = True
        Me.gGender.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.gGender.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gGender.AppearanceCaption.Options.UseFont = True
        Me.gGender.AppearanceCaption.Options.UseForeColor = True
        Me.gGender.Controls.Add(Me.lblFemaleP)
        Me.gGender.Controls.Add(Me.lblMaleP)
        Me.gGender.Controls.Add(Me.lblFemaleN)
        Me.gGender.Controls.Add(Me.lblMaleN)
        Me.gGender.Controls.Add(Me.LabelX3)
        Me.gGender.Controls.Add(Me.LabelX2)
        Me.gGender.Controls.Add(Me.LabelX1)
        Me.gGender.Controls.Add(Me.LabelX4)
        Me.gGender.Location = New System.Drawing.Point(570, 94)
        Me.gGender.LookAndFeel.SkinName = "Darkroom"
        Me.gGender.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gGender.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gGender.Name = "gGender"
        Me.gGender.Size = New System.Drawing.Size(273, 127)
        Me.gGender.TabIndex = 11
        Me.gGender.Text = "Gender"
        '
        'lblFemaleP
        '
        '
        '
        '
        Me.lblFemaleP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFemaleP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFemaleP.ForeColor = System.Drawing.Color.Black
        Me.lblFemaleP.Location = New System.Drawing.Point(191, 94)
        Me.lblFemaleP.Name = "lblFemaleP"
        Me.lblFemaleP.Size = New System.Drawing.Size(80, 25)
        Me.lblFemaleP.TabIndex = 1044
        Me.lblFemaleP.Text = "28.29 %"
        Me.lblFemaleP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMaleP
        '
        '
        '
        '
        Me.lblMaleP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMaleP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMaleP.ForeColor = System.Drawing.Color.Black
        Me.lblMaleP.Location = New System.Drawing.Point(191, 63)
        Me.lblMaleP.Name = "lblMaleP"
        Me.lblMaleP.Size = New System.Drawing.Size(80, 25)
        Me.lblMaleP.TabIndex = 1043
        Me.lblMaleP.Text = "70.25 %"
        Me.lblMaleP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblFemaleN
        '
        '
        '
        '
        Me.lblFemaleN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFemaleN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFemaleN.ForeColor = System.Drawing.Color.Black
        Me.lblFemaleN.Location = New System.Drawing.Point(105, 94)
        Me.lblFemaleN.Name = "lblFemaleN"
        Me.lblFemaleN.Size = New System.Drawing.Size(80, 25)
        Me.lblFemaleN.TabIndex = 1042
        Me.lblFemaleN.Text = "2,402"
        Me.lblFemaleN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMaleN
        '
        '
        '
        '
        Me.lblMaleN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMaleN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMaleN.ForeColor = System.Drawing.Color.Black
        Me.lblMaleN.Location = New System.Drawing.Point(105, 63)
        Me.lblMaleN.Name = "lblMaleN"
        Me.lblMaleN.Size = New System.Drawing.Size(80, 25)
        Me.lblMaleN.TabIndex = 1041
        Me.lblMaleN.Text = "5,059"
        Me.lblMaleN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX3.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX3.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(191, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 25)
        Me.LabelX3.TabIndex = 1040
        Me.LabelX3.Text = "Percentage"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX2.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(105, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(80, 25)
        Me.LabelX2.TabIndex = 1039
        Me.LabelX2.Text = "Number"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(5, 94)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(94, 25)
        Me.LabelX1.TabIndex = 1038
        Me.LabelX1.Text = "Female :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(5, 63)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(94, 25)
        Me.LabelX4.TabIndex = 1037
        Me.LabelX4.Text = "Male :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gCivilStatus
        '
        Me.gCivilStatus.Appearance.BackColor = System.Drawing.Color.White
        Me.gCivilStatus.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gCivilStatus.Appearance.Options.UseBackColor = True
        Me.gCivilStatus.Appearance.Options.UseFont = True
        Me.gCivilStatus.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.gCivilStatus.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gCivilStatus.AppearanceCaption.Options.UseFont = True
        Me.gCivilStatus.AppearanceCaption.Options.UseForeColor = True
        Me.gCivilStatus.Controls.Add(Me.lblWidowedP)
        Me.gCivilStatus.Controls.Add(Me.lblWidowedN)
        Me.gCivilStatus.Controls.Add(Me.LabelX22)
        Me.gCivilStatus.Controls.Add(Me.lblSeparatedP)
        Me.gCivilStatus.Controls.Add(Me.lblSeparatedN)
        Me.gCivilStatus.Controls.Add(Me.LabelX19)
        Me.gCivilStatus.Controls.Add(Me.lblMarriedP)
        Me.gCivilStatus.Controls.Add(Me.lblSingleP)
        Me.gCivilStatus.Controls.Add(Me.lblMarriedN)
        Me.gCivilStatus.Controls.Add(Me.lblSingleN)
        Me.gCivilStatus.Controls.Add(Me.LabelX13)
        Me.gCivilStatus.Controls.Add(Me.LabelX14)
        Me.gCivilStatus.Controls.Add(Me.LabelX15)
        Me.gCivilStatus.Controls.Add(Me.LabelX16)
        Me.gCivilStatus.Location = New System.Drawing.Point(12, 94)
        Me.gCivilStatus.LookAndFeel.SkinName = "Darkroom"
        Me.gCivilStatus.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gCivilStatus.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gCivilStatus.Name = "gCivilStatus"
        Me.gCivilStatus.Size = New System.Drawing.Size(273, 188)
        Me.gCivilStatus.TabIndex = 1045
        Me.gCivilStatus.Text = "Civil Status"
        '
        'lblWidowedP
        '
        '
        '
        '
        Me.lblWidowedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWidowedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblWidowedP.ForeColor = System.Drawing.Color.Black
        Me.lblWidowedP.Location = New System.Drawing.Point(191, 156)
        Me.lblWidowedP.Name = "lblWidowedP"
        Me.lblWidowedP.Size = New System.Drawing.Size(80, 25)
        Me.lblWidowedP.TabIndex = 1050
        Me.lblWidowedP.Text = "3.29 %"
        Me.lblWidowedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblWidowedN
        '
        '
        '
        '
        Me.lblWidowedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblWidowedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblWidowedN.ForeColor = System.Drawing.Color.Black
        Me.lblWidowedN.Location = New System.Drawing.Point(105, 156)
        Me.lblWidowedN.Name = "lblWidowedN"
        Me.lblWidowedN.Size = New System.Drawing.Size(80, 25)
        Me.lblWidowedN.TabIndex = 1049
        Me.lblWidowedN.Text = "291"
        Me.lblWidowedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(5, 156)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(94, 25)
        Me.LabelX22.TabIndex = 1048
        Me.LabelX22.Text = "Widowed :"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblSeparatedP
        '
        '
        '
        '
        Me.lblSeparatedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSeparatedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSeparatedP.ForeColor = System.Drawing.Color.Black
        Me.lblSeparatedP.Location = New System.Drawing.Point(191, 125)
        Me.lblSeparatedP.Name = "lblSeparatedP"
        Me.lblSeparatedP.Size = New System.Drawing.Size(80, 25)
        Me.lblSeparatedP.TabIndex = 1047
        Me.lblSeparatedP.Text = "13.29 %"
        Me.lblSeparatedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblSeparatedN
        '
        '
        '
        '
        Me.lblSeparatedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSeparatedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSeparatedN.ForeColor = System.Drawing.Color.Black
        Me.lblSeparatedN.Location = New System.Drawing.Point(105, 125)
        Me.lblSeparatedN.Name = "lblSeparatedN"
        Me.lblSeparatedN.Size = New System.Drawing.Size(80, 25)
        Me.lblSeparatedN.TabIndex = 1046
        Me.lblSeparatedN.Text = "1,592"
        Me.lblSeparatedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX19.ForeColor = System.Drawing.Color.Black
        Me.LabelX19.Location = New System.Drawing.Point(5, 125)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(94, 25)
        Me.LabelX19.TabIndex = 1045
        Me.LabelX19.Text = "Separated :"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblMarriedP
        '
        '
        '
        '
        Me.lblMarriedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMarriedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMarriedP.ForeColor = System.Drawing.Color.Black
        Me.lblMarriedP.Location = New System.Drawing.Point(191, 94)
        Me.lblMarriedP.Name = "lblMarriedP"
        Me.lblMarriedP.Size = New System.Drawing.Size(80, 25)
        Me.lblMarriedP.TabIndex = 1044
        Me.lblMarriedP.Text = "52.29 %"
        Me.lblMarriedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblSingleP
        '
        '
        '
        '
        Me.lblSingleP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSingleP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSingleP.ForeColor = System.Drawing.Color.Black
        Me.lblSingleP.Location = New System.Drawing.Point(191, 63)
        Me.lblSingleP.Name = "lblSingleP"
        Me.lblSingleP.Size = New System.Drawing.Size(80, 25)
        Me.lblSingleP.TabIndex = 1043
        Me.lblSingleP.Text = "23.52 %"
        Me.lblSingleP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMarriedN
        '
        '
        '
        '
        Me.lblMarriedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMarriedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMarriedN.ForeColor = System.Drawing.Color.Black
        Me.lblMarriedN.Location = New System.Drawing.Point(105, 94)
        Me.lblMarriedN.Name = "lblMarriedN"
        Me.lblMarriedN.Size = New System.Drawing.Size(80, 25)
        Me.lblMarriedN.TabIndex = 1042
        Me.lblMarriedN.Text = "3,502"
        Me.lblMarriedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblSingleN
        '
        '
        '
        '
        Me.lblSingleN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSingleN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSingleN.ForeColor = System.Drawing.Color.Black
        Me.lblSingleN.Location = New System.Drawing.Point(105, 63)
        Me.lblSingleN.Name = "lblSingleN"
        Me.lblSingleN.Size = New System.Drawing.Size(80, 25)
        Me.lblSingleN.TabIndex = 1041
        Me.lblSingleN.Text = "2,520"
        Me.lblSingleN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX13.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX13.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
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
        Me.LabelX14.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelX14.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
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
        Me.LabelX15.ForeColor = System.Drawing.Color.Black
        Me.LabelX15.Location = New System.Drawing.Point(5, 94)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(94, 25)
        Me.LabelX15.TabIndex = 1038
        Me.LabelX15.Text = "Married :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(5, 63)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(94, 25)
        Me.LabelX16.TabIndex = 1037
        Me.LabelX16.Text = "Single :"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gAge
        '
        Me.gAge.Appearance.BackColor = System.Drawing.Color.White
        Me.gAge.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gAge.Appearance.Options.UseBackColor = True
        Me.gAge.Appearance.Options.UseFont = True
        Me.gAge.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.gAge.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gAge.AppearanceCaption.Options.UseFont = True
        Me.gAge.AppearanceCaption.Options.UseForeColor = True
        Me.gAge.Controls.Add(Me.lbl51AboveP)
        Me.gAge.Controls.Add(Me.lbl51AboveN)
        Me.gAge.Controls.Add(Me.LabelX37)
        Me.gAge.Controls.Add(Me.lbl41_50P)
        Me.gAge.Controls.Add(Me.lbl41_50N)
        Me.gAge.Controls.Add(Me.LabelX25)
        Me.gAge.Controls.Add(Me.lbl31_40P)
        Me.gAge.Controls.Add(Me.lbl31_40N)
        Me.gAge.Controls.Add(Me.LabelX28)
        Me.gAge.Controls.Add(Me.lbl21_30P)
        Me.gAge.Controls.Add(Me.lbl20BelowP)
        Me.gAge.Controls.Add(Me.lbl21_30N)
        Me.gAge.Controls.Add(Me.lbl20BelowN)
        Me.gAge.Controls.Add(Me.LabelX33)
        Me.gAge.Controls.Add(Me.LabelX34)
        Me.gAge.Controls.Add(Me.LabelX35)
        Me.gAge.Controls.Add(Me.LabelX36)
        Me.gAge.Location = New System.Drawing.Point(12, 288)
        Me.gAge.LookAndFeel.SkinName = "Darkroom"
        Me.gAge.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gAge.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gAge.Name = "gAge"
        Me.gAge.Size = New System.Drawing.Size(273, 226)
        Me.gAge.TabIndex = 1046
        Me.gAge.Text = "Age"
        '
        'lbl51AboveP
        '
        '
        '
        '
        Me.lbl51AboveP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl51AboveP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl51AboveP.ForeColor = System.Drawing.Color.Black
        Me.lbl51AboveP.Location = New System.Drawing.Point(191, 187)
        Me.lbl51AboveP.Name = "lbl51AboveP"
        Me.lbl51AboveP.Size = New System.Drawing.Size(80, 25)
        Me.lbl51AboveP.TabIndex = 1053
        Me.lbl51AboveP.Text = "19.99 %"
        Me.lbl51AboveP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl51AboveN
        '
        '
        '
        '
        Me.lbl51AboveN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl51AboveN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl51AboveN.ForeColor = System.Drawing.Color.Black
        Me.lbl51AboveN.Location = New System.Drawing.Point(105, 187)
        Me.lbl51AboveN.Name = "lbl51AboveN"
        Me.lbl51AboveN.Size = New System.Drawing.Size(80, 25)
        Me.lbl51AboveN.TabIndex = 1052
        Me.lbl51AboveN.Text = "1,727"
        Me.lbl51AboveN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX37
        '
        '
        '
        '
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX37.ForeColor = System.Drawing.Color.Black
        Me.LabelX37.Location = New System.Drawing.Point(3, 187)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(99, 25)
        Me.LabelX37.TabIndex = 1051
        Me.LabelX37.Text = "51 and Above :"
        Me.LabelX37.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbl41_50P
        '
        '
        '
        '
        Me.lbl41_50P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl41_50P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl41_50P.ForeColor = System.Drawing.Color.Black
        Me.lbl41_50P.Location = New System.Drawing.Point(191, 156)
        Me.lbl41_50P.Name = "lbl41_50P"
        Me.lbl41_50P.Size = New System.Drawing.Size(80, 25)
        Me.lbl41_50P.TabIndex = 1050
        Me.lbl41_50P.Text = "19.52 %"
        Me.lbl41_50P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl41_50N
        '
        '
        '
        '
        Me.lbl41_50N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl41_50N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl41_50N.ForeColor = System.Drawing.Color.Black
        Me.lbl41_50N.Location = New System.Drawing.Point(105, 156)
        Me.lbl41_50N.Name = "lbl41_50N"
        Me.lbl41_50N.Size = New System.Drawing.Size(80, 25)
        Me.lbl41_50N.TabIndex = 1049
        Me.lbl41_50N.Text = "1,637"
        Me.lbl41_50N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX25
        '
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX25.ForeColor = System.Drawing.Color.Black
        Me.LabelX25.Location = New System.Drawing.Point(3, 156)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(99, 25)
        Me.LabelX25.TabIndex = 1048
        Me.LabelX25.Text = "41 - 50 :"
        Me.LabelX25.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbl31_40P
        '
        '
        '
        '
        Me.lbl31_40P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl31_40P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl31_40P.ForeColor = System.Drawing.Color.Black
        Me.lbl31_40P.Location = New System.Drawing.Point(191, 125)
        Me.lbl31_40P.Name = "lbl31_40P"
        Me.lbl31_40P.Size = New System.Drawing.Size(80, 25)
        Me.lbl31_40P.TabIndex = 1047
        Me.lbl31_40P.Text = "28.11 %"
        Me.lbl31_40P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl31_40N
        '
        '
        '
        '
        Me.lbl31_40N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl31_40N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl31_40N.ForeColor = System.Drawing.Color.Black
        Me.lbl31_40N.Location = New System.Drawing.Point(105, 125)
        Me.lbl31_40N.Name = "lbl31_40N"
        Me.lbl31_40N.Size = New System.Drawing.Size(80, 25)
        Me.lbl31_40N.TabIndex = 1046
        Me.lbl31_40N.Text = "2,566"
        Me.lbl31_40N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX28
        '
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX28.ForeColor = System.Drawing.Color.Black
        Me.LabelX28.Location = New System.Drawing.Point(3, 125)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(99, 25)
        Me.LabelX28.TabIndex = 1045
        Me.LabelX28.Text = "31 - 40 :"
        Me.LabelX28.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbl21_30P
        '
        '
        '
        '
        Me.lbl21_30P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl21_30P.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl21_30P.ForeColor = System.Drawing.Color.Black
        Me.lbl21_30P.Location = New System.Drawing.Point(191, 94)
        Me.lbl21_30P.Name = "lbl21_30P"
        Me.lbl21_30P.Size = New System.Drawing.Size(80, 25)
        Me.lbl21_30P.TabIndex = 1044
        Me.lbl21_30P.Text = "24.73 %"
        Me.lbl21_30P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl20BelowP
        '
        '
        '
        '
        Me.lbl20BelowP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl20BelowP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl20BelowP.ForeColor = System.Drawing.Color.Black
        Me.lbl20BelowP.Location = New System.Drawing.Point(191, 63)
        Me.lbl20BelowP.Name = "lbl20BelowP"
        Me.lbl20BelowP.Size = New System.Drawing.Size(80, 25)
        Me.lbl20BelowP.TabIndex = 1043
        Me.lbl20BelowP.Text = "18.25 %"
        Me.lbl20BelowP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl21_30N
        '
        '
        '
        '
        Me.lbl21_30N.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl21_30N.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl21_30N.ForeColor = System.Drawing.Color.Black
        Me.lbl21_30N.Location = New System.Drawing.Point(105, 94)
        Me.lbl21_30N.Name = "lbl21_30N"
        Me.lbl21_30N.Size = New System.Drawing.Size(80, 25)
        Me.lbl21_30N.TabIndex = 1042
        Me.lbl21_30N.Text = "2,267"
        Me.lbl21_30N.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl20BelowN
        '
        '
        '
        '
        Me.lbl20BelowN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl20BelowN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl20BelowN.ForeColor = System.Drawing.Color.Black
        Me.lbl20BelowN.Location = New System.Drawing.Point(105, 63)
        Me.lbl20BelowN.Name = "lbl20BelowN"
        Me.lbl20BelowN.Size = New System.Drawing.Size(80, 25)
        Me.lbl20BelowN.TabIndex = 1041
        Me.lbl20BelowN.Text = "1,262"
        Me.lbl20BelowN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX33
        '
        '
        '
        '
        Me.LabelX33.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX33.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX33.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX33.ForeColor = System.Drawing.Color.Black
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
        Me.LabelX34.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX34.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX34.ForeColor = System.Drawing.Color.Black
        Me.LabelX34.Location = New System.Drawing.Point(105, 32)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(80, 25)
        Me.LabelX34.TabIndex = 1039
        Me.LabelX34.Text = "Number"
        Me.LabelX34.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX35
        '
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX35.ForeColor = System.Drawing.Color.Black
        Me.LabelX35.Location = New System.Drawing.Point(3, 94)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(99, 25)
        Me.LabelX35.TabIndex = 1038
        Me.LabelX35.Text = "21 - 30 :"
        Me.LabelX35.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX36
        '
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX36.ForeColor = System.Drawing.Color.Black
        Me.LabelX36.Location = New System.Drawing.Point(3, 63)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(99, 25)
        Me.LabelX36.TabIndex = 1037
        Me.LabelX36.Text = "20 and Below :"
        Me.LabelX36.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gCitizenship
        '
        Me.gCitizenship.Appearance.BackColor = System.Drawing.Color.White
        Me.gCitizenship.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gCitizenship.Appearance.Options.UseBackColor = True
        Me.gCitizenship.Appearance.Options.UseFont = True
        Me.gCitizenship.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.gCitizenship.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gCitizenship.AppearanceCaption.Options.UseFont = True
        Me.gCitizenship.AppearanceCaption.Options.UseForeColor = True
        Me.gCitizenship.Controls.Add(Me.lblForeignerP)
        Me.gCitizenship.Controls.Add(Me.lblFilipinoP)
        Me.gCitizenship.Controls.Add(Me.lblForeignerN)
        Me.gCitizenship.Controls.Add(Me.lblFilipinoN)
        Me.gCitizenship.Controls.Add(Me.LabelX44)
        Me.gCitizenship.Controls.Add(Me.LabelX45)
        Me.gCitizenship.Controls.Add(Me.LabelX46)
        Me.gCitizenship.Controls.Add(Me.LabelX47)
        Me.gCitizenship.Location = New System.Drawing.Point(570, 227)
        Me.gCitizenship.LookAndFeel.SkinName = "Darkroom"
        Me.gCitizenship.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gCitizenship.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gCitizenship.Name = "gCitizenship"
        Me.gCitizenship.Size = New System.Drawing.Size(273, 127)
        Me.gCitizenship.TabIndex = 1047
        Me.gCitizenship.Text = "Citizenship"
        '
        'lblForeignerP
        '
        '
        '
        '
        Me.lblForeignerP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblForeignerP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblForeignerP.ForeColor = System.Drawing.Color.Black
        Me.lblForeignerP.Location = New System.Drawing.Point(191, 94)
        Me.lblForeignerP.Name = "lblForeignerP"
        Me.lblForeignerP.Size = New System.Drawing.Size(80, 25)
        Me.lblForeignerP.TabIndex = 1044
        Me.lblForeignerP.Text = "0.34 %"
        Me.lblForeignerP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblFilipinoP
        '
        '
        '
        '
        Me.lblFilipinoP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFilipinoP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFilipinoP.ForeColor = System.Drawing.Color.Black
        Me.lblFilipinoP.Location = New System.Drawing.Point(191, 63)
        Me.lblFilipinoP.Name = "lblFilipinoP"
        Me.lblFilipinoP.Size = New System.Drawing.Size(80, 25)
        Me.lblFilipinoP.TabIndex = 1043
        Me.lblFilipinoP.Text = "99.58 %"
        Me.lblFilipinoP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblForeignerN
        '
        '
        '
        '
        Me.lblForeignerN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblForeignerN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblForeignerN.ForeColor = System.Drawing.Color.Black
        Me.lblForeignerN.Location = New System.Drawing.Point(105, 94)
        Me.lblForeignerN.Name = "lblForeignerN"
        Me.lblForeignerN.Size = New System.Drawing.Size(80, 25)
        Me.lblForeignerN.TabIndex = 1042
        Me.lblForeignerN.Text = "3"
        Me.lblForeignerN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblFilipinoN
        '
        '
        '
        '
        Me.lblFilipinoN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFilipinoN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFilipinoN.ForeColor = System.Drawing.Color.Black
        Me.lblFilipinoN.Location = New System.Drawing.Point(105, 63)
        Me.lblFilipinoN.Name = "lblFilipinoN"
        Me.lblFilipinoN.Size = New System.Drawing.Size(80, 25)
        Me.lblFilipinoN.TabIndex = 1041
        Me.lblFilipinoN.Text = "7,295"
        Me.lblFilipinoN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX44
        '
        '
        '
        '
        Me.LabelX44.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX44.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX44.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX44.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX44.ForeColor = System.Drawing.Color.Black
        Me.LabelX44.Location = New System.Drawing.Point(191, 32)
        Me.LabelX44.Name = "LabelX44"
        Me.LabelX44.Size = New System.Drawing.Size(80, 25)
        Me.LabelX44.TabIndex = 1040
        Me.LabelX44.Text = "Percentage"
        Me.LabelX44.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX45
        '
        '
        '
        '
        Me.LabelX45.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX45.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX45.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX45.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX45.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX45.ForeColor = System.Drawing.Color.Black
        Me.LabelX45.Location = New System.Drawing.Point(105, 32)
        Me.LabelX45.Name = "LabelX45"
        Me.LabelX45.Size = New System.Drawing.Size(80, 25)
        Me.LabelX45.TabIndex = 1039
        Me.LabelX45.Text = "Number"
        Me.LabelX45.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX46
        '
        '
        '
        '
        Me.LabelX46.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX46.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX46.ForeColor = System.Drawing.Color.Black
        Me.LabelX46.Location = New System.Drawing.Point(5, 94)
        Me.LabelX46.Name = "LabelX46"
        Me.LabelX46.Size = New System.Drawing.Size(94, 25)
        Me.LabelX46.TabIndex = 1038
        Me.LabelX46.Text = "Foreigner :"
        Me.LabelX46.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX47
        '
        '
        '
        '
        Me.LabelX47.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX47.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX47.ForeColor = System.Drawing.Color.Black
        Me.LabelX47.Location = New System.Drawing.Point(5, 63)
        Me.LabelX47.Name = "LabelX47"
        Me.LabelX47.Size = New System.Drawing.Size(94, 25)
        Me.LabelX47.TabIndex = 1037
        Me.LabelX47.Text = "Filipino :"
        Me.LabelX47.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gDependents
        '
        Me.gDependents.Appearance.BackColor = System.Drawing.Color.White
        Me.gDependents.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gDependents.Appearance.Options.UseBackColor = True
        Me.gDependents.Appearance.Options.UseFont = True
        Me.gDependents.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.gDependents.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gDependents.AppearanceCaption.Options.UseFont = True
        Me.gDependents.AppearanceCaption.Options.UseForeColor = True
        Me.gDependents.Controls.Add(Me.lbl4DependentP)
        Me.gDependents.Controls.Add(Me.lbl4DependentN)
        Me.gDependents.Controls.Add(Me.LabelX50)
        Me.gDependents.Controls.Add(Me.lbl3DependentP)
        Me.gDependents.Controls.Add(Me.lbl3DependentN)
        Me.gDependents.Controls.Add(Me.LabelX53)
        Me.gDependents.Controls.Add(Me.lbl2DependentP)
        Me.gDependents.Controls.Add(Me.lbl2DependentN)
        Me.gDependents.Controls.Add(Me.LabelX56)
        Me.gDependents.Controls.Add(Me.lbl1DependentP)
        Me.gDependents.Controls.Add(Me.lbl0DependentP)
        Me.gDependents.Controls.Add(Me.lbl1DependentN)
        Me.gDependents.Controls.Add(Me.lbl0DependentN)
        Me.gDependents.Controls.Add(Me.LabelX61)
        Me.gDependents.Controls.Add(Me.LabelX62)
        Me.gDependents.Controls.Add(Me.LabelX63)
        Me.gDependents.Controls.Add(Me.LabelX64)
        Me.gDependents.Location = New System.Drawing.Point(291, 288)
        Me.gDependents.LookAndFeel.SkinName = "Darkroom"
        Me.gDependents.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gDependents.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gDependents.Name = "gDependents"
        Me.gDependents.Size = New System.Drawing.Size(273, 226)
        Me.gDependents.TabIndex = 1048
        Me.gDependents.Text = "Dependents"
        '
        'lbl4DependentP
        '
        '
        '
        '
        Me.lbl4DependentP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl4DependentP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl4DependentP.ForeColor = System.Drawing.Color.Black
        Me.lbl4DependentP.Location = New System.Drawing.Point(191, 187)
        Me.lbl4DependentP.Name = "lbl4DependentP"
        Me.lbl4DependentP.Size = New System.Drawing.Size(80, 25)
        Me.lbl4DependentP.TabIndex = 1053
        Me.lbl4DependentP.Text = "1.51 %"
        Me.lbl4DependentP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl4DependentN
        '
        '
        '
        '
        Me.lbl4DependentN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl4DependentN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl4DependentN.ForeColor = System.Drawing.Color.Black
        Me.lbl4DependentN.Location = New System.Drawing.Point(105, 187)
        Me.lbl4DependentN.Name = "lbl4DependentN"
        Me.lbl4DependentN.Size = New System.Drawing.Size(80, 25)
        Me.lbl4DependentN.TabIndex = 1052
        Me.lbl4DependentN.Text = "155"
        Me.lbl4DependentN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX50
        '
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX50.ForeColor = System.Drawing.Color.Black
        Me.LabelX50.Location = New System.Drawing.Point(2, 187)
        Me.LabelX50.Name = "LabelX50"
        Me.LabelX50.Size = New System.Drawing.Size(98, 25)
        Me.LabelX50.TabIndex = 1051
        Me.LabelX50.Text = "More than 3 :"
        Me.LabelX50.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbl3DependentP
        '
        '
        '
        '
        Me.lbl3DependentP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl3DependentP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl3DependentP.ForeColor = System.Drawing.Color.Black
        Me.lbl3DependentP.Location = New System.Drawing.Point(191, 156)
        Me.lbl3DependentP.Name = "lbl3DependentP"
        Me.lbl3DependentP.Size = New System.Drawing.Size(80, 25)
        Me.lbl3DependentP.TabIndex = 1050
        Me.lbl3DependentP.Text = "2.20 %"
        Me.lbl3DependentP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl3DependentN
        '
        '
        '
        '
        Me.lbl3DependentN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl3DependentN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl3DependentN.ForeColor = System.Drawing.Color.Black
        Me.lbl3DependentN.Location = New System.Drawing.Point(105, 156)
        Me.lbl3DependentN.Name = "lbl3DependentN"
        Me.lbl3DependentN.Size = New System.Drawing.Size(80, 25)
        Me.lbl3DependentN.TabIndex = 1049
        Me.lbl3DependentN.Text = "201"
        Me.lbl3DependentN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX53
        '
        '
        '
        '
        Me.LabelX53.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX53.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX53.ForeColor = System.Drawing.Color.Black
        Me.LabelX53.Location = New System.Drawing.Point(2, 156)
        Me.LabelX53.Name = "LabelX53"
        Me.LabelX53.Size = New System.Drawing.Size(98, 25)
        Me.LabelX53.TabIndex = 1048
        Me.LabelX53.Text = "3 Dependents :"
        Me.LabelX53.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbl2DependentP
        '
        '
        '
        '
        Me.lbl2DependentP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl2DependentP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl2DependentP.ForeColor = System.Drawing.Color.Black
        Me.lbl2DependentP.Location = New System.Drawing.Point(191, 125)
        Me.lbl2DependentP.Name = "lbl2DependentP"
        Me.lbl2DependentP.Size = New System.Drawing.Size(80, 25)
        Me.lbl2DependentP.TabIndex = 1047
        Me.lbl2DependentP.Text = "10.70 %"
        Me.lbl2DependentP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl2DependentN
        '
        '
        '
        '
        Me.lbl2DependentN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl2DependentN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl2DependentN.ForeColor = System.Drawing.Color.Black
        Me.lbl2DependentN.Location = New System.Drawing.Point(105, 125)
        Me.lbl2DependentN.Name = "lbl2DependentN"
        Me.lbl2DependentN.Size = New System.Drawing.Size(80, 25)
        Me.lbl2DependentN.TabIndex = 1046
        Me.lbl2DependentN.Text = "1,262"
        Me.lbl2DependentN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX56
        '
        '
        '
        '
        Me.LabelX56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX56.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX56.ForeColor = System.Drawing.Color.Black
        Me.LabelX56.Location = New System.Drawing.Point(2, 125)
        Me.LabelX56.Name = "LabelX56"
        Me.LabelX56.Size = New System.Drawing.Size(98, 25)
        Me.LabelX56.TabIndex = 1045
        Me.LabelX56.Text = "2 Dependents :"
        Me.LabelX56.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbl1DependentP
        '
        '
        '
        '
        Me.lbl1DependentP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl1DependentP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl1DependentP.ForeColor = System.Drawing.Color.Black
        Me.lbl1DependentP.Location = New System.Drawing.Point(191, 94)
        Me.lbl1DependentP.Name = "lbl1DependentP"
        Me.lbl1DependentP.Size = New System.Drawing.Size(80, 25)
        Me.lbl1DependentP.TabIndex = 1044
        Me.lbl1DependentP.Text = "5.95 %"
        Me.lbl1DependentP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl0DependentP
        '
        '
        '
        '
        Me.lbl0DependentP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl0DependentP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl0DependentP.ForeColor = System.Drawing.Color.Black
        Me.lbl0DependentP.Location = New System.Drawing.Point(191, 63)
        Me.lbl0DependentP.Name = "lbl0DependentP"
        Me.lbl0DependentP.Size = New System.Drawing.Size(80, 25)
        Me.lbl0DependentP.TabIndex = 1043
        Me.lbl0DependentP.Text = "80.84 %"
        Me.lbl0DependentP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl1DependentN
        '
        '
        '
        '
        Me.lbl1DependentN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl1DependentN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl1DependentN.ForeColor = System.Drawing.Color.Black
        Me.lbl1DependentN.Location = New System.Drawing.Point(105, 94)
        Me.lbl1DependentN.Name = "lbl1DependentN"
        Me.lbl1DependentN.Size = New System.Drawing.Size(80, 25)
        Me.lbl1DependentN.TabIndex = 1042
        Me.lbl1DependentN.Text = "525"
        Me.lbl1DependentN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lbl0DependentN
        '
        '
        '
        '
        Me.lbl0DependentN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbl0DependentN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbl0DependentN.ForeColor = System.Drawing.Color.Black
        Me.lbl0DependentN.Location = New System.Drawing.Point(105, 63)
        Me.lbl0DependentN.Name = "lbl0DependentN"
        Me.lbl0DependentN.Size = New System.Drawing.Size(80, 25)
        Me.lbl0DependentN.TabIndex = 1041
        Me.lbl0DependentN.Text = "4,152"
        Me.lbl0DependentN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX61
        '
        '
        '
        '
        Me.LabelX61.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX61.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX61.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX61.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX61.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX61.ForeColor = System.Drawing.Color.Black
        Me.LabelX61.Location = New System.Drawing.Point(191, 32)
        Me.LabelX61.Name = "LabelX61"
        Me.LabelX61.Size = New System.Drawing.Size(80, 25)
        Me.LabelX61.TabIndex = 1040
        Me.LabelX61.Text = "Percentage"
        Me.LabelX61.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX62
        '
        '
        '
        '
        Me.LabelX62.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX62.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX62.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX62.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX62.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX62.ForeColor = System.Drawing.Color.Black
        Me.LabelX62.Location = New System.Drawing.Point(105, 32)
        Me.LabelX62.Name = "LabelX62"
        Me.LabelX62.Size = New System.Drawing.Size(80, 25)
        Me.LabelX62.TabIndex = 1039
        Me.LabelX62.Text = "Number"
        Me.LabelX62.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX63
        '
        '
        '
        '
        Me.LabelX63.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX63.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX63.ForeColor = System.Drawing.Color.Black
        Me.LabelX63.Location = New System.Drawing.Point(2, 94)
        Me.LabelX63.Name = "LabelX63"
        Me.LabelX63.Size = New System.Drawing.Size(98, 25)
        Me.LabelX63.TabIndex = 1038
        Me.LabelX63.Text = "1 Dependent :"
        Me.LabelX63.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX64
        '
        '
        '
        '
        Me.LabelX64.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX64.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX64.ForeColor = System.Drawing.Color.Black
        Me.LabelX64.Location = New System.Drawing.Point(2, 63)
        Me.LabelX64.Name = "LabelX64"
        Me.LabelX64.Size = New System.Drawing.Size(98, 25)
        Me.LabelX64.TabIndex = 1037
        Me.LabelX64.Text = "0 Dependent :"
        Me.LabelX64.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gHouseOwnership
        '
        Me.gHouseOwnership.Appearance.BackColor = System.Drawing.Color.White
        Me.gHouseOwnership.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gHouseOwnership.Appearance.Options.UseBackColor = True
        Me.gHouseOwnership.Appearance.Options.UseFont = True
        Me.gHouseOwnership.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gHouseOwnership.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gHouseOwnership.AppearanceCaption.Options.UseFont = True
        Me.gHouseOwnership.AppearanceCaption.Options.UseForeColor = True
        Me.gHouseOwnership.Controls.Add(Me.lblRentedP)
        Me.gHouseOwnership.Controls.Add(Me.lblRentedN)
        Me.gHouseOwnership.Controls.Add(Me.LabelX70)
        Me.gHouseOwnership.Controls.Add(Me.lblFreeP)
        Me.gHouseOwnership.Controls.Add(Me.lblOwnedP)
        Me.gHouseOwnership.Controls.Add(Me.lblFreeN)
        Me.gHouseOwnership.Controls.Add(Me.lblOwnedN)
        Me.gHouseOwnership.Controls.Add(Me.LabelX75)
        Me.gHouseOwnership.Controls.Add(Me.LabelX76)
        Me.gHouseOwnership.Controls.Add(Me.LabelX77)
        Me.gHouseOwnership.Controls.Add(Me.LabelX78)
        Me.gHouseOwnership.Location = New System.Drawing.Point(13, 521)
        Me.gHouseOwnership.LookAndFeel.SkinName = "Darkroom"
        Me.gHouseOwnership.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gHouseOwnership.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gHouseOwnership.Name = "gHouseOwnership"
        Me.gHouseOwnership.Size = New System.Drawing.Size(273, 166)
        Me.gHouseOwnership.TabIndex = 1049
        Me.gHouseOwnership.Text = "House Ownership"
        '
        'lblRentedP
        '
        '
        '
        '
        Me.lblRentedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRentedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblRentedP.ForeColor = System.Drawing.Color.Black
        Me.lblRentedP.Location = New System.Drawing.Point(191, 125)
        Me.lblRentedP.Name = "lblRentedP"
        Me.lblRentedP.Size = New System.Drawing.Size(80, 25)
        Me.lblRentedP.TabIndex = 1047
        Me.lblRentedP.Text = "30.52 %"
        Me.lblRentedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblRentedN
        '
        '
        '
        '
        Me.lblRentedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRentedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblRentedN.ForeColor = System.Drawing.Color.Black
        Me.lblRentedN.Location = New System.Drawing.Point(105, 125)
        Me.lblRentedN.Name = "lblRentedN"
        Me.lblRentedN.Size = New System.Drawing.Size(80, 25)
        Me.lblRentedN.TabIndex = 1046
        Me.lblRentedN.Text = "2,890"
        Me.lblRentedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX70
        '
        '
        '
        '
        Me.LabelX70.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX70.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX70.ForeColor = System.Drawing.Color.Black
        Me.LabelX70.Location = New System.Drawing.Point(5, 125)
        Me.LabelX70.Name = "LabelX70"
        Me.LabelX70.Size = New System.Drawing.Size(94, 25)
        Me.LabelX70.TabIndex = 1045
        Me.LabelX70.Text = "Rented :"
        Me.LabelX70.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblFreeP
        '
        '
        '
        '
        Me.lblFreeP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFreeP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFreeP.ForeColor = System.Drawing.Color.Black
        Me.lblFreeP.Location = New System.Drawing.Point(191, 94)
        Me.lblFreeP.Name = "lblFreeP"
        Me.lblFreeP.Size = New System.Drawing.Size(80, 25)
        Me.lblFreeP.TabIndex = 1044
        Me.lblFreeP.Text = "21.42 %"
        Me.lblFreeP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOwnedP
        '
        '
        '
        '
        Me.lblOwnedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOwnedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblOwnedP.ForeColor = System.Drawing.Color.Black
        Me.lblOwnedP.Location = New System.Drawing.Point(191, 63)
        Me.lblOwnedP.Name = "lblOwnedP"
        Me.lblOwnedP.Size = New System.Drawing.Size(80, 25)
        Me.lblOwnedP.TabIndex = 1043
        Me.lblOwnedP.Text = "60.39 %"
        Me.lblOwnedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblFreeN
        '
        '
        '
        '
        Me.lblFreeN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFreeN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblFreeN.ForeColor = System.Drawing.Color.Black
        Me.lblFreeN.Location = New System.Drawing.Point(105, 94)
        Me.lblFreeN.Name = "lblFreeN"
        Me.lblFreeN.Size = New System.Drawing.Size(80, 25)
        Me.lblFreeN.TabIndex = 1042
        Me.lblFreeN.Text = "1,529"
        Me.lblFreeN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOwnedN
        '
        '
        '
        '
        Me.lblOwnedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOwnedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblOwnedN.ForeColor = System.Drawing.Color.Black
        Me.lblOwnedN.Location = New System.Drawing.Point(105, 63)
        Me.lblOwnedN.Name = "lblOwnedN"
        Me.lblOwnedN.Size = New System.Drawing.Size(80, 25)
        Me.lblOwnedN.TabIndex = 1041
        Me.lblOwnedN.Text = "4,630"
        Me.lblOwnedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX75
        '
        '
        '
        '
        Me.LabelX75.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX75.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX75.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX75.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX75.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX75.ForeColor = System.Drawing.Color.Black
        Me.LabelX75.Location = New System.Drawing.Point(191, 32)
        Me.LabelX75.Name = "LabelX75"
        Me.LabelX75.Size = New System.Drawing.Size(80, 25)
        Me.LabelX75.TabIndex = 1040
        Me.LabelX75.Text = "Percentage"
        Me.LabelX75.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX76
        '
        '
        '
        '
        Me.LabelX76.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX76.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX76.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX76.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX76.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX76.ForeColor = System.Drawing.Color.Black
        Me.LabelX76.Location = New System.Drawing.Point(105, 32)
        Me.LabelX76.Name = "LabelX76"
        Me.LabelX76.Size = New System.Drawing.Size(80, 25)
        Me.LabelX76.TabIndex = 1039
        Me.LabelX76.Text = "Number"
        Me.LabelX76.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX77
        '
        '
        '
        '
        Me.LabelX77.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX77.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX77.ForeColor = System.Drawing.Color.Black
        Me.LabelX77.Location = New System.Drawing.Point(5, 94)
        Me.LabelX77.Name = "LabelX77"
        Me.LabelX77.Size = New System.Drawing.Size(94, 25)
        Me.LabelX77.TabIndex = 1038
        Me.LabelX77.Text = "Free :"
        Me.LabelX77.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX78
        '
        '
        '
        '
        Me.LabelX78.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX78.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX78.ForeColor = System.Drawing.Color.Black
        Me.LabelX78.Location = New System.Drawing.Point(5, 63)
        Me.LabelX78.Name = "LabelX78"
        Me.LabelX78.Size = New System.Drawing.Size(94, 25)
        Me.LabelX78.TabIndex = 1037
        Me.LabelX78.Text = "Owned :"
        Me.LabelX78.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'pCorporate
        '
        Me.pCorporate.CanvasColor = System.Drawing.SystemColors.Control
        Me.pCorporate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pCorporate.Controls.Add(Me.LabelX87)
        Me.pCorporate.DisabledBackColor = System.Drawing.Color.Empty
        Me.pCorporate.Location = New System.Drawing.Point(390, 13)
        Me.pCorporate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pCorporate.Name = "pCorporate"
        Me.pCorporate.Size = New System.Drawing.Size(372, 74)
        Me.pCorporate.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pCorporate.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pCorporate.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pCorporate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pCorporate.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.pCorporate.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.pCorporate.Style.BorderWidth = 4
        Me.pCorporate.Style.Font = New System.Drawing.Font("Century Gothic", 36.0!)
        Me.pCorporate.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pCorporate.Style.GradientAngle = 90
        Me.pCorporate.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pCorporate.TabIndex = 1052
        Me.pCorporate.Text = "15,206"
        '
        'LabelX87
        '
        Me.LabelX87.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        '
        '
        '
        Me.LabelX87.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX87.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.LabelX87.ForeColor = System.Drawing.Color.White
        Me.LabelX87.Location = New System.Drawing.Point(1, 1)
        Me.LabelX87.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX87.Name = "LabelX87"
        Me.LabelX87.Size = New System.Drawing.Size(270, 22)
        Me.LabelX87.TabIndex = 77
        Me.LabelX87.Text = "Total No. of Corporate Borrowers"
        '
        'gFirmSize
        '
        Me.gFirmSize.Appearance.BackColor = System.Drawing.Color.White
        Me.gFirmSize.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gFirmSize.Appearance.Options.UseBackColor = True
        Me.gFirmSize.Appearance.Options.UseFont = True
        Me.gFirmSize.AppearanceCaption.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.gFirmSize.AppearanceCaption.ForeColor = System.Drawing.Color.Black
        Me.gFirmSize.AppearanceCaption.Options.UseFont = True
        Me.gFirmSize.AppearanceCaption.Options.UseForeColor = True
        Me.gFirmSize.Controls.Add(Me.lblLargeP)
        Me.gFirmSize.Controls.Add(Me.lblLargeN)
        Me.gFirmSize.Controls.Add(Me.LabelX90)
        Me.gFirmSize.Controls.Add(Me.lblMediumP)
        Me.gFirmSize.Controls.Add(Me.lblMediumN)
        Me.gFirmSize.Controls.Add(Me.LabelX93)
        Me.gFirmSize.Controls.Add(Me.lblSmallP)
        Me.gFirmSize.Controls.Add(Me.lblMicroP)
        Me.gFirmSize.Controls.Add(Me.lblSmallN)
        Me.gFirmSize.Controls.Add(Me.lblMicroN)
        Me.gFirmSize.Controls.Add(Me.LabelX98)
        Me.gFirmSize.Controls.Add(Me.LabelX99)
        Me.gFirmSize.Controls.Add(Me.LabelX100)
        Me.gFirmSize.Controls.Add(Me.LabelX101)
        Me.gFirmSize.Location = New System.Drawing.Point(291, 94)
        Me.gFirmSize.LookAndFeel.SkinName = "Darkroom"
        Me.gFirmSize.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gFirmSize.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gFirmSize.Name = "gFirmSize"
        Me.gFirmSize.Size = New System.Drawing.Size(273, 188)
        Me.gFirmSize.TabIndex = 1053
        Me.gFirmSize.Text = "Firm Size"
        '
        'lblLargeP
        '
        Me.lblLargeP.AccessibleDescription = ""
        '
        '
        '
        Me.lblLargeP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblLargeP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblLargeP.ForeColor = System.Drawing.Color.Black
        Me.lblLargeP.Location = New System.Drawing.Point(191, 156)
        Me.lblLargeP.Name = "lblLargeP"
        Me.lblLargeP.Size = New System.Drawing.Size(80, 25)
        Me.lblLargeP.TabIndex = 1050
        Me.lblLargeP.Text = "1.52 %"
        Me.lblLargeP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblLargeN
        '
        '
        '
        '
        Me.lblLargeN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblLargeN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblLargeN.ForeColor = System.Drawing.Color.Black
        Me.lblLargeN.Location = New System.Drawing.Point(105, 156)
        Me.lblLargeN.Name = "lblLargeN"
        Me.lblLargeN.Size = New System.Drawing.Size(80, 25)
        Me.lblLargeN.TabIndex = 1049
        Me.lblLargeN.Text = "42"
        Me.lblLargeN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX90
        '
        '
        '
        '
        Me.LabelX90.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX90.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX90.ForeColor = System.Drawing.Color.Black
        Me.LabelX90.Location = New System.Drawing.Point(5, 156)
        Me.LabelX90.Name = "LabelX90"
        Me.LabelX90.Size = New System.Drawing.Size(94, 25)
        Me.LabelX90.TabIndex = 1048
        Me.LabelX90.Text = "Large :"
        Me.LabelX90.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblMediumP
        '
        '
        '
        '
        Me.lblMediumP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMediumP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMediumP.ForeColor = System.Drawing.Color.Black
        Me.lblMediumP.Location = New System.Drawing.Point(191, 125)
        Me.lblMediumP.Name = "lblMediumP"
        Me.lblMediumP.Size = New System.Drawing.Size(80, 25)
        Me.lblMediumP.TabIndex = 1047
        Me.lblMediumP.Text = "9.88 %"
        Me.lblMediumP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMediumN
        '
        '
        '
        '
        Me.lblMediumN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMediumN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMediumN.ForeColor = System.Drawing.Color.Black
        Me.lblMediumN.Location = New System.Drawing.Point(105, 125)
        Me.lblMediumN.Name = "lblMediumN"
        Me.lblMediumN.Size = New System.Drawing.Size(80, 25)
        Me.lblMediumN.TabIndex = 1046
        Me.lblMediumN.Text = "241"
        Me.lblMediumN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX93
        '
        '
        '
        '
        Me.LabelX93.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX93.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX93.ForeColor = System.Drawing.Color.Black
        Me.LabelX93.Location = New System.Drawing.Point(5, 125)
        Me.LabelX93.Name = "LabelX93"
        Me.LabelX93.Size = New System.Drawing.Size(94, 25)
        Me.LabelX93.TabIndex = 1045
        Me.LabelX93.Text = "Medium :"
        Me.LabelX93.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblSmallP
        '
        '
        '
        '
        Me.lblSmallP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSmallP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSmallP.ForeColor = System.Drawing.Color.Black
        Me.lblSmallP.Location = New System.Drawing.Point(191, 94)
        Me.lblSmallP.Name = "lblSmallP"
        Me.lblSmallP.Size = New System.Drawing.Size(80, 25)
        Me.lblSmallP.TabIndex = 1044
        Me.lblSmallP.Text = "15.52 %"
        Me.lblSmallP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMicroP
        '
        '
        '
        '
        Me.lblMicroP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMicroP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMicroP.ForeColor = System.Drawing.Color.Black
        Me.lblMicroP.Location = New System.Drawing.Point(191, 63)
        Me.lblMicroP.Name = "lblMicroP"
        Me.lblMicroP.Size = New System.Drawing.Size(80, 25)
        Me.lblMicroP.TabIndex = 1043
        Me.lblMicroP.Text = "60.21 %"
        Me.lblMicroP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblSmallN
        '
        '
        '
        '
        Me.lblSmallN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSmallN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblSmallN.ForeColor = System.Drawing.Color.Black
        Me.lblSmallN.Location = New System.Drawing.Point(105, 94)
        Me.lblSmallN.Name = "lblSmallN"
        Me.lblSmallN.Size = New System.Drawing.Size(80, 25)
        Me.lblSmallN.TabIndex = 1042
        Me.lblSmallN.Text = "1,294"
        Me.lblSmallN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblMicroN
        '
        '
        '
        '
        Me.lblMicroN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMicroN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblMicroN.ForeColor = System.Drawing.Color.Black
        Me.lblMicroN.Location = New System.Drawing.Point(105, 63)
        Me.lblMicroN.Name = "lblMicroN"
        Me.lblMicroN.Size = New System.Drawing.Size(80, 25)
        Me.lblMicroN.TabIndex = 1041
        Me.lblMicroN.Text = "4,491"
        Me.lblMicroN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX98
        '
        '
        '
        '
        Me.LabelX98.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX98.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX98.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX98.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX98.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX98.ForeColor = System.Drawing.Color.Black
        Me.LabelX98.Location = New System.Drawing.Point(191, 32)
        Me.LabelX98.Name = "LabelX98"
        Me.LabelX98.Size = New System.Drawing.Size(80, 25)
        Me.LabelX98.TabIndex = 1040
        Me.LabelX98.Text = "Percentage"
        Me.LabelX98.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX99
        '
        '
        '
        '
        Me.LabelX99.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX99.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
        Me.LabelX99.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelX99.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX99.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX99.ForeColor = System.Drawing.Color.Black
        Me.LabelX99.Location = New System.Drawing.Point(105, 32)
        Me.LabelX99.Name = "LabelX99"
        Me.LabelX99.Size = New System.Drawing.Size(80, 25)
        Me.LabelX99.TabIndex = 1039
        Me.LabelX99.Text = "Number"
        Me.LabelX99.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX100
        '
        '
        '
        '
        Me.LabelX100.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX100.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX100.ForeColor = System.Drawing.Color.Black
        Me.LabelX100.Location = New System.Drawing.Point(5, 94)
        Me.LabelX100.Name = "LabelX100"
        Me.LabelX100.Size = New System.Drawing.Size(94, 25)
        Me.LabelX100.TabIndex = 1038
        Me.LabelX100.Text = "Small :"
        Me.LabelX100.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX101
        '
        '
        '
        '
        Me.LabelX101.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX101.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX101.ForeColor = System.Drawing.Color.Black
        Me.LabelX101.Location = New System.Drawing.Point(5, 63)
        Me.LabelX101.Name = "LabelX101"
        Me.LabelX101.Size = New System.Drawing.Size(94, 25)
        Me.LabelX101.TabIndex = 1037
        Me.LabelX101.Text = "Micro :"
        Me.LabelX101.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'c1
        '
        Me.c1.AppearanceNameSerializable = "Chameleon"
        Me.c1.BorderOptions.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.c1.BorderOptions.Thickness = 3
        Me.c1.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.c1.Location = New System.Drawing.Point(849, 94)
        Me.c1.Name = "c1"
        Me.c1.PaletteName = "FSFC New Palette"
        Me.c1.PaletteRepository.Add("FSFC New Palette", New DevExpress.XtraCharts.Palette("FSFC New Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer)))}))
        Me.c1.PaletteRepository.Add("FSFC Palette", New DevExpress.XtraCharts.Palette("FSFC Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.IndianRed, System.Drawing.Color.IndianRed), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(64, Byte), Integer)))}))
        Me.c1.PaletteRepository.Add("Palette 1", New DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Maroon, System.Drawing.Color.Maroon), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(177, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(177, Byte), Integer)))}))
        PieSeriesLabel1.Font = New System.Drawing.Font("Roboto", 8.0!)
        PieSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        PieSeriesLabel1.TextPattern = "{VP:P2}"
        Series1.Label = PieSeriesLabel1
        Series1.LegendTextPattern = "{S}"
        Series1.Name = "Series 1"
        Series1.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint1, SeriesPoint2})
        Series1.View = PieSeriesView1
        Me.c1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        DoughnutSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        DoughnutSeriesLabel1.TextPattern = "{VP:P2}"
        Me.c1.SeriesTemplate.Label = DoughnutSeriesLabel1
        Me.c1.SeriesTemplate.View = DoughnutSeriesView1
        Me.c1.Size = New System.Drawing.Size(303, 260)
        Me.c1.TabIndex = 1056
        ChartTitle1.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        ChartTitle1.Text = "Individual vs Corporate"
        ChartTitle1.TextColor = System.Drawing.Color.Black
        Me.c1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'pTotal
        '
        Me.pTotal.CanvasColor = System.Drawing.SystemColors.Control
        Me.pTotal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pTotal.Controls.Add(Me.LabelX102)
        Me.pTotal.DisabledBackColor = System.Drawing.Color.Empty
        Me.pTotal.Location = New System.Drawing.Point(769, 13)
        Me.pTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pTotal.Name = "pTotal"
        Me.pTotal.Size = New System.Drawing.Size(383, 74)
        Me.pTotal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pTotal.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pTotal.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pTotal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pTotal.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.pTotal.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.pTotal.Style.BorderWidth = 4
        Me.pTotal.Style.Font = New System.Drawing.Font("Century Gothic", 36.0!)
        Me.pTotal.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pTotal.Style.GradientAngle = 90
        Me.pTotal.Style.LineAlignment = System.Drawing.StringAlignment.Far
        Me.pTotal.TabIndex = 1057
        Me.pTotal.Text = "355,458"
        '
        'LabelX102
        '
        Me.LabelX102.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))
        '
        '
        '
        Me.LabelX102.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX102.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.LabelX102.ForeColor = System.Drawing.Color.White
        Me.LabelX102.Location = New System.Drawing.Point(1, 1)
        Me.LabelX102.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX102.Name = "LabelX102"
        Me.LabelX102.Size = New System.Drawing.Size(270, 22)
        Me.LabelX102.TabIndex = 77
        Me.LabelX102.Text = "Total Borrowers"
        '
        'c2
        '
        Me.c2.BorderOptions.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.c2.BorderOptions.Thickness = 3
        XyDiagram1.AxisX.Label.Font = New System.Drawing.Font("Roboto", 8.25!)
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Interlaced = True
        XyDiagram1.AxisY.Label.Font = New System.Drawing.Font("Roboto", 8.25!)
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram1.DefaultPane.BorderVisible = False
        Me.c2.Diagram = XyDiagram1
        Me.c2.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.c2.Location = New System.Drawing.Point(570, 359)
        Me.c2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.c2.Name = "c2"
        Me.c2.PaletteName = "FSFC New Palette"
        Me.c2.PaletteRepository.Add("FSFC New Palette", New DevExpress.XtraCharts.Palette("FSFC New Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.White, System.Drawing.Color.White)}))
        Me.c2.PaletteRepository.Add("FSFC Palette", New DevExpress.XtraCharts.Palette("FSFC Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Maroon, System.Drawing.Color.Maroon), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(51, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(51, Byte), Integer)))}))
        Me.c2.PaletteRepository.Add("FSFC Palette1", New DevExpress.XtraCharts.Palette("FSFC Palette1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.IndianRed, System.Drawing.Color.IndianRed), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(64, Byte), Integer)))}))
        SideBySideBarSeriesLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        SideBySideBarSeriesLabel1.TextPattern = "{V:P0}"
        Series2.Label = SideBySideBarSeriesLabel1
        Series2.LegendTextPattern = "{V:G}"
        Series2.Name = "Individual"
        Series2.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint3, SeriesPoint4, SeriesPoint5, SeriesPoint6, SeriesPoint7, SeriesPoint8, SeriesPoint9, SeriesPoint10, SeriesPoint11, SeriesPoint12, SeriesPoint13, SeriesPoint14})
        Series3.Name = "Corporate"
        Series3.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint15, SeriesPoint16, SeriesPoint17, SeriesPoint18, SeriesPoint19, SeriesPoint20, SeriesPoint21, SeriesPoint22, SeriesPoint23, SeriesPoint24, SeriesPoint25, SeriesPoint26})
        Series4.Name = "Total"
        Series4.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint27, SeriesPoint28, SeriesPoint29, SeriesPoint30, SeriesPoint31, SeriesPoint32, SeriesPoint33, SeriesPoint34, SeriesPoint35, SeriesPoint36, SeriesPoint37, SeriesPoint38})
        Me.c2.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series2, Series3, Series4}
        SideBySideBarSeriesLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        SideBySideBarSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.c2.SeriesTemplate.Label = SideBySideBarSeriesLabel2
        Me.c2.Size = New System.Drawing.Size(582, 325)
        Me.c2.TabIndex = 1058
        ChartTitle2.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        ChartTitle2.Text = "Registered Borrower"
        ChartTitle2.TextColor = System.Drawing.Color.Black
        Me.c2.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle2})
        '
        'btnChangeView
        '
        Me.btnChangeView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnChangeView.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnChangeView.Font = New System.Drawing.Font("Roboto", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnChangeView.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnChangeView.Location = New System.Drawing.Point(575, 366)
        Me.btnChangeView.Name = "btnChangeView"
        Me.btnChangeView.Size = New System.Drawing.Size(107, 30)
        Me.btnChangeView.TabIndex = 1059
        Me.btnChangeView.Text = "Change View"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(290, 521)
        Me.GridControl1.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit4, Me.RepositoryItemTextEdit1, Me.RepositoryItemCalcEdit1, Me.RepositoryItemSpinEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(274, 166)
        Me.GridControl1.TabIndex = 1060
        Me.GridControl1.TabStop = False
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn2, Me.GridColumn1})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupPanelText = "General Requirements"
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreAppearance = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PaintStyleName = "Style3D"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Industry"
        Me.GridColumn3.FieldName = "Industry"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowMove = False
        Me.GridColumn3.OptionsColumn.AllowSize = False
        Me.GridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 159
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "N"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "Number"
        Me.GridColumn2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowMove = False
        Me.GridColumn2.OptionsColumn.AllowSize = False
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 35
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "%"
        Me.GridColumn1.FieldName = "Percent"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowMove = False
        Me.GridColumn1.OptionsColumn.AllowSize = False
        Me.GridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 45
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        Me.RepositoryItemCheckEdit4.ValueChecked = "True"
        Me.RepositoryItemCheckEdit4.ValueUnchecked = "False"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemCalcEdit1.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemCalcEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemCalcEdit1.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCalcEdit1.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCalcEdit1.AppearanceDropDown.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCalcEdit1.AppearanceDropDown.Options.UseFont = True
        Me.RepositoryItemCalcEdit1.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCalcEdit1.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCalcEdit1.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCalcEdit1.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemCalcEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        Me.RepositoryItemCalcEdit1.NullValuePrompt = "0"
        Me.RepositoryItemCalcEdit1.NullValuePromptShowForEmptyValue = True
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'Timer_Refresh
        '
        Me.Timer_Refresh.Interval = 1000
        '
        'FrmBorrowerDashboard
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1177, 709)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnChangeView)
        Me.Controls.Add(Me.c2)
        Me.Controls.Add(Me.pTotal)
        Me.Controls.Add(Me.gFirmSize)
        Me.Controls.Add(Me.c1)
        Me.Controls.Add(Me.pCorporate)
        Me.Controls.Add(Me.gHouseOwnership)
        Me.Controls.Add(Me.gGender)
        Me.Controls.Add(Me.gDependents)
        Me.Controls.Add(Me.gCitizenship)
        Me.Controls.Add(Me.gAge)
        Me.Controls.Add(Me.gCivilStatus)
        Me.Controls.Add(Me.pIndividual)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBorrowerDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pIndividual.ResumeLayout(False)
        CType(Me.gGender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gGender.ResumeLayout(False)
        CType(Me.gCivilStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gCivilStatus.ResumeLayout(False)
        CType(Me.gAge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gAge.ResumeLayout(False)
        CType(Me.gCitizenship, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gCitizenship.ResumeLayout(False)
        CType(Me.gDependents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDependents.ResumeLayout(False)
        CType(Me.gHouseOwnership, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gHouseOwnership.ResumeLayout(False)
        Me.pCorporate.ResumeLayout(False)
        CType(Me.gFirmSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gFirmSize.ResumeLayout(False)
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pTotal.ResumeLayout(False)
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pIndividual As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gGender As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFemaleP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMaleP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFemaleN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMaleN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gCivilStatus As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblWidowedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblWidowedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSeparatedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSeparatedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMarriedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSingleP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMarriedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSingleN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gAge As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbl41_50P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl41_50N As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl31_40P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl31_40N As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl21_30P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl20BelowP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl21_30N As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl20BelowN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl51AboveP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl51AboveN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gCitizenship As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblForeignerP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFilipinoP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblForeignerN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFilipinoN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX44 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX45 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX46 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX47 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gDependents As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbl4DependentP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl4DependentN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX50 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl3DependentP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl3DependentN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX53 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl2DependentP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl2DependentN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX56 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl1DependentP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl0DependentP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl1DependentN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbl0DependentN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX61 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX62 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX63 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX64 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gHouseOwnership As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblRentedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblRentedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX70 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFreeP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOwnedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFreeN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOwnedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX75 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX76 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX77 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX78 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pCorporate As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX87 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gFirmSize As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblLargeP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblLargeN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX90 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMediumP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMediumN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX93 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSmallP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMicroP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSmallN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMicroN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX98 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX99 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX100 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX101 As DevComponents.DotNetBar.LabelX
    Friend WithEvents c1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents pTotal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX102 As DevComponents.DotNetBar.LabelX
    Friend WithEvents c2 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents btnChangeView As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Timer_Refresh As Timer
End Class
