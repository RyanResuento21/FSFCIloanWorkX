Public Class RptChartOfAccountsV2

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblFinancialH, lblAccountH, XrLabel3, XrLabel2})
        ReportLabelFontSettings({lblTitle, lblMotherCode, lblSubcode, lblSubaccount})
        ReportPageInfoFontSettings({XrPageInfo1})
    End Sub
End Class