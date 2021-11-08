Public Class RptSubsidiaryLedgervb

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel1, XrLabel2, XrLabel48, XrLabel4, XrLabel6, XrLabel10, XrLabel9, XrLabel8, XrLabel18, XrLabel14, XrLabel16, XrLabel21, XrLabel12, XrLabel42, XrLabel23, XrLabel44, XrLabel24, XrLabel27, XrLabel28, XrLabel31, XrLabel33, XrLabel35, XrLabel37, XrLabel38})
        ReportLabelFontSettings({lblTitle, lblReceivedFrom, lblAccountN, lblBorrwer, XrLabel3, lblSpouse, XrLabel5, lblAddress, XrLabel7, lblCoMaker1, XrLabel32, lblCoMaker2, XrLabel34, lblCoMaker3, XrLabel36, lblCoMaker4, XrLabel11, lblCollateral, XrLabel13, lblMotorNumber, XrLabel15, lblORNumber, XrLabel17, lblTCTNumber, XrLabel19, lblInsurance, XrLabel20, lblPremium, XrLabel22, lblPrincipal, XrLabel25, lblUDI, XrLabel26, lblRPPD, XrLabel29, lblFaceAmount, XrLabel71, lblRate, XrLabel68, lblGMA, XrLabel73, lblMR, XrLabel74, lblNMA, XrLabel30, lblEmailAddress, XrLabel39, lblBirthdate, XrLabel40, lblMobile, XrLabel43, lblMobile_1, XrLabel45, lblMobile_2, XrLabel47, lblMobile_3, XrLabel49, lblMobile_4, XrLabel50, lblPlateNumber, XrLabel53, lblChassisNumber, XrLabel54, lblColor, XrLabel56, lblLocation, XrLabel59, lblCoverage, XrLabel61, lblCVNum, XrLabel80, lblTerms, XrLabel83, lblPNDate, XrLabel78, lblFDD, XrLabel77, lblMD, XrLabel63, lblArea, XrLabel64, lblExpiry, XrLabel66, lblInsuranceDate, XrLabel87, lblDateReleased, XrLabel84, lblInvestigator, XrLabel89, lblReferred, XrLabel90, lblNotes})
        ReportCheckBoxFontSettings({cbxNewAccount, cbxRenewal, cbxRestructured})
    End Sub
End Class