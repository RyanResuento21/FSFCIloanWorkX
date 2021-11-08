Public Class RptRequestLoanApproval

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel3})
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel7, lblBorrower, XrLabel4, lblPrincipal_R, lblPrincipal_A, XrLabel9, lblTerm_R, lblTermType_R, lblTerm_A, lblTermType_A, XrLabel12, lblInterest_R, XrLabel14, lblInterest_A, XrLabel15, XrLabel19, lblService_R, lblService_A, XrLabel23, lblProduct, XrLabel26, lblLoanable, XrLabel27, lblNetProceeds, lblCreditNumber, XrLabel32, lblNarrative, XrLabel34, XrLabel36, lblTotalMonthly, XrLabel38, XrLabel39, lblTotalExpenses, XrLabel42, XrLabel43, lblDisposable, XrLabel45, XrLabel46, lblTMFI, XrLabel48, XrLabel49, lblTMDI})
        ReportCheckBoxFontSettings({cbxGood, cbxFair, cbxPoor})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class