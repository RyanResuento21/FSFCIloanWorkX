<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCaseMonitoring
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
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanelEx10 = New DevComponents.DotNetBar.PanelEx()
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.dtpAsOf = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Chart1 = New DevExpress.XtraCharts.ChartControl()
        Me.lblTotal_P_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_P_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_P_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_P_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_P_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_P_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_BV_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_BV_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_BV_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_BV_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_BV_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_BV_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_A_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_A_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_A_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_A_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_A_L2 = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_A_L2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX44 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX45 = New DevComponents.DotNetBar.LabelX()
        Me.lblLM2 = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_P_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_P_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_P_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_P_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_P_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_P_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_BV_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_BV_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_BV_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_BV_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_BV_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_BV_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_A_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_A_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_A_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_A_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_A_L1 = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_A_L1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.lblLM1 = New DevComponents.DotNetBar.LabelX()
        Me.lblCurrent = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_P = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_P = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_P = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_P = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_P = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_P = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_BV = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_BV = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_BV = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_BV = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_BV = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_BV = New DevComponents.DotNetBar.LabelX()
        Me.lblTotal_A = New DevComponents.DotNetBar.LabelX()
        Me.lblArchieved_A = New DevComponents.DotNetBar.LabelX()
        Me.lblDismissed_A = New DevComponents.DotNetBar.LabelX()
        Me.lblExecuted_A = New DevComponents.DotNetBar.LabelX()
        Me.lblDecided_A = New DevComponents.DotNetBar.LabelX()
        Me.lblOnGoing_A = New DevComponents.DotNetBar.LabelX()
        Me.LabelX62 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX61 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX60 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX59 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX58 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX57 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX56 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX55 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX53 = New DevComponents.DotNetBar.LabelX()
        Me.tabSummary = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand29 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn40 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand30 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand31 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn41 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn42 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand32 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn43 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn44 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand33 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand34 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn45 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn46 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand35 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn47 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn48 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand36 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand37 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn49 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn50 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand38 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn51 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn52 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand39 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand40 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn53 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn54 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand41 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn55 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn56 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand42 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand43 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn57 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn58 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand44 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn59 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn60 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand45 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand46 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn61 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn62 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand47 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn63 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn64 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand48 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand49 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn65 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn66 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand50 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn67 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn68 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand51 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand52 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn69 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn70 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand53 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn71 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn72 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand57 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand58 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn77 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn78 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand59 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn79 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn80 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand54 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand55 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn73 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn74 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand56 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn75 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn76 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabDecided = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand28 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn39 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand12 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand13 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand14 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn19 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn20 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand15 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn21 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn22 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand16 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand17 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn23 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand18 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn25 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn26 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand19 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand20 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn27 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn28 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand21 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn29 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn30 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand22 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand23 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn31 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn32 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand24 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn33 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn34 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand25 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand26 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn35 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn36 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand27 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn37 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn38 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabOngoing = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl6 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand96 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn128 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand97 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand98 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn129 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn130 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand99 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn131 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn132 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabWritteOff = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand92 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn123 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand93 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand94 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn124 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn125 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand95 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn126 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn127 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabArchived = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand79 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn106 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand80 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand81 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn107 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn108 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand82 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn109 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn110 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand83 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand84 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn111 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn112 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand85 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn113 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn114 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand86 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand87 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn115 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn116 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand88 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn117 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn118 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand89 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand90 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn119 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn120 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand91 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn121 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn122 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabDismissed = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand60 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn81 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand61 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand62 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn82 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn83 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand63 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn84 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn85 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand64 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand65 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn86 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn87 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand66 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn88 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn89 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand67 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand68 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn90 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn91 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand69 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn92 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn93 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand70 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand71 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn94 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn95 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand72 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn96 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn97 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand73 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand74 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn98 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn99 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand75 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn100 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn101 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand76 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand77 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn102 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn103 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand78 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn104 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn105 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tabExecuted = New DevComponents.DotNetBar.SuperTabItem()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.PanelEx10.SuspendLayout()
        CType(Me.dtpAsOf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel7.SuspendLayout()
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(372, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(408, 26)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "CASE MONITORING"
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel6)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel7)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.FixedTabSize = New System.Drawing.Size(163, 25)
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 66)
        Me.SuperTabControl1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(1167, 596)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1690
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabSummary, Me.tabOngoing, Me.tabDecided, Me.tabExecuted, Me.tabDismissed, Me.tabArchived, Me.tabWritteOff})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock
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
        Me.SuperTabControlPanel1.TabItem = Me.tabSummary
        '
        'PanelEx10
        '
        Me.PanelEx10.AutoScroll = True
        Me.PanelEx10.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx10.Controls.Add(Me.btnSearch)
        Me.PanelEx10.Controls.Add(Me.dtpAsOf)
        Me.PanelEx10.Controls.Add(Me.LabelX15)
        Me.PanelEx10.Controls.Add(Me.Chart1)
        Me.PanelEx10.Controls.Add(Me.lblTotal_P_L2)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_P_L2)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_P_L2)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_P_L2)
        Me.PanelEx10.Controls.Add(Me.lblDecided_P_L2)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_P_L2)
        Me.PanelEx10.Controls.Add(Me.lblTotal_BV_L2)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_BV_L2)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_BV_L2)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_BV_L2)
        Me.PanelEx10.Controls.Add(Me.lblDecided_BV_L2)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_BV_L2)
        Me.PanelEx10.Controls.Add(Me.lblTotal_A_L2)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_A_L2)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_A_L2)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_A_L2)
        Me.PanelEx10.Controls.Add(Me.lblDecided_A_L2)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_A_L2)
        Me.PanelEx10.Controls.Add(Me.LabelX43)
        Me.PanelEx10.Controls.Add(Me.LabelX44)
        Me.PanelEx10.Controls.Add(Me.LabelX45)
        Me.PanelEx10.Controls.Add(Me.lblLM2)
        Me.PanelEx10.Controls.Add(Me.lblTotal_P_L1)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_P_L1)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_P_L1)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_P_L1)
        Me.PanelEx10.Controls.Add(Me.lblDecided_P_L1)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_P_L1)
        Me.PanelEx10.Controls.Add(Me.lblTotal_BV_L1)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_BV_L1)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_BV_L1)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_BV_L1)
        Me.PanelEx10.Controls.Add(Me.lblDecided_BV_L1)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_BV_L1)
        Me.PanelEx10.Controls.Add(Me.lblTotal_A_L1)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_A_L1)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_A_L1)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_A_L1)
        Me.PanelEx10.Controls.Add(Me.lblDecided_A_L1)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_A_L1)
        Me.PanelEx10.Controls.Add(Me.LabelX22)
        Me.PanelEx10.Controls.Add(Me.LabelX23)
        Me.PanelEx10.Controls.Add(Me.LabelX24)
        Me.PanelEx10.Controls.Add(Me.lblLM1)
        Me.PanelEx10.Controls.Add(Me.lblCurrent)
        Me.PanelEx10.Controls.Add(Me.lblTotal_P)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_P)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_P)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_P)
        Me.PanelEx10.Controls.Add(Me.lblDecided_P)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_P)
        Me.PanelEx10.Controls.Add(Me.lblTotal_BV)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_BV)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_BV)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_BV)
        Me.PanelEx10.Controls.Add(Me.lblDecided_BV)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_BV)
        Me.PanelEx10.Controls.Add(Me.lblTotal_A)
        Me.PanelEx10.Controls.Add(Me.lblArchieved_A)
        Me.PanelEx10.Controls.Add(Me.lblDismissed_A)
        Me.PanelEx10.Controls.Add(Me.lblExecuted_A)
        Me.PanelEx10.Controls.Add(Me.lblDecided_A)
        Me.PanelEx10.Controls.Add(Me.lblOnGoing_A)
        Me.PanelEx10.Controls.Add(Me.LabelX62)
        Me.PanelEx10.Controls.Add(Me.LabelX61)
        Me.PanelEx10.Controls.Add(Me.LabelX60)
        Me.PanelEx10.Controls.Add(Me.LabelX59)
        Me.PanelEx10.Controls.Add(Me.LabelX58)
        Me.PanelEx10.Controls.Add(Me.LabelX57)
        Me.PanelEx10.Controls.Add(Me.LabelX56)
        Me.PanelEx10.Controls.Add(Me.LabelX55)
        Me.PanelEx10.Controls.Add(Me.LabelX54)
        Me.PanelEx10.Controls.Add(Me.LabelX53)
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
        'btnSearch
        '
        Me.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnSearch.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSearch.Location = New System.Drawing.Point(261, 7)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 30)
        Me.btnSearch.TabIndex = 1923
        Me.btnSearch.Text = "Search"
        '
        'dtpAsOf
        '
        '
        '
        '
        Me.dtpAsOf.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpAsOf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpAsOf.ButtonDropDown.Visible = True
        Me.dtpAsOf.CustomFormat = "MMMM, yyyy"
        Me.dtpAsOf.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAsOf.ForeColor = System.Drawing.Color.Black
        Me.dtpAsOf.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpAsOf.IsPopupCalendarOpen = False
        Me.dtpAsOf.Location = New System.Drawing.Point(77, 10)
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpAsOf.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpAsOf.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.MonthCalendar.DisplayMonth = New Date(2016, 12, 1, 0, 0, 0, 0)
        Me.dtpAsOf.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpAsOf.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpAsOf.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpAsOf.MonthCalendar.TodayButtonVisible = True
        Me.dtpAsOf.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpAsOf.Name = "dtpAsOf"
        Me.dtpAsOf.Size = New System.Drawing.Size(178, 23)
        Me.dtpAsOf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpAsOf.TabIndex = 1921
        Me.dtpAsOf.Value = New Date(2016, 12, 2, 13, 44, 54, 0)
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
        Me.LabelX15.Location = New System.Drawing.Point(8, 10)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(63, 23)
        Me.LabelX15.TabIndex = 1922
        Me.LabelX15.Text = "As Of :"
        Me.LabelX15.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        XyDiagram1.AxisX.Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.Chart1.Diagram = XyDiagram1
        Me.Chart1.Legend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.Chart1.Location = New System.Drawing.Point(13, 278)
        Me.Chart1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Chart1.Name = "Chart1"
        Me.Chart1.PaletteName = "FSFC Blue"
        Me.Chart1.PaletteRepository.Add("Case Palette", New DevExpress.XtraCharts.Palette("Case Palette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(88, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(88, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(89, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(89, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(255, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(0, Byte), Integer)))}))
        Me.Chart1.PaletteRepository.Add("FSFC Blue", New DevExpress.XtraCharts.Palette("FSFC Blue", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer)))}))
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
        Me.Chart1.Size = New System.Drawing.Size(1140, 279)
        Me.Chart1.TabIndex = 1920
        ChartTitle1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartTitle1.Text = "Items In Litigation"
        ChartTitle1.TextColor = System.Drawing.Color.Black
        Me.Chart1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'lblTotal_P_L2
        '
        Me.lblTotal_P_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_P_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_P_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_P_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_P_L2.Location = New System.Drawing.Point(1063, 249)
        Me.lblTotal_P_L2.Name = "lblTotal_P_L2"
        Me.lblTotal_P_L2.Size = New System.Drawing.Size(90, 23)
        Me.lblTotal_P_L2.TabIndex = 1919
        Me.lblTotal_P_L2.Text = "0.00 %"
        Me.lblTotal_P_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchieved_P_L2
        '
        Me.lblArchieved_P_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_P_L2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_P_L2.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_P_L2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P_L2.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_P_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_P_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P_L2.Location = New System.Drawing.Point(1063, 220)
        Me.lblArchieved_P_L2.Name = "lblArchieved_P_L2"
        Me.lblArchieved_P_L2.Size = New System.Drawing.Size(90, 23)
        Me.lblArchieved_P_L2.TabIndex = 1918
        Me.lblArchieved_P_L2.Text = "0.00 %"
        Me.lblArchieved_P_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissed_P_L2
        '
        Me.lblDismissed_P_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_P_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_P_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_P_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_P_L2.Location = New System.Drawing.Point(1063, 191)
        Me.lblDismissed_P_L2.Name = "lblDismissed_P_L2"
        Me.lblDismissed_P_L2.Size = New System.Drawing.Size(90, 23)
        Me.lblDismissed_P_L2.TabIndex = 1917
        Me.lblDismissed_P_L2.Text = "0.00 %"
        Me.lblDismissed_P_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecuted_P_L2
        '
        Me.lblExecuted_P_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_P_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_P_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_P_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_P_L2.Location = New System.Drawing.Point(1063, 162)
        Me.lblExecuted_P_L2.Name = "lblExecuted_P_L2"
        Me.lblExecuted_P_L2.Size = New System.Drawing.Size(90, 23)
        Me.lblExecuted_P_L2.TabIndex = 1916
        Me.lblExecuted_P_L2.Text = "0.00 %"
        Me.lblExecuted_P_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecided_P_L2
        '
        Me.lblDecided_P_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_P_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_P_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_P_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_P_L2.Location = New System.Drawing.Point(1063, 133)
        Me.lblDecided_P_L2.Name = "lblDecided_P_L2"
        Me.lblDecided_P_L2.Size = New System.Drawing.Size(90, 23)
        Me.lblDecided_P_L2.TabIndex = 1915
        Me.lblDecided_P_L2.Text = "0.00 %"
        Me.lblDecided_P_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOnGoing_P_L2
        '
        Me.lblOnGoing_P_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_P_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_P_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_P_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_P_L2.Location = New System.Drawing.Point(1063, 104)
        Me.lblOnGoing_P_L2.Name = "lblOnGoing_P_L2"
        Me.lblOnGoing_P_L2.Size = New System.Drawing.Size(90, 23)
        Me.lblOnGoing_P_L2.TabIndex = 1914
        Me.lblOnGoing_P_L2.Text = "0.00 %"
        Me.lblOnGoing_P_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblTotal_BV_L2
        '
        Me.lblTotal_BV_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_BV_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_BV_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_BV_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_BV_L2.Location = New System.Drawing.Point(932, 249)
        Me.lblTotal_BV_L2.Name = "lblTotal_BV_L2"
        Me.lblTotal_BV_L2.Size = New System.Drawing.Size(130, 23)
        Me.lblTotal_BV_L2.TabIndex = 1913
        Me.lblTotal_BV_L2.Text = "0.00"
        Me.lblTotal_BV_L2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblArchieved_BV_L2
        '
        Me.lblArchieved_BV_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_BV_L2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_BV_L2.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_BV_L2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV_L2.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_BV_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_BV_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV_L2.Location = New System.Drawing.Point(932, 220)
        Me.lblArchieved_BV_L2.Name = "lblArchieved_BV_L2"
        Me.lblArchieved_BV_L2.Size = New System.Drawing.Size(130, 23)
        Me.lblArchieved_BV_L2.TabIndex = 1912
        Me.lblArchieved_BV_L2.Text = "0.00"
        Me.lblArchieved_BV_L2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDismissed_BV_L2
        '
        Me.lblDismissed_BV_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_BV_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_BV_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_BV_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_BV_L2.Location = New System.Drawing.Point(932, 191)
        Me.lblDismissed_BV_L2.Name = "lblDismissed_BV_L2"
        Me.lblDismissed_BV_L2.Size = New System.Drawing.Size(130, 23)
        Me.lblDismissed_BV_L2.TabIndex = 1911
        Me.lblDismissed_BV_L2.Text = "0.00"
        Me.lblDismissed_BV_L2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblExecuted_BV_L2
        '
        Me.lblExecuted_BV_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_BV_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_BV_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_BV_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_BV_L2.Location = New System.Drawing.Point(932, 162)
        Me.lblExecuted_BV_L2.Name = "lblExecuted_BV_L2"
        Me.lblExecuted_BV_L2.Size = New System.Drawing.Size(130, 23)
        Me.lblExecuted_BV_L2.TabIndex = 1910
        Me.lblExecuted_BV_L2.Text = "0.00"
        Me.lblExecuted_BV_L2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDecided_BV_L2
        '
        Me.lblDecided_BV_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_BV_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_BV_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_BV_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_BV_L2.Location = New System.Drawing.Point(932, 133)
        Me.lblDecided_BV_L2.Name = "lblDecided_BV_L2"
        Me.lblDecided_BV_L2.Size = New System.Drawing.Size(130, 23)
        Me.lblDecided_BV_L2.TabIndex = 1909
        Me.lblDecided_BV_L2.Text = "0.00"
        Me.lblDecided_BV_L2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblOnGoing_BV_L2
        '
        Me.lblOnGoing_BV_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_BV_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_BV_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_BV_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_BV_L2.Location = New System.Drawing.Point(932, 104)
        Me.lblOnGoing_BV_L2.Name = "lblOnGoing_BV_L2"
        Me.lblOnGoing_BV_L2.Size = New System.Drawing.Size(130, 23)
        Me.lblOnGoing_BV_L2.TabIndex = 1908
        Me.lblOnGoing_BV_L2.Text = "0.00"
        Me.lblOnGoing_BV_L2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblTotal_A_L2
        '
        Me.lblTotal_A_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_A_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_A_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_A_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_A_L2.Location = New System.Drawing.Point(846, 249)
        Me.lblTotal_A_L2.Name = "lblTotal_A_L2"
        Me.lblTotal_A_L2.Size = New System.Drawing.Size(85, 23)
        Me.lblTotal_A_L2.TabIndex = 1907
        Me.lblTotal_A_L2.Text = "0"
        Me.lblTotal_A_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchieved_A_L2
        '
        Me.lblArchieved_A_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_A_L2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_A_L2.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_A_L2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A_L2.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_A_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_A_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A_L2.Location = New System.Drawing.Point(846, 220)
        Me.lblArchieved_A_L2.Name = "lblArchieved_A_L2"
        Me.lblArchieved_A_L2.Size = New System.Drawing.Size(85, 23)
        Me.lblArchieved_A_L2.TabIndex = 1906
        Me.lblArchieved_A_L2.Text = "0"
        Me.lblArchieved_A_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissed_A_L2
        '
        Me.lblDismissed_A_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_A_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_A_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_A_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_A_L2.Location = New System.Drawing.Point(846, 191)
        Me.lblDismissed_A_L2.Name = "lblDismissed_A_L2"
        Me.lblDismissed_A_L2.Size = New System.Drawing.Size(85, 23)
        Me.lblDismissed_A_L2.TabIndex = 1905
        Me.lblDismissed_A_L2.Text = "0"
        Me.lblDismissed_A_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecuted_A_L2
        '
        Me.lblExecuted_A_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_A_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_A_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_A_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_A_L2.Location = New System.Drawing.Point(846, 162)
        Me.lblExecuted_A_L2.Name = "lblExecuted_A_L2"
        Me.lblExecuted_A_L2.Size = New System.Drawing.Size(85, 23)
        Me.lblExecuted_A_L2.TabIndex = 1904
        Me.lblExecuted_A_L2.Text = "0"
        Me.lblExecuted_A_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecided_A_L2
        '
        Me.lblDecided_A_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_A_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_A_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_A_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_A_L2.Location = New System.Drawing.Point(846, 133)
        Me.lblDecided_A_L2.Name = "lblDecided_A_L2"
        Me.lblDecided_A_L2.Size = New System.Drawing.Size(85, 23)
        Me.lblDecided_A_L2.TabIndex = 1903
        Me.lblDecided_A_L2.Text = "0"
        Me.lblDecided_A_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOnGoing_A_L2
        '
        Me.lblOnGoing_A_L2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_A_L2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_A_L2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_A_L2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_A_L2.Location = New System.Drawing.Point(846, 104)
        Me.lblOnGoing_A_L2.Name = "lblOnGoing_A_L2"
        Me.lblOnGoing_A_L2.Size = New System.Drawing.Size(85, 23)
        Me.lblOnGoing_A_L2.TabIndex = 1902
        Me.lblOnGoing_A_L2.Text = "0"
        Me.lblOnGoing_A_L2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX43
        '
        Me.LabelX43.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX43.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX43.ForeColor = System.Drawing.Color.White
        Me.LabelX43.Location = New System.Drawing.Point(1063, 74)
        Me.LabelX43.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(90, 23)
        Me.LabelX43.TabIndex = 1901
        Me.LabelX43.Text = "Percentage"
        Me.LabelX43.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX43.WordWrap = True
        '
        'LabelX44
        '
        Me.LabelX44.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX44.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX44.ForeColor = System.Drawing.Color.White
        Me.LabelX44.Location = New System.Drawing.Point(932, 74)
        Me.LabelX44.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX44.Name = "LabelX44"
        Me.LabelX44.Size = New System.Drawing.Size(130, 23)
        Me.LabelX44.TabIndex = 1900
        Me.LabelX44.Text = "Book Value"
        Me.LabelX44.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX44.WordWrap = True
        '
        'LabelX45
        '
        Me.LabelX45.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX45.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX45.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX45.ForeColor = System.Drawing.Color.White
        Me.LabelX45.Location = New System.Drawing.Point(846, 74)
        Me.LabelX45.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX45.Name = "LabelX45"
        Me.LabelX45.Size = New System.Drawing.Size(85, 23)
        Me.LabelX45.TabIndex = 1899
        Me.LabelX45.Text = "Accounts"
        Me.LabelX45.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX45.WordWrap = True
        '
        'lblLM2
        '
        Me.lblLM2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.lblLM2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblLM2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLM2.ForeColor = System.Drawing.Color.White
        Me.lblLM2.Location = New System.Drawing.Point(846, 43)
        Me.lblLM2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblLM2.Name = "lblLM2"
        Me.lblLM2.Size = New System.Drawing.Size(307, 30)
        Me.lblLM2.TabIndex = 1898
        Me.lblLM2.Text = "Last 2 Months (March, 2018)"
        Me.lblLM2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblTotal_P_L1
        '
        Me.lblTotal_P_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_P_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_P_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_P_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_P_L1.Location = New System.Drawing.Point(755, 249)
        Me.lblTotal_P_L1.Name = "lblTotal_P_L1"
        Me.lblTotal_P_L1.Size = New System.Drawing.Size(90, 23)
        Me.lblTotal_P_L1.TabIndex = 1897
        Me.lblTotal_P_L1.Text = "0.00 %"
        Me.lblTotal_P_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchieved_P_L1
        '
        Me.lblArchieved_P_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_P_L1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_P_L1.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_P_L1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P_L1.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_P_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_P_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P_L1.Location = New System.Drawing.Point(755, 220)
        Me.lblArchieved_P_L1.Name = "lblArchieved_P_L1"
        Me.lblArchieved_P_L1.Size = New System.Drawing.Size(90, 23)
        Me.lblArchieved_P_L1.TabIndex = 1896
        Me.lblArchieved_P_L1.Text = "0.00 %"
        Me.lblArchieved_P_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissed_P_L1
        '
        Me.lblDismissed_P_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_P_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_P_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_P_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_P_L1.Location = New System.Drawing.Point(755, 191)
        Me.lblDismissed_P_L1.Name = "lblDismissed_P_L1"
        Me.lblDismissed_P_L1.Size = New System.Drawing.Size(90, 23)
        Me.lblDismissed_P_L1.TabIndex = 1895
        Me.lblDismissed_P_L1.Text = "0.00 %"
        Me.lblDismissed_P_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecuted_P_L1
        '
        Me.lblExecuted_P_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_P_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_P_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_P_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_P_L1.Location = New System.Drawing.Point(755, 162)
        Me.lblExecuted_P_L1.Name = "lblExecuted_P_L1"
        Me.lblExecuted_P_L1.Size = New System.Drawing.Size(90, 23)
        Me.lblExecuted_P_L1.TabIndex = 1894
        Me.lblExecuted_P_L1.Text = "0.00 %"
        Me.lblExecuted_P_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecided_P_L1
        '
        Me.lblDecided_P_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_P_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_P_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_P_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_P_L1.Location = New System.Drawing.Point(755, 133)
        Me.lblDecided_P_L1.Name = "lblDecided_P_L1"
        Me.lblDecided_P_L1.Size = New System.Drawing.Size(90, 23)
        Me.lblDecided_P_L1.TabIndex = 1893
        Me.lblDecided_P_L1.Text = "0.00 %"
        Me.lblDecided_P_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOnGoing_P_L1
        '
        Me.lblOnGoing_P_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_P_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_P_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_P_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_P_L1.Location = New System.Drawing.Point(755, 104)
        Me.lblOnGoing_P_L1.Name = "lblOnGoing_P_L1"
        Me.lblOnGoing_P_L1.Size = New System.Drawing.Size(90, 23)
        Me.lblOnGoing_P_L1.TabIndex = 1892
        Me.lblOnGoing_P_L1.Text = "0.00 %"
        Me.lblOnGoing_P_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblTotal_BV_L1
        '
        Me.lblTotal_BV_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_BV_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_BV_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_BV_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_BV_L1.Location = New System.Drawing.Point(624, 249)
        Me.lblTotal_BV_L1.Name = "lblTotal_BV_L1"
        Me.lblTotal_BV_L1.Size = New System.Drawing.Size(130, 23)
        Me.lblTotal_BV_L1.TabIndex = 1891
        Me.lblTotal_BV_L1.Text = "0.00"
        Me.lblTotal_BV_L1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblArchieved_BV_L1
        '
        Me.lblArchieved_BV_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_BV_L1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_BV_L1.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_BV_L1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV_L1.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_BV_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_BV_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV_L1.Location = New System.Drawing.Point(624, 220)
        Me.lblArchieved_BV_L1.Name = "lblArchieved_BV_L1"
        Me.lblArchieved_BV_L1.Size = New System.Drawing.Size(130, 23)
        Me.lblArchieved_BV_L1.TabIndex = 1890
        Me.lblArchieved_BV_L1.Text = "0.00"
        Me.lblArchieved_BV_L1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDismissed_BV_L1
        '
        Me.lblDismissed_BV_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_BV_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_BV_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_BV_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_BV_L1.Location = New System.Drawing.Point(624, 191)
        Me.lblDismissed_BV_L1.Name = "lblDismissed_BV_L1"
        Me.lblDismissed_BV_L1.Size = New System.Drawing.Size(130, 23)
        Me.lblDismissed_BV_L1.TabIndex = 1889
        Me.lblDismissed_BV_L1.Text = "0.00"
        Me.lblDismissed_BV_L1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblExecuted_BV_L1
        '
        Me.lblExecuted_BV_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_BV_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_BV_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_BV_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_BV_L1.Location = New System.Drawing.Point(624, 162)
        Me.lblExecuted_BV_L1.Name = "lblExecuted_BV_L1"
        Me.lblExecuted_BV_L1.Size = New System.Drawing.Size(130, 23)
        Me.lblExecuted_BV_L1.TabIndex = 1888
        Me.lblExecuted_BV_L1.Text = "0.00"
        Me.lblExecuted_BV_L1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDecided_BV_L1
        '
        Me.lblDecided_BV_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_BV_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_BV_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_BV_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_BV_L1.Location = New System.Drawing.Point(624, 133)
        Me.lblDecided_BV_L1.Name = "lblDecided_BV_L1"
        Me.lblDecided_BV_L1.Size = New System.Drawing.Size(130, 23)
        Me.lblDecided_BV_L1.TabIndex = 1887
        Me.lblDecided_BV_L1.Text = "0.00"
        Me.lblDecided_BV_L1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblOnGoing_BV_L1
        '
        Me.lblOnGoing_BV_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_BV_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_BV_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_BV_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_BV_L1.Location = New System.Drawing.Point(624, 104)
        Me.lblOnGoing_BV_L1.Name = "lblOnGoing_BV_L1"
        Me.lblOnGoing_BV_L1.Size = New System.Drawing.Size(130, 23)
        Me.lblOnGoing_BV_L1.TabIndex = 1886
        Me.lblOnGoing_BV_L1.Text = "0.00"
        Me.lblOnGoing_BV_L1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblTotal_A_L1
        '
        Me.lblTotal_A_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_A_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_A_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_A_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_A_L1.Location = New System.Drawing.Point(538, 249)
        Me.lblTotal_A_L1.Name = "lblTotal_A_L1"
        Me.lblTotal_A_L1.Size = New System.Drawing.Size(85, 23)
        Me.lblTotal_A_L1.TabIndex = 1885
        Me.lblTotal_A_L1.Text = "0"
        Me.lblTotal_A_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchieved_A_L1
        '
        Me.lblArchieved_A_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_A_L1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_A_L1.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_A_L1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A_L1.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_A_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_A_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A_L1.Location = New System.Drawing.Point(538, 220)
        Me.lblArchieved_A_L1.Name = "lblArchieved_A_L1"
        Me.lblArchieved_A_L1.Size = New System.Drawing.Size(85, 23)
        Me.lblArchieved_A_L1.TabIndex = 1884
        Me.lblArchieved_A_L1.Text = "0"
        Me.lblArchieved_A_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissed_A_L1
        '
        Me.lblDismissed_A_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_A_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_A_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_A_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_A_L1.Location = New System.Drawing.Point(538, 191)
        Me.lblDismissed_A_L1.Name = "lblDismissed_A_L1"
        Me.lblDismissed_A_L1.Size = New System.Drawing.Size(85, 23)
        Me.lblDismissed_A_L1.TabIndex = 1883
        Me.lblDismissed_A_L1.Text = "0"
        Me.lblDismissed_A_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecuted_A_L1
        '
        Me.lblExecuted_A_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_A_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_A_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_A_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_A_L1.Location = New System.Drawing.Point(538, 162)
        Me.lblExecuted_A_L1.Name = "lblExecuted_A_L1"
        Me.lblExecuted_A_L1.Size = New System.Drawing.Size(85, 23)
        Me.lblExecuted_A_L1.TabIndex = 1882
        Me.lblExecuted_A_L1.Text = "0"
        Me.lblExecuted_A_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecided_A_L1
        '
        Me.lblDecided_A_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_A_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_A_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_A_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_A_L1.Location = New System.Drawing.Point(538, 133)
        Me.lblDecided_A_L1.Name = "lblDecided_A_L1"
        Me.lblDecided_A_L1.Size = New System.Drawing.Size(85, 23)
        Me.lblDecided_A_L1.TabIndex = 1881
        Me.lblDecided_A_L1.Text = "0"
        Me.lblDecided_A_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOnGoing_A_L1
        '
        Me.lblOnGoing_A_L1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_A_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_A_L1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_A_L1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_A_L1.Location = New System.Drawing.Point(538, 104)
        Me.lblOnGoing_A_L1.Name = "lblOnGoing_A_L1"
        Me.lblOnGoing_A_L1.Size = New System.Drawing.Size(85, 23)
        Me.lblOnGoing_A_L1.TabIndex = 1880
        Me.lblOnGoing_A_L1.Text = "0"
        Me.lblOnGoing_A_L1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.White
        Me.LabelX22.Location = New System.Drawing.Point(755, 74)
        Me.LabelX22.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(90, 23)
        Me.LabelX22.TabIndex = 1879
        Me.LabelX22.Text = "Percentage"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX22.WordWrap = True
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.White
        Me.LabelX23.Location = New System.Drawing.Point(624, 74)
        Me.LabelX23.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(130, 23)
        Me.LabelX23.TabIndex = 1878
        Me.LabelX23.Text = "Book Value"
        Me.LabelX23.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX23.WordWrap = True
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.White
        Me.LabelX24.Location = New System.Drawing.Point(538, 74)
        Me.LabelX24.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(85, 23)
        Me.LabelX24.TabIndex = 1877
        Me.LabelX24.Text = "Accounts"
        Me.LabelX24.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX24.WordWrap = True
        '
        'lblLM1
        '
        Me.lblLM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.lblLM1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblLM1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLM1.ForeColor = System.Drawing.Color.White
        Me.lblLM1.Location = New System.Drawing.Point(538, 43)
        Me.lblLM1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblLM1.Name = "lblLM1"
        Me.lblLM1.Size = New System.Drawing.Size(307, 30)
        Me.lblLM1.TabIndex = 1876
        Me.lblLM1.Text = "Last Month (April, 2018)"
        Me.lblLM1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblCurrent
        '
        Me.lblCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.lblCurrent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCurrent.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrent.ForeColor = System.Drawing.Color.White
        Me.lblCurrent.Location = New System.Drawing.Point(230, 43)
        Me.lblCurrent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(307, 30)
        Me.lblCurrent.TabIndex = 1854
        Me.lblCurrent.Text = "Current"
        Me.lblCurrent.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblTotal_P
        '
        Me.lblTotal_P.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_P.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_P.Location = New System.Drawing.Point(447, 249)
        Me.lblTotal_P.Name = "lblTotal_P"
        Me.lblTotal_P.Size = New System.Drawing.Size(90, 23)
        Me.lblTotal_P.TabIndex = 1853
        Me.lblTotal_P.Text = "0.00 %"
        Me.lblTotal_P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchieved_P
        '
        Me.lblArchieved_P.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_P.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_P.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_P.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_P.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_P.Location = New System.Drawing.Point(447, 220)
        Me.lblArchieved_P.Name = "lblArchieved_P"
        Me.lblArchieved_P.Size = New System.Drawing.Size(90, 23)
        Me.lblArchieved_P.TabIndex = 1852
        Me.lblArchieved_P.Text = "0.00 %"
        Me.lblArchieved_P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissed_P
        '
        Me.lblDismissed_P.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_P.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_P.Location = New System.Drawing.Point(447, 191)
        Me.lblDismissed_P.Name = "lblDismissed_P"
        Me.lblDismissed_P.Size = New System.Drawing.Size(90, 23)
        Me.lblDismissed_P.TabIndex = 1851
        Me.lblDismissed_P.Text = "0.00 %"
        Me.lblDismissed_P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecuted_P
        '
        Me.lblExecuted_P.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_P.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_P.Location = New System.Drawing.Point(447, 162)
        Me.lblExecuted_P.Name = "lblExecuted_P"
        Me.lblExecuted_P.Size = New System.Drawing.Size(90, 23)
        Me.lblExecuted_P.TabIndex = 1850
        Me.lblExecuted_P.Text = "0.00 %"
        Me.lblExecuted_P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecided_P
        '
        Me.lblDecided_P.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_P.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_P.Location = New System.Drawing.Point(447, 133)
        Me.lblDecided_P.Name = "lblDecided_P"
        Me.lblDecided_P.Size = New System.Drawing.Size(90, 23)
        Me.lblDecided_P.TabIndex = 1849
        Me.lblDecided_P.Text = "0.00 %"
        Me.lblDecided_P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOnGoing_P
        '
        Me.lblOnGoing_P.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_P.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_P.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_P.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_P.Location = New System.Drawing.Point(447, 104)
        Me.lblOnGoing_P.Name = "lblOnGoing_P"
        Me.lblOnGoing_P.Size = New System.Drawing.Size(90, 23)
        Me.lblOnGoing_P.TabIndex = 1848
        Me.lblOnGoing_P.Text = "0.00 %"
        Me.lblOnGoing_P.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblTotal_BV
        '
        Me.lblTotal_BV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_BV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_BV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_BV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_BV.Location = New System.Drawing.Point(316, 249)
        Me.lblTotal_BV.Name = "lblTotal_BV"
        Me.lblTotal_BV.Size = New System.Drawing.Size(130, 23)
        Me.lblTotal_BV.TabIndex = 1847
        Me.lblTotal_BV.Text = "0.00"
        Me.lblTotal_BV.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblArchieved_BV
        '
        Me.lblArchieved_BV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_BV.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_BV.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_BV.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_BV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_BV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_BV.Location = New System.Drawing.Point(316, 220)
        Me.lblArchieved_BV.Name = "lblArchieved_BV"
        Me.lblArchieved_BV.Size = New System.Drawing.Size(130, 23)
        Me.lblArchieved_BV.TabIndex = 1846
        Me.lblArchieved_BV.Text = "0.00"
        Me.lblArchieved_BV.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDismissed_BV
        '
        Me.lblDismissed_BV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_BV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_BV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_BV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_BV.Location = New System.Drawing.Point(316, 191)
        Me.lblDismissed_BV.Name = "lblDismissed_BV"
        Me.lblDismissed_BV.Size = New System.Drawing.Size(130, 23)
        Me.lblDismissed_BV.TabIndex = 1845
        Me.lblDismissed_BV.Text = "0.00"
        Me.lblDismissed_BV.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblExecuted_BV
        '
        Me.lblExecuted_BV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_BV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_BV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_BV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_BV.Location = New System.Drawing.Point(316, 162)
        Me.lblExecuted_BV.Name = "lblExecuted_BV"
        Me.lblExecuted_BV.Size = New System.Drawing.Size(130, 23)
        Me.lblExecuted_BV.TabIndex = 1844
        Me.lblExecuted_BV.Text = "0.00"
        Me.lblExecuted_BV.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblDecided_BV
        '
        Me.lblDecided_BV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_BV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_BV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_BV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_BV.Location = New System.Drawing.Point(316, 133)
        Me.lblDecided_BV.Name = "lblDecided_BV"
        Me.lblDecided_BV.Size = New System.Drawing.Size(130, 23)
        Me.lblDecided_BV.TabIndex = 1843
        Me.lblDecided_BV.Text = "0.00"
        Me.lblDecided_BV.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblOnGoing_BV
        '
        Me.lblOnGoing_BV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_BV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_BV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_BV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_BV.Location = New System.Drawing.Point(316, 104)
        Me.lblOnGoing_BV.Name = "lblOnGoing_BV"
        Me.lblOnGoing_BV.Size = New System.Drawing.Size(130, 23)
        Me.lblOnGoing_BV.TabIndex = 1842
        Me.lblOnGoing_BV.Text = "0.00"
        Me.lblOnGoing_BV.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblTotal_A
        '
        Me.lblTotal_A.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTotal_A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotal_A.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotal_A.Location = New System.Drawing.Point(230, 249)
        Me.lblTotal_A.Name = "lblTotal_A"
        Me.lblTotal_A.Size = New System.Drawing.Size(85, 23)
        Me.lblTotal_A.TabIndex = 1841
        Me.lblTotal_A.Text = "0"
        Me.lblTotal_A.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblArchieved_A
        '
        Me.lblArchieved_A.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblArchieved_A.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArchieved_A.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArchieved_A.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArchieved_A.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchieved_A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblArchieved_A.Location = New System.Drawing.Point(230, 220)
        Me.lblArchieved_A.Name = "lblArchieved_A"
        Me.lblArchieved_A.Size = New System.Drawing.Size(85, 23)
        Me.lblArchieved_A.TabIndex = 1840
        Me.lblArchieved_A.Text = "0"
        Me.lblArchieved_A.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDismissed_A
        '
        Me.lblDismissed_A.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDismissed_A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDismissed_A.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDismissed_A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDismissed_A.Location = New System.Drawing.Point(230, 191)
        Me.lblDismissed_A.Name = "lblDismissed_A"
        Me.lblDismissed_A.Size = New System.Drawing.Size(85, 23)
        Me.lblDismissed_A.TabIndex = 1839
        Me.lblDismissed_A.Text = "0"
        Me.lblDismissed_A.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblExecuted_A
        '
        Me.lblExecuted_A.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblExecuted_A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblExecuted_A.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecuted_A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblExecuted_A.Location = New System.Drawing.Point(230, 162)
        Me.lblExecuted_A.Name = "lblExecuted_A"
        Me.lblExecuted_A.Size = New System.Drawing.Size(85, 23)
        Me.lblExecuted_A.TabIndex = 1838
        Me.lblExecuted_A.Text = "0"
        Me.lblExecuted_A.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblDecided_A
        '
        Me.lblDecided_A.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblDecided_A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDecided_A.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecided_A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblDecided_A.Location = New System.Drawing.Point(230, 133)
        Me.lblDecided_A.Name = "lblDecided_A"
        Me.lblDecided_A.Size = New System.Drawing.Size(85, 23)
        Me.lblDecided_A.TabIndex = 1837
        Me.lblDecided_A.Text = "0"
        Me.lblDecided_A.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblOnGoing_A
        '
        Me.lblOnGoing_A.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblOnGoing_A.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblOnGoing_A.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnGoing_A.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblOnGoing_A.Location = New System.Drawing.Point(230, 104)
        Me.lblOnGoing_A.Name = "lblOnGoing_A"
        Me.lblOnGoing_A.Size = New System.Drawing.Size(85, 23)
        Me.lblOnGoing_A.TabIndex = 1836
        Me.lblOnGoing_A.Text = "0"
        Me.lblOnGoing_A.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX62
        '
        Me.LabelX62.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX62.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX62.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX62.ForeColor = System.Drawing.Color.White
        Me.LabelX62.Location = New System.Drawing.Point(447, 74)
        Me.LabelX62.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX62.Name = "LabelX62"
        Me.LabelX62.Size = New System.Drawing.Size(90, 23)
        Me.LabelX62.TabIndex = 1835
        Me.LabelX62.Text = "Percentage"
        Me.LabelX62.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX62.WordWrap = True
        '
        'LabelX61
        '
        Me.LabelX61.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX61.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX61.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX61.ForeColor = System.Drawing.Color.White
        Me.LabelX61.Location = New System.Drawing.Point(316, 74)
        Me.LabelX61.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX61.Name = "LabelX61"
        Me.LabelX61.Size = New System.Drawing.Size(130, 23)
        Me.LabelX61.TabIndex = 1834
        Me.LabelX61.Text = "Book Value"
        Me.LabelX61.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX61.WordWrap = True
        '
        'LabelX60
        '
        Me.LabelX60.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX60.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX60.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX60.ForeColor = System.Drawing.Color.White
        Me.LabelX60.Location = New System.Drawing.Point(230, 74)
        Me.LabelX60.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX60.Name = "LabelX60"
        Me.LabelX60.Size = New System.Drawing.Size(85, 23)
        Me.LabelX60.TabIndex = 1833
        Me.LabelX60.Text = "Accounts"
        Me.LabelX60.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX60.WordWrap = True
        '
        'LabelX59
        '
        Me.LabelX59.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX59.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX59.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX59.ForeColor = System.Drawing.Color.White
        Me.LabelX59.Location = New System.Drawing.Point(12, 43)
        Me.LabelX59.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX59.Name = "LabelX59"
        Me.LabelX59.Size = New System.Drawing.Size(217, 54)
        Me.LabelX59.TabIndex = 1832
        Me.LabelX59.Text = "Case"
        Me.LabelX59.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX58
        '
        Me.LabelX58.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX58.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX58.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX58.Location = New System.Drawing.Point(12, 249)
        Me.LabelX58.Name = "LabelX58"
        Me.LabelX58.Size = New System.Drawing.Size(217, 23)
        Me.LabelX58.TabIndex = 1831
        Me.LabelX58.Text = "T O T A L"
        Me.LabelX58.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX57
        '
        Me.LabelX57.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX57.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelX57.BackgroundStyle.BorderBottomWidth = 2
        Me.LabelX57.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX57.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX57.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX57.Location = New System.Drawing.Point(12, 220)
        Me.LabelX57.Name = "LabelX57"
        Me.LabelX57.Size = New System.Drawing.Size(217, 23)
        Me.LabelX57.TabIndex = 1830
        Me.LabelX57.Text = "Archieved Cases"
        Me.LabelX57.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX56
        '
        Me.LabelX56.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX56.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX56.Location = New System.Drawing.Point(12, 191)
        Me.LabelX56.Name = "LabelX56"
        Me.LabelX56.Size = New System.Drawing.Size(217, 23)
        Me.LabelX56.TabIndex = 1829
        Me.LabelX56.Text = "Cases Dismissed"
        Me.LabelX56.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX55
        '
        Me.LabelX55.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX55.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX55.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX55.Location = New System.Drawing.Point(12, 162)
        Me.LabelX55.Name = "LabelX55"
        Me.LabelX55.Size = New System.Drawing.Size(217, 23)
        Me.LabelX55.TabIndex = 1828
        Me.LabelX55.Text = "Cases For Execution"
        Me.LabelX55.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX54
        '
        Me.LabelX54.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX54.Location = New System.Drawing.Point(12, 133)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(217, 23)
        Me.LabelX54.TabIndex = 1827
        Me.LabelX54.Text = "Cases Already Decided"
        Me.LabelX54.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX53
        '
        Me.LabelX53.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX53.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX53.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX53.Location = New System.Drawing.Point(12, 104)
        Me.LabelX53.Name = "LabelX53"
        Me.LabelX53.Size = New System.Drawing.Size(217, 23)
        Me.LabelX53.TabIndex = 1826
        Me.LabelX53.Text = "On Going Cases"
        Me.LabelX53.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'tabSummary
        '
        Me.tabSummary.AttachedControl = Me.SuperTabControlPanel1
        Me.tabSummary.GlobalItem = False
        Me.tabSummary.Name = "tabSummary"
        Me.tabSummary.Text = "Summary"
        Me.tabSummary.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.GridControl2)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.tabDecided
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
        Me.GridControl2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl2.MainView = Me.BandedGridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GridControl2.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl2.TabIndex = 1679
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView2})
        '
        'BandedGridView2
        '
        Me.BandedGridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView2.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView2.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView2.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView2.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView2.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView2.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView2.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView2.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView2.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView2.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView2.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView2.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView2.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView2.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView2.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.Row.Options.UseFont = True
        Me.BandedGridView2.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView2.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView2.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView2.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView2.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView2.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView2.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView2.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand29, Me.GridBand30, Me.GridBand33, Me.GridBand36, Me.GridBand39, Me.GridBand42, Me.GridBand45, Me.GridBand48, Me.GridBand51, Me.gridBand57, Me.GridBand54})
        Me.BandedGridView2.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn41, Me.BandedGridColumn42, Me.BandedGridColumn43, Me.BandedGridColumn44, Me.BandedGridColumn45, Me.BandedGridColumn46, Me.BandedGridColumn47, Me.BandedGridColumn48, Me.BandedGridColumn49, Me.BandedGridColumn50, Me.BandedGridColumn51, Me.BandedGridColumn52, Me.BandedGridColumn53, Me.BandedGridColumn54, Me.BandedGridColumn55, Me.BandedGridColumn56, Me.BandedGridColumn57, Me.BandedGridColumn58, Me.BandedGridColumn59, Me.BandedGridColumn60, Me.BandedGridColumn61, Me.BandedGridColumn62, Me.BandedGridColumn63, Me.BandedGridColumn64, Me.BandedGridColumn65, Me.BandedGridColumn66, Me.BandedGridColumn67, Me.BandedGridColumn68, Me.BandedGridColumn69, Me.BandedGridColumn70, Me.BandedGridColumn71, Me.BandedGridColumn72, Me.BandedGridColumn73, Me.BandedGridColumn74, Me.BandedGridColumn75, Me.BandedGridColumn76, Me.BandedGridColumn77, Me.BandedGridColumn78, Me.BandedGridColumn79, Me.BandedGridColumn80, Me.BandedGridColumn40})
        Me.BandedGridView2.CustomizationFormBounds = New System.Drawing.Rectangle(741, 493, 216, 235)
        Me.BandedGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView2.GridControl = Me.GridControl2
        Me.BandedGridView2.GroupPanelText = "General Requirements"
        Me.BandedGridView2.Name = "BandedGridView2"
        Me.BandedGridView2.OptionsBehavior.Editable = False
        Me.BandedGridView2.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView2.OptionsLayout.StoreAppearance = True
        Me.BandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView2.OptionsSelection.MultiSelect = True
        Me.BandedGridView2.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView2.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView2.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView2.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView2.OptionsView.ShowFooter = True
        Me.BandedGridView2.OptionsView.ShowGroupPanel = False
        '
        'GridBand29
        '
        Me.GridBand29.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand29.Caption = "Branch"
        Me.GridBand29.Columns.Add(Me.BandedGridColumn40)
        Me.GridBand29.Name = "GridBand29"
        Me.GridBand29.VisibleIndex = 0
        Me.GridBand29.Width = 200
        '
        'BandedGridColumn40
        '
        Me.BandedGridColumn40.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn40.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn40.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn40.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn40.FieldName = "Branch"
        Me.BandedGridColumn40.Name = "BandedGridColumn40"
        Me.BandedGridColumn40.Visible = True
        Me.BandedGridColumn40.Width = 200
        '
        'GridBand30
        '
        Me.GridBand30.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand30.Caption = "I. Decided and For Monitoring"
        Me.GridBand30.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand31, Me.GridBand32})
        Me.GridBand30.Name = "GridBand30"
        Me.GridBand30.VisibleIndex = 1
        Me.GridBand30.Width = 400
        '
        'GridBand31
        '
        Me.GridBand31.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand31.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand31.Caption = "Amount"
        Me.GridBand31.Columns.Add(Me.BandedGridColumn41)
        Me.GridBand31.Columns.Add(Me.BandedGridColumn42)
        Me.GridBand31.Name = "GridBand31"
        Me.GridBand31.VisibleIndex = 0
        Me.GridBand31.Width = 200
        '
        'BandedGridColumn41
        '
        Me.BandedGridColumn41.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn41.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn41.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn41.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn41.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn41.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn41.Caption = "Amount"
        Me.BandedGridColumn41.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn41.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn41.FieldName = "I_A1"
        Me.BandedGridColumn41.Name = "BandedGridColumn41"
        Me.BandedGridColumn41.Visible = True
        Me.BandedGridColumn41.Width = 100
        '
        'BandedGridColumn42
        '
        Me.BandedGridColumn42.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn42.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn42.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn42.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn42.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn42.Caption = "Percent"
        Me.BandedGridColumn42.FieldName = "I_P1"
        Me.BandedGridColumn42.Name = "BandedGridColumn42"
        Me.BandedGridColumn42.Visible = True
        Me.BandedGridColumn42.Width = 100
        '
        'GridBand32
        '
        Me.GridBand32.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand32.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand32.Caption = "Account"
        Me.GridBand32.Columns.Add(Me.BandedGridColumn43)
        Me.GridBand32.Columns.Add(Me.BandedGridColumn44)
        Me.GridBand32.Name = "GridBand32"
        Me.GridBand32.VisibleIndex = 1
        Me.GridBand32.Width = 200
        '
        'BandedGridColumn43
        '
        Me.BandedGridColumn43.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn43.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn43.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn43.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn43.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn43.Caption = "Account"
        Me.BandedGridColumn43.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn43.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn43.FieldName = "I_A2"
        Me.BandedGridColumn43.Name = "BandedGridColumn43"
        Me.BandedGridColumn43.Visible = True
        Me.BandedGridColumn43.Width = 100
        '
        'BandedGridColumn44
        '
        Me.BandedGridColumn44.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn44.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn44.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn44.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn44.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn44.Caption = "Percent"
        Me.BandedGridColumn44.FieldName = "I_P2"
        Me.BandedGridColumn44.Name = "BandedGridColumn44"
        Me.BandedGridColumn44.Visible = True
        Me.BandedGridColumn44.Width = 100
        '
        'GridBand33
        '
        Me.GridBand33.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand33.Caption = "J. For Preparation of MFE " & Global.Microsoft.VisualBasic.ChrW(9)
        Me.GridBand33.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand34, Me.GridBand35})
        Me.GridBand33.Name = "GridBand33"
        Me.GridBand33.VisibleIndex = 2
        Me.GridBand33.Width = 400
        '
        'GridBand34
        '
        Me.GridBand34.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand34.Caption = "Amount"
        Me.GridBand34.Columns.Add(Me.BandedGridColumn45)
        Me.GridBand34.Columns.Add(Me.BandedGridColumn46)
        Me.GridBand34.Name = "GridBand34"
        Me.GridBand34.VisibleIndex = 0
        Me.GridBand34.Width = 200
        '
        'BandedGridColumn45
        '
        Me.BandedGridColumn45.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn45.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn45.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn45.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn45.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn45.Caption = "Amount"
        Me.BandedGridColumn45.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn45.FieldName = "J_A1"
        Me.BandedGridColumn45.Name = "BandedGridColumn45"
        Me.BandedGridColumn45.Visible = True
        Me.BandedGridColumn45.Width = 100
        '
        'BandedGridColumn46
        '
        Me.BandedGridColumn46.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn46.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn46.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn46.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn46.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn46.Caption = "Percent"
        Me.BandedGridColumn46.FieldName = "J_P1"
        Me.BandedGridColumn46.Name = "BandedGridColumn46"
        Me.BandedGridColumn46.Visible = True
        Me.BandedGridColumn46.Width = 100
        '
        'GridBand35
        '
        Me.GridBand35.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand35.Caption = "Account"
        Me.GridBand35.Columns.Add(Me.BandedGridColumn47)
        Me.GridBand35.Columns.Add(Me.BandedGridColumn48)
        Me.GridBand35.Name = "GridBand35"
        Me.GridBand35.VisibleIndex = 1
        Me.GridBand35.Width = 200
        '
        'BandedGridColumn47
        '
        Me.BandedGridColumn47.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn47.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn47.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn47.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn47.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn47.Caption = "Account"
        Me.BandedGridColumn47.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn47.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn47.FieldName = "J_A2"
        Me.BandedGridColumn47.Name = "BandedGridColumn47"
        Me.BandedGridColumn47.Visible = True
        Me.BandedGridColumn47.Width = 100
        '
        'BandedGridColumn48
        '
        Me.BandedGridColumn48.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn48.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn48.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn48.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn48.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn48.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn48.Caption = "Percent"
        Me.BandedGridColumn48.FieldName = "J_P2"
        Me.BandedGridColumn48.Name = "BandedGridColumn48"
        Me.BandedGridColumn48.Visible = True
        Me.BandedGridColumn48.Width = 100
        '
        'GridBand36
        '
        Me.GridBand36.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand36.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand36.Caption = "K. For Delivery of MFE"
        Me.GridBand36.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand37, Me.GridBand38})
        Me.GridBand36.Name = "GridBand36"
        Me.GridBand36.VisibleIndex = 3
        Me.GridBand36.Width = 400
        '
        'GridBand37
        '
        Me.GridBand37.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand37.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand37.Caption = "Amount"
        Me.GridBand37.Columns.Add(Me.BandedGridColumn49)
        Me.GridBand37.Columns.Add(Me.BandedGridColumn50)
        Me.GridBand37.Name = "GridBand37"
        Me.GridBand37.VisibleIndex = 0
        Me.GridBand37.Width = 200
        '
        'BandedGridColumn49
        '
        Me.BandedGridColumn49.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn49.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn49.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn49.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn49.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn49.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn49.Caption = "Amount"
        Me.BandedGridColumn49.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn49.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn49.FieldName = "K_A1"
        Me.BandedGridColumn49.Name = "BandedGridColumn49"
        Me.BandedGridColumn49.Visible = True
        Me.BandedGridColumn49.Width = 100
        '
        'BandedGridColumn50
        '
        Me.BandedGridColumn50.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn50.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn50.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn50.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn50.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn50.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn50.Caption = "Percent"
        Me.BandedGridColumn50.FieldName = "K_P1"
        Me.BandedGridColumn50.Name = "BandedGridColumn50"
        Me.BandedGridColumn50.Visible = True
        Me.BandedGridColumn50.Width = 100
        '
        'GridBand38
        '
        Me.GridBand38.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand38.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand38.Caption = "Account"
        Me.GridBand38.Columns.Add(Me.BandedGridColumn51)
        Me.GridBand38.Columns.Add(Me.BandedGridColumn52)
        Me.GridBand38.Name = "GridBand38"
        Me.GridBand38.VisibleIndex = 1
        Me.GridBand38.Width = 200
        '
        'BandedGridColumn51
        '
        Me.BandedGridColumn51.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn51.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn51.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn51.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn51.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn51.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn51.Caption = "Account"
        Me.BandedGridColumn51.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn51.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn51.FieldName = "K_A2"
        Me.BandedGridColumn51.Name = "BandedGridColumn51"
        Me.BandedGridColumn51.Visible = True
        Me.BandedGridColumn51.Width = 100
        '
        'BandedGridColumn52
        '
        Me.BandedGridColumn52.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn52.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn52.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn52.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn52.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn52.Caption = "Percent"
        Me.BandedGridColumn52.FieldName = "K_P2"
        Me.BandedGridColumn52.Name = "BandedGridColumn52"
        Me.BandedGridColumn52.Visible = True
        Me.BandedGridColumn52.Width = 100
        '
        'GridBand39
        '
        Me.GridBand39.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand39.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand39.Caption = "L. MFE Delivered"
        Me.GridBand39.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand40, Me.GridBand41})
        Me.GridBand39.Name = "GridBand39"
        Me.GridBand39.VisibleIndex = 4
        Me.GridBand39.Width = 400
        '
        'GridBand40
        '
        Me.GridBand40.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand40.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand40.Caption = "Amount"
        Me.GridBand40.Columns.Add(Me.BandedGridColumn53)
        Me.GridBand40.Columns.Add(Me.BandedGridColumn54)
        Me.GridBand40.Name = "GridBand40"
        Me.GridBand40.VisibleIndex = 0
        Me.GridBand40.Width = 200
        '
        'BandedGridColumn53
        '
        Me.BandedGridColumn53.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn53.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn53.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn53.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn53.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn53.Caption = "Amount"
        Me.BandedGridColumn53.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn53.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn53.FieldName = "L_A1"
        Me.BandedGridColumn53.Name = "BandedGridColumn53"
        Me.BandedGridColumn53.Visible = True
        Me.BandedGridColumn53.Width = 100
        '
        'BandedGridColumn54
        '
        Me.BandedGridColumn54.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn54.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn54.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn54.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn54.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn54.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn54.Caption = "Percent"
        Me.BandedGridColumn54.FieldName = "L_P1"
        Me.BandedGridColumn54.Name = "BandedGridColumn54"
        Me.BandedGridColumn54.Visible = True
        Me.BandedGridColumn54.Width = 100
        '
        'GridBand41
        '
        Me.GridBand41.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand41.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand41.Caption = "Account"
        Me.GridBand41.Columns.Add(Me.BandedGridColumn55)
        Me.GridBand41.Columns.Add(Me.BandedGridColumn56)
        Me.GridBand41.Name = "GridBand41"
        Me.GridBand41.VisibleIndex = 1
        Me.GridBand41.Width = 200
        '
        'BandedGridColumn55
        '
        Me.BandedGridColumn55.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn55.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn55.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn55.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn55.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn55.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn55.Caption = "Account"
        Me.BandedGridColumn55.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn55.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn55.FieldName = "L_A2"
        Me.BandedGridColumn55.Name = "BandedGridColumn55"
        Me.BandedGridColumn55.Visible = True
        Me.BandedGridColumn55.Width = 100
        '
        'BandedGridColumn56
        '
        Me.BandedGridColumn56.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn56.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn56.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn56.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn56.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn56.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn56.Caption = "Percent"
        Me.BandedGridColumn56.FieldName = "L_P2"
        Me.BandedGridColumn56.Name = "BandedGridColumn56"
        Me.BandedGridColumn56.Visible = True
        Me.BandedGridColumn56.Width = 100
        '
        'GridBand42
        '
        Me.GridBand42.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand42.Caption = "M. MFE Filed in Court"
        Me.GridBand42.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand43, Me.GridBand44})
        Me.GridBand42.Name = "GridBand42"
        Me.GridBand42.VisibleIndex = 5
        Me.GridBand42.Width = 400
        '
        'GridBand43
        '
        Me.GridBand43.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand43.Caption = "Amount"
        Me.GridBand43.Columns.Add(Me.BandedGridColumn57)
        Me.GridBand43.Columns.Add(Me.BandedGridColumn58)
        Me.GridBand43.Name = "GridBand43"
        Me.GridBand43.VisibleIndex = 0
        Me.GridBand43.Width = 200
        '
        'BandedGridColumn57
        '
        Me.BandedGridColumn57.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn57.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn57.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn57.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn57.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn57.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn57.Caption = "Amount"
        Me.BandedGridColumn57.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn57.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn57.FieldName = "M_A1"
        Me.BandedGridColumn57.Name = "BandedGridColumn57"
        Me.BandedGridColumn57.Visible = True
        Me.BandedGridColumn57.Width = 100
        '
        'BandedGridColumn58
        '
        Me.BandedGridColumn58.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn58.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn58.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn58.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn58.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn58.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn58.Caption = "Percent"
        Me.BandedGridColumn58.FieldName = "M_P1"
        Me.BandedGridColumn58.Name = "BandedGridColumn58"
        Me.BandedGridColumn58.Visible = True
        Me.BandedGridColumn58.Width = 100
        '
        'GridBand44
        '
        Me.GridBand44.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand44.Caption = "Account"
        Me.GridBand44.Columns.Add(Me.BandedGridColumn59)
        Me.GridBand44.Columns.Add(Me.BandedGridColumn60)
        Me.GridBand44.Name = "GridBand44"
        Me.GridBand44.VisibleIndex = 1
        Me.GridBand44.Width = 200
        '
        'BandedGridColumn59
        '
        Me.BandedGridColumn59.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn59.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn59.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn59.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn59.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn59.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn59.Caption = "Account"
        Me.BandedGridColumn59.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn59.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn59.FieldName = "M_A2"
        Me.BandedGridColumn59.Name = "BandedGridColumn59"
        Me.BandedGridColumn59.Visible = True
        Me.BandedGridColumn59.Width = 100
        '
        'BandedGridColumn60
        '
        Me.BandedGridColumn60.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn60.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn60.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn60.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn60.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn60.Caption = "Percent"
        Me.BandedGridColumn60.FieldName = "M_P2"
        Me.BandedGridColumn60.Name = "BandedGridColumn60"
        Me.BandedGridColumn60.Visible = True
        Me.BandedGridColumn60.Width = 100
        '
        'GridBand45
        '
        Me.GridBand45.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand45.Caption = "N. MFE Waiting for Decision"
        Me.GridBand45.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand46, Me.GridBand47})
        Me.GridBand45.Name = "GridBand45"
        Me.GridBand45.VisibleIndex = 6
        Me.GridBand45.Width = 400
        '
        'GridBand46
        '
        Me.GridBand46.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand46.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand46.Caption = "Amount"
        Me.GridBand46.Columns.Add(Me.BandedGridColumn61)
        Me.GridBand46.Columns.Add(Me.BandedGridColumn62)
        Me.GridBand46.Name = "GridBand46"
        Me.GridBand46.VisibleIndex = 0
        Me.GridBand46.Width = 200
        '
        'BandedGridColumn61
        '
        Me.BandedGridColumn61.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn61.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn61.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn61.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn61.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn61.Caption = "Amount"
        Me.BandedGridColumn61.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn61.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn61.FieldName = "N_A1"
        Me.BandedGridColumn61.Name = "BandedGridColumn61"
        Me.BandedGridColumn61.Visible = True
        Me.BandedGridColumn61.Width = 100
        '
        'BandedGridColumn62
        '
        Me.BandedGridColumn62.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn62.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn62.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn62.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn62.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn62.Caption = "Percent"
        Me.BandedGridColumn62.FieldName = "N_P1"
        Me.BandedGridColumn62.Name = "BandedGridColumn62"
        Me.BandedGridColumn62.Visible = True
        Me.BandedGridColumn62.Width = 100
        '
        'GridBand47
        '
        Me.GridBand47.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand47.Caption = "Account"
        Me.GridBand47.Columns.Add(Me.BandedGridColumn63)
        Me.GridBand47.Columns.Add(Me.BandedGridColumn64)
        Me.GridBand47.Name = "GridBand47"
        Me.GridBand47.VisibleIndex = 1
        Me.GridBand47.Width = 200
        '
        'BandedGridColumn63
        '
        Me.BandedGridColumn63.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn63.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn63.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn63.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn63.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn63.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn63.Caption = "Account"
        Me.BandedGridColumn63.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn63.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn63.FieldName = "N_A2"
        Me.BandedGridColumn63.Name = "BandedGridColumn63"
        Me.BandedGridColumn63.Visible = True
        Me.BandedGridColumn63.Width = 100
        '
        'BandedGridColumn64
        '
        Me.BandedGridColumn64.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn64.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn64.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn64.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn64.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn64.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn64.Caption = "Percent"
        Me.BandedGridColumn64.FieldName = "N_P2"
        Me.BandedGridColumn64.Name = "BandedGridColumn64"
        Me.BandedGridColumn64.Visible = True
        Me.BandedGridColumn64.Width = 100
        '
        'GridBand48
        '
        Me.GridBand48.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand48.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand48.Caption = "O. To Pay Writ Fee" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.GridBand48.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand49, Me.GridBand50})
        Me.GridBand48.Name = "GridBand48"
        Me.GridBand48.VisibleIndex = 7
        Me.GridBand48.Width = 400
        '
        'GridBand49
        '
        Me.GridBand49.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand49.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand49.Caption = "Amount"
        Me.GridBand49.Columns.Add(Me.BandedGridColumn65)
        Me.GridBand49.Columns.Add(Me.BandedGridColumn66)
        Me.GridBand49.Name = "GridBand49"
        Me.GridBand49.VisibleIndex = 0
        Me.GridBand49.Width = 200
        '
        'BandedGridColumn65
        '
        Me.BandedGridColumn65.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn65.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn65.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn65.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn65.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn65.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn65.Caption = "Amount"
        Me.BandedGridColumn65.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn65.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn65.FieldName = "O_A1"
        Me.BandedGridColumn65.Name = "BandedGridColumn65"
        Me.BandedGridColumn65.Visible = True
        Me.BandedGridColumn65.Width = 100
        '
        'BandedGridColumn66
        '
        Me.BandedGridColumn66.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn66.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn66.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn66.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn66.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn66.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn66.Caption = "Percent"
        Me.BandedGridColumn66.FieldName = "O_P1"
        Me.BandedGridColumn66.Name = "BandedGridColumn66"
        Me.BandedGridColumn66.Visible = True
        Me.BandedGridColumn66.Width = 100
        '
        'GridBand50
        '
        Me.GridBand50.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand50.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand50.Caption = "Account"
        Me.GridBand50.Columns.Add(Me.BandedGridColumn67)
        Me.GridBand50.Columns.Add(Me.BandedGridColumn68)
        Me.GridBand50.Name = "GridBand50"
        Me.GridBand50.VisibleIndex = 1
        Me.GridBand50.Width = 200
        '
        'BandedGridColumn67
        '
        Me.BandedGridColumn67.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn67.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn67.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn67.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn67.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn67.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn67.Caption = "Account"
        Me.BandedGridColumn67.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn67.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn67.FieldName = "O_A2"
        Me.BandedGridColumn67.Name = "BandedGridColumn67"
        Me.BandedGridColumn67.Visible = True
        Me.BandedGridColumn67.Width = 100
        '
        'BandedGridColumn68
        '
        Me.BandedGridColumn68.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn68.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn68.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn68.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn68.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn68.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn68.Caption = "Percent"
        Me.BandedGridColumn68.FieldName = "O_P2"
        Me.BandedGridColumn68.Name = "BandedGridColumn68"
        Me.BandedGridColumn68.Visible = True
        Me.BandedGridColumn68.Width = 100
        '
        'GridBand51
        '
        Me.GridBand51.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand51.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand51.Caption = "P. To Pay Sheriff's Bill"
        Me.GridBand51.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand52, Me.GridBand53})
        Me.GridBand51.Name = "GridBand51"
        Me.GridBand51.VisibleIndex = 8
        Me.GridBand51.Width = 400
        '
        'GridBand52
        '
        Me.GridBand52.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand52.Caption = "Amount"
        Me.GridBand52.Columns.Add(Me.BandedGridColumn69)
        Me.GridBand52.Columns.Add(Me.BandedGridColumn70)
        Me.GridBand52.Name = "GridBand52"
        Me.GridBand52.VisibleIndex = 0
        Me.GridBand52.Width = 200
        '
        'BandedGridColumn69
        '
        Me.BandedGridColumn69.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn69.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn69.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn69.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn69.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn69.Caption = "Amount"
        Me.BandedGridColumn69.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn69.FieldName = "P_A1"
        Me.BandedGridColumn69.Name = "BandedGridColumn69"
        Me.BandedGridColumn69.Visible = True
        Me.BandedGridColumn69.Width = 100
        '
        'BandedGridColumn70
        '
        Me.BandedGridColumn70.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn70.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn70.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn70.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn70.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn70.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn70.Caption = "Percent"
        Me.BandedGridColumn70.FieldName = "P_P1"
        Me.BandedGridColumn70.Name = "BandedGridColumn70"
        Me.BandedGridColumn70.Visible = True
        Me.BandedGridColumn70.Width = 100
        '
        'GridBand53
        '
        Me.GridBand53.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand53.Caption = "Account"
        Me.GridBand53.Columns.Add(Me.BandedGridColumn71)
        Me.GridBand53.Columns.Add(Me.BandedGridColumn72)
        Me.GridBand53.Name = "GridBand53"
        Me.GridBand53.VisibleIndex = 1
        Me.GridBand53.Width = 200
        '
        'BandedGridColumn71
        '
        Me.BandedGridColumn71.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn71.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn71.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn71.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn71.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn71.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn71.Caption = "Account"
        Me.BandedGridColumn71.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn71.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn71.FieldName = "P_A2"
        Me.BandedGridColumn71.Name = "BandedGridColumn71"
        Me.BandedGridColumn71.Visible = True
        Me.BandedGridColumn71.Width = 100
        '
        'BandedGridColumn72
        '
        Me.BandedGridColumn72.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn72.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn72.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn72.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn72.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn72.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn72.Caption = "Percent"
        Me.BandedGridColumn72.FieldName = "P_P2"
        Me.BandedGridColumn72.Name = "BandedGridColumn72"
        Me.BandedGridColumn72.Visible = True
        Me.BandedGridColumn72.Width = 100
        '
        'gridBand57
        '
        Me.gridBand57.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand57.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand57.Caption = "Q. MFE for Monitoring"
        Me.gridBand57.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand58, Me.gridBand59})
        Me.gridBand57.Name = "gridBand57"
        Me.gridBand57.VisibleIndex = 9
        Me.gridBand57.Width = 400
        '
        'gridBand58
        '
        Me.gridBand58.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand58.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand58.Caption = "Amount"
        Me.gridBand58.Columns.Add(Me.BandedGridColumn77)
        Me.gridBand58.Columns.Add(Me.BandedGridColumn78)
        Me.gridBand58.Name = "gridBand58"
        Me.gridBand58.VisibleIndex = 0
        Me.gridBand58.Width = 200
        '
        'BandedGridColumn77
        '
        Me.BandedGridColumn77.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn77.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn77.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn77.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn77.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn77.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn77.Caption = "Amount"
        Me.BandedGridColumn77.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn77.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn77.FieldName = "Q_A1"
        Me.BandedGridColumn77.Name = "BandedGridColumn77"
        Me.BandedGridColumn77.Visible = True
        Me.BandedGridColumn77.Width = 100
        '
        'BandedGridColumn78
        '
        Me.BandedGridColumn78.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn78.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn78.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn78.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn78.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn78.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn78.Caption = "Percent"
        Me.BandedGridColumn78.FieldName = "Q_P1"
        Me.BandedGridColumn78.Name = "BandedGridColumn78"
        Me.BandedGridColumn78.Visible = True
        Me.BandedGridColumn78.Width = 100
        '
        'gridBand59
        '
        Me.gridBand59.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand59.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand59.Caption = "Account"
        Me.gridBand59.Columns.Add(Me.BandedGridColumn79)
        Me.gridBand59.Columns.Add(Me.BandedGridColumn80)
        Me.gridBand59.Name = "gridBand59"
        Me.gridBand59.VisibleIndex = 1
        Me.gridBand59.Width = 200
        '
        'BandedGridColumn79
        '
        Me.BandedGridColumn79.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn79.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn79.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn79.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn79.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn79.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn79.Caption = "Account"
        Me.BandedGridColumn79.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn79.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn79.FieldName = "Q_A2"
        Me.BandedGridColumn79.Name = "BandedGridColumn79"
        Me.BandedGridColumn79.Visible = True
        Me.BandedGridColumn79.Width = 100
        '
        'BandedGridColumn80
        '
        Me.BandedGridColumn80.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn80.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn80.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn80.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn80.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn80.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn80.Caption = "Percent2"
        Me.BandedGridColumn80.FieldName = "Q_P2"
        Me.BandedGridColumn80.Name = "BandedGridColumn80"
        Me.BandedGridColumn80.Visible = True
        Me.BandedGridColumn80.Width = 100
        '
        'GridBand54
        '
        Me.GridBand54.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand54.AppearanceHeader.Options.UseFont = True
        Me.GridBand54.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand54.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand54.Caption = "T O T A L"
        Me.GridBand54.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand55, Me.GridBand56})
        Me.GridBand54.Name = "GridBand54"
        Me.GridBand54.VisibleIndex = 10
        Me.GridBand54.Width = 400
        '
        'GridBand55
        '
        Me.GridBand55.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand55.AppearanceHeader.Options.UseFont = True
        Me.GridBand55.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand55.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand55.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridBand55.Caption = "Amount"
        Me.GridBand55.Columns.Add(Me.BandedGridColumn73)
        Me.GridBand55.Columns.Add(Me.BandedGridColumn74)
        Me.GridBand55.Name = "GridBand55"
        Me.GridBand55.VisibleIndex = 0
        Me.GridBand55.Width = 200
        '
        'BandedGridColumn73
        '
        Me.BandedGridColumn73.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn73.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn73.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn73.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn73.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn73.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn73.Caption = "Amount"
        Me.BandedGridColumn73.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn73.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn73.FieldName = "T_A1"
        Me.BandedGridColumn73.Name = "BandedGridColumn73"
        Me.BandedGridColumn73.Visible = True
        Me.BandedGridColumn73.Width = 100
        '
        'BandedGridColumn74
        '
        Me.BandedGridColumn74.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn74.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn74.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn74.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn74.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn74.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn74.Caption = "Percent"
        Me.BandedGridColumn74.FieldName = "T_P1"
        Me.BandedGridColumn74.Name = "BandedGridColumn74"
        Me.BandedGridColumn74.Visible = True
        Me.BandedGridColumn74.Width = 100
        '
        'GridBand56
        '
        Me.GridBand56.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand56.AppearanceHeader.Options.UseFont = True
        Me.GridBand56.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand56.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand56.Caption = "Account"
        Me.GridBand56.Columns.Add(Me.BandedGridColumn75)
        Me.GridBand56.Columns.Add(Me.BandedGridColumn76)
        Me.GridBand56.Name = "GridBand56"
        Me.GridBand56.VisibleIndex = 1
        Me.GridBand56.Width = 200
        '
        'BandedGridColumn75
        '
        Me.BandedGridColumn75.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn75.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn75.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn75.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn75.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn75.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn75.Caption = "Account"
        Me.BandedGridColumn75.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn75.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn75.FieldName = "T_A2"
        Me.BandedGridColumn75.Name = "BandedGridColumn75"
        Me.BandedGridColumn75.Visible = True
        Me.BandedGridColumn75.Width = 100
        '
        'BandedGridColumn76
        '
        Me.BandedGridColumn76.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn76.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn76.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn76.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn76.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn76.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn76.Caption = "Percent"
        Me.BandedGridColumn76.FieldName = "T_P2"
        Me.BandedGridColumn76.Name = "BandedGridColumn76"
        Me.BandedGridColumn76.Visible = True
        Me.BandedGridColumn76.Width = 100
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
        'tabDecided
        '
        Me.tabDecided.AttachedControl = Me.SuperTabControlPanel3
        Me.tabDecided.GlobalItem = False
        Me.tabDecided.Name = "tabDecided"
        Me.tabDecided.Text = "Decided"
        Me.tabDecided.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
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
        Me.SuperTabControlPanel2.TabItem = Me.tabOngoing
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
        Me.GridControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.BandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl1.TabIndex = 1678
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
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand28, Me.gridBand1, Me.gridBand4, Me.gridBand7, Me.gridBand10, Me.gridBand13, Me.gridBand16, Me.gridBand19, Me.gridBand22, Me.gridBand25})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn11, Me.BandedGridColumn12, Me.BandedGridColumn13, Me.BandedGridColumn14, Me.BandedGridColumn15, Me.BandedGridColumn16, Me.BandedGridColumn17, Me.BandedGridColumn18, Me.BandedGridColumn19, Me.BandedGridColumn20, Me.BandedGridColumn21, Me.BandedGridColumn22, Me.BandedGridColumn23, Me.BandedGridColumn24, Me.BandedGridColumn25, Me.BandedGridColumn26, Me.BandedGridColumn27, Me.BandedGridColumn28, Me.BandedGridColumn29, Me.BandedGridColumn30, Me.BandedGridColumn31, Me.BandedGridColumn32, Me.BandedGridColumn33, Me.BandedGridColumn34, Me.BandedGridColumn35, Me.BandedGridColumn36, Me.BandedGridColumn37, Me.BandedGridColumn38, Me.BandedGridColumn39})
        Me.BandedGridView1.CustomizationFormBounds = New System.Drawing.Rectangle(741, 493, 216, 235)
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
        Me.BandedGridView1.OptionsView.ShowFooter = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'gridBand28
        '
        Me.gridBand28.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gridBand28.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gridBand28.AppearanceHeader.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBand28.AppearanceHeader.Options.UseBackColor = True
        Me.gridBand28.AppearanceHeader.Options.UseFont = True
        Me.gridBand28.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand28.Caption = "Branch"
        Me.gridBand28.Columns.Add(Me.BandedGridColumn39)
        Me.gridBand28.Name = "gridBand28"
        Me.gridBand28.VisibleIndex = 0
        Me.gridBand28.Width = 200
        '
        'BandedGridColumn39
        '
        Me.BandedGridColumn39.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridColumn39.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridColumn39.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn39.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn39.AppearanceHeader.Options.UseBackColor = True
        Me.BandedGridColumn39.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn39.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn39.FieldName = "Branch"
        Me.BandedGridColumn39.Name = "BandedGridColumn39"
        Me.BandedGridColumn39.Visible = True
        Me.BandedGridColumn39.Width = 200
        '
        'gridBand1
        '
        Me.gridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand1.Caption = "A. Newly Filed"
        Me.gridBand1.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.gridBand3})
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 1
        Me.gridBand1.Width = 400
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Amount"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 200
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn1.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn1.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn1.Caption = "Amount"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.FieldName = "A_A1"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 100
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn2.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn2.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn2.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn2.Caption = "Percent"
        Me.BandedGridColumn2.FieldName = "A_P1"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 100
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Account"
        Me.gridBand3.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn4)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 200
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn3.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn3.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn3.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn3.Caption = "Account"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "A_A2"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 100
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn4.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn4.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn4.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn4.Caption = "Percent"
        Me.BandedGridColumn4.FieldName = "A_P2"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 100
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "B. For Raffle"
        Me.gridBand4.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand5, Me.gridBand6})
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 2
        Me.gridBand4.Width = 400
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "Amount"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 0
        Me.gridBand5.Width = 200
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn7.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn7.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn7.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn7.Caption = "Amount"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "B_A1"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 100
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn8.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn8.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn8.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn8.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn8.Caption = "Percent"
        Me.BandedGridColumn8.FieldName = "B_P1"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 100
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Account"
        Me.gridBand6.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand6.Columns.Add(Me.BandedGridColumn10)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 1
        Me.gridBand6.Width = 200
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn9.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn9.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn9.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn9.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn9.Caption = "Account"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "B_A2"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 100
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn10.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn10.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn10.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn10.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn10.Caption = "Percent"
        Me.BandedGridColumn10.FieldName = "B_P2"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 100
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "C. For Delivery of Summons"
        Me.gridBand7.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.gridBand9})
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 3
        Me.gridBand7.Width = 400
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Amount"
        Me.gridBand8.Columns.Add(Me.BandedGridColumn11)
        Me.gridBand8.Columns.Add(Me.BandedGridColumn12)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 200
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn11.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn11.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn11.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn11.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn11.Caption = "Amount"
        Me.BandedGridColumn11.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn11.FieldName = "C_A1"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Visible = True
        Me.BandedGridColumn11.Width = 100
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn12.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn12.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn12.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn12.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn12.Caption = "Percent"
        Me.BandedGridColumn12.FieldName = "C_P1"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.Visible = True
        Me.BandedGridColumn12.Width = 100
        '
        'gridBand9
        '
        Me.gridBand9.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand9.Caption = "Account"
        Me.gridBand9.Columns.Add(Me.BandedGridColumn13)
        Me.gridBand9.Columns.Add(Me.BandedGridColumn14)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 1
        Me.gridBand9.Width = 200
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn13.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn13.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn13.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn13.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn13.Caption = "Account"
        Me.BandedGridColumn13.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn13.FieldName = "C_A2"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Visible = True
        Me.BandedGridColumn13.Width = 100
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn14.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn14.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn14.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn14.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn14.Caption = "Percent"
        Me.BandedGridColumn14.FieldName = "C_P2"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.Visible = True
        Me.BandedGridColumn14.Width = 100
        '
        'gridBand10
        '
        Me.gridBand10.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand10.Caption = "D. For PMC"
        Me.gridBand10.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand11, Me.gridBand12})
        Me.gridBand10.Name = "gridBand10"
        Me.gridBand10.VisibleIndex = 4
        Me.gridBand10.Width = 400
        '
        'gridBand11
        '
        Me.gridBand11.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand11.Caption = "Amount"
        Me.gridBand11.Columns.Add(Me.BandedGridColumn15)
        Me.gridBand11.Columns.Add(Me.BandedGridColumn16)
        Me.gridBand11.Name = "gridBand11"
        Me.gridBand11.VisibleIndex = 0
        Me.gridBand11.Width = 200
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn15.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn15.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn15.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn15.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn15.Caption = "Amount"
        Me.BandedGridColumn15.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn15.FieldName = "D_A1"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.Visible = True
        Me.BandedGridColumn15.Width = 100
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn16.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn16.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn16.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn16.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn16.Caption = "Percent"
        Me.BandedGridColumn16.FieldName = "D_P1"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.Visible = True
        Me.BandedGridColumn16.Width = 100
        '
        'gridBand12
        '
        Me.gridBand12.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand12.Caption = "Account"
        Me.gridBand12.Columns.Add(Me.BandedGridColumn17)
        Me.gridBand12.Columns.Add(Me.BandedGridColumn18)
        Me.gridBand12.Name = "gridBand12"
        Me.gridBand12.VisibleIndex = 1
        Me.gridBand12.Width = 200
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn17.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn17.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn17.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn17.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn17.Caption = "Account"
        Me.BandedGridColumn17.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn17.FieldName = "D_A2"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        Me.BandedGridColumn17.Visible = True
        Me.BandedGridColumn17.Width = 100
        '
        'BandedGridColumn18
        '
        Me.BandedGridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn18.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn18.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn18.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn18.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn18.Caption = "Percent"
        Me.BandedGridColumn18.FieldName = "D_P2"
        Me.BandedGridColumn18.Name = "BandedGridColumn18"
        Me.BandedGridColumn18.Visible = True
        Me.BandedGridColumn18.Width = 100
        '
        'gridBand13
        '
        Me.gridBand13.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand13.Caption = "E. For JDR"
        Me.gridBand13.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand14, Me.gridBand15})
        Me.gridBand13.Name = "gridBand13"
        Me.gridBand13.VisibleIndex = 5
        Me.gridBand13.Width = 400
        '
        'gridBand14
        '
        Me.gridBand14.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand14.Caption = "Amount"
        Me.gridBand14.Columns.Add(Me.BandedGridColumn19)
        Me.gridBand14.Columns.Add(Me.BandedGridColumn20)
        Me.gridBand14.Name = "gridBand14"
        Me.gridBand14.VisibleIndex = 0
        Me.gridBand14.Width = 200
        '
        'BandedGridColumn19
        '
        Me.BandedGridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn19.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn19.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn19.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn19.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn19.Caption = "Amount"
        Me.BandedGridColumn19.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn19.FieldName = "E_A1"
        Me.BandedGridColumn19.Name = "BandedGridColumn19"
        Me.BandedGridColumn19.Visible = True
        Me.BandedGridColumn19.Width = 100
        '
        'BandedGridColumn20
        '
        Me.BandedGridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn20.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn20.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn20.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn20.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn20.Caption = "Percent"
        Me.BandedGridColumn20.FieldName = "E_P1"
        Me.BandedGridColumn20.Name = "BandedGridColumn20"
        Me.BandedGridColumn20.Visible = True
        Me.BandedGridColumn20.Width = 100
        '
        'gridBand15
        '
        Me.gridBand15.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand15.Caption = "Account"
        Me.gridBand15.Columns.Add(Me.BandedGridColumn21)
        Me.gridBand15.Columns.Add(Me.BandedGridColumn22)
        Me.gridBand15.Name = "gridBand15"
        Me.gridBand15.VisibleIndex = 1
        Me.gridBand15.Width = 200
        '
        'BandedGridColumn21
        '
        Me.BandedGridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn21.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn21.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn21.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn21.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn21.Caption = "Account"
        Me.BandedGridColumn21.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn21.FieldName = "E_A2"
        Me.BandedGridColumn21.Name = "BandedGridColumn21"
        Me.BandedGridColumn21.Visible = True
        Me.BandedGridColumn21.Width = 100
        '
        'BandedGridColumn22
        '
        Me.BandedGridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn22.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn22.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn22.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn22.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn22.Caption = "Percent"
        Me.BandedGridColumn22.FieldName = "E_P2"
        Me.BandedGridColumn22.Name = "BandedGridColumn22"
        Me.BandedGridColumn22.Visible = True
        Me.BandedGridColumn22.Width = 100
        '
        'gridBand16
        '
        Me.gridBand16.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand16.Caption = "F. Pre-Trial"
        Me.gridBand16.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand17, Me.gridBand18})
        Me.gridBand16.Name = "gridBand16"
        Me.gridBand16.VisibleIndex = 6
        Me.gridBand16.Width = 400
        '
        'gridBand17
        '
        Me.gridBand17.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand17.Caption = "Amount"
        Me.gridBand17.Columns.Add(Me.BandedGridColumn23)
        Me.gridBand17.Columns.Add(Me.BandedGridColumn24)
        Me.gridBand17.Name = "gridBand17"
        Me.gridBand17.VisibleIndex = 0
        Me.gridBand17.Width = 200
        '
        'BandedGridColumn23
        '
        Me.BandedGridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn23.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn23.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn23.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn23.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn23.Caption = "Amount"
        Me.BandedGridColumn23.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn23.FieldName = "F_A1"
        Me.BandedGridColumn23.Name = "BandedGridColumn23"
        Me.BandedGridColumn23.Visible = True
        Me.BandedGridColumn23.Width = 100
        '
        'BandedGridColumn24
        '
        Me.BandedGridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn24.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn24.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn24.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn24.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn24.Caption = "Percent"
        Me.BandedGridColumn24.FieldName = "F_P1"
        Me.BandedGridColumn24.Name = "BandedGridColumn24"
        Me.BandedGridColumn24.Visible = True
        Me.BandedGridColumn24.Width = 100
        '
        'gridBand18
        '
        Me.gridBand18.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand18.Caption = "Account"
        Me.gridBand18.Columns.Add(Me.BandedGridColumn25)
        Me.gridBand18.Columns.Add(Me.BandedGridColumn26)
        Me.gridBand18.Name = "gridBand18"
        Me.gridBand18.VisibleIndex = 1
        Me.gridBand18.Width = 200
        '
        'BandedGridColumn25
        '
        Me.BandedGridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn25.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn25.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn25.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn25.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn25.Caption = "Account"
        Me.BandedGridColumn25.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn25.FieldName = "F_A2"
        Me.BandedGridColumn25.Name = "BandedGridColumn25"
        Me.BandedGridColumn25.Visible = True
        Me.BandedGridColumn25.Width = 100
        '
        'BandedGridColumn26
        '
        Me.BandedGridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn26.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn26.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn26.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn26.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn26.Caption = "Percent"
        Me.BandedGridColumn26.FieldName = "F_P2"
        Me.BandedGridColumn26.Name = "BandedGridColumn26"
        Me.BandedGridColumn26.Visible = True
        Me.BandedGridColumn26.Width = 100
        '
        'gridBand19
        '
        Me.gridBand19.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand19.Caption = "G. Trial"
        Me.gridBand19.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand20, Me.gridBand21})
        Me.gridBand19.Name = "gridBand19"
        Me.gridBand19.VisibleIndex = 7
        Me.gridBand19.Width = 400
        '
        'gridBand20
        '
        Me.gridBand20.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand20.Caption = "Amount"
        Me.gridBand20.Columns.Add(Me.BandedGridColumn27)
        Me.gridBand20.Columns.Add(Me.BandedGridColumn28)
        Me.gridBand20.Name = "gridBand20"
        Me.gridBand20.VisibleIndex = 0
        Me.gridBand20.Width = 200
        '
        'BandedGridColumn27
        '
        Me.BandedGridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn27.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn27.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn27.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn27.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn27.Caption = "Amount"
        Me.BandedGridColumn27.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn27.FieldName = "G_A1"
        Me.BandedGridColumn27.Name = "BandedGridColumn27"
        Me.BandedGridColumn27.Visible = True
        Me.BandedGridColumn27.Width = 100
        '
        'BandedGridColumn28
        '
        Me.BandedGridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn28.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn28.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn28.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn28.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn28.Caption = "Percent"
        Me.BandedGridColumn28.FieldName = "G_P1"
        Me.BandedGridColumn28.Name = "BandedGridColumn28"
        Me.BandedGridColumn28.Visible = True
        Me.BandedGridColumn28.Width = 100
        '
        'gridBand21
        '
        Me.gridBand21.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand21.Caption = "Account"
        Me.gridBand21.Columns.Add(Me.BandedGridColumn29)
        Me.gridBand21.Columns.Add(Me.BandedGridColumn30)
        Me.gridBand21.Name = "gridBand21"
        Me.gridBand21.VisibleIndex = 1
        Me.gridBand21.Width = 200
        '
        'BandedGridColumn29
        '
        Me.BandedGridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn29.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn29.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn29.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn29.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn29.Caption = "Account"
        Me.BandedGridColumn29.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn29.FieldName = "G_A2"
        Me.BandedGridColumn29.Name = "BandedGridColumn29"
        Me.BandedGridColumn29.Visible = True
        Me.BandedGridColumn29.Width = 100
        '
        'BandedGridColumn30
        '
        Me.BandedGridColumn30.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn30.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn30.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn30.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn30.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn30.Caption = "Percent"
        Me.BandedGridColumn30.FieldName = "G_P2"
        Me.BandedGridColumn30.Name = "BandedGridColumn30"
        Me.BandedGridColumn30.Visible = True
        Me.BandedGridColumn30.Width = 100
        '
        'gridBand22
        '
        Me.gridBand22.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand22.Caption = "H. Submitted For Decision"
        Me.gridBand22.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand23, Me.gridBand24})
        Me.gridBand22.Name = "gridBand22"
        Me.gridBand22.VisibleIndex = 8
        Me.gridBand22.Width = 400
        '
        'gridBand23
        '
        Me.gridBand23.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand23.Caption = "Amount"
        Me.gridBand23.Columns.Add(Me.BandedGridColumn31)
        Me.gridBand23.Columns.Add(Me.BandedGridColumn32)
        Me.gridBand23.Name = "gridBand23"
        Me.gridBand23.VisibleIndex = 0
        Me.gridBand23.Width = 200
        '
        'BandedGridColumn31
        '
        Me.BandedGridColumn31.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn31.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn31.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn31.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn31.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn31.Caption = "Amount"
        Me.BandedGridColumn31.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn31.FieldName = "H_A1"
        Me.BandedGridColumn31.Name = "BandedGridColumn31"
        Me.BandedGridColumn31.Visible = True
        Me.BandedGridColumn31.Width = 100
        '
        'BandedGridColumn32
        '
        Me.BandedGridColumn32.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn32.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn32.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn32.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn32.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn32.Caption = "Percent"
        Me.BandedGridColumn32.FieldName = "H_P1"
        Me.BandedGridColumn32.Name = "BandedGridColumn32"
        Me.BandedGridColumn32.Visible = True
        Me.BandedGridColumn32.Width = 100
        '
        'gridBand24
        '
        Me.gridBand24.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand24.Caption = "Account"
        Me.gridBand24.Columns.Add(Me.BandedGridColumn33)
        Me.gridBand24.Columns.Add(Me.BandedGridColumn34)
        Me.gridBand24.Name = "gridBand24"
        Me.gridBand24.VisibleIndex = 1
        Me.gridBand24.Width = 200
        '
        'BandedGridColumn33
        '
        Me.BandedGridColumn33.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn33.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn33.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn33.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn33.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn33.Caption = "Account"
        Me.BandedGridColumn33.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn33.FieldName = "H_A2"
        Me.BandedGridColumn33.Name = "BandedGridColumn33"
        Me.BandedGridColumn33.Visible = True
        Me.BandedGridColumn33.Width = 100
        '
        'BandedGridColumn34
        '
        Me.BandedGridColumn34.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn34.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn34.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn34.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn34.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn34.Caption = "Percent"
        Me.BandedGridColumn34.FieldName = "H_P2"
        Me.BandedGridColumn34.Name = "BandedGridColumn34"
        Me.BandedGridColumn34.Visible = True
        Me.BandedGridColumn34.Width = 100
        '
        'gridBand25
        '
        Me.gridBand25.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridBand25.AppearanceHeader.Options.UseFont = True
        Me.gridBand25.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand25.Caption = "T O T A L"
        Me.gridBand25.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand26, Me.gridBand27})
        Me.gridBand25.Name = "gridBand25"
        Me.gridBand25.VisibleIndex = 9
        Me.gridBand25.Width = 400
        '
        'gridBand26
        '
        Me.gridBand26.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridBand26.AppearanceHeader.Options.UseFont = True
        Me.gridBand26.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand26.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridBand26.Caption = "Amount"
        Me.gridBand26.Columns.Add(Me.BandedGridColumn35)
        Me.gridBand26.Columns.Add(Me.BandedGridColumn36)
        Me.gridBand26.Name = "gridBand26"
        Me.gridBand26.VisibleIndex = 0
        Me.gridBand26.Width = 200
        '
        'BandedGridColumn35
        '
        Me.BandedGridColumn35.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn35.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn35.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn35.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn35.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn35.Caption = "Amount"
        Me.BandedGridColumn35.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn35.FieldName = "T_A1"
        Me.BandedGridColumn35.Name = "BandedGridColumn35"
        Me.BandedGridColumn35.Visible = True
        Me.BandedGridColumn35.Width = 100
        '
        'BandedGridColumn36
        '
        Me.BandedGridColumn36.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn36.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn36.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn36.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn36.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn36.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn36.Caption = "Percent"
        Me.BandedGridColumn36.FieldName = "T_P1"
        Me.BandedGridColumn36.Name = "BandedGridColumn36"
        Me.BandedGridColumn36.Visible = True
        Me.BandedGridColumn36.Width = 100
        '
        'gridBand27
        '
        Me.gridBand27.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridBand27.AppearanceHeader.Options.UseFont = True
        Me.gridBand27.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand27.Caption = "Account"
        Me.gridBand27.Columns.Add(Me.BandedGridColumn37)
        Me.gridBand27.Columns.Add(Me.BandedGridColumn38)
        Me.gridBand27.Name = "gridBand27"
        Me.gridBand27.VisibleIndex = 1
        Me.gridBand27.Width = 200
        '
        'BandedGridColumn37
        '
        Me.BandedGridColumn37.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn37.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn37.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn37.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn37.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn37.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn37.Caption = "Account"
        Me.BandedGridColumn37.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn37.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn37.FieldName = "T_A2"
        Me.BandedGridColumn37.Name = "BandedGridColumn37"
        Me.BandedGridColumn37.Visible = True
        Me.BandedGridColumn37.Width = 100
        '
        'BandedGridColumn38
        '
        Me.BandedGridColumn38.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn38.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn38.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn38.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn38.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn38.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn38.Caption = "Percent"
        Me.BandedGridColumn38.FieldName = "T_P2"
        Me.BandedGridColumn38.Name = "BandedGridColumn38"
        Me.BandedGridColumn38.Visible = True
        Me.BandedGridColumn38.Width = 100
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
        'tabOngoing
        '
        Me.tabOngoing.AttachedControl = Me.SuperTabControlPanel2
        Me.tabOngoing.GlobalItem = False
        Me.tabOngoing.Name = "tabOngoing"
        Me.tabOngoing.Text = "On Going"
        Me.tabOngoing.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.GridControl6)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.tabWritteOff
        '
        'GridControl6
        '
        Me.GridControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl6.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl6.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl6.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl6.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl6.Location = New System.Drawing.Point(0, 0)
        Me.GridControl6.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl6.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl6.MainView = Me.BandedGridView6
        Me.GridControl6.Name = "GridControl6"
        Me.GridControl6.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit6})
        Me.GridControl6.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl6.TabIndex = 1682
        Me.GridControl6.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView6})
        '
        'BandedGridView6
        '
        Me.BandedGridView6.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView6.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView6.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView6.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView6.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView6.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView6.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView6.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView6.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView6.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView6.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView6.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView6.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView6.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView6.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView6.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView6.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView6.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView6.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView6.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView6.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView6.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView6.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView6.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView6.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView6.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView6.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView6.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView6.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView6.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView6.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView6.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.Row.Options.UseFont = True
        Me.BandedGridView6.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView6.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView6.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView6.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView6.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView6.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView6.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView6.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView6.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView6.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView6.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView6.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand96, Me.GridBand97})
        Me.BandedGridView6.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn129, Me.BandedGridColumn130, Me.BandedGridColumn131, Me.BandedGridColumn132, Me.BandedGridColumn128})
        Me.BandedGridView6.CustomizationFormBounds = New System.Drawing.Rectangle(741, 493, 216, 235)
        Me.BandedGridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView6.GridControl = Me.GridControl6
        Me.BandedGridView6.GroupPanelText = "General Requirements"
        Me.BandedGridView6.Name = "BandedGridView6"
        Me.BandedGridView6.OptionsBehavior.Editable = False
        Me.BandedGridView6.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView6.OptionsLayout.StoreAppearance = True
        Me.BandedGridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView6.OptionsSelection.MultiSelect = True
        Me.BandedGridView6.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView6.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView6.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView6.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView6.OptionsView.ShowFooter = True
        Me.BandedGridView6.OptionsView.ShowGroupPanel = False
        '
        'GridBand96
        '
        Me.GridBand96.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand96.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand96.Caption = "Branch"
        Me.GridBand96.Columns.Add(Me.BandedGridColumn128)
        Me.GridBand96.Name = "GridBand96"
        Me.GridBand96.VisibleIndex = 0
        Me.GridBand96.Width = 200
        '
        'BandedGridColumn128
        '
        Me.BandedGridColumn128.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn128.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn128.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn128.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn128.FieldName = "Branch"
        Me.BandedGridColumn128.Name = "BandedGridColumn128"
        Me.BandedGridColumn128.Visible = True
        Me.BandedGridColumn128.Width = 200
        '
        'GridBand97
        '
        Me.GridBand97.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand97.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand97.Caption = "Written Off"
        Me.GridBand97.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand98, Me.GridBand99})
        Me.GridBand97.Name = "GridBand97"
        Me.GridBand97.VisibleIndex = 1
        Me.GridBand97.Width = 400
        '
        'GridBand98
        '
        Me.GridBand98.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand98.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand98.Caption = "Amount"
        Me.GridBand98.Columns.Add(Me.BandedGridColumn129)
        Me.GridBand98.Columns.Add(Me.BandedGridColumn130)
        Me.GridBand98.Name = "GridBand98"
        Me.GridBand98.VisibleIndex = 0
        Me.GridBand98.Width = 200
        '
        'BandedGridColumn129
        '
        Me.BandedGridColumn129.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn129.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn129.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn129.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn129.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn129.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn129.Caption = "Amount"
        Me.BandedGridColumn129.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn129.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn129.FieldName = "Z_A1"
        Me.BandedGridColumn129.Name = "BandedGridColumn129"
        Me.BandedGridColumn129.Visible = True
        Me.BandedGridColumn129.Width = 100
        '
        'BandedGridColumn130
        '
        Me.BandedGridColumn130.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn130.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn130.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn130.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn130.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn130.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn130.Caption = "Percent"
        Me.BandedGridColumn130.FieldName = "Z_P1"
        Me.BandedGridColumn130.Name = "BandedGridColumn130"
        Me.BandedGridColumn130.Visible = True
        Me.BandedGridColumn130.Width = 100
        '
        'GridBand99
        '
        Me.GridBand99.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand99.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand99.Caption = "Account"
        Me.GridBand99.Columns.Add(Me.BandedGridColumn131)
        Me.GridBand99.Columns.Add(Me.BandedGridColumn132)
        Me.GridBand99.Name = "GridBand99"
        Me.GridBand99.VisibleIndex = 1
        Me.GridBand99.Width = 200
        '
        'BandedGridColumn131
        '
        Me.BandedGridColumn131.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn131.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn131.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn131.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn131.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn131.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn131.Caption = "Account"
        Me.BandedGridColumn131.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn131.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn131.FieldName = "Z_A2"
        Me.BandedGridColumn131.Name = "BandedGridColumn131"
        Me.BandedGridColumn131.Visible = True
        Me.BandedGridColumn131.Width = 100
        '
        'BandedGridColumn132
        '
        Me.BandedGridColumn132.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn132.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn132.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn132.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn132.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn132.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn132.Caption = "Percent"
        Me.BandedGridColumn132.FieldName = "Z_P2"
        Me.BandedGridColumn132.Name = "BandedGridColumn132"
        Me.BandedGridColumn132.Visible = True
        Me.BandedGridColumn132.Width = 100
        '
        'RepositoryItemCheckEdit6
        '
        Me.RepositoryItemCheckEdit6.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit6.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit6.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit6.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit6.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit6.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit6.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit6.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit6.AutoHeight = False
        Me.RepositoryItemCheckEdit6.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit6.Name = "RepositoryItemCheckEdit6"
        Me.RepositoryItemCheckEdit6.ValueChecked = "True"
        Me.RepositoryItemCheckEdit6.ValueUnchecked = "False"
        '
        'tabWritteOff
        '
        Me.tabWritteOff.AttachedControl = Me.SuperTabControlPanel7
        Me.tabWritteOff.GlobalItem = False
        Me.tabWritteOff.Name = "tabWritteOff"
        Me.tabWritteOff.Text = "Written Off"
        Me.tabWritteOff.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.GridControl5)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.tabArchived
        '
        'GridControl5
        '
        Me.GridControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl5.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl5.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl5.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl5.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl5.Location = New System.Drawing.Point(0, 0)
        Me.GridControl5.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl5.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl5.MainView = Me.BandedGridView5
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit5})
        Me.GridControl5.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl5.TabIndex = 1681
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView5})
        '
        'BandedGridView5
        '
        Me.BandedGridView5.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView5.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView5.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView5.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView5.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView5.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView5.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView5.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView5.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView5.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView5.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView5.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView5.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView5.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView5.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView5.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView5.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView5.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView5.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView5.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView5.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView5.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView5.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView5.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView5.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView5.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView5.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView5.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView5.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView5.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView5.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView5.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.Row.Options.UseFont = True
        Me.BandedGridView5.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView5.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView5.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView5.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView5.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView5.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView5.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView5.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView5.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView5.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView5.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView5.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand92, Me.GridBand93})
        Me.BandedGridView5.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn124, Me.BandedGridColumn125, Me.BandedGridColumn126, Me.BandedGridColumn127, Me.BandedGridColumn123})
        Me.BandedGridView5.CustomizationFormBounds = New System.Drawing.Rectangle(741, 493, 216, 235)
        Me.BandedGridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView5.GridControl = Me.GridControl5
        Me.BandedGridView5.GroupPanelText = "General Requirements"
        Me.BandedGridView5.Name = "BandedGridView5"
        Me.BandedGridView5.OptionsBehavior.Editable = False
        Me.BandedGridView5.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView5.OptionsLayout.StoreAppearance = True
        Me.BandedGridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView5.OptionsSelection.MultiSelect = True
        Me.BandedGridView5.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView5.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView5.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView5.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView5.OptionsView.ShowFooter = True
        Me.BandedGridView5.OptionsView.ShowGroupPanel = False
        '
        'GridBand92
        '
        Me.GridBand92.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand92.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand92.Caption = "Branch"
        Me.GridBand92.Columns.Add(Me.BandedGridColumn123)
        Me.GridBand92.Name = "GridBand92"
        Me.GridBand92.VisibleIndex = 0
        Me.GridBand92.Width = 200
        '
        'BandedGridColumn123
        '
        Me.BandedGridColumn123.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn123.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn123.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn123.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn123.FieldName = "Branch"
        Me.BandedGridColumn123.Name = "BandedGridColumn123"
        Me.BandedGridColumn123.Visible = True
        Me.BandedGridColumn123.Width = 200
        '
        'GridBand93
        '
        Me.GridBand93.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand93.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand93.Caption = "Z. Archived"
        Me.GridBand93.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand94, Me.GridBand95})
        Me.GridBand93.Name = "GridBand93"
        Me.GridBand93.VisibleIndex = 1
        Me.GridBand93.Width = 400
        '
        'GridBand94
        '
        Me.GridBand94.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand94.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand94.Caption = "Amount"
        Me.GridBand94.Columns.Add(Me.BandedGridColumn124)
        Me.GridBand94.Columns.Add(Me.BandedGridColumn125)
        Me.GridBand94.Name = "GridBand94"
        Me.GridBand94.VisibleIndex = 0
        Me.GridBand94.Width = 200
        '
        'BandedGridColumn124
        '
        Me.BandedGridColumn124.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn124.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn124.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn124.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn124.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn124.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn124.Caption = "Amount"
        Me.BandedGridColumn124.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn124.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn124.FieldName = "Z_A1"
        Me.BandedGridColumn124.Name = "BandedGridColumn124"
        Me.BandedGridColumn124.Visible = True
        Me.BandedGridColumn124.Width = 100
        '
        'BandedGridColumn125
        '
        Me.BandedGridColumn125.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn125.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn125.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn125.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn125.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn125.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn125.Caption = "Percent"
        Me.BandedGridColumn125.FieldName = "Z_P1"
        Me.BandedGridColumn125.Name = "BandedGridColumn125"
        Me.BandedGridColumn125.Visible = True
        Me.BandedGridColumn125.Width = 100
        '
        'GridBand95
        '
        Me.GridBand95.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand95.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand95.Caption = "Account"
        Me.GridBand95.Columns.Add(Me.BandedGridColumn126)
        Me.GridBand95.Columns.Add(Me.BandedGridColumn127)
        Me.GridBand95.Name = "GridBand95"
        Me.GridBand95.VisibleIndex = 1
        Me.GridBand95.Width = 200
        '
        'BandedGridColumn126
        '
        Me.BandedGridColumn126.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn126.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn126.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn126.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn126.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn126.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn126.Caption = "Account"
        Me.BandedGridColumn126.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn126.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn126.FieldName = "Z_A2"
        Me.BandedGridColumn126.Name = "BandedGridColumn126"
        Me.BandedGridColumn126.Visible = True
        Me.BandedGridColumn126.Width = 100
        '
        'BandedGridColumn127
        '
        Me.BandedGridColumn127.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn127.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn127.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn127.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn127.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn127.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn127.Caption = "Percent"
        Me.BandedGridColumn127.FieldName = "Z_P2"
        Me.BandedGridColumn127.Name = "BandedGridColumn127"
        Me.BandedGridColumn127.Visible = True
        Me.BandedGridColumn127.Width = 100
        '
        'RepositoryItemCheckEdit5
        '
        Me.RepositoryItemCheckEdit5.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit5.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit5.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit5.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit5.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit5.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit5.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit5.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit5.AutoHeight = False
        Me.RepositoryItemCheckEdit5.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit5.Name = "RepositoryItemCheckEdit5"
        Me.RepositoryItemCheckEdit5.ValueChecked = "True"
        Me.RepositoryItemCheckEdit5.ValueUnchecked = "False"
        '
        'tabArchived
        '
        Me.tabArchived.AttachedControl = Me.SuperTabControlPanel6
        Me.tabArchived.GlobalItem = False
        Me.tabArchived.Name = "tabArchived"
        Me.tabArchived.Text = "Archived"
        Me.tabArchived.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.GridControl4)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.tabDismissed
        '
        'GridControl4
        '
        Me.GridControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl4.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl4.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl4.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl4.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl4.Location = New System.Drawing.Point(0, 0)
        Me.GridControl4.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl4.MainView = Me.BandedGridView4
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit4})
        Me.GridControl4.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl4.TabIndex = 1680
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView4})
        '
        'BandedGridView4
        '
        Me.BandedGridView4.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView4.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView4.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView4.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView4.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView4.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView4.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView4.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView4.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView4.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView4.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView4.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView4.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView4.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView4.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView4.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView4.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView4.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView4.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView4.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView4.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView4.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView4.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView4.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView4.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView4.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView4.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView4.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView4.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.Row.Options.UseFont = True
        Me.BandedGridView4.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView4.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView4.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView4.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView4.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView4.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView4.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView4.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView4.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView4.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView4.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView4.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand79, Me.GridBand80, Me.GridBand83, Me.GridBand86, Me.GridBand89})
        Me.BandedGridView4.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn107, Me.BandedGridColumn108, Me.BandedGridColumn109, Me.BandedGridColumn110, Me.BandedGridColumn111, Me.BandedGridColumn112, Me.BandedGridColumn113, Me.BandedGridColumn114, Me.BandedGridColumn115, Me.BandedGridColumn116, Me.BandedGridColumn117, Me.BandedGridColumn118, Me.BandedGridColumn119, Me.BandedGridColumn120, Me.BandedGridColumn121, Me.BandedGridColumn122, Me.BandedGridColumn106})
        Me.BandedGridView4.CustomizationFormBounds = New System.Drawing.Rectangle(741, 493, 216, 235)
        Me.BandedGridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView4.GridControl = Me.GridControl4
        Me.BandedGridView4.GroupPanelText = "General Requirements"
        Me.BandedGridView4.Name = "BandedGridView4"
        Me.BandedGridView4.OptionsBehavior.Editable = False
        Me.BandedGridView4.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView4.OptionsLayout.StoreAppearance = True
        Me.BandedGridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView4.OptionsSelection.MultiSelect = True
        Me.BandedGridView4.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView4.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView4.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView4.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView4.OptionsView.ShowFooter = True
        Me.BandedGridView4.OptionsView.ShowGroupPanel = False
        '
        'GridBand79
        '
        Me.GridBand79.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand79.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand79.Caption = "Branch"
        Me.GridBand79.Columns.Add(Me.BandedGridColumn106)
        Me.GridBand79.Name = "GridBand79"
        Me.GridBand79.VisibleIndex = 0
        Me.GridBand79.Width = 200
        '
        'BandedGridColumn106
        '
        Me.BandedGridColumn106.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn106.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn106.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn106.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn106.FieldName = "Branch"
        Me.BandedGridColumn106.Name = "BandedGridColumn106"
        Me.BandedGridColumn106.Visible = True
        Me.BandedGridColumn106.Width = 200
        '
        'GridBand80
        '
        Me.GridBand80.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand80.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand80.Caption = "W. Dismissed with Prejudice"
        Me.GridBand80.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand81, Me.GridBand82})
        Me.GridBand80.Name = "GridBand80"
        Me.GridBand80.VisibleIndex = 1
        Me.GridBand80.Width = 400
        '
        'GridBand81
        '
        Me.GridBand81.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand81.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand81.Caption = "Amount"
        Me.GridBand81.Columns.Add(Me.BandedGridColumn107)
        Me.GridBand81.Columns.Add(Me.BandedGridColumn108)
        Me.GridBand81.Name = "GridBand81"
        Me.GridBand81.VisibleIndex = 0
        Me.GridBand81.Width = 200
        '
        'BandedGridColumn107
        '
        Me.BandedGridColumn107.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn107.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn107.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn107.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn107.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn107.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn107.Caption = "Amount"
        Me.BandedGridColumn107.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn107.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn107.FieldName = "W_A1"
        Me.BandedGridColumn107.Name = "BandedGridColumn107"
        Me.BandedGridColumn107.Visible = True
        Me.BandedGridColumn107.Width = 100
        '
        'BandedGridColumn108
        '
        Me.BandedGridColumn108.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn108.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn108.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn108.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn108.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn108.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn108.Caption = "Percent"
        Me.BandedGridColumn108.FieldName = "W_P1"
        Me.BandedGridColumn108.Name = "BandedGridColumn108"
        Me.BandedGridColumn108.Visible = True
        Me.BandedGridColumn108.Width = 100
        '
        'GridBand82
        '
        Me.GridBand82.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand82.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand82.Caption = "Account"
        Me.GridBand82.Columns.Add(Me.BandedGridColumn109)
        Me.GridBand82.Columns.Add(Me.BandedGridColumn110)
        Me.GridBand82.Name = "GridBand82"
        Me.GridBand82.VisibleIndex = 1
        Me.GridBand82.Width = 200
        '
        'BandedGridColumn109
        '
        Me.BandedGridColumn109.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn109.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn109.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn109.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn109.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn109.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn109.Caption = "Account"
        Me.BandedGridColumn109.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn109.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn109.FieldName = "W_A2"
        Me.BandedGridColumn109.Name = "BandedGridColumn109"
        Me.BandedGridColumn109.Visible = True
        Me.BandedGridColumn109.Width = 100
        '
        'BandedGridColumn110
        '
        Me.BandedGridColumn110.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn110.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn110.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn110.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn110.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn110.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn110.Caption = "Percent"
        Me.BandedGridColumn110.FieldName = "W_P2"
        Me.BandedGridColumn110.Name = "BandedGridColumn110"
        Me.BandedGridColumn110.Visible = True
        Me.BandedGridColumn110.Width = 100
        '
        'GridBand83
        '
        Me.GridBand83.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand83.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand83.Caption = "X. Dismissed without Prejudice"
        Me.GridBand83.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand84, Me.GridBand85})
        Me.GridBand83.Name = "GridBand83"
        Me.GridBand83.VisibleIndex = 2
        Me.GridBand83.Width = 400
        '
        'GridBand84
        '
        Me.GridBand84.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand84.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand84.Caption = "Amount"
        Me.GridBand84.Columns.Add(Me.BandedGridColumn111)
        Me.GridBand84.Columns.Add(Me.BandedGridColumn112)
        Me.GridBand84.Name = "GridBand84"
        Me.GridBand84.VisibleIndex = 0
        Me.GridBand84.Width = 200
        '
        'BandedGridColumn111
        '
        Me.BandedGridColumn111.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn111.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn111.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn111.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn111.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn111.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn111.Caption = "Amount"
        Me.BandedGridColumn111.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn111.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn111.FieldName = "X_A1"
        Me.BandedGridColumn111.Name = "BandedGridColumn111"
        Me.BandedGridColumn111.Visible = True
        Me.BandedGridColumn111.Width = 100
        '
        'BandedGridColumn112
        '
        Me.BandedGridColumn112.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn112.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn112.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn112.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn112.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn112.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn112.Caption = "Percent"
        Me.BandedGridColumn112.FieldName = "X_P1"
        Me.BandedGridColumn112.Name = "BandedGridColumn112"
        Me.BandedGridColumn112.Visible = True
        Me.BandedGridColumn112.Width = 100
        '
        'GridBand85
        '
        Me.GridBand85.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand85.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand85.Caption = "Account"
        Me.GridBand85.Columns.Add(Me.BandedGridColumn113)
        Me.GridBand85.Columns.Add(Me.BandedGridColumn114)
        Me.GridBand85.Name = "GridBand85"
        Me.GridBand85.VisibleIndex = 1
        Me.GridBand85.Width = 200
        '
        'BandedGridColumn113
        '
        Me.BandedGridColumn113.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn113.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn113.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn113.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn113.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn113.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn113.Caption = "Account"
        Me.BandedGridColumn113.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn113.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn113.FieldName = "X_A2"
        Me.BandedGridColumn113.Name = "BandedGridColumn113"
        Me.BandedGridColumn113.Visible = True
        Me.BandedGridColumn113.Width = 100
        '
        'BandedGridColumn114
        '
        Me.BandedGridColumn114.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn114.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn114.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn114.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn114.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn114.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn114.Caption = "Percent"
        Me.BandedGridColumn114.FieldName = "X_P2"
        Me.BandedGridColumn114.Name = "BandedGridColumn114"
        Me.BandedGridColumn114.Visible = True
        Me.BandedGridColumn114.Width = 100
        '
        'GridBand86
        '
        Me.GridBand86.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand86.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand86.Caption = "Y. For Refiling"
        Me.GridBand86.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand87, Me.GridBand88})
        Me.GridBand86.Name = "GridBand86"
        Me.GridBand86.VisibleIndex = 3
        Me.GridBand86.Width = 400
        '
        'GridBand87
        '
        Me.GridBand87.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand87.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand87.Caption = "Amount"
        Me.GridBand87.Columns.Add(Me.BandedGridColumn115)
        Me.GridBand87.Columns.Add(Me.BandedGridColumn116)
        Me.GridBand87.Name = "GridBand87"
        Me.GridBand87.VisibleIndex = 0
        Me.GridBand87.Width = 200
        '
        'BandedGridColumn115
        '
        Me.BandedGridColumn115.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn115.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn115.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn115.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn115.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn115.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn115.Caption = "Amount"
        Me.BandedGridColumn115.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn115.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn115.FieldName = "Y_A1"
        Me.BandedGridColumn115.Name = "BandedGridColumn115"
        Me.BandedGridColumn115.Visible = True
        Me.BandedGridColumn115.Width = 100
        '
        'BandedGridColumn116
        '
        Me.BandedGridColumn116.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn116.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn116.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn116.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn116.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn116.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn116.Caption = "Percent"
        Me.BandedGridColumn116.FieldName = "Y_P1"
        Me.BandedGridColumn116.Name = "BandedGridColumn116"
        Me.BandedGridColumn116.Visible = True
        Me.BandedGridColumn116.Width = 100
        '
        'GridBand88
        '
        Me.GridBand88.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand88.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand88.Caption = "Account"
        Me.GridBand88.Columns.Add(Me.BandedGridColumn117)
        Me.GridBand88.Columns.Add(Me.BandedGridColumn118)
        Me.GridBand88.Name = "GridBand88"
        Me.GridBand88.VisibleIndex = 1
        Me.GridBand88.Width = 200
        '
        'BandedGridColumn117
        '
        Me.BandedGridColumn117.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn117.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn117.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn117.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn117.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn117.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn117.Caption = "Account"
        Me.BandedGridColumn117.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn117.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn117.FieldName = "Y_A2"
        Me.BandedGridColumn117.Name = "BandedGridColumn117"
        Me.BandedGridColumn117.Visible = True
        Me.BandedGridColumn117.Width = 100
        '
        'BandedGridColumn118
        '
        Me.BandedGridColumn118.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn118.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn118.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn118.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn118.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn118.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn118.Caption = "Percent"
        Me.BandedGridColumn118.FieldName = "Y_P2"
        Me.BandedGridColumn118.Name = "BandedGridColumn118"
        Me.BandedGridColumn118.Visible = True
        Me.BandedGridColumn118.Width = 100
        '
        'GridBand89
        '
        Me.GridBand89.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand89.AppearanceHeader.Options.UseFont = True
        Me.GridBand89.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand89.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand89.Caption = "T O T A L"
        Me.GridBand89.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand90, Me.GridBand91})
        Me.GridBand89.Name = "GridBand89"
        Me.GridBand89.VisibleIndex = 4
        Me.GridBand89.Width = 400
        '
        'GridBand90
        '
        Me.GridBand90.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand90.AppearanceHeader.Options.UseFont = True
        Me.GridBand90.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand90.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand90.Caption = "Amount"
        Me.GridBand90.Columns.Add(Me.BandedGridColumn119)
        Me.GridBand90.Columns.Add(Me.BandedGridColumn120)
        Me.GridBand90.Name = "GridBand90"
        Me.GridBand90.VisibleIndex = 0
        Me.GridBand90.Width = 200
        '
        'BandedGridColumn119
        '
        Me.BandedGridColumn119.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn119.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn119.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn119.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn119.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn119.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn119.Caption = "Amount"
        Me.BandedGridColumn119.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn119.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn119.FieldName = "T_A1"
        Me.BandedGridColumn119.Name = "BandedGridColumn119"
        Me.BandedGridColumn119.Visible = True
        Me.BandedGridColumn119.Width = 100
        '
        'BandedGridColumn120
        '
        Me.BandedGridColumn120.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn120.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn120.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn120.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn120.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn120.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn120.Caption = "Percent"
        Me.BandedGridColumn120.FieldName = "T_P1"
        Me.BandedGridColumn120.Name = "BandedGridColumn120"
        Me.BandedGridColumn120.Visible = True
        Me.BandedGridColumn120.Width = 100
        '
        'GridBand91
        '
        Me.GridBand91.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand91.AppearanceHeader.Options.UseFont = True
        Me.GridBand91.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand91.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand91.Caption = "Account"
        Me.GridBand91.Columns.Add(Me.BandedGridColumn121)
        Me.GridBand91.Columns.Add(Me.BandedGridColumn122)
        Me.GridBand91.Name = "GridBand91"
        Me.GridBand91.VisibleIndex = 1
        Me.GridBand91.Width = 200
        '
        'BandedGridColumn121
        '
        Me.BandedGridColumn121.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn121.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn121.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn121.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn121.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn121.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn121.Caption = "Account"
        Me.BandedGridColumn121.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn121.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn121.FieldName = "T_A2"
        Me.BandedGridColumn121.Name = "BandedGridColumn121"
        Me.BandedGridColumn121.Visible = True
        Me.BandedGridColumn121.Width = 100
        '
        'BandedGridColumn122
        '
        Me.BandedGridColumn122.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn122.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn122.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn122.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn122.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn122.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn122.Caption = "Percent"
        Me.BandedGridColumn122.FieldName = "T_P2"
        Me.BandedGridColumn122.Name = "BandedGridColumn122"
        Me.BandedGridColumn122.Visible = True
        Me.BandedGridColumn122.Width = 100
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
        'tabDismissed
        '
        Me.tabDismissed.AttachedControl = Me.SuperTabControlPanel5
        Me.tabDismissed.GlobalItem = False
        Me.tabDismissed.Name = "tabDismissed"
        Me.tabDismissed.Text = "Dismissed"
        Me.tabDismissed.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.GridControl3)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1167, 569)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.tabExecuted
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl3.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl3.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl3.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl3.MainView = Me.BandedGridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3})
        Me.GridControl3.Size = New System.Drawing.Size(1167, 569)
        Me.GridControl3.TabIndex = 1679
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView3})
        '
        'BandedGridView3
        '
        Me.BandedGridView3.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView3.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView3.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView3.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView3.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView3.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView3.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView3.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView3.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView3.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView3.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView3.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView3.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView3.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView3.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView3.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView3.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView3.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView3.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView3.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView3.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.Row.Options.UseFont = True
        Me.BandedGridView3.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView3.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView3.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView3.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView3.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView3.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView3.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView3.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand60, Me.GridBand61, Me.GridBand64, Me.GridBand67, Me.GridBand70, Me.GridBand73, Me.GridBand76})
        Me.BandedGridView3.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn82, Me.BandedGridColumn83, Me.BandedGridColumn84, Me.BandedGridColumn85, Me.BandedGridColumn86, Me.BandedGridColumn87, Me.BandedGridColumn88, Me.BandedGridColumn89, Me.BandedGridColumn90, Me.BandedGridColumn91, Me.BandedGridColumn92, Me.BandedGridColumn93, Me.BandedGridColumn94, Me.BandedGridColumn95, Me.BandedGridColumn96, Me.BandedGridColumn97, Me.BandedGridColumn98, Me.BandedGridColumn99, Me.BandedGridColumn100, Me.BandedGridColumn101, Me.BandedGridColumn102, Me.BandedGridColumn103, Me.BandedGridColumn104, Me.BandedGridColumn105, Me.BandedGridColumn81})
        Me.BandedGridView3.CustomizationFormBounds = New System.Drawing.Rectangle(741, 493, 216, 235)
        Me.BandedGridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView3.GridControl = Me.GridControl3
        Me.BandedGridView3.GroupPanelText = "General Requirements"
        Me.BandedGridView3.Name = "BandedGridView3"
        Me.BandedGridView3.OptionsBehavior.Editable = False
        Me.BandedGridView3.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView3.OptionsLayout.StoreAppearance = True
        Me.BandedGridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView3.OptionsSelection.MultiSelect = True
        Me.BandedGridView3.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView3.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView3.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView3.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView3.OptionsView.ShowFooter = True
        Me.BandedGridView3.OptionsView.ShowGroupPanel = False
        '
        'GridBand60
        '
        Me.GridBand60.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand60.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand60.Caption = "Branch"
        Me.GridBand60.Columns.Add(Me.BandedGridColumn81)
        Me.GridBand60.Name = "GridBand60"
        Me.GridBand60.VisibleIndex = 0
        Me.GridBand60.Width = 200
        '
        'BandedGridColumn81
        '
        Me.BandedGridColumn81.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn81.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn81.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn81.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn81.FieldName = "Branch"
        Me.BandedGridColumn81.Name = "BandedGridColumn81"
        Me.BandedGridColumn81.Visible = True
        Me.BandedGridColumn81.Width = 200
        '
        'GridBand61
        '
        Me.GridBand61.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand61.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand61.Caption = "R. Scheduled for Execution" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.GridBand61.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand62, Me.GridBand63})
        Me.GridBand61.Name = "GridBand61"
        Me.GridBand61.VisibleIndex = 1
        Me.GridBand61.Width = 400
        '
        'GridBand62
        '
        Me.GridBand62.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand62.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand62.Caption = "Amount"
        Me.GridBand62.Columns.Add(Me.BandedGridColumn82)
        Me.GridBand62.Columns.Add(Me.BandedGridColumn83)
        Me.GridBand62.Name = "GridBand62"
        Me.GridBand62.VisibleIndex = 0
        Me.GridBand62.Width = 200
        '
        'BandedGridColumn82
        '
        Me.BandedGridColumn82.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn82.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn82.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn82.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn82.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn82.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn82.Caption = "Amount"
        Me.BandedGridColumn82.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn82.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn82.FieldName = "R_A1"
        Me.BandedGridColumn82.Name = "BandedGridColumn82"
        Me.BandedGridColumn82.Visible = True
        Me.BandedGridColumn82.Width = 100
        '
        'BandedGridColumn83
        '
        Me.BandedGridColumn83.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn83.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn83.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn83.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn83.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn83.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn83.Caption = "Percent"
        Me.BandedGridColumn83.FieldName = "R_P1"
        Me.BandedGridColumn83.Name = "BandedGridColumn83"
        Me.BandedGridColumn83.Visible = True
        Me.BandedGridColumn83.Width = 100
        '
        'GridBand63
        '
        Me.GridBand63.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand63.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand63.Caption = "Account"
        Me.GridBand63.Columns.Add(Me.BandedGridColumn84)
        Me.GridBand63.Columns.Add(Me.BandedGridColumn85)
        Me.GridBand63.Name = "GridBand63"
        Me.GridBand63.VisibleIndex = 1
        Me.GridBand63.Width = 200
        '
        'BandedGridColumn84
        '
        Me.BandedGridColumn84.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn84.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn84.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn84.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn84.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn84.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn84.Caption = "Account"
        Me.BandedGridColumn84.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn84.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn84.FieldName = "R_A2"
        Me.BandedGridColumn84.Name = "BandedGridColumn84"
        Me.BandedGridColumn84.Visible = True
        Me.BandedGridColumn84.Width = 100
        '
        'BandedGridColumn85
        '
        Me.BandedGridColumn85.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn85.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn85.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn85.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn85.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn85.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn85.Caption = "Percent"
        Me.BandedGridColumn85.FieldName = "R_P2"
        Me.BandedGridColumn85.Name = "BandedGridColumn85"
        Me.BandedGridColumn85.Visible = True
        Me.BandedGridColumn85.Width = 100
        '
        'GridBand64
        '
        Me.GridBand64.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand64.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand64.Caption = "S. For Follow Up"
        Me.GridBand64.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand65, Me.GridBand66})
        Me.GridBand64.Name = "GridBand64"
        Me.GridBand64.VisibleIndex = 2
        Me.GridBand64.Width = 400
        '
        'GridBand65
        '
        Me.GridBand65.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand65.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand65.Caption = "Amount"
        Me.GridBand65.Columns.Add(Me.BandedGridColumn86)
        Me.GridBand65.Columns.Add(Me.BandedGridColumn87)
        Me.GridBand65.Name = "GridBand65"
        Me.GridBand65.VisibleIndex = 0
        Me.GridBand65.Width = 200
        '
        'BandedGridColumn86
        '
        Me.BandedGridColumn86.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn86.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn86.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn86.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn86.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn86.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn86.Caption = "Amount"
        Me.BandedGridColumn86.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn86.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn86.FieldName = "S_A1"
        Me.BandedGridColumn86.Name = "BandedGridColumn86"
        Me.BandedGridColumn86.Visible = True
        Me.BandedGridColumn86.Width = 100
        '
        'BandedGridColumn87
        '
        Me.BandedGridColumn87.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn87.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn87.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn87.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn87.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn87.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn87.Caption = "Percent"
        Me.BandedGridColumn87.FieldName = "S_P1"
        Me.BandedGridColumn87.Name = "BandedGridColumn87"
        Me.BandedGridColumn87.Visible = True
        Me.BandedGridColumn87.Width = 100
        '
        'GridBand66
        '
        Me.GridBand66.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand66.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand66.Caption = "Account"
        Me.GridBand66.Columns.Add(Me.BandedGridColumn88)
        Me.GridBand66.Columns.Add(Me.BandedGridColumn89)
        Me.GridBand66.Name = "GridBand66"
        Me.GridBand66.VisibleIndex = 1
        Me.GridBand66.Width = 200
        '
        'BandedGridColumn88
        '
        Me.BandedGridColumn88.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn88.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn88.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn88.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn88.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn88.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn88.Caption = "Account"
        Me.BandedGridColumn88.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn88.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn88.FieldName = "S_A2"
        Me.BandedGridColumn88.Name = "BandedGridColumn88"
        Me.BandedGridColumn88.Visible = True
        Me.BandedGridColumn88.Width = 100
        '
        'BandedGridColumn89
        '
        Me.BandedGridColumn89.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn89.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn89.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn89.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn89.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn89.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn89.Caption = "Percent"
        Me.BandedGridColumn89.FieldName = "S_P2"
        Me.BandedGridColumn89.Name = "BandedGridColumn89"
        Me.BandedGridColumn89.Visible = True
        Me.BandedGridColumn89.Width = 100
        '
        'GridBand67
        '
        Me.GridBand67.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand67.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand67.Caption = "T. For Levy/Attachment of Real Property"
        Me.GridBand67.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand68, Me.GridBand69})
        Me.GridBand67.Name = "GridBand67"
        Me.GridBand67.VisibleIndex = 3
        Me.GridBand67.Width = 400
        '
        'GridBand68
        '
        Me.GridBand68.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand68.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand68.Caption = "Amount"
        Me.GridBand68.Columns.Add(Me.BandedGridColumn90)
        Me.GridBand68.Columns.Add(Me.BandedGridColumn91)
        Me.GridBand68.Name = "GridBand68"
        Me.GridBand68.VisibleIndex = 0
        Me.GridBand68.Width = 200
        '
        'BandedGridColumn90
        '
        Me.BandedGridColumn90.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn90.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn90.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn90.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn90.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn90.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn90.Caption = "Amount"
        Me.BandedGridColumn90.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn90.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn90.FieldName = "T_A1"
        Me.BandedGridColumn90.Name = "BandedGridColumn90"
        Me.BandedGridColumn90.Visible = True
        Me.BandedGridColumn90.Width = 100
        '
        'BandedGridColumn91
        '
        Me.BandedGridColumn91.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn91.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn91.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn91.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn91.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn91.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn91.Caption = "Percent"
        Me.BandedGridColumn91.FieldName = "T_P1"
        Me.BandedGridColumn91.Name = "BandedGridColumn91"
        Me.BandedGridColumn91.Visible = True
        Me.BandedGridColumn91.Width = 100
        '
        'GridBand69
        '
        Me.GridBand69.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand69.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand69.Caption = "Account"
        Me.GridBand69.Columns.Add(Me.BandedGridColumn92)
        Me.GridBand69.Columns.Add(Me.BandedGridColumn93)
        Me.GridBand69.Name = "GridBand69"
        Me.GridBand69.VisibleIndex = 1
        Me.GridBand69.Width = 200
        '
        'BandedGridColumn92
        '
        Me.BandedGridColumn92.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn92.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn92.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn92.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn92.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn92.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn92.Caption = "Account"
        Me.BandedGridColumn92.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn92.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn92.FieldName = "T_A2"
        Me.BandedGridColumn92.Name = "BandedGridColumn92"
        Me.BandedGridColumn92.Visible = True
        Me.BandedGridColumn92.Width = 100
        '
        'BandedGridColumn93
        '
        Me.BandedGridColumn93.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn93.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn93.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn93.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn93.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn93.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn93.Caption = "Percent"
        Me.BandedGridColumn93.FieldName = "T_P2"
        Me.BandedGridColumn93.Name = "BandedGridColumn93"
        Me.BandedGridColumn93.Visible = True
        Me.BandedGridColumn93.Width = 100
        '
        'GridBand70
        '
        Me.GridBand70.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand70.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand70.Caption = "U. For Garnishment"
        Me.GridBand70.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand71, Me.GridBand72})
        Me.GridBand70.Name = "GridBand70"
        Me.GridBand70.VisibleIndex = 4
        Me.GridBand70.Width = 400
        '
        'GridBand71
        '
        Me.GridBand71.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand71.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand71.Caption = "Amount"
        Me.GridBand71.Columns.Add(Me.BandedGridColumn94)
        Me.GridBand71.Columns.Add(Me.BandedGridColumn95)
        Me.GridBand71.Name = "GridBand71"
        Me.GridBand71.VisibleIndex = 0
        Me.GridBand71.Width = 200
        '
        'BandedGridColumn94
        '
        Me.BandedGridColumn94.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn94.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn94.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn94.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn94.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn94.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn94.Caption = "Amount"
        Me.BandedGridColumn94.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn94.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn94.FieldName = "U_A1"
        Me.BandedGridColumn94.Name = "BandedGridColumn94"
        Me.BandedGridColumn94.Visible = True
        Me.BandedGridColumn94.Width = 100
        '
        'BandedGridColumn95
        '
        Me.BandedGridColumn95.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn95.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn95.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn95.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn95.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn95.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn95.Caption = "Percent"
        Me.BandedGridColumn95.FieldName = "U_P1"
        Me.BandedGridColumn95.Name = "BandedGridColumn95"
        Me.BandedGridColumn95.Visible = True
        Me.BandedGridColumn95.Width = 100
        '
        'GridBand72
        '
        Me.GridBand72.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand72.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand72.Caption = "Account"
        Me.GridBand72.Columns.Add(Me.BandedGridColumn96)
        Me.GridBand72.Columns.Add(Me.BandedGridColumn97)
        Me.GridBand72.Name = "GridBand72"
        Me.GridBand72.VisibleIndex = 1
        Me.GridBand72.Width = 200
        '
        'BandedGridColumn96
        '
        Me.BandedGridColumn96.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn96.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn96.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn96.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn96.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn96.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn96.Caption = "Account"
        Me.BandedGridColumn96.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn96.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn96.FieldName = "U_A2"
        Me.BandedGridColumn96.Name = "BandedGridColumn96"
        Me.BandedGridColumn96.Visible = True
        Me.BandedGridColumn96.Width = 100
        '
        'BandedGridColumn97
        '
        Me.BandedGridColumn97.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn97.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn97.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn97.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn97.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn97.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn97.Caption = "Percent"
        Me.BandedGridColumn97.FieldName = "U_P2"
        Me.BandedGridColumn97.Name = "BandedGridColumn97"
        Me.BandedGridColumn97.Visible = True
        Me.BandedGridColumn97.Width = 100
        '
        'GridBand73
        '
        Me.GridBand73.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand73.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand73.Caption = "V. For Recovery of Personal Property"
        Me.GridBand73.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand74, Me.GridBand75})
        Me.GridBand73.Name = "GridBand73"
        Me.GridBand73.VisibleIndex = 5
        Me.GridBand73.Width = 400
        '
        'GridBand74
        '
        Me.GridBand74.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand74.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand74.Caption = "Amount"
        Me.GridBand74.Columns.Add(Me.BandedGridColumn98)
        Me.GridBand74.Columns.Add(Me.BandedGridColumn99)
        Me.GridBand74.Name = "GridBand74"
        Me.GridBand74.VisibleIndex = 0
        Me.GridBand74.Width = 200
        '
        'BandedGridColumn98
        '
        Me.BandedGridColumn98.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn98.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn98.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn98.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn98.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn98.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn98.Caption = "Amount"
        Me.BandedGridColumn98.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn98.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn98.FieldName = "V_A1"
        Me.BandedGridColumn98.Name = "BandedGridColumn98"
        Me.BandedGridColumn98.Visible = True
        Me.BandedGridColumn98.Width = 100
        '
        'BandedGridColumn99
        '
        Me.BandedGridColumn99.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn99.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn99.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn99.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn99.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn99.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn99.Caption = "Percent"
        Me.BandedGridColumn99.FieldName = "V_P1"
        Me.BandedGridColumn99.Name = "BandedGridColumn99"
        Me.BandedGridColumn99.Visible = True
        Me.BandedGridColumn99.Width = 100
        '
        'GridBand75
        '
        Me.GridBand75.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand75.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand75.Caption = "Account"
        Me.GridBand75.Columns.Add(Me.BandedGridColumn100)
        Me.GridBand75.Columns.Add(Me.BandedGridColumn101)
        Me.GridBand75.Name = "GridBand75"
        Me.GridBand75.VisibleIndex = 1
        Me.GridBand75.Width = 200
        '
        'BandedGridColumn100
        '
        Me.BandedGridColumn100.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn100.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn100.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn100.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn100.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn100.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn100.Caption = "Account"
        Me.BandedGridColumn100.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn100.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn100.FieldName = "V_A2"
        Me.BandedGridColumn100.Name = "BandedGridColumn100"
        Me.BandedGridColumn100.Visible = True
        Me.BandedGridColumn100.Width = 100
        '
        'BandedGridColumn101
        '
        Me.BandedGridColumn101.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn101.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn101.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn101.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn101.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn101.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn101.Caption = "Percent"
        Me.BandedGridColumn101.FieldName = "V_P2"
        Me.BandedGridColumn101.Name = "BandedGridColumn101"
        Me.BandedGridColumn101.Visible = True
        Me.BandedGridColumn101.Width = 100
        '
        'GridBand76
        '
        Me.GridBand76.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand76.AppearanceHeader.Options.UseFont = True
        Me.GridBand76.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand76.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand76.Caption = "T O T A L"
        Me.GridBand76.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand77, Me.GridBand78})
        Me.GridBand76.Name = "GridBand76"
        Me.GridBand76.VisibleIndex = 6
        Me.GridBand76.Width = 400
        '
        'GridBand77
        '
        Me.GridBand77.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand77.AppearanceHeader.Options.UseFont = True
        Me.GridBand77.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand77.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand77.Caption = "Amount"
        Me.GridBand77.Columns.Add(Me.BandedGridColumn102)
        Me.GridBand77.Columns.Add(Me.BandedGridColumn103)
        Me.GridBand77.Name = "GridBand77"
        Me.GridBand77.VisibleIndex = 0
        Me.GridBand77.Width = 200
        '
        'BandedGridColumn102
        '
        Me.BandedGridColumn102.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn102.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn102.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn102.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn102.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn102.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn102.Caption = "Amount"
        Me.BandedGridColumn102.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn102.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn102.FieldName = "Total_A1"
        Me.BandedGridColumn102.Name = "BandedGridColumn102"
        Me.BandedGridColumn102.Visible = True
        Me.BandedGridColumn102.Width = 100
        '
        'BandedGridColumn103
        '
        Me.BandedGridColumn103.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn103.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn103.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn103.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn103.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn103.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn103.Caption = "Percent"
        Me.BandedGridColumn103.FieldName = "Total_P1"
        Me.BandedGridColumn103.Name = "BandedGridColumn103"
        Me.BandedGridColumn103.Visible = True
        Me.BandedGridColumn103.Width = 100
        '
        'GridBand78
        '
        Me.GridBand78.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand78.AppearanceHeader.Options.UseFont = True
        Me.GridBand78.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand78.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand78.Caption = "Account"
        Me.GridBand78.Columns.Add(Me.BandedGridColumn104)
        Me.GridBand78.Columns.Add(Me.BandedGridColumn105)
        Me.GridBand78.Name = "GridBand78"
        Me.GridBand78.VisibleIndex = 1
        Me.GridBand78.Width = 200
        '
        'BandedGridColumn104
        '
        Me.BandedGridColumn104.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn104.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn104.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn104.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn104.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn104.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn104.Caption = "Account"
        Me.BandedGridColumn104.DisplayFormat.FormatString = "n0"
        Me.BandedGridColumn104.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn104.FieldName = "Total_A2"
        Me.BandedGridColumn104.Name = "BandedGridColumn104"
        Me.BandedGridColumn104.Visible = True
        Me.BandedGridColumn104.Width = 100
        '
        'BandedGridColumn105
        '
        Me.BandedGridColumn105.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn105.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn105.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!)
        Me.BandedGridColumn105.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn105.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn105.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn105.Caption = "Percent"
        Me.BandedGridColumn105.FieldName = "Total_P2"
        Me.BandedGridColumn105.Name = "BandedGridColumn105"
        Me.BandedGridColumn105.Visible = True
        Me.BandedGridColumn105.Width = 100
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit3.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit3.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit3.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit3.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit3.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.ValueChecked = "True"
        Me.RepositoryItemCheckEdit3.ValueUnchecked = "False"
        '
        'tabExecuted
        '
        Me.tabExecuted.AttachedControl = Me.SuperTabControlPanel4
        Me.tabExecuted.GlobalItem = False
        Me.tabExecuted.Name = "tabExecuted"
        Me.tabExecuted.Text = "Executed"
        Me.tabExecuted.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Percent"
        Me.BandedGridColumn5.FieldName = "A_P2"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Percent"
        Me.BandedGridColumn6.FieldName = "A_P2"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        '
        'FrmCaseMonitoring
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
        Me.Name = "FrmCaseMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.PanelEx10.ResumeLayout(False)
        CType(Me.dtpAsOf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel7.ResumeLayout(False)
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel6.ResumeLayout(False)
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel5.ResumeLayout(False)
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanelEx10 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents tabSummary As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tabOngoing As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabDecided As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabExecuted As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabDismissed As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabArchived As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn39 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn19 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn20 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn21 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn22 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn23 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn25 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn26 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn27 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn28 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn29 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn30 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn31 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn32 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn33 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn34 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn35 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn36 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn37 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn38 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand29 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn40 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand30 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand31 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn41 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn42 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand32 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn43 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn44 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand33 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand34 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn45 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn46 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand35 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn47 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn48 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand36 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand37 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn49 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn50 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand38 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn51 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn52 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand39 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand40 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn53 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn54 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand41 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn55 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn56 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand42 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand43 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn57 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn58 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand44 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn59 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn60 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand45 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand46 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn61 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn62 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand47 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn63 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn64 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand48 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand49 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn65 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn66 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand50 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn67 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn68 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand51 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand52 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn69 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn70 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand53 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn71 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn72 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand57 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand58 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn77 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn78 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand59 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn79 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn80 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand54 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand55 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn73 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn74 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand56 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn75 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn76 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn81 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn82 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn83 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn84 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn85 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn86 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn87 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn88 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn89 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn90 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn91 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn92 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn93 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn94 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn95 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn96 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn97 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn98 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn99 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn100 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn101 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn102 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn103 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn104 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn105 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridBand60 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand61 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand62 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand63 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand64 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand65 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand66 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand67 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand68 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand69 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand70 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand71 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand72 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand73 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand74 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand75 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand76 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand77 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand78 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand79 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn106 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand80 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand81 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn107 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn108 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand82 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn109 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn110 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand83 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand84 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn111 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn112 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand85 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn113 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn114 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand86 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand87 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn115 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn116 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand88 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn117 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn118 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand89 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand90 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn119 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn120 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand91 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn121 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn122 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridControl5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand92 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn123 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand93 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand94 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn124 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn125 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand95 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn126 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn127 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridControl6 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand96 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn128 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand97 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand98 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn129 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn130 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand99 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn131 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn132 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tabWritteOff As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents lblCurrent As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_P As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_BV As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_BV As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_BV As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_BV As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_BV As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_BV As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_A As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_A As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX62 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX61 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX60 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX59 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX58 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX57 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX56 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX55 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX53 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_P_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_P_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_P_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_P_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_P_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_P_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_BV_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_BV_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_BV_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_BV_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_BV_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_BV_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_A_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_A_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_A_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_A_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_A_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_A_L2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX44 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX45 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblLM2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_P_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_P_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_P_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_P_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_P_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_P_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_BV_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_BV_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_BV_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_BV_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_BV_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_BV_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal_A_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArchieved_A_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDismissed_A_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblExecuted_A_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDecided_A_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblOnGoing_A_L1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblLM1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chart1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dtpAsOf As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gridBand28 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand12 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand13 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand14 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand15 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand16 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand17 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand18 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand19 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand20 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand21 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand22 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand23 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand24 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand25 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand26 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand27 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
