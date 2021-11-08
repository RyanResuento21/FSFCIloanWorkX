Public Class Rpt7CollectionDetailed

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel3, XrLabel5, XrLabel6, XrLabel7, XrLabel13, XrLabel11, XrLabel10, XrLabel9, XrLabel20, XrLabel18, XrLabel17, XrLabel15, XrLabel26, XrLabel24, XrLabel23, XrLabel22, XrLabel32, XrLabel30, XrLabel29, XrLabel28})
        ReportLabelFontSettings({lblTitle, XrLabel4, XrLabel12, XrLabel19, XrLabel25, XrLabel31, XrLabel2, lblProduct, lblProductCode, lblLR1, lblCurrent1, lblPastDue1, lblOthers1, lblLR2, lblCurrent2, lblPastDue2, lblOthers2, lblLR3, lblCurrent3, lblPastDue3, lblOthers3, lblLR4, lblCurrent4, lblPastDue4, lblOthers4, lblLR5, lblCurrent5, lblPastDue5, lblOthers5})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblLR1.BeforePrint, lblCurrent1.BeforePrint, lblPastDue1.BeforePrint, lblOthers1.BeforePrint, lblLR2.BeforePrint, lblCurrent2.BeforePrint, lblPastDue2.BeforePrint, lblOthers2.BeforePrint, lblLR3.BeforePrint, lblCurrent3.BeforePrint, lblPastDue3.BeforePrint, lblOthers3.BeforePrint, lblLR4.BeforePrint, lblCurrent4.BeforePrint, lblPastDue4.BeforePrint, lblOthers4.BeforePrint, lblLR5.BeforePrint, lblCurrent5.BeforePrint, lblPastDue5.BeforePrint, lblOthers5.BeforePrint
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
                If lblProduct.Text.Contains("ADD:") Then
                    .BackColor = Color.Yellow
                Else
                    .BackColor = Color.White
                End If
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