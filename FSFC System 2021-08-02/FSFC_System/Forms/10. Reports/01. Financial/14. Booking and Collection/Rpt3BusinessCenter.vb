Public Class Rpt3BusinessCenter

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel2, XrLabel3, lbl1H, lbl2H, lbl3H, lbl4H, lbl5H, lbl6H, lbl7H, lbl8H, lbl9H, lbl10H, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel11, XrLabel10, XrLabel9, XrLabel4, XrLabel12, XrLabel13})
        ReportLabelFontSettings({lblTitle, lblProduct, lblProductCode, lblTotal, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblTotal.BeforePrint, lbl1.BeforePrint, lbl2.BeforePrint, lbl3.BeforePrint, lbl4.BeforePrint, lbl5.BeforePrint, lbl6.BeforePrint, lbl7.BeforePrint, lbl8.BeforePrint, lbl9.BeforePrint, lbl10.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            If lblProduct.Text = "GRAND TOTAL" Or lblProduct.Tag = -1 Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            End If
            If lblProduct.Tag = -1 Then
                .BackColor = Color.FromArgb(255, 192, 192)
            Else
                .BackColor = Color.White
            End If
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub

    Private Sub LblProduct_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblProduct.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            If lblProduct.Text = "GRAND TOTAL" Or lblProduct.Tag = -1 Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            End If
            If lblProduct.Tag = -1 Then
                .BackColor = Color.FromArgb(255, 192, 192)
            Else
                .BackColor = Color.White
            End If
        End With
    End Sub

    Private Sub LblProductCode_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblProductCode.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            If lblProduct.Tag = -1 Then
                .BackColor = Color.FromArgb(255, 192, 192)
            Else
                .BackColor = Color.White
            End If
        End With
    End Sub
End Class