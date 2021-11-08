<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptCreditReferralSlip
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
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.lblBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRemarks = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPreparedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel132 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel133 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel135 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRequestedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel136 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel131 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel122 = New DevExpress.XtraReports.UI.XRLabel()
        Me.subRpt_Closed = New DevExpress.XtraReports.UI.XRSubreport()
        Me.XrLabel123 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel124 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel125 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel126 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel127 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel128 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel129 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel130 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel121 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel120 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel119 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel114 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel115 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel116 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel117 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel118 = New DevExpress.XtraReports.UI.XRLabel()
        Me.subRpt_Active = New DevExpress.XtraReports.UI.XRSubreport()
        Me.XrLabel112 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel106 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPresentStatus = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLoanType = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDeliquency = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel109 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNumberLPC = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel111 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTerms = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel101 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel102 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel104 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNumberPayments = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPD = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel95 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel96 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUDI = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel98 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalAmountDue = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel93 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLPC = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel91 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel88 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestDue = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOutstanding = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel87 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel84 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRemarksScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel80 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel82 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalScoreT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCreditScoreT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel77 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCreditScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel79 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSettleScoreT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel73 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSettleScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel75 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPaymentScoreT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel69 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPaymentScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel71 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblHistoryScoreT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel65 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblHistoryScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel67 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel60 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTimeScore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel62 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTimeScoreT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel59 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel58 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel57 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel56 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOR_CR = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel55 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInsuranceCompany = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel51 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel52 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmountRenewal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel44 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel45 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmountPolicy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel47 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel49 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDatePolicy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel43 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateInsurance = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInsuranceInCharge = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel38 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_Insurance = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.cbxMonthly = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxBimonthly = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxWeekly = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxDaily = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthlyAmortization = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFaceAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateGranted = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDue = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCoMaker4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCoMaker3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCoMaker2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCoMaker1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocumentDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocumentNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0.0!
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTitle})
        Me.PageHeader.HeightF = 25.0!
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
        Me.lblTitle.Text = "Credit Referral Slip"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.lblBalance, Me.lblRemarks, Me.lblPreparedBy, Me.XrLabel132, Me.XrLabel133, Me.XrLabel135, Me.lblRequestedBy, Me.XrLabel136, Me.XrLabel131, Me.XrLabel122, Me.subRpt_Closed, Me.XrLabel123, Me.XrLabel124, Me.XrLabel125, Me.XrLabel126, Me.XrLabel127, Me.XrLabel128, Me.XrLabel129, Me.XrLabel130, Me.XrLabel121, Me.XrLabel120, Me.XrLabel119, Me.XrLabel114, Me.XrLabel115, Me.XrLabel116, Me.XrLabel117, Me.XrLabel118, Me.subRpt_Active, Me.XrLabel112, Me.XrLabel106, Me.lblPresentStatus, Me.lblLoanType, Me.lblDeliquency, Me.XrLabel109, Me.lblNumberLPC, Me.XrLabel111, Me.lblTerms, Me.XrLabel101, Me.XrLabel102, Me.lblPrincipalBalance, Me.XrLabel104, Me.lblNumberPayments, Me.lblRPPD, Me.XrLabel95, Me.XrLabel96, Me.lblUDI, Me.XrLabel98, Me.lblTotalAmountDue, Me.XrLabel93, Me.lblLPC, Me.XrLabel91, Me.XrLabel88, Me.lblInterestDue, Me.lblOutstanding, Me.XrLabel87, Me.XrLabel84, Me.lblRemarksScore, Me.XrLabel80, Me.lblTotalScore, Me.XrLabel82, Me.lblTotalScoreT, Me.lblCreditScoreT, Me.XrLabel77, Me.lblCreditScore, Me.XrLabel79, Me.lblSettleScoreT, Me.XrLabel73, Me.lblSettleScore, Me.XrLabel75, Me.lblPaymentScoreT, Me.XrLabel69, Me.lblPaymentScore, Me.XrLabel71, Me.lblHistoryScoreT, Me.XrLabel65, Me.lblHistoryScore, Me.XrLabel67, Me.XrLabel60, Me.lblTimeScore, Me.XrLabel62, Me.lblTimeScoreT, Me.XrLabel59, Me.XrLabel58, Me.XrLabel57, Me.XrLabel56, Me.lblOR_CR, Me.XrLabel55, Me.lblInsuranceCompany, Me.XrLabel51, Me.XrLabel52, Me.lblAmountRenewal, Me.XrLabel44, Me.XrLabel45, Me.lblAmountPolicy, Me.XrLabel47, Me.XrLabel49, Me.lblDatePolicy, Me.XrLabel43, Me.lblDateInsurance, Me.XrLabel42, Me.lblInsuranceInCharge, Me.XrLabel38, Me.lblAmount_Insurance, Me.XrLabel37, Me.XrLabel36, Me.XrLabel35, Me.XrLabel33, Me.txtAsOf, Me.cbxMonthly, Me.cbxBimonthly, Me.cbxWeekly, Me.cbxDaily, Me.XrLabel31, Me.lblMonthlyAmortization, Me.XrLabel29, Me.lblFaceAmount, Me.XrLabel27, Me.lblPrincipal, Me.XrLabel25, Me.lblDateGranted, Me.lblDue, Me.XrLabel24, Me.lblCoMaker4, Me.XrLabel22, Me.lblCoMaker3, Me.XrLabel20, Me.XrLabel17, Me.lblCoMaker2, Me.XrLabel15, Me.lblCoMaker1, Me.XrLabel13, Me.lblAccountNumber, Me.lblCollateral_7, Me.lblCollateral_6, Me.lblCollateral_5, Me.lblCollateral_4, Me.lblCollateral_3, Me.lblCollateral_2, Me.lblCollateral_1, Me.XrLabel6, Me.lblBorrower, Me.XrLabel2, Me.XrLabel3, Me.lblDocumentDate, Me.XrLabel5, Me.lblDocumentNumber})
        Me.GroupHeader1.HeightF = 955.0001!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(600.0005!, 935.0001!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(200.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblBalance
        '
        Me.lblBalance.BackColor = System.Drawing.Color.White
        Me.lblBalance.BorderColor = System.Drawing.Color.Black
        Me.lblBalance.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblBalance.CanGrow = False
        Me.lblBalance.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblBalance.ForeColor = System.Drawing.Color.Black
        Me.lblBalance.LocationFloat = New DevExpress.Utils.PointFloat(165.0003!, 208.9998!)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBalance.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblBalance.StylePriority.UseBackColor = False
        Me.lblBalance.StylePriority.UseBorderColor = False
        Me.lblBalance.StylePriority.UseBorders = False
        Me.lblBalance.StylePriority.UseFont = False
        Me.lblBalance.StylePriority.UseForeColor = False
        Me.lblBalance.StylePriority.UseTextAlignment = False
        Me.lblBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.White
        Me.lblRemarks.BorderColor = System.Drawing.Color.Black
        Me.lblRemarks.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblRemarks.CanGrow = False
        Me.lblRemarks.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 835.0!)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarks.SizeF = New System.Drawing.SizeF(800.0!, 40.0!)
        Me.lblRemarks.StylePriority.UseBackColor = False
        Me.lblRemarks.StylePriority.UseBorderColor = False
        Me.lblRemarks.StylePriority.UseBorders = False
        Me.lblRemarks.StylePriority.UseFont = False
        Me.lblRemarks.StylePriority.UseForeColor = False
        Me.lblRemarks.StylePriority.UseTextAlignment = False
        Me.lblRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPreparedBy
        '
        Me.lblPreparedBy.BackColor = System.Drawing.Color.White
        Me.lblPreparedBy.BorderColor = System.Drawing.Color.Black
        Me.lblPreparedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblPreparedBy.CanGrow = False
        Me.lblPreparedBy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreparedBy.ForeColor = System.Drawing.Color.Black
        Me.lblPreparedBy.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 895.0!)
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
        'XrLabel132
        '
        Me.XrLabel132.BackColor = System.Drawing.Color.White
        Me.XrLabel132.BorderColor = System.Drawing.Color.Black
        Me.XrLabel132.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel132.CanGrow = False
        Me.XrLabel132.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.XrLabel132.ForeColor = System.Drawing.Color.Black
        Me.XrLabel132.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 935.0!)
        Me.XrLabel132.Name = "XrLabel132"
        Me.XrLabel132.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel132.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel132.StylePriority.UseBackColor = False
        Me.XrLabel132.StylePriority.UseBorderColor = False
        Me.XrLabel132.StylePriority.UseBorders = False
        Me.XrLabel132.StylePriority.UseFont = False
        Me.XrLabel132.StylePriority.UseForeColor = False
        Me.XrLabel132.StylePriority.UseTextAlignment = False
        Me.XrLabel132.Text = "Name and Signature"
        Me.XrLabel132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel133
        '
        Me.XrLabel133.BackColor = System.Drawing.Color.White
        Me.XrLabel133.BorderColor = System.Drawing.Color.Black
        Me.XrLabel133.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel133.CanGrow = False
        Me.XrLabel133.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.XrLabel133.ForeColor = System.Drawing.Color.Black
        Me.XrLabel133.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 875.0!)
        Me.XrLabel133.Name = "XrLabel133"
        Me.XrLabel133.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel133.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel133.StylePriority.UseBackColor = False
        Me.XrLabel133.StylePriority.UseBorderColor = False
        Me.XrLabel133.StylePriority.UseBorders = False
        Me.XrLabel133.StylePriority.UseFont = False
        Me.XrLabel133.StylePriority.UseForeColor = False
        Me.XrLabel133.StylePriority.UseTextAlignment = False
        Me.XrLabel133.Text = "Prepared By :"
        Me.XrLabel133.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel135
        '
        Me.XrLabel135.BackColor = System.Drawing.Color.White
        Me.XrLabel135.BorderColor = System.Drawing.Color.Black
        Me.XrLabel135.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel135.CanGrow = False
        Me.XrLabel135.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.XrLabel135.ForeColor = System.Drawing.Color.Black
        Me.XrLabel135.LocationFloat = New DevExpress.Utils.PointFloat(200.0001!, 935.0!)
        Me.XrLabel135.Name = "XrLabel135"
        Me.XrLabel135.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel135.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel135.StylePriority.UseBackColor = False
        Me.XrLabel135.StylePriority.UseBorderColor = False
        Me.XrLabel135.StylePriority.UseBorders = False
        Me.XrLabel135.StylePriority.UseFont = False
        Me.XrLabel135.StylePriority.UseForeColor = False
        Me.XrLabel135.StylePriority.UseTextAlignment = False
        Me.XrLabel135.Text = "Name and Signature"
        Me.XrLabel135.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblRequestedBy
        '
        Me.lblRequestedBy.BackColor = System.Drawing.Color.White
        Me.lblRequestedBy.BorderColor = System.Drawing.Color.Black
        Me.lblRequestedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblRequestedBy.CanGrow = False
        Me.lblRequestedBy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestedBy.ForeColor = System.Drawing.Color.Black
        Me.lblRequestedBy.LocationFloat = New DevExpress.Utils.PointFloat(200.0001!, 895.0!)
        Me.lblRequestedBy.Name = "lblRequestedBy"
        Me.lblRequestedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRequestedBy.SizeF = New System.Drawing.SizeF(195.0!, 40.0!)
        Me.lblRequestedBy.StylePriority.UseBackColor = False
        Me.lblRequestedBy.StylePriority.UseBorderColor = False
        Me.lblRequestedBy.StylePriority.UseBorders = False
        Me.lblRequestedBy.StylePriority.UseFont = False
        Me.lblRequestedBy.StylePriority.UseForeColor = False
        Me.lblRequestedBy.StylePriority.UseTextAlignment = False
        Me.lblRequestedBy.Text = "Mark Kevin M. Gotico"
        Me.lblRequestedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel136
        '
        Me.XrLabel136.BackColor = System.Drawing.Color.White
        Me.XrLabel136.BorderColor = System.Drawing.Color.Black
        Me.XrLabel136.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel136.CanGrow = False
        Me.XrLabel136.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.XrLabel136.ForeColor = System.Drawing.Color.Black
        Me.XrLabel136.LocationFloat = New DevExpress.Utils.PointFloat(200.0001!, 875.0!)
        Me.XrLabel136.Name = "XrLabel136"
        Me.XrLabel136.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel136.SizeF = New System.Drawing.SizeF(195.0!, 20.0!)
        Me.XrLabel136.StylePriority.UseBackColor = False
        Me.XrLabel136.StylePriority.UseBorderColor = False
        Me.XrLabel136.StylePriority.UseBorders = False
        Me.XrLabel136.StylePriority.UseFont = False
        Me.XrLabel136.StylePriority.UseForeColor = False
        Me.XrLabel136.StylePriority.UseTextAlignment = False
        Me.XrLabel136.Text = "Requested By :"
        Me.XrLabel136.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel131
        '
        Me.XrLabel131.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel131.BorderColor = System.Drawing.Color.Black
        Me.XrLabel131.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel131.CanGrow = False
        Me.XrLabel131.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel131.ForeColor = System.Drawing.Color.White
        Me.XrLabel131.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 815.0!)
        Me.XrLabel131.Name = "XrLabel131"
        Me.XrLabel131.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel131.SizeF = New System.Drawing.SizeF(225.0003!, 20.0!)
        Me.XrLabel131.StylePriority.UseBackColor = False
        Me.XrLabel131.StylePriority.UseBorderColor = False
        Me.XrLabel131.StylePriority.UseBorders = False
        Me.XrLabel131.StylePriority.UseFont = False
        Me.XrLabel131.StylePriority.UseForeColor = False
        Me.XrLabel131.StylePriority.UseTextAlignment = False
        Me.XrLabel131.Text = "Remarks"
        Me.XrLabel131.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel122
        '
        Me.XrLabel122.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel122.BorderColor = System.Drawing.Color.Black
        Me.XrLabel122.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel122.CanGrow = False
        Me.XrLabel122.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel122.ForeColor = System.Drawing.Color.White
        Me.XrLabel122.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 615.0!)
        Me.XrLabel122.Name = "XrLabel122"
        Me.XrLabel122.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel122.SizeF = New System.Drawing.SizeF(225.0!, 20.0!)
        Me.XrLabel122.StylePriority.UseBackColor = False
        Me.XrLabel122.StylePriority.UseBorderColor = False
        Me.XrLabel122.StylePriority.UseBorders = False
        Me.XrLabel122.StylePriority.UseFont = False
        Me.XrLabel122.StylePriority.UseForeColor = False
        Me.XrLabel122.StylePriority.UseTextAlignment = False
        Me.XrLabel122.Text = "ACCOUNT CLOSED"
        Me.XrLabel122.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'subRpt_Closed
        '
        Me.subRpt_Closed.CanShrink = True
        Me.subRpt_Closed.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 660.0!)
        Me.subRpt_Closed.Name = "subRpt_Closed"
        Me.subRpt_Closed.SizeF = New System.Drawing.SizeF(800.0!, 150.0!)
        '
        'XrLabel123
        '
        Me.XrLabel123.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel123.BorderColor = System.Drawing.Color.Black
        Me.XrLabel123.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel123.CanGrow = False
        Me.XrLabel123.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel123.ForeColor = System.Drawing.Color.White
        Me.XrLabel123.LocationFloat = New DevExpress.Utils.PointFloat(644.9998!, 640.0!)
        Me.XrLabel123.Name = "XrLabel123"
        Me.XrLabel123.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel123.SizeF = New System.Drawing.SizeF(154.9999!, 20.0!)
        Me.XrLabel123.StylePriority.UseBackColor = False
        Me.XrLabel123.StylePriority.UseBorderColor = False
        Me.XrLabel123.StylePriority.UseBorders = False
        Me.XrLabel123.StylePriority.UseFont = False
        Me.XrLabel123.StylePriority.UseForeColor = False
        Me.XrLabel123.StylePriority.UseTextAlignment = False
        Me.XrLabel123.Text = "Remarks"
        Me.XrLabel123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel124
        '
        Me.XrLabel124.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel124.BorderColor = System.Drawing.Color.Black
        Me.XrLabel124.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel124.CanGrow = False
        Me.XrLabel124.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel124.ForeColor = System.Drawing.Color.White
        Me.XrLabel124.LocationFloat = New DevExpress.Utils.PointFloat(295.0003!, 640.0!)
        Me.XrLabel124.Name = "XrLabel124"
        Me.XrLabel124.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel124.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel124.StylePriority.UseBackColor = False
        Me.XrLabel124.StylePriority.UseBorderColor = False
        Me.XrLabel124.StylePriority.UseBorders = False
        Me.XrLabel124.StylePriority.UseFont = False
        Me.XrLabel124.StylePriority.UseForeColor = False
        Me.XrLabel124.StylePriority.UseTextAlignment = False
        Me.XrLabel124.Text = "Outstanding Bal"
        Me.XrLabel124.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel125
        '
        Me.XrLabel125.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel125.BorderColor = System.Drawing.Color.Black
        Me.XrLabel125.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel125.CanGrow = False
        Me.XrLabel125.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel125.ForeColor = System.Drawing.Color.White
        Me.XrLabel125.LocationFloat = New DevExpress.Utils.PointFloat(210.0003!, 640.0!)
        Me.XrLabel125.Name = "XrLabel125"
        Me.XrLabel125.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel125.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel125.StylePriority.UseBackColor = False
        Me.XrLabel125.StylePriority.UseBorderColor = False
        Me.XrLabel125.StylePriority.UseBorders = False
        Me.XrLabel125.StylePriority.UseFont = False
        Me.XrLabel125.StylePriority.UseForeColor = False
        Me.XrLabel125.StylePriority.UseTextAlignment = False
        Me.XrLabel125.Text = "Face Amount"
        Me.XrLabel125.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel126
        '
        Me.XrLabel126.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel126.BorderColor = System.Drawing.Color.Black
        Me.XrLabel126.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel126.CanGrow = False
        Me.XrLabel126.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel126.ForeColor = System.Drawing.Color.White
        Me.XrLabel126.LocationFloat = New DevExpress.Utils.PointFloat(125.0003!, 640.0!)
        Me.XrLabel126.Name = "XrLabel126"
        Me.XrLabel126.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel126.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel126.StylePriority.UseBackColor = False
        Me.XrLabel126.StylePriority.UseBorderColor = False
        Me.XrLabel126.StylePriority.UseBorders = False
        Me.XrLabel126.StylePriority.UseFont = False
        Me.XrLabel126.StylePriority.UseForeColor = False
        Me.XrLabel126.StylePriority.UseTextAlignment = False
        Me.XrLabel126.Text = "Principal"
        Me.XrLabel126.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel127
        '
        Me.XrLabel127.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel127.BorderColor = System.Drawing.Color.Black
        Me.XrLabel127.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel127.CanGrow = False
        Me.XrLabel127.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel127.ForeColor = System.Drawing.Color.White
        Me.XrLabel127.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 640.0!)
        Me.XrLabel127.Name = "XrLabel127"
        Me.XrLabel127.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel127.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel127.StylePriority.UseBackColor = False
        Me.XrLabel127.StylePriority.UseBorderColor = False
        Me.XrLabel127.StylePriority.UseBorders = False
        Me.XrLabel127.StylePriority.UseFont = False
        Me.XrLabel127.StylePriority.UseForeColor = False
        Me.XrLabel127.StylePriority.UseTextAlignment = False
        Me.XrLabel127.Text = "Account Number"
        Me.XrLabel127.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel128
        '
        Me.XrLabel128.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel128.BorderColor = System.Drawing.Color.Black
        Me.XrLabel128.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel128.CanGrow = False
        Me.XrLabel128.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel128.ForeColor = System.Drawing.Color.White
        Me.XrLabel128.LocationFloat = New DevExpress.Utils.PointFloat(380.0002!, 640.0!)
        Me.XrLabel128.Name = "XrLabel128"
        Me.XrLabel128.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel128.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel128.StylePriority.UseBackColor = False
        Me.XrLabel128.StylePriority.UseBorderColor = False
        Me.XrLabel128.StylePriority.UseBorders = False
        Me.XrLabel128.StylePriority.UseFont = False
        Me.XrLabel128.StylePriority.UseForeColor = False
        Me.XrLabel128.StylePriority.UseTextAlignment = False
        Me.XrLabel128.Text = "GMA"
        Me.XrLabel128.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel129
        '
        Me.XrLabel129.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel129.BorderColor = System.Drawing.Color.Black
        Me.XrLabel129.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel129.CanGrow = False
        Me.XrLabel129.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel129.ForeColor = System.Drawing.Color.White
        Me.XrLabel129.LocationFloat = New DevExpress.Utils.PointFloat(465.0002!, 640.0!)
        Me.XrLabel129.Name = "XrLabel129"
        Me.XrLabel129.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel129.SizeF = New System.Drawing.SizeF(89.99948!, 20.0!)
        Me.XrLabel129.StylePriority.UseBackColor = False
        Me.XrLabel129.StylePriority.UseBorderColor = False
        Me.XrLabel129.StylePriority.UseBorders = False
        Me.XrLabel129.StylePriority.UseFont = False
        Me.XrLabel129.StylePriority.UseForeColor = False
        Me.XrLabel129.StylePriority.UseTextAlignment = False
        Me.XrLabel129.Text = "Date Granted"
        Me.XrLabel129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel130
        '
        Me.XrLabel130.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel130.BorderColor = System.Drawing.Color.Black
        Me.XrLabel130.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel130.CanGrow = False
        Me.XrLabel130.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel130.ForeColor = System.Drawing.Color.White
        Me.XrLabel130.LocationFloat = New DevExpress.Utils.PointFloat(554.9998!, 640.0!)
        Me.XrLabel130.Name = "XrLabel130"
        Me.XrLabel130.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel130.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.XrLabel130.StylePriority.UseBackColor = False
        Me.XrLabel130.StylePriority.UseBorderColor = False
        Me.XrLabel130.StylePriority.UseBorders = False
        Me.XrLabel130.StylePriority.UseFont = False
        Me.XrLabel130.StylePriority.UseForeColor = False
        Me.XrLabel130.StylePriority.UseTextAlignment = False
        Me.XrLabel130.Text = "Maturity Date"
        Me.XrLabel130.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel121
        '
        Me.XrLabel121.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel121.BorderColor = System.Drawing.Color.Black
        Me.XrLabel121.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel121.CanGrow = False
        Me.XrLabel121.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel121.ForeColor = System.Drawing.Color.White
        Me.XrLabel121.LocationFloat = New DevExpress.Utils.PointFloat(555.0001!, 490.0001!)
        Me.XrLabel121.Name = "XrLabel121"
        Me.XrLabel121.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel121.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.XrLabel121.StylePriority.UseBackColor = False
        Me.XrLabel121.StylePriority.UseBorderColor = False
        Me.XrLabel121.StylePriority.UseBorders = False
        Me.XrLabel121.StylePriority.UseFont = False
        Me.XrLabel121.StylePriority.UseForeColor = False
        Me.XrLabel121.StylePriority.UseTextAlignment = False
        Me.XrLabel121.Text = "Maturity Date"
        Me.XrLabel121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel120
        '
        Me.XrLabel120.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel120.BorderColor = System.Drawing.Color.Black
        Me.XrLabel120.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel120.CanGrow = False
        Me.XrLabel120.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel120.ForeColor = System.Drawing.Color.White
        Me.XrLabel120.LocationFloat = New DevExpress.Utils.PointFloat(465.0005!, 490.0!)
        Me.XrLabel120.Name = "XrLabel120"
        Me.XrLabel120.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel120.SizeF = New System.Drawing.SizeF(89.99948!, 20.0!)
        Me.XrLabel120.StylePriority.UseBackColor = False
        Me.XrLabel120.StylePriority.UseBorderColor = False
        Me.XrLabel120.StylePriority.UseBorders = False
        Me.XrLabel120.StylePriority.UseFont = False
        Me.XrLabel120.StylePriority.UseForeColor = False
        Me.XrLabel120.StylePriority.UseTextAlignment = False
        Me.XrLabel120.Text = "Date Granted"
        Me.XrLabel120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel119
        '
        Me.XrLabel119.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel119.BorderColor = System.Drawing.Color.Black
        Me.XrLabel119.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel119.CanGrow = False
        Me.XrLabel119.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel119.ForeColor = System.Drawing.Color.White
        Me.XrLabel119.LocationFloat = New DevExpress.Utils.PointFloat(380.0005!, 490.0!)
        Me.XrLabel119.Name = "XrLabel119"
        Me.XrLabel119.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel119.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel119.StylePriority.UseBackColor = False
        Me.XrLabel119.StylePriority.UseBorderColor = False
        Me.XrLabel119.StylePriority.UseBorders = False
        Me.XrLabel119.StylePriority.UseFont = False
        Me.XrLabel119.StylePriority.UseForeColor = False
        Me.XrLabel119.StylePriority.UseTextAlignment = False
        Me.XrLabel119.Text = "GMA"
        Me.XrLabel119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel114
        '
        Me.XrLabel114.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel114.BorderColor = System.Drawing.Color.Black
        Me.XrLabel114.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel114.CanGrow = False
        Me.XrLabel114.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel114.ForeColor = System.Drawing.Color.White
        Me.XrLabel114.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 490.0!)
        Me.XrLabel114.Name = "XrLabel114"
        Me.XrLabel114.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel114.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel114.StylePriority.UseBackColor = False
        Me.XrLabel114.StylePriority.UseBorderColor = False
        Me.XrLabel114.StylePriority.UseBorders = False
        Me.XrLabel114.StylePriority.UseFont = False
        Me.XrLabel114.StylePriority.UseForeColor = False
        Me.XrLabel114.StylePriority.UseTextAlignment = False
        Me.XrLabel114.Text = "Account Number"
        Me.XrLabel114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel115
        '
        Me.XrLabel115.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel115.BorderColor = System.Drawing.Color.Black
        Me.XrLabel115.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel115.CanGrow = False
        Me.XrLabel115.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel115.ForeColor = System.Drawing.Color.White
        Me.XrLabel115.LocationFloat = New DevExpress.Utils.PointFloat(125.0005!, 490.0!)
        Me.XrLabel115.Name = "XrLabel115"
        Me.XrLabel115.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel115.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel115.StylePriority.UseBackColor = False
        Me.XrLabel115.StylePriority.UseBorderColor = False
        Me.XrLabel115.StylePriority.UseBorders = False
        Me.XrLabel115.StylePriority.UseFont = False
        Me.XrLabel115.StylePriority.UseForeColor = False
        Me.XrLabel115.StylePriority.UseTextAlignment = False
        Me.XrLabel115.Text = "Principal"
        Me.XrLabel115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel116
        '
        Me.XrLabel116.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel116.BorderColor = System.Drawing.Color.Black
        Me.XrLabel116.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel116.CanGrow = False
        Me.XrLabel116.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel116.ForeColor = System.Drawing.Color.White
        Me.XrLabel116.LocationFloat = New DevExpress.Utils.PointFloat(210.0005!, 490.0!)
        Me.XrLabel116.Name = "XrLabel116"
        Me.XrLabel116.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel116.SizeF = New System.Drawing.SizeF(84.9995!, 20.0!)
        Me.XrLabel116.StylePriority.UseBackColor = False
        Me.XrLabel116.StylePriority.UseBorderColor = False
        Me.XrLabel116.StylePriority.UseBorders = False
        Me.XrLabel116.StylePriority.UseFont = False
        Me.XrLabel116.StylePriority.UseForeColor = False
        Me.XrLabel116.StylePriority.UseTextAlignment = False
        Me.XrLabel116.Text = "Face Amount"
        Me.XrLabel116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel117
        '
        Me.XrLabel117.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel117.BorderColor = System.Drawing.Color.Black
        Me.XrLabel117.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel117.CanGrow = False
        Me.XrLabel117.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel117.ForeColor = System.Drawing.Color.White
        Me.XrLabel117.LocationFloat = New DevExpress.Utils.PointFloat(295.0005!, 490.0!)
        Me.XrLabel117.Name = "XrLabel117"
        Me.XrLabel117.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel117.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel117.StylePriority.UseBackColor = False
        Me.XrLabel117.StylePriority.UseBorderColor = False
        Me.XrLabel117.StylePriority.UseBorders = False
        Me.XrLabel117.StylePriority.UseFont = False
        Me.XrLabel117.StylePriority.UseForeColor = False
        Me.XrLabel117.StylePriority.UseTextAlignment = False
        Me.XrLabel117.Text = "Outstanding Bal"
        Me.XrLabel117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel118
        '
        Me.XrLabel118.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel118.BorderColor = System.Drawing.Color.Black
        Me.XrLabel118.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel118.CanGrow = False
        Me.XrLabel118.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel118.ForeColor = System.Drawing.Color.White
        Me.XrLabel118.LocationFloat = New DevExpress.Utils.PointFloat(645.0001!, 490.0!)
        Me.XrLabel118.Name = "XrLabel118"
        Me.XrLabel118.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel118.SizeF = New System.Drawing.SizeF(154.9999!, 20.0!)
        Me.XrLabel118.StylePriority.UseBackColor = False
        Me.XrLabel118.StylePriority.UseBorderColor = False
        Me.XrLabel118.StylePriority.UseBorders = False
        Me.XrLabel118.StylePriority.UseFont = False
        Me.XrLabel118.StylePriority.UseForeColor = False
        Me.XrLabel118.StylePriority.UseTextAlignment = False
        Me.XrLabel118.Text = "Remarks"
        Me.XrLabel118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'subRpt_Active
        '
        Me.subRpt_Active.CanShrink = True
        Me.subRpt_Active.LocationFloat = New DevExpress.Utils.PointFloat(0.0005386494!, 510.0!)
        Me.subRpt_Active.Name = "subRpt_Active"
        Me.subRpt_Active.SizeF = New System.Drawing.SizeF(800.0!, 100.0!)
        '
        'XrLabel112
        '
        Me.XrLabel112.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel112.BorderColor = System.Drawing.Color.Black
        Me.XrLabel112.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel112.CanGrow = False
        Me.XrLabel112.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel112.ForeColor = System.Drawing.Color.White
        Me.XrLabel112.LocationFloat = New DevExpress.Utils.PointFloat(0.0005364418!, 465.0!)
        Me.XrLabel112.Name = "XrLabel112"
        Me.XrLabel112.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel112.SizeF = New System.Drawing.SizeF(225.0!, 20.0!)
        Me.XrLabel112.StylePriority.UseBackColor = False
        Me.XrLabel112.StylePriority.UseBorderColor = False
        Me.XrLabel112.StylePriority.UseBorders = False
        Me.XrLabel112.StylePriority.UseFont = False
        Me.XrLabel112.StylePriority.UseForeColor = False
        Me.XrLabel112.StylePriority.UseTextAlignment = False
        Me.XrLabel112.Text = "ACTIVE ACCOUNTS"
        Me.XrLabel112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel106
        '
        Me.XrLabel106.BackColor = System.Drawing.Color.White
        Me.XrLabel106.BorderColor = System.Drawing.Color.Black
        Me.XrLabel106.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel106.CanGrow = False
        Me.XrLabel106.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel106.ForeColor = System.Drawing.Color.Black
        Me.XrLabel106.LocationFloat = New DevExpress.Utils.PointFloat(0.0001986821!, 419.9999!)
        Me.XrLabel106.Name = "XrLabel106"
        Me.XrLabel106.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel106.SizeF = New System.Drawing.SizeF(164.9998!, 19.00003!)
        Me.XrLabel106.StylePriority.UseBackColor = False
        Me.XrLabel106.StylePriority.UseBorderColor = False
        Me.XrLabel106.StylePriority.UseBorders = False
        Me.XrLabel106.StylePriority.UseFont = False
        Me.XrLabel106.StylePriority.UseForeColor = False
        Me.XrLabel106.StylePriority.UseTextAlignment = False
        Me.XrLabel106.Text = "Present Status :"
        Me.XrLabel106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblPresentStatus
        '
        Me.lblPresentStatus.BackColor = System.Drawing.Color.White
        Me.lblPresentStatus.BorderColor = System.Drawing.Color.Black
        Me.lblPresentStatus.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblPresentStatus.CanGrow = False
        Me.lblPresentStatus.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblPresentStatus.ForeColor = System.Drawing.Color.Black
        Me.lblPresentStatus.LocationFloat = New DevExpress.Utils.PointFloat(165.0!, 419.9999!)
        Me.lblPresentStatus.Name = "lblPresentStatus"
        Me.lblPresentStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPresentStatus.SizeF = New System.Drawing.SizeF(125.0001!, 19.0!)
        Me.lblPresentStatus.StylePriority.UseBackColor = False
        Me.lblPresentStatus.StylePriority.UseBorderColor = False
        Me.lblPresentStatus.StylePriority.UseBorders = False
        Me.lblPresentStatus.StylePriority.UseFont = False
        Me.lblPresentStatus.StylePriority.UseForeColor = False
        Me.lblPresentStatus.StylePriority.UseTextAlignment = False
        Me.lblPresentStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblLoanType
        '
        Me.lblLoanType.BackColor = System.Drawing.Color.White
        Me.lblLoanType.BorderColor = System.Drawing.Color.Black
        Me.lblLoanType.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblLoanType.CanGrow = False
        Me.lblLoanType.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblLoanType.ForeColor = System.Drawing.Color.Black
        Me.lblLoanType.LocationFloat = New DevExpress.Utils.PointFloat(165.0001!, 438.9998!)
        Me.lblLoanType.Name = "lblLoanType"
        Me.lblLoanType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLoanType.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblLoanType.StylePriority.UseBackColor = False
        Me.lblLoanType.StylePriority.UseBorderColor = False
        Me.lblLoanType.StylePriority.UseBorders = False
        Me.lblLoanType.StylePriority.UseFont = False
        Me.lblLoanType.StylePriority.UseForeColor = False
        Me.lblLoanType.StylePriority.UseTextAlignment = False
        Me.lblLoanType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDeliquency
        '
        Me.lblDeliquency.BackColor = System.Drawing.Color.White
        Me.lblDeliquency.BorderColor = System.Drawing.Color.Black
        Me.lblDeliquency.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDeliquency.CanGrow = False
        Me.lblDeliquency.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblDeliquency.ForeColor = System.Drawing.Color.Black
        Me.lblDeliquency.LocationFloat = New DevExpress.Utils.PointFloat(165.0004!, 400.9999!)
        Me.lblDeliquency.Name = "lblDeliquency"
        Me.lblDeliquency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDeliquency.SizeF = New System.Drawing.SizeF(124.9997!, 19.0!)
        Me.lblDeliquency.StylePriority.UseBackColor = False
        Me.lblDeliquency.StylePriority.UseBorderColor = False
        Me.lblDeliquency.StylePriority.UseBorders = False
        Me.lblDeliquency.StylePriority.UseFont = False
        Me.lblDeliquency.StylePriority.UseForeColor = False
        Me.lblDeliquency.StylePriority.UseTextAlignment = False
        Me.lblDeliquency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel109
        '
        Me.XrLabel109.BackColor = System.Drawing.Color.White
        Me.XrLabel109.BorderColor = System.Drawing.Color.Black
        Me.XrLabel109.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel109.CanGrow = False
        Me.XrLabel109.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel109.ForeColor = System.Drawing.Color.Black
        Me.XrLabel109.LocationFloat = New DevExpress.Utils.PointFloat(0.0005364418!, 400.9999!)
        Me.XrLabel109.Name = "XrLabel109"
        Me.XrLabel109.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel109.SizeF = New System.Drawing.SizeF(164.9998!, 19.00006!)
        Me.XrLabel109.StylePriority.UseBackColor = False
        Me.XrLabel109.StylePriority.UseBorderColor = False
        Me.XrLabel109.StylePriority.UseBorders = False
        Me.XrLabel109.StylePriority.UseFont = False
        Me.XrLabel109.StylePriority.UseForeColor = False
        Me.XrLabel109.StylePriority.UseTextAlignment = False
        Me.XrLabel109.Text = "Deliquency Range :"
        Me.XrLabel109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblNumberLPC
        '
        Me.lblNumberLPC.BackColor = System.Drawing.Color.White
        Me.lblNumberLPC.BorderColor = System.Drawing.Color.Black
        Me.lblNumberLPC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblNumberLPC.CanGrow = False
        Me.lblNumberLPC.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblNumberLPC.ForeColor = System.Drawing.Color.Black
        Me.lblNumberLPC.LocationFloat = New DevExpress.Utils.PointFloat(165.0003!, 382.0!)
        Me.lblNumberLPC.Name = "lblNumberLPC"
        Me.lblNumberLPC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNumberLPC.SizeF = New System.Drawing.SizeF(124.9998!, 19.0!)
        Me.lblNumberLPC.StylePriority.UseBackColor = False
        Me.lblNumberLPC.StylePriority.UseBorderColor = False
        Me.lblNumberLPC.StylePriority.UseBorders = False
        Me.lblNumberLPC.StylePriority.UseFont = False
        Me.lblNumberLPC.StylePriority.UseForeColor = False
        Me.lblNumberLPC.StylePriority.UseTextAlignment = False
        Me.lblNumberLPC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel111
        '
        Me.XrLabel111.BackColor = System.Drawing.Color.White
        Me.XrLabel111.BorderColor = System.Drawing.Color.Black
        Me.XrLabel111.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel111.CanGrow = False
        Me.XrLabel111.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel111.ForeColor = System.Drawing.Color.Black
        Me.XrLabel111.LocationFloat = New DevExpress.Utils.PointFloat(0.0004967054!, 382.0!)
        Me.XrLabel111.Name = "XrLabel111"
        Me.XrLabel111.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel111.SizeF = New System.Drawing.SizeF(164.9998!, 19.00003!)
        Me.XrLabel111.StylePriority.UseBackColor = False
        Me.XrLabel111.StylePriority.UseBorderColor = False
        Me.XrLabel111.StylePriority.UseBorders = False
        Me.XrLabel111.StylePriority.UseFont = False
        Me.XrLabel111.StylePriority.UseForeColor = False
        Me.XrLabel111.StylePriority.UseTextAlignment = False
        Me.XrLabel111.Text = "Number of LPC's :"
        Me.XrLabel111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTerms
        '
        Me.lblTerms.BackColor = System.Drawing.Color.White
        Me.lblTerms.BorderColor = System.Drawing.Color.Black
        Me.lblTerms.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblTerms.CanGrow = False
        Me.lblTerms.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblTerms.ForeColor = System.Drawing.Color.Black
        Me.lblTerms.LocationFloat = New DevExpress.Utils.PointFloat(165.0001!, 363.0!)
        Me.lblTerms.Name = "lblTerms"
        Me.lblTerms.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTerms.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblTerms.StylePriority.UseBackColor = False
        Me.lblTerms.StylePriority.UseBorderColor = False
        Me.lblTerms.StylePriority.UseBorders = False
        Me.lblTerms.StylePriority.UseFont = False
        Me.lblTerms.StylePriority.UseForeColor = False
        Me.lblTerms.StylePriority.UseTextAlignment = False
        Me.lblTerms.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel101
        '
        Me.XrLabel101.BackColor = System.Drawing.Color.White
        Me.XrLabel101.BorderColor = System.Drawing.Color.Black
        Me.XrLabel101.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel101.CanGrow = False
        Me.XrLabel101.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel101.ForeColor = System.Drawing.Color.Black
        Me.XrLabel101.LocationFloat = New DevExpress.Utils.PointFloat(0.0002384186!, 363.0!)
        Me.XrLabel101.Name = "XrLabel101"
        Me.XrLabel101.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel101.SizeF = New System.Drawing.SizeF(164.9998!, 19.00006!)
        Me.XrLabel101.StylePriority.UseBackColor = False
        Me.XrLabel101.StylePriority.UseBorderColor = False
        Me.XrLabel101.StylePriority.UseBorders = False
        Me.XrLabel101.StylePriority.UseFont = False
        Me.XrLabel101.StylePriority.UseForeColor = False
        Me.XrLabel101.StylePriority.UseTextAlignment = False
        Me.XrLabel101.Text = "Term of Loan :"
        Me.XrLabel101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel102
        '
        Me.XrLabel102.BackColor = System.Drawing.Color.White
        Me.XrLabel102.BorderColor = System.Drawing.Color.Black
        Me.XrLabel102.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel102.CanGrow = False
        Me.XrLabel102.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel102.ForeColor = System.Drawing.Color.Black
        Me.XrLabel102.LocationFloat = New DevExpress.Utils.PointFloat(0.0004371007!, 306.0!)
        Me.XrLabel102.Name = "XrLabel102"
        Me.XrLabel102.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel102.SizeF = New System.Drawing.SizeF(164.9998!, 19.00003!)
        Me.XrLabel102.StylePriority.UseBackColor = False
        Me.XrLabel102.StylePriority.UseBorderColor = False
        Me.XrLabel102.StylePriority.UseBorders = False
        Me.XrLabel102.StylePriority.UseFont = False
        Me.XrLabel102.StylePriority.UseForeColor = False
        Me.XrLabel102.StylePriority.UseTextAlignment = False
        Me.XrLabel102.Text = "Principal Balance :"
        Me.XrLabel102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblPrincipalBalance
        '
        Me.lblPrincipalBalance.BackColor = System.Drawing.Color.White
        Me.lblPrincipalBalance.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalBalance.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblPrincipalBalance.CanGrow = False
        Me.lblPrincipalBalance.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblPrincipalBalance.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalBalance.LocationFloat = New DevExpress.Utils.PointFloat(165.0002!, 306.0!)
        Me.lblPrincipalBalance.Name = "lblPrincipalBalance"
        Me.lblPrincipalBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalBalance.SizeF = New System.Drawing.SizeF(124.9998!, 19.00003!)
        Me.lblPrincipalBalance.StylePriority.UseBackColor = False
        Me.lblPrincipalBalance.StylePriority.UseBorderColor = False
        Me.lblPrincipalBalance.StylePriority.UseBorders = False
        Me.lblPrincipalBalance.StylePriority.UseFont = False
        Me.lblPrincipalBalance.StylePriority.UseForeColor = False
        Me.lblPrincipalBalance.StylePriority.UseTextAlignment = False
        Me.lblPrincipalBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel104
        '
        Me.XrLabel104.BackColor = System.Drawing.Color.White
        Me.XrLabel104.BorderColor = System.Drawing.Color.Black
        Me.XrLabel104.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel104.CanGrow = False
        Me.XrLabel104.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel104.ForeColor = System.Drawing.Color.Black
        Me.XrLabel104.LocationFloat = New DevExpress.Utils.PointFloat(0.0004867713!, 325.0!)
        Me.XrLabel104.Name = "XrLabel104"
        Me.XrLabel104.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel104.SizeF = New System.Drawing.SizeF(164.9998!, 19.00006!)
        Me.XrLabel104.StylePriority.UseBackColor = False
        Me.XrLabel104.StylePriority.UseBorderColor = False
        Me.XrLabel104.StylePriority.UseBorders = False
        Me.XrLabel104.StylePriority.UseFont = False
        Me.XrLabel104.StylePriority.UseForeColor = False
        Me.XrLabel104.StylePriority.UseTextAlignment = False
        Me.XrLabel104.Text = "Number of Payments Made :"
        Me.XrLabel104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblNumberPayments
        '
        Me.lblNumberPayments.BackColor = System.Drawing.Color.White
        Me.lblNumberPayments.BorderColor = System.Drawing.Color.Black
        Me.lblNumberPayments.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblNumberPayments.CanGrow = False
        Me.lblNumberPayments.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblNumberPayments.ForeColor = System.Drawing.Color.Black
        Me.lblNumberPayments.LocationFloat = New DevExpress.Utils.PointFloat(165.0003!, 325.0!)
        Me.lblNumberPayments.Name = "lblNumberPayments"
        Me.lblNumberPayments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNumberPayments.SizeF = New System.Drawing.SizeF(124.9998!, 19.0!)
        Me.lblNumberPayments.StylePriority.UseBackColor = False
        Me.lblNumberPayments.StylePriority.UseBorderColor = False
        Me.lblNumberPayments.StylePriority.UseBorders = False
        Me.lblNumberPayments.StylePriority.UseFont = False
        Me.lblNumberPayments.StylePriority.UseForeColor = False
        Me.lblNumberPayments.StylePriority.UseTextAlignment = False
        Me.lblNumberPayments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblRPPD
        '
        Me.lblRPPD.BackColor = System.Drawing.Color.White
        Me.lblRPPD.BorderColor = System.Drawing.Color.Black
        Me.lblRPPD.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblRPPD.CanGrow = False
        Me.lblRPPD.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblRPPD.ForeColor = System.Drawing.Color.Black
        Me.lblRPPD.LocationFloat = New DevExpress.Utils.PointFloat(165.0!, 227.9999!)
        Me.lblRPPD.Name = "lblRPPD"
        Me.lblRPPD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPD.SizeF = New System.Drawing.SizeF(125.0!, 18.99998!)
        Me.lblRPPD.StylePriority.UseBackColor = False
        Me.lblRPPD.StylePriority.UseBorderColor = False
        Me.lblRPPD.StylePriority.UseBorders = False
        Me.lblRPPD.StylePriority.UseFont = False
        Me.lblRPPD.StylePriority.UseForeColor = False
        Me.lblRPPD.StylePriority.UseTextAlignment = False
        Me.lblRPPD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel95
        '
        Me.XrLabel95.BackColor = System.Drawing.Color.White
        Me.XrLabel95.BorderColor = System.Drawing.Color.Black
        Me.XrLabel95.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel95.CanGrow = False
        Me.XrLabel95.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel95.ForeColor = System.Drawing.Color.Black
        Me.XrLabel95.LocationFloat = New DevExpress.Utils.PointFloat(0.0001688798!, 227.9999!)
        Me.XrLabel95.Name = "XrLabel95"
        Me.XrLabel95.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel95.SizeF = New System.Drawing.SizeF(164.9998!, 19.00003!)
        Me.XrLabel95.StylePriority.UseBackColor = False
        Me.XrLabel95.StylePriority.UseBorderColor = False
        Me.XrLabel95.StylePriority.UseBorders = False
        Me.XrLabel95.StylePriority.UseFont = False
        Me.XrLabel95.StylePriority.UseForeColor = False
        Me.XrLabel95.StylePriority.UseTextAlignment = False
        Me.XrLabel95.Text = "Less : RPPD :"
        Me.XrLabel95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel96
        '
        Me.XrLabel96.BackColor = System.Drawing.Color.White
        Me.XrLabel96.BorderColor = System.Drawing.Color.Black
        Me.XrLabel96.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel96.CanGrow = False
        Me.XrLabel96.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel96.ForeColor = System.Drawing.Color.Black
        Me.XrLabel96.LocationFloat = New DevExpress.Utils.PointFloat(0.0004371007!, 246.9999!)
        Me.XrLabel96.Name = "XrLabel96"
        Me.XrLabel96.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel96.SizeF = New System.Drawing.SizeF(164.9998!, 19.00008!)
        Me.XrLabel96.StylePriority.UseBackColor = False
        Me.XrLabel96.StylePriority.UseBorderColor = False
        Me.XrLabel96.StylePriority.UseBorders = False
        Me.XrLabel96.StylePriority.UseFont = False
        Me.XrLabel96.StylePriority.UseForeColor = False
        Me.XrLabel96.StylePriority.UseTextAlignment = False
        Me.XrLabel96.Text = "UDI :"
        Me.XrLabel96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblUDI
        '
        Me.lblUDI.BackColor = System.Drawing.Color.White
        Me.lblUDI.BorderColor = System.Drawing.Color.Black
        Me.lblUDI.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblUDI.CanGrow = False
        Me.lblUDI.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblUDI.ForeColor = System.Drawing.Color.Black
        Me.lblUDI.LocationFloat = New DevExpress.Utils.PointFloat(165.0002!, 246.9999!)
        Me.lblUDI.Name = "lblUDI"
        Me.lblUDI.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUDI.SizeF = New System.Drawing.SizeF(125.0!, 19.00002!)
        Me.lblUDI.StylePriority.UseBackColor = False
        Me.lblUDI.StylePriority.UseBorderColor = False
        Me.lblUDI.StylePriority.UseBorders = False
        Me.lblUDI.StylePriority.UseFont = False
        Me.lblUDI.StylePriority.UseForeColor = False
        Me.lblUDI.StylePriority.UseTextAlignment = False
        Me.lblUDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel98
        '
        Me.XrLabel98.BackColor = System.Drawing.Color.White
        Me.XrLabel98.BorderColor = System.Drawing.Color.Black
        Me.XrLabel98.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel98.CanGrow = False
        Me.XrLabel98.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel98.ForeColor = System.Drawing.Color.Black
        Me.XrLabel98.LocationFloat = New DevExpress.Utils.PointFloat(0.0004867713!, 265.9999!)
        Me.XrLabel98.Name = "XrLabel98"
        Me.XrLabel98.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel98.SizeF = New System.Drawing.SizeF(164.9998!, 19.00003!)
        Me.XrLabel98.StylePriority.UseBackColor = False
        Me.XrLabel98.StylePriority.UseBorderColor = False
        Me.XrLabel98.StylePriority.UseBorders = False
        Me.XrLabel98.StylePriority.UseFont = False
        Me.XrLabel98.StylePriority.UseForeColor = False
        Me.XrLabel98.StylePriority.UseTextAlignment = False
        Me.XrLabel98.Text = "Total Amount Due :"
        Me.XrLabel98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTotalAmountDue
        '
        Me.lblTotalAmountDue.BackColor = System.Drawing.Color.White
        Me.lblTotalAmountDue.BorderColor = System.Drawing.Color.Black
        Me.lblTotalAmountDue.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblTotalAmountDue.CanGrow = False
        Me.lblTotalAmountDue.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblTotalAmountDue.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAmountDue.LocationFloat = New DevExpress.Utils.PointFloat(165.0003!, 265.9999!)
        Me.lblTotalAmountDue.Name = "lblTotalAmountDue"
        Me.lblTotalAmountDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalAmountDue.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblTotalAmountDue.StylePriority.UseBackColor = False
        Me.lblTotalAmountDue.StylePriority.UseBorderColor = False
        Me.lblTotalAmountDue.StylePriority.UseBorders = False
        Me.lblTotalAmountDue.StylePriority.UseFont = False
        Me.lblTotalAmountDue.StylePriority.UseForeColor = False
        Me.lblTotalAmountDue.StylePriority.UseTextAlignment = False
        Me.lblTotalAmountDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel93
        '
        Me.XrLabel93.BackColor = System.Drawing.Color.White
        Me.XrLabel93.BorderColor = System.Drawing.Color.Black
        Me.XrLabel93.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel93.CanGrow = False
        Me.XrLabel93.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel93.ForeColor = System.Drawing.Color.Black
        Me.XrLabel93.LocationFloat = New DevExpress.Utils.PointFloat(0.0004867713!, 208.9998!)
        Me.XrLabel93.Name = "XrLabel93"
        Me.XrLabel93.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel93.SizeF = New System.Drawing.SizeF(164.9998!, 19.00006!)
        Me.XrLabel93.StylePriority.UseBackColor = False
        Me.XrLabel93.StylePriority.UseBorderColor = False
        Me.XrLabel93.StylePriority.UseBorders = False
        Me.XrLabel93.StylePriority.UseFont = False
        Me.XrLabel93.StylePriority.UseForeColor = False
        Me.XrLabel93.StylePriority.UseTextAlignment = False
        Me.XrLabel93.Text = "Balance :"
        Me.XrLabel93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblLPC
        '
        Me.lblLPC.BackColor = System.Drawing.Color.White
        Me.lblLPC.BorderColor = System.Drawing.Color.Black
        Me.lblLPC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblLPC.CanGrow = False
        Me.lblLPC.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblLPC.ForeColor = System.Drawing.Color.Black
        Me.lblLPC.LocationFloat = New DevExpress.Utils.PointFloat(165.0003!, 189.9998!)
        Me.lblLPC.Name = "lblLPC"
        Me.lblLPC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLPC.SizeF = New System.Drawing.SizeF(125.0!, 18.99998!)
        Me.lblLPC.StylePriority.UseBackColor = False
        Me.lblLPC.StylePriority.UseBorderColor = False
        Me.lblLPC.StylePriority.UseBorders = False
        Me.lblLPC.StylePriority.UseFont = False
        Me.lblLPC.StylePriority.UseForeColor = False
        Me.lblLPC.StylePriority.UseTextAlignment = False
        Me.lblLPC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel91
        '
        Me.XrLabel91.BackColor = System.Drawing.Color.White
        Me.XrLabel91.BorderColor = System.Drawing.Color.Black
        Me.XrLabel91.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel91.CanGrow = False
        Me.XrLabel91.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel91.ForeColor = System.Drawing.Color.Black
        Me.XrLabel91.LocationFloat = New DevExpress.Utils.PointFloat(0.0004569689!, 189.9998!)
        Me.XrLabel91.Name = "XrLabel91"
        Me.XrLabel91.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel91.SizeF = New System.Drawing.SizeF(164.9998!, 19.00003!)
        Me.XrLabel91.StylePriority.UseBackColor = False
        Me.XrLabel91.StylePriority.UseBorderColor = False
        Me.XrLabel91.StylePriority.UseBorders = False
        Me.XrLabel91.StylePriority.UseFont = False
        Me.XrLabel91.StylePriority.UseForeColor = False
        Me.XrLabel91.StylePriority.UseTextAlignment = False
        Me.XrLabel91.Text = "LPC :"
        Me.XrLabel91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel88
        '
        Me.XrLabel88.BackColor = System.Drawing.Color.White
        Me.XrLabel88.BorderColor = System.Drawing.Color.Black
        Me.XrLabel88.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel88.CanGrow = False
        Me.XrLabel88.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel88.ForeColor = System.Drawing.Color.Black
        Me.XrLabel88.LocationFloat = New DevExpress.Utils.PointFloat(0.000188748!, 170.9998!)
        Me.XrLabel88.Name = "XrLabel88"
        Me.XrLabel88.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel88.SizeF = New System.Drawing.SizeF(164.9998!, 19.00006!)
        Me.XrLabel88.StylePriority.UseBackColor = False
        Me.XrLabel88.StylePriority.UseBorderColor = False
        Me.XrLabel88.StylePriority.UseBorders = False
        Me.XrLabel88.StylePriority.UseFont = False
        Me.XrLabel88.StylePriority.UseForeColor = False
        Me.XrLabel88.StylePriority.UseTextAlignment = False
        Me.XrLabel88.Text = "Plus : Interest Due :"
        Me.XrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblInterestDue
        '
        Me.lblInterestDue.BackColor = System.Drawing.Color.White
        Me.lblInterestDue.BorderColor = System.Drawing.Color.Black
        Me.lblInterestDue.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblInterestDue.CanGrow = False
        Me.lblInterestDue.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblInterestDue.ForeColor = System.Drawing.Color.Black
        Me.lblInterestDue.LocationFloat = New DevExpress.Utils.PointFloat(165.0!, 170.9998!)
        Me.lblInterestDue.Name = "lblInterestDue"
        Me.lblInterestDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestDue.SizeF = New System.Drawing.SizeF(125.0!, 19.00002!)
        Me.lblInterestDue.StylePriority.UseBackColor = False
        Me.lblInterestDue.StylePriority.UseBorderColor = False
        Me.lblInterestDue.StylePriority.UseBorders = False
        Me.lblInterestDue.StylePriority.UseFont = False
        Me.lblInterestDue.StylePriority.UseForeColor = False
        Me.lblInterestDue.StylePriority.UseTextAlignment = False
        Me.lblInterestDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblOutstanding
        '
        Me.lblOutstanding.BackColor = System.Drawing.Color.White
        Me.lblOutstanding.BorderColor = System.Drawing.Color.Black
        Me.lblOutstanding.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblOutstanding.CanGrow = False
        Me.lblOutstanding.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblOutstanding.ForeColor = System.Drawing.Color.Black
        Me.lblOutstanding.LocationFloat = New DevExpress.Utils.PointFloat(165.0!, 151.9997!)
        Me.lblOutstanding.Name = "lblOutstanding"
        Me.lblOutstanding.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOutstanding.SizeF = New System.Drawing.SizeF(125.0!, 19.00002!)
        Me.lblOutstanding.StylePriority.UseBackColor = False
        Me.lblOutstanding.StylePriority.UseBorderColor = False
        Me.lblOutstanding.StylePriority.UseBorders = False
        Me.lblOutstanding.StylePriority.UseFont = False
        Me.lblOutstanding.StylePriority.UseForeColor = False
        Me.lblOutstanding.StylePriority.UseTextAlignment = False
        Me.lblOutstanding.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel87
        '
        Me.XrLabel87.BackColor = System.Drawing.Color.White
        Me.XrLabel87.BorderColor = System.Drawing.Color.Black
        Me.XrLabel87.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel87.CanGrow = False
        Me.XrLabel87.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel87.ForeColor = System.Drawing.Color.Black
        Me.XrLabel87.LocationFloat = New DevExpress.Utils.PointFloat(0.000188748!, 151.9997!)
        Me.XrLabel87.Name = "XrLabel87"
        Me.XrLabel87.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel87.SizeF = New System.Drawing.SizeF(164.9998!, 19.00006!)
        Me.XrLabel87.StylePriority.UseBackColor = False
        Me.XrLabel87.StylePriority.UseBorderColor = False
        Me.XrLabel87.StylePriority.UseBorders = False
        Me.XrLabel87.StylePriority.UseFont = False
        Me.XrLabel87.StylePriority.UseForeColor = False
        Me.XrLabel87.StylePriority.UseTextAlignment = False
        Me.XrLabel87.Text = "Outstanding Balance :"
        Me.XrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel84
        '
        Me.XrLabel84.BackColor = System.Drawing.Color.White
        Me.XrLabel84.BorderColor = System.Drawing.Color.Black
        Me.XrLabel84.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel84.CanGrow = False
        Me.XrLabel84.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel84.ForeColor = System.Drawing.Color.Black
        Me.XrLabel84.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 445.0!)
        Me.XrLabel84.Name = "XrLabel84"
        Me.XrLabel84.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel84.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel84.StylePriority.UseBackColor = False
        Me.XrLabel84.StylePriority.UseBorderColor = False
        Me.XrLabel84.StylePriority.UseBorders = False
        Me.XrLabel84.StylePriority.UseFont = False
        Me.XrLabel84.StylePriority.UseForeColor = False
        Me.XrLabel84.StylePriority.UseTextAlignment = False
        Me.XrLabel84.Text = "Remarks"
        Me.XrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblRemarksScore
        '
        Me.lblRemarksScore.BackColor = System.Drawing.Color.White
        Me.lblRemarksScore.BorderColor = System.Drawing.Color.Black
        Me.lblRemarksScore.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRemarksScore.CanGrow = False
        Me.lblRemarksScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarksScore.ForeColor = System.Drawing.Color.Black
        Me.lblRemarksScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0!, 445.0!)
        Me.lblRemarksScore.Name = "lblRemarksScore"
        Me.lblRemarksScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarksScore.SizeF = New System.Drawing.SizeF(225.0!, 20.0!)
        Me.lblRemarksScore.StylePriority.UseBackColor = False
        Me.lblRemarksScore.StylePriority.UseBorderColor = False
        Me.lblRemarksScore.StylePriority.UseBorders = False
        Me.lblRemarksScore.StylePriority.UseFont = False
        Me.lblRemarksScore.StylePriority.UseForeColor = False
        Me.lblRemarksScore.StylePriority.UseTextAlignment = False
        Me.lblRemarksScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel80
        '
        Me.XrLabel80.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel80.BorderColor = System.Drawing.Color.Black
        Me.XrLabel80.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel80.CanGrow = False
        Me.XrLabel80.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel80.ForeColor = System.Drawing.Color.White
        Me.XrLabel80.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 425.0!)
        Me.XrLabel80.Name = "XrLabel80"
        Me.XrLabel80.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel80.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel80.StylePriority.UseBackColor = False
        Me.XrLabel80.StylePriority.UseBorderColor = False
        Me.XrLabel80.StylePriority.UseBorders = False
        Me.XrLabel80.StylePriority.UseFont = False
        Me.XrLabel80.StylePriority.UseForeColor = False
        Me.XrLabel80.StylePriority.UseTextAlignment = False
        Me.XrLabel80.Text = "T O T A L"
        Me.XrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTotalScore
        '
        Me.lblTotalScore.BackColor = System.Drawing.Color.White
        Me.lblTotalScore.BorderColor = System.Drawing.Color.Black
        Me.lblTotalScore.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalScore.CanGrow = False
        Me.lblTotalScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalScore.ForeColor = System.Drawing.Color.Black
        Me.lblTotalScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0!, 425.0!)
        Me.lblTotalScore.Name = "lblTotalScore"
        Me.lblTotalScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalScore.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblTotalScore.StylePriority.UseBackColor = False
        Me.lblTotalScore.StylePriority.UseBorderColor = False
        Me.lblTotalScore.StylePriority.UseBorders = False
        Me.lblTotalScore.StylePriority.UseFont = False
        Me.lblTotalScore.StylePriority.UseForeColor = False
        Me.lblTotalScore.StylePriority.UseTextAlignment = False
        Me.lblTotalScore.Text = "20"
        Me.lblTotalScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel82
        '
        Me.XrLabel82.BackColor = System.Drawing.Color.White
        Me.XrLabel82.BorderColor = System.Drawing.Color.Black
        Me.XrLabel82.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel82.CanGrow = False
        Me.XrLabel82.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel82.ForeColor = System.Drawing.Color.Black
        Me.XrLabel82.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 425.0!)
        Me.XrLabel82.Name = "XrLabel82"
        Me.XrLabel82.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel82.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel82.StylePriority.UseBackColor = False
        Me.XrLabel82.StylePriority.UseBorderColor = False
        Me.XrLabel82.StylePriority.UseBorders = False
        Me.XrLabel82.StylePriority.UseFont = False
        Me.XrLabel82.StylePriority.UseForeColor = False
        Me.XrLabel82.StylePriority.UseTextAlignment = False
        Me.XrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTotalScoreT
        '
        Me.lblTotalScoreT.BackColor = System.Drawing.Color.White
        Me.lblTotalScoreT.BorderColor = System.Drawing.Color.Black
        Me.lblTotalScoreT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalScoreT.CanGrow = False
        Me.lblTotalScoreT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalScoreT.ForeColor = System.Drawing.Color.Black
        Me.lblTotalScoreT.LocationFloat = New DevExpress.Utils.PointFloat(725.0001!, 425.0!)
        Me.lblTotalScoreT.Name = "lblTotalScoreT"
        Me.lblTotalScoreT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalScoreT.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblTotalScoreT.StylePriority.UseBackColor = False
        Me.lblTotalScoreT.StylePriority.UseBorderColor = False
        Me.lblTotalScoreT.StylePriority.UseBorders = False
        Me.lblTotalScoreT.StylePriority.UseFont = False
        Me.lblTotalScoreT.StylePriority.UseForeColor = False
        Me.lblTotalScoreT.StylePriority.UseTextAlignment = False
        Me.lblTotalScoreT.Text = "20.00"
        Me.lblTotalScoreT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblTotalScoreT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblCreditScoreT
        '
        Me.lblCreditScoreT.BackColor = System.Drawing.Color.White
        Me.lblCreditScoreT.BorderColor = System.Drawing.Color.Black
        Me.lblCreditScoreT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblCreditScoreT.CanGrow = False
        Me.lblCreditScoreT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditScoreT.ForeColor = System.Drawing.Color.Black
        Me.lblCreditScoreT.LocationFloat = New DevExpress.Utils.PointFloat(725.0002!, 405.0!)
        Me.lblCreditScoreT.Name = "lblCreditScoreT"
        Me.lblCreditScoreT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCreditScoreT.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblCreditScoreT.StylePriority.UseBackColor = False
        Me.lblCreditScoreT.StylePriority.UseBorderColor = False
        Me.lblCreditScoreT.StylePriority.UseBorders = False
        Me.lblCreditScoreT.StylePriority.UseFont = False
        Me.lblCreditScoreT.StylePriority.UseForeColor = False
        Me.lblCreditScoreT.StylePriority.UseTextAlignment = False
        Me.lblCreditScoreT.Text = "2.00"
        Me.lblCreditScoreT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblCreditScoreT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel77
        '
        Me.XrLabel77.BackColor = System.Drawing.Color.White
        Me.XrLabel77.BorderColor = System.Drawing.Color.Black
        Me.XrLabel77.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel77.CanGrow = False
        Me.XrLabel77.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel77.ForeColor = System.Drawing.Color.Black
        Me.XrLabel77.LocationFloat = New DevExpress.Utils.PointFloat(650.0002!, 405.0!)
        Me.XrLabel77.Name = "XrLabel77"
        Me.XrLabel77.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel77.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel77.StylePriority.UseBackColor = False
        Me.XrLabel77.StylePriority.UseBorderColor = False
        Me.XrLabel77.StylePriority.UseBorders = False
        Me.XrLabel77.StylePriority.UseFont = False
        Me.XrLabel77.StylePriority.UseForeColor = False
        Me.XrLabel77.StylePriority.UseTextAlignment = False
        Me.XrLabel77.Text = "10.00%"
        Me.XrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel77.XlsxFormatString = "0.00%"
        '
        'lblCreditScore
        '
        Me.lblCreditScore.BackColor = System.Drawing.Color.White
        Me.lblCreditScore.BorderColor = System.Drawing.Color.Black
        Me.lblCreditScore.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblCreditScore.CanGrow = False
        Me.lblCreditScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditScore.ForeColor = System.Drawing.Color.Black
        Me.lblCreditScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0002!, 405.0!)
        Me.lblCreditScore.Name = "lblCreditScore"
        Me.lblCreditScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCreditScore.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblCreditScore.StylePriority.UseBackColor = False
        Me.lblCreditScore.StylePriority.UseBorderColor = False
        Me.lblCreditScore.StylePriority.UseBorders = False
        Me.lblCreditScore.StylePriority.UseFont = False
        Me.lblCreditScore.StylePriority.UseForeColor = False
        Me.lblCreditScore.StylePriority.UseTextAlignment = False
        Me.lblCreditScore.Text = "16"
        Me.lblCreditScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel79
        '
        Me.XrLabel79.BackColor = System.Drawing.Color.White
        Me.XrLabel79.BorderColor = System.Drawing.Color.Black
        Me.XrLabel79.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel79.CanGrow = False
        Me.XrLabel79.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel79.ForeColor = System.Drawing.Color.Black
        Me.XrLabel79.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 405.0!)
        Me.XrLabel79.Name = "XrLabel79"
        Me.XrLabel79.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel79.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel79.StylePriority.UseBackColor = False
        Me.XrLabel79.StylePriority.UseBorderColor = False
        Me.XrLabel79.StylePriority.UseBorders = False
        Me.XrLabel79.StylePriority.UseFont = False
        Me.XrLabel79.StylePriority.UseForeColor = False
        Me.XrLabel79.StylePriority.UseTextAlignment = False
        Me.XrLabel79.Text = "Credit/Court Checking"
        Me.XrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblSettleScoreT
        '
        Me.lblSettleScoreT.BackColor = System.Drawing.Color.White
        Me.lblSettleScoreT.BorderColor = System.Drawing.Color.Black
        Me.lblSettleScoreT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblSettleScoreT.CanGrow = False
        Me.lblSettleScoreT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettleScoreT.ForeColor = System.Drawing.Color.Black
        Me.lblSettleScoreT.LocationFloat = New DevExpress.Utils.PointFloat(725.0002!, 385.0!)
        Me.lblSettleScoreT.Name = "lblSettleScoreT"
        Me.lblSettleScoreT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSettleScoreT.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblSettleScoreT.StylePriority.UseBackColor = False
        Me.lblSettleScoreT.StylePriority.UseBorderColor = False
        Me.lblSettleScoreT.StylePriority.UseBorders = False
        Me.lblSettleScoreT.StylePriority.UseFont = False
        Me.lblSettleScoreT.StylePriority.UseForeColor = False
        Me.lblSettleScoreT.StylePriority.UseTextAlignment = False
        Me.lblSettleScoreT.Text = "3.00"
        Me.lblSettleScoreT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblSettleScoreT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel73
        '
        Me.XrLabel73.BackColor = System.Drawing.Color.White
        Me.XrLabel73.BorderColor = System.Drawing.Color.Black
        Me.XrLabel73.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel73.CanGrow = False
        Me.XrLabel73.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel73.ForeColor = System.Drawing.Color.Black
        Me.XrLabel73.LocationFloat = New DevExpress.Utils.PointFloat(650.0001!, 385.0!)
        Me.XrLabel73.Name = "XrLabel73"
        Me.XrLabel73.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel73.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel73.StylePriority.UseBackColor = False
        Me.XrLabel73.StylePriority.UseBorderColor = False
        Me.XrLabel73.StylePriority.UseBorders = False
        Me.XrLabel73.StylePriority.UseFont = False
        Me.XrLabel73.StylePriority.UseForeColor = False
        Me.XrLabel73.StylePriority.UseTextAlignment = False
        Me.XrLabel73.Text = "15.00%"
        Me.XrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel73.XlsxFormatString = "0.00%"
        '
        'lblSettleScore
        '
        Me.lblSettleScore.BackColor = System.Drawing.Color.White
        Me.lblSettleScore.BorderColor = System.Drawing.Color.Black
        Me.lblSettleScore.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblSettleScore.CanGrow = False
        Me.lblSettleScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettleScore.ForeColor = System.Drawing.Color.Black
        Me.lblSettleScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0002!, 385.0!)
        Me.lblSettleScore.Name = "lblSettleScore"
        Me.lblSettleScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSettleScore.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblSettleScore.StylePriority.UseBackColor = False
        Me.lblSettleScore.StylePriority.UseBorderColor = False
        Me.lblSettleScore.StylePriority.UseBorders = False
        Me.lblSettleScore.StylePriority.UseFont = False
        Me.lblSettleScore.StylePriority.UseForeColor = False
        Me.lblSettleScore.StylePriority.UseTextAlignment = False
        Me.lblSettleScore.Text = "17"
        Me.lblSettleScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel75
        '
        Me.XrLabel75.BackColor = System.Drawing.Color.White
        Me.XrLabel75.BorderColor = System.Drawing.Color.Black
        Me.XrLabel75.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel75.CanGrow = False
        Me.XrLabel75.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel75.ForeColor = System.Drawing.Color.Black
        Me.XrLabel75.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 385.0!)
        Me.XrLabel75.Name = "XrLabel75"
        Me.XrLabel75.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel75.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel75.StylePriority.UseBackColor = False
        Me.XrLabel75.StylePriority.UseBorderColor = False
        Me.XrLabel75.StylePriority.UseBorders = False
        Me.XrLabel75.StylePriority.UseFont = False
        Me.XrLabel75.StylePriority.UseForeColor = False
        Me.XrLabel75.StylePriority.UseTextAlignment = False
        Me.XrLabel75.Text = "Settlement of Accounts"
        Me.XrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPaymentScoreT
        '
        Me.lblPaymentScoreT.BackColor = System.Drawing.Color.White
        Me.lblPaymentScoreT.BorderColor = System.Drawing.Color.Black
        Me.lblPaymentScoreT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblPaymentScoreT.CanGrow = False
        Me.lblPaymentScoreT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentScoreT.ForeColor = System.Drawing.Color.Black
        Me.lblPaymentScoreT.LocationFloat = New DevExpress.Utils.PointFloat(725.0002!, 365.0!)
        Me.lblPaymentScoreT.Name = "lblPaymentScoreT"
        Me.lblPaymentScoreT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPaymentScoreT.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblPaymentScoreT.StylePriority.UseBackColor = False
        Me.lblPaymentScoreT.StylePriority.UseBorderColor = False
        Me.lblPaymentScoreT.StylePriority.UseBorders = False
        Me.lblPaymentScoreT.StylePriority.UseFont = False
        Me.lblPaymentScoreT.StylePriority.UseForeColor = False
        Me.lblPaymentScoreT.StylePriority.UseTextAlignment = False
        Me.lblPaymentScoreT.Text = "4.00"
        Me.lblPaymentScoreT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblPaymentScoreT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel69
        '
        Me.XrLabel69.BackColor = System.Drawing.Color.White
        Me.XrLabel69.BorderColor = System.Drawing.Color.Black
        Me.XrLabel69.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel69.CanGrow = False
        Me.XrLabel69.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel69.ForeColor = System.Drawing.Color.Black
        Me.XrLabel69.LocationFloat = New DevExpress.Utils.PointFloat(650.0001!, 365.0!)
        Me.XrLabel69.Name = "XrLabel69"
        Me.XrLabel69.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel69.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel69.StylePriority.UseBackColor = False
        Me.XrLabel69.StylePriority.UseBorderColor = False
        Me.XrLabel69.StylePriority.UseBorders = False
        Me.XrLabel69.StylePriority.UseFont = False
        Me.XrLabel69.StylePriority.UseForeColor = False
        Me.XrLabel69.StylePriority.UseTextAlignment = False
        Me.XrLabel69.Text = "20.00%"
        Me.XrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel69.XlsxFormatString = "0.00%"
        '
        'lblPaymentScore
        '
        Me.lblPaymentScore.BackColor = System.Drawing.Color.White
        Me.lblPaymentScore.BorderColor = System.Drawing.Color.Black
        Me.lblPaymentScore.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblPaymentScore.CanGrow = False
        Me.lblPaymentScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentScore.ForeColor = System.Drawing.Color.Black
        Me.lblPaymentScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0001!, 365.0!)
        Me.lblPaymentScore.Name = "lblPaymentScore"
        Me.lblPaymentScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPaymentScore.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblPaymentScore.StylePriority.UseBackColor = False
        Me.lblPaymentScore.StylePriority.UseBorderColor = False
        Me.lblPaymentScore.StylePriority.UseBorders = False
        Me.lblPaymentScore.StylePriority.UseFont = False
        Me.lblPaymentScore.StylePriority.UseForeColor = False
        Me.lblPaymentScore.StylePriority.UseTextAlignment = False
        Me.lblPaymentScore.Text = "18"
        Me.lblPaymentScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel71
        '
        Me.XrLabel71.BackColor = System.Drawing.Color.White
        Me.XrLabel71.BorderColor = System.Drawing.Color.Black
        Me.XrLabel71.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel71.CanGrow = False
        Me.XrLabel71.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel71.ForeColor = System.Drawing.Color.Black
        Me.XrLabel71.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 365.0!)
        Me.XrLabel71.Name = "XrLabel71"
        Me.XrLabel71.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel71.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel71.StylePriority.UseBackColor = False
        Me.XrLabel71.StylePriority.UseBorderColor = False
        Me.XrLabel71.StylePriority.UseBorders = False
        Me.XrLabel71.StylePriority.UseFont = False
        Me.XrLabel71.StylePriority.UseForeColor = False
        Me.XrLabel71.StylePriority.UseTextAlignment = False
        Me.XrLabel71.Text = "Mode of Payment"
        Me.XrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblHistoryScoreT
        '
        Me.lblHistoryScoreT.BackColor = System.Drawing.Color.White
        Me.lblHistoryScoreT.BorderColor = System.Drawing.Color.Black
        Me.lblHistoryScoreT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblHistoryScoreT.CanGrow = False
        Me.lblHistoryScoreT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoryScoreT.ForeColor = System.Drawing.Color.Black
        Me.lblHistoryScoreT.LocationFloat = New DevExpress.Utils.PointFloat(725.0002!, 345.0!)
        Me.lblHistoryScoreT.Name = "lblHistoryScoreT"
        Me.lblHistoryScoreT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHistoryScoreT.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblHistoryScoreT.StylePriority.UseBackColor = False
        Me.lblHistoryScoreT.StylePriority.UseBorderColor = False
        Me.lblHistoryScoreT.StylePriority.UseBorders = False
        Me.lblHistoryScoreT.StylePriority.UseFont = False
        Me.lblHistoryScoreT.StylePriority.UseForeColor = False
        Me.lblHistoryScoreT.StylePriority.UseTextAlignment = False
        Me.lblHistoryScoreT.Text = "5.00"
        Me.lblHistoryScoreT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblHistoryScoreT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel65
        '
        Me.XrLabel65.BackColor = System.Drawing.Color.White
        Me.XrLabel65.BorderColor = System.Drawing.Color.Black
        Me.XrLabel65.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel65.CanGrow = False
        Me.XrLabel65.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel65.ForeColor = System.Drawing.Color.Black
        Me.XrLabel65.LocationFloat = New DevExpress.Utils.PointFloat(650.0001!, 345.0!)
        Me.XrLabel65.Name = "XrLabel65"
        Me.XrLabel65.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel65.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel65.StylePriority.UseBackColor = False
        Me.XrLabel65.StylePriority.UseBorderColor = False
        Me.XrLabel65.StylePriority.UseBorders = False
        Me.XrLabel65.StylePriority.UseFont = False
        Me.XrLabel65.StylePriority.UseForeColor = False
        Me.XrLabel65.StylePriority.UseTextAlignment = False
        Me.XrLabel65.Text = "25.00%"
        Me.XrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel65.XlsxFormatString = "0.00%"
        '
        'lblHistoryScore
        '
        Me.lblHistoryScore.BackColor = System.Drawing.Color.White
        Me.lblHistoryScore.BorderColor = System.Drawing.Color.Black
        Me.lblHistoryScore.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblHistoryScore.CanGrow = False
        Me.lblHistoryScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoryScore.ForeColor = System.Drawing.Color.Black
        Me.lblHistoryScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0002!, 345.0!)
        Me.lblHistoryScore.Name = "lblHistoryScore"
        Me.lblHistoryScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHistoryScore.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblHistoryScore.StylePriority.UseBackColor = False
        Me.lblHistoryScore.StylePriority.UseBorderColor = False
        Me.lblHistoryScore.StylePriority.UseBorders = False
        Me.lblHistoryScore.StylePriority.UseFont = False
        Me.lblHistoryScore.StylePriority.UseForeColor = False
        Me.lblHistoryScore.StylePriority.UseTextAlignment = False
        Me.lblHistoryScore.Text = "19"
        Me.lblHistoryScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel67
        '
        Me.XrLabel67.BackColor = System.Drawing.Color.White
        Me.XrLabel67.BorderColor = System.Drawing.Color.Black
        Me.XrLabel67.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel67.CanGrow = False
        Me.XrLabel67.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel67.ForeColor = System.Drawing.Color.Black
        Me.XrLabel67.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 345.0!)
        Me.XrLabel67.Name = "XrLabel67"
        Me.XrLabel67.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel67.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel67.StylePriority.UseBackColor = False
        Me.XrLabel67.StylePriority.UseBorderColor = False
        Me.XrLabel67.StylePriority.UseBorders = False
        Me.XrLabel67.StylePriority.UseFont = False
        Me.XrLabel67.StylePriority.UseForeColor = False
        Me.XrLabel67.StylePriority.UseTextAlignment = False
        Me.XrLabel67.Text = "History of PDC's"
        Me.XrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel60
        '
        Me.XrLabel60.BackColor = System.Drawing.Color.White
        Me.XrLabel60.BorderColor = System.Drawing.Color.Black
        Me.XrLabel60.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel60.CanGrow = False
        Me.XrLabel60.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel60.ForeColor = System.Drawing.Color.Black
        Me.XrLabel60.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 325.0!)
        Me.XrLabel60.Name = "XrLabel60"
        Me.XrLabel60.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel60.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel60.StylePriority.UseBackColor = False
        Me.XrLabel60.StylePriority.UseBorderColor = False
        Me.XrLabel60.StylePriority.UseBorders = False
        Me.XrLabel60.StylePriority.UseFont = False
        Me.XrLabel60.StylePriority.UseForeColor = False
        Me.XrLabel60.StylePriority.UseTextAlignment = False
        Me.XrLabel60.Text = "Time of Payment"
        Me.XrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblTimeScore
        '
        Me.lblTimeScore.BackColor = System.Drawing.Color.White
        Me.lblTimeScore.BorderColor = System.Drawing.Color.Black
        Me.lblTimeScore.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblTimeScore.CanGrow = False
        Me.lblTimeScore.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeScore.ForeColor = System.Drawing.Color.Black
        Me.lblTimeScore.LocationFloat = New DevExpress.Utils.PointFloat(575.0002!, 325.0!)
        Me.lblTimeScore.Name = "lblTimeScore"
        Me.lblTimeScore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTimeScore.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblTimeScore.StylePriority.UseBackColor = False
        Me.lblTimeScore.StylePriority.UseBorderColor = False
        Me.lblTimeScore.StylePriority.UseBorders = False
        Me.lblTimeScore.StylePriority.UseFont = False
        Me.lblTimeScore.StylePriority.UseForeColor = False
        Me.lblTimeScore.StylePriority.UseTextAlignment = False
        Me.lblTimeScore.Text = "20"
        Me.lblTimeScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel62
        '
        Me.XrLabel62.BackColor = System.Drawing.Color.White
        Me.XrLabel62.BorderColor = System.Drawing.Color.Black
        Me.XrLabel62.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel62.CanGrow = False
        Me.XrLabel62.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel62.ForeColor = System.Drawing.Color.Black
        Me.XrLabel62.LocationFloat = New DevExpress.Utils.PointFloat(650.0002!, 325.0!)
        Me.XrLabel62.Name = "XrLabel62"
        Me.XrLabel62.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel62.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel62.StylePriority.UseBackColor = False
        Me.XrLabel62.StylePriority.UseBorderColor = False
        Me.XrLabel62.StylePriority.UseBorders = False
        Me.XrLabel62.StylePriority.UseFont = False
        Me.XrLabel62.StylePriority.UseForeColor = False
        Me.XrLabel62.StylePriority.UseTextAlignment = False
        Me.XrLabel62.Text = "30.00%"
        Me.XrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel62.XlsxFormatString = "0.00%"
        '
        'lblTimeScoreT
        '
        Me.lblTimeScoreT.BackColor = System.Drawing.Color.White
        Me.lblTimeScoreT.BorderColor = System.Drawing.Color.Black
        Me.lblTimeScoreT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblTimeScoreT.CanGrow = False
        Me.lblTimeScoreT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeScoreT.ForeColor = System.Drawing.Color.Black
        Me.lblTimeScoreT.LocationFloat = New DevExpress.Utils.PointFloat(725.0002!, 325.0!)
        Me.lblTimeScoreT.Name = "lblTimeScoreT"
        Me.lblTimeScoreT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTimeScoreT.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblTimeScoreT.StylePriority.UseBackColor = False
        Me.lblTimeScoreT.StylePriority.UseBorderColor = False
        Me.lblTimeScoreT.StylePriority.UseBorders = False
        Me.lblTimeScoreT.StylePriority.UseFont = False
        Me.lblTimeScoreT.StylePriority.UseForeColor = False
        Me.lblTimeScoreT.StylePriority.UseTextAlignment = False
        Me.lblTimeScoreT.Text = "6.00"
        Me.lblTimeScoreT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblTimeScoreT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel59
        '
        Me.XrLabel59.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel59.BorderColor = System.Drawing.Color.Black
        Me.XrLabel59.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel59.CanGrow = False
        Me.XrLabel59.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel59.ForeColor = System.Drawing.Color.White
        Me.XrLabel59.LocationFloat = New DevExpress.Utils.PointFloat(725.0!, 305.0!)
        Me.XrLabel59.Name = "XrLabel59"
        Me.XrLabel59.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel59.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel59.StylePriority.UseBackColor = False
        Me.XrLabel59.StylePriority.UseBorderColor = False
        Me.XrLabel59.StylePriority.UseBorders = False
        Me.XrLabel59.StylePriority.UseFont = False
        Me.XrLabel59.StylePriority.UseForeColor = False
        Me.XrLabel59.StylePriority.UseTextAlignment = False
        Me.XrLabel59.Text = "T O T A L"
        Me.XrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel58
        '
        Me.XrLabel58.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel58.BorderColor = System.Drawing.Color.Black
        Me.XrLabel58.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel58.CanGrow = False
        Me.XrLabel58.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel58.ForeColor = System.Drawing.Color.White
        Me.XrLabel58.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 305.0!)
        Me.XrLabel58.Name = "XrLabel58"
        Me.XrLabel58.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel58.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel58.StylePriority.UseBackColor = False
        Me.XrLabel58.StylePriority.UseBorderColor = False
        Me.XrLabel58.StylePriority.UseBorders = False
        Me.XrLabel58.StylePriority.UseFont = False
        Me.XrLabel58.StylePriority.UseForeColor = False
        Me.XrLabel58.StylePriority.UseTextAlignment = False
        Me.XrLabel58.Text = "Rate"
        Me.XrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel57
        '
        Me.XrLabel57.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel57.BorderColor = System.Drawing.Color.Black
        Me.XrLabel57.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel57.CanGrow = False
        Me.XrLabel57.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel57.ForeColor = System.Drawing.Color.White
        Me.XrLabel57.LocationFloat = New DevExpress.Utils.PointFloat(575.0!, 305.0!)
        Me.XrLabel57.Name = "XrLabel57"
        Me.XrLabel57.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel57.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel57.StylePriority.UseBackColor = False
        Me.XrLabel57.StylePriority.UseBorderColor = False
        Me.XrLabel57.StylePriority.UseBorders = False
        Me.XrLabel57.StylePriority.UseFont = False
        Me.XrLabel57.StylePriority.UseForeColor = False
        Me.XrLabel57.StylePriority.UseTextAlignment = False
        Me.XrLabel57.Text = "Score"
        Me.XrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel56
        '
        Me.XrLabel56.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel56.BorderColor = System.Drawing.Color.Black
        Me.XrLabel56.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel56.CanGrow = False
        Me.XrLabel56.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel56.ForeColor = System.Drawing.Color.White
        Me.XrLabel56.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 305.0!)
        Me.XrLabel56.Name = "XrLabel56"
        Me.XrLabel56.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel56.SizeF = New System.Drawing.SizeF(275.0!, 20.0!)
        Me.XrLabel56.StylePriority.UseBackColor = False
        Me.XrLabel56.StylePriority.UseBorderColor = False
        Me.XrLabel56.StylePriority.UseBorders = False
        Me.XrLabel56.StylePriority.UseFont = False
        Me.XrLabel56.StylePriority.UseForeColor = False
        Me.XrLabel56.StylePriority.UseTextAlignment = False
        Me.XrLabel56.Text = "Summary"
        Me.XrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblOR_CR
        '
        Me.lblOR_CR.BackColor = System.Drawing.Color.White
        Me.lblOR_CR.BorderColor = System.Drawing.Color.Black
        Me.lblOR_CR.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblOR_CR.CanGrow = False
        Me.lblOR_CR.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOR_CR.ForeColor = System.Drawing.Color.Black
        Me.lblOR_CR.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 284.0002!)
        Me.lblOR_CR.Name = "lblOR_CR"
        Me.lblOR_CR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOR_CR.SizeF = New System.Drawing.SizeF(400.0!, 19.0!)
        Me.lblOR_CR.StylePriority.UseBackColor = False
        Me.lblOR_CR.StylePriority.UseBorderColor = False
        Me.lblOR_CR.StylePriority.UseBorders = False
        Me.lblOR_CR.StylePriority.UseFont = False
        Me.lblOR_CR.StylePriority.UseForeColor = False
        Me.lblOR_CR.StylePriority.UseTextAlignment = False
        Me.lblOR_CR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel55
        '
        Me.XrLabel55.BackColor = System.Drawing.Color.White
        Me.XrLabel55.BorderColor = System.Drawing.Color.Black
        Me.XrLabel55.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel55.CanGrow = False
        Me.XrLabel55.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel55.ForeColor = System.Drawing.Color.Black
        Me.XrLabel55.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 284.0002!)
        Me.XrLabel55.Name = "XrLabel55"
        Me.XrLabel55.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel55.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel55.StylePriority.UseBackColor = False
        Me.XrLabel55.StylePriority.UseBorderColor = False
        Me.XrLabel55.StylePriority.UseBorders = False
        Me.XrLabel55.StylePriority.UseFont = False
        Me.XrLabel55.StylePriority.UseForeColor = False
        Me.XrLabel55.StylePriority.UseTextAlignment = False
        Me.XrLabel55.Text = "OR / CR :"
        Me.XrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblInsuranceCompany
        '
        Me.lblInsuranceCompany.BackColor = System.Drawing.Color.White
        Me.lblInsuranceCompany.BorderColor = System.Drawing.Color.Black
        Me.lblInsuranceCompany.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblInsuranceCompany.CanGrow = False
        Me.lblInsuranceCompany.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsuranceCompany.ForeColor = System.Drawing.Color.Black
        Me.lblInsuranceCompany.LocationFloat = New DevExpress.Utils.PointFloat(665.0!, 265.0002!)
        Me.lblInsuranceCompany.Name = "lblInsuranceCompany"
        Me.lblInsuranceCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInsuranceCompany.SizeF = New System.Drawing.SizeF(135.0001!, 19.00003!)
        Me.lblInsuranceCompany.StylePriority.UseBackColor = False
        Me.lblInsuranceCompany.StylePriority.UseBorderColor = False
        Me.lblInsuranceCompany.StylePriority.UseBorders = False
        Me.lblInsuranceCompany.StylePriority.UseFont = False
        Me.lblInsuranceCompany.StylePriority.UseForeColor = False
        Me.lblInsuranceCompany.StylePriority.UseTextAlignment = False
        Me.lblInsuranceCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel51
        '
        Me.XrLabel51.BackColor = System.Drawing.Color.White
        Me.XrLabel51.BorderColor = System.Drawing.Color.Black
        Me.XrLabel51.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel51.CanGrow = False
        Me.XrLabel51.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel51.ForeColor = System.Drawing.Color.Black
        Me.XrLabel51.LocationFloat = New DevExpress.Utils.PointFloat(555.0001!, 265.0002!)
        Me.XrLabel51.Name = "XrLabel51"
        Me.XrLabel51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel51.SizeF = New System.Drawing.SizeF(109.9999!, 19.00003!)
        Me.XrLabel51.StylePriority.UseBackColor = False
        Me.XrLabel51.StylePriority.UseBorderColor = False
        Me.XrLabel51.StylePriority.UseBorders = False
        Me.XrLabel51.StylePriority.UseFont = False
        Me.XrLabel51.StylePriority.UseForeColor = False
        Me.XrLabel51.StylePriority.UseTextAlignment = False
        Me.XrLabel51.Text = "Insurance Company :"
        Me.XrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel52
        '
        Me.XrLabel52.BackColor = System.Drawing.Color.White
        Me.XrLabel52.BorderColor = System.Drawing.Color.Black
        Me.XrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel52.CanGrow = False
        Me.XrLabel52.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel52.ForeColor = System.Drawing.Color.Black
        Me.XrLabel52.LocationFloat = New DevExpress.Utils.PointFloat(555.0001!, 246.0001!)
        Me.XrLabel52.Name = "XrLabel52"
        Me.XrLabel52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel52.SizeF = New System.Drawing.SizeF(109.9999!, 19.00005!)
        Me.XrLabel52.StylePriority.UseBackColor = False
        Me.XrLabel52.StylePriority.UseBorderColor = False
        Me.XrLabel52.StylePriority.UseBorders = False
        Me.XrLabel52.StylePriority.UseFont = False
        Me.XrLabel52.StylePriority.UseForeColor = False
        Me.XrLabel52.StylePriority.UseTextAlignment = False
        Me.XrLabel52.Text = "Amount :"
        Me.XrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAmountRenewal
        '
        Me.lblAmountRenewal.BackColor = System.Drawing.Color.White
        Me.lblAmountRenewal.BorderColor = System.Drawing.Color.Black
        Me.lblAmountRenewal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblAmountRenewal.CanGrow = False
        Me.lblAmountRenewal.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountRenewal.ForeColor = System.Drawing.Color.Black
        Me.lblAmountRenewal.LocationFloat = New DevExpress.Utils.PointFloat(665.0!, 246.0001!)
        Me.lblAmountRenewal.Name = "lblAmountRenewal"
        Me.lblAmountRenewal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmountRenewal.SizeF = New System.Drawing.SizeF(135.0001!, 19.00005!)
        Me.lblAmountRenewal.StylePriority.UseBackColor = False
        Me.lblAmountRenewal.StylePriority.UseBorderColor = False
        Me.lblAmountRenewal.StylePriority.UseBorders = False
        Me.lblAmountRenewal.StylePriority.UseFont = False
        Me.lblAmountRenewal.StylePriority.UseForeColor = False
        Me.lblAmountRenewal.StylePriority.UseTextAlignment = False
        Me.lblAmountRenewal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel44
        '
        Me.XrLabel44.BackColor = System.Drawing.Color.White
        Me.XrLabel44.BorderColor = System.Drawing.Color.Black
        Me.XrLabel44.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel44.CanGrow = False
        Me.XrLabel44.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel44.ForeColor = System.Drawing.Color.Black
        Me.XrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 227.0001!)
        Me.XrLabel44.Name = "XrLabel44"
        Me.XrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel44.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel44.StylePriority.UseBackColor = False
        Me.XrLabel44.StylePriority.UseBorderColor = False
        Me.XrLabel44.StylePriority.UseBorders = False
        Me.XrLabel44.StylePriority.UseFont = False
        Me.XrLabel44.StylePriority.UseForeColor = False
        Me.XrLabel44.StylePriority.UseTextAlignment = False
        Me.XrLabel44.Text = "Existing Policy"
        Me.XrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel45
        '
        Me.XrLabel45.BackColor = System.Drawing.Color.White
        Me.XrLabel45.BorderColor = System.Drawing.Color.Black
        Me.XrLabel45.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel45.CanGrow = False
        Me.XrLabel45.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel45.ForeColor = System.Drawing.Color.Black
        Me.XrLabel45.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 227.0001!)
        Me.XrLabel45.Name = "XrLabel45"
        Me.XrLabel45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel45.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.XrLabel45.StylePriority.UseBackColor = False
        Me.XrLabel45.StylePriority.UseBorderColor = False
        Me.XrLabel45.StylePriority.UseBorders = False
        Me.XrLabel45.StylePriority.UseFont = False
        Me.XrLabel45.StylePriority.UseForeColor = False
        Me.XrLabel45.StylePriority.UseTextAlignment = False
        Me.XrLabel45.Text = "Due of Renewal"
        Me.XrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmountPolicy
        '
        Me.lblAmountPolicy.BackColor = System.Drawing.Color.White
        Me.lblAmountPolicy.BorderColor = System.Drawing.Color.Black
        Me.lblAmountPolicy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblAmountPolicy.CanGrow = False
        Me.lblAmountPolicy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountPolicy.ForeColor = System.Drawing.Color.Black
        Me.lblAmountPolicy.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 246.0001!)
        Me.lblAmountPolicy.Name = "lblAmountPolicy"
        Me.lblAmountPolicy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmountPolicy.SizeF = New System.Drawing.SizeF(115.0!, 19.0!)
        Me.lblAmountPolicy.StylePriority.UseBackColor = False
        Me.lblAmountPolicy.StylePriority.UseBorderColor = False
        Me.lblAmountPolicy.StylePriority.UseBorders = False
        Me.lblAmountPolicy.StylePriority.UseFont = False
        Me.lblAmountPolicy.StylePriority.UseForeColor = False
        Me.lblAmountPolicy.StylePriority.UseTextAlignment = False
        Me.lblAmountPolicy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel47
        '
        Me.XrLabel47.BackColor = System.Drawing.Color.White
        Me.XrLabel47.BorderColor = System.Drawing.Color.Black
        Me.XrLabel47.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel47.CanGrow = False
        Me.XrLabel47.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel47.ForeColor = System.Drawing.Color.Black
        Me.XrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 246.0001!)
        Me.XrLabel47.Name = "XrLabel47"
        Me.XrLabel47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel47.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel47.StylePriority.UseBackColor = False
        Me.XrLabel47.StylePriority.UseBorderColor = False
        Me.XrLabel47.StylePriority.UseBorders = False
        Me.XrLabel47.StylePriority.UseFont = False
        Me.XrLabel47.StylePriority.UseForeColor = False
        Me.XrLabel47.StylePriority.UseTextAlignment = False
        Me.XrLabel47.Text = "Amount :"
        Me.XrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel49
        '
        Me.XrLabel49.BackColor = System.Drawing.Color.White
        Me.XrLabel49.BorderColor = System.Drawing.Color.Black
        Me.XrLabel49.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel49.CanGrow = False
        Me.XrLabel49.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel49.ForeColor = System.Drawing.Color.Black
        Me.XrLabel49.LocationFloat = New DevExpress.Utils.PointFloat(340.0001!, 265.0002!)
        Me.XrLabel49.Name = "XrLabel49"
        Me.XrLabel49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel49.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel49.StylePriority.UseBackColor = False
        Me.XrLabel49.StylePriority.UseBorderColor = False
        Me.XrLabel49.StylePriority.UseBorders = False
        Me.XrLabel49.StylePriority.UseFont = False
        Me.XrLabel49.StylePriority.UseForeColor = False
        Me.XrLabel49.StylePriority.UseTextAlignment = False
        Me.XrLabel49.Text = "Date Granted :"
        Me.XrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDatePolicy
        '
        Me.lblDatePolicy.BackColor = System.Drawing.Color.White
        Me.lblDatePolicy.BorderColor = System.Drawing.Color.Black
        Me.lblDatePolicy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDatePolicy.CanGrow = False
        Me.lblDatePolicy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatePolicy.ForeColor = System.Drawing.Color.Black
        Me.lblDatePolicy.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 265.0002!)
        Me.lblDatePolicy.Name = "lblDatePolicy"
        Me.lblDatePolicy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDatePolicy.SizeF = New System.Drawing.SizeF(115.0!, 19.0!)
        Me.lblDatePolicy.StylePriority.UseBackColor = False
        Me.lblDatePolicy.StylePriority.UseBorderColor = False
        Me.lblDatePolicy.StylePriority.UseBorders = False
        Me.lblDatePolicy.StylePriority.UseFont = False
        Me.lblDatePolicy.StylePriority.UseForeColor = False
        Me.lblDatePolicy.StylePriority.UseTextAlignment = False
        Me.lblDatePolicy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel43
        '
        Me.XrLabel43.BackColor = System.Drawing.Color.White
        Me.XrLabel43.BorderColor = System.Drawing.Color.Black
        Me.XrLabel43.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel43.CanGrow = False
        Me.XrLabel43.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel43.ForeColor = System.Drawing.Color.Black
        Me.XrLabel43.LocationFloat = New DevExpress.Utils.PointFloat(570.0!, 208.0001!)
        Me.XrLabel43.Name = "XrLabel43"
        Me.XrLabel43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel43.SizeF = New System.Drawing.SizeF(230.0!, 19.00005!)
        Me.XrLabel43.StylePriority.UseBackColor = False
        Me.XrLabel43.StylePriority.UseBorderColor = False
        Me.XrLabel43.StylePriority.UseBorders = False
        Me.XrLabel43.StylePriority.UseFont = False
        Me.XrLabel43.StylePriority.UseForeColor = False
        Me.XrLabel43.StylePriority.UseTextAlignment = False
        Me.XrLabel43.Text = "Insurance In-Charge"
        Me.XrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDateInsurance
        '
        Me.lblDateInsurance.BackColor = System.Drawing.Color.White
        Me.lblDateInsurance.BorderColor = System.Drawing.Color.Black
        Me.lblDateInsurance.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDateInsurance.CanGrow = False
        Me.lblDateInsurance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateInsurance.ForeColor = System.Drawing.Color.Black
        Me.lblDateInsurance.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 208.0001!)
        Me.lblDateInsurance.Name = "lblDateInsurance"
        Me.lblDateInsurance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateInsurance.SizeF = New System.Drawing.SizeF(115.0!, 19.0!)
        Me.lblDateInsurance.StylePriority.UseBackColor = False
        Me.lblDateInsurance.StylePriority.UseBorderColor = False
        Me.lblDateInsurance.StylePriority.UseBorders = False
        Me.lblDateInsurance.StylePriority.UseFont = False
        Me.lblDateInsurance.StylePriority.UseForeColor = False
        Me.lblDateInsurance.StylePriority.UseTextAlignment = False
        Me.lblDateInsurance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel42
        '
        Me.XrLabel42.BackColor = System.Drawing.Color.White
        Me.XrLabel42.BorderColor = System.Drawing.Color.Black
        Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel42.CanGrow = False
        Me.XrLabel42.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel42.ForeColor = System.Drawing.Color.Black
        Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 208.0001!)
        Me.XrLabel42.Name = "XrLabel42"
        Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel42.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel42.StylePriority.UseBackColor = False
        Me.XrLabel42.StylePriority.UseBorderColor = False
        Me.XrLabel42.StylePriority.UseBorders = False
        Me.XrLabel42.StylePriority.UseFont = False
        Me.XrLabel42.StylePriority.UseForeColor = False
        Me.XrLabel42.StylePriority.UseTextAlignment = False
        Me.XrLabel42.Text = "Date Granted :"
        Me.XrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblInsuranceInCharge
        '
        Me.lblInsuranceInCharge.BackColor = System.Drawing.Color.White
        Me.lblInsuranceInCharge.BorderColor = System.Drawing.Color.Black
        Me.lblInsuranceInCharge.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblInsuranceInCharge.CanGrow = False
        Me.lblInsuranceInCharge.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsuranceInCharge.ForeColor = System.Drawing.Color.Black
        Me.lblInsuranceInCharge.LocationFloat = New DevExpress.Utils.PointFloat(570.0!, 189.0!)
        Me.lblInsuranceInCharge.Name = "lblInsuranceInCharge"
        Me.lblInsuranceInCharge.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInsuranceInCharge.SizeF = New System.Drawing.SizeF(230.0!, 19.0!)
        Me.lblInsuranceInCharge.StylePriority.UseBackColor = False
        Me.lblInsuranceInCharge.StylePriority.UseBorderColor = False
        Me.lblInsuranceInCharge.StylePriority.UseBorders = False
        Me.lblInsuranceInCharge.StylePriority.UseFont = False
        Me.lblInsuranceInCharge.StylePriority.UseForeColor = False
        Me.lblInsuranceInCharge.StylePriority.UseTextAlignment = False
        Me.lblInsuranceInCharge.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel38
        '
        Me.XrLabel38.BackColor = System.Drawing.Color.White
        Me.XrLabel38.BorderColor = System.Drawing.Color.Black
        Me.XrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel38.CanGrow = False
        Me.XrLabel38.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel38.ForeColor = System.Drawing.Color.Black
        Me.XrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 189.0!)
        Me.XrLabel38.Name = "XrLabel38"
        Me.XrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel38.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel38.StylePriority.UseBackColor = False
        Me.XrLabel38.StylePriority.UseBorderColor = False
        Me.XrLabel38.StylePriority.UseBorders = False
        Me.XrLabel38.StylePriority.UseFont = False
        Me.XrLabel38.StylePriority.UseForeColor = False
        Me.XrLabel38.StylePriority.UseTextAlignment = False
        Me.XrLabel38.Text = "Amount :"
        Me.XrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAmount_Insurance
        '
        Me.lblAmount_Insurance.BackColor = System.Drawing.Color.White
        Me.lblAmount_Insurance.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_Insurance.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblAmount_Insurance.CanGrow = False
        Me.lblAmount_Insurance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_Insurance.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_Insurance.LocationFloat = New DevExpress.Utils.PointFloat(440.0!, 189.0!)
        Me.lblAmount_Insurance.Name = "lblAmount_Insurance"
        Me.lblAmount_Insurance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_Insurance.SizeF = New System.Drawing.SizeF(115.0!, 19.0!)
        Me.lblAmount_Insurance.StylePriority.UseBackColor = False
        Me.lblAmount_Insurance.StylePriority.UseBorderColor = False
        Me.lblAmount_Insurance.StylePriority.UseBorders = False
        Me.lblAmount_Insurance.StylePriority.UseFont = False
        Me.lblAmount_Insurance.StylePriority.UseForeColor = False
        Me.lblAmount_Insurance.StylePriority.UseTextAlignment = False
        Me.lblAmount_Insurance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel37
        '
        Me.XrLabel37.BackColor = System.Drawing.Color.White
        Me.XrLabel37.BorderColor = System.Drawing.Color.Black
        Me.XrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel37.CanGrow = False
        Me.XrLabel37.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel37.ForeColor = System.Drawing.Color.Black
        Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 170.0!)
        Me.XrLabel37.Name = "XrLabel37"
        Me.XrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel37.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.XrLabel37.StylePriority.UseBackColor = False
        Me.XrLabel37.StylePriority.UseBorderColor = False
        Me.XrLabel37.StylePriority.UseBorders = False
        Me.XrLabel37.StylePriority.UseFont = False
        Me.XrLabel37.StylePriority.UseForeColor = False
        Me.XrLabel37.StylePriority.UseTextAlignment = False
        Me.XrLabel37.Text = "(Accounts Receivable)"
        Me.XrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel36
        '
        Me.XrLabel36.BackColor = System.Drawing.Color.White
        Me.XrLabel36.BorderColor = System.Drawing.Color.Black
        Me.XrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel36.CanGrow = False
        Me.XrLabel36.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel36.ForeColor = System.Drawing.Color.Black
        Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 170.0!)
        Me.XrLabel36.Name = "XrLabel36"
        Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel36.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel36.StylePriority.UseBackColor = False
        Me.XrLabel36.StylePriority.UseBorderColor = False
        Me.XrLabel36.StylePriority.UseBorders = False
        Me.XrLabel36.StylePriority.UseFont = False
        Me.XrLabel36.StylePriority.UseForeColor = False
        Me.XrLabel36.StylePriority.UseTextAlignment = False
        Me.XrLabel36.Text = "Unpaid Insurance"
        Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel35
        '
        Me.XrLabel35.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel35.BorderColor = System.Drawing.Color.Black
        Me.XrLabel35.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel35.CanGrow = False
        Me.XrLabel35.Font = New System.Drawing.Font("Century Gothic", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel35.ForeColor = System.Drawing.Color.White
        Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 150.0!)
        Me.XrLabel35.Name = "XrLabel35"
        Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel35.SizeF = New System.Drawing.SizeF(225.0!, 20.0!)
        Me.XrLabel35.StylePriority.UseBackColor = False
        Me.XrLabel35.StylePriority.UseBorderColor = False
        Me.XrLabel35.StylePriority.UseBorders = False
        Me.XrLabel35.StylePriority.UseFont = False
        Me.XrLabel35.StylePriority.UseForeColor = False
        Me.XrLabel35.StylePriority.UseTextAlignment = False
        Me.XrLabel35.Text = "INSURANCE"
        Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel33
        '
        Me.XrLabel33.BackColor = System.Drawing.Color.White
        Me.XrLabel33.BorderColor = System.Drawing.Color.Black
        Me.XrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel33.CanGrow = False
        Me.XrLabel33.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel33.ForeColor = System.Drawing.Color.Black
        Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(0.0001907349!, 132.9997!)
        Me.XrLabel33.Name = "XrLabel33"
        Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel33.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel33.StylePriority.UseBackColor = False
        Me.XrLabel33.StylePriority.UseBorderColor = False
        Me.XrLabel33.StylePriority.UseBorders = False
        Me.XrLabel33.StylePriority.UseFont = False
        Me.XrLabel33.StylePriority.UseForeColor = False
        Me.XrLabel33.StylePriority.UseTextAlignment = False
        Me.XrLabel33.Text = "As Of :"
        Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'txtAsOf
        '
        Me.txtAsOf.BackColor = System.Drawing.Color.White
        Me.txtAsOf.BorderColor = System.Drawing.Color.Black
        Me.txtAsOf.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.txtAsOf.CanGrow = False
        Me.txtAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.txtAsOf.ForeColor = System.Drawing.Color.Black
        Me.txtAsOf.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 132.9997!)
        Me.txtAsOf.Name = "txtAsOf"
        Me.txtAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAsOf.SizeF = New System.Drawing.SizeF(190.0!, 19.0!)
        Me.txtAsOf.StylePriority.UseBackColor = False
        Me.txtAsOf.StylePriority.UseBorderColor = False
        Me.txtAsOf.StylePriority.UseBorders = False
        Me.txtAsOf.StylePriority.UseFont = False
        Me.txtAsOf.StylePriority.UseForeColor = False
        Me.txtAsOf.StylePriority.UseTextAlignment = False
        Me.txtAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxMonthly
        '
        Me.cbxMonthly.BackColor = System.Drawing.Color.White
        Me.cbxMonthly.BorderColor = System.Drawing.Color.Black
        Me.cbxMonthly.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.cbxMonthly.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxMonthly.ForeColor = System.Drawing.Color.Black
        Me.cbxMonthly.LocationFloat = New DevExpress.Utils.PointFloat(230.0!, 114.0!)
        Me.cbxMonthly.Name = "cbxMonthly"
        Me.cbxMonthly.SizeF = New System.Drawing.SizeF(65.0!, 18.99974!)
        Me.cbxMonthly.StylePriority.UseBackColor = False
        Me.cbxMonthly.StylePriority.UseBorderColor = False
        Me.cbxMonthly.StylePriority.UseBorders = False
        Me.cbxMonthly.StylePriority.UseFont = False
        Me.cbxMonthly.StylePriority.UseForeColor = False
        Me.cbxMonthly.Text = "Monthly"
        '
        'cbxBimonthly
        '
        Me.cbxBimonthly.BackColor = System.Drawing.Color.White
        Me.cbxBimonthly.BorderColor = System.Drawing.Color.Black
        Me.cbxBimonthly.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.cbxBimonthly.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxBimonthly.ForeColor = System.Drawing.Color.Black
        Me.cbxBimonthly.LocationFloat = New DevExpress.Utils.PointFloat(165.0!, 114.0006!)
        Me.cbxBimonthly.Name = "cbxBimonthly"
        Me.cbxBimonthly.SizeF = New System.Drawing.SizeF(65.0!, 18.99974!)
        Me.cbxBimonthly.StylePriority.UseBackColor = False
        Me.cbxBimonthly.StylePriority.UseBorderColor = False
        Me.cbxBimonthly.StylePriority.UseBorders = False
        Me.cbxBimonthly.StylePriority.UseFont = False
        Me.cbxBimonthly.StylePriority.UseForeColor = False
        Me.cbxBimonthly.Text = "Bimonthly"
        '
        'cbxWeekly
        '
        Me.cbxWeekly.BackColor = System.Drawing.Color.White
        Me.cbxWeekly.BorderColor = System.Drawing.Color.Black
        Me.cbxWeekly.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.cbxWeekly.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxWeekly.ForeColor = System.Drawing.Color.Black
        Me.cbxWeekly.LocationFloat = New DevExpress.Utils.PointFloat(99.99998!, 114.0006!)
        Me.cbxWeekly.Name = "cbxWeekly"
        Me.cbxWeekly.SizeF = New System.Drawing.SizeF(65.0!, 18.99974!)
        Me.cbxWeekly.StylePriority.UseBackColor = False
        Me.cbxWeekly.StylePriority.UseBorderColor = False
        Me.cbxWeekly.StylePriority.UseBorders = False
        Me.cbxWeekly.StylePriority.UseFont = False
        Me.cbxWeekly.StylePriority.UseForeColor = False
        Me.cbxWeekly.Text = "Weekly"
        '
        'cbxDaily
        '
        Me.cbxDaily.BackColor = System.Drawing.Color.White
        Me.cbxDaily.BorderColor = System.Drawing.Color.Black
        Me.cbxDaily.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.cbxDaily.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxDaily.ForeColor = System.Drawing.Color.Black
        Me.cbxDaily.LocationFloat = New DevExpress.Utils.PointFloat(35.00001!, 114.0006!)
        Me.cbxDaily.Name = "cbxDaily"
        Me.cbxDaily.SizeF = New System.Drawing.SizeF(65.0!, 18.99973!)
        Me.cbxDaily.StylePriority.UseBackColor = False
        Me.cbxDaily.StylePriority.UseBorderColor = False
        Me.cbxDaily.StylePriority.UseBorders = False
        Me.cbxDaily.StylePriority.UseFont = False
        Me.cbxDaily.StylePriority.UseForeColor = False
        Me.cbxDaily.Text = "Daily"
        '
        'XrLabel31
        '
        Me.XrLabel31.BackColor = System.Drawing.Color.White
        Me.XrLabel31.BorderColor = System.Drawing.Color.Black
        Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel31.CanGrow = False
        Me.XrLabel31.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel31.ForeColor = System.Drawing.Color.Black
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 114.0!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel31.StylePriority.UseBackColor = False
        Me.XrLabel31.StylePriority.UseBorderColor = False
        Me.XrLabel31.StylePriority.UseBorders = False
        Me.XrLabel31.StylePriority.UseFont = False
        Me.XrLabel31.StylePriority.UseForeColor = False
        Me.XrLabel31.StylePriority.UseTextAlignment = False
        Me.XrLabel31.Text = "Monthly Amortization :"
        Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblMonthlyAmortization
        '
        Me.lblMonthlyAmortization.BackColor = System.Drawing.Color.White
        Me.lblMonthlyAmortization.BorderColor = System.Drawing.Color.Black
        Me.lblMonthlyAmortization.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblMonthlyAmortization.CanGrow = False
        Me.lblMonthlyAmortization.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyAmortization.ForeColor = System.Drawing.Color.Black
        Me.lblMonthlyAmortization.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 114.0!)
        Me.lblMonthlyAmortization.Name = "lblMonthlyAmortization"
        Me.lblMonthlyAmortization.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthlyAmortization.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblMonthlyAmortization.StylePriority.UseBackColor = False
        Me.lblMonthlyAmortization.StylePriority.UseBorderColor = False
        Me.lblMonthlyAmortization.StylePriority.UseBorders = False
        Me.lblMonthlyAmortization.StylePriority.UseFont = False
        Me.lblMonthlyAmortization.StylePriority.UseForeColor = False
        Me.lblMonthlyAmortization.StylePriority.UseTextAlignment = False
        Me.lblMonthlyAmortization.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel29
        '
        Me.XrLabel29.BackColor = System.Drawing.Color.White
        Me.XrLabel29.BorderColor = System.Drawing.Color.Black
        Me.XrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel29.CanGrow = False
        Me.XrLabel29.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel29.ForeColor = System.Drawing.Color.Black
        Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 95.00002!)
        Me.XrLabel29.Name = "XrLabel29"
        Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel29.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel29.StylePriority.UseBackColor = False
        Me.XrLabel29.StylePriority.UseBorderColor = False
        Me.XrLabel29.StylePriority.UseBorders = False
        Me.XrLabel29.StylePriority.UseFont = False
        Me.XrLabel29.StylePriority.UseForeColor = False
        Me.XrLabel29.StylePriority.UseTextAlignment = False
        Me.XrLabel29.Text = "Face Amount :"
        Me.XrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblFaceAmount
        '
        Me.lblFaceAmount.BackColor = System.Drawing.Color.White
        Me.lblFaceAmount.BorderColor = System.Drawing.Color.Black
        Me.lblFaceAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblFaceAmount.CanGrow = False
        Me.lblFaceAmount.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaceAmount.ForeColor = System.Drawing.Color.Black
        Me.lblFaceAmount.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 95.00002!)
        Me.lblFaceAmount.Name = "lblFaceAmount"
        Me.lblFaceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFaceAmount.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblFaceAmount.StylePriority.UseBackColor = False
        Me.lblFaceAmount.StylePriority.UseBorderColor = False
        Me.lblFaceAmount.StylePriority.UseBorders = False
        Me.lblFaceAmount.StylePriority.UseFont = False
        Me.lblFaceAmount.StylePriority.UseForeColor = False
        Me.lblFaceAmount.StylePriority.UseTextAlignment = False
        Me.lblFaceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel27
        '
        Me.XrLabel27.BackColor = System.Drawing.Color.White
        Me.XrLabel27.BorderColor = System.Drawing.Color.Black
        Me.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel27.CanGrow = False
        Me.XrLabel27.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel27.ForeColor = System.Drawing.Color.Black
        Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 76.00002!)
        Me.XrLabel27.Name = "XrLabel27"
        Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel27.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel27.StylePriority.UseBackColor = False
        Me.XrLabel27.StylePriority.UseBorderColor = False
        Me.XrLabel27.StylePriority.UseBorders = False
        Me.XrLabel27.StylePriority.UseFont = False
        Me.XrLabel27.StylePriority.UseForeColor = False
        Me.XrLabel27.StylePriority.UseTextAlignment = False
        Me.XrLabel27.Text = "Principal :"
        Me.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BackColor = System.Drawing.Color.White
        Me.lblPrincipal.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblPrincipal.CanGrow = False
        Me.lblPrincipal.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 76.00002!)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblPrincipal.StylePriority.UseBackColor = False
        Me.lblPrincipal.StylePriority.UseBorderColor = False
        Me.lblPrincipal.StylePriority.UseBorders = False
        Me.lblPrincipal.StylePriority.UseFont = False
        Me.lblPrincipal.StylePriority.UseForeColor = False
        Me.lblPrincipal.StylePriority.UseTextAlignment = False
        Me.lblPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel25
        '
        Me.XrLabel25.BackColor = System.Drawing.Color.White
        Me.XrLabel25.BorderColor = System.Drawing.Color.Black
        Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel25.CanGrow = False
        Me.XrLabel25.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel25.ForeColor = System.Drawing.Color.Black
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 57.00003!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel25.StylePriority.UseBackColor = False
        Me.XrLabel25.StylePriority.UseBorderColor = False
        Me.XrLabel25.StylePriority.UseBorders = False
        Me.XrLabel25.StylePriority.UseFont = False
        Me.XrLabel25.StylePriority.UseForeColor = False
        Me.XrLabel25.StylePriority.UseTextAlignment = False
        Me.XrLabel25.Text = "Date Granted :"
        Me.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDateGranted
        '
        Me.lblDateGranted.BackColor = System.Drawing.Color.White
        Me.lblDateGranted.BorderColor = System.Drawing.Color.Black
        Me.lblDateGranted.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDateGranted.CanGrow = False
        Me.lblDateGranted.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateGranted.ForeColor = System.Drawing.Color.Black
        Me.lblDateGranted.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 57.00003!)
        Me.lblDateGranted.Name = "lblDateGranted"
        Me.lblDateGranted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateGranted.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblDateGranted.StylePriority.UseBackColor = False
        Me.lblDateGranted.StylePriority.UseBorderColor = False
        Me.lblDateGranted.StylePriority.UseBorders = False
        Me.lblDateGranted.StylePriority.UseFont = False
        Me.lblDateGranted.StylePriority.UseForeColor = False
        Me.lblDateGranted.StylePriority.UseTextAlignment = False
        Me.lblDateGranted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDue
        '
        Me.lblDue.BackColor = System.Drawing.Color.White
        Me.lblDue.BorderColor = System.Drawing.Color.Black
        Me.lblDue.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDue.CanGrow = False
        Me.lblDue.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDue.ForeColor = System.Drawing.Color.Black
        Me.lblDue.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 38.00004!)
        Me.lblDue.Name = "lblDue"
        Me.lblDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDue.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblDue.StylePriority.UseBackColor = False
        Me.lblDue.StylePriority.UseBorderColor = False
        Me.lblDue.StylePriority.UseBorders = False
        Me.lblDue.StylePriority.UseFont = False
        Me.lblDue.StylePriority.UseForeColor = False
        Me.lblDue.StylePriority.UseTextAlignment = False
        Me.lblDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel24
        '
        Me.XrLabel24.BackColor = System.Drawing.Color.White
        Me.XrLabel24.BorderColor = System.Drawing.Color.Black
        Me.XrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel24.CanGrow = False
        Me.XrLabel24.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel24.ForeColor = System.Drawing.Color.Black
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 38.00004!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel24.StylePriority.UseBackColor = False
        Me.XrLabel24.StylePriority.UseBorderColor = False
        Me.XrLabel24.StylePriority.UseBorders = False
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.StylePriority.UseForeColor = False
        Me.XrLabel24.StylePriority.UseTextAlignment = False
        Me.XrLabel24.Text = "Due :"
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCoMaker4
        '
        Me.lblCoMaker4.BackColor = System.Drawing.Color.White
        Me.lblCoMaker4.BorderColor = System.Drawing.Color.Black
        Me.lblCoMaker4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCoMaker4.CanGrow = False
        Me.lblCoMaker4.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCoMaker4.ForeColor = System.Drawing.Color.Black
        Me.lblCoMaker4.LocationFloat = New DevExpress.Utils.PointFloat(99.99998!, 95.00017!)
        Me.lblCoMaker4.Name = "lblCoMaker4"
        Me.lblCoMaker4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCoMaker4.SizeF = New System.Drawing.SizeF(200.0!, 19.0!)
        Me.lblCoMaker4.StylePriority.UseBackColor = False
        Me.lblCoMaker4.StylePriority.UseBorderColor = False
        Me.lblCoMaker4.StylePriority.UseBorders = False
        Me.lblCoMaker4.StylePriority.UseFont = False
        Me.lblCoMaker4.StylePriority.UseForeColor = False
        Me.lblCoMaker4.StylePriority.UseTextAlignment = False
        Me.lblCoMaker4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel22
        '
        Me.XrLabel22.BackColor = System.Drawing.Color.White
        Me.XrLabel22.BorderColor = System.Drawing.Color.Black
        Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel22.CanGrow = False
        Me.XrLabel22.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.ForeColor = System.Drawing.Color.Black
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 95.00017!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel22.StylePriority.UseBackColor = False
        Me.XrLabel22.StylePriority.UseBorderColor = False
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseForeColor = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.Text = "Co-Maker IV :"
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCoMaker3
        '
        Me.lblCoMaker3.BackColor = System.Drawing.Color.White
        Me.lblCoMaker3.BorderColor = System.Drawing.Color.Black
        Me.lblCoMaker3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCoMaker3.CanGrow = False
        Me.lblCoMaker3.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCoMaker3.ForeColor = System.Drawing.Color.Black
        Me.lblCoMaker3.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 76.00018!)
        Me.lblCoMaker3.Name = "lblCoMaker3"
        Me.lblCoMaker3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCoMaker3.SizeF = New System.Drawing.SizeF(200.0!, 19.0!)
        Me.lblCoMaker3.StylePriority.UseBackColor = False
        Me.lblCoMaker3.StylePriority.UseBorderColor = False
        Me.lblCoMaker3.StylePriority.UseBorders = False
        Me.lblCoMaker3.StylePriority.UseFont = False
        Me.lblCoMaker3.StylePriority.UseForeColor = False
        Me.lblCoMaker3.StylePriority.UseTextAlignment = False
        Me.lblCoMaker3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel20
        '
        Me.XrLabel20.BackColor = System.Drawing.Color.White
        Me.XrLabel20.BorderColor = System.Drawing.Color.Black
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.CanGrow = False
        Me.XrLabel20.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel20.ForeColor = System.Drawing.Color.Black
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(0.0001907349!, 76.00018!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel20.StylePriority.UseBackColor = False
        Me.XrLabel20.StylePriority.UseBorderColor = False
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.StylePriority.UseForeColor = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.Text = "Co-Maker III :"
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel17
        '
        Me.XrLabel17.BackColor = System.Drawing.Color.White
        Me.XrLabel17.BorderColor = System.Drawing.Color.Black
        Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel17.CanGrow = False
        Me.XrLabel17.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel17.ForeColor = System.Drawing.Color.Black
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(0.0001907349!, 57.00006!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel17.StylePriority.UseBackColor = False
        Me.XrLabel17.StylePriority.UseBorderColor = False
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseForeColor = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = "Co-Maker II :"
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCoMaker2
        '
        Me.lblCoMaker2.BackColor = System.Drawing.Color.White
        Me.lblCoMaker2.BorderColor = System.Drawing.Color.Black
        Me.lblCoMaker2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCoMaker2.CanGrow = False
        Me.lblCoMaker2.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCoMaker2.ForeColor = System.Drawing.Color.Black
        Me.lblCoMaker2.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 57.00006!)
        Me.lblCoMaker2.Name = "lblCoMaker2"
        Me.lblCoMaker2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCoMaker2.SizeF = New System.Drawing.SizeF(200.0!, 19.0!)
        Me.lblCoMaker2.StylePriority.UseBackColor = False
        Me.lblCoMaker2.StylePriority.UseBorderColor = False
        Me.lblCoMaker2.StylePriority.UseBorders = False
        Me.lblCoMaker2.StylePriority.UseFont = False
        Me.lblCoMaker2.StylePriority.UseForeColor = False
        Me.lblCoMaker2.StylePriority.UseTextAlignment = False
        Me.lblCoMaker2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel15
        '
        Me.XrLabel15.BackColor = System.Drawing.Color.White
        Me.XrLabel15.BorderColor = System.Drawing.Color.Black
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.ForeColor = System.Drawing.Color.Black
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 38.00008!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Co-Maker I :"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCoMaker1
        '
        Me.lblCoMaker1.BackColor = System.Drawing.Color.White
        Me.lblCoMaker1.BorderColor = System.Drawing.Color.Black
        Me.lblCoMaker1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCoMaker1.CanGrow = False
        Me.lblCoMaker1.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCoMaker1.ForeColor = System.Drawing.Color.Black
        Me.lblCoMaker1.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 38.00008!)
        Me.lblCoMaker1.Name = "lblCoMaker1"
        Me.lblCoMaker1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCoMaker1.SizeF = New System.Drawing.SizeF(200.0!, 19.0!)
        Me.lblCoMaker1.StylePriority.UseBackColor = False
        Me.lblCoMaker1.StylePriority.UseBorderColor = False
        Me.lblCoMaker1.StylePriority.UseBorders = False
        Me.lblCoMaker1.StylePriority.UseFont = False
        Me.lblCoMaker1.StylePriority.UseForeColor = False
        Me.lblCoMaker1.StylePriority.UseTextAlignment = False
        Me.lblCoMaker1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.White
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.Black
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(0.0001907349!, 18.99999!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Account Number :"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 18.99999!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(200.0!, 19.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_7
        '
        Me.lblCollateral_7.BackColor = System.Drawing.Color.White
        Me.lblCollateral_7.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_7.CanGrow = False
        Me.lblCollateral_7.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_7.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_7.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 114.0003!)
        Me.lblCollateral_7.Name = "lblCollateral_7"
        Me.lblCollateral_7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_7.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_7.StylePriority.UseBackColor = False
        Me.lblCollateral_7.StylePriority.UseBorderColor = False
        Me.lblCollateral_7.StylePriority.UseBorders = False
        Me.lblCollateral_7.StylePriority.UseFont = False
        Me.lblCollateral_7.StylePriority.UseForeColor = False
        Me.lblCollateral_7.StylePriority.UseTextAlignment = False
        Me.lblCollateral_7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_6
        '
        Me.lblCollateral_6.BackColor = System.Drawing.Color.White
        Me.lblCollateral_6.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_6.CanGrow = False
        Me.lblCollateral_6.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_6.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_6.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 95.00021!)
        Me.lblCollateral_6.Name = "lblCollateral_6"
        Me.lblCollateral_6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_6.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_6.StylePriority.UseBackColor = False
        Me.lblCollateral_6.StylePriority.UseBorderColor = False
        Me.lblCollateral_6.StylePriority.UseBorders = False
        Me.lblCollateral_6.StylePriority.UseFont = False
        Me.lblCollateral_6.StylePriority.UseForeColor = False
        Me.lblCollateral_6.StylePriority.UseTextAlignment = False
        Me.lblCollateral_6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_5
        '
        Me.lblCollateral_5.BackColor = System.Drawing.Color.White
        Me.lblCollateral_5.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_5.CanGrow = False
        Me.lblCollateral_5.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_5.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_5.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 76.00015!)
        Me.lblCollateral_5.Name = "lblCollateral_5"
        Me.lblCollateral_5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_5.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_5.StylePriority.UseBackColor = False
        Me.lblCollateral_5.StylePriority.UseBorderColor = False
        Me.lblCollateral_5.StylePriority.UseBorders = False
        Me.lblCollateral_5.StylePriority.UseFont = False
        Me.lblCollateral_5.StylePriority.UseForeColor = False
        Me.lblCollateral_5.StylePriority.UseTextAlignment = False
        Me.lblCollateral_5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_4
        '
        Me.lblCollateral_4.BackColor = System.Drawing.Color.White
        Me.lblCollateral_4.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_4.CanGrow = False
        Me.lblCollateral_4.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_4.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_4.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 57.0001!)
        Me.lblCollateral_4.Name = "lblCollateral_4"
        Me.lblCollateral_4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_4.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_4.StylePriority.UseBackColor = False
        Me.lblCollateral_4.StylePriority.UseBorderColor = False
        Me.lblCollateral_4.StylePriority.UseBorders = False
        Me.lblCollateral_4.StylePriority.UseFont = False
        Me.lblCollateral_4.StylePriority.UseForeColor = False
        Me.lblCollateral_4.StylePriority.UseTextAlignment = False
        Me.lblCollateral_4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_3
        '
        Me.lblCollateral_3.BackColor = System.Drawing.Color.White
        Me.lblCollateral_3.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_3.CanGrow = False
        Me.lblCollateral_3.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_3.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_3.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 38.00004!)
        Me.lblCollateral_3.Name = "lblCollateral_3"
        Me.lblCollateral_3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_3.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_3.StylePriority.UseBackColor = False
        Me.lblCollateral_3.StylePriority.UseBorderColor = False
        Me.lblCollateral_3.StylePriority.UseBorders = False
        Me.lblCollateral_3.StylePriority.UseFont = False
        Me.lblCollateral_3.StylePriority.UseForeColor = False
        Me.lblCollateral_3.StylePriority.UseTextAlignment = False
        Me.lblCollateral_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_2
        '
        Me.lblCollateral_2.BackColor = System.Drawing.Color.White
        Me.lblCollateral_2.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_2.CanGrow = False
        Me.lblCollateral_2.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_2.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_2.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 18.99999!)
        Me.lblCollateral_2.Name = "lblCollateral_2"
        Me.lblCollateral_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_2.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_2.StylePriority.UseBackColor = False
        Me.lblCollateral_2.StylePriority.UseBorderColor = False
        Me.lblCollateral_2.StylePriority.UseBorders = False
        Me.lblCollateral_2.StylePriority.UseFont = False
        Me.lblCollateral_2.StylePriority.UseForeColor = False
        Me.lblCollateral_2.StylePriority.UseTextAlignment = False
        Me.lblCollateral_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral_1
        '
        Me.lblCollateral_1.BackColor = System.Drawing.Color.White
        Me.lblCollateral_1.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_1.CanGrow = False
        Me.lblCollateral_1.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblCollateral_1.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_1.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 0.0!)
        Me.lblCollateral_1.Name = "lblCollateral_1"
        Me.lblCollateral_1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_1.SizeF = New System.Drawing.SizeF(175.0!, 19.00004!)
        Me.lblCollateral_1.StylePriority.UseBackColor = False
        Me.lblCollateral_1.StylePriority.UseBorderColor = False
        Me.lblCollateral_1.StylePriority.UseBorders = False
        Me.lblCollateral_1.StylePriority.UseFont = False
        Me.lblCollateral_1.StylePriority.UseForeColor = False
        Me.lblCollateral_1.StylePriority.UseTextAlignment = False
        Me.lblCollateral_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.White
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.Black
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(525.0!, 0.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Collateral :"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0.0!)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower.SizeF = New System.Drawing.SizeF(200.0!, 19.0!)
        Me.lblBorrower.StylePriority.UseBackColor = False
        Me.lblBorrower.StylePriority.UseBorderColor = False
        Me.lblBorrower.StylePriority.UseBorders = False
        Me.lblBorrower.StylePriority.UseFont = False
        Me.lblBorrower.StylePriority.UseForeColor = False
        Me.lblBorrower.StylePriority.UseTextAlignment = False
        Me.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.White
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.Black
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Borrower :"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.White
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.Black
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 0.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 19.00004!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Document Date :"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDocumentDate
        '
        Me.lblDocumentDate.BackColor = System.Drawing.Color.White
        Me.lblDocumentDate.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentDate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDocumentDate.CanGrow = False
        Me.lblDocumentDate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentDate.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentDate.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.lblDocumentDate.Name = "lblDocumentDate"
        Me.lblDocumentDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDocumentDate.SizeF = New System.Drawing.SizeF(125.0!, 19.00004!)
        Me.lblDocumentDate.StylePriority.UseBackColor = False
        Me.lblDocumentDate.StylePriority.UseBorderColor = False
        Me.lblDocumentDate.StylePriority.UseBorders = False
        Me.lblDocumentDate.StylePriority.UseFont = False
        Me.lblDocumentDate.StylePriority.UseForeColor = False
        Me.lblDocumentDate.StylePriority.UseTextAlignment = False
        Me.lblDocumentDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.White
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.Black
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(300.0002!, 19.00004!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(99.99982!, 19.00004!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Document Number :"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDocumentNumber
        '
        Me.lblDocumentNumber.BackColor = System.Drawing.Color.White
        Me.lblDocumentNumber.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentNumber.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDocumentNumber.CanGrow = False
        Me.lblDocumentNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNumber.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentNumber.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 19.00004!)
        Me.lblDocumentNumber.Name = "lblDocumentNumber"
        Me.lblDocumentNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDocumentNumber.SizeF = New System.Drawing.SizeF(125.0!, 19.0!)
        Me.lblDocumentNumber.StylePriority.UseBackColor = False
        Me.lblDocumentNumber.StylePriority.UseBorderColor = False
        Me.lblDocumentNumber.StylePriority.UseBorders = False
        Me.lblDocumentNumber.StylePriority.UseFont = False
        Me.lblDocumentNumber.StylePriority.UseForeColor = False
        Me.lblDocumentNumber.StylePriority.UseTextAlignment = False
        Me.lblDocumentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.PageFooter.HeightF = 20.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.White
        Me.XrPageInfo1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'rptCreditReferralSlip
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader1, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDocumentDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDocumentNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCoMaker2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCoMaker1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCoMaker4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCoMaker3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDue As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthlyAmortization As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFaceAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateGranted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cbxMonthly As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxBimonthly As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxWeekly As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxDaily As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel38 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_Insurance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInsuranceInCharge As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateInsurance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel43 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel44 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmountPolicy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel47 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel49 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDatePolicy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel45 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInsuranceCompany As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel51 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel52 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmountRenewal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOR_CR As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel55 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel56 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel57 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel58 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel59 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel84 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRemarksScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel80 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel82 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalScoreT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCreditScoreT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel77 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCreditScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel79 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSettleScoreT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel73 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSettleScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel75 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPaymentScoreT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel69 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPaymentScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel71 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblHistoryScoreT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel65 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblHistoryScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel67 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel60 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTimeScore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel62 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTimeScoreT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOutstanding As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel87 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel88 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestDue As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel102 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel104 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNumberPayments As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel95 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel96 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUDI As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel98 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalAmountDue As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel93 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLPC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel91 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDeliquency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel109 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNumberLPC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel111 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTerms As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel101 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel106 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPresentStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLoanType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel112 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel114 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel115 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel116 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel117 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel118 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subRpt_Active As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents XrLabel121 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel120 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel119 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel122 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subRpt_Closed As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents XrLabel123 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel124 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel125 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel126 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel127 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel128 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel129 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel130 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel131 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRemarks As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPreparedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel132 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel133 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel135 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRequestedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel136 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
