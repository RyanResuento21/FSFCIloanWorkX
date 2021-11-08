Public Class Rpt2ClientType

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel2, XrLabel3, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel4})
        ReportLabelFontSettings({lblProduct, lblProductCode, lblNew, lblRepeat, lblTotal, lblNewP, lblRepeatP, lblTotalP})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblNew.BeforePrint, lblRepeat.BeforePrint, lblTotal.BeforePrint
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

    Private Sub LblProduct_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblProduct.BeforePrint, lblNewP.BeforePrint, lblRepeatP.BeforePrint, lblTotalP.BeforePrint
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