Public Class RptSalaryLoanPayment

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, lblFinancialH, XrLabel4, XrLabel5, XrLabel6})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel1, lblBranch, lblPayor, lblAccountNumber, lblBalance, lblNMA, lblAmount, lblBalanceT, lblNMAT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class