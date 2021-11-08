Public Class RptImportCheckDisbursement

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel4, XrLabel6, XrLabel7, XrLabel8, XrLabel1, XrLabel2, XrLabel20, XrLabel9, XrLabel10, XrLabel3, XrLabel5, XrLabel11, XrLabel12, XrLabel15, XrLabel13, XrLabel14, XrLabel16, XrLabel17, XrLabel18, XrLabel19, lblReferenceNo, lblPayee, lblDocumentDate, lblPostingDate, lblCheckNo, lblCheckDate, lblClearDate, lblBank, lblExplanation, lblAccountCode, lblBusinessCode, lblDepartmentCode, lblDebit, lblCredit, lblRemarks, lblPreparedBy, lblCheckBy, lblApprovedBy, lblReceivedBy, lblReceivedDate})
    End Sub
End Class