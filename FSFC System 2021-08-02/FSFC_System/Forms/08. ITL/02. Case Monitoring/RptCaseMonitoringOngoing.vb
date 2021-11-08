Public Class RptCaseMonitoringOngoing

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel1, XrLabel8, XrLabel21, XrLabel22, XrLabel29, XrLabel42, XrLabel43, XrLabel44, XrLabel63, XrLabel2, XrLabel3, XrLabel9, XrLabel10, XrLabel20, XrLabel19, XrLabel23, XrLabel24, XrLabel30, XrLabel31, XrLabel41, XrLabel40, XrLabel46, XrLabel47, XrLabel52, XrLabel53, XrLabel45, XrLabel58, XrLabel4, XrLabel5, XrLabel7, XrLabel6, XrLabel12, XrLabel11, XrLabel13, XrLabel14, XrLabel17, XrLabel18, XrLabel16, XrLabel15, XrLabel26, XrLabel25, XrLabel27, XrLabel28, XrLabel33, XrLabel32, XrLabel34, XrLabel35, XrLabel38, XrLabel39, XrLabel37, XrLabel36, XrLabel49, XrLabel48, XrLabel50, XrLabel51, XrLabel55, XrLabel54, XrLabel56, XrLabel57, XrLabel60, XrLabel59, XrLabel61, XrLabel62})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblBranch, lblAA1, lblAP1, lblAA2, lblAP2, lblBA1, lblBP1, lblBA2, lblBP2, lblCA1, lblCP1, lblCA2, lblCP2, lblDA1, lblDP1, lblDA2, lblDP2, lblEA1, lblEP1, lblEA2, lblEP2, lblFA1, lblFP1, lblFA2, lblFP2, lblGA1, lblGP1, lblGA2, lblGP2, lblHA1, lblHP1, lblHA2, lblHP2, lblAA1T, lblAP1T, lblAA2T, lblAP2T, lblBA1T, lblBP1T, lblBA2T, lblBP2T, lblCA1T, lblCP1T, lblCA2T, lblCP2T, lblDA1T, lblDP1T, lblDA2T, lblDP2T, lblEA1T, lblEP1T, lblEA2T, lblEP2T, lblFA1T, lblFP1T, lblFA2T, lblFP2T, lblGA1T, lblGP1T, lblGA2T, lblGP2T, lblHA1T, lblHP1T, lblHA2T, lblHP2T, lblTA1, lblTP1, lblTA2, lblTP2, lblTA1T, lblTP1T, lblTA2T, lblTP2T})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAA1.BeforePrint, lblBA1.BeforePrint, lblCA1.BeforePrint, lblDA1.BeforePrint, lblEA1.BeforePrint, lblFA1.BeforePrint, lblGA1.BeforePrint, lblHA1.BeforePrint, lblTA1.BeforePrint, lblAA1T.BeforePrint, lblBA1T.BeforePrint, lblCA1T.BeforePrint, lblDA1T.BeforePrint, lblEA1T.BeforePrint, lblFA1T.BeforePrint, lblGA1T.BeforePrint, lblHA1T.BeforePrint, lblTA1T.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class