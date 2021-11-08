Public Class RptTrialBalanceWithoutFP

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel10, lblAccountH, lblCaption1, lblCaption2, lblCaption3, lblTotalH})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblCode, lblAccount, lblActual1, lblActual2, lblActual3, lblActual1T, lblActual2T, lblActual3T})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblActual1.BeforePrint, lblActual2.BeforePrint, lblActual3.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class