<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubRptReturned
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
        Me.lblORDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocumentNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJVDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJVNumber = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblORDate, Me.lblDocumentNo, Me.lblJVDate, Me.lblBorrower, Me.lblAmount, Me.lblJVNumber})
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
        'lblORDate
        '
        Me.lblORDate.BackColor = System.Drawing.Color.White
        Me.lblORDate.BorderColor = System.Drawing.Color.Black
        Me.lblORDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblORDate.CanGrow = False
        Me.lblORDate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORDate.ForeColor = System.Drawing.Color.Black
        Me.lblORDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
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
        'lblDocumentNo
        '
        Me.lblDocumentNo.BackColor = System.Drawing.Color.White
        Me.lblDocumentNo.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDocumentNo.CanGrow = False
        Me.lblDocumentNo.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNo.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentNo.LocationFloat = New DevExpress.Utils.PointFloat(80.0!, 0.0!)
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
        'lblJVDate
        '
        Me.lblJVDate.BackColor = System.Drawing.Color.White
        Me.lblJVDate.BorderColor = System.Drawing.Color.Black
        Me.lblJVDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJVDate.CanGrow = False
        Me.lblJVDate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJVDate.ForeColor = System.Drawing.Color.Black
        Me.lblJVDate.LocationFloat = New DevExpress.Utils.PointFloat(160.0!, 0.0!)
        Me.lblJVDate.Name = "lblJVDate"
        Me.lblJVDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJVDate.SizeF = New System.Drawing.SizeF(79.99988!, 15.0!)
        Me.lblJVDate.StylePriority.UseBackColor = False
        Me.lblJVDate.StylePriority.UseBorderColor = False
        Me.lblJVDate.StylePriority.UseBorders = False
        Me.lblJVDate.StylePriority.UseFont = False
        Me.lblJVDate.StylePriority.UseForeColor = False
        Me.lblJVDate.StylePriority.UseTextAlignment = False
        Me.lblJVDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(319.9998!, 0.0!)
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
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.Color.White
        Me.lblAmount.BorderColor = System.Drawing.Color.Black
        Me.lblAmount.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount.CanGrow = False
        Me.lblAmount.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Black
        Me.lblAmount.LocationFloat = New DevExpress.Utils.PointFloat(569.9999!, 0.0!)
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
        'lblJVNumber
        '
        Me.lblJVNumber.BackColor = System.Drawing.Color.White
        Me.lblJVNumber.BorderColor = System.Drawing.Color.Black
        Me.lblJVNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJVNumber.CanGrow = False
        Me.lblJVNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJVNumber.ForeColor = System.Drawing.Color.Black
        Me.lblJVNumber.LocationFloat = New DevExpress.Utils.PointFloat(239.9998!, 0.0!)
        Me.lblJVNumber.Name = "lblJVNumber"
        Me.lblJVNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJVNumber.SizeF = New System.Drawing.SizeF(80.0!, 15.0!)
        Me.lblJVNumber.StylePriority.UseBackColor = False
        Me.lblJVNumber.StylePriority.UseBorderColor = False
        Me.lblJVNumber.StylePriority.UseBorders = False
        Me.lblJVNumber.StylePriority.UseFont = False
        Me.lblJVNumber.StylePriority.UseForeColor = False
        Me.lblJVNumber.StylePriority.UseTextAlignment = False
        Me.lblJVNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'subRpt_Returned
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblORDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDocumentNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJVDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJVNumber As DevExpress.XtraReports.UI.XRLabel
End Class
