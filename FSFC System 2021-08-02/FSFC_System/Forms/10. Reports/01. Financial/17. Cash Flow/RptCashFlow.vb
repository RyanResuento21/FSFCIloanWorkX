Public Class RptCashFlow

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1})
        ReportLabelFontSettings({lblBranch, lblTitle, lblAsOf, lblAccount, lblAmount})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LblAccount_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAccount.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            If .Text.Contains("Cash flow from") Or .Text.Contains("Operating Income (Loss)") Or .Text.Contains("Net cash provided") Or .Text.Contains("Net cash used") Or .Text.Contains("INCREASE (DECREASE) OF CASH") Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            End If
            If .Text.Contains("Bad Debt") Then
                .BackColor = Color.Yellow
            Else
                .BackColor = Color.White
            End If
        End With
    End Sub

    Private Sub LblAmount_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount.BeforePrint
        With lblAmount
            If lblAccount.Text.Contains("Cash flow from") Or lblAccount.Text.Contains("Operating Income (Loss)") Or lblAccount.Text.Contains("Net cash provided") Or lblAccount.Text.Contains("Net cash used") Or lblAccount.Text.Contains("INCREASE (DECREASE) OF CASH") Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            End If
            If IsNumeric(.Text) Then
                .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
            End If
        End With
    End Sub
End Class