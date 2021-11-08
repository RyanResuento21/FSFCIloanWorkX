Public Class RptCaseSetup

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel20})
        ReportLabelFontSettings({lblTitle, XrLabel7, lblDefendant, XrLabel1, lblITLDate, XrLabel4, lblReference, XrLabel5, lblAccountNo, XrLabel9, lblFaceAmount, XrLabel11, lblProduct, XrLabel12, lblOutstanding, XrLabel14, lblCollateral, XrLabel16, lblLastPayment, XrLabel18, lblBank, XrLabel22, lblCaseNumber, XrLabel23, lblDateFilled, XrLabel26, lblDueDate, XrLabel27, lblCategory, XrLabel30, lblSubcategory, XrLabel33, lblMovementDate, XrLabel32, lblCaseType, XrLabel36, lblBookValue, XrLabel37, lblDecisionValue, XrLabel39, lblActionPlan, XrLabel42, lblActionDate, XrLabel44, lblRemarks, XrLabel47, lblReasons, XrLabel53, lblPreparedBy, XrLabel51, XrLabel50, lblCounsel, XrLabel49})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class