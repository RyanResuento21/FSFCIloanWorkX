Public Class RptSubScheduleRE

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblNo, lblDate, lblNature, lblAccountName, lblAccountNo, lblTCT, lblLocation, lblArea, lblBookValue, lbl1Year, lblOver1Year, lblSelling, lblRedemption, lblInspection, lblClassification, lblRemarks})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblBookValue.BeforePrint, lbl1Year.BeforePrint, lblOver1Year.BeforePrint, lblSelling.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class