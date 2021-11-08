Public Class RptCollectionCashCount

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel2, XrLabel46, XrLabel47, XrLabel48, XrLabel49, XrLabel50, XrLabel3, XrLabel4, XrLabel45, XrLabel59, XrLabel58, XrLabel57, XrLabel56, XrLabel55, XrLabel75, XrLabel76, XrLabel60, XrLabel1, XrLabel5, XrLabel8, XrLabel6, XrLabel14, XrLabel17, XrLabel18, XrLabel10, XrLabel11, XrLabel13, XrLabel21, XrLabel62})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel16, lblDocumentDate, XrLabel9, lblDocumentNumber, XrLabel7, XrLabel12, XrLabel15, i1000, d1000, i500, d500, i200, d200, XrLabel19, XrLabel22, XrLabel25, i100, d100, i50, d50, i20, d20, XrLabel28, XrLabel31, XrLabel34, i10, d10, i5, d5, i1, d1, XrLabel37, XrLabel40, XrLabel43, XrLabel23, i025, d025, i010, d010, i005, i001, d005, lblTotalCash, XrLabel51, XrLabel73, cbxORLastIssued, dtpORLastIssued, XrLabel79, cbxORDeposited, dtpORDeposited, XrLabel54, lblTotalCheck, lblTotalCollection, XrLabel20, lblShort, lblExplanation, XrLabel68, XrLabel65, XrLabel67, lblPreparedBy, XrLabel66, lblCheckedBy, XrLabel64, lblApprovedBy, XrLabel63})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class