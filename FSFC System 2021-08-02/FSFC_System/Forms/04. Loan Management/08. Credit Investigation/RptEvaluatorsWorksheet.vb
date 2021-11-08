Public Class RptEvaluatorsWorksheet

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel59, XrLabel60, XrLabel69, XrLabel71})
        ReportLabelFontSettings({XrLabel1, XrLabel7, lblBorrower, XrLabel3, lblAddress, XrLabel5, lblTelephone, XrLabel8, lblCollateral, XrLabel10, lblTypeLoan, XrLabel11, lblTerms, XrLabel13, lblModePayment, XrLabel15, lblAppraisedValue, XrLabel21, XrLabel22, XrLabel24, XrLabel25, XrLabel28, XrLabel30, XrLabel32, XrLabel34, XrLabel36, XrLabel38, XrLabel40, XrLabel41, XrLabel43, XrLabel45, XrLabel47, lblDisposable, lblLiving, lblClothing, lblEducation, lblTransportation, lblLights, lblInsurance, lblAmortization, lblMiscellaneous, lblTotal, lblNetDisposable, lblTMFI, lblTMDI, XrLabel49, XrLabel50, XrLabel52, XrLabel54, XrLabel55, XrLabel57, XrLabel61, XrLabel63, XrLabel65, lblFaceAmount, lblRPPD, lblUDI, lblTotalDeductions, lblGMA, lblRebate, lblNMA, lblJustification, lblDeviations, lblRecommendation, lblC1, lblC2, lblC3, lblC4, lblC5, lblC6, lblC7, lblC8, lblC9, XrLabel73, XrLabel74, lblEvaluator, lblPosition})
        ReportCheckBoxFontSettings({cbxApproval, cbxDisapproval})
    End Sub
End Class