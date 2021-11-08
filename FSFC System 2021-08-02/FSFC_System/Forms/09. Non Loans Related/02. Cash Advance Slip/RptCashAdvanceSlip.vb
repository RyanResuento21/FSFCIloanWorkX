Public Class RptCashAdvanceSlip

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel36, XrLabel37})
        ReportLabelFontSettings({lblTitle, XrLabel4, lblPayee, XrLabel8, lblPurpose, XrLabel3, lblDate, XrLabel5, lblAccountNumber, XrLabel27, XrLabel11, XrLabel14, XrLabel17, XrLabel20, XrLabel23, XrLabel26, XrLabel7, XrLabel32, lblMeals, lblTransportation, lblBIR, lblRD, lblLTO, lblNotarizationF, lblOthers, lblTotal, XrLabel9, lblDate_1, lblDate_2, lblDate_3, lblDate_4, lblDate_5, lblDate_6, lblDate_7, lblAmount_1, lblAmount_2, lblAmount_3, lblAmount_4, lblAmount_5, lblAmount_6, lblAmount_7, lblTotalLiquidate, lblHereby, lblDate2, XrLabel62, lblName, XrLabel64, XrLabel19, lblPreparedBy, XrLabel1, XrLabel68, lblApprovedBy, XrLabel67, XrLabel71, lblReceivedBy, XrLabel69, lblReceivedDate, XrLabel73})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class