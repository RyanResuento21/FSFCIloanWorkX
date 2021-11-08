Public Class RptSubScheduleVL

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblNo, lblDate, lblNature, lblAccountName, lblAccountNo, lblPlateNum, lblDescription, lblBookValue, lblImpairment, lblNetBook, lbl1_90Days, lbl90Days_1Year, lbl1Year_3Years, lblOver3Years, lblSelling, lblInspection, lblClassification, lblObservation})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblBookValue.BeforePrint, lblImpairment.BeforePrint, lblNetBook.BeforePrint, lbl1_90Days.BeforePrint, lbl90Days_1Year.BeforePrint, lbl1Year_3Years.BeforePrint, lblOver3Years.BeforePrint, lblSelling.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class