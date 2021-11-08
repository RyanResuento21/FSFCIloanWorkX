<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubRptDeposit
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
        Me.lblDateDeposited = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMOP = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocumentNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblORDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDateDeposited, Me.lblAmount, Me.lblBorrower, Me.lblMOP, Me.lblDocumentNo, Me.lblORDate})
        Me.Detail.HeightF = 15.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblDateDeposited
        '
        Me.lblDateDeposited.BackColor = System.Drawing.Color.White
        Me.lblDateDeposited.BorderColor = System.Drawing.Color.Black
        Me.lblDateDeposited.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDateDeposited.CanGrow = False
        Me.lblDateDeposited.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateDeposited.ForeColor = System.Drawing.Color.Black
        Me.lblDateDeposited.LocationFloat = New DevExpress.Utils.PointFloat(570.0!, 0.0!)
        Me.lblDateDeposited.Name = "lblDateDeposited"
        Me.lblDateDeposited.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateDeposited.SizeF = New System.Drawing.SizeF(80.0!, 15.0!)
        Me.lblDateDeposited.StylePriority.UseBackColor = False
        Me.lblDateDeposited.StylePriority.UseBorderColor = False
        Me.lblDateDeposited.StylePriority.UseBorders = False
        Me.lblDateDeposited.StylePriority.UseFont = False
        Me.lblDateDeposited.StylePriority.UseForeColor = False
        Me.lblDateDeposited.StylePriority.UseTextAlignment = False
        Me.lblDateDeposited.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.Color.White
        Me.lblAmount.BorderColor = System.Drawing.Color.Black
        Me.lblAmount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount.CanGrow = False
        Me.lblAmount.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Black
        Me.lblAmount.LocationFloat = New DevExpress.Utils.PointFloat(490.0!, 0.0!)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount.SizeF = New System.Drawing.SizeF(80.0!, 15.0!)
        Me.lblAmount.StylePriority.UseBackColor = False
        Me.lblAmount.StylePriority.UseBorderColor = False
        Me.lblAmount.StylePriority.UseBorders = False
        Me.lblAmount.StylePriority.UseFont = False
        Me.lblAmount.StylePriority.UseForeColor = False
        Me.lblAmount.StylePriority.UseTextAlignment = False
        Me.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(240.0!, 0.0!)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower.SizeF = New System.Drawing.SizeF(250.0!, 15.0!)
        Me.lblBorrower.StylePriority.UseBackColor = False
        Me.lblBorrower.StylePriority.UseBorderColor = False
        Me.lblBorrower.StylePriority.UseBorders = False
        Me.lblBorrower.StylePriority.UseFont = False
        Me.lblBorrower.StylePriority.UseForeColor = False
        Me.lblBorrower.StylePriority.UseTextAlignment = False
        Me.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblMOP
        '
        Me.lblMOP.BackColor = System.Drawing.Color.White
        Me.lblMOP.BorderColor = System.Drawing.Color.Black
        Me.lblMOP.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMOP.CanGrow = False
        Me.lblMOP.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOP.ForeColor = System.Drawing.Color.Black
        Me.lblMOP.LocationFloat = New DevExpress.Utils.PointFloat(160.0001!, 0.0!)
        Me.lblMOP.Name = "lblMOP"
        Me.lblMOP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMOP.SizeF = New System.Drawing.SizeF(79.99988!, 15.0!)
        Me.lblMOP.StylePriority.UseBackColor = False
        Me.lblMOP.StylePriority.UseBorderColor = False
        Me.lblMOP.StylePriority.UseBorders = False
        Me.lblMOP.StylePriority.UseFont = False
        Me.lblMOP.StylePriority.UseForeColor = False
        Me.lblMOP.StylePriority.UseTextAlignment = False
        Me.lblMOP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDocumentNo
        '
        Me.lblDocumentNo.BackColor = System.Drawing.Color.White
        Me.lblDocumentNo.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDocumentNo.CanGrow = False
        Me.lblDocumentNo.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNo.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentNo.LocationFloat = New DevExpress.Utils.PointFloat(80.00012!, 0.0!)
        Me.lblDocumentNo.Name = "lblDocumentNo"
        Me.lblDocumentNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDocumentNo.SizeF = New System.Drawing.SizeF(79.99988!, 15.0!)
        Me.lblDocumentNo.StylePriority.UseBackColor = False
        Me.lblDocumentNo.StylePriority.UseBorderColor = False
        Me.lblDocumentNo.StylePriority.UseBorders = False
        Me.lblDocumentNo.StylePriority.UseFont = False
        Me.lblDocumentNo.StylePriority.UseForeColor = False
        Me.lblDocumentNo.StylePriority.UseTextAlignment = False
        Me.lblDocumentNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblORDate
        '
        Me.lblORDate.BackColor = System.Drawing.Color.White
        Me.lblORDate.BorderColor = System.Drawing.Color.Black
        Me.lblORDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblORDate.CanGrow = False
        Me.lblORDate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORDate.ForeColor = System.Drawing.Color.Black
        Me.lblORDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0001220703!, 0.0!)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblORDate.SizeF = New System.Drawing.SizeF(79.99988!, 15.0!)
        Me.lblORDate.StylePriority.UseBackColor = False
        Me.lblORDate.StylePriority.UseBorderColor = False
        Me.lblORDate.StylePriority.UseBorders = False
        Me.lblORDate.StylePriority.UseFont = False
        Me.lblORDate.StylePriority.UseForeColor = False
        Me.lblORDate.StylePriority.UseTextAlignment = False
        Me.lblORDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'subRpt_Deposit
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblDateDeposited As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMOP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDocumentNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblORDate As DevExpress.XtraReports.UI.XRLabel
End Class
