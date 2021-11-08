<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubRptSOA
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblArrears = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalty = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonths = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDays = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblArrears, Me.lblPenalty, Me.lblMonths, Me.lblDays})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblArrears
        '
        Me.lblArrears.BackColor = System.Drawing.Color.White
        Me.lblArrears.BorderColor = System.Drawing.Color.Black
        Me.lblArrears.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblArrears.CanGrow = False
        Me.lblArrears.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArrears.ForeColor = System.Drawing.Color.Black
        Me.lblArrears.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 0.0!)
        Me.lblArrears.Name = "lblArrears"
        Me.lblArrears.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblArrears.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblArrears.StylePriority.UseBackColor = False
        Me.lblArrears.StylePriority.UseBorderColor = False
        Me.lblArrears.StylePriority.UseBorders = False
        Me.lblArrears.StylePriority.UseFont = False
        Me.lblArrears.StylePriority.UseForeColor = False
        Me.lblArrears.StylePriority.UseTextAlignment = False
        Me.lblArrears.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblArrears.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenalty
        '
        Me.lblPenalty.BackColor = System.Drawing.Color.White
        Me.lblPenalty.BorderColor = System.Drawing.Color.Black
        Me.lblPenalty.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalty.CanGrow = False
        Me.lblPenalty.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalty.ForeColor = System.Drawing.Color.Black
        Me.lblPenalty.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 0.0!)
        Me.lblPenalty.Name = "lblPenalty"
        Me.lblPenalty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalty.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblPenalty.StylePriority.UseBackColor = False
        Me.lblPenalty.StylePriority.UseBorderColor = False
        Me.lblPenalty.StylePriority.UseBorders = False
        Me.lblPenalty.StylePriority.UseFont = False
        Me.lblPenalty.StylePriority.UseForeColor = False
        Me.lblPenalty.StylePriority.UseTextAlignment = False
        Me.lblPenalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalty.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMonths
        '
        Me.lblMonths.BackColor = System.Drawing.Color.White
        Me.lblMonths.BorderColor = System.Drawing.Color.Black
        Me.lblMonths.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMonths.CanGrow = False
        Me.lblMonths.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonths.ForeColor = System.Drawing.Color.Black
        Me.lblMonths.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblMonths.Name = "lblMonths"
        Me.lblMonths.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonths.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblMonths.StylePriority.UseBackColor = False
        Me.lblMonths.StylePriority.UseBorderColor = False
        Me.lblMonths.StylePriority.UseBorders = False
        Me.lblMonths.StylePriority.UseFont = False
        Me.lblMonths.StylePriority.UseForeColor = False
        Me.lblMonths.StylePriority.UseTextAlignment = False
        Me.lblMonths.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDays
        '
        Me.lblDays.BackColor = System.Drawing.Color.White
        Me.lblDays.BorderColor = System.Drawing.Color.Black
        Me.lblDays.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDays.CanGrow = False
        Me.lblDays.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDays.ForeColor = System.Drawing.Color.Black
        Me.lblDays.LocationFloat = New DevExpress.Utils.PointFloat(150.0!, 0.0!)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDays.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblDays.StylePriority.UseBackColor = False
        Me.lblDays.StylePriority.UseBorderColor = False
        Me.lblDays.StylePriority.UseBorders = False
        Me.lblDays.StylePriority.UseFont = False
        Me.lblDays.StylePriority.UseForeColor = False
        Me.lblDays.StylePriority.UseTextAlignment = False
        Me.lblDays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'rptSubSOA
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblArrears As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalty As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonths As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDays As DevExpress.XtraReports.UI.XRLabel
End Class
