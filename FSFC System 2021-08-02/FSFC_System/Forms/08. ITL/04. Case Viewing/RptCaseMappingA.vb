Public Class RptCaseMappingA

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, XrLabel2, XrLabel1, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel12, XrLabel11, XrLabel14, XrLabel13, XrLabel15, XrLabel16, XrLabel18, XrLabel17, XrLabel19, XrLabel20, XrLabel22, XrLabel21, XrLabel23, XrLabel26, XrLabel25, XrLabel24, XrLabel27, XrLabel28})
        ReportLabelFontSettings({lblTitle, lblNo, lblBranch, lblAmount_A, lblAccount_A, lblAmount_B, lblAccount_B, lblAmount_C, lblAccount_C, lblAmount_D, lblAccount_D, lblAmount_E, lblAccount_E, lblAmount_F, lblAccount_F, lblAmount_T, lblAccount_T, lblNoT, lblBranchT, lblAmount_AT, lblAccount_AT, lblAmount_BT, lblAccount_BT, lblAmount_CT, lblAccount_CT, lblAmount_DT, lblAccount_DT, lblAmount_ET, lblAccount_ET, lblAmount_FT, lblAccount_FT, lblAmount_TT, lblAccount_TT, lblAmount_G, lblAccount_G, lblAmount_H, lblAccount_H, lblAmount_GT, lblAccount_GT, lblAmount_HT, lblAccount_HT})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblAmount_A.BeforePrint, lblAmount_B.BeforePrint, lblAmount_C.BeforePrint, lblAmount_D.BeforePrint, lblAmount_E.BeforePrint, lblAmount_F.BeforePrint, lblAmount_G.BeforePrint, lblAmount_H.BeforePrint, lblAmount_T.BeforePrint, lblAmount_AT.BeforePrint, lblAmount_BT.BeforePrint, lblAmount_CT.BeforePrint, lblAmount_DT.BeforePrint, lblAmount_ET.BeforePrint, lblAmount_FT.BeforePrint, lblAmount_GT.BeforePrint, lblAmount_HT.BeforePrint, lblAmount_TT.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class