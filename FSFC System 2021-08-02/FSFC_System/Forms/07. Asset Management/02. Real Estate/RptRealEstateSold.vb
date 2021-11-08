Public Class RptRealEstateSold

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel4, lblDate, XrLabel3, lblAssetNumber, lblSOLD, XrLabel6, lblTCT, XrLabel8, lblLocation, XrLabel11, lblArea, XrLabel5, XrLabel7, lblPrice, XrLabel10, lblStorey, XrLabel19, lblFrames, XrLabel29, lblWalling, XrLabel35, lblPartitions, XrLabel13, lblRoofings, XrLabel21, lblBeams, XrLabel27, lblCeiling, XrLabel37, XrLabel15, lblFloorings, XrLabel23, lblDoors, XrLabel33, lblWindows, XrLabel17, lblTandB, XrLabel25, lblYear, XrLabel31, lblFloorArea, XrLabel37, XrLabel9, lblBuyersName, XrLabel12, lblAddress, XrLabel14, lblBirthdate, XrLabel22, XrLabel16, lblORNumber_2, XrLabel26, lblAmount, XrLabel18, lblORDate})
        ReportRichTextFontSettings({lblRemarks})
        ReportCheckBoxFontSettings({cbxResidential, cbxCommercial, cbxAgricultural, cbxTourism, cbxIndustrial, cbxOthers, cbxVacantLot, cbxMale, cbxFemale})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class