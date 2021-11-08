Public Class SubRptLedger

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblDate, lblRemarks, lblOR, lblAmountPaid, lblAR_P, lblPenalties_P, lblPenalties_W, lblRPPD_P, lblRPPD_F, lblInterest_P, lblPrincipal_P, lblAR_B, lblPenalties_B, lblRPPD_B, lblInterest_B, lblPrincipal_B, lblTotal_B})
    End Sub
End Class