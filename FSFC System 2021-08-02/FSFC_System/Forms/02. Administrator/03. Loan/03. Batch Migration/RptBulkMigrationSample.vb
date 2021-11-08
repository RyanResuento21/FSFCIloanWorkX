Public Class RptBulkMigrationSample

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel38, XrLabel1, XrLabel15, XrLabel2, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel12, XrLabel10, XrLabel14, XrLabel17, XrLabel20, XrLabel22, XrLabel23, XrLabel25, XrLabel83, XrLabel84, XrLabel85, XrLabel86, XrLabel3, XrLabel5, XrLabel16, XrLabel18, XrLabel19, XrLabel21, XrLabel11, XrLabel24, XrLabel13, XrLabel78, XrLabel77, XrLabel79, XrLabel81, XrLabel80, XrLabel82})
        ReportLabelFontSettings({lblBorrowerID, lblAccountNumber, lblCollateral, lblTerms, lblInterestRate, lblRPPDRate, lblDateAvailed, lblDueDate, lblFDD, lblPrincipal, lblUDI, lblRPPD, lblGMA, lblMonthlyRabate, lblCVNumber, XrLabel87, XrLabel88, XrLabel89, XrLabel90, lblBusinessCenter, lblProduct, lblPrincipalBalance, lblUDIBalance, lblRPPDBalance, lblUnpaidPenalty, lblLastPayment, lblBank, lblRemarks, XrLabel26, XrLabel27, XrLabel28, XrLabel29, XrLabel30, XrLabel31, XrLabel32, XrLabel34, XrLabel33, XrLabel35, XrLabel36, XrLabel42, XrLabel41, XrLabel39, XrLabel40, XrLabel43, XrLabel44, XrLabel46, XrLabel45, XrLabel50, XrLabel49, XrLabel47, XrLabel48, XrLabel58, XrLabel57, XrLabel55, XrLabel56, XrLabel51, XrLabel52, XrLabel54, XrLabel53, XrLabel59, XrLabel60, XrLabel62, XrLabel61, XrLabel66, XrLabel65, XrLabel63, XrLabel64, XrLabel74, XrLabel73, XrLabel71, XrLabel72, XrLabel67, XrLabel68, XrLabel70, XrLabel69, XrLabel91, XrLabel92, XrLabel96, XrLabel95, XrLabel93, XrLabel94, XrLabel98, XrLabel97, XrLabel75, XrLabel76, XrLabel99})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class