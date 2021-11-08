Public Class Rpt6CollectionSummary

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel3, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9})
        ReportLabelFontSettings({lblTitle, XrLabel4, XrLabel2, lblProduct, lblProductCode, lblWeek1, lblWeek2, lblWeek3, lblWeek4, lblWeek5, lblWeekT})
        ReportPageInfoFontSettings({XrPageInfo3, XrPageInfo4})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblWeek1.BeforePrint, lblWeek2.BeforePrint, lblWeek3.BeforePrint, lblWeek4.BeforePrint, lblWeek5.BeforePrint, lblWeekT.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            If lblProduct.Text = "GRAND TOTAL" Or lblProduct.Tag = -1 Then
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Bold)
                If lblProduct.Text.Contains("LESS:") Then
                    .ForeColor = OfficialColor2 'Color.Red
                Else
                    .ForeColor = Color.Black
                End If
            Else
                .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
                If lblProduct.Text.Contains("LESS:") Then
                    .ForeColor = OfficialColor2 'Color.Red
                Else
                    .ForeColor = Color.Black
                End If
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
                If lblProduct.Text.Contains("ADD:") Then
                    .BackColor = Color.Yellow
                Else
                    .BackColor = Color.White
                End If
            End If
            If lblProduct.Text.Contains("LESS:") Then
                .ForeColor = OfficialColor2 'Color.Red
            Else
                .ForeColor = Color.Black
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