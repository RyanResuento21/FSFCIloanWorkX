<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptSalaryLoanPayment
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
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNMA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPayor = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancialH = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lblNMAT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBalanceT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAmount, Me.lblNMA, Me.lblBalance, Me.lblPayor, Me.lblAccountNumber})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.lblAmount.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 0.0!)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblAmount.StylePriority.UseBackColor = False
        Me.lblAmount.StylePriority.UseBorderColor = False
        Me.lblAmount.StylePriority.UseBorders = False
        Me.lblAmount.StylePriority.UseFont = False
        Me.lblAmount.StylePriority.UseForeColor = False
        Me.lblAmount.StylePriority.UseTextAlignment = False
        Me.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblNMA
        '
        Me.lblNMA.BackColor = System.Drawing.Color.White
        Me.lblNMA.BorderColor = System.Drawing.Color.Black
        Me.lblNMA.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNMA.CanGrow = False
        Me.lblNMA.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNMA.ForeColor = System.Drawing.Color.Black
        Me.lblNMA.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0.0!)
        Me.lblNMA.Name = "lblNMA"
        Me.lblNMA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNMA.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblNMA.StylePriority.UseBackColor = False
        Me.lblNMA.StylePriority.UseBorderColor = False
        Me.lblNMA.StylePriority.UseBorders = False
        Me.lblNMA.StylePriority.UseFont = False
        Me.lblNMA.StylePriority.UseForeColor = False
        Me.lblNMA.StylePriority.UseTextAlignment = False
        Me.lblNMA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblNMA.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBalance
        '
        Me.lblBalance.BackColor = System.Drawing.Color.White
        Me.lblBalance.BorderColor = System.Drawing.Color.Black
        Me.lblBalance.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBalance.CanGrow = False
        Me.lblBalance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.ForeColor = System.Drawing.Color.Black
        Me.lblBalance.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0.0!)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBalance.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblBalance.StylePriority.UseBackColor = False
        Me.lblBalance.StylePriority.UseBorderColor = False
        Me.lblBalance.StylePriority.UseBorders = False
        Me.lblBalance.StylePriority.UseFont = False
        Me.lblBalance.StylePriority.UseForeColor = False
        Me.lblBalance.StylePriority.UseTextAlignment = False
        Me.lblBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBalance.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPayor
        '
        Me.lblPayor.BackColor = System.Drawing.Color.White
        Me.lblPayor.BorderColor = System.Drawing.Color.Black
        Me.lblPayor.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPayor.CanGrow = False
        Me.lblPayor.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayor.ForeColor = System.Drawing.Color.Black
        Me.lblPayor.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblPayor.Name = "lblPayor"
        Me.lblPayor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPayor.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblPayor.StylePriority.UseBackColor = False
        Me.lblPayor.StylePriority.UseBorderColor = False
        Me.lblPayor.StylePriority.UseBorders = False
        Me.lblPayor.StylePriority.UseFont = False
        Me.lblPayor.StylePriority.UseForeColor = False
        Me.lblPayor.StylePriority.UseTextAlignment = False
        Me.lblPayor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.lblBranch, Me.lblAccountH, Me.XrLabel4, Me.XrLabel5, Me.XrLabel6, Me.lblTitle, Me.lblAsOf, Me.lblFinancialH})
        Me.PageHeader.HeightF = 105.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.White
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.Black
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(90.0!, 25.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Branch :"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.Color.White
        Me.lblBranch.BorderColor = System.Drawing.Color.Black
        Me.lblBranch.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblBranch.CanGrow = False
        Me.lblBranch.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.Color.Black
        Me.lblBranch.LocationFloat = New DevExpress.Utils.PointFloat(90.0!, 40.0!)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBranch.SizeF = New System.Drawing.SizeF(250.0!, 25.0!)
        Me.lblBranch.StylePriority.UseBackColor = False
        Me.lblBranch.StylePriority.UseBorderColor = False
        Me.lblBranch.StylePriority.UseBorders = False
        Me.lblBranch.StylePriority.UseFont = False
        Me.lblBranch.StylePriority.UseForeColor = False
        Me.lblBranch.StylePriority.UseTextAlignment = False
        Me.lblBranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 70.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(400.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Payor"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 70.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Balance"
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 70.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "NMA"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.White
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 70.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Amount"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.00002384186!, 2.499994!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Salary Loan Billing Statement"
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
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 22.5!)
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
        'lblFinancialH
        '
        Me.lblFinancialH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFinancialH.BorderColor = System.Drawing.Color.Black
        Me.lblFinancialH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancialH.CanGrow = False
        Me.lblFinancialH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancialH.ForeColor = System.Drawing.Color.White
        Me.lblFinancialH.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 70.0!)
        Me.lblFinancialH.Name = "lblFinancialH"
        Me.lblFinancialH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancialH.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.lblFinancialH.StylePriority.UseBackColor = False
        Me.lblFinancialH.StylePriority.UseBorderColor = False
        Me.lblFinancialH.StylePriority.UseBorders = False
        Me.lblFinancialH.StylePriority.UseFont = False
        Me.lblFinancialH.StylePriority.UseForeColor = False
        Me.lblFinancialH.StylePriority.UseTextAlignment = False
        Me.lblFinancialH.Text = "Account Number"
        Me.lblFinancialH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(399.9997!, 0.0!)
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
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblNMAT, Me.lblBalanceT, Me.XrLabel19, Me.XrLine2})
        Me.ReportFooter.HeightF = 30.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblNMAT
        '
        Me.lblNMAT.BackColor = System.Drawing.Color.White
        Me.lblNMAT.BorderColor = System.Drawing.Color.Black
        Me.lblNMAT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNMAT.CanGrow = False
        Me.lblNMAT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNMAT.ForeColor = System.Drawing.Color.Black
        Me.lblNMAT.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0.0!)
        Me.lblNMAT.Name = "lblNMAT"
        Me.lblNMAT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNMAT.SizeF = New System.Drawing.SizeF(99.99994!, 20.0!)
        Me.lblNMAT.StylePriority.UseBackColor = False
        Me.lblNMAT.StylePriority.UseBorderColor = False
        Me.lblNMAT.StylePriority.UseBorders = False
        Me.lblNMAT.StylePriority.UseFont = False
        Me.lblNMAT.StylePriority.UseForeColor = False
        Me.lblNMAT.StylePriority.UseTextAlignment = False
        Me.lblNMAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblNMAT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBalanceT
        '
        Me.lblBalanceT.BackColor = System.Drawing.Color.White
        Me.lblBalanceT.BorderColor = System.Drawing.Color.Black
        Me.lblBalanceT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBalanceT.CanGrow = False
        Me.lblBalanceT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceT.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceT.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0.0!)
        Me.lblBalanceT.Name = "lblBalanceT"
        Me.lblBalanceT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBalanceT.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblBalanceT.StylePriority.UseBackColor = False
        Me.lblBalanceT.StylePriority.UseBorderColor = False
        Me.lblBalanceT.StylePriority.UseBorders = False
        Me.lblBalanceT.StylePriority.UseFont = False
        Me.lblBalanceT.StylePriority.UseForeColor = False
        Me.lblBalanceT.StylePriority.UseTextAlignment = False
        Me.lblBalanceT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBalanceT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel19
        '
        Me.XrLabel19.BackColor = System.Drawing.Color.White
        Me.XrLabel19.BorderColor = System.Drawing.Color.Black
        Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.XrLabel19.CanGrow = False
        Me.XrLabel19.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel19.ForeColor = System.Drawing.Color.Black
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(699.9999!, 0.0!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(99.99982!, 20.0!)
        Me.XrLabel19.StylePriority.UseBackColor = False
        Me.XrLabel19.StylePriority.UseBorderColor = False
        Me.XrLabel19.StylePriority.UseBorders = False
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.StylePriority.UseForeColor = False
        Me.XrLabel19.StylePriority.UseTextAlignment = False
        Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLine2
        '
        Me.XrLine2.BorderColor = System.Drawing.Color.Black
        Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrLine2.BorderWidth = 3.0!
        Me.XrLine2.ForeColor = System.Drawing.Color.Black
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(800.0!, 10.0!)
        Me.XrLine2.StylePriority.UseBorderColor = False
        Me.XrLine2.StylePriority.UseBorders = False
        Me.XrLine2.StylePriority.UseBorderWidth = False
        Me.XrLine2.StylePriority.UseForeColor = False
        '
        'rptSalaryLoanPayment
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNMA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPayor As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancialH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents lblNMAT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBalanceT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
