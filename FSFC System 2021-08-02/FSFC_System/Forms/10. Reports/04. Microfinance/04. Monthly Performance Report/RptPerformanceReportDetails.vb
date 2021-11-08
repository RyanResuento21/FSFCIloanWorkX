Public Class RptPerformanceReportDetails

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel4, XrLabel5, XrLabel1, XrLabel2, XrLabel3, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel12, XrLabel13, XrLabel14})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblBorrower, lblPNNumber, lblTerms, lblInterestRate, lblProduct, lblReleases, lblOutstanding, lblPastDue, lblPrincipal, lblInterest, lblPenalties, XrLabel11, XrLabel10, XrLabel15, XrLabel16, XrLabel17, lblReleasesT, lblOutstandingT, lblPastDueT, lblPrincipalT, lblInterestT, lblPenaltiesT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblReleases.BeforePrint, lblOutstanding.BeforePrint, lblPastDue.BeforePrint, lblPrincipal.BeforePrint, lblInterest.BeforePrint, lblPenalties.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class