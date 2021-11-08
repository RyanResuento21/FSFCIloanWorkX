Public Class RptBulkMigrationNotes

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel3, XrLabel2, XrLabel4, XrLabel5})
    End Sub
End Class