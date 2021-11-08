Public Class RptLiquidation

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblCaption_Particular, lblCaption1, lblCaption2, lblCaption3, lblCaption4, lblCaption5, lblCaption6, lblCaption7, lblCaption8, lblCaption9, lblCaption10, lblCaptionT})
        ReportLabelFontSettings({lblTitle, XrLabel4, lblPayee, XrLabel1, lblPurpose, XrLabel3, lblDate, XrLabel5, lblAccountNumber, lblParticulars, lblAmount1, lblAmount2, lblAmount3, lblAmount4, lblAmount5, lblAmount6, lblAmount7, lblAmount8, lblAmount9, lblAmount10, lblAmountT, XrLabel35, lblPreparedBy, XrLabel38, XrLabel13, lblCheckedBy, XrLabel11, XrLabel22, lblApprovedBy, XrLabel20, XrLabel7, lblTotalExpense, XrLabel10, lblAmountReceived, XrLabel14, lblCheckNumber, XrLabel17, lblCVNumber, XrLabel18, lblAmountDue})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount1.BeforePrint, lblAmount2.BeforePrint, lblAmount3.BeforePrint, lblAmount4.BeforePrint, lblAmount5.BeforePrint, lblAmount6.BeforePrint, lblAmount7.BeforePrint, lblAmount8.BeforePrint, lblAmount9.BeforePrint, lblAmount10.BeforePrint, lblAmountT.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class