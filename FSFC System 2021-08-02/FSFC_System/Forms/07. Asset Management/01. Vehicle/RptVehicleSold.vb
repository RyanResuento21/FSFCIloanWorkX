Public Class RptVehicleSold

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel2, lblSOLD, XrLabel4, lblDate, XrLabel6, lblMake, XrLabel13, lblPlateNumber, XrLabel23, lblMotorNumber, XrLabel29, lblORNumber, XrLabel35, lblPrice, XrLabel3, lblAssetNumber, XrLabel8, lblType, XrLabel15, lblTransmission, XrLabel19, lblGasoline, XrLabel25, lblSerialNumber, XrLabel33, lblGrossWeight, XrLabel10, lblRim, XrLabel18, lblLastRegistered, XrLabel36, XrLabel7, lblCondition, lblReason, XrLabel11, lblEngine, XrLabel17, lblBodyColor, XrLabel20, lblYear, XrLabel27, lblRegCertNumber, XrLabel31, lblMileAge, XrLabel24, lblLTO, XrLabel5, lblBuyersName, XrLabel9, lblAddress, XrLabel12, lblBirthdate, XrLabel22, XrLabel16, lblORNumber_2, XrLabel21, lblORDate, XrLabel26, lblAmount})
        ReportRichTextFontSettings({lblRemarks})
        ReportCheckBoxFontSettings({cbxMale, cbxFemale})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class