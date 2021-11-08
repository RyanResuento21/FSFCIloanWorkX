Public Class Rpt5BookingsDetailed

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel3, XrLabel4, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel15, XrLabel16, XrLabel17, XrLabel18, XrLabel19, XrLabel20, XrLabel21, XrLabel22, XrLabel23, XrLabel24, XrLabel25, XrLabel26, XrLabel27, XrLabel29, XrLabel30, XrLabel31, XrLabel32, XrLabel33, XrLabel34, XrLabel35, XrLabel36, XrLabel37, XrLabel38, XrLabel39})
        ReportLabelFontSettings({XrLabel5, lblNo, lblDate, lblWeek, lblClient, lblAccountNo, lblPrincipal, lblUDI, lblRPPD, lblFA, lblRate, lblTerms, lblMonthlyAmort, lblRebate, lblProcessingFee, lblServiceCharge, lblInsurance, lblMiscellaneous, lblOtherFees, lblAdvanceAmortization, lblInterest, lblDeductBalance, lblNetProceeds, lblCheckNo, lblCollateral, lblProductCode, lblTypeOfLoan, lblRemarks, lblCI, lblInsuranceProvider, lblInsuranceRate, lblPremium, lblWithholdingTax, lblInsuranceCommission, lblReasonDiff, lblBusinessCenter, lblSourceIncome, XrLabel40, XrLabel41, XrLabel42, XrLabel43, XrLabel44, XrLabel45, lblPrincipalT, lblUDIT, lblRPPDT, lblFAT, XrLabel50, lblTermsT, lblMonthlyAmortT, lblRebateT, lblProcessingFeeT, lblServiceChargeT, lblInsuranceT, lblMiscellaneousT, lblOtherFeesT, lblAdvanceAmortizationT, lblInterestT, lblDeductBalanceT, lblNetProceedsT, XrLabel63, XrLabel64, XrLabel65, XrLabel66, XrLabel67, XrLabel68, XrLabel69, XrLabel70, lblPremiumT, lblWithholdingTaxT, lblInsuranceCommissionT, XrLabel74, XrLabel75, XrLabel76})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblPrincipal.BeforePrint, lblUDI.BeforePrint, lblRPPD.BeforePrint, lblFA.BeforePrint, lblMonthlyAmort.BeforePrint, lblRebate.BeforePrint, lblProcessingFee.BeforePrint, lblServiceCharge.BeforePrint, lblInsurance.BeforePrint, lblMiscellaneous.BeforePrint, lblOtherFees.BeforePrint, lblAdvanceAmortization.BeforePrint, lblInterest.BeforePrint, lblDeductBalance.BeforePrint, lblNetProceeds.BeforePrint, lblInsuranceRate.BeforePrint, lblPremium.BeforePrint, lblWithholdingTax.BeforePrint, lblInsuranceCommission.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class