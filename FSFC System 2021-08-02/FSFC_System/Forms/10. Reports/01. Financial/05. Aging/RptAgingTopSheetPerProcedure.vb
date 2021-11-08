Public Class RptAgingTopSheetPerProcedure

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel3, XrLabel5, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel13})
        ReportLabelFontSettings({lblBranch, lblTitle, lblAsOf, XrLabel1, lblCollectionProcedure, XrLabel50, lblCode, XrLabel48, lblOutstanding, lblOutstandingP, lblOutstandingT2, lblOutstandingPT2, lblCurrent, lblCurrentP, lbl1_30, lbl1_30P, lbl31_60, lbl31_60P, lbl61_90, lbl61_90P, lbl91_120, lbl91_120P, lblOver120, lblOver120P, lblCurrentT2, lblCurrentPT2, lbl1_30T2, lbl1_30PT2, lbl31_60T2, lbl31_60PT2, lbl61_90T2, lbl61_90PT2, lbl91_120T2, lbl91_120PT2, lblOver120T2, lblOver120PT2})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblOutstanding.BeforePrint, lblCurrent.BeforePrint, lbl1_30.BeforePrint, lbl31_60.BeforePrint, lbl61_90.BeforePrint, lbl91_120.BeforePrint, lblOver120.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0" Or .Text = "0.00", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub

    Private Sub PercentX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblCurrentP.BeforePrint, lbl1_30P.BeforePrint, lbl31_60P.BeforePrint, lbl61_90P.BeforePrint, lbl91_120P.BeforePrint, lblOver120P.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", FormatPercent(.Text, 2))
        End With
    End Sub
End Class