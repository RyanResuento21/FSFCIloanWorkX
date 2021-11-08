Public Class RptCaseMonitoringDismissed

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1, XrLabel8, XrLabel21, XrLabel45, XrLabel2, XrLabel3, XrLabel9, XrLabel10, XrLabel20, XrLabel19, XrLabel58, XrLabel59, XrLabel4, XrLabel5, XrLabel7, XrLabel6, XrLabel12, XrLabel11, XrLabel13, XrLabel14, XrLabel17, XrLabel18, XrLabel16, XrLabel15, XrLabel61, XrLabel60, XrLabel62, XrLabel63})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblBranch, lblAA1, lblAP1, lblAA2, lblAP2, lblBA1, lblBP1, lblBA2, lblBP2, lblCA1, lblCP1, lblCA2, lblCP2, lblAA1T, lblAP1T, lblAA2T, lblAP2T, lblBA1T, lblBP1T, lblBA2T, lblBP2T, lblCA1T, lblCP1T, lblCA2T, lblCP2T, lblTA1, lblTP1, lblTA2, lblTP2, lblTA1T, lblTP1T, lblTA2T, lblTP2T})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAA1.BeforePrint, lblBA1.BeforePrint, lblCA1.BeforePrint, lblTA1.BeforePrint, lblAA1T.BeforePrint, lblBA1T.BeforePrint, lblCA1T.BeforePrint, lblTA1T.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class