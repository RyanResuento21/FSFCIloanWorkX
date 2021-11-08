Public Class RptDeliquencyReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel3, XrLabel1, XrLabel2, XrLabel16, XrLabel4, XrLabel15, XrLabel6, XrLabel7, XrLabel5, XrLabel9, XrLabel10, XrLabel8, XrLabel11, XrLabel12, XrLabel13, XrLabel14})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblBorrowerH, lblBorrower, lblPN, lblDateGranted, lblDateMaturity, lblInterest, lblLoanAmount, lblPrincipalPAR, lblInterestPAR, lblTotaLPAR, lblPrincipalAD, lblInterestAD, lblTotalAD, lblMissedA, lblDaysPastDue, lblLastTransaction, XrLabel29, XrLabel30, XrLabel31, XrLabel32, XrLabel18, lblLoanAmountT, lblPrincipalPART, lblInterestPART, lblTotaLPART, lblPrincipalADT, lblInterestADT, lblTotalADT, XrLabel40, XrLabel41, XrLabel42})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblLoanAmount.BeforePrint, lblPrincipalPAR.BeforePrint, lblInterestPAR.BeforePrint, lblTotaLPAR.BeforePrint, lblPrincipalAD.BeforePrint, lblInterestAD.BeforePrint, lblTotalAD.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class