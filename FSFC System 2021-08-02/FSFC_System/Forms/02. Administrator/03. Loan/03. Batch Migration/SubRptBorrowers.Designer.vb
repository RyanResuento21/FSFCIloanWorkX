<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class SubRptBorrowers
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
        Me.lblBorrowerName = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrowerID = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblBorrowerName, Me.lblBorrowerID})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblBorrowerName
        '
        Me.lblBorrowerName.BackColor = System.Drawing.Color.White
        Me.lblBorrowerName.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerName.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrowerName.CanGrow = False
        Me.lblBorrowerName.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerName.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerName.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 0.0!)
        Me.lblBorrowerName.Name = "lblBorrowerName"
        Me.lblBorrowerName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerName.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
        Me.lblBorrowerName.StylePriority.UseBackColor = False
        Me.lblBorrowerName.StylePriority.UseBorderColor = False
        Me.lblBorrowerName.StylePriority.UseBorders = False
        Me.lblBorrowerName.StylePriority.UseFont = False
        Me.lblBorrowerName.StylePriority.UseForeColor = False
        Me.lblBorrowerName.StylePriority.UseTextAlignment = False
        Me.lblBorrowerName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBorrowerID
        '
        Me.lblBorrowerID.BackColor = System.Drawing.Color.White
        Me.lblBorrowerID.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerID.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrowerID.CanGrow = False
        Me.lblBorrowerID.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerID.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerID.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblBorrowerID.Name = "lblBorrowerID"
        Me.lblBorrowerID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerID.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblBorrowerID.StylePriority.UseBackColor = False
        Me.lblBorrowerID.StylePriority.UseBorderColor = False
        Me.lblBorrowerID.StylePriority.UseBorders = False
        Me.lblBorrowerID.StylePriority.UseFont = False
        Me.lblBorrowerID.StylePriority.UseForeColor = False
        Me.lblBorrowerID.StylePriority.UseTextAlignment = False
        Me.lblBorrowerID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'subRptBorrowers
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblBorrowerName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrowerID As DevExpress.XtraReports.UI.XRLabel
End Class
