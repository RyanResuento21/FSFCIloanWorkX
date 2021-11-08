<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBorrowersHistory
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
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PieSeriesLabel1 As DevExpress.XtraCharts.PieSeriesLabel = New DevExpress.XtraCharts.PieSeriesLabel()
        Dim SeriesPoint1 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Individual", New Object() {CType(340252.0R, Object)}, 0)
        Dim SeriesPoint2 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("Corporate", New Object() {CType(15206.0R, Object)}, 2)
        Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
        Dim DoughnutSeriesLabel1 As DevExpress.XtraCharts.DoughnutSeriesLabel = New DevExpress.XtraCharts.DoughnutSeriesLabel()
        Dim DoughnutSeriesView1 As DevExpress.XtraCharts.DoughnutSeriesView = New DevExpress.XtraCharts.DoughnutSeriesView()
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.PanelEx9 = New DevComponents.DotNetBar.PanelEx()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.pFaceAmount = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.c1 = New DevExpress.XtraCharts.ChartControl()
        Me.gAccounts = New DevExpress.XtraEditors.GroupControl()
        Me.lblClosedP = New DevComponents.DotNetBar.LabelX()
        Me.lblClosedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.lblOngoingP = New DevComponents.DotNetBar.LabelX()
        Me.lblForReleaseP = New DevComponents.DotNetBar.LabelX()
        Me.lblOngoingN = New DevComponents.DotNetBar.LabelX()
        Me.lblForReleaseN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.gRequirements = New DevExpress.XtraEditors.GroupControl()
        Me.lblIncP = New DevComponents.DotNetBar.LabelX()
        Me.lblCompP = New DevComponents.DotNetBar.LabelX()
        Me.lblIncN = New DevComponents.DotNetBar.LabelX()
        Me.lblCompN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.gApplication = New DevExpress.XtraEditors.GroupControl()
        Me.lblDisapprovedP = New DevComponents.DotNetBar.LabelX()
        Me.lblDisapprovedN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.lblApprovedP = New DevComponents.DotNetBar.LabelX()
        Me.lblPendingP = New DevComponents.DotNetBar.LabelX()
        Me.lblApprovedN = New DevComponents.DotNetBar.LabelX()
        Me.lblPendingN = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.CbxPrefix_B = New SergeUtils.EasyCompletionComboBox()
        Me.cbxSuffix_B = New SergeUtils.EasyCompletionComboBox()
        Me.TxtLastN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMiddleN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFirstN_B = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.pb_B = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx9.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pFaceAmount.SuspendLayout()
        CType(Me.c1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gAccounts.SuspendLayout()
        CType(Me.gRequirements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gRequirements.SuspendLayout()
        CType(Me.gApplication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gApplication.SuspendLayout()
        CType(Me.pb_B.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx9
        '
        Me.PanelEx9.AutoScroll = True
        Me.PanelEx9.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx9.Controls.Add(Me.GridControl1)
        Me.PanelEx9.Controls.Add(Me.pFaceAmount)
        Me.PanelEx9.Controls.Add(Me.c1)
        Me.PanelEx9.Controls.Add(Me.gAccounts)
        Me.PanelEx9.Controls.Add(Me.gRequirements)
        Me.PanelEx9.Controls.Add(Me.gApplication)
        Me.PanelEx9.Controls.Add(Me.CbxPrefix_B)
        Me.PanelEx9.Controls.Add(Me.cbxSuffix_B)
        Me.PanelEx9.Controls.Add(Me.TxtLastN_B)
        Me.PanelEx9.Controls.Add(Me.TxtMiddleN_B)
        Me.PanelEx9.Controls.Add(Me.TxtFirstN_B)
        Me.PanelEx9.Controls.Add(Me.LabelX43)
        Me.PanelEx9.Controls.Add(Me.pb_B)
        Me.PanelEx9.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx9.Location = New System.Drawing.Point(0, 73)
        Me.PanelEx9.Name = "PanelEx9"
        Me.PanelEx9.Size = New System.Drawing.Size(1167, 603)
        Me.PanelEx9.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx9.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx9.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx9.Style.GradientAngle = 90
        Me.PanelEx9.TabIndex = 1005
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl1.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(6, 336)
        Me.GridControl1.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1149, 267)
        Me.GridControl1.TabIndex = 1713
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
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
        Me.GridColumn2.Caption = "Product"
        Me.GridColumn2.FieldName = "Product"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 120
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Account No"
        Me.GridColumn3.FieldName = "Account Number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 120
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Date Granted"
        Me.GridColumn4.FieldName = "Date Granted"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 120
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Terms"
        Me.GridColumn5.FieldName = "Terms"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 60
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Interest"
        Me.GridColumn6.FieldName = "Interest"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 60
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Principal"
        Me.GridColumn7.FieldName = "Principal"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 95
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Net Proceeds"
        Me.GridColumn8.FieldName = "Net Proceeds"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 95
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "GMA"
        Me.GridColumn9.FieldName = "GMA"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 95
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Collateral"
        Me.GridColumn10.FieldName = "Collateral"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 231
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Credit Investigator"
        Me.GridColumn11.FieldName = "CI"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        Me.GridColumn11.Width = 200
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Account Status"
        Me.GridColumn12.FieldName = "Account Status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 150
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Account Remedial"
        Me.GridColumn13.FieldName = "Account Remedial"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        Me.GridColumn13.Width = 150
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Branch"
        Me.GridColumn14.FieldName = "Branch"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 12
        Me.GridColumn14.Width = 150
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
        'pFaceAmount
        '
        Me.pFaceAmount.CanvasColor = System.Drawing.SystemColors.Control
        Me.pFaceAmount.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pFaceAmount.Controls.Add(Me.LabelX155)
        Me.pFaceAmount.DisabledBackColor = System.Drawing.Color.Empty
        Me.pFaceAmount.Location = New System.Drawing.Point(569, 202)
        Me.pFaceAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pFaceAmount.Name = "pFaceAmount"
        Me.pFaceAmount.Size = New System.Drawing.Size(268, 127)
        Me.pFaceAmount.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pFaceAmount.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pFaceAmount.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pFaceAmount.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pFaceAmount.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pFaceAmount.Style.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pFaceAmount.Style.ForeColor.Color = System.Drawing.Color.White
        Me.pFaceAmount.Style.GradientAngle = 90
        Me.pFaceAmount.TabIndex = 1712
        Me.pFaceAmount.Text = "P650,520,502.00"
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
        Me.LabelX155.Location = New System.Drawing.Point(3, 4)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(251, 22)
        Me.LabelX155.TabIndex = 78
        Me.LabelX155.Text = "Total Face Amount"
        '
        'c1
        '
        Me.c1.AppearanceNameSerializable = "Chameleon"
        Me.c1.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.c1.Location = New System.Drawing.Point(843, 38)
        Me.c1.Name = "c1"
        Me.c1.PaletteName = "FSFC New Palette"
        Me.c1.PaletteRepository.Add("FSFC New Palette", New DevExpress.XtraCharts.Palette("FSFC New Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(242, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer)))}))
        Me.c1.PaletteRepository.Add("Palette 1", New DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Maroon, System.Drawing.Color.Maroon), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(177, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(177, Byte), Integer)))}))
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
        Me.c1.Size = New System.Drawing.Size(312, 291)
        Me.c1.TabIndex = 1708
        ChartTitle1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartTitle1.Text = "Payments vs Payables"
        ChartTitle1.TextColor = System.Drawing.Color.Black
        Me.c1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'gAccounts
        '
        Me.gAccounts.Appearance.BackColor = System.Drawing.Color.White
        Me.gAccounts.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gAccounts.Appearance.Options.UseBackColor = True
        Me.gAccounts.Appearance.Options.UseFont = True
        Me.gAccounts.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gAccounts.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gAccounts.AppearanceCaption.Options.UseFont = True
        Me.gAccounts.AppearanceCaption.Options.UseForeColor = True
        Me.gAccounts.Controls.Add(Me.lblClosedP)
        Me.gAccounts.Controls.Add(Me.lblClosedN)
        Me.gAccounts.Controls.Add(Me.LabelX5)
        Me.gAccounts.Controls.Add(Me.lblOngoingP)
        Me.gAccounts.Controls.Add(Me.lblForReleaseP)
        Me.gAccounts.Controls.Add(Me.lblOngoingN)
        Me.gAccounts.Controls.Add(Me.lblForReleaseN)
        Me.gAccounts.Controls.Add(Me.LabelX25)
        Me.gAccounts.Controls.Add(Me.LabelX26)
        Me.gAccounts.Controls.Add(Me.LabelX28)
        Me.gAccounts.Controls.Add(Me.LabelX29)
        Me.gAccounts.Location = New System.Drawing.Point(564, 38)
        Me.gAccounts.LookAndFeel.SkinName = "Darkroom"
        Me.gAccounts.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gAccounts.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gAccounts.Name = "gAccounts"
        Me.gAccounts.Size = New System.Drawing.Size(273, 158)
        Me.gAccounts.TabIndex = 1707
        Me.gAccounts.Text = "Total Number of Accounts"
        '
        'lblClosedP
        '
        '
        '
        '
        Me.lblClosedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblClosedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblClosedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblClosedP.Location = New System.Drawing.Point(191, 125)
        Me.lblClosedP.Name = "lblClosedP"
        Me.lblClosedP.Size = New System.Drawing.Size(80, 25)
        Me.lblClosedP.TabIndex = 1047
        Me.lblClosedP.Text = "0.00 %"
        Me.lblClosedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblClosedN
        '
        '
        '
        '
        Me.lblClosedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblClosedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblClosedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblClosedN.Location = New System.Drawing.Point(105, 125)
        Me.lblClosedN.Name = "lblClosedN"
        Me.lblClosedN.Size = New System.Drawing.Size(80, 25)
        Me.lblClosedN.TabIndex = 1046
        Me.lblClosedN.Text = "0"
        Me.lblClosedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(5, 125)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(94, 25)
        Me.LabelX5.TabIndex = 1045
        Me.LabelX5.Text = "Closed :"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblOngoingP
        '
        '
        '
        '
        Me.lblOngoingP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOngoingP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblOngoingP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOngoingP.Location = New System.Drawing.Point(191, 94)
        Me.lblOngoingP.Name = "lblOngoingP"
        Me.lblOngoingP.Size = New System.Drawing.Size(80, 25)
        Me.lblOngoingP.TabIndex = 1044
        Me.lblOngoingP.Text = "0.00 %"
        Me.lblOngoingP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblForReleaseP
        '
        '
        '
        '
        Me.lblForReleaseP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblForReleaseP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblForReleaseP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblForReleaseP.Location = New System.Drawing.Point(191, 63)
        Me.lblForReleaseP.Name = "lblForReleaseP"
        Me.lblForReleaseP.Size = New System.Drawing.Size(80, 25)
        Me.lblForReleaseP.TabIndex = 1043
        Me.lblForReleaseP.Text = "0.00 %"
        Me.lblForReleaseP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOngoingN
        '
        '
        '
        '
        Me.lblOngoingN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOngoingN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblOngoingN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOngoingN.Location = New System.Drawing.Point(105, 94)
        Me.lblOngoingN.Name = "lblOngoingN"
        Me.lblOngoingN.Size = New System.Drawing.Size(80, 25)
        Me.lblOngoingN.TabIndex = 1042
        Me.lblOngoingN.Text = "0"
        Me.lblOngoingN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblForReleaseN
        '
        '
        '
        '
        Me.lblForReleaseN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblForReleaseN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblForReleaseN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblForReleaseN.Location = New System.Drawing.Point(105, 63)
        Me.lblForReleaseN.Name = "lblForReleaseN"
        Me.lblForReleaseN.Size = New System.Drawing.Size(80, 25)
        Me.lblForReleaseN.TabIndex = 1041
        Me.lblForReleaseN.Text = "0"
        Me.lblForReleaseN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX25
        '
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX25.Location = New System.Drawing.Point(191, 32)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(80, 25)
        Me.LabelX25.TabIndex = 1040
        Me.LabelX25.Text = "Percentage"
        Me.LabelX25.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX26
        '
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX26.Location = New System.Drawing.Point(105, 32)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(80, 25)
        Me.LabelX26.TabIndex = 1039
        Me.LabelX26.Text = "Number"
        Me.LabelX26.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX28
        '
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX28.Location = New System.Drawing.Point(5, 94)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(94, 25)
        Me.LabelX28.TabIndex = 1038
        Me.LabelX28.Text = "On Going :"
        Me.LabelX28.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX29
        '
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX29.Location = New System.Drawing.Point(5, 63)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(94, 25)
        Me.LabelX29.TabIndex = 1037
        Me.LabelX29.Text = "For Release :"
        Me.LabelX29.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gRequirements
        '
        Me.gRequirements.Appearance.BackColor = System.Drawing.Color.White
        Me.gRequirements.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gRequirements.Appearance.Options.UseBackColor = True
        Me.gRequirements.Appearance.Options.UseFont = True
        Me.gRequirements.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gRequirements.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gRequirements.AppearanceCaption.Options.UseFont = True
        Me.gRequirements.AppearanceCaption.Options.UseForeColor = True
        Me.gRequirements.Controls.Add(Me.lblIncP)
        Me.gRequirements.Controls.Add(Me.lblCompP)
        Me.gRequirements.Controls.Add(Me.lblIncN)
        Me.gRequirements.Controls.Add(Me.lblCompN)
        Me.gRequirements.Controls.Add(Me.LabelX10)
        Me.gRequirements.Controls.Add(Me.LabelX11)
        Me.gRequirements.Controls.Add(Me.LabelX12)
        Me.gRequirements.Controls.Add(Me.LabelX17)
        Me.gRequirements.Location = New System.Drawing.Point(285, 202)
        Me.gRequirements.LookAndFeel.SkinName = "Darkroom"
        Me.gRequirements.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gRequirements.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gRequirements.Name = "gRequirements"
        Me.gRequirements.Size = New System.Drawing.Size(273, 127)
        Me.gRequirements.TabIndex = 1706
        Me.gRequirements.Text = "Total Requirements"
        '
        'lblIncP
        '
        '
        '
        '
        Me.lblIncP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblIncP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblIncP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblIncP.Location = New System.Drawing.Point(191, 94)
        Me.lblIncP.Name = "lblIncP"
        Me.lblIncP.Size = New System.Drawing.Size(80, 25)
        Me.lblIncP.TabIndex = 1044
        Me.lblIncP.Text = "0.00 %"
        Me.lblIncP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCompP
        '
        '
        '
        '
        Me.lblCompP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCompP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCompP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCompP.Location = New System.Drawing.Point(191, 63)
        Me.lblCompP.Name = "lblCompP"
        Me.lblCompP.Size = New System.Drawing.Size(80, 25)
        Me.lblCompP.TabIndex = 1043
        Me.lblCompP.Text = "0.00 %"
        Me.lblCompP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblIncN
        '
        '
        '
        '
        Me.lblIncN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblIncN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblIncN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblIncN.Location = New System.Drawing.Point(105, 94)
        Me.lblIncN.Name = "lblIncN"
        Me.lblIncN.Size = New System.Drawing.Size(80, 25)
        Me.lblIncN.TabIndex = 1042
        Me.lblIncN.Text = "0"
        Me.lblIncN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCompN
        '
        '
        '
        '
        Me.lblCompN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCompN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblCompN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCompN.Location = New System.Drawing.Point(105, 63)
        Me.lblCompN.Name = "lblCompN"
        Me.lblCompN.Size = New System.Drawing.Size(80, 25)
        Me.lblCompN.TabIndex = 1041
        Me.lblCompN.Text = "0"
        Me.lblCompN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX10.Location = New System.Drawing.Point(191, 32)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(80, 25)
        Me.LabelX10.TabIndex = 1040
        Me.LabelX10.Text = "Percentage"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelX11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX11.Location = New System.Drawing.Point(105, 32)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(80, 25)
        Me.LabelX11.TabIndex = 1039
        Me.LabelX11.Text = "Number"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX12.Location = New System.Drawing.Point(5, 94)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(94, 25)
        Me.LabelX12.TabIndex = 1038
        Me.LabelX12.Text = "Incomplete :"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(5, 63)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(94, 25)
        Me.LabelX17.TabIndex = 1037
        Me.LabelX17.Text = "Complete :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'gApplication
        '
        Me.gApplication.Appearance.BackColor = System.Drawing.Color.White
        Me.gApplication.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gApplication.Appearance.Options.UseBackColor = True
        Me.gApplication.Appearance.Options.UseFont = True
        Me.gApplication.AppearanceCaption.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gApplication.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gApplication.AppearanceCaption.Options.UseFont = True
        Me.gApplication.AppearanceCaption.Options.UseForeColor = True
        Me.gApplication.Controls.Add(Me.lblDisapprovedP)
        Me.gApplication.Controls.Add(Me.lblDisapprovedN)
        Me.gApplication.Controls.Add(Me.LabelX6)
        Me.gApplication.Controls.Add(Me.lblApprovedP)
        Me.gApplication.Controls.Add(Me.lblPendingP)
        Me.gApplication.Controls.Add(Me.lblApprovedN)
        Me.gApplication.Controls.Add(Me.lblPendingN)
        Me.gApplication.Controls.Add(Me.LabelX13)
        Me.gApplication.Controls.Add(Me.LabelX14)
        Me.gApplication.Controls.Add(Me.LabelX15)
        Me.gApplication.Controls.Add(Me.LabelX16)
        Me.gApplication.Location = New System.Drawing.Point(285, 38)
        Me.gApplication.LookAndFeel.SkinName = "Darkroom"
        Me.gApplication.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gApplication.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gApplication.Name = "gApplication"
        Me.gApplication.Size = New System.Drawing.Size(273, 158)
        Me.gApplication.TabIndex = 1701
        Me.gApplication.Text = "Total Number of Application"
        '
        'lblDisapprovedP
        '
        '
        '
        '
        Me.lblDisapprovedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDisapprovedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDisapprovedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDisapprovedP.Location = New System.Drawing.Point(191, 125)
        Me.lblDisapprovedP.Name = "lblDisapprovedP"
        Me.lblDisapprovedP.Size = New System.Drawing.Size(80, 25)
        Me.lblDisapprovedP.TabIndex = 1047
        Me.lblDisapprovedP.Text = "0.00 %"
        Me.lblDisapprovedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDisapprovedN
        '
        '
        '
        '
        Me.lblDisapprovedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDisapprovedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblDisapprovedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDisapprovedN.Location = New System.Drawing.Point(105, 125)
        Me.lblDisapprovedN.Name = "lblDisapprovedN"
        Me.lblDisapprovedN.Size = New System.Drawing.Size(80, 25)
        Me.lblDisapprovedN.TabIndex = 1046
        Me.lblDisapprovedN.Text = "0"
        Me.lblDisapprovedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(5, 125)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(94, 25)
        Me.LabelX6.TabIndex = 1045
        Me.LabelX6.Text = "Disapproved :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblApprovedP
        '
        '
        '
        '
        Me.lblApprovedP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblApprovedP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblApprovedP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblApprovedP.Location = New System.Drawing.Point(191, 94)
        Me.lblApprovedP.Name = "lblApprovedP"
        Me.lblApprovedP.Size = New System.Drawing.Size(80, 25)
        Me.lblApprovedP.TabIndex = 1044
        Me.lblApprovedP.Text = "0.00 %"
        Me.lblApprovedP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblPendingP
        '
        '
        '
        '
        Me.lblPendingP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPendingP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPendingP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPendingP.Location = New System.Drawing.Point(191, 63)
        Me.lblPendingP.Name = "lblPendingP"
        Me.lblPendingP.Size = New System.Drawing.Size(80, 25)
        Me.lblPendingP.TabIndex = 1043
        Me.lblPendingP.Text = "0.00 %"
        Me.lblPendingP.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblApprovedN
        '
        '
        '
        '
        Me.lblApprovedN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblApprovedN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblApprovedN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblApprovedN.Location = New System.Drawing.Point(105, 94)
        Me.lblApprovedN.Name = "lblApprovedN"
        Me.lblApprovedN.Size = New System.Drawing.Size(80, 25)
        Me.lblApprovedN.TabIndex = 1042
        Me.lblApprovedN.Text = "0"
        Me.lblApprovedN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblPendingN
        '
        '
        '
        '
        Me.lblPendingN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPendingN.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lblPendingN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblPendingN.Location = New System.Drawing.Point(105, 63)
        Me.lblPendingN.Name = "lblPendingN"
        Me.lblPendingN.Size = New System.Drawing.Size(80, 25)
        Me.lblPendingN.TabIndex = 1041
        Me.lblPendingN.Text = "0"
        Me.lblPendingN.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
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
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
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
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX15.Location = New System.Drawing.Point(5, 94)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(94, 25)
        Me.LabelX15.TabIndex = 1038
        Me.LabelX15.Text = "Approved :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LabelX16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX16.Location = New System.Drawing.Point(5, 63)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(94, 25)
        Me.LabelX16.TabIndex = 1037
        Me.LabelX16.Text = "Pending :"
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'CbxPrefix_B
        '
        Me.CbxPrefix_B.DisplayMember = "PREFIX"
        Me.CbxPrefix_B.Enabled = False
        Me.CbxPrefix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxPrefix_B.FormattingEnabled = True
        Me.CbxPrefix_B.Location = New System.Drawing.Point(415, 7)
        Me.CbxPrefix_B.MaxLength = 15
        Me.CbxPrefix_B.Name = "CbxPrefix_B"
        Me.CbxPrefix_B.Size = New System.Drawing.Size(72, 25)
        Me.CbxPrefix_B.TabIndex = 77
        Me.CbxPrefix_B.ValueMember = "ID"
        '
        'cbxSuffix_B
        '
        Me.cbxSuffix_B.Enabled = False
        Me.cbxSuffix_B.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxSuffix_B.FormattingEnabled = True
        Me.cbxSuffix_B.Location = New System.Drawing.Point(1111, 7)
        Me.cbxSuffix_B.MaxLength = 10
        Me.cbxSuffix_B.Name = "cbxSuffix_B"
        Me.cbxSuffix_B.Size = New System.Drawing.Size(44, 25)
        Me.cbxSuffix_B.TabIndex = 81
        '
        'TxtLastN_B
        '
        '
        '
        '
        Me.TxtLastN_B.Border.Class = "TextBoxBorder"
        Me.TxtLastN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLastN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLastN_B.Enabled = False
        Me.TxtLastN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastN_B.Location = New System.Drawing.Point(905, 7)
        Me.TxtLastN_B.MaxLength = 35
        Me.TxtLastN_B.Name = "TxtLastN_B"
        Me.TxtLastN_B.PreventEnterBeep = True
        Me.TxtLastN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtLastN_B.TabIndex = 80
        Me.TxtLastN_B.WatermarkText = "Last Name"
        '
        'TxtMiddleN_B
        '
        '
        '
        '
        Me.TxtMiddleN_B.Border.Class = "TextBoxBorder"
        Me.TxtMiddleN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMiddleN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMiddleN_B.Enabled = False
        Me.TxtMiddleN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMiddleN_B.Location = New System.Drawing.Point(699, 7)
        Me.TxtMiddleN_B.MaxLength = 35
        Me.TxtMiddleN_B.Name = "TxtMiddleN_B"
        Me.TxtMiddleN_B.PreventEnterBeep = True
        Me.TxtMiddleN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtMiddleN_B.TabIndex = 79
        Me.TxtMiddleN_B.WatermarkText = "Middle Name"
        '
        'TxtFirstN_B
        '
        '
        '
        '
        Me.TxtFirstN_B.Border.Class = "TextBoxBorder"
        Me.TxtFirstN_B.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFirstN_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFirstN_B.Enabled = False
        Me.TxtFirstN_B.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFirstN_B.Location = New System.Drawing.Point(493, 7)
        Me.TxtFirstN_B.MaxLength = 35
        Me.TxtFirstN_B.Name = "TxtFirstN_B"
        Me.TxtFirstN_B.PreventEnterBeep = True
        Me.TxtFirstN_B.Size = New System.Drawing.Size(200, 23)
        Me.TxtFirstN_B.TabIndex = 78
        Me.TxtFirstN_B.WatermarkText = "First Name"
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
        Me.LabelX43.Location = New System.Drawing.Point(283, 7)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(127, 23)
        Me.LabelX43.TabIndex = 76
        Me.LabelX43.Text = "Borrower's Name :"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'pb_B
        '
        Me.pb_B.EditValue = Global.FSFC_System.My.Resources.Resources.Avatar
        Me.pb_B.Location = New System.Drawing.Point(6, 38)
        Me.pb_B.Name = "pb_B"
        Me.pb_B.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.pb_B.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.pb_B.Properties.Appearance.Options.UseBackColor = True
        Me.pb_B.Properties.Appearance.Options.UseFont = True
        Me.pb_B.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pb_B.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_B.Size = New System.Drawing.Size(273, 291)
        Me.pb_B.TabIndex = 6
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 676)
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
        Me.PanelEx3.TabIndex = 1004
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(3, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1015
        Me.btnCancel.Text = "Close"
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1167, 73)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1003
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
        Me.PictureEdit1.Size = New System.Drawing.Size(307, 71)
        Me.PictureEdit1.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(671, 34)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(476, 32)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Company Policy <b><u>strictly prohibits</u></b> employees from soliciting or rece" &
    "iving any compensation in the processing of loan applications."
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(671, 4)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(476, 32)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "BORROWER HISTORY"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'FrmBorrowersHistory
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 713)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx9)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBorrowersHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx9.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pFaceAmount.ResumeLayout(False)
        CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gAccounts.ResumeLayout(False)
        CType(Me.gRequirements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gRequirements.ResumeLayout(False)
        CType(Me.gApplication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gApplication.ResumeLayout(False)
        CType(Me.pb_B.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx9 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents gRequirements As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblIncP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCompP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblIncN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCompN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gApplication As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblDisapprovedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDisapprovedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblApprovedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPendingP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblApprovedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPendingN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CbxPrefix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxSuffix_B As SergeUtils.EasyCompletionComboBox
    Friend WithEvents TxtLastN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMiddleN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFirstN_B As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pb_B As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gAccounts As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblClosedP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblClosedN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOngoingP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblForReleaseP As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOngoingN As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblForReleaseN As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents c1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents pFaceAmount As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
End Class
