<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptTrialBalanceV2
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
        Me.lblAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFP1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVariance1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFP2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVariance2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFP3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVariance3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancialH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYear1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYear2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYear3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lblVariance3T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual3T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFP3T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVariance2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFP2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVariance1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFP1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalH = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAccount, Me.lblCode, Me.lblFP1, Me.lblActual1, Me.lblVariance1, Me.lblFP2, Me.lblActual2, Me.lblVariance2, Me.lblFP3, Me.lblActual3, Me.lblVariance3})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAccount
        '
        Me.lblAccount.BackColor = System.Drawing.Color.White
        Me.lblAccount.BorderColor = System.Drawing.Color.Black
        Me.lblAccount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount.CanGrow = False
        Me.lblAccount.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount.ForeColor = System.Drawing.Color.Black
        Me.lblAccount.LocationFloat = New DevExpress.Utils.PointFloat(45.00006!, 0.0!)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount.SizeF = New System.Drawing.SizeF(260.0!, 20.0!)
        Me.lblAccount.StylePriority.UseBackColor = False
        Me.lblAccount.StylePriority.UseBorderColor = False
        Me.lblAccount.StylePriority.UseBorders = False
        Me.lblAccount.StylePriority.UseFont = False
        Me.lblAccount.StylePriority.UseForeColor = False
        Me.lblAccount.StylePriority.UseTextAlignment = False
        Me.lblAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.White
        Me.lblCode.BorderColor = System.Drawing.Color.Black
        Me.lblCode.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCode.CanGrow = False
        Me.lblCode.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Black
        Me.lblCode.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 0.0!)
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
        'lblFP1
        '
        Me.lblFP1.BackColor = System.Drawing.Color.White
        Me.lblFP1.BorderColor = System.Drawing.Color.Black
        Me.lblFP1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFP1.CanGrow = False
        Me.lblFP1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFP1.ForeColor = System.Drawing.Color.Black
        Me.lblFP1.LocationFloat = New DevExpress.Utils.PointFloat(305.0001!, 0.0!)
        Me.lblFP1.Name = "lblFP1"
        Me.lblFP1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFP1.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblFP1.StylePriority.UseBackColor = False
        Me.lblFP1.StylePriority.UseBorderColor = False
        Me.lblFP1.StylePriority.UseBorders = False
        Me.lblFP1.StylePriority.UseFont = False
        Me.lblFP1.StylePriority.UseForeColor = False
        Me.lblFP1.StylePriority.UseTextAlignment = False
        Me.lblFP1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFP1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual1
        '
        Me.lblActual1.BackColor = System.Drawing.Color.White
        Me.lblActual1.BorderColor = System.Drawing.Color.Black
        Me.lblActual1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual1.CanGrow = False
        Me.lblActual1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual1.ForeColor = System.Drawing.Color.Black
        Me.lblActual1.LocationFloat = New DevExpress.Utils.PointFloat(360.0001!, 0.0!)
        Me.lblActual1.Name = "lblActual1"
        Me.lblActual1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual1.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblActual1.StylePriority.UseBackColor = False
        Me.lblActual1.StylePriority.UseBorderColor = False
        Me.lblActual1.StylePriority.UseBorders = False
        Me.lblActual1.StylePriority.UseFont = False
        Me.lblActual1.StylePriority.UseForeColor = False
        Me.lblActual1.StylePriority.UseTextAlignment = False
        Me.lblActual1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblVariance1
        '
        Me.lblVariance1.BackColor = System.Drawing.Color.White
        Me.lblVariance1.BorderColor = System.Drawing.Color.Black
        Me.lblVariance1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblVariance1.CanGrow = False
        Me.lblVariance1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance1.ForeColor = System.Drawing.Color.Black
        Me.lblVariance1.LocationFloat = New DevExpress.Utils.PointFloat(415.0001!, 0.0!)
        Me.lblVariance1.Name = "lblVariance1"
        Me.lblVariance1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVariance1.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblVariance1.StylePriority.UseBackColor = False
        Me.lblVariance1.StylePriority.UseBorderColor = False
        Me.lblVariance1.StylePriority.UseBorders = False
        Me.lblVariance1.StylePriority.UseFont = False
        Me.lblVariance1.StylePriority.UseForeColor = False
        Me.lblVariance1.StylePriority.UseTextAlignment = False
        Me.lblVariance1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblVariance1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFP2
        '
        Me.lblFP2.BackColor = System.Drawing.Color.White
        Me.lblFP2.BorderColor = System.Drawing.Color.Black
        Me.lblFP2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFP2.CanGrow = False
        Me.lblFP2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFP2.ForeColor = System.Drawing.Color.Black
        Me.lblFP2.LocationFloat = New DevExpress.Utils.PointFloat(470.0001!, 0.0!)
        Me.lblFP2.Name = "lblFP2"
        Me.lblFP2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFP2.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblFP2.StylePriority.UseBackColor = False
        Me.lblFP2.StylePriority.UseBorderColor = False
        Me.lblFP2.StylePriority.UseBorders = False
        Me.lblFP2.StylePriority.UseFont = False
        Me.lblFP2.StylePriority.UseForeColor = False
        Me.lblFP2.StylePriority.UseTextAlignment = False
        Me.lblFP2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFP2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual2
        '
        Me.lblActual2.BackColor = System.Drawing.Color.White
        Me.lblActual2.BorderColor = System.Drawing.Color.Black
        Me.lblActual2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual2.CanGrow = False
        Me.lblActual2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual2.ForeColor = System.Drawing.Color.Black
        Me.lblActual2.LocationFloat = New DevExpress.Utils.PointFloat(525.0001!, 0.0!)
        Me.lblActual2.Name = "lblActual2"
        Me.lblActual2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual2.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblActual2.StylePriority.UseBackColor = False
        Me.lblActual2.StylePriority.UseBorderColor = False
        Me.lblActual2.StylePriority.UseBorders = False
        Me.lblActual2.StylePriority.UseFont = False
        Me.lblActual2.StylePriority.UseForeColor = False
        Me.lblActual2.StylePriority.UseTextAlignment = False
        Me.lblActual2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblVariance2
        '
        Me.lblVariance2.BackColor = System.Drawing.Color.White
        Me.lblVariance2.BorderColor = System.Drawing.Color.Black
        Me.lblVariance2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblVariance2.CanGrow = False
        Me.lblVariance2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance2.ForeColor = System.Drawing.Color.Black
        Me.lblVariance2.LocationFloat = New DevExpress.Utils.PointFloat(580.0001!, 0.0!)
        Me.lblVariance2.Name = "lblVariance2"
        Me.lblVariance2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVariance2.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblVariance2.StylePriority.UseBackColor = False
        Me.lblVariance2.StylePriority.UseBorderColor = False
        Me.lblVariance2.StylePriority.UseBorders = False
        Me.lblVariance2.StylePriority.UseFont = False
        Me.lblVariance2.StylePriority.UseForeColor = False
        Me.lblVariance2.StylePriority.UseTextAlignment = False
        Me.lblVariance2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblVariance2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFP3
        '
        Me.lblFP3.BackColor = System.Drawing.Color.White
        Me.lblFP3.BorderColor = System.Drawing.Color.Black
        Me.lblFP3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFP3.CanGrow = False
        Me.lblFP3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFP3.ForeColor = System.Drawing.Color.Black
        Me.lblFP3.LocationFloat = New DevExpress.Utils.PointFloat(635.0001!, 0.0!)
        Me.lblFP3.Name = "lblFP3"
        Me.lblFP3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFP3.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblFP3.StylePriority.UseBackColor = False
        Me.lblFP3.StylePriority.UseBorderColor = False
        Me.lblFP3.StylePriority.UseBorders = False
        Me.lblFP3.StylePriority.UseFont = False
        Me.lblFP3.StylePriority.UseForeColor = False
        Me.lblFP3.StylePriority.UseTextAlignment = False
        Me.lblFP3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFP3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual3
        '
        Me.lblActual3.BackColor = System.Drawing.Color.White
        Me.lblActual3.BorderColor = System.Drawing.Color.Black
        Me.lblActual3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual3.CanGrow = False
        Me.lblActual3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual3.ForeColor = System.Drawing.Color.Black
        Me.lblActual3.LocationFloat = New DevExpress.Utils.PointFloat(690.0001!, 0.0!)
        Me.lblActual3.Name = "lblActual3"
        Me.lblActual3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual3.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblActual3.StylePriority.UseBackColor = False
        Me.lblActual3.StylePriority.UseBorderColor = False
        Me.lblActual3.StylePriority.UseBorders = False
        Me.lblActual3.StylePriority.UseFont = False
        Me.lblActual3.StylePriority.UseForeColor = False
        Me.lblActual3.StylePriority.UseTextAlignment = False
        Me.lblActual3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblVariance3
        '
        Me.lblVariance3.BackColor = System.Drawing.Color.White
        Me.lblVariance3.BorderColor = System.Drawing.Color.Black
        Me.lblVariance3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblVariance3.CanGrow = False
        Me.lblVariance3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance3.ForeColor = System.Drawing.Color.Black
        Me.lblVariance3.LocationFloat = New DevExpress.Utils.PointFloat(744.9999!, 0.0!)
        Me.lblVariance3.Name = "lblVariance3"
        Me.lblVariance3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVariance3.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblVariance3.StylePriority.UseBackColor = False
        Me.lblVariance3.StylePriority.UseBorderColor = False
        Me.lblVariance3.StylePriority.UseBorders = False
        Me.lblVariance3.StylePriority.UseFont = False
        Me.lblVariance3.StylePriority.UseForeColor = False
        Me.lblVariance3.StylePriority.UseTextAlignment = False
        Me.lblVariance3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblVariance3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTitle, Me.lblAsOf, Me.lblAccountH, Me.lblFinancialH, Me.XrLabel4, Me.XrLabel5, Me.XrLabel10, Me.lblYear1, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.lblYear2, Me.lblYear3, Me.XrLabel11, Me.XrLabel9, Me.XrLabel7})
        Me.PageHeader.HeightF = 95.0!
        Me.PageHeader.Name = "PageHeader"
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
        'lblAccountH
        '
        Me.lblAccountH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAccountH.BorderColor = System.Drawing.Color.Black
        Me.lblAccountH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountH.CanGrow = False
        Me.lblAccountH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountH.ForeColor = System.Drawing.Color.White
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(45.00006!, 60.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(260.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Account Title"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFinancialH
        '
        Me.lblFinancialH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFinancialH.BorderColor = System.Drawing.Color.Black
        Me.lblFinancialH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancialH.CanGrow = False
        Me.lblFinancialH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancialH.ForeColor = System.Drawing.Color.White
        Me.lblFinancialH.LocationFloat = New DevExpress.Utils.PointFloat(305.0001!, 60.0!)
        Me.lblFinancialH.Name = "lblFinancialH"
        Me.lblFinancialH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancialH.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.lblFinancialH.StylePriority.UseBackColor = False
        Me.lblFinancialH.StylePriority.UseBorderColor = False
        Me.lblFinancialH.StylePriority.UseBorders = False
        Me.lblFinancialH.StylePriority.UseFont = False
        Me.lblFinancialH.StylePriority.UseForeColor = False
        Me.lblFinancialH.StylePriority.UseTextAlignment = False
        Me.lblFinancialH.Text = "Financial Plan"
        Me.lblFinancialH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.White
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(360.0001!, 60.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Actual"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.White
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(415.0001!, 60.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Variance"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'lblYear1
        '
        Me.lblYear1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblYear1.BorderColor = System.Drawing.Color.Black
        Me.lblYear1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblYear1.CanGrow = False
        Me.lblYear1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear1.ForeColor = System.Drawing.Color.White
        Me.lblYear1.LocationFloat = New DevExpress.Utils.PointFloat(305.0001!, 40.0!)
        Me.lblYear1.Name = "lblYear1"
        Me.lblYear1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYear1.SizeF = New System.Drawing.SizeF(165.0!, 20.0!)
        Me.lblYear1.StylePriority.UseBackColor = False
        Me.lblYear1.StylePriority.UseBorderColor = False
        Me.lblYear1.StylePriority.UseBorders = False
        Me.lblYear1.StylePriority.UseFont = False
        Me.lblYear1.StylePriority.UseForeColor = False
        Me.lblYear1.StylePriority.UseTextAlignment = False
        Me.lblYear1.Text = "September 21, 2018"
        Me.lblYear1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.White
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(580.0001!, 60.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Variance"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.White
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(525.0001!, 60.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Actual"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.White
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(470.0001!, 60.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Financial Plan"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYear2
        '
        Me.lblYear2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblYear2.BorderColor = System.Drawing.Color.Black
        Me.lblYear2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblYear2.CanGrow = False
        Me.lblYear2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear2.ForeColor = System.Drawing.Color.White
        Me.lblYear2.LocationFloat = New DevExpress.Utils.PointFloat(470.0001!, 40.0!)
        Me.lblYear2.Name = "lblYear2"
        Me.lblYear2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYear2.SizeF = New System.Drawing.SizeF(165.0!, 20.0!)
        Me.lblYear2.StylePriority.UseBackColor = False
        Me.lblYear2.StylePriority.UseBorderColor = False
        Me.lblYear2.StylePriority.UseBorders = False
        Me.lblYear2.StylePriority.UseFont = False
        Me.lblYear2.StylePriority.UseForeColor = False
        Me.lblYear2.StylePriority.UseTextAlignment = False
        Me.lblYear2.Text = "September 21, 2017"
        Me.lblYear2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYear3
        '
        Me.lblYear3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblYear3.BorderColor = System.Drawing.Color.Black
        Me.lblYear3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblYear3.CanGrow = False
        Me.lblYear3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear3.ForeColor = System.Drawing.Color.White
        Me.lblYear3.LocationFloat = New DevExpress.Utils.PointFloat(635.0!, 40.0!)
        Me.lblYear3.Name = "lblYear3"
        Me.lblYear3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYear3.SizeF = New System.Drawing.SizeF(165.0!, 20.0!)
        Me.lblYear3.StylePriority.UseBackColor = False
        Me.lblYear3.StylePriority.UseBorderColor = False
        Me.lblYear3.StylePriority.UseBorders = False
        Me.lblYear3.StylePriority.UseFont = False
        Me.lblYear3.StylePriority.UseForeColor = False
        Me.lblYear3.StylePriority.UseTextAlignment = False
        Me.lblYear3.Text = "September 21, 2016"
        Me.lblYear3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.White
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(635.0001!, 60.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Financial Plan"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(690.0001!, 60.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Actual"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.White
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(745.0001!, 60.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Variance"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblVariance3T, Me.lblActual3T, Me.lblFP3T, Me.lblVariance2T, Me.lblActual2T, Me.lblFP2T, Me.lblVariance1T, Me.lblActual1T, Me.lblFP1T, Me.lblTotalH})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblVariance3T
        '
        Me.lblVariance3T.BackColor = System.Drawing.Color.White
        Me.lblVariance3T.BorderColor = System.Drawing.Color.Black
        Me.lblVariance3T.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblVariance3T.CanGrow = False
        Me.lblVariance3T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance3T.ForeColor = System.Drawing.Color.Black
        Me.lblVariance3T.LocationFloat = New DevExpress.Utils.PointFloat(745.0001!, 0.0!)
        Me.lblVariance3T.Name = "lblVariance3T"
        Me.lblVariance3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVariance3T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblVariance3T.StylePriority.UseBackColor = False
        Me.lblVariance3T.StylePriority.UseBorderColor = False
        Me.lblVariance3T.StylePriority.UseBorders = False
        Me.lblVariance3T.StylePriority.UseFont = False
        Me.lblVariance3T.StylePriority.UseForeColor = False
        Me.lblVariance3T.StylePriority.UseTextAlignment = False
        Me.lblVariance3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblVariance3T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual3T
        '
        Me.lblActual3T.BackColor = System.Drawing.Color.White
        Me.lblActual3T.BorderColor = System.Drawing.Color.Black
        Me.lblActual3T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual3T.CanGrow = False
        Me.lblActual3T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual3T.ForeColor = System.Drawing.Color.Black
        Me.lblActual3T.LocationFloat = New DevExpress.Utils.PointFloat(690.0001!, 0.0!)
        Me.lblActual3T.Name = "lblActual3T"
        Me.lblActual3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual3T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblActual3T.StylePriority.UseBackColor = False
        Me.lblActual3T.StylePriority.UseBorderColor = False
        Me.lblActual3T.StylePriority.UseBorders = False
        Me.lblActual3T.StylePriority.UseFont = False
        Me.lblActual3T.StylePriority.UseForeColor = False
        Me.lblActual3T.StylePriority.UseTextAlignment = False
        Me.lblActual3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual3T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFP3T
        '
        Me.lblFP3T.BackColor = System.Drawing.Color.White
        Me.lblFP3T.BorderColor = System.Drawing.Color.Black
        Me.lblFP3T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFP3T.CanGrow = False
        Me.lblFP3T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFP3T.ForeColor = System.Drawing.Color.Black
        Me.lblFP3T.LocationFloat = New DevExpress.Utils.PointFloat(635.0001!, 0.0!)
        Me.lblFP3T.Name = "lblFP3T"
        Me.lblFP3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFP3T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblFP3T.StylePriority.UseBackColor = False
        Me.lblFP3T.StylePriority.UseBorderColor = False
        Me.lblFP3T.StylePriority.UseBorders = False
        Me.lblFP3T.StylePriority.UseFont = False
        Me.lblFP3T.StylePriority.UseForeColor = False
        Me.lblFP3T.StylePriority.UseTextAlignment = False
        Me.lblFP3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFP3T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblVariance2T
        '
        Me.lblVariance2T.BackColor = System.Drawing.Color.White
        Me.lblVariance2T.BorderColor = System.Drawing.Color.Black
        Me.lblVariance2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblVariance2T.CanGrow = False
        Me.lblVariance2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance2T.ForeColor = System.Drawing.Color.Black
        Me.lblVariance2T.LocationFloat = New DevExpress.Utils.PointFloat(580.0001!, 0.0!)
        Me.lblVariance2T.Name = "lblVariance2T"
        Me.lblVariance2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVariance2T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblVariance2T.StylePriority.UseBackColor = False
        Me.lblVariance2T.StylePriority.UseBorderColor = False
        Me.lblVariance2T.StylePriority.UseBorders = False
        Me.lblVariance2T.StylePriority.UseFont = False
        Me.lblVariance2T.StylePriority.UseForeColor = False
        Me.lblVariance2T.StylePriority.UseTextAlignment = False
        Me.lblVariance2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblVariance2T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual2T
        '
        Me.lblActual2T.BackColor = System.Drawing.Color.White
        Me.lblActual2T.BorderColor = System.Drawing.Color.Black
        Me.lblActual2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual2T.CanGrow = False
        Me.lblActual2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual2T.ForeColor = System.Drawing.Color.Black
        Me.lblActual2T.LocationFloat = New DevExpress.Utils.PointFloat(525.0001!, 0.0!)
        Me.lblActual2T.Name = "lblActual2T"
        Me.lblActual2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual2T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblActual2T.StylePriority.UseBackColor = False
        Me.lblActual2T.StylePriority.UseBorderColor = False
        Me.lblActual2T.StylePriority.UseBorders = False
        Me.lblActual2T.StylePriority.UseFont = False
        Me.lblActual2T.StylePriority.UseForeColor = False
        Me.lblActual2T.StylePriority.UseTextAlignment = False
        Me.lblActual2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual2T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFP2T
        '
        Me.lblFP2T.BackColor = System.Drawing.Color.White
        Me.lblFP2T.BorderColor = System.Drawing.Color.Black
        Me.lblFP2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFP2T.CanGrow = False
        Me.lblFP2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFP2T.ForeColor = System.Drawing.Color.Black
        Me.lblFP2T.LocationFloat = New DevExpress.Utils.PointFloat(470.0001!, 0.0!)
        Me.lblFP2T.Name = "lblFP2T"
        Me.lblFP2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFP2T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblFP2T.StylePriority.UseBackColor = False
        Me.lblFP2T.StylePriority.UseBorderColor = False
        Me.lblFP2T.StylePriority.UseBorders = False
        Me.lblFP2T.StylePriority.UseFont = False
        Me.lblFP2T.StylePriority.UseForeColor = False
        Me.lblFP2T.StylePriority.UseTextAlignment = False
        Me.lblFP2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFP2T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblVariance1T
        '
        Me.lblVariance1T.BackColor = System.Drawing.Color.White
        Me.lblVariance1T.BorderColor = System.Drawing.Color.Black
        Me.lblVariance1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblVariance1T.CanGrow = False
        Me.lblVariance1T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance1T.ForeColor = System.Drawing.Color.Black
        Me.lblVariance1T.LocationFloat = New DevExpress.Utils.PointFloat(415.0001!, 0.0!)
        Me.lblVariance1T.Name = "lblVariance1T"
        Me.lblVariance1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVariance1T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblVariance1T.StylePriority.UseBackColor = False
        Me.lblVariance1T.StylePriority.UseBorderColor = False
        Me.lblVariance1T.StylePriority.UseBorders = False
        Me.lblVariance1T.StylePriority.UseFont = False
        Me.lblVariance1T.StylePriority.UseForeColor = False
        Me.lblVariance1T.StylePriority.UseTextAlignment = False
        Me.lblVariance1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblVariance1T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual1T
        '
        Me.lblActual1T.BackColor = System.Drawing.Color.White
        Me.lblActual1T.BorderColor = System.Drawing.Color.Black
        Me.lblActual1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual1T.CanGrow = False
        Me.lblActual1T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual1T.ForeColor = System.Drawing.Color.Black
        Me.lblActual1T.LocationFloat = New DevExpress.Utils.PointFloat(360.0001!, 0.0!)
        Me.lblActual1T.Name = "lblActual1T"
        Me.lblActual1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual1T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblActual1T.StylePriority.UseBackColor = False
        Me.lblActual1T.StylePriority.UseBorderColor = False
        Me.lblActual1T.StylePriority.UseBorders = False
        Me.lblActual1T.StylePriority.UseFont = False
        Me.lblActual1T.StylePriority.UseForeColor = False
        Me.lblActual1T.StylePriority.UseTextAlignment = False
        Me.lblActual1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual1T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFP1T
        '
        Me.lblFP1T.BackColor = System.Drawing.Color.White
        Me.lblFP1T.BorderColor = System.Drawing.Color.Black
        Me.lblFP1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFP1T.CanGrow = False
        Me.lblFP1T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFP1T.ForeColor = System.Drawing.Color.Black
        Me.lblFP1T.LocationFloat = New DevExpress.Utils.PointFloat(305.0001!, 0.0!)
        Me.lblFP1T.Name = "lblFP1T"
        Me.lblFP1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFP1T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblFP1T.StylePriority.UseBackColor = False
        Me.lblFP1T.StylePriority.UseBorderColor = False
        Me.lblFP1T.StylePriority.UseBorders = False
        Me.lblFP1T.StylePriority.UseFont = False
        Me.lblFP1T.StylePriority.UseForeColor = False
        Me.lblFP1T.StylePriority.UseTextAlignment = False
        Me.lblFP1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFP1T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblTotalH
        '
        Me.lblTotalH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotalH.BorderColor = System.Drawing.Color.Black
        Me.lblTotalH.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalH.CanGrow = False
        Me.lblTotalH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalH.ForeColor = System.Drawing.Color.White
        Me.lblTotalH.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 0.0!)
        Me.lblTotalH.Name = "lblTotalH"
        Me.lblTotalH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalH.SizeF = New System.Drawing.SizeF(305.0!, 20.0!)
        Me.lblTotalH.StylePriority.UseBackColor = False
        Me.lblTotalH.StylePriority.UseBorderColor = False
        Me.lblTotalH.StylePriority.UseBorders = False
        Me.lblTotalH.StylePriority.UseFont = False
        Me.lblTotalH.StylePriority.UseForeColor = False
        Me.lblTotalH.StylePriority.UseTextAlignment = False
        Me.lblTotalH.Text = "T O T A L"
        Me.lblTotalH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 20.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(399.9999!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.White
        Me.XrPageInfo1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'rptTrialBalanceV2
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
    Friend WithEvents lblAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFP1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVariance1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFP2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVariance2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFP3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVariance3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancialH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYear1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYear2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYear3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVariance3T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual3T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFP3T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVariance2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFP2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVariance1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFP1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
