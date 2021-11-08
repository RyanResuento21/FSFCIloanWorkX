Public Class SubRptReturned

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblORDate, lblDocumentNo, lblJVDate, lblBorrower, lblAmount, lblJVNumber})
    End Sub

    Private Sub LblAmount_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount.BeforePrint
        With lblAmount
            If IsNumeric(.Text) Then
                .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
            End If
        End With
    End Sub
End Class