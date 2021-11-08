Public Class RptCreditReferralSlip

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel35, XrLabel56, XrLabel57, XrLabel58, XrLabel59, XrLabel80, XrLabel112, XrLabel114, XrLabel115, XrLabel116, XrLabel117, XrLabel119, XrLabel120, XrLabel121, XrLabel118, XrLabel122, XrLabel127, XrLabel126, XrLabel125, XrLabel124, XrLabel128, XrLabel129, XrLabel130, XrLabel123, XrLabel131})
        ReportLabelFontSettings({lblTitle, XrLabel2, lblBorrower, XrLabel3, lblDocumentDate, XrLabel13, lblAccountNumber, XrLabel5, lblDocumentNumber, XrLabel15, lblCoMaker1, XrLabel24, lblDue, XrLabel17, lblCoMaker2, XrLabel25, lblDateGranted, XrLabel20, lblCoMaker3, XrLabel27, lblPrincipal, XrLabel22, lblCoMaker4, XrLabel29, lblFaceAmount, XrLabel31, lblMonthlyAmortization, XrLabel6, lblCollateral_1, lblCollateral_2, lblCollateral_3, lblCollateral_4, lblCollateral_5, lblCollateral_6, lblCollateral_7, XrLabel33, txtAsOf, XrLabel87, lblOutstanding, XrLabel88, lblInterestDue, XrLabel91, lblLPC, XrLabel93, lblBalance, XrLabel95, lblRPPD, XrLabel96, lblUDI, XrLabel98, lblTotalAmountDue, XrLabel36, XrLabel37, XrLabel38, lblAmount_Insurance, lblInsuranceInCharge, XrLabel42, lblDateInsurance, XrLabel43, XrLabel44, XrLabel45, XrLabel47, lblAmountPolicy, XrLabel52, lblAmountRenewal, XrLabel49, lblDatePolicy, XrLabel51, lblInsuranceCompany, XrLabel55, lblOR_CR, XrLabel102, lblPrincipalBalance, XrLabel104, lblNumberPayments, XrLabel101, lblTerms, XrLabel111, lblNumberLPC, XrLabel109, lblDeliquency, XrLabel106, lblPresentStatus, lblLoanType, XrLabel60, XrLabel67, XrLabel71, XrLabel75, XrLabel79, XrLabel84, lblTimeScore, XrLabel62, lblTimeScoreT, lblHistoryScore, XrLabel65, lblHistoryScoreT, lblPaymentScore, XrLabel69, lblPaymentScoreT, lblSettleScore, XrLabel73, lblSettleScoreT, lblCreditScore, XrLabel77, lblCreditScoreT, lblTotalScore, XrLabel82, lblTotalScoreT, lblRemarksScore, lblRemarks, XrLabel133, XrLabel136, lblPreparedBy, lblRequestedBy, XrLabel132, XrLabel135})
        ReportPageInfoFontSettings({XrPageInfo2, XrPageInfo1})
        ReportCheckBoxFontSettings({cbxDaily, cbxWeekly, cbxBimonthly, cbxMonthly})
    End Sub
End Class