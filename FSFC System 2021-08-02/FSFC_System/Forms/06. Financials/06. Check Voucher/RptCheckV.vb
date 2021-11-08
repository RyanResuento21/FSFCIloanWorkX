Public Class RptCheckV

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
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel15, XrLabel10, XrLabel18, XrLabel17, XrLabel6, XrLabel12, XrLabel13})
        ReportLabelFontSettings({lblTitle, XrLabel7, lblPayee, XrLabel3, lblBank, XrLabel16, lblDocumentDate, XrLabel14, lblPostingDate, XrLabel11, lblCheckDate, XrLabel9, lblDocumentNumber, XrLabel4, lblReferenceNumber, XrLabel8, lblCheckNumber, lblExplanation, lblNet, lblAccount, lblBusinessCenter, lblDepartment, lblDebit, lblCredit, lblRemarks, lblDebitT, lblCreditT, XrLabel25, lblWords, XrLabel34, lblReceivedBy, XrLabel32, XrLabel5, lblDateReceived, XrLabel42, lblPreparedBy, XrLabel46, lblCheckedBy, XrLabel28, XrLabel26, XrLabel29, lblApprovedBy, XrLabel31, XrLabel20, lblApprovedBy_2, XrLabel22, XrLabel1, lblNotedBy, XrLabel19})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class