Public Class RptTrialBalance

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblFinancialH2, XrLabel8, XrLabel10, lblAccountH, lblFinancialH, XrLabel4, XrLabel5, XrLabel6, XrLabel1, lblTotalH})
        ReportLabelFontSettings({lblCode, lblAccount, lblFinancial, lblActual_1, lblActual_2, lblActual_3, lblDifference, lblFinancialT, lblActual_1T, lblActual_2T, lblActual_3T, lblDifference_T, lblTitle, lblAsOf})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblFinancial.BeforePrint, lblActual_1.BeforePrint, lblActual_2.BeforePrint, lblActual_3.BeforePrint, lblDifference.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class