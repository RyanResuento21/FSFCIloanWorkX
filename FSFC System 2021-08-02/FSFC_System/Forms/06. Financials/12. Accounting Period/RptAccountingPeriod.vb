Public Class RptAccountingPeriod

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel10, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel8, XrLabel9, XrLabel11, XrLabel12, XrLabel13, XrLabel14, XrLabel15})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel7, lblYear, lblBranch, lbl_01, lbl_02, lbl_03, lbl_04, lbl_05, lbl_06, lbl_07, lbl_08, lbl_09, lbl_10, lbl_11, lbl_12})
    End Sub
End Class