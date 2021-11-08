Public Class RptPerformanceReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel3, XrLabel2, XrLabel4, XrLabel5, XrLabel1, XrLabel6, XrLabel7, XrLabel9, XrLabel8, XrLabel11, XrLabel10, XrLabel12, XrLabel13, XrLabel14})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblAccountOfficer, XrLabel15, lblOutstanding_1, lblClients_1, lblAmount_2, lblRatio_2, lblClient_2, lblAmount_3, lblReleases_3, lblPrincipal_4, lblInterest_4, lblPenalties_4, lblOutstanding_1T, lblClients_1T, lblAmount_2T, lblRatio_2T, lblClient_2T, lblAmount_3T, lblReleases_3T, lblPrincipal_4T, lblInterest_4T, lblPenalties_4T})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblOutstanding_1.BeforePrint, lblAmount_2.BeforePrint, lblAmount_3.BeforePrint, lblPrincipal_4.BeforePrint, lblInterest_4.BeforePrint, lblPenalties_4.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class