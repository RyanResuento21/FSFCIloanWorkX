Public Class RptScheduleVL

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel3, XrLabel4, XrLabel6, XrLabel17, XrLabel5, XrLabel18, XrLabel20, XrLabel22, XrLabel7, XrLabel15, XrLabel23, XrLabel16})
        ReportLabelFontSettings({XrLabel1, lblAsOf, lblBank, lblNo, XrLabel2, XrLabel19, XrLabel24, XrLabel25, lblBookValue, lblImpairment, lblNetBook, lbl1_90Days, lbl90Days_1Year, lbl1Year_3Years, lblOver3Years, lblSellingPrice, lblObservation, lblBookValue_2, lblImpairment_2, lblNetBook_2, lbl1_90Days_2, lbl90Days_1Year_2, lbl1Year_3Years_2, lblOver3Years_2, lblSellingPrice_2, lblBookValue_3, lblImpairment_3, lblNetBook_3, lbl1_90Days_3, lbl90Days_1Year_3, lbl1Year_3Years_3, lblOver3Years_3, lblSellingPrice_3, XrLabel21, XrLabel28})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblBookValue.BeforePrint, lblImpairment.BeforePrint, lblNetBook.BeforePrint, lbl1_90Days.BeforePrint, lbl90Days_1Year.BeforePrint, lbl1Year_3Years.BeforePrint, lblOver3Years.BeforePrint, lblSellingPrice.BeforePrint, lblBookValue_2.BeforePrint, lblImpairment_2.BeforePrint, lblNetBook_2.BeforePrint, lbl1_90Days_2.BeforePrint, lbl90Days_1Year_2.BeforePrint, lbl1Year_3Years_2.BeforePrint, lblOver3Years_2.BeforePrint, lblSellingPrice_2.BeforePrint, lblBookValue_3.BeforePrint, lblImpairment_3.BeforePrint, lblNetBook_3.BeforePrint, lbl1_90Days_3.BeforePrint, lbl90Days_1Year_3.BeforePrint, lbl1Year_3Years_3.BeforePrint, lblOver3Years_3.BeforePrint, lblSellingPrice_3.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class