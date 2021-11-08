Public Class RptAmortizationSchedule

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblMonthly.BeforePrint, lblInterest.BeforePrint, lblRPPD.BeforePrint, lblPrincipal.BeforePrint, lblOutstanding.BeforePrint, lblRPPD_2.BeforePrint, lblUnearn.BeforePrint, lblLoansReceivable.BeforePrint
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
        ReportLabelWithBackgroundFontSettings({XrLabel4, XrLabel2, XrLabel3, XrLabel5, XrLabel6, XrLabel8, XrLabel7, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel15, XrLabel16})
        ReportLabelFontSettings({XrLabel1, lblAmountApplied, lblTerms, lblProduct, lblPurpose, lblDate, lblNo, lblDue, lblMonthly, lblInterest, lblRPPD, lblPrincipal, lblOutstanding, lblRPPD_2, lblUnearn, lblLoansReceivable, XrLabel17})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class