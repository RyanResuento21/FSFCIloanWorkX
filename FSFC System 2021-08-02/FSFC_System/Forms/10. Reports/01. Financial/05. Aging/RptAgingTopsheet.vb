Public Class RptAgingTopsheet

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13})
        ReportLabelFontSettings({lblBranch, lblTitle, lblAsOf, XrLabel1, lblProduct, XrLabel23, XrLabel33, XrLabel50, XrLabel14, lblSub, XrLabel32, XrLabel49, XrLabel15, lblCode, XrLabel31, XrLabel48, XrLabel16, lblOutstanding, lblOutstandingP, lblOutstandingT1, lblOutstandingPT1, lblOutstandingT2, lblOutstandingPT2, XrLabel17, lblCurrent, lblCurrentP, lblCurrentT1, lblCurrentPT1, lblCurrentT2, lblCurrentPT2, XrLabel18, lbl1_30, lbl1_30P, lbl1_30T1, lbl1_30PT1, lbl1_30T2, lbl1_30PT2, XrLabel19, lbl31_60, lbl31_60P, lbl31_60T1, lbl31_60PT1, lbl31_60T2, lbl31_60PT2, XrLabel20, lbl61_90, lbl61_90P, lbl61_90T1, lbl61_90PT1, lbl61_90T2, lbl61_90PT2, XrLabel21, lbl91_120, lbl91_120P, lbl91_120T1, lbl91_120PT1, lbl91_120T2, lbl91_120PT2, XrLabel22, lblOver120, lblOver120P, lblOver120T1, lblOver120PT1, lblOver120T2, lblOver120PT2})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblOutstanding.BeforePrint, lblCurrent.BeforePrint, lbl1_30.BeforePrint, lbl31_60.BeforePrint, lbl61_90.BeforePrint, lbl91_120.BeforePrint, lblOver120.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub

    Private Sub PercentX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblCurrentP.BeforePrint, lbl1_30P.BeforePrint, lbl31_60P.BeforePrint, lbl61_90P.BeforePrint, lbl91_120P.BeforePrint, lblOver120P.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", FormatPercent(.Text, 2))
        End With
    End Sub
End Class