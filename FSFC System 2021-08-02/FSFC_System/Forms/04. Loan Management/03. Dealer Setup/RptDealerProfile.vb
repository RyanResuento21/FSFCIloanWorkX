Public Class RptDealerProfile

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel3})
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel4, lblBorrowerID, XrLabel6, lblBorrower, XrLabel7, lblTradeN, XrLabel14, lblCompleteAdd, XrLabel28, lblTelephone, XrLabel26, lblTIN, XrLabel33, lblMobile, XrLabel30, lblSSS, XrLabel35, lblEmail, XrLabel11, lblFaxNo, XrLabel9, lblWebsite})
        ReportCheckBoxFontSettings({cbxCar})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class