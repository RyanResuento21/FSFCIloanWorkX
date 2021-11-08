Public Class RptAuthorization

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, lblFinancialH, XrLabel4, XrLabel5, XrLabel6, XrLabel1, XrLabel3, XrLabel9})
        ReportLabelFontSettings({lblTitle, XrLabel7, lblBranch, XrLabel2, lblUser, XrLabel8, lblGroupRole, lblForm})
        ReportCheckBoxFontSettings({cbxView, cbxSave, cbxUpdate, cbxDelete, cbxPrint, cbxCheck, cbxApprove})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class