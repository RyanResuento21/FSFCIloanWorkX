Public Class RptAgentProfile

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel3, XrLabel5, XrLabel100, XrLabel7, XrLabel8, XrLabel9, XrLabel192, XrLabel193, XrLabel194, XrLabel195})
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel4, lblBorrowerID, XrLabel6, lblBorrower, XrLabel14, lblCompleteAdd, XrLabel18, lblBirthDate, XrLabel20, lblBirthPlace, XrLabel22, XrLabel23, XrLabel24, lblCitizenship, XrLabel26, lblTIN, XrLabel28, lblTelephone, XrLabel30, lblSSS, XrLabel33, lblMobile, XrLabel35, lblEmail, lblFrom_1, lblTo_1, lblPosition_1, lblCompany_1, lblFrom_2, lblTo_2, lblPosition_2, lblCompany_2, lblFrom_3, lblTo_3, lblPosition_3, lblCompany_3, lblReference_1, lblReferenceAdd_1, lblReferenceTel_1, lblReference_2, lblReferenceAdd_2, lblReferenceTel_2, lblReference_3, lblReferenceAdd_3, lblReferenceTel_3})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class