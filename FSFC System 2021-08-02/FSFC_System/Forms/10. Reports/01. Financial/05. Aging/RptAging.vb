Public Class RptAging

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel15, XrLabel16, XrLabel19, XrLabel22, XrLabel25, XrLabel26, XrLabel20, XrLabel23, XrLabel24, XrLabel27, XrLabel28, XrLabel29, XrLabel30, XrLabel31})
        ReportLabelFontSettings({lblProduct, lblAccountNumber, lblBorrower, lblCI, lblAO, lblCollateral, lblDateGranted, lblDueDate, lblDue, lblTerm, lblFA, lblGMA, lblLastPayment, lblMonthsLapsed, lblRemainDays, lblRemainMonths, lblBeginning, lblEnding, lblCurrent, lbl1_30, lbl31_60, lbl61_90, lbl91_120, lblOver120})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblFA.BeforePrint, lblGMA.BeforePrint, lblBeginning.BeforePrint, lblEnding.BeforePrint, lblCurrent.BeforePrint, lbl1_30.BeforePrint, lbl31_60.BeforePrint, lbl61_90.BeforePrint, lbl91_120.BeforePrint, lblOver120.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class