Public Class RptBalanceSheet

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, lblFinancialH2, XrLabel8, lblFinancialH, XrLabel4, XrLabel5, XrLabel6})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblAccount, lblFinancial, lblActual_1, lblActual_2, lblDifference})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblFinancial.BeforePrint, lblActual_1.BeforePrint, lblActual_2.BeforePrint, lblDifference.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            If .Text = "" Or lblAccount.Text.Contains("TOTAL") Or lblAccount.Text.Contains("Total") Or lblAccount.Text.Contains("NET INCOME BEFORE TAX") Or lblAccount.Text.Contains("Less: Income Tax Expense") Or lblAccount.Text.Contains("NET INCOME FOR THE PERIOD") Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            End If
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub

    Private Sub LblAccount_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAccount.BeforePrint
        With lblAccount
            If lblFinancial.Text = "" Or .Text.Contains("TOTAL") Or .Text.Contains("Total") Or .Text.Contains("NET INCOME BEFORE TAX") Or .Text.Contains("Less: Income Tax Expense") Or .Text.Contains("NET INCOME FOR THE PERIOD") Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            End If
        End With
    End Sub
End Class