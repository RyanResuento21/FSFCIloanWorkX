Public Class RptFinancialPlan

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblJan.BeforePrint, lblFeb.BeforePrint, lblMar.BeforePrint, lblApr.BeforePrint, lblMar.BeforePrint, lblMay.BeforePrint, lblJun.BeforePrint, lblTotal.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel4, XrLabel5, lblJanH, lblFebH, lblMarH, lblAprH, lblMayH, lblJunH, lblTotalH, XrLabel21})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel2, lblYear, lblCode, lblAccount, lblJan, lblFeb, lblMar, lblApr, lblMay, lblJun, lblTotal, lblJanT, lblFebT, lblMarT, lblAprT, lblMayT, lblJunT, lblTotalT, XrLabel42, lblPreparedBy, XrLabel46, XrLabel28, lblCheckedBy, XrLabel30, XrLabel29, lblApprovedBy, XrLabel31})
        ReportCheckBoxFontSettings({cbx1st, cbx2nd})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class