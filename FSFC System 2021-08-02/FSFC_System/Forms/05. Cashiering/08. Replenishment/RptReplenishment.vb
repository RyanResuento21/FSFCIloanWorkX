Public Class RptReplenishment

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblDate_C, lblDocumentNumber_C, lblParticulars_C, lblAmount_C, lblCaption1, lblCaption2, lblCaption3, lblCaption4, lblCaption5, lblCaption6, lblCaption7, lblCaption8, lblCaption9, lblCaption10, lblCaption11, lblCaption12, lblCaption13, lblCaption14, lblCaption15, lblCaption16, lblCaption17, lblCaption18, lblCaption19, lblCaption20})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel9, lblDocumentNum, XrLabel2, lblReferenceNum, XrLabel14, lblRemarks, lblDate, lblDocumentNumber, lblParticulars, lblAmount, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10, lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20, XrLabel35, lblPreparedBy, XrLabel38, XrLabel13, lblCheckedBy, XrLabel11, XrLabel22, lblApprovedBy, XrLabel20, XrLabel7, lblTotalExpense, XrLabel10, lblRemainingCash, XrLabel5, lblUnliquidated, XrLabel8, lblTotal})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        lblAmount.Text = If(lblAmount.Text = "", "", FormatNumber(CDbl(lblAmount.Text), 2))
        lbl1.Text = ConvertZeroToDash(lbl1.Text)
        lbl2.Text = ConvertZeroToDash(lbl2.Text)
        lbl3.Text = ConvertZeroToDash(lbl3.Text)
        lbl4.Text = ConvertZeroToDash(lbl4.Text)
        lbl5.Text = ConvertZeroToDash(lbl5.Text)
        lbl6.Text = ConvertZeroToDash(lbl6.Text)
        lbl7.Text = ConvertZeroToDash(lbl7.Text)
        lbl8.Text = ConvertZeroToDash(lbl8.Text)
        lbl9.Text = ConvertZeroToDash(lbl9.Text)
        lbl10.Text = ConvertZeroToDash(lbl10.Text)
        lbl11.Text = ConvertZeroToDash(lbl11.Text)
        lbl12.Text = ConvertZeroToDash(lbl12.Text)
        lbl13.Text = ConvertZeroToDash(lbl13.Text)
        lbl14.Text = ConvertZeroToDash(lbl14.Text)
        lbl15.Text = ConvertZeroToDash(lbl15.Text)
        lbl16.Text = ConvertZeroToDash(lbl16.Text)
        lbl17.Text = ConvertZeroToDash(lbl17.Text)
        lbl18.Text = ConvertZeroToDash(lbl18.Text)
        lbl19.Text = ConvertZeroToDash(lbl19.Text)
        lbl20.Text = ConvertZeroToDash(lbl20.Text)

        If lblDocumentNumber.Text = "T O T A L" Then
            lblDocumentNumber.Font = New Font(lblDocumentNumber.Font.FontFamily, lblDocumentNumber.Font.Size, FontStyle.Bold)
            lblAmount.Font = New Font(lblAmount.Font.FontFamily, lblAmount.Font.Size, FontStyle.Bold)
            lbl1.Font = New Font(lbl1.Font.FontFamily, lbl1.Font.Size, FontStyle.Bold)
            lbl2.Font = New Font(lbl2.Font.FontFamily, lbl2.Font.Size, FontStyle.Bold)
            lbl3.Font = New Font(lbl3.Font.FontFamily, lbl3.Font.Size, FontStyle.Bold)
            lbl4.Font = New Font(lbl4.Font.FontFamily, lbl4.Font.Size, FontStyle.Bold)
            lbl5.Font = New Font(lbl5.Font.FontFamily, lbl5.Font.Size, FontStyle.Bold)
            lbl6.Font = New Font(lbl6.Font.FontFamily, lbl6.Font.Size, FontStyle.Bold)
            lbl7.Font = New Font(lbl7.Font.FontFamily, lbl7.Font.Size, FontStyle.Bold)
            lbl8.Font = New Font(lbl8.Font.FontFamily, lbl8.Font.Size, FontStyle.Bold)
            lbl9.Font = New Font(lbl9.Font.FontFamily, lbl9.Font.Size, FontStyle.Bold)
            lbl10.Font = New Font(lbl10.Font.FontFamily, lbl10.Font.Size, FontStyle.Bold)
            lbl11.Font = New Font(lbl11.Font.FontFamily, lbl11.Font.Size, FontStyle.Bold)
            lbl12.Font = New Font(lbl12.Font.FontFamily, lbl12.Font.Size, FontStyle.Bold)
            lbl13.Font = New Font(lbl13.Font.FontFamily, lbl13.Font.Size, FontStyle.Bold)
            lbl14.Font = New Font(lbl14.Font.FontFamily, lbl14.Font.Size, FontStyle.Bold)
            lbl15.Font = New Font(lbl15.Font.FontFamily, lbl15.Font.Size, FontStyle.Bold)
            lbl16.Font = New Font(lbl16.Font.FontFamily, lbl16.Font.Size, FontStyle.Bold)
            lbl17.Font = New Font(lbl17.Font.FontFamily, lbl17.Font.Size, FontStyle.Bold)
            lbl18.Font = New Font(lbl18.Font.FontFamily, lbl18.Font.Size, FontStyle.Bold)
            lbl19.Font = New Font(lbl19.Font.FontFamily, lbl19.Font.Size, FontStyle.Bold)
            lbl20.Font = New Font(lbl20.Font.FontFamily, lbl20.Font.Size, FontStyle.Bold)
        Else
            lblParticulars.Font = New Font(lblParticulars.Font.FontFamily, lblParticulars.Font.Size, FontStyle.Regular)
            lblAmount.Font = New Font(lblAmount.Font.FontFamily, lblAmount.Font.Size, FontStyle.Regular)
            lbl1.Font = New Font(lbl1.Font.FontFamily, lbl1.Font.Size, FontStyle.Regular)
            lbl2.Font = New Font(lbl2.Font.FontFamily, lbl2.Font.Size, FontStyle.Regular)
            lbl3.Font = New Font(lbl3.Font.FontFamily, lbl3.Font.Size, FontStyle.Regular)
            lbl4.Font = New Font(lbl4.Font.FontFamily, lbl4.Font.Size, FontStyle.Regular)
            lbl5.Font = New Font(lbl5.Font.FontFamily, lbl5.Font.Size, FontStyle.Regular)
            lbl6.Font = New Font(lbl6.Font.FontFamily, lbl6.Font.Size, FontStyle.Regular)
            lbl7.Font = New Font(lbl7.Font.FontFamily, lbl7.Font.Size, FontStyle.Regular)
            lbl8.Font = New Font(lbl8.Font.FontFamily, lbl8.Font.Size, FontStyle.Regular)
            lbl9.Font = New Font(lbl9.Font.FontFamily, lbl9.Font.Size, FontStyle.Regular)
            lbl10.Font = New Font(lbl10.Font.FontFamily, lbl10.Font.Size, FontStyle.Regular)
            lbl11.Font = New Font(lbl11.Font.FontFamily, lbl11.Font.Size, FontStyle.Regular)
            lbl12.Font = New Font(lbl12.Font.FontFamily, lbl12.Font.Size, FontStyle.Regular)
            lbl13.Font = New Font(lbl13.Font.FontFamily, lbl13.Font.Size, FontStyle.Regular)
            lbl14.Font = New Font(lbl14.Font.FontFamily, lbl14.Font.Size, FontStyle.Regular)
            lbl15.Font = New Font(lbl15.Font.FontFamily, lbl15.Font.Size, FontStyle.Regular)
            lbl16.Font = New Font(lbl16.Font.FontFamily, lbl16.Font.Size, FontStyle.Regular)
            lbl17.Font = New Font(lbl17.Font.FontFamily, lbl17.Font.Size, FontStyle.Regular)
            lbl18.Font = New Font(lbl18.Font.FontFamily, lbl18.Font.Size, FontStyle.Regular)
            lbl19.Font = New Font(lbl19.Font.FontFamily, lbl19.Font.Size, FontStyle.Regular)
            lbl20.Font = New Font(lbl20.Font.FontFamily, lbl20.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Private Sub LblDocumentNumber_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblDocumentNumber.BeforePrint
        If lblDocumentNumber.Text = "T O T A L" Then
            lblDocumentNumber.Font = New Font(lblDocumentNumber.Font.FontFamily, lblDocumentNumber.Font.Size, FontStyle.Bold)
        Else
            lblDocumentNumber.Font = New Font(lblDocumentNumber.Font.FontFamily, lblDocumentNumber.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Private Sub LblAmount_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount.BeforePrint
        lblAmount.Text = ConvertZeroToDash(lblAmount.Text)
        If lblDocumentNumber.Text = "T O T A L" Then
            lblAmount.Font = New Font(lblAmount.Font.FontFamily, lblAmount.Font.Size, FontStyle.Bold)
        Else
            lblAmount.Font = New Font(lblAmount.Font.FontFamily, lblAmount.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lbl1.BeforePrint, lbl2.BeforePrint, lbl3.BeforePrint, lbl4.BeforePrint, lbl5.BeforePrint, lbl6.BeforePrint, lbl7.BeforePrint, lbl8.BeforePrint, lbl9.BeforePrint, lbl10.BeforePrint, lbl11.BeforePrint, lbl12.BeforePrint, lbl13.BeforePrint, lbl14.BeforePrint, lbl15.BeforePrint, lbl16.BeforePrint, lbl17.BeforePrint, lbl18.BeforePrint, lbl19.BeforePrint, lbl20.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        LabelX.Text = ConvertZeroToDash(LabelX.Text)
        If lblDocumentNumber.Text = "T O T A L" Then
            LabelX.Font = New Font(LabelX.Font.FontFamily, LabelX.Font.Size, FontStyle.Bold)
        Else
            LabelX.Font = New Font(LabelX.Font.FontFamily, LabelX.Font.Size, FontStyle.Regular)
        End If
    End Sub
End Class