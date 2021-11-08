Public Class SubRptSchedule

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblNo, lblDate, lblRPPD, lblUDI, lblPrincipal, lblLoansReceivable})
    End Sub
End Class