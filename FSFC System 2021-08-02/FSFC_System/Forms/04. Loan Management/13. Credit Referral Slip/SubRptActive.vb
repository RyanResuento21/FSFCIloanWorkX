Public Class SubRptActive

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblAccountNumber, lblPrincipal, lblFaceAmount, lblOutstanding, lblGMA, lblDateGranted, lblMaturityDate, lblRemarks})
    End Sub
End Class