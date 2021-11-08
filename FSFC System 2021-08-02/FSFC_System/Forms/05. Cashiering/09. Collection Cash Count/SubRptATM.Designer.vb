<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubRptATM
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
        Me.lblAccountName = New DevExpress.XtraReports.UI.XRLabel()
        Me.cbxOnHand = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.lblBank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRemarks = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAccountName, Me.cbxOnHand, Me.lblBank, Me.lblRemarks})
        Me.Detail.HeightF = 15.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAccountName
        '
        Me.lblAccountName.BackColor = System.Drawing.Color.White
        Me.lblAccountName.BorderColor = System.Drawing.Color.Black
        Me.lblAccountName.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountName.CanGrow = False
        Me.lblAccountName.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountName.ForeColor = System.Drawing.Color.Black
        Me.lblAccountName.LocationFloat = New DevExpress.Utils.PointFloat(20.0!, 0.0!)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountName.SizeF = New System.Drawing.SizeF(90.0!, 15.0!)
        Me.lblAccountName.StylePriority.UseBackColor = False
        Me.lblAccountName.StylePriority.UseBorderColor = False
        Me.lblAccountName.StylePriority.UseBorders = False
        Me.lblAccountName.StylePriority.UseFont = False
        Me.lblAccountName.StylePriority.UseForeColor = False
        Me.lblAccountName.StylePriority.UseTextAlignment = False
        Me.lblAccountName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxOnHand
        '
        Me.cbxOnHand.BackColor = System.Drawing.Color.White
        Me.cbxOnHand.BorderColor = System.Drawing.Color.Black
        Me.cbxOnHand.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxOnHand.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxOnHand.ForeColor = System.Drawing.Color.Black
        Me.cbxOnHand.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxOnHand.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.cbxOnHand.Name = "cbxOnHand"
        Me.cbxOnHand.SizeF = New System.Drawing.SizeF(20.0!, 15.0!)
        Me.cbxOnHand.StylePriority.UseBackColor = False
        Me.cbxOnHand.StylePriority.UseBorderColor = False
        Me.cbxOnHand.StylePriority.UseBorders = False
        Me.cbxOnHand.StylePriority.UseFont = False
        Me.cbxOnHand.StylePriority.UseForeColor = False
        Me.cbxOnHand.StylePriority.UseTextAlignment = False
        Me.cbxOnHand.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBank
        '
        Me.lblBank.BackColor = System.Drawing.Color.White
        Me.lblBank.BorderColor = System.Drawing.Color.Black
        Me.lblBank.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBank.CanGrow = False
        Me.lblBank.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBank.ForeColor = System.Drawing.Color.Black
        Me.lblBank.LocationFloat = New DevExpress.Utils.PointFloat(110.0!, 0.0!)
        Me.lblBank.Name = "lblBank"
        Me.lblBank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBank.SizeF = New System.Drawing.SizeF(150.0!, 15.0!)
        Me.lblBank.StylePriority.UseBackColor = False
        Me.lblBank.StylePriority.UseBorderColor = False
        Me.lblBank.StylePriority.UseBorders = False
        Me.lblBank.StylePriority.UseFont = False
        Me.lblBank.StylePriority.UseForeColor = False
        Me.lblBank.StylePriority.UseTextAlignment = False
        Me.lblBank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.White
        Me.lblRemarks.BorderColor = System.Drawing.Color.Black
        Me.lblRemarks.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRemarks.CanGrow = False
        Me.lblRemarks.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 0.0!)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarks.SizeF = New System.Drawing.SizeF(130.0!, 15.0!)
        Me.lblRemarks.StylePriority.UseBackColor = False
        Me.lblRemarks.StylePriority.UseBorderColor = False
        Me.lblRemarks.StylePriority.UseBorders = False
        Me.lblRemarks.StylePriority.UseFont = False
        Me.lblRemarks.StylePriority.UseForeColor = False
        Me.lblRemarks.StylePriority.UseTextAlignment = False
        Me.lblRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'subRpt_ATM
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblAccountName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cbxOnHand As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents lblBank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRemarks As DevExpress.XtraReports.UI.XRLabel
End Class
