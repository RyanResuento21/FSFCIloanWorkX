Public Class RptPDCReceipt

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel24})
        ReportLabelFontSettings({lblTitle, lblReceivedFrom, lblBorrower, XrLabel6, lblContactN, lblNo, lblBank, lblBranch, lblCheckN, lblCheckD, lblAmount, lblRemarksC, lblTotal, XrLabel111, lblConfirmed, XrLabel30, lblBorrower2, lblBorrowerType, lblConfirmedD, lblReceivedBy, lblAuthorized, lblReceivedD})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class