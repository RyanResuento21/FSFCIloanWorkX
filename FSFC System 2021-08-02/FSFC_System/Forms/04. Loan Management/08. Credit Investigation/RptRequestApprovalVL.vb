Public Class RptRequestApprovalVL

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel60, XrLabel61, XrLabel58, XrLabel62, XrLabel63, XrLabel64, XrLabel71, XrLabel72, XrLabel82, XrLabel73, XrLabel74, XrLabel75})
        ReportLabelFontSettings({XrLabel1, lblDate, XrLabel7, lblBorrower, lblRepeat, XrLabel5, lblStatus, XrLabel9, lblAge, XrLabel12, lblDependents, XrLabel27, lblSpouse, XrLabel133, lblCI, XrLabel130, lblCoMaker, XrLabel14, lblAddress, XrLabel18, lblLength, XrLabel21, lblFacility, XrLabel24, lblAmountApplied, XrLabel30, lblPurpose, XrLabel33, lblInterest, XrLabel36, lblTerms, XrLabel39, lblModePayment, XrLabel42, lblCollateral, lblPowered, lblCondition, XrLabel11, lblUsage, XrLabel20, lblMileAge, XrLabel45, lblFairMarketValue, lblAppraisedP, lblAppraisedValue, lblLoanableP, lblLoanableValue, lblLoanable, lblFinancingRate, XrLabel48, lblPrincipal, lblFairMarketValue_2, lblCollateralRatio, XrLabel51, lblSourceIncome, lblSourceIncome_CoMaker, XrLabel154, XrLabel55, lblGrossIncome, XrLabel53, lblDisposableIncome, XrLabel56, lblAccountNumber, lblPrincipalEx, lblFaceAmount, lblOB, lblGMA, lblRemarks, lblAccountNumber_1, lblPrincipalEx_1, lblFaceAmount_1, lblOB_1, lblGMA_1, lblRemarks_1, lblAccountNumber_2, lblPrincipalEx_2, lblFaceAmount_2, lblOB_2, lblGMA_2, lblRemarks_2, lblAccountNumber_3, lblPrincipalEx_3, lblFaceAmount_3, lblOB_3, lblGMA_3, lblRemarks_3, lblAccountNumber_4, lblPrincipalEx_4, lblFaceAmount_4, lblOB_4, lblGMA_4, lblRemarks_4, lblAccountNumber_5, lblPrincipalEx_5, lblFaceAmount_5, lblOB_5, lblGMA_5, lblRemarks_5, XrLabel90, lblGMA_0, lblGrossIncome_2, lblBurdenRatio, XrLabel96, lblCreditChecking, XrLabel78, lblAdditionalRemarks, XrLabel81, lblC1, lblC2, lblC3, lblC4, lblC5, lblC6, lblC7, lblC8, lblC9, XrLabel105, XrLabel108, XrLabel111, XrLabel114, lblPreparedBy, lblRecommendedBy, lblApprovedBy, lblApprovedBy_President, lblPreparedBy_Position, XrLabel110, XrLabel113, XrLabel116})
        ReportCheckBoxFontSettings({cbxOwned, cbxRented, cbxFree})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class