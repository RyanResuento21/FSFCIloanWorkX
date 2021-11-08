Public Class RptExportGeneralJournal

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel4, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, lblReferenceNo, lblPayee, lblDocumentDate, lblPostingDate, lblBank, lblExplanation, XrLabel11, XrLabel12, XrLabel14, lblPreparedBy, lblCheckBy, lblApprovedBy, XrLabel1, XrLabel2, XrLabel3, XrLabel5, XrLabel15, XrLabel13, lblAccountCode, lblBusinessCode, lblDepartmentCode, lblDebit, lblCredit, lblRemarks})
    End Sub
End Class