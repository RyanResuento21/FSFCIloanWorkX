Public Class RptScheduleRE

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel17, XrLabel7, XrLabel18, XrLabel15, XrLabel20, XrLabel16})
        ReportLabelFontSettings({lblBank, lblNo, lblBookValue, lbl1Year, lblOver1Year, lblSelling, lblObservation, XrLabel2, XrLabel19, lblBookValue_2, lbl1Year_2, lblOver1Year_2, lblSelling_2, XrLabel21, XrLabel22, XrLabel26, lblBookValue_3, lbl1Year_3, lblOver1Year_3, lblSelling_3, XrLabel24, XrLabel29, XrLabel30, XrLabel32, XrLabel35, lblBookValue_4, lbl1Year_4, lblOver1Year_4, lblSelling_4, XrLabel36, XrLabel39, XrLabel43, lblBookValue_5, lbl1Year_5, lblOver1Year_5, lblSelling_5, XrLabel41, XrLabel46, XrLabel52, lblBookValue_6, lbl1Year_6, lblOver1Year_6, lblSelling_6, XrLabel48, XrLabel56, lblBookValue_7, lbl1Year_7, lblOver1Year_7, lblSelling_7, XrLabel53})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblBookValue.BeforePrint, lbl1Year.BeforePrint, lblOver1Year.BeforePrint, lblSelling.BeforePrint, lblBookValue_2.BeforePrint, lbl1Year_2.BeforePrint, lblOver1Year_2.BeforePrint, lblSelling_2.BeforePrint, lblBookValue_3.BeforePrint, lbl1Year_3.BeforePrint, lblOver1Year_3.BeforePrint, lblSelling_3.BeforePrint, lblBookValue_4.BeforePrint, lbl1Year_4.BeforePrint, lblOver1Year_4.BeforePrint, lblSelling_4.BeforePrint, lblBookValue_5.BeforePrint, lbl1Year_5.BeforePrint, lblOver1Year_5.BeforePrint, lblSelling_5.BeforePrint, lblBookValue_6.BeforePrint, lbl1Year_6.BeforePrint, lblOver1Year_6.BeforePrint, lblSelling_6.BeforePrint, lblBookValue_7.BeforePrint, lbl1Year_7.BeforePrint, lblOver1Year_7.BeforePrint, lblSelling_7.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class