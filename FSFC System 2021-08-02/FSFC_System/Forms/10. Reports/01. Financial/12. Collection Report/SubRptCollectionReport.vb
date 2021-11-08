Public Class SubRptCollectionReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel32})
        ReportLabelFontSettings({lblDocumentNumber, lblIssuedTo, lblAccountNumber, lblCash, lblCheck, lblAmount, lblCheckNumber, lblCheckDate, lblLoans, lblOthers, lblCashT, lblCheckT, lblAmountT, lblLoansT, lblOthersT})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblCash.BeforePrint, lblCheck.BeforePrint, lblAmount.BeforePrint, lblLoans.BeforePrint, lblOthers.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class