Public Class RptGeneralLedgerPeriodic

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel10, XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblCode, lblAccount, lblSubAccount, lblDepartment, lblBeginning, lblDebit, lblCredit, lblEnding})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblDebit.BeforePrint, lblCredit.BeforePrint, lblBeginning.BeforePrint, lblEnding.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class