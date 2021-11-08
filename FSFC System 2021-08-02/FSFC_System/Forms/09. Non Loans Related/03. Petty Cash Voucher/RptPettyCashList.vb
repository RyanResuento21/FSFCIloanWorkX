Public Class RptPettyCashList

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel11, XrLabel10, XrLabel5, XrLabel2, XrLabel3, XrLabel4, XrLabel6, XrLabel7, XrLabel8, XrLabel9})
        ReportLabelFontSettings({lblTotalT, lblTitle, XrLabel1, lblAsOf, lblNo, lblPayee, lblDate, lblDocument, lblPurpose, lblTotal, lblStatus, lblPrepared, lblApproved})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblTotal.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class