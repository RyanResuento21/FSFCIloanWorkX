Public Class RptExportToXlsx

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel3, XrLabel5, XrLabel15, XrLabel13, lblAccountCode, lblBusinessCode, lblDepartmentCode, lblDebit, lblCredit, lblRemarks})
    End Sub
End Class