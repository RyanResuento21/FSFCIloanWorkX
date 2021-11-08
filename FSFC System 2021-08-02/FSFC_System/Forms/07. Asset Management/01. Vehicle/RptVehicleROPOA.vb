Public Class RptVehicleROPOA

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel2, lblSOLD, XrLabel4, XrLabel6, XrLabel13, XrLabel23, XrLabel29, XrLabel35, lblDate, lblMake, lblPlateNumber, lblMotorNumber, lblORNumber, lblPrice, XrLabel3, lblAssetNumber, XrLabel8, lblType, XrLabel15, lblTransmission, XrLabel19, lblGasoline, XrLabel25, lblSerialNumber, XrLabel33, lblGrossWeight, XrLabel7, lblRim, XrLabel9, lblLastRegistered, XrLabel36, XrLabel5, lblCondition, lblReason, XrLabel11, lblEngine, XrLabel17, lblBodyColor, XrLabel20, lblYear, XrLabel27, lblRegCertNumber, XrLabel31, lblMileAge, XrLabel14, lblLTO})
        ReportRichTextFontSettings({lblRemarks})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class