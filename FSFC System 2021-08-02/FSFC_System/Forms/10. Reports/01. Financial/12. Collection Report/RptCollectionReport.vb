Public Class RptCollectionReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel8, XrLabel1, XrLabel2, XrLabel3, XrLabel16, XrLabel4, XrLabel5, XrLabel7, XrLabel15, XrLabel9, XrLabel10, XrLabel6, XrLabel32, XrLabel17, XrLabel62, XrLabel73, XrLabel79, XrLabel39, XrLabel14, XrLabel11, lblCollectionSummary})
        ReportLabelFontSettings({lblTitle, lblBank, lblAsOf, lblDocumentNumber, lblIssuedTo, lblAccountNumber, lblCash, lblCheck, lblAmount, lblCheckNumber, lblCheckDate, lblLoans, lblOthers, lblCashT, lblCheckT, lblAmountT, lblLoansT, lblOthersT, XrLabel64, XrLabel66, XrLabel67, XrLabel69, XrLabel72, XrLabel63, XrLabel65, XrLabel68, XrLabel70, XrLabel71, XrLabel74, XrLabel75, XrLabel76, XrLabel78, XrLabel77, XrLabel80, XrLabel81, XrLabel82, XrLabel83, XrLabel84, XrLabel18, XrLabel19, XrLabel22, XrLabel23, XrLabel25, XrLabel24, XrLabel27, XrLabel26, XrLabel29, XrLabel28, XrLabel31, XrLabel30, XrLabel34, XrLabel33, XrLabel35, XrLabel36, XrLabel46, XrLabel45, XrLabel37, XrLabel38, XrLabel40, XrLabel41, XrLabel43, XrLabel42, XrLabel44, XrLabel47, XrLabel48, XrLabel49, XrLabel50, XrLabel51, XrLabel52, XrLabel53, XrLabel54, XrLabel55, XrLabel57, XrLabel56, XrLabel58, XrLabel59, XrLabel61, XrLabel60, XrLabel85, XrLabel86, XrLabel89, lblPreparedBy, lblCheckedBy, lblNotedBy, lblPosition, lblPositionChecked, lblPositionNoted, XrLabel13, XrLabel21, XrLabel91, XrLabel87, XrLabel93, XrLabel100, XrLabel103, XrLabel111, XrLabel112, lblCurrent_C, lblCurrent_P, lblCurrent_T, lblPrevious_C, lblPrevious_P, lblPrevious_T, lblTotal_C, lblTotal_P, lblTotal_T, lblCurrent_C2, lblCurrent_P2, lblCurrent_T2, lblPrevious_C2, lblPrevious_P2, lblPrevious_T2, lblTotal_C2, lblTotal_P2, lblTotal_T2, XrLabel101, XrLabel102, XrLabel106, XrLabel12, XrLabel97, lblReturnedCheck_C, lblCancelled_C, lblReturnedCheck_P, lblCancelled_P, lblReturnedCheck_T, lblCancelled_T, XrLabel105, XrLabel107, lblReturnedCheck_C2, lblCancelled_C2, lblReturnedCheck_P2, lblCancelled_P2, lblReturnedCheck_T2, lblCancelled_T2})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblCash.BeforePrint, lblCheck.BeforePrint, lblAmount.BeforePrint, lblLoans.BeforePrint, lblOthers.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class