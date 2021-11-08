Public Class RptTargetBooking

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel5, lblJanH, XrLabel1, XrLabel3, lblFebH, XrLabel4, XrLabel6, lblMarH, XrLabel7, XrLabel8, lblAprH, XrLabel9, XrLabel10, lblMayH, XrLabel11, XrLabel12, lblJunH, XrLabel13, XrLabel14, lblTotalH, XrLabel15, XrLabel16, XrLabel30})
        ReportLabelFontSettings({lblTitle, lblAsOf, XrLabel2, lblYear, lblProduct, lblBooking_1, lblThreshold_1, lblBooking_2, lblThreshold_2, lblBooking_3, lblThreshold_3, lblBooking_4, lblThreshold_4, lblBooking_5, lblThreshold_5, lblBooking_6, lblThreshold_6, lblBooking_T, lblThreshold_T, lblBooking_1T, lblThreshold_1T, lblBooking_2T, lblThreshold_2T, lblBooking_3T, lblThreshold_3T, lblBooking_4T, lblThreshold_4T, lblBooking_5T, lblThreshold_5T, lblBooking_6T, lblThreshold_6T, lblBooking_TT, lblThreshold_TT, XrLabel44, lblPreparedBy, XrLabel46, XrLabel48, lblCheckedBy, XrLabel47, XrLabel49, lblApprovedBy, XrLabel45})
        ReportCheckBoxFontSettings({cbx1st, cbx2nd})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblBooking_1.BeforePrint, lblThreshold_1.BeforePrint, lblBooking_2.BeforePrint, lblThreshold_2.BeforePrint, lblBooking_3.BeforePrint, lblThreshold_3.BeforePrint, lblBooking_4.BeforePrint, lblThreshold_4.BeforePrint, lblBooking_5.BeforePrint, lblThreshold_5.BeforePrint, lblBooking_6.BeforePrint, lblThreshold_6.BeforePrint, lblBooking_T.BeforePrint, lblThreshold_T.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class