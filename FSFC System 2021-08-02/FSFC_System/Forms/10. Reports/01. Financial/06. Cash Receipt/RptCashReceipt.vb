Public Class RptCashReceipt

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel15, XrLabel31})
        ReportLabelFontSettings({lblEntryStatus, lblDepositStatus, lblTransactionType, lblDocumentDate, lblDateDeposited, lblPostingDate, lblPayor, lblAccountNumber, lblDocumentNumber, lblPayment, lblMotherAccount, lblAccountCode, lblDepartment, lblDebit, lblCredit, lblRemarks, lblDebitT, lblCreditT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblDebit.BeforePrint, lblCredit.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class