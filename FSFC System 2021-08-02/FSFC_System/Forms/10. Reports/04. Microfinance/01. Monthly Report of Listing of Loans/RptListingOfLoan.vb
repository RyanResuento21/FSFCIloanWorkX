Public Class RptListingOfLoan

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel11, XrLabel6, XrLabel7, XrLabel19, XrLabel8, XrLabel9, XrLabel10})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblBorrowerH, lblBorrower, lblAddress, lblAccountNumber, lblDateGranted, lblDateMaturity, lblTerm, lblPrincipal, lblOutstanding, lblInterest, lblInterestBalance, lblLastPayment, lblBorrowerF, XrLabel12, XrLabel13, XrLabel14, XrLabel15, XrLabel16, lblPrincipalF, lblOutstandingF, lblInterestF, lblInterestBalanceF, XrLabel21})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblPrincipal.BeforePrint, lblOutstanding.BeforePrint, lblInterest.BeforePrint, lblInterestBalance.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class