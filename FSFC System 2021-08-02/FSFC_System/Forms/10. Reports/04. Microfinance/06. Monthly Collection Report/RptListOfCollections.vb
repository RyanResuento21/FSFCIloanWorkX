Public Class RptListOfCollections

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel7, XrLabel6, XrLabel3, XrLabel1, XrLabel2, XrLabel4, XrLabel5})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblBorrowerH, lblBorrower, lblPostingDate, lblORNumber, lblPrincipal, lblInterest, lblPenalty, lblInterestAfterMaturity, lblTotalCollection, XrLabel9, XrLabel8, XrLabel10, lblPrincipalT, lblInterestT, lblPenaltyT, lblInterestAfterMaturityT, lblTotalCollectionT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblPrincipal.BeforePrint, lblInterest.BeforePrint, lblPenalty.BeforePrint, lblInterestAfterMaturity.BeforePrint, lblTotalCollection.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class