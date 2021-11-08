<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptDeliquencyReport
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
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblInterest = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLastTransaction = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDaysPastDue = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMissedA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalAD = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestAD = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalAD = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotaLPAR = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestPAR = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalPAR = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLoanAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateMaturity = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateGranted = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPN = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFSFC = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.lblBorrowerH = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLoanAmountT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalPART = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestPART = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotaLPART = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalADT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestADT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalADT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblInterest, Me.lblLastTransaction, Me.lblDaysPastDue, Me.lblMissedA, Me.lblTotalAD, Me.lblInterestAD, Me.lblPrincipalAD, Me.lblTotaLPAR, Me.lblInterestPAR, Me.lblPrincipalPAR, Me.lblLoanAmount, Me.lblDateMaturity, Me.lblDateGranted, Me.lblPN, Me.lblBorrower})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblInterest
        '
        Me.lblInterest.BackColor = System.Drawing.Color.White
        Me.lblInterest.BorderColor = System.Drawing.Color.Black
        Me.lblInterest.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterest.CanGrow = False
        Me.lblInterest.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest.ForeColor = System.Drawing.Color.Black
        Me.lblInterest.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 0.0!)
        Me.lblInterest.Name = "lblInterest"
        Me.lblInterest.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterest.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblInterest.StylePriority.UseBackColor = False
        Me.lblInterest.StylePriority.UseBorderColor = False
        Me.lblInterest.StylePriority.UseBorders = False
        Me.lblInterest.StylePriority.UseFont = False
        Me.lblInterest.StylePriority.UseForeColor = False
        Me.lblInterest.StylePriority.UseTextAlignment = False
        Me.lblInterest.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblLastTransaction
        '
        Me.lblLastTransaction.BackColor = System.Drawing.Color.White
        Me.lblLastTransaction.BorderColor = System.Drawing.Color.Black
        Me.lblLastTransaction.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblLastTransaction.CanGrow = False
        Me.lblLastTransaction.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastTransaction.ForeColor = System.Drawing.Color.Black
        Me.lblLastTransaction.LocationFloat = New DevExpress.Utils.PointFloat(990.0!, 0.0!)
        Me.lblLastTransaction.Name = "lblLastTransaction"
        Me.lblLastTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLastTransaction.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblLastTransaction.StylePriority.UseBackColor = False
        Me.lblLastTransaction.StylePriority.UseBorderColor = False
        Me.lblLastTransaction.StylePriority.UseBorders = False
        Me.lblLastTransaction.StylePriority.UseFont = False
        Me.lblLastTransaction.StylePriority.UseForeColor = False
        Me.lblLastTransaction.StylePriority.UseTextAlignment = False
        Me.lblLastTransaction.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblLastTransaction.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblDaysPastDue
        '
        Me.lblDaysPastDue.BackColor = System.Drawing.Color.White
        Me.lblDaysPastDue.BorderColor = System.Drawing.Color.Black
        Me.lblDaysPastDue.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDaysPastDue.CanGrow = False
        Me.lblDaysPastDue.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaysPastDue.ForeColor = System.Drawing.Color.Black
        Me.lblDaysPastDue.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 0.0!)
        Me.lblDaysPastDue.Name = "lblDaysPastDue"
        Me.lblDaysPastDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDaysPastDue.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblDaysPastDue.StylePriority.UseBackColor = False
        Me.lblDaysPastDue.StylePriority.UseBorderColor = False
        Me.lblDaysPastDue.StylePriority.UseBorders = False
        Me.lblDaysPastDue.StylePriority.UseFont = False
        Me.lblDaysPastDue.StylePriority.UseForeColor = False
        Me.lblDaysPastDue.StylePriority.UseTextAlignment = False
        Me.lblDaysPastDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMissedA
        '
        Me.lblMissedA.BackColor = System.Drawing.Color.White
        Me.lblMissedA.BorderColor = System.Drawing.Color.Black
        Me.lblMissedA.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMissedA.CanGrow = False
        Me.lblMissedA.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMissedA.ForeColor = System.Drawing.Color.Black
        Me.lblMissedA.LocationFloat = New DevExpress.Utils.PointFloat(870.0!, 0.0!)
        Me.lblMissedA.Name = "lblMissedA"
        Me.lblMissedA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMissedA.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblMissedA.StylePriority.UseBackColor = False
        Me.lblMissedA.StylePriority.UseBorderColor = False
        Me.lblMissedA.StylePriority.UseBorders = False
        Me.lblMissedA.StylePriority.UseFont = False
        Me.lblMissedA.StylePriority.UseForeColor = False
        Me.lblMissedA.StylePriority.UseTextAlignment = False
        Me.lblMissedA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTotalAD
        '
        Me.lblTotalAD.BackColor = System.Drawing.Color.White
        Me.lblTotalAD.BorderColor = System.Drawing.Color.Black
        Me.lblTotalAD.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalAD.CanGrow = False
        Me.lblTotalAD.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAD.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAD.LocationFloat = New DevExpress.Utils.PointFloat(805.0!, 0.0!)
        Me.lblTotalAD.Name = "lblTotalAD"
        Me.lblTotalAD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalAD.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblTotalAD.StylePriority.UseBackColor = False
        Me.lblTotalAD.StylePriority.UseBorderColor = False
        Me.lblTotalAD.StylePriority.UseBorders = False
        Me.lblTotalAD.StylePriority.UseFont = False
        Me.lblTotalAD.StylePriority.UseForeColor = False
        Me.lblTotalAD.StylePriority.UseTextAlignment = False
        Me.lblTotalAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotalAD.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestAD
        '
        Me.lblInterestAD.BackColor = System.Drawing.Color.White
        Me.lblInterestAD.BorderColor = System.Drawing.Color.Black
        Me.lblInterestAD.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestAD.CanGrow = False
        Me.lblInterestAD.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestAD.ForeColor = System.Drawing.Color.Black
        Me.lblInterestAD.LocationFloat = New DevExpress.Utils.PointFloat(740.0!, 0.0!)
        Me.lblInterestAD.Name = "lblInterestAD"
        Me.lblInterestAD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestAD.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblInterestAD.StylePriority.UseBackColor = False
        Me.lblInterestAD.StylePriority.UseBorderColor = False
        Me.lblInterestAD.StylePriority.UseBorders = False
        Me.lblInterestAD.StylePriority.UseFont = False
        Me.lblInterestAD.StylePriority.UseForeColor = False
        Me.lblInterestAD.StylePriority.UseTextAlignment = False
        Me.lblInterestAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestAD.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipalAD
        '
        Me.lblPrincipalAD.BackColor = System.Drawing.Color.White
        Me.lblPrincipalAD.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalAD.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipalAD.CanGrow = False
        Me.lblPrincipalAD.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalAD.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalAD.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 0.0!)
        Me.lblPrincipalAD.Name = "lblPrincipalAD"
        Me.lblPrincipalAD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalAD.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblPrincipalAD.StylePriority.UseBackColor = False
        Me.lblPrincipalAD.StylePriority.UseBorderColor = False
        Me.lblPrincipalAD.StylePriority.UseBorders = False
        Me.lblPrincipalAD.StylePriority.UseFont = False
        Me.lblPrincipalAD.StylePriority.UseForeColor = False
        Me.lblPrincipalAD.StylePriority.UseTextAlignment = False
        Me.lblPrincipalAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipalAD.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblTotaLPAR
        '
        Me.lblTotaLPAR.BackColor = System.Drawing.Color.White
        Me.lblTotaLPAR.BorderColor = System.Drawing.Color.Black
        Me.lblTotaLPAR.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotaLPAR.CanGrow = False
        Me.lblTotaLPAR.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaLPAR.ForeColor = System.Drawing.Color.Black
        Me.lblTotaLPAR.LocationFloat = New DevExpress.Utils.PointFloat(610.0!, 0.0!)
        Me.lblTotaLPAR.Name = "lblTotaLPAR"
        Me.lblTotaLPAR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotaLPAR.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblTotaLPAR.StylePriority.UseBackColor = False
        Me.lblTotaLPAR.StylePriority.UseBorderColor = False
        Me.lblTotaLPAR.StylePriority.UseBorders = False
        Me.lblTotaLPAR.StylePriority.UseFont = False
        Me.lblTotaLPAR.StylePriority.UseForeColor = False
        Me.lblTotaLPAR.StylePriority.UseTextAlignment = False
        Me.lblTotaLPAR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotaLPAR.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestPAR
        '
        Me.lblInterestPAR.BackColor = System.Drawing.Color.White
        Me.lblInterestPAR.BorderColor = System.Drawing.Color.Black
        Me.lblInterestPAR.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestPAR.CanGrow = False
        Me.lblInterestPAR.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestPAR.ForeColor = System.Drawing.Color.Black
        Me.lblInterestPAR.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 0.0!)
        Me.lblInterestPAR.Name = "lblInterestPAR"
        Me.lblInterestPAR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestPAR.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblInterestPAR.StylePriority.UseBackColor = False
        Me.lblInterestPAR.StylePriority.UseBorderColor = False
        Me.lblInterestPAR.StylePriority.UseBorders = False
        Me.lblInterestPAR.StylePriority.UseFont = False
        Me.lblInterestPAR.StylePriority.UseForeColor = False
        Me.lblInterestPAR.StylePriority.UseTextAlignment = False
        Me.lblInterestPAR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestPAR.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipalPAR
        '
        Me.lblPrincipalPAR.BackColor = System.Drawing.Color.White
        Me.lblPrincipalPAR.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalPAR.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipalPAR.CanGrow = False
        Me.lblPrincipalPAR.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalPAR.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalPAR.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 0.0!)
        Me.lblPrincipalPAR.Name = "lblPrincipalPAR"
        Me.lblPrincipalPAR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalPAR.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblPrincipalPAR.StylePriority.UseBackColor = False
        Me.lblPrincipalPAR.StylePriority.UseBorderColor = False
        Me.lblPrincipalPAR.StylePriority.UseBorders = False
        Me.lblPrincipalPAR.StylePriority.UseFont = False
        Me.lblPrincipalPAR.StylePriority.UseForeColor = False
        Me.lblPrincipalPAR.StylePriority.UseTextAlignment = False
        Me.lblPrincipalPAR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipalPAR.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblLoanAmount
        '
        Me.lblLoanAmount.BackColor = System.Drawing.Color.White
        Me.lblLoanAmount.BorderColor = System.Drawing.Color.Black
        Me.lblLoanAmount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblLoanAmount.CanGrow = False
        Me.lblLoanAmount.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanAmount.ForeColor = System.Drawing.Color.Black
        Me.lblLoanAmount.LocationFloat = New DevExpress.Utils.PointFloat(415.0!, 0.0!)
        Me.lblLoanAmount.Name = "lblLoanAmount"
        Me.lblLoanAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLoanAmount.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblLoanAmount.StylePriority.UseBackColor = False
        Me.lblLoanAmount.StylePriority.UseBorderColor = False
        Me.lblLoanAmount.StylePriority.UseBorders = False
        Me.lblLoanAmount.StylePriority.UseFont = False
        Me.lblLoanAmount.StylePriority.UseForeColor = False
        Me.lblLoanAmount.StylePriority.UseTextAlignment = False
        Me.lblLoanAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblLoanAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDateMaturity
        '
        Me.lblDateMaturity.BackColor = System.Drawing.Color.White
        Me.lblDateMaturity.BorderColor = System.Drawing.Color.Black
        Me.lblDateMaturity.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDateMaturity.CanGrow = False
        Me.lblDateMaturity.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateMaturity.ForeColor = System.Drawing.Color.Black
        Me.lblDateMaturity.LocationFloat = New DevExpress.Utils.PointFloat(280.0!, 0.0!)
        Me.lblDateMaturity.Name = "lblDateMaturity"
        Me.lblDateMaturity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateMaturity.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblDateMaturity.StylePriority.UseBackColor = False
        Me.lblDateMaturity.StylePriority.UseBorderColor = False
        Me.lblDateMaturity.StylePriority.UseBorders = False
        Me.lblDateMaturity.StylePriority.UseFont = False
        Me.lblDateMaturity.StylePriority.UseForeColor = False
        Me.lblDateMaturity.StylePriority.UseTextAlignment = False
        Me.lblDateMaturity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDateMaturity.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblDateGranted
        '
        Me.lblDateGranted.BackColor = System.Drawing.Color.White
        Me.lblDateGranted.BorderColor = System.Drawing.Color.Black
        Me.lblDateGranted.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDateGranted.CanGrow = False
        Me.lblDateGranted.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateGranted.ForeColor = System.Drawing.Color.Black
        Me.lblDateGranted.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 0.0!)
        Me.lblDateGranted.Name = "lblDateGranted"
        Me.lblDateGranted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateGranted.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblDateGranted.StylePriority.UseBackColor = False
        Me.lblDateGranted.StylePriority.UseBorderColor = False
        Me.lblDateGranted.StylePriority.UseBorders = False
        Me.lblDateGranted.StylePriority.UseFont = False
        Me.lblDateGranted.StylePriority.UseForeColor = False
        Me.lblDateGranted.StylePriority.UseTextAlignment = False
        Me.lblDateGranted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDateGranted.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblPN
        '
        Me.lblPN.BackColor = System.Drawing.Color.White
        Me.lblPN.BorderColor = System.Drawing.Color.Black
        Me.lblPN.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPN.CanGrow = False
        Me.lblPN.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPN.ForeColor = System.Drawing.Color.Black
        Me.lblPN.LocationFloat = New DevExpress.Utils.PointFloat(140.0!, 0.0!)
        Me.lblPN.Name = "lblPN"
        Me.lblPN.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPN.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblPN.StylePriority.UseBackColor = False
        Me.lblPN.StylePriority.UseBorderColor = False
        Me.lblPN.StylePriority.UseBorders = False
        Me.lblPN.StylePriority.UseFont = False
        Me.lblPN.StylePriority.UseForeColor = False
        Me.lblPN.StylePriority.UseTextAlignment = False
        Me.lblPN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
        Me.lblBorrower.StylePriority.UseBackColor = False
        Me.lblBorrower.StylePriority.UseBorderColor = False
        Me.lblBorrower.StylePriority.UseBorders = False
        Me.lblBorrower.StylePriority.UseFont = False
        Me.lblBorrower.StylePriority.UseForeColor = False
        Me.lblBorrower.StylePriority.UseTextAlignment = False
        Me.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAsOf, Me.lblTitle, Me.lblBranch, Me.lblFSFC})
        Me.ReportHeader.HeightF = 70.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 55.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(1050.0!, 15.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "As Of June 30, 2020"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(1050.0!, 15.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "DELIQUENCY REPORT / PORTOLIO-AT-RISK REPORT"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.Color.White
        Me.lblBranch.BorderColor = System.Drawing.Color.Black
        Me.lblBranch.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBranch.CanGrow = False
        Me.lblBranch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.Color.Black
        Me.lblBranch.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBranch.SizeF = New System.Drawing.SizeF(1050.0!, 15.0!)
        Me.lblBranch.StylePriority.UseBackColor = False
        Me.lblBranch.StylePriority.UseBorderColor = False
        Me.lblBranch.StylePriority.UseBorders = False
        Me.lblBranch.StylePriority.UseFont = False
        Me.lblBranch.StylePriority.UseForeColor = False
        Me.lblBranch.StylePriority.UseTextAlignment = False
        Me.lblBranch.Text = "ILOILO BRANCH"
        Me.lblBranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFSFC
        '
        Me.lblFSFC.BackColor = System.Drawing.Color.White
        Me.lblFSFC.BorderColor = System.Drawing.Color.Black
        Me.lblFSFC.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblFSFC.CanGrow = False
        Me.lblFSFC.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFSFC.ForeColor = System.Drawing.Color.Black
        Me.lblFSFC.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblFSFC.Name = "lblFSFC"
        Me.lblFSFC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFSFC.SizeF = New System.Drawing.SizeF(1050.0!, 20.0!)
        Me.lblFSFC.StylePriority.UseBackColor = False
        Me.lblFSFC.StylePriority.UseBorderColor = False
        Me.lblFSFC.StylePriority.UseBorders = False
        Me.lblFSFC.StylePriority.UseFont = False
        Me.lblFSFC.StylePriority.UseForeColor = False
        Me.lblFSFC.StylePriority.UseTextAlignment = False
        Me.lblFSFC.Text = "FIRST STANDARD FINANCE CORPORATION"
        Me.lblFSFC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel16, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel8, Me.XrLabel9, Me.XrLabel10, Me.XrLabel11, Me.XrLabel5, Me.XrLabel6, Me.XrLabel15, Me.XrLabel7, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.XrLabel3, Me.lblAccountH})
        Me.PageHeader.HeightF = 35.00001!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel16
        '
        Me.XrLabel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel16.BorderColor = System.Drawing.Color.Black
        Me.XrLabel16.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel16.CanGrow = False
        Me.XrLabel16.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel16.ForeColor = System.Drawing.Color.White
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 0.0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel16.StylePriority.UseBackColor = False
        Me.XrLabel16.StylePriority.UseBorderColor = False
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UseForeColor = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.Text = "Term / Interest Rate"
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.White
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(990.0!, 0.0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(60.0!, 35.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Last Transaction"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.White
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 0.0!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(60.0!, 35.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "No of Days Past Due"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.White
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(870.0!, 0.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(60.0!, 35.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "No of Missed Amortization"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(740.0!, 14.99999!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Interest"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 0.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(195.0!, 15.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Amortization Due"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 14.99999!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Principal"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(805.0!, 14.99999!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "TOTAL"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(610.0!, 14.99999!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "TOTAL"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.White
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 14.99999!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Principal"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel15
        '
        Me.XrLabel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel15.BorderColor = System.Drawing.Color.Black
        Me.XrLabel15.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.ForeColor = System.Drawing.Color.White
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 0.0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(195.0!, 15.0!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Portfolio at Risk"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.White
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 14.99999!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Interest"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(415.0!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Amount of Loan"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(280.0!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Date Maturity"
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
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Date Granted"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(140.0!, 0.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "PN Number"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(140.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Borrower"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
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
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblBorrowerH})
        Me.GroupHeader1.HeightF = 20.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblBorrowerH
        '
        Me.lblBorrowerH.BackColor = System.Drawing.Color.White
        Me.lblBorrowerH.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrowerH.CanGrow = False
        Me.lblBorrowerH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerH.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblBorrowerH.Name = "lblBorrowerH"
        Me.lblBorrowerH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerH.SizeF = New System.Drawing.SizeF(1050.0!, 20.0!)
        Me.lblBorrowerH.StylePriority.UseBackColor = False
        Me.lblBorrowerH.StylePriority.UseBorderColor = False
        Me.lblBorrowerH.StylePriority.UseBorders = False
        Me.lblBorrowerH.StylePriority.UseFont = False
        Me.lblBorrowerH.StylePriority.UseForeColor = False
        Me.lblBorrowerH.StylePriority.UseTextAlignment = False
        Me.lblBorrowerH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel18, Me.XrLabel29, Me.XrLabel30, Me.XrLabel31, Me.XrLabel32, Me.lblLoanAmountT, Me.lblPrincipalPART, Me.lblInterestPART, Me.lblTotaLPART, Me.lblPrincipalADT, Me.lblInterestADT, Me.lblTotalADT, Me.XrLabel40, Me.XrLabel41, Me.XrLabel42})
        Me.GroupFooter1.HeightF = 20.00001!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'XrLabel18
        '
        Me.XrLabel18.BackColor = System.Drawing.Color.White
        Me.XrLabel18.BorderColor = System.Drawing.Color.Black
        Me.XrLabel18.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel18.CanGrow = False
        Me.XrLabel18.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.ForeColor = System.Drawing.Color.Black
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 0.0!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel18.StylePriority.UseBackColor = False
        Me.XrLabel18.StylePriority.UseBorderColor = False
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.StylePriority.UseForeColor = False
        Me.XrLabel18.StylePriority.UseTextAlignment = False
        Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel29
        '
        Me.XrLabel29.BackColor = System.Drawing.Color.White
        Me.XrLabel29.BorderColor = System.Drawing.Color.Black
        Me.XrLabel29.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel29.CanGrow = False
        Me.XrLabel29.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel29.ForeColor = System.Drawing.Color.Black
        Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.00000667572!)
        Me.XrLabel29.Name = "XrLabel29"
        Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel29.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
        Me.XrLabel29.StylePriority.UseBackColor = False
        Me.XrLabel29.StylePriority.UseBorderColor = False
        Me.XrLabel29.StylePriority.UseBorders = False
        Me.XrLabel29.StylePriority.UseFont = False
        Me.XrLabel29.StylePriority.UseForeColor = False
        Me.XrLabel29.StylePriority.UseTextAlignment = False
        Me.XrLabel29.Text = "TOTAL"
        Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel30
        '
        Me.XrLabel30.BackColor = System.Drawing.Color.White
        Me.XrLabel30.BorderColor = System.Drawing.Color.Black
        Me.XrLabel30.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel30.CanGrow = False
        Me.XrLabel30.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel30.ForeColor = System.Drawing.Color.Black
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(140.0!, 0.00000667572!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.XrLabel30.StylePriority.UseBackColor = False
        Me.XrLabel30.StylePriority.UseBorderColor = False
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.StylePriority.UseFont = False
        Me.XrLabel30.StylePriority.UseForeColor = False
        Me.XrLabel30.StylePriority.UseTextAlignment = False
        Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel31
        '
        Me.XrLabel31.BackColor = System.Drawing.Color.White
        Me.XrLabel31.BorderColor = System.Drawing.Color.Black
        Me.XrLabel31.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel31.CanGrow = False
        Me.XrLabel31.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel31.ForeColor = System.Drawing.Color.Black
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(210.0!, 0.00000667572!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.XrLabel31.StylePriority.UseBackColor = False
        Me.XrLabel31.StylePriority.UseBorderColor = False
        Me.XrLabel31.StylePriority.UseBorders = False
        Me.XrLabel31.StylePriority.UseFont = False
        Me.XrLabel31.StylePriority.UseForeColor = False
        Me.XrLabel31.StylePriority.UseTextAlignment = False
        Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel32
        '
        Me.XrLabel32.BackColor = System.Drawing.Color.White
        Me.XrLabel32.BorderColor = System.Drawing.Color.Black
        Me.XrLabel32.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel32.CanGrow = False
        Me.XrLabel32.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel32.ForeColor = System.Drawing.Color.Black
        Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(280.0!, 0.00000667572!)
        Me.XrLabel32.Name = "XrLabel32"
        Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel32.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.XrLabel32.StylePriority.UseBackColor = False
        Me.XrLabel32.StylePriority.UseBorderColor = False
        Me.XrLabel32.StylePriority.UseBorders = False
        Me.XrLabel32.StylePriority.UseFont = False
        Me.XrLabel32.StylePriority.UseForeColor = False
        Me.XrLabel32.StylePriority.UseTextAlignment = False
        Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblLoanAmountT
        '
        Me.lblLoanAmountT.BackColor = System.Drawing.Color.White
        Me.lblLoanAmountT.BorderColor = System.Drawing.Color.Black
        Me.lblLoanAmountT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblLoanAmountT.CanGrow = False
        Me.lblLoanAmountT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanAmountT.ForeColor = System.Drawing.Color.Black
        Me.lblLoanAmountT.LocationFloat = New DevExpress.Utils.PointFloat(415.0!, 0.00000667572!)
        Me.lblLoanAmountT.Name = "lblLoanAmountT"
        Me.lblLoanAmountT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLoanAmountT.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblLoanAmountT.StylePriority.UseBackColor = False
        Me.lblLoanAmountT.StylePriority.UseBorderColor = False
        Me.lblLoanAmountT.StylePriority.UseBorders = False
        Me.lblLoanAmountT.StylePriority.UseFont = False
        Me.lblLoanAmountT.StylePriority.UseForeColor = False
        Me.lblLoanAmountT.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:n2}"
        XrSummary1.IgnoreNullValues = True
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblLoanAmountT.Summary = XrSummary1
        Me.lblLoanAmountT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblLoanAmountT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipalPART
        '
        Me.lblPrincipalPART.BackColor = System.Drawing.Color.White
        Me.lblPrincipalPART.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalPART.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipalPART.CanGrow = False
        Me.lblPrincipalPART.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalPART.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalPART.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 0.00000667572!)
        Me.lblPrincipalPART.Name = "lblPrincipalPART"
        Me.lblPrincipalPART.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalPART.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblPrincipalPART.StylePriority.UseBackColor = False
        Me.lblPrincipalPART.StylePriority.UseBorderColor = False
        Me.lblPrincipalPART.StylePriority.UseBorders = False
        Me.lblPrincipalPART.StylePriority.UseFont = False
        Me.lblPrincipalPART.StylePriority.UseForeColor = False
        Me.lblPrincipalPART.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:n2}"
        XrSummary2.IgnoreNullValues = True
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblPrincipalPART.Summary = XrSummary2
        Me.lblPrincipalPART.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipalPART.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestPART
        '
        Me.lblInterestPART.BackColor = System.Drawing.Color.White
        Me.lblInterestPART.BorderColor = System.Drawing.Color.Black
        Me.lblInterestPART.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestPART.CanGrow = False
        Me.lblInterestPART.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestPART.ForeColor = System.Drawing.Color.Black
        Me.lblInterestPART.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 0.00000667572!)
        Me.lblInterestPART.Name = "lblInterestPART"
        Me.lblInterestPART.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestPART.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblInterestPART.StylePriority.UseBackColor = False
        Me.lblInterestPART.StylePriority.UseBorderColor = False
        Me.lblInterestPART.StylePriority.UseBorders = False
        Me.lblInterestPART.StylePriority.UseFont = False
        Me.lblInterestPART.StylePriority.UseForeColor = False
        Me.lblInterestPART.StylePriority.UseTextAlignment = False
        XrSummary3.FormatString = "{0:n2}"
        XrSummary3.IgnoreNullValues = True
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblInterestPART.Summary = XrSummary3
        Me.lblInterestPART.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestPART.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblTotaLPART
        '
        Me.lblTotaLPART.BackColor = System.Drawing.Color.White
        Me.lblTotaLPART.BorderColor = System.Drawing.Color.Black
        Me.lblTotaLPART.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotaLPART.CanGrow = False
        Me.lblTotaLPART.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaLPART.ForeColor = System.Drawing.Color.Black
        Me.lblTotaLPART.LocationFloat = New DevExpress.Utils.PointFloat(610.0!, 0.00000667572!)
        Me.lblTotaLPART.Name = "lblTotaLPART"
        Me.lblTotaLPART.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotaLPART.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblTotaLPART.StylePriority.UseBackColor = False
        Me.lblTotaLPART.StylePriority.UseBorderColor = False
        Me.lblTotaLPART.StylePriority.UseBorders = False
        Me.lblTotaLPART.StylePriority.UseFont = False
        Me.lblTotaLPART.StylePriority.UseForeColor = False
        Me.lblTotaLPART.StylePriority.UseTextAlignment = False
        XrSummary4.FormatString = "{0:n2}"
        XrSummary4.IgnoreNullValues = True
        XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblTotaLPART.Summary = XrSummary4
        Me.lblTotaLPART.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotaLPART.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipalADT
        '
        Me.lblPrincipalADT.BackColor = System.Drawing.Color.White
        Me.lblPrincipalADT.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalADT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipalADT.CanGrow = False
        Me.lblPrincipalADT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalADT.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalADT.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 0.00000667572!)
        Me.lblPrincipalADT.Name = "lblPrincipalADT"
        Me.lblPrincipalADT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalADT.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblPrincipalADT.StylePriority.UseBackColor = False
        Me.lblPrincipalADT.StylePriority.UseBorderColor = False
        Me.lblPrincipalADT.StylePriority.UseBorders = False
        Me.lblPrincipalADT.StylePriority.UseFont = False
        Me.lblPrincipalADT.StylePriority.UseForeColor = False
        Me.lblPrincipalADT.StylePriority.UseTextAlignment = False
        XrSummary5.FormatString = "{0:n2}"
        XrSummary5.IgnoreNullValues = True
        XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblPrincipalADT.Summary = XrSummary5
        Me.lblPrincipalADT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipalADT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestADT
        '
        Me.lblInterestADT.BackColor = System.Drawing.Color.White
        Me.lblInterestADT.BorderColor = System.Drawing.Color.Black
        Me.lblInterestADT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestADT.CanGrow = False
        Me.lblInterestADT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestADT.ForeColor = System.Drawing.Color.Black
        Me.lblInterestADT.LocationFloat = New DevExpress.Utils.PointFloat(740.0!, 0.0!)
        Me.lblInterestADT.Name = "lblInterestADT"
        Me.lblInterestADT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestADT.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblInterestADT.StylePriority.UseBackColor = False
        Me.lblInterestADT.StylePriority.UseBorderColor = False
        Me.lblInterestADT.StylePriority.UseBorders = False
        Me.lblInterestADT.StylePriority.UseFont = False
        Me.lblInterestADT.StylePriority.UseForeColor = False
        Me.lblInterestADT.StylePriority.UseTextAlignment = False
        XrSummary6.FormatString = "{0:n2}"
        XrSummary6.IgnoreNullValues = True
        XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblInterestADT.Summary = XrSummary6
        Me.lblInterestADT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestADT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblTotalADT
        '
        Me.lblTotalADT.BackColor = System.Drawing.Color.White
        Me.lblTotalADT.BorderColor = System.Drawing.Color.Black
        Me.lblTotalADT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalADT.CanGrow = False
        Me.lblTotalADT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalADT.ForeColor = System.Drawing.Color.Black
        Me.lblTotalADT.LocationFloat = New DevExpress.Utils.PointFloat(805.0!, 0.00000667572!)
        Me.lblTotalADT.Name = "lblTotalADT"
        Me.lblTotalADT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalADT.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblTotalADT.StylePriority.UseBackColor = False
        Me.lblTotalADT.StylePriority.UseBorderColor = False
        Me.lblTotalADT.StylePriority.UseBorders = False
        Me.lblTotalADT.StylePriority.UseFont = False
        Me.lblTotalADT.StylePriority.UseForeColor = False
        Me.lblTotalADT.StylePriority.UseTextAlignment = False
        XrSummary7.FormatString = "{0:n2}"
        XrSummary7.IgnoreNullValues = True
        XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblTotalADT.Summary = XrSummary7
        Me.lblTotalADT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotalADT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel40
        '
        Me.XrLabel40.BackColor = System.Drawing.Color.White
        Me.XrLabel40.BorderColor = System.Drawing.Color.Black
        Me.XrLabel40.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel40.CanGrow = False
        Me.XrLabel40.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel40.ForeColor = System.Drawing.Color.Black
        Me.XrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(870.0!, 0.00000667572!)
        Me.XrLabel40.Name = "XrLabel40"
        Me.XrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel40.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel40.StylePriority.UseBackColor = False
        Me.XrLabel40.StylePriority.UseBorderColor = False
        Me.XrLabel40.StylePriority.UseBorders = False
        Me.XrLabel40.StylePriority.UseFont = False
        Me.XrLabel40.StylePriority.UseForeColor = False
        Me.XrLabel40.StylePriority.UseTextAlignment = False
        Me.XrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel41
        '
        Me.XrLabel41.BackColor = System.Drawing.Color.White
        Me.XrLabel41.BorderColor = System.Drawing.Color.Black
        Me.XrLabel41.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel41.CanGrow = False
        Me.XrLabel41.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel41.ForeColor = System.Drawing.Color.Black
        Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 0.00000667572!)
        Me.XrLabel41.Name = "XrLabel41"
        Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel41.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel41.StylePriority.UseBackColor = False
        Me.XrLabel41.StylePriority.UseBorderColor = False
        Me.XrLabel41.StylePriority.UseBorders = False
        Me.XrLabel41.StylePriority.UseFont = False
        Me.XrLabel41.StylePriority.UseForeColor = False
        Me.XrLabel41.StylePriority.UseTextAlignment = False
        Me.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel42
        '
        Me.XrLabel42.BackColor = System.Drawing.Color.White
        Me.XrLabel42.BorderColor = System.Drawing.Color.Black
        Me.XrLabel42.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel42.CanGrow = False
        Me.XrLabel42.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel42.ForeColor = System.Drawing.Color.Black
        Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(990.0!, 0.00000667572!)
        Me.XrLabel42.Name = "XrLabel42"
        Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel42.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel42.StylePriority.UseBackColor = False
        Me.XrLabel42.StylePriority.UseBorderColor = False
        Me.XrLabel42.StylePriority.UseBorders = False
        Me.XrLabel42.StylePriority.UseFont = False
        Me.XrLabel42.StylePriority.UseForeColor = False
        Me.XrLabel42.StylePriority.UseTextAlignment = False
        Me.XrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rptDeliquencyReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.PageFooter, Me.GroupHeader1, Me.GroupFooter1})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFSFC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrowerH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLastTransaction As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDaysPastDue As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMissedA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalAD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestAD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalAD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotaLPAR As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestPAR As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalPAR As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLoanAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateMaturity As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateGranted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPN As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLoanAmountT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalPART As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestPART As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotaLPART As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalADT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestADT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalADT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel40 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterest As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
End Class
