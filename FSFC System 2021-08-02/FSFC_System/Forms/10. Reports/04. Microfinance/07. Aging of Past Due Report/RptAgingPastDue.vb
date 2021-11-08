Public Class RptAgingPastDue

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel15, XrLabel16, XrLabel17, XrLabel18, XrLabel19, XrLabel20, XrLabel21, XrLabel22, XrLabel23, XrLabel24})
        ReportLabelFontSettings({lblFSFC, lblBranch, lblTitle, lblAsOf, lblAccountOfficer, XrLabel25, lblCurrent_Client, lblCurrent_Amount, lbl1to30_Client, lbl1to30_Amount, lbl31to60_Client, lbl31to60_Amount, lbl61to90_Client, lbl61to90_Amount, lbl91to120_Client, lbl91to120_Amount, lblOver120_Client, lblOver120_Amount, lblTotalPastDue_Client, lblTotalPastDue_Amount, lblTotalPortfolio_Client, lblTotalPortfolio_Amount, lblCurrent_ClientT, lblCurrent_AmountT, lbl1to30_ClientT, lbl1to30_AmountT, lbl31to60_ClientT, lbl31to60_AmountT, lbl61to90_ClientT, lbl61to90_AmountT, lbl91to120_ClientT, lbl91to120_AmountT, lblOver120_ClientT, lblOver120_AmountT, lblTotalPastDue_ClientT, lblTotalPastDue_AmountT, lblTotalPortfolio_ClientT, lblTotalPortfolio_AmountT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblCurrent_Amount.BeforePrint, lbl1to30_Amount.BeforePrint, lbl31to60_Amount.BeforePrint, lbl61to90_Amount.BeforePrint, lbl91to120_Amount.BeforePrint, lblOver120_Amount.BeforePrint, lblTotalPastDue_Amount.BeforePrint, lblTotalPortfolio_Amount.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender

        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class