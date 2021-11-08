Public Class RptAcknowledgementReceipt

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblDebit.BeforePrint, lblCredit.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel17, XrLabel1, XrLabel22, XrLabel18, XrLabel5, XrLabel4, XrLabel13})
        ReportLabelFontSettings({XrLabel2, lblAddress, XrLabel20, lblContact, XrLabel21, lblTIN, lblFSFC, lblTitle, XrLabel7, lblPayee, XrLabel3, lblBank, XrLabel16, lblDocumentDate, XrLabel9, lblPostingDate, XrLabel10, lblDocumentNumber, XrLabel12, lblReferenceNumber, lblExplanation, lblNet, lblAccount, lblBusinessCenter, lblDepartment, lblDebit, lblCredit, lblRemarks, lblDebitT, lblCreditT, XrLabel6, XrLabel8, lblCheckNumber, XrLabel11, lblDepositNumber, XrLabel14, lblCheckDate, XrLabel15, lblDepositDate, XrLabel42, XrLabel28, XrLabel29, lblPreparedBy, lblCheckedBy, lblApprovedBy, XrLabel46, XrLabel26, XrLabel31})
        ReportCheckBoxFontSettings({cbxCash, cbxCheck, cbxOnline})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class