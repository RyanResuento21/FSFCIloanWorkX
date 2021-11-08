Public Class RptJournalVoucher

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
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel2, XrLabel1, XrLabel8, XrLabel5, XrLabel15, XrLabel13})
        ReportLabelFontSettings({lblTitle, XrLabel7, lblPayee, XrLabel3, lblBank, XrLabel16, XrLabel14, lblDocumentDate, lblPostingDate, XrLabel9, lblDocumentNumber, XrLabel4, lblReferenceNumber, lblExplanation, lblAccount, lblBusinessCenter, lblDepartment, lblDebit, lblCredit, lblRemarks, lblDebitT, lblCreditT, XrLabel42, lblPreparedBy, XrLabel46, XrLabel28, lblCheckedBy, XrLabel26, XrLabel29, lblApprovedBy, XrLabel31})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class