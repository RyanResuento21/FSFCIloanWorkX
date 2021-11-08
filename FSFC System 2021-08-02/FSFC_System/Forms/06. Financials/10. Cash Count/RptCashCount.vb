Public Class RptCashCount

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel2, XrLabel41, XrLabel1, XrLabel45, XrLabel46, XrLabel47, XrLabel48, XrLabel49, XrLabel50, XrLabel53, XrLabel54, XrLabel55, XrLabel56, XrLabel58, XrLabel60, XrLabel61, XrLabel62, XrLabel63, XrLabel65, XrLabel75, XrLabel76, XrLabel8})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel3, lblDocumentDate, XrLabel5, lblDocumentNumber, XrLabel4, XrLabel7, XrLabel10, i1000, i500, i200, d1000, d500, d200, XrLabel13, XrLabel16, XrLabel19, i100, i50, i20, d100, d50, d20, XrLabel24, XrLabel27, XrLabel30, i10, i5, i1, d10, d5, d1, XrLabel31, XrLabel34, XrLabel37, i025, i010, i005, XrLabel23, d025, d010, i001, d005, XrLabel44, dTotalCash, XrLabel51, dTotalCheck, XrLabel59, dTotalUnreplenish, XrLabel64, dTotalCashAdvances, XrLabel68, dTotalFund, XrLabel69, dAccountability, XrLabel72, dOverage, XrLabel73, txtORLastIssued, dtpORLastIssued, XrLabel79, txtORDeposited, dtpORDeposited, XrLabel82, txtORNotIssued, dtpORNotIssued, lblRemarks, lblNote, lblPreparedBy, lblPreparedPos})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class