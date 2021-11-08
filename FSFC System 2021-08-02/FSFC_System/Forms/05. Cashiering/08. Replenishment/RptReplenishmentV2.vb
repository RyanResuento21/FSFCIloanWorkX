Public Class RptReplenishmentV2

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblDate_C, lblDocumentNumber_C, lblParticulars_C, lblAmount_C, lblCaption1, lblCaption2, lblCaption3, lblCaption4, lblCaption5, lblCaption6, lblCaption7, lblCaption8, lblCaption9, lblCaption10, lblCaption11, lblCaption12, lblCaption13, lblCaption14, lblCaption15, lblCaption16, lblCaption17, lblCaption18, lblCaption19, lblCaption20, lblCaption21, lblCaption22, lblCaption23, lblCaption24, lblCaption25, lblCaption26, lblCaption27, lblCaption28, lblCaption29, lblCaption30, lblCaption31, lblCaption32, lblCaption33, lblCaption34, lblCaption35, lblCaption36, lblCaption37, lblCaption38, lblCaption39, lblCaption40})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel9, lblDocumentNum, XrLabel2, lblReferenceNum, XrLabel14, lblRemarks, lblDate, lblDocumentNumber, lblParticulars, lblAmount, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10, lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20, lbl21, lbl22, lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30, lbl31, lbl32, lbl33, lbl34, lbl35, lbl36, lbl37, lbl38, lbl39, lbl40, XrLabel35, lblPreparedBy, XrLabel38, XrLabel13, lblCheckedBy, XrLabel11, XrLabel22, lblApprovedBy, XrLabel20})
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
        lbl21.Text = ConvertZeroToDash(lbl21.Text)
        lbl22.Text = ConvertZeroToDash(lbl22.Text)
        lbl23.Text = ConvertZeroToDash(lbl23.Text)
        lbl24.Text = ConvertZeroToDash(lbl24.Text)
        lbl25.Text = ConvertZeroToDash(lbl25.Text)
        lbl26.Text = ConvertZeroToDash(lbl26.Text)
        lbl27.Text = ConvertZeroToDash(lbl27.Text)
        lbl28.Text = ConvertZeroToDash(lbl28.Text)
        lbl29.Text = ConvertZeroToDash(lbl29.Text)
        lbl30.Text = ConvertZeroToDash(lbl30.Text)
        lbl31.Text = ConvertZeroToDash(lbl31.Text)
        lbl32.Text = ConvertZeroToDash(lbl32.Text)
        lbl33.Text = ConvertZeroToDash(lbl33.Text)
        lbl34.Text = ConvertZeroToDash(lbl34.Text)
        lbl35.Text = ConvertZeroToDash(lbl35.Text)
        lbl36.Text = ConvertZeroToDash(lbl36.Text)
        lbl37.Text = ConvertZeroToDash(lbl37.Text)
        lbl38.Text = ConvertZeroToDash(lbl38.Text)
        lbl39.Text = ConvertZeroToDash(lbl39.Text)
        lbl40.Text = ConvertZeroToDash(lbl40.Text)

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
            lbl21.Font = New Font(lbl21.Font.FontFamily, lbl21.Font.Size, FontStyle.Bold)
            lbl22.Font = New Font(lbl22.Font.FontFamily, lbl22.Font.Size, FontStyle.Bold)
            lbl23.Font = New Font(lbl23.Font.FontFamily, lbl23.Font.Size, FontStyle.Bold)
            lbl24.Font = New Font(lbl24.Font.FontFamily, lbl24.Font.Size, FontStyle.Bold)
            lbl25.Font = New Font(lbl25.Font.FontFamily, lbl25.Font.Size, FontStyle.Bold)
            lbl26.Font = New Font(lbl26.Font.FontFamily, lbl26.Font.Size, FontStyle.Bold)
            lbl27.Font = New Font(lbl27.Font.FontFamily, lbl27.Font.Size, FontStyle.Bold)
            lbl28.Font = New Font(lbl28.Font.FontFamily, lbl28.Font.Size, FontStyle.Bold)
            lbl29.Font = New Font(lbl29.Font.FontFamily, lbl29.Font.Size, FontStyle.Bold)
            lbl30.Font = New Font(lbl30.Font.FontFamily, lbl30.Font.Size, FontStyle.Bold)
            lbl31.Font = New Font(lbl31.Font.FontFamily, lbl31.Font.Size, FontStyle.Bold)
            lbl32.Font = New Font(lbl32.Font.FontFamily, lbl32.Font.Size, FontStyle.Bold)
            lbl33.Font = New Font(lbl33.Font.FontFamily, lbl33.Font.Size, FontStyle.Bold)
            lbl34.Font = New Font(lbl34.Font.FontFamily, lbl34.Font.Size, FontStyle.Bold)
            lbl35.Font = New Font(lbl35.Font.FontFamily, lbl35.Font.Size, FontStyle.Bold)
            lbl36.Font = New Font(lbl36.Font.FontFamily, lbl36.Font.Size, FontStyle.Bold)
            lbl37.Font = New Font(lbl37.Font.FontFamily, lbl37.Font.Size, FontStyle.Bold)
            lbl38.Font = New Font(lbl38.Font.FontFamily, lbl38.Font.Size, FontStyle.Bold)
            lbl39.Font = New Font(lbl39.Font.FontFamily, lbl39.Font.Size, FontStyle.Bold)
            lbl40.Font = New Font(lbl40.Font.FontFamily, lbl40.Font.Size, FontStyle.Bold)
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
            lbl21.Font = New Font(lbl21.Font.FontFamily, lbl21.Font.Size, FontStyle.Regular)
            lbl22.Font = New Font(lbl22.Font.FontFamily, lbl22.Font.Size, FontStyle.Regular)
            lbl23.Font = New Font(lbl23.Font.FontFamily, lbl23.Font.Size, FontStyle.Regular)
            lbl24.Font = New Font(lbl24.Font.FontFamily, lbl24.Font.Size, FontStyle.Regular)
            lbl25.Font = New Font(lbl25.Font.FontFamily, lbl25.Font.Size, FontStyle.Regular)
            lbl26.Font = New Font(lbl26.Font.FontFamily, lbl26.Font.Size, FontStyle.Regular)
            lbl27.Font = New Font(lbl27.Font.FontFamily, lbl27.Font.Size, FontStyle.Regular)
            lbl28.Font = New Font(lbl28.Font.FontFamily, lbl28.Font.Size, FontStyle.Regular)
            lbl29.Font = New Font(lbl29.Font.FontFamily, lbl29.Font.Size, FontStyle.Regular)
            lbl30.Font = New Font(lbl30.Font.FontFamily, lbl30.Font.Size, FontStyle.Regular)
            lbl31.Font = New Font(lbl31.Font.FontFamily, lbl31.Font.Size, FontStyle.Regular)
            lbl32.Font = New Font(lbl32.Font.FontFamily, lbl32.Font.Size, FontStyle.Regular)
            lbl33.Font = New Font(lbl33.Font.FontFamily, lbl33.Font.Size, FontStyle.Regular)
            lbl34.Font = New Font(lbl34.Font.FontFamily, lbl34.Font.Size, FontStyle.Regular)
            lbl35.Font = New Font(lbl35.Font.FontFamily, lbl35.Font.Size, FontStyle.Regular)
            lbl36.Font = New Font(lbl36.Font.FontFamily, lbl36.Font.Size, FontStyle.Regular)
            lbl37.Font = New Font(lbl37.Font.FontFamily, lbl37.Font.Size, FontStyle.Regular)
            lbl38.Font = New Font(lbl38.Font.FontFamily, lbl38.Font.Size, FontStyle.Regular)
            lbl39.Font = New Font(lbl39.Font.FontFamily, lbl39.Font.Size, FontStyle.Regular)
            lbl40.Font = New Font(lbl40.Font.FontFamily, lbl40.Font.Size, FontStyle.Regular)
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

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lbl1.BeforePrint, lbl2.BeforePrint, lbl3.BeforePrint, lbl4.BeforePrint, lbl5.BeforePrint, lbl6.BeforePrint, lbl7.BeforePrint, lbl8.BeforePrint, lbl9.BeforePrint, lbl10.BeforePrint, lbl11.BeforePrint, lbl12.BeforePrint, lbl13.BeforePrint, lbl14.BeforePrint, lbl15.BeforePrint, lbl16.BeforePrint, lbl17.BeforePrint, lbl18.BeforePrint, lbl19.BeforePrint, lbl20.BeforePrint, lbl21.BeforePrint, lbl22.BeforePrint, lbl23.BeforePrint, lbl24.BeforePrint, lbl25.BeforePrint, lbl26.BeforePrint, lbl27.BeforePrint, lbl28.BeforePrint, lbl29.BeforePrint, lbl30.BeforePrint, lbl31.BeforePrint, lbl32.BeforePrint, lbl33.BeforePrint, lbl34.BeforePrint, lbl35.BeforePrint, lbl36.BeforePrint, lbl37.BeforePrint, lbl38.BeforePrint, lbl39.BeforePrint, lbl40.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        LabelX.Text = ConvertZeroToDash(LabelX.Text)
        If lblDocumentNumber.Text = "T O T A L" Then
            LabelX.Font = New Font(LabelX.Font.FontFamily, LabelX.Font.Size, FontStyle.Bold)
        Else
            LabelX.Font = New Font(LabelX.Font.FontFamily, LabelX.Font.Size, FontStyle.Regular)
        End If
    End Sub
End Class