Public Class RptGroupRole

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({lblAccountH, lblFinancialH, XrLabel4, XrLabel5, XrLabel6, XrLabel1, XrLabel2, XrLabel3})
        ReportLabelFontSettings({lblTitle, lblGroupRole, XrLabel7, lblForm})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
        ReportCheckBoxFontSettings({cbxView, cbxSave, cbxUpdate, cbxDelete, cbxPrint, cbxCheck, cbxApprove})
    End Sub
End Class