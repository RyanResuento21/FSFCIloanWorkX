Public Class RptSOADetailed

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel41, XrLabel43, XrLabel47, XrLabel48})
        ReportLabelFontSettings({lblAddress, lblContact, XrLabel4, XrLabel7, XrLabel10, XrLabel13, XrLabel15, XrLabel18, XrLabel21, XrLabel25, XrLabel27, XrLabel30, XrLabel33, XrLabel35, XrLabel39, lblName, lblAccountNumber, lblCollateral, lblPrincipal, lblFaceAmount, lblTotalPayments, lblDueDate, lblMonthlyA, lblDateAvailed, lblLastP, lblMaturityD, lblAsOf, XrLabel37, lblMonthsMD, XrLabel49, XrLabel52, XrLabel53, lblBalance, lblUpdatedA, lblBalanceP, lblUpdatedP, lblDaysDelayed, lblHangingA, lblHangingP, XrLabel61, lblArrears, lblDiscount_3, XrLabel64, XrLabel65, lblOthers, lblRebate, lblRebateD, XrLabel73, XrLabel76, lblPenalties, lblDiscount, lblUnpaidPenalties, lblOthersAmount, lblRebateA, lblOverdue, lblTotal, XrLabel80, XrLabel9, XrLabel81, XrLabel78, lblPrepared, lblChecked, lblNoted, lblReceived, XrLabel84, lblAddress_2, lblContact_2, XrLabel5, lblAsOf_2, XrLabel8, XrLabel12, XrLabel16, XrLabel20, XrLabel22, XrLabel24, XrLabel28, lblName_2, lblAccountNumber_2, lblCollateral_2, lblPrincipal_2, lblMonthlyA_2, lblDateAvailed_2, lblLastP_2, XrLabel32, lblBalance_2, lblDiscount_4, lblDiscount_2, lblUnpaidDate_2, lblUnpaidPenalties_2, lblPenaltyDates_2, lblPenalties_2, lblOthers_2, lblOthersAmount_2, lblRebate_2, lblRebateA_2, XrLabel3, lblOverdue_2, XrLabel42, lblTotal_2, XrLabel44, XrLabel11, XrLabel45, XrLabel46, lblPrepared_2, lblChecked_2, lblNoted_2, lblReceived_2, XrLabel50, XrLabel51})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class