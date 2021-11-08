Public Class RptSOA

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({lblAddress, lblContact, lblAsOf, lblName, lblAccountNumber, lblCollateral, lblPrincipal, lblMonthlyA, lblDateAvailed, lblLastP, lblUnpaidDate, lblPenaltyDates, lblOthers, lblRebate, lblPrepared, lblChecked, lblNoted, lblReceived, lblBalance, lblDiscount, lblUnpaidPenalties, lblPenalties, lblOthersAmount, lblRebateA, lblOverdue, lblTotal, lblAddress_2, lblContact_2, lblAsOf_2, lblName_2, lblAccountNumber_2, lblCollateral_2, lblPrincipal_2, lblMonthlyA_2, lblDateAvailed_2, lblLastP_2, lblDiscount_3, lblDiscount_4, lblUnpaidDate_2, lblPenaltyDates_2, lblOthers_2, lblRebate_2, lblPrepared_2, lblChecked_2, lblNoted_2, lblReceived_2, lblBalance_2, lblDiscount_2, lblUnpaidPenalties_2, lblPenalties_2, lblOthersAmount_2, lblRebateA_2, lblOverdue_2, lblTotal_2, XrLabel2, XrLabel4, XrLabel7, XrLabel9, XrLabel11, XrLabel13, XrLabel15, XrLabel17, XrLabel8, XrLabel12, XrLabel16, XrLabel20, XrLabel22, XrLabel24, XrLabel28, XrLabel19, XrLabel1, XrLabel25, XrLabel27, XrLabel18, XrLabel29, XrLabel31, XrLabel33, XrLabel34, XrLabel5, XrLabel8, XrLabel12, XrLabel16, XrLabel20, XrLabel22, XrLabel24, XrLabel28, XrLabel32, lblDiscount_4, XrLabel3, XrLabel42, XrLabel44, XrLabel14, XrLabel45, XrLabel46, XrLabel50, XrLabel51})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub
End Class