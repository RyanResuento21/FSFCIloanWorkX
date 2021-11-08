Public Class RptRealEstateROPOA

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel1, XrLabel2, lblSOLD, XrLabel4, lblDate, XrLabel6, lblTCT, XrLabel5, XrLabel3, lblAssetNumber, XrLabel8, lblLocation, XrLabel11, lblArea, XrLabel7, lblPrice, XrLabel10, lblStorey, XrLabel19, lblFrames, XrLabel29, lblWalling, XrLabel35, lblPartitions, XrLabel13, lblRoofings, XrLabel21, lblBeams, XrLabel27, lblCeiling, XrLabel37, XrLabel15, lblFloorings, XrLabel23, lblDoors, XrLabel33, lblWindows, XrLabel17, lblTandB, XrLabel25, lblYear, XrLabel31, lblFloorArea})
        ReportRichTextFontSettings({lblRemarks})
        ReportCheckBoxFontSettings({cbxResidential, cbxCommercial, cbxAgricultural, cbxTourism, cbxIndustrial, cbxOthers, cbxVacantLot})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class