<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptAgingMerged
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.subRptTopSheet = New DevExpress.XtraReports.UI.XRSubreport()
        Me.subRptTopSheetProcedure = New DevExpress.XtraReports.UI.XRSubreport()
        Me.subRptAging = New DevExpress.XtraReports.UI.XRSubreport()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.subRptAging, Me.subRptTopSheetProcedure, Me.subRptTopSheet})
        Me.Detail.HeightF = 750.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 25.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 25.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'subRptTopSheet
        '
        Me.subRptTopSheet.CanShrink = True
        Me.subRptTopSheet.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.subRptTopSheet.Name = "subRptTopSheet"
        Me.subRptTopSheet.SizeF = New System.Drawing.SizeF(800.0!, 200.0!)
        '
        'subRptTopSheetProcedure
        '
        Me.subRptTopSheetProcedure.CanShrink = True
        Me.subRptTopSheetProcedure.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 200.0!)
        Me.subRptTopSheetProcedure.Name = "subRptTopSheetProcedure"
        Me.subRptTopSheetProcedure.SizeF = New System.Drawing.SizeF(800.0!, 200.0!)
        '
        'subRptAging
        '
        Me.subRptAging.CanShrink = True
        Me.subRptAging.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 400.0!)
        Me.subRptAging.Name = "subRptAging"
        Me.subRptAging.SizeF = New System.Drawing.SizeF(800.0!, 200.0!)
        '
        'rptAgingMerged
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents subRptAging As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents subRptTopSheetProcedure As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents subRptTopSheet As DevExpress.XtraReports.UI.XRSubreport
End Class
