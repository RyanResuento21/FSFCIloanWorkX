Public Class RptCaseMonitoringArchived

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel7, XrLabel6})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblBranch, lblAA1, lblAP1, lblAA2, lblAP2, lblBranchT, lblAA1T, lblAP1T, lblAA2T, lblAP2T})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAA1.BeforePrint, lblAA1T.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class