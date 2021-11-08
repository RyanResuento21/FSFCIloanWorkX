Public Class RptImportPDC

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, lblBorrower, lblAccountNumber, lblBank, lblBranch, lblCheckNum, lblDate, lblAmount, lblBankAccountNum, lblRemarks})
    End Sub
End Class