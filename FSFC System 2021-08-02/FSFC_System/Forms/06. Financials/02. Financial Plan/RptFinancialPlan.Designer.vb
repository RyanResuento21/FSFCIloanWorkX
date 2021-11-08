<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptFinancialPlan
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
        Me.lblTotal = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJun = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMay = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblApr = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMar = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFeb = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJan = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJunH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMayH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAprH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMarH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFebH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJanH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.cbx1st = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbx2nd = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYear = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCheckedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblApprovedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel46 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPreparedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJunT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMayT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAprT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMarT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFebT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblJanT = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTotal, Me.lblJun, Me.lblMay, Me.lblApr, Me.lblMar, Me.lblFeb, Me.lblJan, Me.lblAccount, Me.lblCode})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderColor = System.Drawing.Color.Black
        Me.lblTotal.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotal.CanGrow = False
        Me.lblTotal.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 0.0!)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotal.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblTotal.StylePriority.UseBackColor = False
        Me.lblTotal.StylePriority.UseBorderColor = False
        Me.lblTotal.StylePriority.UseBorders = False
        Me.lblTotal.StylePriority.UseFont = False
        Me.lblTotal.StylePriority.UseForeColor = False
        Me.lblTotal.StylePriority.UseTextAlignment = False
        Me.lblTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotal.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblJun
        '
        Me.lblJun.BackColor = System.Drawing.Color.White
        Me.lblJun.BorderColor = System.Drawing.Color.Black
        Me.lblJun.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJun.CanGrow = False
        Me.lblJun.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblJun.ForeColor = System.Drawing.Color.Black
        Me.lblJun.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0.0!)
        Me.lblJun.Name = "lblJun"
        Me.lblJun.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJun.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblJun.StylePriority.UseBackColor = False
        Me.lblJun.StylePriority.UseBorderColor = False
        Me.lblJun.StylePriority.UseBorders = False
        Me.lblJun.StylePriority.UseFont = False
        Me.lblJun.StylePriority.UseForeColor = False
        Me.lblJun.StylePriority.UseTextAlignment = False
        Me.lblJun.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblJun.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMay
        '
        Me.lblMay.BackColor = System.Drawing.Color.White
        Me.lblMay.BorderColor = System.Drawing.Color.Black
        Me.lblMay.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMay.CanGrow = False
        Me.lblMay.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblMay.ForeColor = System.Drawing.Color.Black
        Me.lblMay.LocationFloat = New DevExpress.Utils.PointFloat(580.0!, 0.0!)
        Me.lblMay.Name = "lblMay"
        Me.lblMay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMay.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblMay.StylePriority.UseBackColor = False
        Me.lblMay.StylePriority.UseBorderColor = False
        Me.lblMay.StylePriority.UseBorders = False
        Me.lblMay.StylePriority.UseFont = False
        Me.lblMay.StylePriority.UseForeColor = False
        Me.lblMay.StylePriority.UseTextAlignment = False
        Me.lblMay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblMay.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblApr
        '
        Me.lblApr.BackColor = System.Drawing.Color.White
        Me.lblApr.BorderColor = System.Drawing.Color.Black
        Me.lblApr.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblApr.CanGrow = False
        Me.lblApr.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblApr.ForeColor = System.Drawing.Color.Black
        Me.lblApr.LocationFloat = New DevExpress.Utils.PointFloat(510.0!, 0.0!)
        Me.lblApr.Name = "lblApr"
        Me.lblApr.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblApr.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblApr.StylePriority.UseBackColor = False
        Me.lblApr.StylePriority.UseBorderColor = False
        Me.lblApr.StylePriority.UseBorders = False
        Me.lblApr.StylePriority.UseFont = False
        Me.lblApr.StylePriority.UseForeColor = False
        Me.lblApr.StylePriority.UseTextAlignment = False
        Me.lblApr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblApr.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMar
        '
        Me.lblMar.BackColor = System.Drawing.Color.White
        Me.lblMar.BorderColor = System.Drawing.Color.Black
        Me.lblMar.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMar.CanGrow = False
        Me.lblMar.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblMar.ForeColor = System.Drawing.Color.Black
        Me.lblMar.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 0.0!)
        Me.lblMar.Name = "lblMar"
        Me.lblMar.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMar.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblMar.StylePriority.UseBackColor = False
        Me.lblMar.StylePriority.UseBorderColor = False
        Me.lblMar.StylePriority.UseBorders = False
        Me.lblMar.StylePriority.UseFont = False
        Me.lblMar.StylePriority.UseForeColor = False
        Me.lblMar.StylePriority.UseTextAlignment = False
        Me.lblMar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblMar.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFeb
        '
        Me.lblFeb.BackColor = System.Drawing.Color.White
        Me.lblFeb.BorderColor = System.Drawing.Color.Black
        Me.lblFeb.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFeb.CanGrow = False
        Me.lblFeb.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblFeb.ForeColor = System.Drawing.Color.Black
        Me.lblFeb.LocationFloat = New DevExpress.Utils.PointFloat(370.0!, 0.0!)
        Me.lblFeb.Name = "lblFeb"
        Me.lblFeb.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFeb.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblFeb.StylePriority.UseBackColor = False
        Me.lblFeb.StylePriority.UseBorderColor = False
        Me.lblFeb.StylePriority.UseBorders = False
        Me.lblFeb.StylePriority.UseFont = False
        Me.lblFeb.StylePriority.UseForeColor = False
        Me.lblFeb.StylePriority.UseTextAlignment = False
        Me.lblFeb.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFeb.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblJan
        '
        Me.lblJan.BackColor = System.Drawing.Color.White
        Me.lblJan.BorderColor = System.Drawing.Color.Black
        Me.lblJan.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJan.CanGrow = False
        Me.lblJan.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblJan.ForeColor = System.Drawing.Color.Black
        Me.lblJan.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 0.0!)
        Me.lblJan.Name = "lblJan"
        Me.lblJan.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJan.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblJan.StylePriority.UseBackColor = False
        Me.lblJan.StylePriority.UseBorderColor = False
        Me.lblJan.StylePriority.UseBorders = False
        Me.lblJan.StylePriority.UseFont = False
        Me.lblJan.StylePriority.UseForeColor = False
        Me.lblJan.StylePriority.UseTextAlignment = False
        Me.lblJan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblJan.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount
        '
        Me.lblAccount.BackColor = System.Drawing.Color.White
        Me.lblAccount.BorderColor = System.Drawing.Color.Black
        Me.lblAccount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount.CanGrow = False
        Me.lblAccount.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblAccount.ForeColor = System.Drawing.Color.Black
        Me.lblAccount.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 0.0!)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
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
        Me.lblCode.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCode.ForeColor = System.Drawing.Color.Black
        Me.lblCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCode.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblCode.StylePriority.UseBackColor = False
        Me.lblCode.StylePriority.UseBorderColor = False
        Me.lblCode.StylePriority.UseBorders = False
        Me.lblCode.StylePriority.UseFont = False
        Me.lblCode.StylePriority.UseForeColor = False
        Me.lblCode.StylePriority.UseTextAlignment = False
        Me.lblCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTitle, Me.lblAsOf, Me.lblTotalH, Me.lblJunH, Me.lblMayH, Me.lblAprH, Me.lblMarH, Me.lblFebH, Me.lblJanH, Me.XrLabel5, Me.XrLabel4, Me.cbx1st, Me.cbx2nd, Me.XrLabel2, Me.lblYear})
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
        Me.lblTitle.SizeF = New System.Drawing.SizeF(800.0!, 25.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Financial Plan"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(800.0!, 15.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "As of August 08, 2018"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTotalH
        '
        Me.lblTotalH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotalH.BorderColor = System.Drawing.Color.Black
        Me.lblTotalH.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalH.CanGrow = False
        Me.lblTotalH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalH.ForeColor = System.Drawing.Color.White
        Me.lblTotalH.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 65.0!)
        Me.lblTotalH.Name = "lblTotalH"
        Me.lblTotalH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalH.SizeF = New System.Drawing.SizeF(80.0!, 30.0!)
        Me.lblTotalH.StylePriority.UseBackColor = False
        Me.lblTotalH.StylePriority.UseBorderColor = False
        Me.lblTotalH.StylePriority.UseBorders = False
        Me.lblTotalH.StylePriority.UseFont = False
        Me.lblTotalH.StylePriority.UseForeColor = False
        Me.lblTotalH.StylePriority.UseTextAlignment = False
        Me.lblTotalH.Text = "Total"
        Me.lblTotalH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblJunH
        '
        Me.lblJunH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblJunH.BorderColor = System.Drawing.Color.Black
        Me.lblJunH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJunH.CanGrow = False
        Me.lblJunH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJunH.ForeColor = System.Drawing.Color.White
        Me.lblJunH.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 65.0!)
        Me.lblJunH.Name = "lblJunH"
        Me.lblJunH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJunH.SizeF = New System.Drawing.SizeF(70.0!, 30.0!)
        Me.lblJunH.StylePriority.UseBackColor = False
        Me.lblJunH.StylePriority.UseBorderColor = False
        Me.lblJunH.StylePriority.UseBorders = False
        Me.lblJunH.StylePriority.UseFont = False
        Me.lblJunH.StylePriority.UseForeColor = False
        Me.lblJunH.StylePriority.UseTextAlignment = False
        Me.lblJunH.Text = "Jun"
        Me.lblJunH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMayH
        '
        Me.lblMayH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblMayH.BorderColor = System.Drawing.Color.Black
        Me.lblMayH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMayH.CanGrow = False
        Me.lblMayH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMayH.ForeColor = System.Drawing.Color.White
        Me.lblMayH.LocationFloat = New DevExpress.Utils.PointFloat(580.0!, 65.0!)
        Me.lblMayH.Name = "lblMayH"
        Me.lblMayH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMayH.SizeF = New System.Drawing.SizeF(70.0!, 30.0!)
        Me.lblMayH.StylePriority.UseBackColor = False
        Me.lblMayH.StylePriority.UseBorderColor = False
        Me.lblMayH.StylePriority.UseBorders = False
        Me.lblMayH.StylePriority.UseFont = False
        Me.lblMayH.StylePriority.UseForeColor = False
        Me.lblMayH.StylePriority.UseTextAlignment = False
        Me.lblMayH.Text = "May"
        Me.lblMayH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAprH
        '
        Me.lblAprH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAprH.BorderColor = System.Drawing.Color.Black
        Me.lblAprH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAprH.CanGrow = False
        Me.lblAprH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAprH.ForeColor = System.Drawing.Color.White
        Me.lblAprH.LocationFloat = New DevExpress.Utils.PointFloat(510.0!, 65.0!)
        Me.lblAprH.Name = "lblAprH"
        Me.lblAprH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAprH.SizeF = New System.Drawing.SizeF(70.0!, 30.0!)
        Me.lblAprH.StylePriority.UseBackColor = False
        Me.lblAprH.StylePriority.UseBorderColor = False
        Me.lblAprH.StylePriority.UseBorders = False
        Me.lblAprH.StylePriority.UseFont = False
        Me.lblAprH.StylePriority.UseForeColor = False
        Me.lblAprH.StylePriority.UseTextAlignment = False
        Me.lblAprH.Text = "Apr"
        Me.lblAprH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMarH
        '
        Me.lblMarH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblMarH.BorderColor = System.Drawing.Color.Black
        Me.lblMarH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMarH.CanGrow = False
        Me.lblMarH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarH.ForeColor = System.Drawing.Color.White
        Me.lblMarH.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 65.0!)
        Me.lblMarH.Name = "lblMarH"
        Me.lblMarH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMarH.SizeF = New System.Drawing.SizeF(70.0!, 30.0!)
        Me.lblMarH.StylePriority.UseBackColor = False
        Me.lblMarH.StylePriority.UseBorderColor = False
        Me.lblMarH.StylePriority.UseBorders = False
        Me.lblMarH.StylePriority.UseFont = False
        Me.lblMarH.StylePriority.UseForeColor = False
        Me.lblMarH.StylePriority.UseTextAlignment = False
        Me.lblMarH.Text = "Mar"
        Me.lblMarH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFebH
        '
        Me.lblFebH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFebH.BorderColor = System.Drawing.Color.Black
        Me.lblFebH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFebH.CanGrow = False
        Me.lblFebH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFebH.ForeColor = System.Drawing.Color.White
        Me.lblFebH.LocationFloat = New DevExpress.Utils.PointFloat(370.0!, 65.0!)
        Me.lblFebH.Name = "lblFebH"
        Me.lblFebH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFebH.SizeF = New System.Drawing.SizeF(70.0!, 30.0!)
        Me.lblFebH.StylePriority.UseBackColor = False
        Me.lblFebH.StylePriority.UseBorderColor = False
        Me.lblFebH.StylePriority.UseBorders = False
        Me.lblFebH.StylePriority.UseFont = False
        Me.lblFebH.StylePriority.UseForeColor = False
        Me.lblFebH.StylePriority.UseTextAlignment = False
        Me.lblFebH.Text = "Feb"
        Me.lblFebH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblJanH
        '
        Me.lblJanH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblJanH.BorderColor = System.Drawing.Color.Black
        Me.lblJanH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJanH.CanGrow = False
        Me.lblJanH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJanH.ForeColor = System.Drawing.Color.White
        Me.lblJanH.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 65.0!)
        Me.lblJanH.Name = "lblJanH"
        Me.lblJanH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJanH.SizeF = New System.Drawing.SizeF(70.0!, 30.0!)
        Me.lblJanH.StylePriority.UseBackColor = False
        Me.lblJanH.StylePriority.UseBorderColor = False
        Me.lblJanH.StylePriority.UseBorders = False
        Me.lblJanH.StylePriority.UseFont = False
        Me.lblJanH.StylePriority.UseForeColor = False
        Me.lblJanH.StylePriority.UseTextAlignment = False
        Me.lblJanH.Text = "Jan"
        Me.lblJanH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 65.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(250.0!, 30.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Account Name"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 65.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(50.0!, 30.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Code"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbx1st
        '
        Me.cbx1st.BackColor = System.Drawing.Color.White
        Me.cbx1st.BorderColor = System.Drawing.Color.Black
        Me.cbx1st.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.cbx1st.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbx1st.ForeColor = System.Drawing.Color.Black
        Me.cbx1st.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 39.99989!)
        Me.cbx1st.Name = "cbx1st"
        Me.cbx1st.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.cbx1st.StylePriority.UseBackColor = False
        Me.cbx1st.StylePriority.UseBorderColor = False
        Me.cbx1st.StylePriority.UseBorders = False
        Me.cbx1st.StylePriority.UseFont = False
        Me.cbx1st.StylePriority.UseForeColor = False
        Me.cbx1st.Text = "1st Half"
        '
        'cbx2nd
        '
        Me.cbx2nd.BackColor = System.Drawing.Color.White
        Me.cbx2nd.BorderColor = System.Drawing.Color.Black
        Me.cbx2nd.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.cbx2nd.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbx2nd.ForeColor = System.Drawing.Color.Black
        Me.cbx2nd.LocationFloat = New DevExpress.Utils.PointFloat(195.0!, 40.0!)
        Me.cbx2nd.Name = "cbx2nd"
        Me.cbx2nd.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.cbx2nd.StylePriority.UseBackColor = False
        Me.cbx2nd.StylePriority.UseBorderColor = False
        Me.cbx2nd.StylePriority.UseBorders = False
        Me.cbx2nd.StylePriority.UseFont = False
        Me.cbx2nd.StylePriority.UseForeColor = False
        Me.cbx2nd.Text = "2nd Half"
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.White
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.Black
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Year :"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblYear
        '
        Me.lblYear.BackColor = System.Drawing.Color.White
        Me.lblYear.BorderColor = System.Drawing.Color.Black
        Me.lblYear.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblYear.CanGrow = False
        Me.lblYear.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.Black
        Me.lblYear.LocationFloat = New DevExpress.Utils.PointFloat(59.99997!, 40.0!)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYear.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblYear.StylePriority.UseBackColor = False
        Me.lblYear.StylePriority.UseBorderColor = False
        Me.lblYear.StylePriority.UseBorders = False
        Me.lblYear.StylePriority.UseFont = False
        Me.lblYear.StylePriority.UseForeColor = False
        Me.lblYear.StylePriority.UseTextAlignment = False
        Me.lblYear.Text = "2018"
        Me.lblYear.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrLabel29, Me.XrLabel28, Me.lblCheckedBy, Me.XrLabel30, Me.XrLabel31, Me.lblApprovedBy, Me.XrLabel42, Me.XrLabel46, Me.lblPreparedBy, Me.lblTotalT, Me.lblJunT, Me.lblMayT, Me.lblAprT, Me.lblMarT, Me.lblFebT, Me.XrLabel21, Me.lblJanT})
        Me.ReportFooter.HeightF = 110.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(595.0001!, 89.99999!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(204.9998!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel29
        '
        Me.XrLabel29.BackColor = System.Drawing.Color.White
        Me.XrLabel29.BorderColor = System.Drawing.Color.Black
        Me.XrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel29.CanGrow = False
        Me.XrLabel29.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel29.ForeColor = System.Drawing.Color.Black
        Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(400.0001!, 30.0!)
        Me.XrLabel29.Name = "XrLabel29"
        Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel29.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel29.StylePriority.UseBackColor = False
        Me.XrLabel29.StylePriority.UseBorderColor = False
        Me.XrLabel29.StylePriority.UseBorders = False
        Me.XrLabel29.StylePriority.UseFont = False
        Me.XrLabel29.StylePriority.UseForeColor = False
        Me.XrLabel29.StylePriority.UseTextAlignment = False
        Me.XrLabel29.Text = "Approved By :"
        Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel28
        '
        Me.XrLabel28.BackColor = System.Drawing.Color.White
        Me.XrLabel28.BorderColor = System.Drawing.Color.Black
        Me.XrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel28.CanGrow = False
        Me.XrLabel28.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel28.ForeColor = System.Drawing.Color.Black
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(200.0001!, 30.0!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel28.StylePriority.UseBackColor = False
        Me.XrLabel28.StylePriority.UseBorderColor = False
        Me.XrLabel28.StylePriority.UseBorders = False
        Me.XrLabel28.StylePriority.UseFont = False
        Me.XrLabel28.StylePriority.UseForeColor = False
        Me.XrLabel28.StylePriority.UseTextAlignment = False
        Me.XrLabel28.Text = "Checked By :"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblCheckedBy
        '
        Me.lblCheckedBy.BackColor = System.Drawing.Color.White
        Me.lblCheckedBy.BorderColor = System.Drawing.Color.Black
        Me.lblCheckedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblCheckedBy.CanGrow = False
        Me.lblCheckedBy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCheckedBy.LocationFloat = New DevExpress.Utils.PointFloat(200.0001!, 50.0!)
        Me.lblCheckedBy.Name = "lblCheckedBy"
        Me.lblCheckedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheckedBy.SizeF = New System.Drawing.SizeF(195.0!, 40.0!)
        Me.lblCheckedBy.StylePriority.UseBackColor = False
        Me.lblCheckedBy.StylePriority.UseBorderColor = False
        Me.lblCheckedBy.StylePriority.UseBorders = False
        Me.lblCheckedBy.StylePriority.UseFont = False
        Me.lblCheckedBy.StylePriority.UseForeColor = False
        Me.lblCheckedBy.StylePriority.UseTextAlignment = False
        Me.lblCheckedBy.Text = "Mark Kevin M. Gotico"
        Me.lblCheckedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel30
        '
        Me.XrLabel30.BackColor = System.Drawing.Color.White
        Me.XrLabel30.BorderColor = System.Drawing.Color.Black
        Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel30.CanGrow = False
        Me.XrLabel30.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel30.ForeColor = System.Drawing.Color.Black
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(200.0001!, 90.0!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel30.StylePriority.UseBackColor = False
        Me.XrLabel30.StylePriority.UseBorderColor = False
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.StylePriority.UseFont = False
        Me.XrLabel30.StylePriority.UseForeColor = False
        Me.XrLabel30.StylePriority.UseTextAlignment = False
        Me.XrLabel30.Text = "Name and Signature"
        Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel31
        '
        Me.XrLabel31.BackColor = System.Drawing.Color.White
        Me.XrLabel31.BorderColor = System.Drawing.Color.Black
        Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel31.CanGrow = False
        Me.XrLabel31.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel31.ForeColor = System.Drawing.Color.Black
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(400.0001!, 90.0!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel31.StylePriority.UseBackColor = False
        Me.XrLabel31.StylePriority.UseBorderColor = False
        Me.XrLabel31.StylePriority.UseBorders = False
        Me.XrLabel31.StylePriority.UseFont = False
        Me.XrLabel31.StylePriority.UseForeColor = False
        Me.XrLabel31.StylePriority.UseTextAlignment = False
        Me.XrLabel31.Text = "Name and Signature"
        Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.BackColor = System.Drawing.Color.White
        Me.lblApprovedBy.BorderColor = System.Drawing.Color.Black
        Me.lblApprovedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblApprovedBy.CanGrow = False
        Me.lblApprovedBy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedBy.ForeColor = System.Drawing.Color.Black
        Me.lblApprovedBy.LocationFloat = New DevExpress.Utils.PointFloat(400.0001!, 50.0!)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblApprovedBy.SizeF = New System.Drawing.SizeF(195.0!, 40.0!)
        Me.lblApprovedBy.StylePriority.UseBackColor = False
        Me.lblApprovedBy.StylePriority.UseBorderColor = False
        Me.lblApprovedBy.StylePriority.UseBorders = False
        Me.lblApprovedBy.StylePriority.UseFont = False
        Me.lblApprovedBy.StylePriority.UseForeColor = False
        Me.lblApprovedBy.StylePriority.UseTextAlignment = False
        Me.lblApprovedBy.Text = "Mark Kevin M. Gotico"
        Me.lblApprovedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel42
        '
        Me.XrLabel42.BackColor = System.Drawing.Color.White
        Me.XrLabel42.BorderColor = System.Drawing.Color.Black
        Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel42.CanGrow = False
        Me.XrLabel42.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel42.ForeColor = System.Drawing.Color.Black
        Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 30.0!)
        Me.XrLabel42.Name = "XrLabel42"
        Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel42.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel42.StylePriority.UseBackColor = False
        Me.XrLabel42.StylePriority.UseBorderColor = False
        Me.XrLabel42.StylePriority.UseBorders = False
        Me.XrLabel42.StylePriority.UseFont = False
        Me.XrLabel42.StylePriority.UseForeColor = False
        Me.XrLabel42.StylePriority.UseTextAlignment = False
        Me.XrLabel42.Text = "Prepared By :"
        Me.XrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel46
        '
        Me.XrLabel46.BackColor = System.Drawing.Color.White
        Me.XrLabel46.BorderColor = System.Drawing.Color.Black
        Me.XrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel46.CanGrow = False
        Me.XrLabel46.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel46.ForeColor = System.Drawing.Color.Black
        Me.XrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 90.0!)
        Me.XrLabel46.Name = "XrLabel46"
        Me.XrLabel46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel46.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel46.StylePriority.UseBackColor = False
        Me.XrLabel46.StylePriority.UseBorderColor = False
        Me.XrLabel46.StylePriority.UseBorders = False
        Me.XrLabel46.StylePriority.UseFont = False
        Me.XrLabel46.StylePriority.UseForeColor = False
        Me.XrLabel46.StylePriority.UseTextAlignment = False
        Me.XrLabel46.Text = "Name and Signature"
        Me.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPreparedBy
        '
        Me.lblPreparedBy.BackColor = System.Drawing.Color.White
        Me.lblPreparedBy.BorderColor = System.Drawing.Color.Black
        Me.lblPreparedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblPreparedBy.CanGrow = False
        Me.lblPreparedBy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreparedBy.ForeColor = System.Drawing.Color.Black
        Me.lblPreparedBy.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.0!)
        Me.lblPreparedBy.Name = "lblPreparedBy"
        Me.lblPreparedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPreparedBy.SizeF = New System.Drawing.SizeF(195.0!, 40.0!)
        Me.lblPreparedBy.StylePriority.UseBackColor = False
        Me.lblPreparedBy.StylePriority.UseBorderColor = False
        Me.lblPreparedBy.StylePriority.UseBorders = False
        Me.lblPreparedBy.StylePriority.UseFont = False
        Me.lblPreparedBy.StylePriority.UseForeColor = False
        Me.lblPreparedBy.StylePriority.UseTextAlignment = False
        Me.lblPreparedBy.Text = "Mark Kevin M. Gotico"
        Me.lblPreparedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblTotalT
        '
        Me.lblTotalT.BackColor = System.Drawing.Color.White
        Me.lblTotalT.BorderColor = System.Drawing.Color.Black
        Me.lblTotalT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalT.CanGrow = False
        Me.lblTotalT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalT.ForeColor = System.Drawing.Color.Black
        Me.lblTotalT.LocationFloat = New DevExpress.Utils.PointFloat(719.9999!, 0.0!)
        Me.lblTotalT.Name = "lblTotalT"
        Me.lblTotalT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalT.SizeF = New System.Drawing.SizeF(80.00006!, 20.0!)
        Me.lblTotalT.StylePriority.UseBackColor = False
        Me.lblTotalT.StylePriority.UseBorderColor = False
        Me.lblTotalT.StylePriority.UseBorders = False
        Me.lblTotalT.StylePriority.UseFont = False
        Me.lblTotalT.StylePriority.UseForeColor = False
        Me.lblTotalT.StylePriority.UseTextAlignment = False
        Me.lblTotalT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotalT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblJunT
        '
        Me.lblJunT.BackColor = System.Drawing.Color.White
        Me.lblJunT.BorderColor = System.Drawing.Color.Black
        Me.lblJunT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJunT.CanGrow = False
        Me.lblJunT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJunT.ForeColor = System.Drawing.Color.Black
        Me.lblJunT.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0.0!)
        Me.lblJunT.Name = "lblJunT"
        Me.lblJunT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJunT.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblJunT.StylePriority.UseBackColor = False
        Me.lblJunT.StylePriority.UseBorderColor = False
        Me.lblJunT.StylePriority.UseBorders = False
        Me.lblJunT.StylePriority.UseFont = False
        Me.lblJunT.StylePriority.UseForeColor = False
        Me.lblJunT.StylePriority.UseTextAlignment = False
        Me.lblJunT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblJunT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMayT
        '
        Me.lblMayT.BackColor = System.Drawing.Color.White
        Me.lblMayT.BorderColor = System.Drawing.Color.Black
        Me.lblMayT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMayT.CanGrow = False
        Me.lblMayT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMayT.ForeColor = System.Drawing.Color.Black
        Me.lblMayT.LocationFloat = New DevExpress.Utils.PointFloat(580.0!, 0.0!)
        Me.lblMayT.Name = "lblMayT"
        Me.lblMayT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMayT.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblMayT.StylePriority.UseBackColor = False
        Me.lblMayT.StylePriority.UseBorderColor = False
        Me.lblMayT.StylePriority.UseBorders = False
        Me.lblMayT.StylePriority.UseFont = False
        Me.lblMayT.StylePriority.UseForeColor = False
        Me.lblMayT.StylePriority.UseTextAlignment = False
        Me.lblMayT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblMayT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAprT
        '
        Me.lblAprT.BackColor = System.Drawing.Color.White
        Me.lblAprT.BorderColor = System.Drawing.Color.Black
        Me.lblAprT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAprT.CanGrow = False
        Me.lblAprT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAprT.ForeColor = System.Drawing.Color.Black
        Me.lblAprT.LocationFloat = New DevExpress.Utils.PointFloat(510.0!, 0.0!)
        Me.lblAprT.Name = "lblAprT"
        Me.lblAprT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAprT.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblAprT.StylePriority.UseBackColor = False
        Me.lblAprT.StylePriority.UseBorderColor = False
        Me.lblAprT.StylePriority.UseBorders = False
        Me.lblAprT.StylePriority.UseFont = False
        Me.lblAprT.StylePriority.UseForeColor = False
        Me.lblAprT.StylePriority.UseTextAlignment = False
        Me.lblAprT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAprT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMarT
        '
        Me.lblMarT.BackColor = System.Drawing.Color.White
        Me.lblMarT.BorderColor = System.Drawing.Color.Black
        Me.lblMarT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMarT.CanGrow = False
        Me.lblMarT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarT.ForeColor = System.Drawing.Color.Black
        Me.lblMarT.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 0.0!)
        Me.lblMarT.Name = "lblMarT"
        Me.lblMarT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMarT.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblMarT.StylePriority.UseBackColor = False
        Me.lblMarT.StylePriority.UseBorderColor = False
        Me.lblMarT.StylePriority.UseBorders = False
        Me.lblMarT.StylePriority.UseFont = False
        Me.lblMarT.StylePriority.UseForeColor = False
        Me.lblMarT.StylePriority.UseTextAlignment = False
        Me.lblMarT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblMarT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFebT
        '
        Me.lblFebT.BackColor = System.Drawing.Color.White
        Me.lblFebT.BorderColor = System.Drawing.Color.Black
        Me.lblFebT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFebT.CanGrow = False
        Me.lblFebT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFebT.ForeColor = System.Drawing.Color.Black
        Me.lblFebT.LocationFloat = New DevExpress.Utils.PointFloat(370.0!, 0.0!)
        Me.lblFebT.Name = "lblFebT"
        Me.lblFebT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFebT.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblFebT.StylePriority.UseBackColor = False
        Me.lblFebT.StylePriority.UseBorderColor = False
        Me.lblFebT.StylePriority.UseBorders = False
        Me.lblFebT.StylePriority.UseFont = False
        Me.lblFebT.StylePriority.UseForeColor = False
        Me.lblFebT.StylePriority.UseTextAlignment = False
        Me.lblFebT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFebT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel21
        '
        Me.XrLabel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel21.BorderColor = System.Drawing.Color.Black
        Me.XrLabel21.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel21.CanGrow = False
        Me.XrLabel21.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel21.ForeColor = System.Drawing.Color.White
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(300.0!, 20.0!)
        Me.XrLabel21.StylePriority.UseBackColor = False
        Me.XrLabel21.StylePriority.UseBorderColor = False
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseForeColor = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "T O T A L"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblJanT
        '
        Me.lblJanT.BackColor = System.Drawing.Color.White
        Me.lblJanT.BorderColor = System.Drawing.Color.Black
        Me.lblJanT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblJanT.CanGrow = False
        Me.lblJanT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJanT.ForeColor = System.Drawing.Color.Black
        Me.lblJanT.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 0.0!)
        Me.lblJanT.Name = "lblJanT"
        Me.lblJanT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblJanT.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblJanT.StylePriority.UseBackColor = False
        Me.lblJanT.StylePriority.UseBorderColor = False
        Me.lblJanT.StylePriority.UseBorders = False
        Me.lblJanT.StylePriority.UseFont = False
        Me.lblJanT.StylePriority.UseForeColor = False
        Me.lblJanT.StylePriority.UseTextAlignment = False
        Me.lblJanT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblJanT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'rptFinancialPlan
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter})
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
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYear As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cbx1st As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbx2nd As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents lblTotalH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJunH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMayH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAprH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMarH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFebH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJanH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJun As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblApr As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMar As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFeb As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJan As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJunT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMayT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAprT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMarT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFebT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblJanT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheckedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblApprovedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel46 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPreparedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
