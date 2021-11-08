Public Class RptPettyCashVoucher

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel36, XrLabel6, XrLabel7, XrLabel32})
        ReportLabelFontSettings({lblTitle, XrLabel4, lblPayee, XrLabel8, lblPurpose, XrLabel3, lblDate, XrLabel5, lblAccountNumber, lblParticular_1, lblDepartment_1, lblAmount_1, lblParticular_2, lblDepartment_2, lblAmount_2, lblParticular_3, lblDepartment_3, lblAmount_3, lblParticular_4, lblDepartment_4, lblAmount_4, lblParticular_5, lblDepartment_5, lblAmount_5, lblParticular_6, lblDepartment_6, lblAmount_6, lblParticular_7, lblDepartment_7, lblAmount_7, lblParticular_8, lblDepartment_8, lblAmount_8, lblParticular_9, lblDepartment_9, lblAmount_9, lblParticular_10, lblDepartment_10, lblAmount_10, lblParticular_11, lblDepartment_11, lblAmount_11, lblParticular_12, lblDepartment_12, lblAmount_12, lblTotal, XrLabel35, lblPreparedBy, XrLabel38, XrLabel68, lblApprovedBy, XrLabel67, XrLabel71, lblReceivedBy, XrLabel69, lblReceivedDate, XrLabel73})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class