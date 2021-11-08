Public Class RptBulkMigration

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel3, XrLabel5, XrLabel15, XrLabel2, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel11, XrLabel12, XrLabel14, XrLabel16, XrLabel17, XrLabel18, XrLabel20, XrLabel19, XrLabel21, XrLabel22, XrLabel23, XrLabel24, XrLabel8, lblBorrowerID, lblBusinessCenter, lblProduct, lblAccountNumber, lblCollateral, lblTerms, lblInterestRate, lblRPPDRate, lblDateAvailed, lblLastPayment, lblDueDate, lblPrincipal, lblPrincipalBalance, lblUDI, lblUDIBalance, lblRPPD, lblRPPDBalance, lblUnpaidPenalty, lblGMA, lblMonthlyRabate, lblBank, lblIndustry})
    End Sub
End Class