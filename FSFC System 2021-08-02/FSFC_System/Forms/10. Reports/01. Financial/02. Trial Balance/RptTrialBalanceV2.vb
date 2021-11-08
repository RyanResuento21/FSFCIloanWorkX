Public Class RptTrialBalanceV2

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblYear1, lblYear2, lblYear3, XrLabel10, lblAccountH, lblFinancialH, XrLabel4, XrLabel5, XrLabel1, XrLabel2, XrLabel3, XrLabel11, XrLabel9, XrLabel7, lblTotalH})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblCode, lblAccount, lblFP1, lblActual1, lblVariance1, lblFP2, lblActual2, lblVariance2, lblFP3, lblActual3, lblVariance3, lblFP1T, lblActual1T, lblVariance1, lblFP2T, lblActual2T, lblVariance2T, lblFP3T, lblActual3T, lblVariance3T})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblFP1.BeforePrint, lblActual1.BeforePrint, lblVariance1.BeforePrint, lblFP2.BeforePrint, lblActual2.BeforePrint, lblVariance2.BeforePrint, lblFP3.BeforePrint, lblActual3.BeforePrint, lblVariance3.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class