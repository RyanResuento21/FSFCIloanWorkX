Public Class RptGeneralLedgerAccount

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel10, XrLabel1, XrLabel5, XrLabel7, XrLabel8, XrLabel11})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel4, lblType, XrLabel2, lblClassification, XrLabel3, lblGroup, XrLabel6, lblAccountNum, lblAccount, XrLabel9, lblRemarks, lblCode, lblAccountTitle, lblDepartmentCode, lblDebit, lblCredit, lblTotal})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblDebit.BeforePrint, lblCredit.BeforePrint, lblTotal.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", If(.Text < 0, NegativeParenthesisV2(.Text), FormatNumber(CDbl(.Text), 2)))
        End With
    End Sub
End Class