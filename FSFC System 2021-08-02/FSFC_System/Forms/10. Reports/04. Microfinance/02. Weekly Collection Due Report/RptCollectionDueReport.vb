Public Class RptCollectionDueReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel3, XrLabel4, XrLabel5, XrLabel15, XrLabel6, XrLabel7, XrLabel19, XrLabel8, XrLabel9, XrLabel20, XrLabel1, XrLabel2, XrLabel21, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblBorrowerH, lblBorrower, lblDateGranted, lblDateMaturity, lblTermInterest, lblPrincipal, lblOutstanding, lblInterest, lblInterestBalance, lblPrincipalDue, lblPrincipalPaid, lblInterestDue, lblInterestPaid, lblBlank, lblTotalPaid, lblClientsSignature, lblBorrowerF, XrLabel16, XrLabel17, XrLabel18, lblPrincipalF, lblOutstandingF, lblInterestF, lblInterestBalanceF, lblInterestBalanceF, lblInterestBalanceF, lblInterestDueF, lblInterestPaidF, lblBlankF, lblTotalPaidF, lblClientsSignatureF})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblPrincipal.BeforePrint, lblOutstanding.BeforePrint, lblInterest.BeforePrint, lblInterestBalance.BeforePrint, lblPrincipalDue.BeforePrint, lblPrincipalPaid.BeforePrint, lblInterestDue.BeforePrint, lblInterestPaid.BeforePrint, lblTotalPaid.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class