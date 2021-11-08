Public Class RptCheckRegistry

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel18, XrLabel5, XrLabel4, XrLabel13, XrLabel6, XrLabel14, XrLabel29})
        ReportLabelFontSettings({lblTitle, XrLabel7, lblSupplier, XrLabel3, lblBank, XrLabel8, lblPrincipal, XrLabel11, lblTerms, XrLabel16, lblDocumentDate, XrLabel9, lblPostingDate, XrLabel17, lblInterestRate, XrLabel23, XrLabel10, lblDocumentNumber, XrLabel12, lblReferenceNumber, XrLabel19, lblInterest, lblNo, lblBankV2, lblBranch, lblCheckNumber, lblDate, lblAmount, lblRemarks, lblAmountT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class