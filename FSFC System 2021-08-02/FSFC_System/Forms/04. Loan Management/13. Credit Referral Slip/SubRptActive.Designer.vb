<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubRptActive
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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFaceAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOutstanding = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblGMA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateGranted = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMaturityDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRemarks = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblRemarks, Me.lblMaturityDate, Me.lblDateGranted, Me.lblGMA, Me.lblOutstanding, Me.lblFaceAmount, Me.lblPrincipal, Me.lblAccountNumber})
        Me.Detail.HeightF = 15.0!
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
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(125.0!, 15.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BackColor = System.Drawing.Color.White
        Me.lblPrincipal.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal.CanGrow = False
        Me.lblPrincipal.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblPrincipal.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(125.0006!, 0.0!)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal.SizeF = New System.Drawing.SizeF(84.99999!, 15.0!)
        Me.lblPrincipal.StylePriority.UseBackColor = False
        Me.lblPrincipal.StylePriority.UseBorderColor = False
        Me.lblPrincipal.StylePriority.UseBorders = False
        Me.lblPrincipal.StylePriority.UseFont = False
        Me.lblPrincipal.StylePriority.UseForeColor = False
        Me.lblPrincipal.StylePriority.UseTextAlignment = False
        Me.lblPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblFaceAmount
        '
        Me.lblFaceAmount.BackColor = System.Drawing.Color.White
        Me.lblFaceAmount.BorderColor = System.Drawing.Color.Black
        Me.lblFaceAmount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFaceAmount.CanGrow = False
        Me.lblFaceAmount.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblFaceAmount.ForeColor = System.Drawing.Color.Black
        Me.lblFaceAmount.LocationFloat = New DevExpress.Utils.PointFloat(210.0005!, 0.0!)
        Me.lblFaceAmount.Name = "lblFaceAmount"
        Me.lblFaceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFaceAmount.SizeF = New System.Drawing.SizeF(84.99999!, 15.0!)
        Me.lblFaceAmount.StylePriority.UseBackColor = False
        Me.lblFaceAmount.StylePriority.UseBorderColor = False
        Me.lblFaceAmount.StylePriority.UseBorders = False
        Me.lblFaceAmount.StylePriority.UseFont = False
        Me.lblFaceAmount.StylePriority.UseForeColor = False
        Me.lblFaceAmount.StylePriority.UseTextAlignment = False
        Me.lblFaceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblOutstanding
        '
        Me.lblOutstanding.BackColor = System.Drawing.Color.White
        Me.lblOutstanding.BorderColor = System.Drawing.Color.Black
        Me.lblOutstanding.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOutstanding.CanGrow = False
        Me.lblOutstanding.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblOutstanding.ForeColor = System.Drawing.Color.Black
        Me.lblOutstanding.LocationFloat = New DevExpress.Utils.PointFloat(295.0005!, 0.0!)
        Me.lblOutstanding.Name = "lblOutstanding"
        Me.lblOutstanding.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOutstanding.SizeF = New System.Drawing.SizeF(84.99999!, 15.0!)
        Me.lblOutstanding.StylePriority.UseBackColor = False
        Me.lblOutstanding.StylePriority.UseBorderColor = False
        Me.lblOutstanding.StylePriority.UseBorders = False
        Me.lblOutstanding.StylePriority.UseFont = False
        Me.lblOutstanding.StylePriority.UseForeColor = False
        Me.lblOutstanding.StylePriority.UseTextAlignment = False
        Me.lblOutstanding.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblGMA
        '
        Me.lblGMA.BackColor = System.Drawing.Color.White
        Me.lblGMA.BorderColor = System.Drawing.Color.Black
        Me.lblGMA.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblGMA.CanGrow = False
        Me.lblGMA.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblGMA.ForeColor = System.Drawing.Color.Black
        Me.lblGMA.LocationFloat = New DevExpress.Utils.PointFloat(380.0005!, 0.0!)
        Me.lblGMA.Name = "lblGMA"
        Me.lblGMA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGMA.SizeF = New System.Drawing.SizeF(84.99999!, 15.0!)
        Me.lblGMA.StylePriority.UseBackColor = False
        Me.lblGMA.StylePriority.UseBorderColor = False
        Me.lblGMA.StylePriority.UseBorders = False
        Me.lblGMA.StylePriority.UseFont = False
        Me.lblGMA.StylePriority.UseForeColor = False
        Me.lblGMA.StylePriority.UseTextAlignment = False
        Me.lblGMA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDateGranted
        '
        Me.lblDateGranted.BackColor = System.Drawing.Color.White
        Me.lblDateGranted.BorderColor = System.Drawing.Color.Black
        Me.lblDateGranted.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDateGranted.CanGrow = False
        Me.lblDateGranted.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblDateGranted.ForeColor = System.Drawing.Color.Black
        Me.lblDateGranted.LocationFloat = New DevExpress.Utils.PointFloat(465.0005!, 0.0!)
        Me.lblDateGranted.Name = "lblDateGranted"
        Me.lblDateGranted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateGranted.SizeF = New System.Drawing.SizeF(89.99948!, 15.0!)
        Me.lblDateGranted.StylePriority.UseBackColor = False
        Me.lblDateGranted.StylePriority.UseBorderColor = False
        Me.lblDateGranted.StylePriority.UseBorders = False
        Me.lblDateGranted.StylePriority.UseFont = False
        Me.lblDateGranted.StylePriority.UseForeColor = False
        Me.lblDateGranted.StylePriority.UseTextAlignment = False
        Me.lblDateGranted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMaturityDate
        '
        Me.lblMaturityDate.BackColor = System.Drawing.Color.White
        Me.lblMaturityDate.BorderColor = System.Drawing.Color.Black
        Me.lblMaturityDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMaturityDate.CanGrow = False
        Me.lblMaturityDate.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblMaturityDate.ForeColor = System.Drawing.Color.Black
        Me.lblMaturityDate.LocationFloat = New DevExpress.Utils.PointFloat(555.0!, 0.0!)
        Me.lblMaturityDate.Name = "lblMaturityDate"
        Me.lblMaturityDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMaturityDate.SizeF = New System.Drawing.SizeF(90.00006!, 15.0!)
        Me.lblMaturityDate.StylePriority.UseBackColor = False
        Me.lblMaturityDate.StylePriority.UseBorderColor = False
        Me.lblMaturityDate.StylePriority.UseBorders = False
        Me.lblMaturityDate.StylePriority.UseFont = False
        Me.lblMaturityDate.StylePriority.UseForeColor = False
        Me.lblMaturityDate.StylePriority.UseTextAlignment = False
        Me.lblMaturityDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.White
        Me.lblRemarks.BorderColor = System.Drawing.Color.Black
        Me.lblRemarks.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRemarks.CanGrow = False
        Me.lblRemarks.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.LocationFloat = New DevExpress.Utils.PointFloat(645.0001!, 0.0!)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarks.SizeF = New System.Drawing.SizeF(154.9999!, 15.0!)
        Me.lblRemarks.StylePriority.UseBackColor = False
        Me.lblRemarks.StylePriority.UseBorderColor = False
        Me.lblRemarks.StylePriority.UseBorders = False
        Me.lblRemarks.StylePriority.UseFont = False
        Me.lblRemarks.StylePriority.UseForeColor = False
        Me.lblRemarks.StylePriority.UseTextAlignment = False
        Me.lblRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'subRpt_Active
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
    Friend WithEvents lblRemarks As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMaturityDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateGranted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblGMA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOutstanding As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFaceAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
End Class
