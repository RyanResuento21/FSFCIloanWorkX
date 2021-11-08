Public Class RptLoansReleases

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel3, XrLabel1, XrLabel2, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblBorrowerH, lblBorrower, lblPN, lblPrincipal, lblTerm, lblInterestRate, lblServiceCharge, lblInsurance, lblDocumentary, lblNotarialFee, lblTotalCharges, lblNetProceeds, lblOtherDeductions, lblNetAmount, XrLabel25, XrLabel24, lblPrincipalT, lblTermT, lblInterestRateT, lblServiceChargeT, lblInsuranceT, lblDocumentaryT, lblNotarialFeeT, lblTotalChargesT, lblNetProceedsT, lblOtherDeductionsT, lblNetAmountT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblPrincipal.BeforePrint, lblServiceCharge.BeforePrint, lblInsurance.BeforePrint, lblDocumentary.BeforePrint, lblNotarialFee.BeforePrint, lblTotalCharges.BeforePrint, lblNetProceeds.BeforePrint, lblOtherDeductions.BeforePrint, lblNetAmount.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class