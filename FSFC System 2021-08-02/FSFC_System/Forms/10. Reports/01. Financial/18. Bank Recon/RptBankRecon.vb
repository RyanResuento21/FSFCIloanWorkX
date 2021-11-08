Public Class RptBankRecon

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel2, XrLabel3, XrLabel18, XrLabel46, XrLabel19, XrLabel20, XrLabel21, XrLabel22, XrLabel23, XrLabel25, XrLabel24, XrLabel26, XrLabel27, XrLabel28, XrLabel29, lblC, lblD, XrLabel35, XrLabel33, XrLabel36, XrLabel37, XrLabel40, XrLabel38, XrLabel39, XrLabel49, XrLabel50, XrLabel48, XrLabel47, XrLabel45, XrLabel44, XrLabel51, XrLabel43, XrLabel52, XrLabel53, XrLabel54, XrLabel55})
        ReportLabelFontSettings({lblBranch, lblTitle, lblSA, lblAsOf, lblUnadjusted, XrLabel6, XrLabel11, XrLabel14, lblCRBook, lblCDBook, lblGJBook, lblTotalBook, lblCRBank, lblCDBank, lblGJBank, lblTotalBank, XrLabel17, lblAdjusted, lblAdjustedBook, lblAdjustedBank, lblAdjustedTotalBank, XrLabel68, lblPreparedBy, lblPreparedPos, XrLabel63, lblReviewedBy, lblReviewedPos})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LblAmount_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblCRBook.BeforePrint, lblCRBank.BeforePrint, lblCDBook.BeforePrint, lblCDBank.BeforePrint, lblGJBook.BeforePrint, lblGJBank.BeforePrint, lblTotalBook.BeforePrint, lblTotalBank.BeforePrint, lblAdjustedBook.BeforePrint, lblAdjustedBank.BeforePrint, lblAdjustedTotalBank.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            If IsNumeric(.Text) Then
                .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
            End If
        End With
    End Sub
End Class