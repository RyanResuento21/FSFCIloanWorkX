<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptTrialBalanceWithoutFP
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
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.lblCaption3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCaption2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCaption1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual3T = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblActual3, Me.lblActual2, Me.lblActual1, Me.lblCode, Me.lblAccount})
        Me.Detail.HeightF = 20.0!
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
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblCaption3, Me.lblCaption2, Me.XrLabel10, Me.lblCaption1, Me.lblAccountH, Me.lblAsOf, Me.lblTitle})
        Me.PageHeader.HeightF = 95.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTotalH, Me.lblActual1T, Me.lblActual2T, Me.lblActual3T})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.XrPageInfo2})
        Me.PageFooter.HeightF = 20.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.White
        Me.XrPageInfo1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCaption3
        '
        Me.lblCaption3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCaption3.BorderColor = System.Drawing.Color.Black
        Me.lblCaption3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCaption3.CanGrow = False
        Me.lblCaption3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption3.ForeColor = System.Drawing.Color.White
        Me.lblCaption3.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 60.0!)
        Me.lblCaption3.Name = "lblCaption3"
        Me.lblCaption3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCaption3.SizeF = New System.Drawing.SizeF(125.0!, 35.0!)
        Me.lblCaption3.StylePriority.UseBackColor = False
        Me.lblCaption3.StylePriority.UseBorderColor = False
        Me.lblCaption3.StylePriority.UseBorders = False
        Me.lblCaption3.StylePriority.UseFont = False
        Me.lblCaption3.StylePriority.UseForeColor = False
        Me.lblCaption3.StylePriority.UseTextAlignment = False
        Me.lblCaption3.Text = "Actual"
        Me.lblCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCaption2
        '
        Me.lblCaption2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCaption2.BorderColor = System.Drawing.Color.Black
        Me.lblCaption2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCaption2.CanGrow = False
        Me.lblCaption2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption2.ForeColor = System.Drawing.Color.White
        Me.lblCaption2.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 60.0!)
        Me.lblCaption2.Name = "lblCaption2"
        Me.lblCaption2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCaption2.SizeF = New System.Drawing.SizeF(125.0!, 35.0!)
        Me.lblCaption2.StylePriority.UseBackColor = False
        Me.lblCaption2.StylePriority.UseBorderColor = False
        Me.lblCaption2.StylePriority.UseBorders = False
        Me.lblCaption2.StylePriority.UseFont = False
        Me.lblCaption2.StylePriority.UseForeColor = False
        Me.lblCaption2.StylePriority.UseTextAlignment = False
        Me.lblCaption2.Text = "Actual"
        Me.lblCaption2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.White
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 60.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(45.00006!, 35.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Account Code"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCaption1
        '
        Me.lblCaption1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblCaption1.BorderColor = System.Drawing.Color.Black
        Me.lblCaption1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCaption1.CanGrow = False
        Me.lblCaption1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption1.ForeColor = System.Drawing.Color.White
        Me.lblCaption1.LocationFloat = New DevExpress.Utils.PointFloat(425.0!, 60.0!)
        Me.lblCaption1.Name = "lblCaption1"
        Me.lblCaption1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCaption1.SizeF = New System.Drawing.SizeF(125.0!, 35.0!)
        Me.lblCaption1.StylePriority.UseBackColor = False
        Me.lblCaption1.StylePriority.UseBorderColor = False
        Me.lblCaption1.StylePriority.UseBorders = False
        Me.lblCaption1.StylePriority.UseFont = False
        Me.lblCaption1.StylePriority.UseForeColor = False
        Me.lblCaption1.StylePriority.UseTextAlignment = False
        Me.lblCaption1.Text = "Actual"
        Me.lblCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountH
        '
        Me.lblAccountH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAccountH.BorderColor = System.Drawing.Color.Black
        Me.lblAccountH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountH.CanGrow = False
        Me.lblAccountH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountH.ForeColor = System.Drawing.Color.White
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(45.0!, 60.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(380.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Account Title"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(799.9999!, 15.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "As of August 08, 2018"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Trial Balance"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblActual3
        '
        Me.lblActual3.BackColor = System.Drawing.Color.White
        Me.lblActual3.BorderColor = System.Drawing.Color.Black
        Me.lblActual3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual3.CanGrow = False
        Me.lblActual3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual3.ForeColor = System.Drawing.Color.Black
        Me.lblActual3.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 0.0!)
        Me.lblActual3.Name = "lblActual3"
        Me.lblActual3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual3.SizeF = New System.Drawing.SizeF(124.9999!, 20.0!)
        Me.lblActual3.StylePriority.UseBackColor = False
        Me.lblActual3.StylePriority.UseBorderColor = False
        Me.lblActual3.StylePriority.UseBorders = False
        Me.lblActual3.StylePriority.UseFont = False
        Me.lblActual3.StylePriority.UseForeColor = False
        Me.lblActual3.StylePriority.UseTextAlignment = False
        Me.lblActual3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual2
        '
        Me.lblActual2.BackColor = System.Drawing.Color.White
        Me.lblActual2.BorderColor = System.Drawing.Color.Black
        Me.lblActual2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual2.CanGrow = False
        Me.lblActual2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual2.ForeColor = System.Drawing.Color.Black
        Me.lblActual2.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0.0!)
        Me.lblActual2.Name = "lblActual2"
        Me.lblActual2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual2.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblActual2.StylePriority.UseBackColor = False
        Me.lblActual2.StylePriority.UseBorderColor = False
        Me.lblActual2.StylePriority.UseBorders = False
        Me.lblActual2.StylePriority.UseFont = False
        Me.lblActual2.StylePriority.UseForeColor = False
        Me.lblActual2.StylePriority.UseTextAlignment = False
        Me.lblActual2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual1
        '
        Me.lblActual1.BackColor = System.Drawing.Color.White
        Me.lblActual1.BorderColor = System.Drawing.Color.Black
        Me.lblActual1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual1.CanGrow = False
        Me.lblActual1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual1.ForeColor = System.Drawing.Color.Black
        Me.lblActual1.LocationFloat = New DevExpress.Utils.PointFloat(425.0!, 0.0!)
        Me.lblActual1.Name = "lblActual1"
        Me.lblActual1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual1.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblActual1.StylePriority.UseBackColor = False
        Me.lblActual1.StylePriority.UseBorderColor = False
        Me.lblActual1.StylePriority.UseBorders = False
        Me.lblActual1.StylePriority.UseFont = False
        Me.lblActual1.StylePriority.UseForeColor = False
        Me.lblActual1.StylePriority.UseTextAlignment = False
        Me.lblActual1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.White
        Me.lblCode.BorderColor = System.Drawing.Color.Black
        Me.lblCode.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCode.CanGrow = False
        Me.lblCode.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Black
        Me.lblCode.LocationFloat = New DevExpress.Utils.PointFloat(0.00009155273!, 0.0!)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCode.SizeF = New System.Drawing.SizeF(45.0!, 20.0!)
        Me.lblCode.StylePriority.UseBackColor = False
        Me.lblCode.StylePriority.UseBorderColor = False
        Me.lblCode.StylePriority.UseBorders = False
        Me.lblCode.StylePriority.UseFont = False
        Me.lblCode.StylePriority.UseForeColor = False
        Me.lblCode.StylePriority.UseTextAlignment = False
        Me.lblCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccount
        '
        Me.lblAccount.BackColor = System.Drawing.Color.White
        Me.lblAccount.BorderColor = System.Drawing.Color.Black
        Me.lblAccount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount.CanGrow = False
        Me.lblAccount.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount.ForeColor = System.Drawing.Color.Black
        Me.lblAccount.LocationFloat = New DevExpress.Utils.PointFloat(45.00009!, 0.0!)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount.SizeF = New System.Drawing.SizeF(379.9999!, 20.0!)
        Me.lblAccount.StylePriority.UseBackColor = False
        Me.lblAccount.StylePriority.UseBorderColor = False
        Me.lblAccount.StylePriority.UseBorders = False
        Me.lblAccount.StylePriority.UseFont = False
        Me.lblAccount.StylePriority.UseForeColor = False
        Me.lblAccount.StylePriority.UseTextAlignment = False
        Me.lblAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblTotalH
        '
        Me.lblTotalH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotalH.BorderColor = System.Drawing.Color.Black
        Me.lblTotalH.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalH.CanGrow = False
        Me.lblTotalH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalH.ForeColor = System.Drawing.Color.White
        Me.lblTotalH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblTotalH.Name = "lblTotalH"
        Me.lblTotalH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalH.SizeF = New System.Drawing.SizeF(425.0!, 20.0!)
        Me.lblTotalH.StylePriority.UseBackColor = False
        Me.lblTotalH.StylePriority.UseBorderColor = False
        Me.lblTotalH.StylePriority.UseBorders = False
        Me.lblTotalH.StylePriority.UseFont = False
        Me.lblTotalH.StylePriority.UseForeColor = False
        Me.lblTotalH.StylePriority.UseTextAlignment = False
        Me.lblTotalH.Text = "T O T A L"
        Me.lblTotalH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblActual1T
        '
        Me.lblActual1T.BackColor = System.Drawing.Color.White
        Me.lblActual1T.BorderColor = System.Drawing.Color.Black
        Me.lblActual1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual1T.CanGrow = False
        Me.lblActual1T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual1T.ForeColor = System.Drawing.Color.Black
        Me.lblActual1T.LocationFloat = New DevExpress.Utils.PointFloat(425.0!, 0.0!)
        Me.lblActual1T.Name = "lblActual1T"
        Me.lblActual1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual1T.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblActual1T.StylePriority.UseBackColor = False
        Me.lblActual1T.StylePriority.UseBorderColor = False
        Me.lblActual1T.StylePriority.UseBorders = False
        Me.lblActual1T.StylePriority.UseFont = False
        Me.lblActual1T.StylePriority.UseForeColor = False
        Me.lblActual1T.StylePriority.UseTextAlignment = False
        Me.lblActual1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual1T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual2T
        '
        Me.lblActual2T.BackColor = System.Drawing.Color.White
        Me.lblActual2T.BorderColor = System.Drawing.Color.Black
        Me.lblActual2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual2T.CanGrow = False
        Me.lblActual2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual2T.ForeColor = System.Drawing.Color.Black
        Me.lblActual2T.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0.0!)
        Me.lblActual2T.Name = "lblActual2T"
        Me.lblActual2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual2T.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblActual2T.StylePriority.UseBackColor = False
        Me.lblActual2T.StylePriority.UseBorderColor = False
        Me.lblActual2T.StylePriority.UseBorders = False
        Me.lblActual2T.StylePriority.UseFont = False
        Me.lblActual2T.StylePriority.UseForeColor = False
        Me.lblActual2T.StylePriority.UseTextAlignment = False
        Me.lblActual2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual2T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual3T
        '
        Me.lblActual3T.BackColor = System.Drawing.Color.White
        Me.lblActual3T.BorderColor = System.Drawing.Color.Black
        Me.lblActual3T.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual3T.CanGrow = False
        Me.lblActual3T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual3T.ForeColor = System.Drawing.Color.Black
        Me.lblActual3T.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 0.0!)
        Me.lblActual3T.Name = "lblActual3T"
        Me.lblActual3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual3T.SizeF = New System.Drawing.SizeF(124.9999!, 20.0!)
        Me.lblActual3T.StylePriority.UseBackColor = False
        Me.lblActual3T.StylePriority.UseBorderColor = False
        Me.lblActual3T.StylePriority.UseBorders = False
        Me.lblActual3T.StylePriority.UseFont = False
        Me.lblActual3T.StylePriority.UseForeColor = False
        Me.lblActual3T.StylePriority.UseTextAlignment = False
        Me.lblActual3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual3T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'rptTrialBalanceWithoutFP
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents lblCaption3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCaption2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCaption1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual3T As DevExpress.XtraReports.UI.XRLabel
End Class
