Public Class RptLedgerCard

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel18, XrLabel37, XrLabel38, XrLabel39, XrLabel40, XrLabel41, XrLabel42, XrLabel43, XrLabel44, XrLabel45, XrLabel46, XrLabel47})
        ReportLabelFontSettings({lblTitle, lblCompanyAddress, lblCompanyNumber, lblProduct, XrLabel4, XrLabel3, lblCode, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, lblName, lblAddress, lblLoanGranted, lblInterestAmount, lblDateGranted, lblMaturityDate, lblNoOfPayments, XrLabel30, lblLoanTerms, lblAccountOfficer, XrLabel17, lblClientNumber, XrLabel19, XrLabel20, lblPrincipal, XrLabel21, lblInterest, XrLabel24, lblTotal, XrLabel32, lblLoanCycle, XrLabel35, lblAONumber, lblNo, lblSchedDate, lblActualPaymenDate, lblLoanPayment, lblLoanBalance, lblInterestPayment, lblPenalty, lblPDI, lblNoOfDays, lblTotalAmountPaid, lblSignature})
        ReportCheckBoxFontSettings({cbxPickup, cbxCash, cbxWalkin, cbxCheck, cbxDaily, cbxWeekly, cbxSemiMonthly, cbxMonthly, cbxMon, cbxTue, cbxWed, cbxThu, cbxFri})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblLoanPayment.BeforePrint, lblLoanBalance.BeforePrint, lblInterestPayment.BeforePrint, lblPenalty.BeforePrint, lblPDI.BeforePrint, lblTotalAmountPaid.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class